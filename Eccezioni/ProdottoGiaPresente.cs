namespace Barcode.Eccezioni;

public class ProdottoGiaPresente : Exception
{
    public ProdottoGiaPresente(string message) : base(message)
    {
    }
}