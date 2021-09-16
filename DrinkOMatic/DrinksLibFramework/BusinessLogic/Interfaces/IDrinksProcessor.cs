using System;
using System.Threading.Tasks;
using DrinksLibFramework.Models;

namespace DrinksLibFramework.BusinessLogic.Interfaces 
{
    public interface IDrinksProcessor
    {
        void AddOrder(DrinkType drinkType);

        void CancelOrder();

        Task<Cup> TryProcessNextOrder();
    }
}