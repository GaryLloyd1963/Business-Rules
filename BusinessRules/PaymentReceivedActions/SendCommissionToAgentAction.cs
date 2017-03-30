using BusinessRules.ActionsSourceProcessor;
using BusinessRules.Core;
using BusinessRules.Domain;

namespace BusinessRules.PaymentReceivedActions
{
    public class SendCommissionToAgentAction : IAction
    {
        private readonly PurchaseOrder _purchaseOrder;
        private readonly IActionLogger _logger;

        public SendCommissionToAgentAction(PurchaseOrder purchaseOrder)
        {
            _purchaseOrder = purchaseOrder;
            _logger = ContainerManager.GetInstance<IActionLogger>();
        }

        public void PerformAction()
        {
            _logger.WriteLine($"SCOM--> Send commission to agents for products on purchase order {_purchaseOrder.Id}");
        }
    }
}