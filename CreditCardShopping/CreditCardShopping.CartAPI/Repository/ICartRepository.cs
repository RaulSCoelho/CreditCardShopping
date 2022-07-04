using CreditCardShopping.CartAPI.Data.ValueObjects;

namespace CreditCardShopping.CartAPI.Repository
{
    public interface ICartRepository
    {
        Task<List<ProductVO>> FindAll();
        Task<ProductVO> FindById(long id);
        Task<ProductVO> Create(ProductVO vo);
        Task<ProductVO> Update(ProductVO vo);
        Task<bool> Delete(long id);
    }
}
