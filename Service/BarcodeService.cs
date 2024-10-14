using Barcode.Repository;
using Barcode.Entities;
using Barcode.Entities.DTO;
using Barcode.Eccezioni;
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
        if (string.IsNullOrWhiteSpace(request.BarcodeId) || request.BarcodeId.Length != 13)
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
            throw new QtaInvalida("La quantità non può essere minore di 0");
        }
        
        _barcodeRepository.AddBarcode(barcode, request.BarcodeId, request.BarcodeName);
    }
    public async Task<int> GetContototale()
    {
        return await _barcodeRepository.Contaelementi();
    }
    public async Task<IEnumerable<Prodotto>> GetAllProdottiAsync()
    {
        return await _barcodeRepository.GetAllProdottiAsync();
    }

    public async Task<Prodotto> GetProdottoWithMaxQuantityAsync()
    {
        return await _barcodeRepository.GetProdottoWithMaxQuantityAsync();
    }

    public async Task<Prodotto> GetProdottoWithMinQuantityAsync()
    {
        return await _barcodeRepository.GetProdottoWithMinQuantityAsync();
    }
    public async Task DeleteProductAsync(int id)
    {
        await _barcodeRepository.DeleteAsync(id);
    }
}