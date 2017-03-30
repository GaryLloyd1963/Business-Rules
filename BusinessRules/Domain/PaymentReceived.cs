using System;

namespace BusinessRules.Domain
{
    public class PaymentReceived
    {
        public Guid Id { get; set; }
        public PurchaseOrder PurchaseOrder{ get; set; }
    }
}