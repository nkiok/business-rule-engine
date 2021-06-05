using CSharpFunctionalExtensions;
using Engine.Core.Commands;
using Engine.Core.Domain;

namespace Engine.Core.Rules
{
    public class ActivateMembershipRule : IBusinessRule<OrderContext>
    {
        private readonly ISender _sender;

        public ActivateMembershipRule(ISender sender)
        {
            _sender = sender;
        }

        public Result Apply(OrderContext context)
            => Result.SuccessIf(Predicate(context.Product), Consts.RuleDoesNotApply).Tap(() => SendCommand(context));

        private static bool Predicate(Product product)
            => product.Type == ProductType.NewMembership;

        private void SendCommand(OrderContext context)
            => _sender.Send(new ActivateMembershipCommand(context.Product, context.OrderMaster.Id));
    }
}
