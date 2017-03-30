using System.Linq;
using BusinessRules.ActionsSource;
using BusinessRules.ActionsSourceProcessor;
using BusinessRules.Core;
using NUnit.Framework;

namespace BusinessRules.Tests.Unit.Acceptance
{
    [TestFixture]
    public class PaymentReceivedForBookTests
    {
        private string[] _log;

        [OneTimeSetUp]
        public void GivenAPaymentForABook_WhenTheProcessorIsCalled()
        {
            var paymentReceived = ProcessHelper.CreatePaymentReceivedForAnItem(
                ProductConstants.MainProductType.Physical, ProductConstants.SubProductType.Book, "The Hobbit");

            var actionsSourceFactory = ContainerManager.GetInstance<IActionsSourceFactory>();
            var actionsSource = actionsSourceFactory.ActionSource(paymentReceived);

            var actionSourceProcessor = ContainerManager.GetInstance<IActionsSourceProcessor>();

            actionSourceProcessor.CreateAndPerformActions(actionsSource);

            _log = ContainerManager.GetInstance<IActionLogger>().GetLog();
        }

        [Test]
        public void ThenTheCorrectNumberOfActionsOccurred()
        {
            Assert.That(_log.Length == 3);
        }

        [Test]
        public void ThenAPackingSlipIsActioned()
        {
            Assert.That(_log.Count(x => x.StartsWith("PSLP")) == 1);
        }

        [Test]
        public void ThenARoyaltySlipIsActioned()
        {
            Assert.That(_log.Count(x => x.StartsWith("RSLP")) == 1);
        }

        [Test]
        public void ThenAnAgentCommissionIsActioned()
        {
            Assert.That(_log.Count(x => x.StartsWith("SCOM")) == 1);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            ContainerManager.GetInstance<IActionLogger>().ClearLog();
        }
    }
}
