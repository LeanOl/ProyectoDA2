using APIModels.InputModels;
using APIModels.OutputModels;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [Route("api/promotions")]
    [ExceptionFilter]
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
        [HttpDelete("{id}")]
        public IActionResult DeletePromotion([FromRoute]Guid id)
        {
            _promotionLogic.DeletePromotion(id);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdatePromotion([FromRoute]Guid id, [FromBody]PromotionRequest received)
        {
            var promotion = received.ToEntity();
            var updatedPromotion=_promotionLogic.UpdatePromotion(id, promotion);
            var result = new PromotionResponse(updatedPromotion);
            return Ok(result);
        }
    }
}
