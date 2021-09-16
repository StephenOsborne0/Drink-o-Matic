using System;
using System.Threading;
using System.Threading.Tasks;

namespace DrinksLibFramework.Models 
{
    public class HotChocolate : Drink
    {
        public HotChocolate()
        {
            var requiredComponents = DrinksComponent.Water | DrinksComponent.ChocolatePowder;
            var additionalComponents = (DrinksComponent)0;
            var processes = DrinksProcesses.Boiled;

            Id = Guid.NewGuid();
            DrinkType = DrinkType.HotChocolate;
            Name = "Hot Chocolate";
            Price = GetDrinkPrice(DrinkType.HotChocolate);
            Recipe = new Recipe(requiredComponents, additionalComponents, processes);
        }

        public override async Task Make(CancellationToken ct)
        {
            if (ct.IsCancellationRequested)
                return;

            await base.Make(ct);
            AddRequiredComponent(DrinksComponent.ChocolatePowder);
        }
    }
}