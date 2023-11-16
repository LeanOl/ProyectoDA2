using Domain;

namespace IPromotionProject;

public class ProductDto
{
    public string Category { get; set; }
    public decimal Price { get; set; }
    public string Brand { get; set; }
    public string Description { get; set; }
    public IEnumerable<string> Colors { get; set; }

    public ProductDto(Product product)
    {
        Category = product.Category;
        Price = product.Price;
        Brand = product.Brand;
        Description = product.Description;
        Colors = GetColors(product);
    }

    public ProductDto()
    {
    }
    private IEnumerable<string> GetColors(Product product)
    {
        var colors = product.Colors;
        if (colors == null || colors.Count == 0)
        {
            return new List<string>();
        }
        return product.Colors.Select(c => c.Color);
    }
}