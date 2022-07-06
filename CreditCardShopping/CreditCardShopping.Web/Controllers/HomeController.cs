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
        private readonly ICartService _cartService;
        private static JwtUtil jwt = new JwtUtil();

		public HomeController(ILogger<HomeController> logger, IProductService productService, ICartService cartService)
		{
			_logger = logger;
			_productService = productService;
            _cartService = cartService ?? throw new ArgumentNullException(nameof(cartService));
        }

		public async Task<IActionResult> Index()
        {
            var token = jwt.GetToken(HttpContext).Result;
            var products = await _productService.FindAllProducts(token);

            return View(products);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            var token = jwt.GetToken(HttpContext).Result;
            var product = await _productService.FindProductById(id, token);

            return View(product);
        }

        [HttpPost]
        [ActionName("Details")]
        [Authorize]
        public async Task<IActionResult> AddToCart(ProductViewModel product)
        {
            var token = jwt.GetToken(HttpContext).Result;
            var cart = new CartViewModel()
            {
                CartHeader = new CartHeaderViewModel
                {
                    UserId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value,
                },
                CartDetails = new List<CartDetailViewModel>()
            };

            var cartDetail = new CartDetailViewModel()
            {
                CartHeaderId = cart.CartHeader.Id,
                ProductId = product.Id,
                Product = await _productService.FindProductById(product.Id, token),
                Count = product.Count
            };

            cart.CartDetails.Add(cartDetail);

            var response = await _cartService.SaveOrUpdateCart(cart, token);
            if(response != null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(product);
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