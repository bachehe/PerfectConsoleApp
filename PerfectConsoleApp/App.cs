
using UltimateLibrary.Interfaces;

namespace PerfectConsoleApp;

public class App
{
    private readonly IMessages _messages;
    private const string SUBSTRING = "-lang=";

    public App(IMessages messages)
    {
        _messages = messages;
    }

    public void Run(string[] args)
    {
        string lang = "es";

        for (int i = 0; i < args.Length; i++)
        {
            if (args[i].ToLower().StartsWith(SUBSTRING))
            {
                lang = args[i].Substring(SUBSTRING.Length);
                break;
            }
        }

        string message = _messages.Greeting(lang);
        Console.WriteLine(message);
    }
}

