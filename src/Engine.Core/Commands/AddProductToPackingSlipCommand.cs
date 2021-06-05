using System;
using Engine.Core.Domain;

namespace Engine.Core.Commands
{
    public class AddProductToPackingSlipCommand : BaseCommand
    {
        public AddProductToPackingSlipCommand(Product product, Guid orderId) : base(product, orderId)
        {
        }
    }
}
