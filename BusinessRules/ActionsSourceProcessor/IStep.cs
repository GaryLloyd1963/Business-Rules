using System.Collections.Generic;

namespace BusinessRules.ActionsSourceProcessor
{
    public interface IStep
    {
        List<IAction> CreateActions();
    }
}