using System.Collections.Generic;

namespace DrinksLibFramework.Models.Interfaces 
{
    public interface IVendingMachineInfo
    {
        Dictionary<DrinkType, int> Stock { get; }

        decimal TotalMoneyReceived { get; }

        void ReceiveMoney(decimal amount);

        bool IsInStock(DrinkType drinkType);

        void Load();

        void Save();
    }
}