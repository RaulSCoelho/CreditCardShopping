namespace CreditCardShopping.CartAPI.Model
{
    public class Cart
    {
        public CartHeader CartHeader { get; set; }
        public List<CartDetail> CartDetails { get; set; }
    }
}
