using System;
using System.Collections.Generic;
using DrinksLib.Helpers;

namespace DrinksLib.Models
{
    public class VendingMachineInfo
    {
        public Dictionary<DrinkType, int> Stock { get; private set; }

        public decimal TotalMoneyReceived { get; private set; }

        public VendingMachineInfo()
        {
            Stock = new Dictionary<DrinkType, int>();

            var drinkTypes = Enum.GetValues(typeof(DrinkType));

            foreach (var drinkType in drinkTypes)
                Stock.Add((DrinkType) drinkType, 0);
        }

        public void ReceiveMoney(DrinkType drinkType) => TotalMoneyReceived += Drink.GetDrinkPrice(drinkType);

        public bool IsInStock(DrinkType drinkType)
        {
            if (!Stock.ContainsKey(drinkType))
                throw new Exception($"Drink type {Enum.GetName(typeof(DrinkType), drinkType)} not found in stock");

            return Stock[drinkType] > 0;
        }

        public void Load(string filepath)
        {
            var vendState = Serialization.Deserialize<VendingMachineInfo>(filepath);
            Stock = vendState.Stock;
            TotalMoneyReceived = vendState.TotalMoneyReceived;
        }

        public void Save(string filepath) => Serialization.Serialize<VendingMachineInfo>(filepath, this);
    }
}
