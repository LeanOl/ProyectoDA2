namespace Domain
{
    public class FreeProductPromotion : Promotion
    {
        public int FreeProductCount { get; set; }

        public override decimal GetDiscount(ShoppingCart cart)
        {
            bool isConditionApplicable = true;
            decimal discount = 0;
            foreach (var condition in PromotionConditions)
            {
                isConditionApplicable= isConditionApplicable && condition.VerifyCartCondition(cart);

            }

            if (isConditionApplicable)
            {
                IEnumerable<Product> products = cart.GetProducts();
                var lessValueableProducts = GetLessValueableProducts(products);
                foreach (var product in lessValueableProducts)
                {
                    discount+= product.Price;
                }
            }

            return discount;
        }

        private IEnumerable<Product> GetLessValueableProducts(IEnumerable<Product> products)
        {
            return products
                .OrderBy(x => x.Price)
                .Take(FreeProductCount);
        }
    }
}