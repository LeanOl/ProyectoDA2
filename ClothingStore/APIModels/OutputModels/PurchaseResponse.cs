using Domain;

namespace APIModels.OutputModels;

public class PurchaseResponse
{
    public Guid PurchaseId { get; set; }
    public Guid UserId { get; set; }
    public List<PurchaseProductResponse> Products { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal TotalDiscount { get; set; }
    public decimal FinalPrice { get; set; }
    public DateTime Date { get; set; }
   

    public PurchaseResponse(Purchase purchase)
    {
        PurchaseId = purchase.Id;
        UserId = purchase.UserId;
        Products = purchase.Products.Select(p => new PurchaseProductResponse(p)).ToList();
        TotalPrice = purchase.TotalPrice;
        TotalDiscount = purchase.Discount;
        FinalPrice = purchase.FinalPrice;
        Date = purchase.Date;
    }
}