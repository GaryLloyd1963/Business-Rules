using System;
using System.Collections.Generic;
using System.Linq;
using BusinessRules.ActionsSourceProcessor;
using BusinessRules.Core;
using BusinessRules.Domain;
using BusinessRules.PaymentReceivedActions;

namespace BusinessRules.PaymentReceivedSteps
{
    public class PackingSlipForRoyaltyDeptStep : IStep
    {
        private readonly PaymentReceived _paymentReceived;

        public PackingSlipForRoyaltyDeptStep(PaymentReceived paymentReceived)
        {
            _paymentReceived = paymentReceived;
        }

        public List<IAction> CreateActions()
        {
            var purchaseOrder = _paymentReceived.PurchaseOrder;
            var booksOnPurchaseOrder =
                purchaseOrder.ProductItemsOrdered.Any(
                    x => x.Product.MainProductType == ProductConstants.MainProductType.Physical
                         && x.Product.SubProductType == ProductConstants.SubProductType.Book);

            var actionList = new List<IAction>();

            if (!booksOnPurchaseOrder) return actionList;

            var packingSlip = new PackingSlip
            {
                Id = Guid.NewGuid(),
                PurchaseOrder = purchaseOrder
            };

            actionList.Add(new SendPackingSlipAction(packingSlip, ProcessConstants.Receiver.Royalty));
            return actionList;
        }
    }
}