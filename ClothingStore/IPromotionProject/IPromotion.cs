
namespace IPromotionProject
{
    public interface IPromotion
    {
        Guid Id { get; set; }
        string Name { get; set; }
        decimal GetDiscount(IEnumerable<ProductDto> cart);
    }
}