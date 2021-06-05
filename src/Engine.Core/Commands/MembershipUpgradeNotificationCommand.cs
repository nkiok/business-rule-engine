using System;
using Engine.Core.Domain;

namespace Engine.Core.Commands
{
    public class MembershipUpgradeNotificationCommand : BaseCommand
    {
        public MembershipUpgradeNotificationCommand(Product product, Guid orderId) : base(product, orderId)
        {
        }
    }
}
