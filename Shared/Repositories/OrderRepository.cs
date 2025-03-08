using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using ProductOrdersProject.Interfaces;
using Shared.Models;

namespace ProductOrdersProject.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IMongoCollection<OrderDto> _orders;

        static OrderRepository()
        {
            // Înregistrarea serializatorului pentru Guid cu GuidRepresentation.Standard
            BsonSerializer.RegisterSerializer(new GuidSerializer(MongoDB.Bson.GuidRepresentation.Standard));
        }

        public OrderRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("OrdersDB");
            _orders = database.GetCollection<OrderDto>("OrderCollection");
        }

        public async Task<IEnumerable<OrderDto>> GetAllAsync()
        {
            return await _orders.Find(_ => true).ToListAsync();
        }

        public async Task AddAsync(OrderDto order)
        {
            await _orders.InsertOneAsync(order);
        }
    }
}
