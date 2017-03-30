using System;
using System.Collections.Generic;

namespace BusinessRules.Domain
{
    public class PurchaseOrder
    {
        public Guid Id { get; set; }
        public string ContactEmailAddress { get; set; }
        public List<ProductItemOnOrder> ProductItemsOrdered { get; set; }
    }
}