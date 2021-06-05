namespace Engine.Core.Domain
{
    public class Order
    {
        public OrderMaster Master { get; }

        public OrderDetail Detail { get; }

        public Order(OrderMaster master, OrderDetail detail)
        {
            Master = master;

            Detail = detail;
        }
    }
}
