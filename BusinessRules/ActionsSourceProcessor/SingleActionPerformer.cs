namespace BusinessRules.ActionsSourceProcessor
{
    public class SingleActionPerformer : ISingleActionPerformer
    {
        public void PerformAction(IAction action)
        {
            action.PerformAction();
        }
    }
}