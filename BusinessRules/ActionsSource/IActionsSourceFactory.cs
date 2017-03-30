using BusinessRules.ActionsSourceProcessor;

namespace BusinessRules.ActionsSource
{
    public interface IActionsSourceFactory
    {
        IActionsSource ActionSource(object item);
    }
}
