using Finall_ASP.NET.Data;
using Finall_ASP.NET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Finall_ASP.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DishesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Dishes.Include(d => d.Restaurant).ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Dish dish)
        {
            _context.Dishes.Add(dish);
            await _context.SaveChangesAsync();
            return Ok(dish);
        }
    }
}