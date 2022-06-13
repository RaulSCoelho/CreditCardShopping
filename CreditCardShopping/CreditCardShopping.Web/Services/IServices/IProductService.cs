using CreditCardShopping.Web.Models;

namespace CreditCardShopping.Web.Services.IServices
{
    public interface IProductService
    {
        Task<List<ProductViewModel>> FindAllProducts();
        Task<ProductViewModel> FindProductById(long id);
        Task<ProductViewModel> CreateProduct(ProductViewModel product);
        Task<ProductViewModel> UpdateProduct(ProductViewModel product);
        Task<bool> DeleteProductById(long id);
    }
}
