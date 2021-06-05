using System;
using Engine.Core.Domain;

namespace Engine.Core.Commands
{
    public class MembershipActivationNotificationCommand : BaseCommand
    {
        public MembershipActivationNotificationCommand(Product product, Guid orderId) : base(product, orderId)
        {
        }
    }
}
