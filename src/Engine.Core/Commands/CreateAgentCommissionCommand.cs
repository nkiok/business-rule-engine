using System;
using Engine.Core.Domain;

namespace Engine.Core.Commands
{
    public class CreateAgentCommissionCommand : BaseCommand
    {
        public Guid AgentId { get; }

        public CreateAgentCommissionCommand(Product product, Guid orderId, Guid agentId) : base(product, orderId)
        {
            AgentId = agentId;
        }
    }
}
