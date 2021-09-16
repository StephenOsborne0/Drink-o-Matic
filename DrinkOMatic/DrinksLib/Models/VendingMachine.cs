using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using DrinksLib.BusinessLogic;
using DrinksLib.Helpers;

namespace DrinksLib.Models
{
    public class VendingMachine
    {
        //TODO: List processes (trace)
        //TODO: Error handling

        private readonly IDrinksFactory _drinksFactory;
        private readonly VendingMachineInfo _vendingMachineInfo;
        private VendState _vendState;
        private decimal _moneyInserted;
        private Cup _cup;
        private readonly CancellationTokenSource _cancellationTokenSource;
        private readonly Queue<(DrinkType drinkType, CancellationToken token)> _drinksQueue = new Queue<(DrinkType, CancellationToken)>();
        private readonly string _vendingInfoFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "vendingInfo.json");

        public VendingMachine(IDrinksFactory drinksFactory)
        {
            _drinksFactory = drinksFactory;
            _vendingMachineInfo = new VendingMachineInfo();

            if (File.Exists(_vendingInfoFilePath))
                _vendingMachineInfo.Load(_vendingInfoFilePath);

            _cancellationTokenSource = new CancellationTokenSource();
            _vendState = VendState.AwaitingOrder;
        }

        public void InsertMoney(decimal amount) => _moneyInserted += amount;

        public void DrinkButtonPressed(int buttonIndex)
        {
            var drinkType = DrinksHelper.GetDrinkTypeForButton(buttonIndex);
            TryPlaceOrder(drinkType);
        }

        public void CancelButtonPressed() => CancelOrder();

        public void RefundButtonPressed() => RefundMoney();

        private void TryPlaceOrder(DrinkType drinkType)
        {
            if (CanPurchaseDrink(drinkType))
                PurchaseDrink(drinkType);
        }

        private bool CanPurchaseDrink(DrinkType drinkType)
        {
            var price = Drink.GetDrinkPrice(drinkType);
            var inStock = _vendingMachineInfo.IsInStock(drinkType);
            return inStock && _moneyInserted >= price;
        }

        private void PurchaseDrink(DrinkType drinkType)
        {
            var price = Drink.GetDrinkPrice(drinkType);
            _drinksQueue.Enqueue((drinkType, _cancellationTokenSource.Token));
            _moneyInserted -= price;
            DrinkPurchased?.Invoke(this, new Events.DrinkPurchasedEventArgs(drinkType));
        }

        private async void ProcessNext((DrinkType drinkType, CancellationToken ct) drinkOrder)
        {
            _vendState = VendState.ProcessingDrink;
            _vendState = VendState.AwaitingOrder;
            _cup = await ProcessDrink(drinkOrder.drinkType, drinkOrder.ct);
        }

        private void CancelOrder() => _cancellationTokenSource.Cancel();

        private void RefundMoney() => _moneyInserted = 0;

        private DisplayUpdate Update()
        {
            switch (_vendState)
            {
                case VendState.AwaitingOrder:
                { 
                    if(_drinksQueue.TryPeek(out var drinkOrder))
                        ProcessNext(drinkOrder);
                        
                    return new DisplayUpdate(new[] { "Awaiting order...", "Buy 2 for £1.70" });
                }

                case VendState.ProcessingDrink:
                    return new DisplayUpdate(new[] { "Processing your drink, please wait..." });

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private async Task<Cup> ProcessDrink(DrinkType drinkType, CancellationToken ct)
        {
            var cup = new Cup();
            var drink = _drinksFactory.Create(drinkType);
            await drink.Make(ct);

            while (!drink.IsReadyToPour)
                Thread.Sleep(1000);

            cup.Pour(drink);
            drink.AddAdditionalComponent(drink.AdditionalComponents);
            return cup;
        }

        public event EventHandler<Events.DrinkPurchasedEventArgs> DrinkPurchased;

        private enum VendState
        {
            AwaitingOrder,
            ProcessingDrink
        }
    }
}
