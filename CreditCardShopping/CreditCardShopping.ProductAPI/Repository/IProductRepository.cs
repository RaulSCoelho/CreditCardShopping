using CreditCardShopping.ProductAPI.Data.ValueObjects;

namespace CreditCardShopping.ProductAPI.Repository
{
    public interface IProductRepository
    {
        Task<List<ProductVO>> FindAll();
        Task<ProductVO> FindById(long id);
        Task<ProductVO> Create(ProductVO vo);
        Task<ProductVO> Update(ProductVO vo);
        Task<bool> Delete(long id);
    }
}
