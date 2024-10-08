using Barcode.Repository;
using Barcode.Entities;
namespace Barcode.Service;

public class BarcodeService : IBarcodeService
{
    private readonly IBarcodeRepository _barcodeRepository;

    public BarcodeService(IBarcodeRepository repository)
    {
        _barcodeRepository = repository ?? throw new ArgumentNullException(nameof(BarcodeRepository));
    }
    
    public Prodotto GetBarcodeByBarcodeId(string barcodeId)
    {
        return _barcodeRepository.GetBarcode(barcodeId);
    }

    public void UpdateBarcode(string barcodeId, int quantity)
    { 
        _barcodeRepository.UpdateBarcodeQuantity(barcodeId, quantity);
    }
}