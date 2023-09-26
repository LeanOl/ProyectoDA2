namespace Domain;

public class PromotionProductCondition
{
    public PromotionCondition? Category { get; set; }
    public PromotionCondition? Brand { get; set; }
    public PromotionCondition? Color { get; set; }

    public void SelfValidate()
    {
       Category.SelfValidate();
    }
}