
namespace UltimateLibrary.Models;
public class Languages
{
    public string Language { get; set; } = string.Empty;
    public Dictionary<string, string> Translation { get; set; } = new();
}

