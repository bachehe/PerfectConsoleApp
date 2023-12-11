namespace UltimateLibrary.Interfaces
{
    public interface IMessages
    {
        string ReadLines();
        string Greeting();
        bool IsValidString(params string[] values);
    }
}