using CreditCardShopping.CartAPI.Data.ValueObjects;
using CreditCardShopping.CartAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CreditCardShopping.CartAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private ICartRepository _repository;

        public CartController(ICartRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<CartVO>> FindCartByUserId(string userId)
        {
            var cart = await _repository.FindCartByUserId(userId);
            if (cart == null) return NotFound();
            return Ok(cart);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CartVO>> SaveOrUpdateCart(CartVO cartVo)
        {
            var cart = await _repository.SaveOrUpdateCart(cartVo);
            if (cart == null) return NotFound();
            return Ok(cart);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<bool>> RemoveFromCart(int id)
        {
            var status = await _repository.RemoveFromCart(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}
