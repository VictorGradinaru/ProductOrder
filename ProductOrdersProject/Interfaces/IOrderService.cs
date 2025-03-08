using Shared.Models;

namespace ProductOrdersProject.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetAllAsync();
        Task AddRangeAsync(IEnumerable<OrderDto> orders);
    }
}
