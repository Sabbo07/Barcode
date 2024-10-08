using Microsoft.EntityFrameworkCore;
using Barcode.Entities;
namespace Barcode.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    
    public DbSet<Prodotto> barcodes { set; get; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}