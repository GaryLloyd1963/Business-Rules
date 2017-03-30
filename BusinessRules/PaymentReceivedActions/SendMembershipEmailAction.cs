using BusinessRules.ActionsSourceProcessor;
using BusinessRules.Core;
using BusinessRules.Domain;

namespace BusinessRules.PaymentReceivedActions
{
    public class SendMembershipEmailAction : IAction
    {
        private readonly PurchaseOrder _purchaseOrder;
        private readonly IActionLogger _logger;

        public SendMembershipEmailAction(PurchaseOrder purchaseOrder)
        {
            _purchaseOrder = purchaseOrder;
            _logger = ContainerManager.GetInstance<IActionLogger>();
        }

        public void PerformAction()
        {
            _logger.WriteLine($"EMEM--> Email owners regarding memberships from purchase order {_purchaseOrder.Id}");
        }
    }
}