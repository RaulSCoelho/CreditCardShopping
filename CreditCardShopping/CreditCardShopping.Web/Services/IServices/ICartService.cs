using CreditCardShopping.Web.Models;

namespace CreditCardShopping.Web.Services.IServices
{
    public interface ICartService
    {
        Task<CartViewModel> FindCartByUserId(string userId, string token);
        Task<CartViewModel> SaveOrUpdateCart(CartViewModel cartViewModel, string token);
        Task<bool> RemoveFromCart(int id, string token);
        Task<bool> ClearCart(string userId, string token);
        Task<CartViewModel> Checkout(CartHeaderViewModel cartHeader, string token);
        Task<bool> ApplyCoupon(string userId, string couponCode, string token);
        Task<bool> RemoveCoupon(string userId, string token);
    }
}
