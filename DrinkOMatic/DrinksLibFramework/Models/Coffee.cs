using System;
using System.Threading;
using System.Threading.Tasks;
using DrinksLibFramework.Models.Interfaces;

namespace DrinksLibFramework.Models 
{
    public class Coffee : Drink, IBrewable
    {
        public Coffee()
        {
            var requiredComponents = DrinksComponent.Water | DrinksComponent.CoffeeGrounds;
            var additionalComponents = DrinksComponent.Sugar | DrinksComponent.Milk;
            var processes = DrinksProcesses.Boiled | DrinksProcesses.Brewed;

            Id = Guid.NewGuid();
            DrinkType = DrinkType.Coffee;
            Name = "Coffee";
            Price = GetDrinkPrice(DrinkType.Coffee);
            Recipe = new Recipe(requiredComponents, additionalComponents, processes);
        }

        public override async Task Make(CancellationToken ct)
        {
            if (ct.IsCancellationRequested)
                return;

            await base.Make(ct);
            AddRequiredComponent(DrinksComponent.CoffeeGrounds);
            await Brew(ct);
        }

        public Task Brew(CancellationToken ct)
        {
            if (ct.IsCancellationRequested)
                return Task.FromCanceled(ct);

            AddProcess(DrinksProcesses.Brewed);
            return Task.CompletedTask;
        }
    }
}