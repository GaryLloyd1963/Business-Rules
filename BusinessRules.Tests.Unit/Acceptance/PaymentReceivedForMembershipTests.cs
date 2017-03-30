using System.Linq;
using BusinessRules.ActionsSource;
using BusinessRules.ActionsSourceProcessor;
using BusinessRules.Core;
using NUnit.Framework;

namespace BusinessRules.Tests.Unit.Acceptance
{
    [TestFixture]
    public class PaymentReceivedForMembershipTests
    {
        private string[] _log;

        [OneTimeSetUp]
        public void GivenAPaymentForABook_WhenTheProcessorIsCalled()
        {
            var paymentReceived = ProcessHelper.CreatePaymentReceivedForAnItem(
                ProductConstants.MainProductType.NonPhysical, ProductConstants.SubProductType.Membership, "The Gym");

            var actionsSourceFactory = ContainerManager.GetInstance<IActionsSourceFactory>();
            var actionsSource = actionsSourceFactory.ActionSource(paymentReceived);

            var actionSourceProcessor = ContainerManager.GetInstance<IActionsSourceProcessor>();

            actionSourceProcessor.CreateAndPerformActions(actionsSource);

            _log = ContainerManager.GetInstance<IActionLogger>().GetLog();
        }

        [Test]
        public void ThenTheCorrectNumberOfActionsOccurred()
        {
            Assert.That(_log.Length == 2);
        }

        [Test]
        public void ThenMemberShipActivationIsActioned()
        {
            Assert.That(_log.Count(x => x.StartsWith("AMEM")) == 1);
        }

        [Test]
        public void ThenEmailNoificationIsActioned()
        {
            Assert.That(_log.Count(x => x.StartsWith("EMEM")) == 1);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            ContainerManager.GetInstance<IActionLogger>().ClearLog();
        }
    }
}
