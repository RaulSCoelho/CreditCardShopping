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
            var products = await _productService.FindAllProducts();

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
            if (ModelState.IsValid)
            {
                var response = await _productService.CreateProduct(model);
                if(response != null) return RedirectToAction(nameof(ProductIndex));
            }

            return View(model);
        }

        public async Task<IActionResult> ProductUpdate(long id)
        {
            var product = await _productService.FindProductById(id);
            if (product != null) return View(product);
            return NotFound();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ProductUpdate(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.UpdateProduct(model);
                if(response != null) return RedirectToAction(nameof(ProductIndex));
            }

            return View(model);
        }

        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> ProductDelete(long id)
        {
            var response = await _productService.DeleteProductById(id);
            if (response) return RedirectToAction(nameof(ProductIndex));

            return NotFound();
        }
        #endregion
    }
}