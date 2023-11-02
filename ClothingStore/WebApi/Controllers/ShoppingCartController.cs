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


        public IActionResult CreateShoppingCart(ShoppingCartRequest received)
        {
            var createdShoppingCart = _shoppingCartLogic.CreateShoppingCart(received);
            ShoppingCartResponse shoppingCartResponse = new ShoppingCartResponse(createdShoppingCart);
            return CreatedAtAction(nameof(CreateShoppingCart), new{id = shoppingCartResponse.IdCart},shoppingCartResponse);
        }
    }

}
