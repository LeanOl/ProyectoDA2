using APIModels.InputModels;
using APIModels.OutputModels;
using ILogic;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class PurchaseController : ControllerBase
    {
        IPurchaseLogic _purchaseLogic;

        public PurchaseController(IPurchaseLogic purchaseLogic)
        {
            _purchaseLogic = purchaseLogic;
        }
        [HttpPost]
        public IActionResult CreatePurchase([FromBody] PurchaseRequest request)
        {
            var created = _purchaseLogic.CreatePurchase(request);
            PurchaseResponse response = new PurchaseResponse(created);

            return CreatedAtAction(nameof(CreatePurchase), new { id = created.Id }, response);
        }
    }
}
