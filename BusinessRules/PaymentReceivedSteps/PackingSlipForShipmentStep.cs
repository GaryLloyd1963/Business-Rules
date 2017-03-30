using System;
using System.Collections.Generic;
using System.Linq;
using BusinessRules.ActionsSourceProcessor;
using BusinessRules.Core;
using BusinessRules.Domain;
using BusinessRules.PaymentReceivedActions;

namespace BusinessRules.PaymentReceivedSteps
{
    public class PackingSlipForShipmentStep : IStep
    {
        private readonly PaymentReceived _paymentReceived;

        public PackingSlipForShipmentStep(PaymentReceived paymentReceived)
        {
            _paymentReceived = paymentReceived;
        }

        public List<IAction> CreateActions()
        {
            var purchaseOrder = _paymentReceived.PurchaseOrder;
            var physicalProductsOnPurchaseOrder =
                        purchaseOrder.ProductItemsOrdered.Any(x => x.Product.MainProductType == ProductConstants.MainProductType.Physical);

            var actionList = new List<IAction>();

            if (!physicalProductsOnPurchaseOrder) return actionList;

            var packingSlip = new PackingSlip
            {
                Id = Guid.NewGuid(),
                PurchaseOrder = purchaseOrder
            };

            actionList.Add(new SendPackingSlipAction(packingSlip, ProcessConstants.Receiver.Shipping));
            return actionList;
        }
    }
}