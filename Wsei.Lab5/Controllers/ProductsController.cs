using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Wsei.Lab5.Database;
using Wsei.Lab5.Entities;
using Wsei.Lab5.Models;
using Wsei.Lab5.Services;

namespace Wsei.Lab5.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductModel product)
        {
            await _productService.Add(product);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> List(string name)
        {
            var products = await _productService.GetAll(name);
            return View(products);
        }
    }
}
