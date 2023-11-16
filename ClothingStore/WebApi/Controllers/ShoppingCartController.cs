using APIModels.InputModels;
using APIModels.OutputModels;
using ILogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/carts")]
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
        [HttpDelete]
        public IActionResult DeleteCartProduct([FromBody]DeleteShoppingCartProductRequest received)
        {
            var result= _shoppingCartLogic.DeleteProduct(received.Cart.ToEntity(), received.ProductId);
            ShoppingCartResponse shoppingCartResponse = new ShoppingCartResponse(result);
            return Ok(shoppingCartResponse);
        }
        [HttpGet("{userId}")]
        public IActionResult GetCartByUserId([FromRoute]Guid userId)
        {
            var result = _shoppingCartLogic.GetShoppingCartByUserId(userId);
            ShoppingCartResponse shoppingCartResponse = new ShoppingCartResponse(result);
            return Ok(shoppingCartResponse);
        }
    }

}
