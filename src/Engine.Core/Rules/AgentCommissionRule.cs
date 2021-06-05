using CSharpFunctionalExtensions;
using Engine.Core.Commands;
using Engine.Core.Domain;

namespace Engine.Core.Rules
{
    public class AgentCommissionRule : IBusinessRule<OrderContext>
    {
        private readonly ISender _sender;

        public AgentCommissionRule(ISender sender)
        {
            _sender = sender;
        }

        public Result Apply(OrderContext context) 
            => Result.SuccessIf(Predicate(context.Product), Consts.RuleDoesNotApply).Tap(() => SendCommand(context));

        private static bool Predicate(Product product) 
            => product.Physical || product.Type == ProductType.Book;

        private void SendCommand(OrderContext context) 
            => _sender.Send(new CreateAgentCommissionCommand(context.Product, context.OrderMaster.Id, context.OrderMaster.AgentId));
    }
}
