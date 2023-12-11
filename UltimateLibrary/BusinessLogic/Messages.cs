using Microsoft.Extensions.Logging;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using UltimateLibrary.Helpers;
using UltimateLibrary.Interfaces;
using UltimateLibrary.Models;

namespace UltimateLibrary.BusinessLogic;

public class Messages : IMessages
{
    private const string GREETING = "Greeting";
    private const string JsonPath = "Data\\LanguageTranslations.json";
    private readonly ILogger<Messages> _log;
    private readonly IConsoleHelper _helper;

    public Messages(ILogger<Messages> log, IConsoleHelper helper)
    {
        _log = log;
        _helper = helper;
    }
    private string LookUpTranslation(string key, string language)
    {
        if (!IsValidString(key, language))
            return string.Empty;


        try
        {
            //Take json file and deserialize it into single string
            var msgSets = Deserialise();

            var msgs = msgSets.Where(x => x.Language == language).First();

            if (!IsValidString(msgs.Language, msgs.Translation[key]))
                throw new Exception(_helper.ErrorTranslation);

            return msgs.Translation[key];
        }
        catch (Exception ex)
        {
            _log.LogError(_helper.ErrorLookingForTranslation, ex);
            throw new Exception(ex.Message);
        }
    }
    private string HandleConversation()
    {
        JsonSerializerOptions opt = new()
        {
            PropertyNameCaseInsensitive = true
        };

        var msgSets = Deserialise();

        _helper.ConsoleWriteLine(msgSets);

        var res = Console.ReadLine();

        foreach (var item in msgSets)
        {
            if (res == item.Language)
                return res;
        }

        return string.Empty;
    }

    private List<Languages> Deserialise()
    {
        JsonSerializerOptions opt = new()
        {
            PropertyNameCaseInsensitive = true
        };

        var msgSets = JsonSerializer
           .Deserialize<List<Languages>>
           (
               File.ReadAllText(JsonPath), opt
           );

        return msgSets;
    }

    public string Greeting()
    {
        var selectedLanguage = HandleConversation();

        if (selectedLanguage == string.Empty && selectedLanguage != "x")
            return _helper.InvalidKey;

        return LookUpTranslation(GREETING, selectedLanguage);
    }

    public bool IsValidString(params string[] values)
    {
        foreach (var value in values)
        {
            if (value == null || value == string.Empty)
                return false;
        }
        return true;
    }
}

