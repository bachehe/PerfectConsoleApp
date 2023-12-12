using UltimateLibrary.Interfaces;
using UltimateLibrary.Models;

namespace UltimateLibrary.Helpers
{
    public static class ConsoleHelper
    {
        public static string ErrorTranslation { get; private set; } = "No Translation Found";
        public static string ErrorLookingForTranslation { get; private set; } = "Error looking up for translation";
        public static string InvalidKey { get; private set; } = "Invalid Key, please try harder";

        public static void ConsoleWriteLine(List<Languages> lang)
        {
            
            Console.WriteLine("Select Language:\n");

            foreach (var item in lang)
            {
                Console.WriteLine(item.Language);
            }
            Console.WriteLine("\n");
        }
        public static void ConsoleWriteLine(string message)
        {
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine("\n"+ message + "\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void ConsoleWriteLineExit()
        {
            Console.WriteLine("THE.PERFECT.APP will be closed...");
        }
    }
}
