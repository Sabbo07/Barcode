namespace Barcode.Entities.Request;

public class BarcodeUpdateRequest
{
    public required string BarcodeId { get; set; }
    public int NewQuantity { get; set; }
}