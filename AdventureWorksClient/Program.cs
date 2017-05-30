using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AdventureWorksClient.AdventureWorksService;

namespace AdventureWorksClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a proxy object and connect to the service
            AdventureWorksService.AdventureWorksServiceClient proxy = new AdventureWorksService.AdventureWorksServiceClient();

            // Obtain a list of all products
            Console.WriteLine("Test 1: List all products");
            string[] productNumbers = proxy.ListProducts();
            foreach (string productNumber in productNumbers)
            {
                Console.WriteLine("Number: {0}", productNumber);
            }
            Console.WriteLine();

            Console.WriteLine("Test 2: Display the details of a product");
            ProductData product = proxy.GetProduct("AR-5381");
            Console.WriteLine("Number: {0}", product.ProductNumber);
            Console.WriteLine("Name: {0}", product.Name);
            Console.WriteLine("Color: {0}", product.Color);
            Console.WriteLine("Price: {0}", product.ListPrice);
            Console.WriteLine();

            // Disconnect from the service
            proxy.Close();
            Console.WriteLine("Press ENTER to finish");
            Console.ReadLine();
        }
    }
}