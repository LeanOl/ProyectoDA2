
namespace IPromotionProject
{
    public interface IPromotion
    {
        public string Name { get; set; }
        decimal GetDiscount(IEnumerable<ProductDto> cart);
    }
}