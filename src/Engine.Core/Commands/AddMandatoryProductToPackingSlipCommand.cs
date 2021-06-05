using System;
using Engine.Core.Domain;

namespace Engine.Core.Commands
{
    public class AddMandatoryProductToPackingSlipCommand : BaseCommand
    {
        public AddMandatoryProductToPackingSlipCommand(Product product, Guid orderId) : base(product, orderId)
        {
        }
    }
}
