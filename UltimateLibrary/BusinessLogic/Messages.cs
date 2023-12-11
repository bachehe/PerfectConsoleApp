using Microsoft.Extensions.Logging;
using System.Text.Json;
using UltimateLibrary.Interfaces;
using UltimateLibrary.Models;

namespace UltimateLibrary.BusinessLogic;

public class Messages : IMessages
{
    private const string GREETING = "Greeting";
    private readonly ILogger<Messages> _log;

    public Messages(ILogger<Messages> log)
    {
        _log = log;
    }
    private string LookUpTranslation(string key, string language)
    {
        if (!IsValidString(key, language))
            return string.Empty;

        JsonSerializerOptions opt = new()
        {
            PropertyNameCaseInsensitive = true
        };

        try
        {
            //Take json file and deserialize it into single string
            var msgSets = JsonSerializer
                .Deserialize<List<Languages>>
                (
                    File.ReadAllText("Data\\LanguageTranslations.json"), opt
                );

            var msgs = msgSets.Where(x => x.Language == language).First();

            if (!IsValidString(msgs.Language, msgs.Translation[key]))
                throw new Exception("No translation found");

            return msgs.Translation[key];
        }
        catch (Exception ex)
        {
            _log.LogError("Error looking up for translation", ex);
            throw new Exception(ex.Message);
        }
    }

    public string Greeting(string language)
        => LookUpTranslation(GREETING, language);

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

