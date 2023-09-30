namespace Domain;

public abstract class PromotionCondition
{
    public Guid Id { get; set; }
    public string ProductPropertyCondition { get; set; }
    public string QuantityCondition { get; set; }
    public abstract void SelfValidate();
    public abstract bool VerifyCartCondition(ShoppingCart cart);
}