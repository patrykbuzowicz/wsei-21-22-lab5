using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Wsei.Lab5.Database;
using Wsei.Lab5.Entities;
using Wsei.Lab5.Models;

namespace Wsei.Lab5.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ProductsController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductModel product)
        {
            var entity = new ProductEntity
            {
                Name = product.Name,
                Description = product.Description,
                IsVisible = product.IsVisible,
            };

            await _dbContext.Products.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return View();
        }
    }
}
