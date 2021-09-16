using System;
using System.Threading;
using DrinksLibFramework.BusinessLogic;
using DrinksLibFramework.BusinessLogic.Interfaces;
using DrinksLibFramework.Helpers;
using DrinksLibFramework.Models.Interfaces;

namespace DrinksLibFramework.Models
{
    public class VendingMachine
    {
        //TODO: Trace logging
        //TODO: Add error handling
        //TODO: Set display message timeout rather than timer based

        public decimal MoneyInserted { get; private set; }

        private readonly IVendingMachineInfo _vendingMachineInfo;
        private readonly IDrinksProcessor _drinksProcessor;
        private VendState _vendState;
        public Cup Cup { get; set; }

        private string _displayMessage;

        public VendingMachine(IVendingMachineInfo vendingMachineInfo, IDrinksProcessor drinksProcessor)
        {
            _drinksProcessor = drinksProcessor;
            _vendingMachineInfo = vendingMachineInfo;
            _vendingMachineInfo.Load();
            _vendState = VendState.AwaitingOrder;
            _displayMessage = Constants.AwaitingOrder;

            DrinksProcessor.DrinkPurchased += OnDrinkPurchased;
            DrinksProcessor.DrinkProcessing += OnDrinkProcessing;
            DrinksProcessor.DrinkFinishedProcessing += OnDrinkFinishedProcessing;
        }

        public void InsertMoney(decimal amount) => MoneyInserted += amount;

        public void DrinkButtonPressed(int buttonIndex)
        {
            var drinkType = DrinksHelper.GetDrinkTypeForButton(buttonIndex);
            TryPlaceOrder(drinkType);
        }

        public void CancelButtonPressed() => CancelOrder();

        public void RefundButtonPressed() => RefundMoney();

        private void TryPlaceOrder(DrinkType drinkType)
        {
            var drinkPrice = Drink.GetDrinkPrice(drinkType);

            if (MoneyInserted < drinkPrice)
                NotEnoughMoney?.Invoke(this, new Events.NotEnoughMoneyEventArgs(MoneyInserted, drinkPrice));

            else if (!_vendingMachineInfo.IsInStock(drinkType))
                DrinkOutOfStock?.Invoke(this, new Events.DrinkOutOfStockEventArgs(drinkType));
            
            else 
                PurchaseDrink(drinkType);
        }

        private bool CanPurchaseDrink(DrinkType drinkType) => MoneyInserted >= Drink.GetDrinkPrice(drinkType);

        private void PurchaseDrink(DrinkType drinkType) => _drinksProcessor.AddOrder(drinkType);

        private void CancelOrder()
        {
            if (_vendState == VendState.ProcessingDrink)
                _drinksProcessor.CancelOrder();
        }

        private void RefundMoney() => MoneyInserted = 0;

        public void Update()
        {
            if (_vendState == VendState.ProcessingDrink)
                return;

            var thread = new Thread(() => Cup = _drinksProcessor.TryProcessNextOrder().Result);
            thread.Start();
        }

        public string GetDisplayMessage() => _displayMessage;

        public void OnDrinkPurchased(object sender, Events.DrinkPurchasedEventArgs e)
        {
            var price = Drink.GetDrinkPrice(e.DrinkType);
            MoneyInserted -= price;
            _vendingMachineInfo.Stock[e.DrinkType]--;
            _vendingMachineInfo.ReceiveMoney(price);
            _vendingMachineInfo.Save();
            _displayMessage = Constants.PurchasedDrink;
        }

        public void OnDrinkProcessing(object sender, Events.DrinkProcessingEventArgs e)
        {
            _displayMessage = Constants.ProcessingDrink;
            _vendState = VendState.ProcessingDrink;
        }

        public void OnDrinkFinishedProcessing(object sender, Events.DrinkFinishedProcessingEventArgs e)
        {
            _displayMessage = Constants.AwaitingOrder;
            _vendState = VendState.AwaitingOrder;
        }

        private enum VendState
        {
            AwaitingOrder,
            ProcessingDrink
        }


        public static event EventHandler<Events.DrinkOutOfStockEventArgs> DrinkOutOfStock;
        public static event EventHandler<Events.NotEnoughMoneyEventArgs> NotEnoughMoney;
    }
}
