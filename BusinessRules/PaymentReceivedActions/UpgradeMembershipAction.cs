using BusinessRules.ActionsSourceProcessor;
using BusinessRules.Core;
using BusinessRules.Domain;

namespace BusinessRules.PaymentReceivedActions
{
    public class UpgradeMembershipAction : IAction
    {
        private readonly PurchaseOrder _purchaseOrder;
        private IActionLogger _logger;

        public UpgradeMembershipAction(PurchaseOrder purchaseOrder)
        {
            _purchaseOrder = purchaseOrder;
            _logger = ContainerManager.GetInstance<IActionLogger>();
        }

        public void PerformAction()
        {
            _logger.WriteLine($"UMEM--> Upgrade memberships from purchase order {_purchaseOrder.Id}");
        }
    }
}