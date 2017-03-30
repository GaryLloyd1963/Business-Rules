using System.Collections.Generic;

namespace BusinessRules.ActionsSourceProcessor
{
    public interface IActionsPerformer
    {
        void PerformActions(List<IAction> actions);
    }
}