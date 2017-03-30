using System.Collections.Generic;
using BusinessRules.ActionsSourceProcessor;
using Moq;
using NUnit.Framework;

namespace BusinessRules.Tests.Unit.Unit.ActionsSourceProcessor
{
    [TestFixture]
    public class ActionsProcessorTests
    {
        private List<IAction> _actionsToBePerformed;
        private Mock<IActionsSource> _mockActionsSource;
        private Mock<IActionsPerformer> _mockActionsPerformer;

        [OneTimeSetUp]
        public void GivenAnActionProcessor_WhenTheProcessorIsCalled()
        {
            _actionsToBePerformed = new List<IAction>();
            _mockActionsSource = new Mock<IActionsSource>();
            _mockActionsSource.Setup(x => x.GetActions()).Returns(_actionsToBePerformed);

            _mockActionsPerformer = new Mock<IActionsPerformer>();
            _mockActionsPerformer.Setup(x => x.PerformActions(It.IsAny<List<IAction>>())).Verifiable();

            var actionsSourceProcessor = new BusinessRules.ActionsSourceProcessor.ActionsSourceProcessor(_mockActionsPerformer.Object);

            actionsSourceProcessor.CreateAndPerformActions(_mockActionsSource.Object);
        }

        [Test]
        public void ThenGetActionsIsCalled()
        {
            _mockActionsSource.Verify(x => x.GetActions(), Times.Once);
        }

        [Test]
        public void ThenTheActionsArePerformed()
        {
            _mockActionsPerformer.Verify(x => x.PerformActions(_actionsToBePerformed), Times.Once);            
        }
    }
}
