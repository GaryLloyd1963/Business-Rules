using BusinessRules.ActionsSourceProcessor;
using BusinessRules.Core;
using BusinessRules.Domain;

namespace BusinessRules.PaymentReceivedActions
{
    public class AddCompulsoryFreeProductAction : IAction
    {
        private readonly PurchaseOrder _purchaseOrder;
        private readonly ProductItem _freeProduct;
        private readonly IActionLogger _logger;

        public AddCompulsoryFreeProductAction(PurchaseOrder purchaseOrder, ProductItem freeProduct)
        {
            _purchaseOrder = purchaseOrder;
            _freeProduct = freeProduct;
            _logger = ContainerManager.GetInstance<IActionLogger>();
        }

        public void PerformAction()
        {
            _logger.WriteLine($"COMP--> Add compulsory free product {_freeProduct.Title} to purchase order {_purchaseOrder.Id}");
        }
    }
}