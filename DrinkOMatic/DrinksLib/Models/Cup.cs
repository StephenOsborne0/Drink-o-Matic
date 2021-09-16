namespace DrinksLib.Models
{
    public class Cup
    {
        public IDrink Drink { get; set; }

        public void Pour<T>(T drink) where T : IDrink => Drink = drink;
    }
}
