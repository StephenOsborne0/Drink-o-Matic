using System;
using System.Threading;
using System.Threading.Tasks;
using DrinksLib.Models;

namespace DrinksLib 
{
    public interface IDrink
    {
        Guid Id { get; }

        DrinkType DrinkType { get; }

        string Name { get; }

        decimal Price { get; }

        bool IsReadyToPour { get; }

        Task Make(CancellationToken ct);

        Task BoilWater(CancellationToken ct);

        Task Pour(Cup cup, CancellationToken ct);

        void AddAdditionalComponent(DrinksComponent component);

        DrinksComponent AdditionalComponents { get; }
    }
}