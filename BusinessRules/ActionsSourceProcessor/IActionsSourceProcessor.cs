namespace BusinessRules.ActionsSourceProcessor
{
    public interface IActionsSourceProcessor
    {
        void CreateAndPerformActions(IActionsSource actionsSource);
    }
}