using System;
using System.Collections.Generic;
using System.Linq;
using DrinksLibFramework.Models;

namespace DrinksLibFramework.Helpers
{
    public class DrinksHelper
    {
        public static List<string> GetComponentNames(DrinksComponent components)
        {
            return Enum.GetValues(typeof(DrinksComponent))
                .Cast<DrinksComponent>()
                .Where(component => components.HasFlag(component))
                .Select(component => component.ToString())
                .ToList();
        }

        public static List<string> GetProcessNames(DrinksProcesses processes)
        {
            return Enum.GetValues(typeof(DrinksProcesses))
                       .Cast<DrinksProcesses>()
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
