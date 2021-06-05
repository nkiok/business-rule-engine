using System;
using CSharpFunctionalExtensions;
using Engine.Core.Commands;
using Engine.Core.Domain;
using Engine.Core.Rules;
using NSubstitute;
using NUnit.Framework;

namespace Engine.Tests.Rules
{
    public class PackingSlipRuleTests
    {
        private IBusinessRule<OrderContext> _rule;
        private ISender _sender;

        [SetUp]
        public void SetUp()
        {
            _sender = Substitute.For<ISender>();

            _rule = new PackingSlipRule(_sender);
        }

        [Test]
        [TestCase(true, ExpectedResult = true, TestName = "Packing slip generated for PHYSICAL product")]
        [TestCase(false, ExpectedResult = false, TestName = "Packing slip NOT generated for NON PHYSICAL product")]
        public bool RuleEvaluationReturnsExpectedFor(bool isPhysical)
        {
            var orderContext = CreateOrderContextWith(isPhysical);

            var result = _rule.Apply(orderContext)
                .Tap(() => _sender.Received().Send(Arg.Any<AddProductToPackingSlipCommand>()));

            return result.IsSuccess;
        }

        private static OrderContext CreateOrderContextWith(bool isPhysical) 
            => new OrderContext(
                new OrderMaster(), 
                new Product(Guid.NewGuid(), isPhysical, ProductType.Book, string.Empty));
    }
}