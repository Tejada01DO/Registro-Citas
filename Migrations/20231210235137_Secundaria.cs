using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RegistroCitas.Migrations
{
    /// <inheritdoc />
    public partial class Secundaria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployeeName = table.Column<string>(type: "TEXT", nullable: true),
                    EmployeeColor = table.Column<string>(type: "TEXT", nullable: false),
                    EmployeeEmail = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Image = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Subject = table.Column<string>(type: "TEXT", nullable: true),
                    Location = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StartTimezone = table.Column<string>(type: "TEXT", nullable: true),
                    EndTimezone = table.Column<string>(type: "TEXT", nullable: true),
                    IsAllDay = table.Column<bool>(type: "INTEGER", nullable: true),
                    IsBlock = table.Column<bool>(type: "INTEGER", nullable: true),
                    IsReadonly = table.Column<bool>(type: "INTEGER", nullable: true),
                    RecurrenceID = table.Column<int>(type: "INTEGER", nullable: true),
                    FollowingID = table.Column<int>(type: "INTEGER", nullable: true),
                    RecurrenceRule = table.Column<string>(type: "TEXT", nullable: true),
                    RecurrenceException = table.Column<string>(type: "TEXT", nullable: true),
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_events_employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employee",
                        principalColumn: "EmployeeId");
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "ProductId", "Description", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Esta crema para piel grasa es humectante y de uso diario. Ayuda a combatir la decoloración, reduciendo visiblemente la apariencia de manchas oscuras en 4 semanas, para que tu piel luzca radiante y con un tono más uniforme.", "https://assets.unileversolutions.com/v1/44022034.png", "POND'S CLARANT B3", 10m },
                    { 2, "Hidrata la piel de forma rápida gracias a la combinación de ingredientes humectantes y aceite de almendras, que se activan cuando entran en contacto con el agua para absorberse al instante.", "https://hips.hearstapps.com/vader-prod.s3.amazonaws.com/1691762276-1442473.jpg?crop=1xw:1.00xh;center,top&resize=980:*", "Nivea Body Milk Bajo La Ducha", 5m },
                    { 3, "La Crema Hidratante de CeraVe, desarrollada por dermatólogos, ofrece una respuesta idónea para aquellas pieles sensibles y secas que buscan una hidratación profunda y duradera. Referente en las pieles más delicadas.", "https://www.cerave.es/-/media/Project/Loreal/BrandSites/CeraVe/Master/Spain/Product/Moisturizers/Moisturizing-cream-16oz.png", "CeraVe Crema Hidratante", 10m },
                    { 4, "El aceite esencial de Romero  es un aceite muy perfumado  en AROMATERAPÌA , es la CONCENTRACIÓN ,  crea ambientes frescos y aumenta la CONCENTRACIÓN y la MEMORIA .y su uso tópico como antiséptico.", "https://www.aromesdemorella.com/1077-big_default/aceite-esencial-romero-aromaterapia-12-ml.jpg", "Aceite Esencial Romero Concentración 12 ML", 5m },
                    { 5, "Celebra la época más mágica del año con el atrayente aroma de la naranja, la canela y la pícea negra. Usa la mezcla de aceites esenciales o disfruta de su fragancia en el jabón de manos.", "https://static.youngliving.com/productimages/large/45222.jpg", "Christmas Spirit", 15m },
                    { 6, "El protector solar también es compatible con el mecanismo de reparación del ADN de la piel e incluye la tecnología Oil Control que regula el sebo.", "https://climed.com.do/wp-content/uploads/2021/09/Eucerin-Protector-Solar-en-Gel-Oil-control-SPF-50-X-50mL.jpg", "Gel Cream Oil Control Toque Seco x 50 ML Eucerin", 8m },
                    { 7, "Se trata de una loción intensificadora para marcar aún tus rizos y conseguir acabar con el encrespamiento. Se aplica sobre el cabello mojado antes de empezar a trabajar en la definición.", "https://hips.hearstapps.com/vader-prod.s3.amazonaws.com/1662113053-n3-hair-perfector-reparador-y-fortalecedor-capilar.jpg?crop=1xw:1.00xh;center,top&resize=980:*", "Olaplex N3 Hair Perfector Reparador y Fortalecedor Capilar", 5m },
                    { 8, "Si aún no conoces Rulls, solamente decirte que se incorporó al catálogo de la tienda este mismo año y ha sido todo un bombazo. Es Made in Spain y con ingredientes naturales ecológicos certificados. ¡Todo un descubrimiento!", "https://www.sofiablack.com/blog/wp-content/uploads/rulls-styling-curl-gel.webp", "Rulls Moisturizer Curl Cream", 15m },
                    { 9, "Una crema de peinado que lleva con nosotros desde los inicios de la tienda en 2012, y no deja de maravillar melenas rizadas de tipo 3 y 4. Rizos flexibles, suaves y superhidratados", "https://www.sofiablack.com/blog/wp-content/uploads/aunt-jackies-curl-la-la.webp", "Aunt Jackie's Curl La La", 15m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_events_EmployeeId",
                table: "events",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "events");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "employee");
        }
    }
}
