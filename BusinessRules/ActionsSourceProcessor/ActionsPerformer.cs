using System.Collections.Generic;

namespace BusinessRules.ActionsSourceProcessor
{
    public class ActionsPerformer : IActionsPerformer
    {
        private readonly ISingleActionPerformer _singleActionPerformer;

        public ActionsPerformer(ISingleActionPerformer singleActionPerformer)
        {
            _singleActionPerformer = singleActionPerformer;
        }

        public void PerformActions(List<IAction> actions)
        {
            foreach (var action in actions)
            {
                _singleActionPerformer.PerformAction(action);
            }
        }
    }
}