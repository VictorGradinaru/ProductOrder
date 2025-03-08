using ProductOrdersProject.Interfaces;
using Shared.Models;

namespace ProductOrdersProject.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // GET ALL
        public async Task<IEnumerable<OrderDto>> GetAllAsync()
        {
            return await _orderRepository.GetAllAsync();
        }

        // POST (ADD RANGE)
        public async Task AddRangeAsync(IEnumerable<OrderDto> orders)
        {
            if (orders == null || !orders.Any())
                throw new ArgumentException("Order list is empty");

            foreach (var order in orders)
            {
                order.Id = Guid.NewGuid();
                order.CreatedAt = DateTime.UtcNow;
                order.Status ??= "Created"; // Setează implicit "Created" dacă nu e specificat
            }

            foreach (var order in orders)
            {
                await _orderRepository.AddAsync(order);
            }
        }
    }
}
