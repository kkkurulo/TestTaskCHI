using System.Text.RegularExpressions;

namespace TestTaskCHI
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>
                {
                    new Product { Name = "Bread", Price = 30m },
                    new Product { Name = "Butter", Price = 60m },
                    new Product { Name = "Mix Of Salad", Price = 56m },
                    new Product { Name = "Milk", Price = 29m },
                    new Product { Name = "Eggs", Price = 40m }
                };
            Cart cart = new Cart();
            PrintProducts(products);
            AddProductToCart(cart, products);
            cart.PrintCart();
            decimal totalCost = cart.GetTotalAmount();

            if (totalCost == 0)
            {
                Console.WriteLine("\nYou didn't add any products to the cart.");
                return;
            }

            Console.Write($"\n\nYour total amount is {totalCost}. Enter your balance: ");
            decimal userBalance = InputBalance();
            CheckBalance(userBalance, totalCost);
        }
        public static decimal InputBalance()
        {
            decimal balance = 0;
            string input = Console.ReadLine() ?? String.Empty;
            while (!decimal.TryParse(input, out balance) || balance < 0)
            {
                Console.Write("Invalid input. Enter again: ");
                input = Console.ReadLine() ?? String.Empty;
            }
            return balance;
        }
        public static void CheckBalance(decimal balance, decimal totalCost)
        {
            if (balance >= totalCost)
            {
                Console.WriteLine($"Success. Your change is {balance - totalCost}.");
            }
            else
            {
                Console.WriteLine($"Failure. You need {totalCost - balance} more.");
            }
        }
        public static void PrintProducts(List<Product> products)
        {
            Console.WriteLine("Available products:");
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Name} - {product.Price}");
            }
        }
        public static void AddProductToCart(Cart cart, List<Product> products)
        {
            string input = String.Empty;
            Console.WriteLine("\n\nPrint word \"CLOSE\" in any register to close adding.");
            while (input.ToLower() != "close")
            {
                Console.Write("Input name of what you want to buy in any register: ");
                input = Console.ReadLine() ?? String.Empty;
                if (!IsLettersOnly(input) && input.ToLower() != "close")
                {
                    Console.WriteLine("Input must contain only letters. Please try again.\n");
                    continue;
                }

                var product = products.FirstOrDefault(p => p.Name.ToLower() == input.ToLower());
                if (product != default)
                {
                    cart.AddProduct(product);
                    Console.WriteLine("Product successfully added to cart!\n");
                }
                else if(input.ToLower() != "close")
                {
                    Console.WriteLine("Product not found. Please try again.\n");
                }
            }
        }

        public static bool IsLettersOnly(string input)
        {
            return Regex.IsMatch(input, @"^[a-zA-Z\s]+$");
        }
    }
}
