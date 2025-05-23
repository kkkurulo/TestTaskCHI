namespace TestTaskCHI
{
    /**
     * Represents a product with a name and price.
     */
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        /**
         * Default constructor initializes the product with default values.
         */
        public Product()
        {
            Name = String.Empty;
            Price = Decimal.Zero;
        }
        /**
         * Parameterized constructor initializes the product with specified name and price.
         * @param name - The name of the product;
         * @param price - The price of the product;
         */
        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}
