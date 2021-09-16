namespace DrinksLib.Models
{
    public class Recipe
    {
        public DrinksComponent RequiredComponents { get; }
        public DrinksComponent AdditionalComponents { get; }
        public DrinksProcesses Processes { get; }

        public Recipe(DrinksComponent requiredComponents, DrinksComponent additionalComponents, DrinksProcesses processes)
        {
            RequiredComponents = requiredComponents;
            AdditionalComponents = additionalComponents;
            Processes = processes;
        }
    }
}
