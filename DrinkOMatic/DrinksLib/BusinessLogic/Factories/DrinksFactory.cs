using System;
using DrinksLib.Models;

namespace DrinksLib.BusinessLogic
{
    public class DrinksFactory : IDrinksFactory
    {
        public IDrink Create(DrinkType drinkType)
        {
            switch (drinkType)
            {
                case DrinkType.LemonTea:
                    return new LemonTea();

                case DrinkType.Coffee:
                    return new Coffee();

                case DrinkType.HotChocolate:
                    return new HotChocolate();

                default:
                    throw new ArgumentOutOfRangeException(nameof(drinkType), drinkType, null);
            }
        }
    }
}
