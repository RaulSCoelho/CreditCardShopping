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
        public async Task<IActionResult> CartIndex(string userId)
        {
            var token = jwt.GetToken(HttpContext).Result;
            var cart = await _cartService.FindCartByUserId(userId, token);

            return View(cart);
        }
        #endregion
    }
}