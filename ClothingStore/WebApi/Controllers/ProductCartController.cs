using ILogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/productCart")]
    public class ProductCartController : ControllerBase
    {
        private readonly IShoppingCartLogic _shoppingCartLogic;
        public ProductCartController(IShoppingCartLogic shoppingCartLogic)
        {
            _shoppingCartLogic = shoppingCartLogic;
        }

    }

}
