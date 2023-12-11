namespace UltimateLibrary.Interfaces
{
    public interface IMessages
    {
        string Greeting(string language);
        bool IsValidString(params string[] values);
    }
}