using System;
using CSharpFunctionalExtensions;
using Engine.Core.Commands;
using Engine.Core.Domain;
using Engine.Core.Rules;
using NSubstitute;
using NUnit.Framework;

namespace Engine.Tests.Rules
{
    public class MembershipStatusNotificationRuleTests
    {
        private IBusinessRule<OrderContext> _rule;
        private ISender _sender;

        [SetUp]
        public void SetUp()
        {
            _sender = Substitute.For<ISender>();

            _rule = new MembershipStatusNotificationRule(_sender);
        }
        
        [Test]
        [TestCase(ProductType.NewMembership, ExpectedResult = true, TestName = "Notification for a new membership")]
        [TestCase(ProductType.UpgradeMembership, ExpectedResult = true, TestName = "Notification for a membership upgrade")]
        [TestCase(ProductType.Book, ExpectedResult = false, TestName = "No notification for a book")]
        public bool RuleEvaluationReturnsExpectedResultFor(ProductType productType)
        {
            var orderContext = CreateOrderContextWith(productType);

            var result = _rule.Apply(orderContext)
                .TapIf(productType == ProductType.NewMembership, () => 
                    _sender.Received().Send(Arg.Any<MembershipActivationNotificationCommand>()))
                .TapIf(productType == ProductType.UpgradeMembership, () => 
                    _sender.Received().Send(Arg.Any<MembershipUpgradeNotificationCommand>()))
                .OnFailure(() =>
                    {
                        _sender.DidNotReceive().Send(Arg.Any<MembershipActivationNotificationCommand>());
                        _sender.DidNotReceive().Send(Arg.Any<MembershipUpgradeNotificationCommand>());
                    });
 
            return result.IsSuccess;
        }

        private static OrderContext CreateOrderContextWith(ProductType productType)
            => new OrderContext(
                new OrderMaster(),
                new Product(Guid.NewGuid(), false, productType, string.Empty));
    }
}
