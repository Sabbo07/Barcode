using Barcode.Entities;
namespace Barcode.Service;

public interface IBarcodeService
{
    Prodotto GetBarcodeByBarcodeId(string barcodeId);
    void UpdateBarcode(string barcodeId, int quantity);
}