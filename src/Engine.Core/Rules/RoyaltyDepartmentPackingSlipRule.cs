using CSharpFunctionalExtensions;
using Engine.Core.Commands;
using Engine.Core.Domain;

namespace Engine.Core.Rules
{
    public class RoyaltyDepartmentPackingSlipRule : IBusinessRule<OrderContext>
    {
        private readonly ISender _sender;

        public RoyaltyDepartmentPackingSlipRule(ISender sender)
        {
            _sender = sender;
        }

        public Result Apply(OrderContext context) 
            => Result.SuccessIf(Predicate(context.Product), Consts.RuleDoesNotApply).Tap(() => SendCommand(context));

        private static bool Predicate(Product product)
            => product.Type == ProductType.Book;

        private void SendCommand(OrderContext context) 
            => _sender.Send(new AddProductToPackingSlipForRoyaltyDepartmentCommand(context.Product, context.OrderMaster.Id));
    }
}
