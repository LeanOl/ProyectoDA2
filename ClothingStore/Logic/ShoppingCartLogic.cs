using IData;
using Domain;
using ILogic;
using IPromotionProject;
using Microsoft.IdentityModel.Tokens;

namespace Logic
{

    public class ShoppingCartLogic : IShoppingCartLogic
    {
        private IPromotionLogic _promotionLogic;
        
        public ShoppingCartLogic(IPromotionLogic logic)
        {
            _promotionLogic = logic;
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

    }
}