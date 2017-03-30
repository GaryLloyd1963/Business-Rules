using BusinessRules.ActionsSourceProcessor;
using BusinessRules.Core;
using BusinessRules.Domain;

namespace BusinessRules.PaymentReceivedActions
{
    public class ActivateMembershipAction : IAction
    {
        private readonly PurchaseOrder _purchaseOrder;
        private readonly IActionLogger _logger;

        public ActivateMembershipAction(PurchaseOrder purchaseOrder)
        {
            _purchaseOrder = purchaseOrder;
            _logger = ContainerManager.GetInstance<IActionLogger>();
        }

        public void PerformAction()
        {
            _logger.WriteLine($"AMEM --> Activate memberships from purchase order {_purchaseOrder.Id}");
        }
    }
}