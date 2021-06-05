using System;
using Engine.Core.Domain;

namespace Engine.Core.Commands
{
    public class BaseCommand : ICommand
    {
        public Product Product { get; }

        public Guid OrderId { get; }

        public BaseCommand(Product product, Guid orderId)
        {
            Product = product;

            OrderId = orderId;
        }
    }
}
