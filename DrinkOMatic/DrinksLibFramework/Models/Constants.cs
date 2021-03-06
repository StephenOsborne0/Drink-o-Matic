using System;
using System.Collections.Generic;
using System.IO;

namespace DrinksLibFramework.Models
{

    public class Constants
    {
        public static Dictionary<int, DrinkType> ButtonMapping = new Dictionary<int, DrinkType>
        {
            { 0, DrinkType.Coffee },
            { 1, DrinkType.LemonTea },
            { 2, DrinkType.HotChocolate }
        };

        public static Dictionary<DrinkType, decimal> DrinkPrices = new Dictionary<DrinkType, decimal>
        {
            { DrinkType.Coffee, 1.50m },
            { DrinkType.LemonTea, 1.00m },
            { DrinkType.HotChocolate, 1.20m }
        };

        public const string AwaitingOrder = "Awaiting order...";
        public const string PurchasedDrink = "Thank you for your order";
        public const string ProcessingDrink = "Processing drink, please wait...";
        public const string OutOfStock = "{0} out of stock!";
        public const string NotEnoughMoney = "Not enough money inserted. {0} more required";

        public static string VendingMachineOutputFilePath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "vendingInfo.json");
    }

    public enum DrinkType
    {
        LemonTea = 1 << 1,
        Coffee = 1 << 2,
        HotChocolate = 1 << 3
    }

    [Flags]
    public enum DrinksComponent
    {
        Water = 1 << 1,
        Teabag = 1 << 2,
        CoffeeGrounds = 1 << 3,
        Sugar = 1 << 4,
        Milk = 1 << 5,
        ChocolatePowder = 1 << 6,
        Lemon = 1 << 7
    }

    [Flags]
    public enum DrinksProcesses
    {
        Boiled = 1 << 1,
        Brewed = 1 << 2,
        Steeped = 1 << 3
    }
}
