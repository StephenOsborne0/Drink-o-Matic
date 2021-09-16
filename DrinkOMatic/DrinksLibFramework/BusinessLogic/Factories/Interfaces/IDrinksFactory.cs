using DrinksLibFramework.Models;
using DrinksLibFramework.Models.Interfaces;

namespace DrinksLibFramework.BusinessLogic.Factories.Interfaces {
    public interface IDrinksFactory
    {
        IDrink Create(DrinkType drinkType);
    }
}