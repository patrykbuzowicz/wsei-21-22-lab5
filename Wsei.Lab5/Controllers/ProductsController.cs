using Microsoft.AspNetCore.Mvc;

namespace Wsei.Lab5.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add()
        {
            return View();
        }
    }
}
