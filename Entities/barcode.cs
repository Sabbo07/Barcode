using System.ComponentModel.DataAnnotations;

namespace Barcode.Entities;

public class barcode
{
    [Key]
    public int ID { get; set; }
    public int BarcodeId { get; set; }
    public string BarcodeName { get; set; }
    public int qta  { get; set; }
    
}