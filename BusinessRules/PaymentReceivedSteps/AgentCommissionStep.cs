using System.Collections.Generic;
using System.Linq;
using BusinessRules.ActionsSourceProcessor;
using BusinessRules.Core;
using BusinessRules.Domain;
using BusinessRules.PaymentReceivedActions;

namespace BusinessRules.PaymentReceivedSteps
{
    public class AgentCommissionStep : IStep
    {
        private readonly PaymentReceived _paymentReceived;

        public AgentCommissionStep(PaymentReceived paymentReceived)
        {
            _paymentReceived = paymentReceived;
        }

        public List<IAction> CreateActions()
        {
            var purchaseOrder = _paymentReceived.PurchaseOrder;
            var physicalProductsOnPurchaseOrder =
                        purchaseOrder.ProductItemsOrdered.Where(x => x.Product.MainProductType == ProductConstants.MainProductType.Physical).ToList();

            var actionList = new List<IAction>();
            if (!physicalProductsOnPurchaseOrder.Any()) return actionList;

            actionList.Add(new SendCommissionToAgentAction(purchaseOrder));

            return actionList;
        }
    }
}