using CreditCardShopping.Web.Models;
using CreditCardShopping.Web.Services.IServices;
using CreditCardShopping.Web.Utils;

namespace CreditCardShopping.Web.Services
{
    public class CartService : ICartService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/v1/Cart";
        private static JwtUtil jwt = new JwtUtil();

        public CartService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<CartViewModel> FindCartByUserId(string userId, string token)
        {
            jwt.Authorize(_client, token);
            var response = await _client.GetAsync($"{BasePath}/get-cart/{userId}");
            return await response.ReadContentAs<CartViewModel>();
        }

        public async Task<CartViewModel> SaveOrUpdateCart(CartViewModel cartViewModel, string token)
        {
            jwt.Authorize(_client, token);
            var response = await _client.PostAsJson($"{BasePath}/save-cart", cartViewModel);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<CartViewModel>();
            else throw new Exception($"Something went wrong calling the API: {response.ReasonPhrase}");
        }

        public async Task<bool> RemoveFromCart(int id, string token)
        {
            jwt.Authorize(_client, token);
            var response = await _client.DeleteAsync($"{BasePath}/remove-cart/{id}");
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();
            else throw new Exception($"Something went wrong calling the API: {response.ReasonPhrase}");
        }

        public Task<bool> ClearCart(string userId, string token)
        {
            throw new NotImplementedException();
        }

        public Task<CartViewModel> Checkout(CartHeaderViewModel cartHeader, string token)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ApplyCoupon(string userId, string couponCode, string token)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveCoupon(string userId, string token)
        {
            throw new NotImplementedException();
        }
    }
}
