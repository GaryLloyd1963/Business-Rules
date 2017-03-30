using BusinessRules.ActionsSourceProcessor;
using BusinessRules.Core;
using BusinessRules.Domain;

namespace BusinessRules.PaymentReceivedActions
{
    public class SendPackingSlipAction : IAction
    {
        private readonly PackingSlip _packingSlip;
        private readonly ProcessConstants.Receiver _destination;
        private readonly IActionLogger _logger;

        public SendPackingSlipAction(PackingSlip packingSlip, ProcessConstants.Receiver destination)
        {
            _packingSlip = packingSlip;
            _destination = destination;
            _logger = ContainerManager.GetInstance<IActionLogger>();
        }

        public void PerformAction()
        {
            var code = _destination == ProcessConstants.Receiver.Royalty ? "RSLP" : "PSLP";
            _logger.WriteLine($"{code}--> Send packing slip {_packingSlip.Id} to {_destination} for order {_packingSlip.PurchaseOrder.Id}");
        }
    }
}