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

        public barcode? GetBarcode(string barcodeId)
        {
            return _context.barcodes.FirstOrDefault(b => b.BarcodeId == barcodeId);
        }
    }
}