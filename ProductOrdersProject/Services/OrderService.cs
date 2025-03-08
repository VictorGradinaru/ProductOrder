using ProductOrdersProject.Interfaces;
using Shared.Models;
using Shared.NewFolder;

namespace ProductOrdersProject.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IFileLogger _fileLogger;

        public OrderService(IOrderRepository orderRepository, IFileLogger fileLogger)
        {
            _orderRepository = orderRepository;
            _fileLogger= fileLogger;
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
                order.Status ??= "Validated"; // Setează implicit "Created" dacă nu e specificat
                _fileLogger.Log($"Validated product with name {order.ProductName}");
            }

            foreach (var order in orders)
            {
                await _orderRepository.AddAsync(order);
            }
        }
    }
}
