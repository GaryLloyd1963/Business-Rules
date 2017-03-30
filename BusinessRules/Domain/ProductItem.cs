using System;
using BusinessRules.Core;

namespace BusinessRules.Domain
{
    public class ProductItem
    {
        public Guid Id { get; set; }
        public ProductConstants.MainProductType MainProductType { get; set; }
        public ProductConstants.SubProductType SubProductType { get; set; }
        public string Title { get; set; }
        public int NormalUnitPrice { get; set; }
    }
}