using System.ComponentModel.DataAnnotations;

namespace Barcode.Entities;

public class Prodotto
{
    [Key]
    public int ID { get; set; }
    public required string BarcodeId { get; set; }
    public required string BarcodeName { get; set; }
    public int qta  { get; set; }
    
}