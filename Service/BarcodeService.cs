using Barcode.Repository;
using Barcode.Entities;
namespace Barcode.Service;

public class BarcodeService : IBarcodeService
{
    private readonly IBarcodeRepository _repository;

    public BarcodeService(IBarcodeRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(BarcodeRepository));
    }
    
    public barcode? GetBarcodeByBarcodeId(string barcodeId)
    {
        return _repository.GetBarcode(barcodeId);
    }
}