using System;
using CSharpFunctionalExtensions;
using Engine.Core.Commands;
using Engine.Core.Domain;
using Engine.Core.Rules;
using NSubstitute;
using NUnit.Framework;

namespace Engine.Tests.Rules
{
    public class RoyaltyDepartmentPackingSlipRuleTests
    {
        private IBusinessRule<OrderContext> _rule;
        private ISender _sender;

        [SetUp]
        public void SetUp()
        {
            _sender = Substitute.For<ISender>();

            _rule = new RoyaltyDepartmentPackingSlipRule(_sender);
        }

        [Test]
        [TestCase(ProductType.Book, ExpectedResult = true, TestName = "Duplicate packing slip generated when product is a book")]
        [TestCase(ProductType.Video, ExpectedResult = false, TestName = "Duplicate Packing slip NOT generated when product is not a book")]
        [TestCase(ProductType.NewMembership, ExpectedResult = false, TestName = "Duplicate Packing slip NOT generated when product is not a book")]
        public bool RuleEvaluationReturnsExpectedFor(ProductType productType)
        {
            var orderContext = CreateOrderContextWith(productType);

            var result = _rule.Apply(orderContext)
                .Tap(() => _sender.Received().Send(Arg.Any<AddProductToPackingSlipForRoyaltyDepartmentCommand>()));

            return result.IsSuccess;
        }

        private static OrderContext CreateOrderContextWith(ProductType productType) 
            => new OrderContext(
                new OrderMaster(), 
                new Product(Guid.NewGuid(), true,productType, string.Empty));
    }
}