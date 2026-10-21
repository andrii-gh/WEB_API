using Finall_ASP.NET.Data;
using Microsoft.EntityFrameworkCore;
using Quartz;

namespace Finall_ASP.NET.Jobs
{
    public class OrderStatusJob : IJob
    {
        private readonly AppDbContext _context;
        private readonly ILogger<OrderStatusJob> _logger;

        public OrderStatusJob(AppDbContext context, ILogger<OrderStatusJob> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var oldOrders = await _context.Orders
                .Where(o => o.Status == "Нове" && o.CreatedAt < DateTime.UtcNow.AddMinutes(-1))
                .ToListAsync();

            foreach (var order in oldOrders)
            {
                order.Status = "Готується";
                _logger.LogInformation("Замовлення #{Id} для {Name} змінено на: Готується", order.Id, order.CustomerName);
            }

            if (oldOrders.Any())
            {
                await _context.SaveChangesAsync();
            }
        }
    }
}