namespace BusinessRules.ActionsSourceProcessor
{
    public interface ISingleActionPerformer
    {
        void PerformAction(IAction action);
    }
}