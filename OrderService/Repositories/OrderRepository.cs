using OrderService.Interfaces;
using SharedModels;

namespace OrderService.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private static List<Order> _orders = new List<Order>();
        private int nextOrderId = 1;
        public OrderRepository() { }

        public void AddOrder(Order order)
        {
            order.Id = nextOrderId++;
            _orders.Add(order);
        }

        public void DeleteOrder(int id)
        {
            var order = _orders.FirstOrDefault(x => x.Id == id);
            if (order == null)
            {
                throw new InvalidOperationException($"Замовлення з ID {id} не знайдений.");
            }
            _orders.Remove(order);
        }

        public Order GetOrderById(int id)
        {
            var order = _orders.FirstOrDefault(x => x.Id == id);

            if (order == null)
            {
                throw new InvalidOperationException($"Замовлення з ID {id} не знайдений.");
            }

            return order;
        }

        public List<Order> GetOrders()
        {
            return _orders;
        }

        public void UpdateOrder(int id, Order newOrder)
        {
            var order = _orders.FirstOrDefault(x => x.Id == id);

            if (order == null)
            {
                throw new InvalidOperationException($"Замовлення з ID {id} не знайдений.");
            }
            order.UserId = newOrder.UserId;
            order.ProductId = newOrder.ProductId;
            order.Quantity = newOrder.Quantity;
        }
    }
}
