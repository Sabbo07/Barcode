using Barcode.Repository;
using Barcode.Entities;
using Barcode.Entities.DTO;
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
    public void AddBarcode(BarcodeDTO request)
    {
        // Validate input
        if (string.IsNullOrWhiteSpace(request.BarcodeId) || request.BarcodeId.Length != 12)
        {
            throw new ArgumentException("Il codice deve essere di 12 caratteri");
        }

        var barcode = new Prodotto
        {
            Barcode = request.BarcodeId,
            Nome  = request.BarcodeName,
            qta = request.Qta
            
        };
        if(request.Qta < 0)
        {
            throw new ArgumentException("La quantità in inserimento del prodotto deve essere maggiore di 0");
        }
        
        _barcodeRepository.AddBarcode(barcode, request.BarcodeId, request.BarcodeName);
    }
    
}