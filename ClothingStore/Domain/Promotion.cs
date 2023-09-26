namespace Domain;
public class Promotion
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public PromotionCondition Condition { get; set; }
}