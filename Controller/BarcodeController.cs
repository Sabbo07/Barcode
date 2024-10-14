using Microsoft.AspNetCore.Mvc;
using Barcode.Service;
using Barcode.Entities.Request;
using Barcode.Entities.DTO;
using Barcode.Eccezioni;
namespace Barcode.Controller;

[Route("api/[controller]")]
[ApiController]
public class BarcodeController : ControllerBase
{
    private readonly IBarcodeService _barcodeService;

    public BarcodeController(IBarcodeService barcodeService)
    {
        _barcodeService = barcodeService;
    }
    [HttpGet("{barcodeId}")]
    public IActionResult GetBarcodeByBarcodeId(string barcodeId)
    {
        var barcod = _barcodeService.GetBarcodeByBarcodeId(barcodeId);
        if (barcod == null)
        {
            return NotFound(new { Message = $"Questo barcode: '{barcodeId}' non è stato trovato." });
        }
        return Ok(barcod);
    }

    [HttpPut("update-quantity")]
    public IActionResult UpdateBarcodeQuantity([FromBody] BarcodeUpdateRequest request)
    {
        try
        {
            var barcode = _barcodeService.GetBarcodeByBarcodeId(request.BarcodeId);
            if (barcode == null)
            {
                return NotFound(new { Message = $"Questo barcode: '{request.BarcodeId}' non è stato trovato." });
            }

            _barcodeService.UpdateBarcode(request.BarcodeId, request.NewQuantity);
            return Ok(new
                { Message = $"La quantità per questo Barcode: '{request.BarcodeId}' è stata aggiornata con successo." });
        }
        catch (InvalidOperationException ex)
        {
            //altri tipi di errori
            return BadRequest(new { Error = ex.Message });
        }
        catch (QtaInvalida ex)
        {
            // Gestisci altre eccezioni non previste con un messaggio generico
            return BadRequest(new { message = ex.Message });
        }
    }
    [HttpPost]
    public IActionResult AddBarcode([FromBody] BarcodeDTO request)
    {
        try
        {
            _barcodeService.AddBarcode(request);
            return CreatedAtAction(nameof(GetBarcodeByBarcodeId), new { barcodeId = request.BarcodeId }, request);
        }
        catch (ProdottoGiaPresente ex)
        {
            // Restituisci un errore user-friendly con un codice di stato HTTP 400 Bad Request
            return BadRequest(new { message = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            // Gestisci altre eccezioni non previste con un messaggio generico
            return StatusCode(500, new { message = "Si è verificato un errore imprevisto, riprova più tardi." });
        }
        catch (QtaInvalida ex)
        {
            // Gestisci altre eccezioni non previste con un messaggio generico
            return BadRequest(new { message = ex.Message });
        }
    }
    [HttpGet("count")]
    public async Task<IActionResult> GetElementCount()
    {
        int count = await _barcodeService.GetContototale();
        return Ok(count);
    }
    [HttpGet("all")]
    public async Task<IActionResult> GetAllProdotti()
    {
        var prodotti = await _barcodeService.GetAllProdottiAsync();
        return Ok(prodotti);
    }

    [HttpGet("max-quantity")]
    public async Task<IActionResult> GetProdottoWithMaxQuantity()
    {
        var prodotto = await _barcodeService.GetProdottoWithMaxQuantityAsync();
        return Ok(prodotto);
    }

    [HttpGet("min-quantity")]
    public async Task<IActionResult> GetProdottoWithMinQuantity()
    {
        var prodotto = await _barcodeService.GetProdottoWithMinQuantityAsync();
        return Ok(prodotto);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        await _barcodeService.DeleteProductAsync(id);
        return NoContent(); // Restituisce 204 No Content
    }
}