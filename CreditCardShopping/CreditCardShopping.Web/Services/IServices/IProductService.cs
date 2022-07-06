using CreditCardShopping.Web.Models;

namespace CreditCardShopping.Web.Services.IServices
{
    public interface IProductService
    {
        Task<List<ProductViewModel>> FindAllProducts();
        Task<ProductViewModel> FindProductById(long id, string token);
        Task<ProductViewModel> CreateProduct(ProductViewModel product, string token);
        Task<ProductViewModel> UpdateProduct(ProductViewModel product, string token);
        Task<bool> DeleteProductById(long id, string token);
    }
}
