using Barcode.Entities;
using Barcode.Entities.DTO;
namespace Barcode.Service;

public interface IBarcodeService
{
    Prodotto GetBarcodeByBarcodeId(string barcodeId);
    void UpdateBarcode(string barcodeId, int quantity);
    void AddBarcode(BarcodeDTO request);
    Task<int> GetContototale();
    Task<IEnumerable<Prodotto>> GetAllProdottiAsync();
    Task<Prodotto> GetProdottoWithMaxQuantityAsync();
    Task<Prodotto> GetProdottoWithMinQuantityAsync();
    Task DeleteProductAsync(int id);
}