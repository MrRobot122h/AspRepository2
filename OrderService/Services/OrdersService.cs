using OrderService.Interfaces;
using SharedModels;

namespace OrderService.Services
{
    public class OrdersService : IOrdersService
    {
        IOrderRepository _orderRepository;
        public OrdersService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public void Add(Order order)
        {
            _orderRepository.AddOrder(order);
        }

        public void Delete(int id)
        {
            _orderRepository.DeleteOrder(id);
        }

        public Order GetOrder(int id)
        {
            return _orderRepository.GetOrderById(id);
        }

        public List<Order> GetOrders()
        {
            return _orderRepository.GetOrders();
        }

        public void Update(int id, Order order)
        {
            _orderRepository.UpdateOrder(id, order);
        }
    }
}
