using IData;
using Domain;
using ILogic;

namespace Logic
{

    public class ShoppingCartLogic : IShoppingCartLogic
    {
        private readonly IGenericRepository<Promotion> _promotionRepo;
        public ShoppingCartLogic(IGenericRepository<Promotion> promotionRepo)
        {
            _promotionRepo = promotionRepo;
        }

        public void ApplyBestPromotion(ShoppingCart shoppingCart)
        {
            List<Promotion> promotions = _promotionRepo.GetAll<Promotion>().ToList();
            var bestPromotion = FindBestPromotion(shoppingCart, promotions);
            shoppingCart.AppliedPromotion = bestPromotion;
        }

        private Promotion? FindBestPromotion(ShoppingCart shoppingCart, List<Promotion> promotions)
        {
            Promotion bestPromotion = null;
            decimal bestDiscount = 0;
            foreach (var promotion in promotions)
            {
                decimal discount = promotion.GetDiscount(shoppingCart);
                if (discount > bestDiscount)
                {
                    bestDiscount = discount;
                    bestPromotion = promotion;
                }
            }

            return bestPromotion;
        }
    }
}