namespace Engine.Core.Domain
{
    public class OrderContext
    {
        public OrderMaster OrderMaster { get; }

        public Product Product { get; }
        
        public OrderContext(OrderMaster orderMaster, Product product)
        {
            OrderMaster = orderMaster;

            Product = product;
        }
    }
}
