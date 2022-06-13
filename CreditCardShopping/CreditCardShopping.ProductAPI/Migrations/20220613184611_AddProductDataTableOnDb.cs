using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditCardShopping.ProductAPI.Migrations
{
    public partial class AddProductDataTableOnDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    price = table.Column<double>(type: "double", nullable: false),
                    description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    category_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    image_url = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "id", "category_name", "description", "image_url", "name", "price" },
                values: new object[,]
                {
                    { 1L, "Notebook Gamer", "GTX 1650, intel core i5, 8GB de RAM, 512GB SSD", "https://www.kabum.com.br/conteudo/descricao/113442/img/header-image.png", "Notebook Acer Nitro 5", 5199.9899999999998 },
                    { 2L, "Placas de Vídeo", "Com a GeForce RTX™ 3060 Ti e a RTX™ 3060, você pode jogar os games mais atuais usando o poder da Ampere, a 2ª geração da arquitetura RTX da NVIDIA. Obtenha um desempenho incrível com Ray Tracing Cores e Tensor Cores aprimorados, novos multiprocessadores de streaming e memória G6 de alta velocidade.", "https://images.nvidia.com/aem-dam/Solutions/geforce/ampere/rtx-3060-ti/geforce-rtx-3060-ti-product-gallery-full-screen-3840-3-bl.jpg", "GeForce RTX 3060", 6999.8999999999996 },
                    { 3L, "Mouse Gamer", "Tecnologia LIGHTSPEED, RGB LIGHTSYNC, Design Ambidestro, 6 Botões Programáveis, Sensor HERO 25K e Bateria Recarregável - Compatível com POWERPLAY", "https://www.logitechstore.com.br/media/catalog/product/cache/1/image/634x545/9df78eab33525d08d6e5fb8d27136e95/p/r/pro-wireless.png", "Mouse Gamer Sem Fio Logitech G PRO Wireless", 799.89999999999998 },
                    { 4L, "Headset Gamer", "O HyperX Cloud foi criado para ser um headset gamer ultraconfortável com um som espetacular. Pensamos muito nos detalhes, como nossa espuma memory foam exclusiva HyperX, o couro sintético premium, a força de aperto do arco da cabeça reduzida e o peso equilibrado para criar um headset que fosse confortável para longas sessões de jogo.", "https://prosettings.net/wp-content/uploads/2020/11/HyperX-Cloud-II-Wireless-Transparent-Background.png", "Headset Sem Fio Gamer HyperX Cloud II", 1199.9000000000001 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product");
        }
    }
}
