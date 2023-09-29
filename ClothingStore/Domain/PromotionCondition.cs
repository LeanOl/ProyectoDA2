namespace Domain;

public abstract class PromotionCondition
{
    public string ProductPropertyCondition { get; set; }
    public string QuantityCondition { get; set; }
    public abstract void SelfValidate();
}