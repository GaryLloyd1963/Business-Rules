using System.Collections.Generic;
using System.Linq;
using BusinessRules.ActionsSourceProcessor;
using BusinessRules.Core;
using BusinessRules.Domain;
using BusinessRules.PaymentReceivedActions;

namespace BusinessRules.PaymentReceivedSteps
{
    public class UpgradeMembershipStep : IStep
    {
        private readonly PaymentReceived _paymentReceived;

        public UpgradeMembershipStep(PaymentReceived paymentReceived)
        {
            _paymentReceived = paymentReceived;
        }

        public List<IAction> CreateActions()
        {
            var purchaseOrder = _paymentReceived.PurchaseOrder;
            var membershipsOnPurchaseOrder =
                        purchaseOrder.ProductItemsOrdered.Any(x => x.Product.MainProductType == ProductConstants.MainProductType.NonPhysical
                                                                        && x.Product.SubProductType == ProductConstants.SubProductType.MembershipUpgrade);

            var actionList = new List<IAction>();

            if (!membershipsOnPurchaseOrder) return actionList;

            actionList.Add(new UpgradeMembershipAction(purchaseOrder));

            actionList.Add(new SendMembershipEmailAction(purchaseOrder));

            return actionList;
        }
    }
}