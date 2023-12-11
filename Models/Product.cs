using System.ComponentModel.DataAnnotations;    
using System.ComponentModel.DataAnnotations.Schema;

public class Product
{
    [Key]

    public int ProductId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }
    public decimal? Price { get; set; }
}