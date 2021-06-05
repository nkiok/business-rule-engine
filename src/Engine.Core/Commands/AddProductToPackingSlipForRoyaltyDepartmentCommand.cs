using System;
using Engine.Core.Domain;

namespace Engine.Core.Commands
{
    public class AddProductToRoyaltyDepartmentPackingSlipCommand : BaseCommand
    {
        public AddProductToRoyaltyDepartmentPackingSlipCommand(Product product, Guid orderId) : base(product, orderId)
        {
        }
    }
}
