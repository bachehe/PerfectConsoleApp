
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
        while (true)
        {
            string message = _messages.Greeting();

            _helper.ConsoleWriteLine(message);
        }
    }
}

