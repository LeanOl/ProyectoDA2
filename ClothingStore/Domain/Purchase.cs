namespace Domain;

public class Purchase
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public List<PurchaseProduct> Products { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal Discount { get; set; }
    public decimal FinalPrice { get; set; }
    public string PromotionName { get; set; }
    public string PaymentMethod { get; set; }
    public DateTime Date { get; set; }

}