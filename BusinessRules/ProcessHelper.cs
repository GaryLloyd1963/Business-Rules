using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessRules.Core;
using BusinessRules.Domain;

namespace BusinessRules
{
    public class ProcessHelper
    {
        public static PaymentReceived CreatePaymentReceivedForAnItem(ProductConstants.MainProductType mainType, ProductConstants.SubProductType subType, string title)
        {
            var product = new ProductItem
            {
                Id = Guid.NewGuid(),
                MainProductType = mainType,
                SubProductType = subType,
                Title = title,
                NormalUnitPrice = 1000
            };

            var productItemOrdered = new ProductItemOnOrder
            {
                Id = Guid.NewGuid(),
                Product = product,
                Quantity = 1
            };

            var purchaseOrder = new PurchaseOrder
            {
                Id = Guid.NewGuid(),
                ContactEmailAddress = "al@acme.com",
                ProductItemsOrdered = new List<ProductItemOnOrder>
                {
                    productItemOrdered
                }
            };

            return new PaymentReceived
            {
                Id = Guid.NewGuid(),
                PurchaseOrder = purchaseOrder
            };
        }
    }
}
