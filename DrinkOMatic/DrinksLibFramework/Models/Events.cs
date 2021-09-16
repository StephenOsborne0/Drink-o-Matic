using System;
using DrinksLibFramework.Models.Interfaces;

namespace DrinksLibFramework.Models
{
    public class Events
    {
        public class DrinkPurchasedEventArgs : EventArgs
        {
            public DrinkType DrinkType { get; set; }

            public DrinkPurchasedEventArgs(DrinkType drinkType) => DrinkType = drinkType;
        }

        public class NotEnoughMoneyEventArgs : EventArgs
        {
            public decimal MoneyReceived { get; set; }
            public decimal MoneyRequired { get; set; }

            public decimal AdditionalMoneyRequired => MoneyRequired - MoneyReceived;

            public NotEnoughMoneyEventArgs(decimal moneyReceived, decimal moneyRequired)
            {
                MoneyReceived = moneyReceived;
                MoneyRequired = moneyRequired;
            }
        }

        public class DrinkOutOfStockEventArgs : EventArgs
        {
            public DrinkType DrinkType { get; set; }

            public DrinkOutOfStockEventArgs(DrinkType drinkType) => DrinkType = drinkType;
        }

        public class DrinkProcessingEventArgs : EventArgs
        {
            public IDrink Drink { get; set; }

            public DrinkProcessingEventArgs(IDrink drink) => Drink = drink;
        }

        public class DrinkFinishedProcessingEventArgs : EventArgs
        {
            public Cup Cup { get; set; }

            public DrinkFinishedProcessingEventArgs(Cup cup) => Cup = cup;
        }

        public class ProcessCompletedEventArgs : EventArgs
        {
            public DrinksProcesses Process { get; set; }

            public ProcessCompletedEventArgs(DrinksProcesses process) => Process = process;
        }

        public class ComponentAddedEventArgs : EventArgs
        {
            public DrinksComponent Component { get; set; }

            public ComponentAddedEventArgs(DrinksComponent component) => Component = component;
        }
    }
}
