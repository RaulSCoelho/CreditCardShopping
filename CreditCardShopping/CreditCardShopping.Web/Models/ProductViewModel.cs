using System.ComponentModel.DataAnnotations;

namespace CreditCardShopping.Web.Models
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public double Price { get; set; }

        [Range(1, 100)]
        public int Count { get; set; } = 1;
    }
}
