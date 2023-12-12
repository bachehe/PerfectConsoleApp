using UltimateLibrary.Interfaces;

namespace PerfectConsoleApp;

public class App
{
    private readonly IMessages _messages;

    public App(IMessages messages)
    {
        _messages = messages;
    }

    public void Run(string[] args)
    {
        while (true)
        {
            string message = _messages.Greeting();

            Console.WriteLine(message);
        }
    }
}

