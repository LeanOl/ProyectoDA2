using APIModels.InputModels;
using APIModels.OutputModels;
using Logic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/promotions")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private readonly IPromotionLogic _promotionLogic;
        public PromotionController(IPromotionLogic logic)
        {
            _promotionLogic = logic;
        }

        [HttpPost]
        public IActionResult CreatePromotion([FromBody] PromotionRequest received)
        {
            var promotion = received.ToEntity();
            var createdPromotion = _promotionLogic.CreatePromotion(promotion);
            var result = new PromotionResponse(createdPromotion);

            return CreatedAtAction(nameof(CreatePromotion), new {id = result.Id},result);
        }
        [HttpGet]
        public IActionResult GetAllPromotions()
        {
            var promotions = _promotionLogic.GetAllPromotions();
            var result =  promotions.Select(p => new PromotionResponse(p)).ToList();
            return Ok(result);
        }
    }
}
