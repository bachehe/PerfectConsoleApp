
using UltimateLibrary.Interfaces;
using UltimateLibrary.Models;

namespace UltimateLibrary.Helpers
{
    public class ConsoleHelper : IConsoleHelper
    {
        public string ErrorTranslation { get; private set; }
        public string ErrorLookingForTranslation { get; private set; }
        public string InvalidKey { get; private set; }

        public ConsoleHelper()
        {
            ErrorTranslation = "No Translation Found";
            ErrorLookingForTranslation = "Error looking up for translation";
            InvalidKey = "Invalid Key, please try harder";
        }

        public void ConsoleWriteLine(List<Languages> lang)
        {
            Console.WriteLine("Select Language:\n");

            foreach (var item in lang)
            {
                Console.WriteLine(item.Language);
            }
            Console.WriteLine("\n");
        }
        public void ConsoleWriteLine(string message)
        {
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine("\n"+ message + "\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void ConsoleWriteLineExit()
        {
            Console.WriteLine("THE.PERFECT.APP will be closed...");
        }
    }
}
