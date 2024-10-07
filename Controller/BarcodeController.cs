using Microsoft.AspNetCore.Mvc;
using Barcode.Service;
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
            return NotFound();
        }
        return Ok(barcod);
    }

}