namespace model
{
    public interface IDiscount
    {
        string Name {get; set;}
    }

    public class Discount : IDiscount
    {
        public string Name { get; set; }
    }
}