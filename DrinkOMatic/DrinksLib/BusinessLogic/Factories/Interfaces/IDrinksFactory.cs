using DrinksLib.Models;

namespace DrinksLib.BusinessLogic {
    public interface IDrinksFactory
    {
        IDrink Create(DrinkType drinkType);
    }
}