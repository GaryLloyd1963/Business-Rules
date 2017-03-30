using System;
using System.Collections.Generic;
using System.Linq;
using BusinessRules.ActionsSourceProcessor;
using BusinessRules.Core;
using BusinessRules.Domain;
using BusinessRules.PaymentReceivedActions;

namespace BusinessRules.PaymentReceivedSteps
{
    public class AddCompulsoryFreeProductStep : IStep
    {
        private readonly PaymentReceived _paymentReceived;

        public AddCompulsoryFreeProductStep(PaymentReceived paymentReceived)
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

            if (
                physicalProductsOnPurchaseOrder.Any(
                    x => x.Product.SubProductType == ProductConstants.SubProductType.Video
                         && x.Product.Title == "Learning to Ski"))
            {
                actionList.Add(new AddCompulsoryFreeProductAction(purchaseOrder, new ProductItem
                {
                    Id = Guid.NewGuid(),
                    MainProductType = ProductConstants.MainProductType.Physical,
                    NormalUnitPrice = 1000,
                    SubProductType = ProductConstants.SubProductType.Book,
                    Title = "First Aid"
                }));
            }

            return actionList;
        }
    }
}