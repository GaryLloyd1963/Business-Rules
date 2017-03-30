using System.Collections.Generic;

namespace BusinessRules.ActionsSourceProcessor
{
    public interface IActionsSource
    {
        string GetDescription();
        List<IAction> GetActions();
    }
}