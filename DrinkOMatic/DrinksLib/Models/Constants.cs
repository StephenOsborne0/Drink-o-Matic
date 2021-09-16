using System;
using System.Collections.Generic;

namespace DrinksLib.Models
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
    }

    public enum DrinkType
    {
        None = 0,
        LemonTea = 1 << 1,
        Coffee = 1 << 2,
        HotChocolate = 1 << 3
    }

    [Flags]
    public enum DrinksComponent
    {
        None = 0,
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
        None = 0,
        Boiled = 1 << 1,
        Brewed = 1 << 2,
        Steeped = 1 << 3
    }
}
