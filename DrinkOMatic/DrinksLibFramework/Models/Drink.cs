using System;
using System.Threading;
using System.Threading.Tasks;
using DrinksLibFramework.Models.Interfaces;

namespace DrinksLibFramework.Models
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

        public void AddRequiredComponent(DrinksComponent component)
        {
            RequiredComponents |= component;
            ComponentAdded?.Invoke(this, new Events.ComponentAddedEventArgs(component));
        }

        public void AddAdditionalComponent(DrinksComponent component)
        {
            AdditionalComponents |= component;
            ComponentAdded?.Invoke(this, new Events.ComponentAddedEventArgs(component));
        }

        protected void AddProcess(DrinksProcesses process)
        {
            Processes |= process;
            Thread.Sleep(5000);
            ProcessCompleted?.Invoke(this, new Events.ProcessCompletedEventArgs(process));
        }

        public static decimal GetDrinkPrice(DrinkType drinkType) => Constants.DrinkPrices.ContainsKey(drinkType) 
                                                                         ? Constants.DrinkPrices[drinkType] 
                                                                         : throw new Exception($"No price stated for drink type {Enum.GetName(typeof(DrinkType), drinkType)}");

        public static event EventHandler<Events.ProcessCompletedEventArgs> ProcessCompleted;

        public static event EventHandler<Events.ComponentAddedEventArgs> ComponentAdded;
    }
}
