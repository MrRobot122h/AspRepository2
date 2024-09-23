using SharedModels;

namespace OrderService.Interfaces
{
    public interface IOrdersService
    {
        public void Add(Order order);
        public void Update(int id, Order order);
        public void Delete(int id);
        public Order GetOrder(int id);
        public List<Order> GetOrders();
    }
}
