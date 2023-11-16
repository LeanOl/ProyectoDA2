namespace APIModels.InputModels;

public class PurchaseRequest
{
    public Guid UserId { get; set; }
    public string PaymentMethod { get; set; }
}