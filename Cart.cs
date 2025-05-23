namespace TestTaskCHI
{
    public class Cart
    {
        private Dictionary<Product, int> products = new Dictionary<Product, int>();

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

        public decimal GetTotalAmount()
        {
            decimal total = 0;
            foreach (var item in products)
            {
                total += item.Key.Price * item.Value;
            }
            return total;
        }
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
