using Barcode.Entities;
namespace Barcode.Repository;

public interface IBarcodeRepository
{
    Prodotto GetBarcode(string barcodeid);
    void UpdateBarcodeQuantity(string barcodeId, int quantity);
    void AddBarcode(Prodotto prodotto, string barcodeid, string barcodenome);
    
    Task<int> Contaelementi();
    Task<IEnumerable<Prodotto>> GetAllProdottiAsync();
    Task<Prodotto> GetProdottoWithMaxQuantityAsync();
    Task<Prodotto> GetProdottoWithMinQuantityAsync();
    Task DeleteAsync(int id);
}