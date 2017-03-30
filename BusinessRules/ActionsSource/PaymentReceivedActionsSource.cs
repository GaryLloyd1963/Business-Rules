using System.Collections.Generic;
using BusinessRules.ActionsSourceProcessor;
using BusinessRules.Domain;
using BusinessRules.PaymentReceivedSteps;

namespace BusinessRules.ActionsSource
{
    public class PaymentReceivedActionsSource : IActionsSource
    {
        private readonly PaymentReceived _paymentReceived;

        public PaymentReceivedActionsSource(PaymentReceived paymentReceived)
        {
            _paymentReceived = paymentReceived;
        }

        public string GetDescription()
        {
            return $"Payment Received {_paymentReceived.Id} for Purchase Order {_paymentReceived.PurchaseOrder.Id}";
        }

        public List<IAction> GetActions()
        {
            var actions = new AddCompulsoryFreeProductStep(_paymentReceived).CreateActions();

            actions.AddRange(new PackingSlipForShipmentStep(_paymentReceived).CreateActions());

            actions.AddRange(new PackingSlipForRoyaltyDeptStep(_paymentReceived).CreateActions());

            actions.AddRange(new NewMembershipStep(_paymentReceived).CreateActions());

            actions.AddRange(new UpgradeMembershipStep(_paymentReceived).CreateActions());

            actions.AddRange(new AgentCommissionStep(_paymentReceived).CreateActions());

            return actions;
        }
    }
}