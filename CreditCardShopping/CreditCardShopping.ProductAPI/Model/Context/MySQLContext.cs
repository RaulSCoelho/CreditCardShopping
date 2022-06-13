using Microsoft.EntityFrameworkCore;

namespace CreditCardShopping.ProductAPI.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() {}
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) {}

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Name = "Notebook Acer Nitro 5",
                Price = 5199.99,
                Description = "GTX 1650, intel core i5, 8GB de RAM, 512GB SSD",
                CategoryName = "Notebook Gamer",
                ImageURL = "https://www.kabum.com.br/conteudo/descricao/113442/img/header-image.png",
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                Name = "GeForce RTX 3060",
                Price = 6999.9,
                Description = "Com a GeForce RTX™ 3060 Ti e a RTX™ 3060, você pode jogar os games mais atuais usando o poder da Ampere, a 2ª geração da arquitetura RTX da NVIDIA. Obtenha um desempenho incrível com Ray Tracing Cores e Tensor Cores aprimorados, novos multiprocessadores de streaming e memória G6 de alta velocidade.",
                CategoryName = "Placas de Vídeo",
                ImageURL = "https://images.nvidia.com/aem-dam/Solutions/geforce/ampere/rtx-3060-ti/geforce-rtx-3060-ti-product-gallery-full-screen-3840-3-bl.jpg",
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 3,
                Name = "Mouse Gamer Sem Fio Logitech G PRO Wireless",
                Price = 799.9,
                Description = "Tecnologia LIGHTSPEED, RGB LIGHTSYNC, Design Ambidestro, 6 Botões Programáveis, Sensor HERO 25K e Bateria Recarregável - Compatível com POWERPLAY",
                CategoryName = "Mouse Gamer",
                ImageURL = "https://www.logitechstore.com.br/media/catalog/product/cache/1/image/634x545/9df78eab33525d08d6e5fb8d27136e95/p/r/pro-wireless.png",
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 4,
                Name = "Headset Sem Fio Gamer HyperX Cloud II",
                Price = 1199.9,
                Description = "O HyperX Cloud foi criado para ser um headset gamer ultraconfortável com um som espetacular. Pensamos muito nos detalhes, como nossa espuma memory foam exclusiva HyperX, o couro sintético premium, a força de aperto do arco da cabeça reduzida e o peso equilibrado para criar um headset que fosse confortável para longas sessões de jogo.",
                CategoryName = "Headset Gamer",
                ImageURL = "https://prosettings.net/wp-content/uploads/2020/11/HyperX-Cloud-II-Wireless-Transparent-Background.png",
            });
        }
    }
}
