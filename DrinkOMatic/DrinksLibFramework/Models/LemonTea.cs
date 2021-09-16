using System;
using System.Threading;
using System.Threading.Tasks;
using DrinksLibFramework.Models.Interfaces;

namespace DrinksLibFramework.Models 
{
    public class LemonTea : Drink, ISteepable
    {
        public LemonTea()
        {
            var requiredComponents = DrinksComponent.Water | DrinksComponent.Teabag;
            var additionalComponents = DrinksComponent.Lemon;
            var processes = DrinksProcesses.Boiled | DrinksProcesses.Steeped;

            Id = Guid.NewGuid();
            DrinkType = DrinkType.LemonTea;
            Name = "Lemon Tea";
            Price = GetDrinkPrice(DrinkType.LemonTea);
            Recipe = new Recipe(requiredComponents, additionalComponents, processes);
        }

        public override async Task Make(CancellationToken ct)
        {
            if (ct.IsCancellationRequested)
                return;

            await base.Make(ct);
            AddRequiredComponent(DrinksComponent.Teabag);
            await Steep(ct);
        }

        public Task Steep(CancellationToken ct)
        {
            if (ct.IsCancellationRequested)
                return Task.FromCanceled(ct);

            AddProcess(DrinksProcesses.Steeped);
            return Task.CompletedTask;
        }
    }
}