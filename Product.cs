namespace TestTaskCHI
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product()
        {
            Name = String.Empty;
            Price = Decimal.Zero;
        }
        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}
