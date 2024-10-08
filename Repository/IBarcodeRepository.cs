using Barcode.Entities;
namespace Barcode.Repository;

public interface IBarcodeRepository
{
    Prodotto GetBarcode(string barcodeid);
    void UpdateBarcodeQuantity(string barcodeId, int quantity);
}