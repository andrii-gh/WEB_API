using _01.Data;
using _01.Models;
using _01.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace _01.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ApplicationDbContext _context;

        public CatalogController(IProductRepository productRepository, ApplicationDbContext context)
        {
            _productRepository = productRepository;
            _context = context;
        }

        public async Task<IActionResult> Index(string? categoryName)
        {
            IEnumerable<Product> products;

            if (string.IsNullOrEmpty(categoryName))
            {
                products = await _productRepository.GetAllAsync();
            }
            else
            {
                products = await _productRepository.GetByCategoryNameAsync(categoryName);
            }

            ViewBag.Categories = await _context.Categories.ToListAsync();
            ViewBag.CurrentCategory = categoryName;

            return View(products);
        }

    }
}