namespace Engine.Core.Domain
{
    public class OrderDetail
    {
        public Product[] Products { get; }

        public OrderDetail(Product[] products)
        {
            Products = products;
        }
    }
}
