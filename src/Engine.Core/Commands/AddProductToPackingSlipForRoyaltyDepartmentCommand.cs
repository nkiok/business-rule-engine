using System;
using Engine.Core.Domain;

namespace Engine.Core.Commands
{
    public class AddProductToPackingSlipForRoyaltyDepartmentCommand : BaseCommand
    {
        public AddProductToPackingSlipForRoyaltyDepartmentCommand(Product product, Guid orderId) : base(product, orderId)
        {
        }
    }
}
