using CreditCardShopping.Web.Models;
using CreditCardShopping.Web.Services.IServices;
using CreditCardShopping.Web.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CreditCardShopping.Web.Controllers
{
    public class ProductController : Controller
    {
        #region Campos
        private readonly IProductService _productService;
        private static JwtUtil jwt = new JwtUtil();
        #endregion

        #region Ctr
        public ProductController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }
        #endregion

        #region Metodos
        [Authorize]
        public async Task<IActionResult> ProductIndex()
        {
            var token = jwt.GetToken(HttpContext).Result;
            var products = await _productService.FindAllProducts(token);

            return View(products);
        }

        public IActionResult ProductCreate()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductViewModel model)
        {
            var token = jwt.GetToken(HttpContext).Result;
            if (ModelState.IsValid)
            {
                var response = await _productService.CreateProduct(model, token);
                if(response != null) return RedirectToAction(nameof(ProductIndex));
            }

            return View(model);
        }

        public async Task<IActionResult> ProductUpdate(long id)
        {
            var token = jwt.GetToken(HttpContext).Result;
            var product = await _productService.FindProductById(id, token);
            if (product != null) return View(product);
            return NotFound();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ProductUpdate(ProductViewModel model)
        {
            var token = jwt.GetToken(HttpContext).Result;
            if (ModelState.IsValid)
            {
                var response = await _productService.UpdateProduct(model, token);
                if(response != null) return RedirectToAction(nameof(ProductIndex));
            }

            return View(model);
        }

        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> ProductDelete(long id)
        {
            var token = jwt.GetToken(HttpContext).Result;
            var response = await _productService.DeleteProductById(id, token);
            if (response) return RedirectToAction(nameof(ProductIndex));

            return NotFound();
        }
        #endregion
    }
}