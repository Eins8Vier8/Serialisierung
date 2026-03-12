namespace _02___Produktinfo
{
    public class Produkt
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}