using System.Collections.Generic;
using BusinessRules.ActionsSourceProcessor;
using Moq;
using NUnit.Framework;

namespace BusinessRules.Tests.Unit.Unit.ActionsSourceProcessor
{
    [TestFixture]
    public class ActionsPerformerTests
    {
        private List<IAction> _actionsToBePerformed;
        private Mock<ISingleActionPerformer> _mockSingleActionPerformer;
        private Mock<IAction> _mockAction1;
        private Mock<IAction> _mockAction2;
        private Mock<IAction> _mockAction3;

        [OneTimeSetUp]
        public void GivenAnActionProcessor_WhenTheProcessorIsCalled()
        {
            _mockAction1 = new Mock<IAction>();
            _mockAction2 = new Mock<IAction>();
            _mockAction3 = new Mock<IAction>();

            _actionsToBePerformed = new List<IAction>
            {
                _mockAction1.Object,
                _mockAction2.Object,
                _mockAction3.Object
            };

            _mockSingleActionPerformer = new Mock<ISingleActionPerformer>();
            _mockSingleActionPerformer.Setup(x => x.PerformAction(It.IsAny<IAction>())).Verifiable();

            var actionsPerformer = new ActionsPerformer(_mockSingleActionPerformer.Object);

            actionsPerformer.PerformActions(_actionsToBePerformed);
        }

        [Test]
        public void ThenTheSingleActionPerformerIsCalled()
        {
            _mockSingleActionPerformer.Verify(x => x.PerformAction(It.IsAny<IAction>()), Times.Exactly(3));
        }
    }
}
