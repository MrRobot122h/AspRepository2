using SharedModels;

namespace OrderService.Interfaces
{
    public interface IOrderRepository
    {
        public void AddOrder(Order order);
        public void UpdateOrder(int id, Order order);
        public void DeleteOrder(int id);
        public Order GetOrderById(int id);
        public List<Order> GetOrders();
    }
}
