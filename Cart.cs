namespace TestTaskCHI
{
    // Represents a shopping cart containing products and their quantities
    public class Cart
    {
        // Dictionary to store products and amounts
        private Dictionary<Product, int> products = new Dictionary<Product, int>();

        /** 
         * Add a product to the cart. Increments amount if already exist entry in the cart.
         * @param product - The product to add to the cart; 
         * @result - void
         */
        public void AddProduct(Product product)
        {
            if (products.ContainsKey(product))
            {
                products[product]++;
            }
            else
            {
                products[product] = 1;
            }
        }


        /** 
         * Calculates and returns the total price for all products in the cart.
         *  @result - decimal - The total price of all products in the cart.
         */
        public decimal GetTotalAmount()
        {
            decimal total = 0;
            foreach (var item in products)
            {
                total += item.Key.Price * item.Value; // Calculate total for each product by multiplying price by their amount
            }
            return total;
        }

        /**
         * Prints the cart contents to the console, including product names, pcs, and total amount.
         * @result - void
         */
        public void PrintCart()
        {
            Console.WriteLine("Your cart:");
            foreach (var item in products)
            {
                Console.WriteLine($"{item.Key.Name} - {item.Value} pcs");
            }
            Console.WriteLine($"Total amount: {GetTotalAmount()}");
        }
    }
}
