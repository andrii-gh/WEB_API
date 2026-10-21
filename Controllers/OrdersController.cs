using Finall_ASP.NET.Data;
using Finall_ASP.NET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Finall_ASP.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Orders.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Order order)
        {
            order.CreatedAt = DateTime.UtcNow;
            order.Status = "Нове";
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return Ok(order);
        }
    }
}