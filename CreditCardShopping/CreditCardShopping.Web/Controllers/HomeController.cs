using CreditCardShopping.Web.Models;
using CreditCardShopping.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CreditCardShopping.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.FindAllProducts();

            return View(products);
        }

        [HttpGet]
        public JsonResult GetProductById(int id)
        {
            var products = new List<ProductViewModel>();
            var product1 = new ProductViewModel()
            {
                Id = 1,
                CategoryName = "Notebook Gamer",
                Name = "Notebook Acer Nitro 5",
                Price = 5199.99,
                Description = "GTX 1650, intel core i5, 8GB de RAM, 512GB SSD",
                ImageURL = "https://www.kabum.com.br/conteudo/descricao/113442/img/header-image.png"
            };

            products.Add(product1);

            foreach(var product in products)
            {
                if(product.Id == id)
                {
                    return Json(product1);
                }
            }

            return Json("Produto não encontrado");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}