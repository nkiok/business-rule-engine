using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Core.Domain;

namespace Engine.Core.Commands
{
    public class ActivateMembershipCommand : BaseCommand
    {
        public ActivateMembershipCommand(Product product, Guid orderId) : base(product, orderId)
        {
        }
    }
}
