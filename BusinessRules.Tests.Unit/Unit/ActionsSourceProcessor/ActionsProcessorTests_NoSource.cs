using System.Collections.Generic;
using BusinessRules.ActionsSourceProcessor;
using Moq;
using NUnit.Framework;

namespace BusinessRules.Tests.Unit.Unit.ActionsSourceProcessor
{
    [TestFixture]
    public class ActionProcessorTestsNoSource
    {
        private Mock<IActionsPerformer> _mockActionsPerformer;

        [OneTimeSetUp]
        public void GivenAnActionProcessor_WhenTheProcessorIsCalled()
        {
            _mockActionsPerformer = new Mock<IActionsPerformer>();
            _mockActionsPerformer.Setup(x => x.PerformActions(It.IsAny<List<IAction>>())).Verifiable();

            var actionsSourceProcessor = new BusinessRules.ActionsSourceProcessor.ActionsSourceProcessor(_mockActionsPerformer.Object);

            actionsSourceProcessor.CreateAndPerformActions(null);
        }

        [Test]
        public void ThenTheActionsAreNotPerformed()
        {
            _mockActionsPerformer.Verify(x => x.PerformActions(It.IsAny<List<IAction>>()), Times.Never);            
        }
    }
}
