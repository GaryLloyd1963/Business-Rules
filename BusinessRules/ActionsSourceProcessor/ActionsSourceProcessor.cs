using System;

namespace BusinessRules.ActionsSourceProcessor
{
    public class ActionsSourceProcessor : IActionsSourceProcessor
    {
        private readonly IActionsPerformer _actionsPerformer;

        public ActionsSourceProcessor(IActionsPerformer actionsPerformer)
        {
            _actionsPerformer = actionsPerformer;
        }

        public void CreateAndPerformActions(IActionsSource actionsSource)
        {
            if (actionsSource == null)
            {
                Console.WriteLine("** ActionsSourceProcessor : no action source supplied!");
                return;
            }

            var actions = actionsSource.GetActions();

            _actionsPerformer.PerformActions(actions);
        }
    }
}