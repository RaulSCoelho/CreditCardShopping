using CreditCardShopping.Web.Models;
using CreditCardShopping.Web.Services.IServices;
using CreditCardShopping.Web.Utils;

namespace CreditCardShopping.Web.Services
{
	public class ProductService : IProductService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/v1/Product";
        private static JwtUtil jwt = new JwtUtil();

        public ProductService(HttpClient client)
		{
			_client = client ?? throw new ArgumentNullException(nameof(client));
		}

		public async Task<List<ProductViewModel>> FindAllProducts(string token)
        {
            jwt.Authorize(_client, token);
            var response = await _client.GetAsync(BasePath);
            return await response.ReadContentAs<List<ProductViewModel>>();
        }

        public async Task<ProductViewModel> FindProductById(long id, string token)
        {
            jwt.Authorize(_client, token);
            var response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<ProductViewModel>();
        }

        public async Task<ProductViewModel> CreateProduct(ProductViewModel product, string token)
        {
            jwt.Authorize(_client, token);
            var response = await _client.PostAsJson(BasePath, product);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProductViewModel>();
            else throw new Exception($"Something went wrong calling the API: {response.ReasonPhrase}");
        }

        public async Task<ProductViewModel> UpdateProduct(ProductViewModel product, string token)
        {
            jwt.Authorize(_client, token);
            var response = await _client.PutAsJson(BasePath, product);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProductViewModel>();
            else throw new Exception($"Something went wrong calling the API: {response.ReasonPhrase}");
        }

        public async Task<bool> DeleteProductById(long id, string token)
        {
            jwt.Authorize(_client, token);
            var response = await _client.DeleteAsync($"{BasePath}/{id}");
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();
            else throw new Exception($"Something went wrong calling the API: {response.ReasonPhrase}");
        }
    }
}
