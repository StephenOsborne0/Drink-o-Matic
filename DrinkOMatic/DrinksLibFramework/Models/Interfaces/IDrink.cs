using System;
using System.Threading;
using System.Threading.Tasks;

namespace DrinksLibFramework.Models.Interfaces 
{
    public interface IDrink
    {
        Guid Id { get; }

        DrinkType DrinkType { get; }

        string Name { get; }

        decimal Price { get; }

        Recipe Recipe { get; }

        bool IsReadyToPour { get; }

        Task Make(CancellationToken ct);

        Task BoilWater(CancellationToken ct);

        Task Pour(Cup cup, CancellationToken ct);

        void AddAdditionalComponent(DrinksComponent component);

        DrinksComponent AdditionalComponents { get; }
    }
}