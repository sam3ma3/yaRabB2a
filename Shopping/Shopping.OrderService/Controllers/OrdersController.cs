using Confluent.Kafka;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopping.Model;
using Shopping.OrderService.Data;
using static Confluent.Kafka.ConfigPropertyNames;
using ECommerce.Services.OrderService.Kafka;

namespace Shopping.OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController(IKafkaProducer producer,OrderDbContext dbContext) : ControllerBase
    {
        [HttpGet]
        public async Task<List<Order>> GetOrders()
        {
            return await dbContext.Orders.ToListAsync();
        }

        [HttpPost]
        public async Task<Order> AddOrder(Order order)
        {
            dbContext.Orders.Add(order);
            await dbContext.SaveChangesAsync();

            var orderMessage = new OrderMessage
            {
                OrderId = order.Id,
                Quantity = order.Quantity,
                ProductId = order.ProductId
            };
            await producer.ProduceAsync("order-topic", new Message<string, string>
            {
                Key = order.Id.ToString(),
                Value = JsonSerializer.Serialize(orderMessage)
            });

            return order;
        }
    }
}
