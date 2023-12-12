using Microsoft.Extensions.Logging;
using System.Text.Json;
using UltimateLibrary.Helpers;
using UltimateLibrary.Interfaces;
using UltimateLibrary.Models;

namespace UltimateLibrary.BusinessLogic;

public class Messages : IMessages
{
    #region CONST
    private const string GREETING = "Greeting";
    private const string JsonPath = "Data\\LanguageTranslations.json";
    #endregion

    #region READONLY
    private readonly ILogger<Messages> _log;
    private readonly IInputReader _inputReader;
    #endregion

    #region CTOR
    public Messages(ILogger<Messages> log, IInputReader inputReader)
    {
        _log = log;
        _inputReader = inputReader;
    }
    #endregion

    #region PUBLIC METHODS
    /// <summary>
    /// Handler of Conversation
    /// </summary>
    /// <returns></returns>
    public string Greeting()
    {
        var selectedLanguage = HandleConversation();

        if (selectedLanguage == string.Empty && selectedLanguage != "x")
            return ConsoleHelper.InvalidKey;

        return LookUpTranslation(GREETING, selectedLanguage);
    }

    /// <summary>
    /// Validates if input string is in correct and expected form
    /// </summary>
    /// <param name="values"></param>
    /// <returns></returns>
    public bool IsValidString(params string[] values)
    {
        foreach (var value in values)
        {
            if (value == null || value == string.Empty)
                return false;
        }
        return true;
    }

    #endregion

    #region PRIVATE METHODS

    /// <summary>
    /// Searching for key in deserialized json object
    /// </summary>
    /// <param name="key"></param>
    /// <param name="language"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    private string LookUpTranslation(string key, string language)
    {
        if (!IsValidString(key, language))
            return string.Empty;

        try
        {
            var msgSets = Deserialise();

            var msgs = msgSets.Where(x => x.Language == language).First();

            if (!IsValidString(msgs.Language, msgs.Translation[key]))
                throw new Exception(ConsoleHelper.ErrorTranslation);

            return msgs.Translation[key];
        }
        catch (Exception ex)
        {
            _log.LogError(ConsoleHelper.ErrorLookingForTranslation, ex);
            throw new Exception(ex.Message);
        }
    }

    /// <summary>
    /// Deserialize and Write in console users choice
    /// </summary>
    /// <returns></returns>
    private string HandleConversation()
    {
        JsonSerializerOptions opt = new()
        {
            PropertyNameCaseInsensitive = true
        };

        var msgSets = Deserialise();

        ConsoleHelper.ConsoleWriteLine(msgSets);

        var res = _inputReader.ReadLine();

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
    #endregion
}

