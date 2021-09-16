using System;
using System.Collections.Generic;
using System.Linq;
using DrinksLib.Models;

namespace DrinksLib.Helpers
{
    public class DrinksHelper
    {
        public List<string> GetComponentNames(DrinksComponent components)
        {
            return Enum.GetValues(typeof(DrinksComponent))
                .Cast<DrinksComponent>()
                .Where(component => components.HasFlag(component))
                .Select(component => component.ToString())
                .ToList();
        }

        public List<string> GetProcessNames(DrinksProcesses processes)
        {
            return Enum.GetValues(typeof(DrinksComponent))
                       .Cast<DrinksComponent>()
                       .Where(process => processes.HasFlag(process))
                       .Select(process => process.ToString())
                       .ToList();
        }

        public static DrinkType GetDrinkTypeForButton(int buttonIndex)
        {
            if (Constants.ButtonMapping.ContainsKey(buttonIndex))
                return Constants.ButtonMapping[buttonIndex];

            throw new Exception($"Button mapping not set for {buttonIndex}");
        }
    }
}
