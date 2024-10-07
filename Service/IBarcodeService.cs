using Barcode.Entities;
namespace Barcode.Service;

public interface IBarcodeService
{
    barcode? GetBarcodeByBarcodeId(string barcodeId);
}