using Microsoft.EntityFrameworkCore;

public class Context : DbContext
{
    public DbSet<Employee> employee { get; set; }
    public DbSet<EventModel> events { get; set; }
    public DbSet<Product> products { get; set; }
    public Context(DbContextOptions<Context> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source= Data\\Database2.Db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(
            new Product { ProductId = 1, Name = "POND'S CLARANT B3", Description = "Esta crema para piel grasa es humectante y de uso diario. Ayuda a combatir la decoloración, reduciendo visiblemente la apariencia de manchas oscuras en 4 semanas, para que tu piel luzca radiante y con un tono más uniforme.", Image = "https://assets.unileversolutions.com/v1/44022034.png", Price = 10 },
            new Product { ProductId = 2, Name = "Nivea Body Milk Bajo La Ducha", Description = "Hidrata la piel de forma rápida gracias a la combinación de ingredientes humectantes y aceite de almendras, que se activan cuando entran en contacto con el agua para absorberse al instante.", Image = "https://hips.hearstapps.com/vader-prod.s3.amazonaws.com/1691762276-1442473.jpg?crop=1xw:1.00xh;center,top&resize=980:*", Price = 5 },
            new Product { ProductId = 3, Name = "CeraVe Crema Hidratante", Description = "La Crema Hidratante de CeraVe, desarrollada por dermatólogos, ofrece una respuesta idónea para aquellas pieles sensibles y secas que buscan una hidratación profunda y duradera. Referente en las pieles más delicadas.", Image = "https://www.cerave.es/-/media/Project/Loreal/BrandSites/CeraVe/Master/Spain/Product/Moisturizers/Moisturizing-cream-16oz.png", Price = 10 },
            new Product { ProductId = 4, Name = "Aceite Esencial Romero Concentración 12 ML", Description = "El aceite esencial de Romero  es un aceite muy perfumado  en AROMATERAPÌA , es la CONCENTRACIÓN ,  crea ambientes frescos y aumenta la CONCENTRACIÓN y la MEMORIA .y su uso tópico como antiséptico.", Image = "https://www.aromesdemorella.com/1077-big_default/aceite-esencial-romero-aromaterapia-12-ml.jpg", Price = 5 },
            new Product { ProductId = 5, Name = "Christmas Spirit", Description = "Celebra la época más mágica del año con el atrayente aroma de la naranja, la canela y la pícea negra. Usa la mezcla de aceites esenciales o disfruta de su fragancia en el jabón de manos.", Image = "https://static.youngliving.com/productimages/large/45222.jpg", Price = 15 },
            new Product { ProductId = 6, Name = "Gel Cream Oil Control Toque Seco x 50 ML Eucerin", Description = "El protector solar también es compatible con el mecanismo de reparación del ADN de la piel e incluye la tecnología Oil Control que regula el sebo.", Image = "https://climed.com.do/wp-content/uploads/2021/09/Eucerin-Protector-Solar-en-Gel-Oil-control-SPF-50-X-50mL.jpg", Price = 8 },
            new Product { ProductId = 7, Name = "Olaplex N3 Hair Perfector Reparador y Fortalecedor Capilar", Description = "Se trata de una loción intensificadora para marcar aún tus rizos y conseguir acabar con el encrespamiento. Se aplica sobre el cabello mojado antes de empezar a trabajar en la definición.", Image = "https://hips.hearstapps.com/vader-prod.s3.amazonaws.com/1662113053-n3-hair-perfector-reparador-y-fortalecedor-capilar.jpg?crop=1xw:1.00xh;center,top&resize=980:*", Price = 5 },
            new Product { ProductId = 8, Name = "Rulls Moisturizer Curl Cream", Description = "Si aún no conoces Rulls, solamente decirte que se incorporó al catálogo de la tienda este mismo año y ha sido todo un bombazo. Es Made in Spain y con ingredientes naturales ecológicos certificados. ¡Todo un descubrimiento!", Image = "https://www.sofiablack.com/blog/wp-content/uploads/rulls-styling-curl-gel.webp", Price = 15 },
            new Product { ProductId = 9, Name = "Aunt Jackie's Curl La La", Description = "Una crema de peinado que lleva con nosotros desde los inicios de la tienda en 2012, y no deja de maravillar melenas rizadas de tipo 3 y 4. Rizos flexibles, suaves y superhidratados", Image = "https://www.sofiablack.com/blog/wp-content/uploads/aunt-jackies-curl-la-la.webp", Price = 15 }
        );
    }
}