using Barcode.Data;
using Barcode.Entities;
using Barcode.Eccezioni;
using Microsoft.EntityFrameworkCore;

namespace Barcode.Repository
{
    public class BarcodeRepository : IBarcodeRepository
    {
        private readonly DataContext _context;

        // Make the constructor public
        public BarcodeRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Prodotto GetBarcode(string barcodeId)
        {
            var barcode = _context.prodotti.FirstOrDefault(b => b.Barcode == barcodeId);
            /*if (barcode == null)
            {
                throw new InvalidOperationException($"Questo codice: {barcodeId} non è presente nel database");
            }
            */
            return barcode;
        }

        public void UpdateBarcodeQuantity(string barcodeId, int quantity)
        {
            var barcode = _context.prodotti.FirstOrDefault(b => b.Barcode == barcodeId);
            if (barcode != null)
            {
                
               //int  newQuantity = barcode.qta + quantity
                if (quantity < 0)
                {
                    throw new QtaInvalida("La quantità non può essere minore di 0");
                }
                barcode.qta = quantity;
                _context.SaveChanges();
            }
        }
        public void AddBarcode(Prodotto prodotto, string barcodeId, string barcodeNome)
        {
            var barcode = _context.prodotti.FirstOrDefault(b => b.Barcode == barcodeId);
            if (barcode != null)
            {
                throw new ProdottoGiaPresente("Prodotto già presente nel DB!");
            }
            var barcode2 = _context.prodotti.FirstOrDefault(b => b.Nome == barcodeNome);
            if (barcode2 != null)
            {
                throw new ProdottoGiaPresente("Errore! Nome prodotto uguale a un articolo già presente");
            }
            _context.prodotti.Add(prodotto);
            _context.SaveChanges();
        }
        public async Task<int> Contaelementi()
        {
            return await _context.prodotti.CountAsync();
        }
        public async Task<IEnumerable<Prodotto>> GetAllProdottiAsync()
        {
            return await _context.prodotti.ToListAsync();
        }
        public async Task<Prodotto> GetProdottoWithMaxQuantityAsync()
        {
            return await _context.prodotti.OrderByDescending(p => p.qta).FirstOrDefaultAsync();
        }

        public async Task<Prodotto> GetProdottoWithMinQuantityAsync()
        {
            return await _context.prodotti.OrderBy(p => p.qta).FirstOrDefaultAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var product = await _context.prodotti.FindAsync(id);
            if (product != null)
            {
                _context.prodotti.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}