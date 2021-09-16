using System;

namespace DrinksLib.Models
{
    public class Events
    {
        public class DrinkPurchasedEventArgs : EventArgs
        {
            public DrinkType DrinkType { get; set; }

            public DrinkPurchasedEventArgs(DrinkType drinkType) => DrinkType = drinkType;
        }
    }
}
