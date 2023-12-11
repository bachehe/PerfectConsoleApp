using UltimateLibrary.Models;

namespace UltimateLibrary.Interfaces;

public interface IConsoleHelper
{
    string ErrorLookingForTranslation { get; }
    string ErrorTranslation { get; }
    string InvalidKey { get; }

    void ConsoleWriteLine(List<Languages> lang);
    void ConsoleWriteLine(string message);
    void ConsoleWriteLineExit();
}
