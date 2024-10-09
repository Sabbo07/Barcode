using Microsoft.AspNetCore.Mvc;
using Barcode.Service;
using Barcode.Entities.Request;
using Barcode.Entities.DTO;
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
        catch (Exception ex)
        {
            // Eccezione in caso di altri tipi di errori
            return StatusCode(500, new { Error = "Ops, c'è stato un errore! Riprova ." });
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
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
       /* catch (Exception)
        {
            return StatusCode(500, "Errore Non previsto!");
        }
        */
    }
    
}