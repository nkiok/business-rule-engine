using System;
using Engine.Core.Domain;

namespace Engine.Core.Commands
{
    public class UpgradeMembershipCommand : BaseCommand
    {
        public UpgradeMembershipCommand(Product product, Guid orderId) : base(product, orderId)
        {
        }
    }
}
