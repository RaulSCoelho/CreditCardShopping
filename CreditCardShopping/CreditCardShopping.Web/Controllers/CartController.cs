using CreditCardShopping.Web.Models;
using CreditCardShopping.Web.Services.IServices;
using CreditCardShopping.Web.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CreditCardShopping.Web.Controllers
{
    public class CartController : Controller
    {
        #region Campos
        private readonly ICartService _cartService;
        private static JwtUtil jwt = new JwtUtil();
        #endregion

        #region Ctr
        public CartController(ICartService cartService)
        {
            _cartService = cartService ?? throw new ArgumentNullException(nameof(cartService));
        }
        #endregion

        #region Metodos
        [Authorize]
        public async Task<IActionResult> CartIndex()
        {
            return View(await FindUserCart());
        }

        private async Task<CartViewModel> FindUserCart()
        {
            var token = jwt.GetToken(HttpContext).Result;
            var userId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value;

            var response = await _cartService.FindCartByUserId(userId, token);

            return response;
        }

        public async Task<IActionResult> Remove(int id)
        {
            var token = jwt.GetToken(HttpContext).Result;

            var response = await _cartService.RemoveFromCart(id, token);

            if (response)
            {
                return RedirectToAction(nameof(CartIndex));
            }
            return View();
        }
        #endregion
    }
}