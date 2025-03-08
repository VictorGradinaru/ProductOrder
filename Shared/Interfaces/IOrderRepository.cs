using Shared.Models;

namespace ProductOrdersProject.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<OrderDto>> GetAllAsync();
        Task AddAsync(OrderDto order);
        Task UpdateAsync(OrderDto order);
    }
}
