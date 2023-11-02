using APIModels.InputModels;
using IData;
using Domain;
using ILogic;
using IPromotionProject;
using Microsoft.IdentityModel.Tokens;

namespace Logic
{

    public class ShoppingCartLogic : IShoppingCartLogic
    {
        private readonly IPromotionLogic _promotionLogic;
        private readonly IShoppingCartManagement _shoppingCartManagement;
        private readonly IShoppingCartProductsManagement _shoppingCartProductsManagement;

        
        public ShoppingCartLogic(IPromotionLogic logic,IShoppingCartManagement shoppingCartManagement)
        {
            _promotionLogic = logic;
            _shoppingCartManagement = shoppingCartManagement;
            _shoppingCartProductsManagement = shoppingCartProductsManagement;
        }

        public void ApplyBestPromotion(ShoppingCart shoppingCart)
        {
            IEnumerable<IPromotion> promotions = GetPromotions();
            FindBestPromotion(shoppingCart, promotions);
        }

        private void FindBestPromotion(ShoppingCart shoppingCart, IEnumerable<IPromotion> promotions)
        {
            IPromotion bestPromotion = null;
            decimal bestDiscount = 0;
            List<ProductDto> productsDto = ConvertToProductsDto(shoppingCart).ToList();
            foreach (var promotion in promotions)
            {
                decimal discount = promotion.GetDiscount(productsDto);
                if (discount > bestDiscount)
                {
                    bestDiscount = discount;
                    bestPromotion = promotion;
                }
            }

            if (bestPromotion != null)
            {
                shoppingCart.PromotionName = bestPromotion.Name;
                shoppingCart.Discount = bestDiscount;
            }
        }

        private static IEnumerable<ProductDto> ConvertToProductsDto(ShoppingCart shoppingCart)
        {
            IEnumerable<Product> products = shoppingCart.GetProducts();
            IEnumerable<ProductDto> productsDto = products.Select(p => new ProductDto(p));
            return productsDto;
        }

        public IEnumerable<IPromotion> GetPromotions()
        {
            return _promotionLogic.GetPromotions();
        }

        public ShoppingCart UpdateShoppingCart(ShoppingCart received)
        {
            ApplyBestPromotion(received);
            received.UpdatePrices();
            ShoppingCart shoppingCart = _shoppingCartManagement.UpdateShoppingCart(received);
            return;
        }
    }
}