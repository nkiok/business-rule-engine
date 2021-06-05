using CSharpFunctionalExtensions;
using Engine.Core.Commands;
using Engine.Core.Domain;

namespace Engine.Core.Rules
{
    public class UpgradeMembershipRule : IBusinessRule<OrderContext>
    {
        private readonly ISender _sender;

        public UpgradeMembershipRule(ISender sender)
        {
            _sender = sender;
        }

        public Result Apply(OrderContext context) 
            => Result.SuccessIf(Predicate(context.Product), Consts.RuleDoesNotApply).Tap(() => SendCommand(context));

        private static bool Predicate(Product product) 
            => product.Type == ProductType.UpgradeMembership;

        private void SendCommand(OrderContext context) 
            => _sender.Send(new UpgradeMembershipCommand(context.Product, context.OrderMaster.Id));
    }
}
