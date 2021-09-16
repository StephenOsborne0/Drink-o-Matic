using System;
using System.Threading;
using System.Threading.Tasks;
using DrinksLib.Models;

namespace DrinksLib
{
    public abstract class Drink : IDrink
    {
        public Guid Id { get; protected set; }

        public DrinkType DrinkType { get; protected set; }

        public string Name { get; protected set; }

        public decimal Price { get; protected set; }

        public Recipe Recipe { get; protected set; }

        public DrinksComponent RequiredComponents { get; set; }

        public DrinksComponent AdditionalComponents { get; set; }

        public DrinksProcesses Processes { get; set; }

        public bool IsReadyToPour => Recipe != null 
                                       && RequiredComponents == Recipe.RequiredComponents 
                                       && Processes == Recipe.Processes;

        public virtual async Task Make(CancellationToken ct)
        {
            if (ct.IsCancellationRequested)
                return;

            await BoilWater(ct);
        }

        public Task BoilWater(CancellationToken ct)
        {
            if (ct.IsCancellationRequested)
                return Task.FromCanceled(ct);

            AddRequiredComponent(DrinksComponent.Water);
            AddProcess(DrinksProcesses.Boiled);
            return Task.CompletedTask;
        }

        public Task Pour(Cup cup, CancellationToken ct)
        {
            cup.Drink = this;
            return Task.CompletedTask;
        }

        public void AddRequiredComponent(DrinksComponent component) => RequiredComponents |= component;

        public void AddAdditionalComponent(DrinksComponent component) => AdditionalComponents |= component;

        protected void AddProcess(DrinksProcesses process) => Processes |= process;

        public static decimal GetDrinkPrice(DrinkType drinkType) => Constants.DrinkPrices.ContainsKey(drinkType) 
                                                                         ? Constants.DrinkPrices[drinkType] 
                                                                         : throw new Exception($"No price stated for drink type {Enum.GetName(typeof(DrinkType), drinkType)}");
    }

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

    public class HotChocolate : Drink
    {
        public HotChocolate()
        {
            var requiredComponents = DrinksComponent.Water | DrinksComponent.ChocolatePowder;
            var additionalComponents = DrinksComponent.None;
            var processes = DrinksProcesses.Boiled;

            Id = Guid.NewGuid();
            DrinkType = DrinkType.HotChocolate;
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
