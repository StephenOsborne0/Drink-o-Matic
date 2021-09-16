using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DrinksLibFramework.BusinessLogic.Factories.Interfaces;
using DrinksLibFramework.BusinessLogic.Interfaces;
using DrinksLibFramework.Models;

namespace DrinksLibFramework.BusinessLogic
{
    public class DrinksProcessor : IDrinksProcessor
    {
        private readonly CancellationTokenSource _cancellationTokenSource;
        private readonly Queue<(DrinkType drinkType, CancellationToken token)> _drinksQueue = new Queue<(DrinkType, CancellationToken)>();
        private readonly IDrinksFactory _drinksFactory;

        public DrinksProcessor(IDrinksFactory drinksFactory)
        {
            _drinksFactory = drinksFactory;
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public void AddOrder(DrinkType drinkType)
        {
            DrinkPurchased?.Invoke(this, new Events.DrinkPurchasedEventArgs(drinkType));
            _drinksQueue.Enqueue((drinkType, _cancellationTokenSource.Token));
        }

        public void CancelOrder() => _cancellationTokenSource.Cancel();

        public async Task<Cup> TryProcessNextOrder()
        {
            if (_drinksQueue.Any())
            {
                var drinkOrder = _drinksQueue.Peek();

                if (drinkOrder.drinkType != 0)
                    return await ProcessNextOrder();
            }

            return null;
        }

        private async Task<Cup> ProcessNextOrder()
        {
            var drinkOrder = _drinksQueue.Dequeue();
            return await ProcessDrink(drinkOrder.drinkType, drinkOrder.token);
        }

        private async Task<Cup> ProcessDrink(DrinkType drinkType, CancellationToken ct)
        {
            var cup = new Cup();

            var drink = _drinksFactory.Create(drinkType);
            DrinkProcessing?.Invoke(this, new Events.DrinkProcessingEventArgs(drink));

            await drink.Make(ct);

            cup.Pour(drink);
            
            if (drink.Recipe.AdditionalComponents != 0)
                drink.AddAdditionalComponent(drink.Recipe.AdditionalComponents);

            DrinkFinishedProcessing?.Invoke(this, new Events.DrinkFinishedProcessingEventArgs(cup));
            return cup;
        }

        public static event EventHandler<Events.DrinkPurchasedEventArgs> DrinkPurchased;

        public static event EventHandler<Events.DrinkProcessingEventArgs> DrinkProcessing;

        public static event EventHandler<Events.DrinkFinishedProcessingEventArgs> DrinkFinishedProcessing;
    }
}
