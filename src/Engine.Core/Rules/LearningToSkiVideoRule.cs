using System;
using CSharpFunctionalExtensions;
using Engine.Core.Commands;
using Engine.Core.Domain;

namespace Engine.Core.Rules
{
    public class LearningToSkiVideoRule : IBusinessRule<OrderContext>
    {
        private readonly ISender _dispatcher;

        public LearningToSkiVideoRule(ISender dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public Result Apply(OrderContext context) 
            => Result.SuccessIf(Predicate(context.Product), Consts.RuleDoesNotApply).Tap(() => SendCommand(context));

        private static bool Predicate(Product product)
            => product.Type == ProductType.Video &&
               product.Description == Consts.LearnToSkiVideoTitle;

        private void SendCommand(OrderContext context) 
            => _dispatcher.Send(new AddMandatoryProductToPackingSlipCommand(context.Product, context.OrderMaster.Id));
    }
}
