using AutoMapper;
using CreditCardShopping.ProductAPI.Data.ValueObjects;
using CreditCardShopping.ProductAPI.Model;

namespace CreditCardShopping.ProductAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig =  new MapperConfiguration(config =>
            {
                config.CreateMap<ProductVO, Product>();
                config.CreateMap<Product, ProductVO>();
            });
            return mappingConfig;
        }
    }
}
