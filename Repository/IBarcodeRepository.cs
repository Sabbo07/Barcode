using Barcode.Entities;
namespace Barcode.Repository;

public interface IBarcodeRepository
{
    barcode GetBarcode(string barcodeid);
}