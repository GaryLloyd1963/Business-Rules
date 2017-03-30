using BusinessRules.ActionsSourceProcessor;
using BusinessRules.Domain;

namespace BusinessRules.ActionsSource
{
    public class ActionsSourceFactory : IActionsSourceFactory
    {
        public IActionsSource ActionSource(object item)
        {
            if ( item.GetType() == typeof(PaymentReceived))
                return new PaymentReceivedActionsSource(item as PaymentReceived);
            return null;
        }
    }
}
