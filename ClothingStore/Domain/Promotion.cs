namespace Domain;
public class Promotion
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public PromotionProductCondition ProductCondition { get; set; }

    public void SelfValidate()
    {
        ProductCondition.SelfValidate();
    }
}