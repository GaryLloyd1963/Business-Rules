using System;

namespace BusinessRules.Domain
{
    public class PackingSlip
    {
        public Guid Id { get; set; }
        public PurchaseOrder  PurchaseOrder { get; set; }
    }
}