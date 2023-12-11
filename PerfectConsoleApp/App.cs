
using UltimateLibrary.Interfaces;

namespace PerfectConsoleApp;

public class App
{
    private readonly IMessages _messages;
    private readonly IConsoleHelper _helper;

    public App(IMessages messages, IConsoleHelper helper)
    {
        _messages = messages;
        _helper = helper;
    }

    public void Run(string[] args)
    {
        var IsActive = true;
        while (IsActive)
        {
            string message = _messages.Greeting();

            if (Console.ReadLine() == "x")
            {
                IsActive = false;
                if (!IsActive) _helper.ConsoleWriteLineExit();
                break;
            }

            _helper.ConsoleWriteLine(message);
        }
    }
}

