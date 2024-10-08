using Barcode.Data;
using Barcode.Entities;

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
            var barcode = _context.barcodes.FirstOrDefault(b => b.BarcodeId == barcodeId);
            /*if (barcode == null)
            {
                throw new InvalidOperationException($"Questo codice: {barcodeId} non è presente nel database");
            }
            */
            return barcode;
        }

        public void UpdateBarcodeQuantity(string barcodeId, int quantity)
        {
            var barcode = _context.barcodes.FirstOrDefault(b => b.BarcodeId == barcodeId);
            if (barcode != null)
            {
                int newQuantity = barcode.qta + quantity;
                if (newQuantity < 0)
                {
                    throw new InvalidOperationException("Ls quantità non può essere minore di 000");
                }
                barcode.qta = newQuantity;
                _context.SaveChanges();
            }
        }
    }
}