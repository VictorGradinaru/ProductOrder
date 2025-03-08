using PaymentProject.Interfaces;
using ProductOrdersProject.Interfaces;
using Shared.Models;

namespace PaymentProject.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IOrderRepository _orderRepository;

        // Injectăm OrderRepository în PaymentService
        public PaymentService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // Metoda care aduce toate comenzile și le schimbă statusul în "Paid" dacă sunt "Validated"
        public async Task<List<Guid>> ProcessPaymentsAsync()
        {
            // Lista de ID-uri ale comenzilor procesate
            var processedOrderIds = new List<Guid>();

            // Obținem toate comenzile
            var allOrders = await _orderRepository.GetAllAsync();

            // Filtrăm comenzile care au statusul "Validated"
            var validatedOrders = allOrders.Where(order => order.Status == "Validated").ToList();

            // Schimbăm statusul fiecărei comenzi în "Paid" și adăugăm ID-ul în lista procesată
            foreach (var order in validatedOrders)
            {
                order.Status = "Paid";
                await _orderRepository.UpdateAsync(order);  // Folosim UpdateAsync pentru a actualiza comenzile
                processedOrderIds.Add(order.Id);  // Adăugăm ID-ul comenzii procesate
            }

            // Returnăm lista cu ID-urile procesate
            return processedOrderIds;
        }
    }
}
