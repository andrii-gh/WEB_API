using _01.Data;
using _01.Models;
using _01.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.GetAllAsync();
            return View(products);
        }

        public async Task<IActionResult> ByName(string name)
        {
            var products = await _productRepository.GetByNameAsync(name);
            if (products == null) return NotFound();
            return View("Index", new List<Product> { products });
        }

        public async Task<IActionResult> ByCategory(string categoryName)
        {
            var products = await _productRepository.GetByCategoryNameAsync(categoryName);
            return View("Index", products);
        }

        public async Task<IActionResult> ByPrice(decimal min, decimal max)
        {
            var products = await _productRepository.GetByPriceRangeAsync(min, max);
            return View("Index", products);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productRepository.AddAsync(product);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var product = await _productRepository.GetByIdAsync(id.Value);
            if (product == null) return NotFound();

            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.Id) return NotFound();

            if (ModelState.IsValid)
            {
                await _productRepository.UpdateAsync(product);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var product = await _productRepository.GetByIdAsync(id.Value);
            if (product == null) return NotFound();

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}