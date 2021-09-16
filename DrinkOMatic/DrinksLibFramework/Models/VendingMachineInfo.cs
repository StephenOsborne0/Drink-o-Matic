using System;
using System.Collections.Generic;
using System.IO;
using DrinksLibFramework.BusinessLogic.Serialization;
using DrinksLibFramework.Models.Interfaces;

namespace DrinksLibFramework.Models
{
    public class VendingMachineInfo : IVendingMachineInfo
    {
        public Dictionary<DrinkType, int> Stock { get; private set; }

        public decimal TotalMoneyReceived { get; private set; }

        public VendingMachineInfo()
        {
            Stock = new Dictionary<DrinkType, int>();

            var drinkTypes = Enum.GetValues(typeof(DrinkType));

            foreach (var drinkType in drinkTypes)
                Stock.Add((DrinkType) drinkType, 5);
        }

        public void ReceiveMoney(decimal amount) => TotalMoneyReceived += amount;

        public bool IsInStock(DrinkType drinkType)
        {
            if (!Stock.ContainsKey(drinkType))
                throw new Exception($"Drink type {Enum.GetName(typeof(DrinkType), drinkType)} not found in stock");

            return Stock[drinkType] > 0;
        }

        public void Load()
        {
            var filepath = Constants.VendingMachineOutputFilePath;

            if (!File.Exists(filepath))
                return;

            var vendState = Serialization.Deserialize<VendingMachineInfo>(filepath);
            Stock = vendState.Stock;
            TotalMoneyReceived = vendState.TotalMoneyReceived;
        }

        public void Save() => Serialization.Serialize<VendingMachineInfo>(Constants.VendingMachineOutputFilePath, this);
    }
}
