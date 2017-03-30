using System;

namespace BusinessRules.Domain
{
    public class ProductItemOnOrder
    {
        public Guid Id { get; set; }
        public ProductItem Product { get; set; }
        public int Quantity { get; set; }
    }
}