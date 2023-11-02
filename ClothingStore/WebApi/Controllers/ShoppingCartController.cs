using APIModels.InputModels;
using APIModels.OutputModels;
using ILogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/productCart")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartLogic _shoppingCartLogic;
        public ShoppingCartController(IShoppingCartLogic shoppingCartLogic)
        {
            _shoppingCartLogic = shoppingCartLogic;
        }

        [HttpPut]
        public IActionResult UpdateShoppingCart([FromBody]ShoppingCartRequest received)
        {
            var createdShoppingCart = _shoppingCartLogic.UpdateShoppingCart(received.ToEntity());
            ShoppingCartResponse shoppingCartResponse = new ShoppingCartResponse(createdShoppingCart);
            return Ok(shoppingCartResponse);
        }
    }

}
