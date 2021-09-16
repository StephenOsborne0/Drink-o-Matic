namespace DrinksLib.Models
{
    public class DisplayUpdate
    {
        public string[] Messages { get; set; }

        public DisplayUpdate(string[] messages) => Messages = messages;
    }
}
