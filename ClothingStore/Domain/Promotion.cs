namespace Domain;
public class Promotion
{
    public string Name { get; set; }
    public string CartCondition { get; set; }
    public decimal Discount { get; set; }

    public Promotion(string name, string cartCondition, decimal discount)
    {
        Name = name;
        CartCondition = cartCondition;
        Discount = discount;
    }
}