using AutoMapper;
using Finall_ASP.NET.Data;
using Finall_ASP.NET.DTOs;
using Finall_ASP.NET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Finall_ASP.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public RestaurantsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var restaurants = await _context.Restaurants.ToListAsync();
            var dtos = _mapper.Map<List<RestaurantDto>>(restaurants);
            return Ok(dtos);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
            await _context.SaveChangesAsync();
            return Ok(restaurant);
        }
    }
}