namespace BusinessRules.ActionsSourceProcessor
{
    public interface IActionLogger
    {
        void ClearLog();
        void WriteLine(string text);
        string[] GetLog();
    }
}
