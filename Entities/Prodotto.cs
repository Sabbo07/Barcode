using System.ComponentModel.DataAnnotations;

namespace Barcode.Entities;

public class Prodotto
{
    [Key]
    public int ID { get; set; }
    public required string Barcode { get; set; }
    public required string Nome { get; set; }
    public int qta  { get; set; }
    
}