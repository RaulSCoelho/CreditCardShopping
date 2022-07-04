using CreditCardShopping.Web.Models;
using CreditCardShopping.Web.Services.IServices;
using CreditCardShopping.Web.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CreditCardShopping.Web.Controllers
{
	public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private static JwtUtil jwt = new JwtUtil();

		public HomeController(ILogger<HomeController> logger, IProductService productService)
		{
			_logger = logger;
			_productService = productService;
		}

		public async Task<IActionResult> Index()
        {
            var token = jwt.GetToken(HttpContext).Result;
            var products = await _productService.FindAllProducts(token);

            return View(products);
        }

        [HttpGet]
        public async Task<JsonResult> GetProductById(int id)
        {
            var token = jwt.GetToken(HttpContext).Result;
            var product = await _productService.FindProductById(id, token);

            return Json(product);
        }

        [Authorize]
        public async Task<IActionResult> Login()
        {
            var token = jwt.GetToken(HttpContext).Result;
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}