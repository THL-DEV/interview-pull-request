using System;
using Interview.PullRequest.Entities;
using Interview.PullRequest.Services;
using Interview.PullRequest.Tools;

namespace Interview.PullRequest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ignore the content of the `Main` method for the review please :)
            DoSomeMath(args);
            CalculatePrice();
        }

        private static void DoSomeMath(string[] args)
        {
            int i = -1;
            try
            {
                i = Int32.Parse(args[0]);
            }
            catch { }

            int result = Fibonacci.Caclulate(i);

            Console.WriteLine("Fibonacci's {1}th term is {0}", result, i);
        }

        private static void CalculatePrice()
        {
            IProductService service = new ProductService();
            Product product = service.BuildProduct();
            decimal price = service.CalculatePrice(product);
            Console.WriteLine("This product's price is ${0}", price);
        }
    }
}
