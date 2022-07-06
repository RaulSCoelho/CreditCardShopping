namespace CreditCardShopping.Web.Models
{
    public class CartViewModel
    {
        public CartHeaderViewModel CartHeader { get; set; }
        public List<CartDetailViewModel> CartDetails { get; set; }
    }
}
