namespace CreditCardShopping.CartAPI.Data.ValueObjects
{
    public class CartVO
    {
        public CartHeaderVO CartHeader { get; set; }
        public List<CartDetailVO> CartDetails { get; set; }
    }
}
