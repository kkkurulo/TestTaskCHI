using System.Text.RegularExpressions;

namespace TestTaskCHI
{
    public class Program
    {
        static void Main(string[] args)
        {
            //  Initialize a list of products with their names and prices
            List<Product> products = new List<Product>
                {
                    new Product { Name = "Bread", Price = 30m },
                    new Product { Name = "Butter", Price = 60m },
                    new Product { Name = "Mix Of Salad", Price = 56m },
                    new Product { Name = "Milk", Price = 29m },
                    new Product { Name = "Eggs", Price = 40m }
                };

            // Cteate a new cart
            Cart cart = new Cart();

            // Print product in start-list
            PrintProducts(products);

            AddProductToCart(cart, products);
            cart.PrintCart();

            decimal totalCost = cart.GetTotalAmount();

            // Check if the cart is empty, if so, print a message and exit
            if (totalCost == 0)
            {
                Console.WriteLine("\nYou didn't add any products to the cart.");
                return;
            }
            
            Console.Write($"\n\nYour total amount is {totalCost}. Enter your balance: ");
            decimal userBalance = InputBalance();
            CheckBalance(userBalance, totalCost);
        }
        /**
         * Function to read user input for balance and validate it.
         * @result decimal - The valid balance entered by the user.
         */
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
        /**
         * Function to check if the user's balance can cover the total cost.
         * @param balance - The user's balance;
         * @param totalCost - The total cost of products in the cart;
         * @result void
         */
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
        /**
         * Function to print the available products to the console.
         * @param products - The list of products to print;
         * @result void
         */
        public static void PrintProducts(List<Product> products)
        {
            Console.WriteLine("Available products:");
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Name} - {product.Price}");
            }
        }
        /**
         * Function to add products to the cart depend on user input.
         * @param cart - The cart to which products will be added;
         * @param products - The list of available products;
         * @result void
         */
        public static void AddProductToCart(Cart cart, List<Product> products)
        {
            string input = String.Empty;
            Console.WriteLine("\n\nPrint word \"CLOSE\" in any register to close adding.");
            while (input.ToLower() != "close")
            {
                Console.Write("Input name of what you want to buy in any register: ");
                input = Console.ReadLine() ?? String.Empty;
                // Check if the input match the required format
                if (!IsLettersOnly(input) && input.ToLower() != "close")
                {
                    Console.WriteLine("Input must be only letters. Please try again.\n");
                    continue;
                }
                // Find the product in the list of products
                var product = products.FirstOrDefault(p => p.Name.ToLower() == input.ToLower());
                if (product != default)
                {
                    cart.AddProduct(product);
                    Console.WriteLine("Product successfully added to cart!\n");
                }
                else if(input.ToLower() != "close") // edge case for "CLOSE"
                {
                    Console.WriteLine("Product not found. Please try again.\n");
                }
            }
        }
        /**
         * Function to check if the input string contains only letters and spaces.
         * @param input - The input string to check;
         * @result bool - True if the input contains only letters and spaces, false otherwise.
         */
        public static bool IsLettersOnly(string input)
        {
            return Regex.IsMatch(input, @"^[a-zA-Z\s]+$");
        }
    }
}
