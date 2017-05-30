using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using AdventureWorksEntityModel;

namespace AdventureWorks
{
    public class AdventureWorksServiceImpl : IAdventureWorksService
    {
        public List<string> ListProducts()
        {
            // Create a list for holding product numbers
            List<string> productsList = new List<string>();
            try
            {
                // Connect to the AdventureWorks database by using the Entity Framework
                using (AdventureWorksModel database = new AdventureWorksModel())
                {
                    // Fetch the product number of every product in the database
                    var products = from product in database.Products
                                   select product.ProductNumber;
                    productsList = products.ToList();
                }
            }
            catch
            {
                // Ignore exceptions in this implementation
            }
            // Return the list of product numbers
            return productsList;
        }
        public ProductData GetProduct(string productNumber)
        {
            // Create a reference to a ProductData object
            // This object will be instantiated if a matching product is found
            ProductData productData = null;
            try
            {
                // Connect to the AdventureWorks database by using the Entity Framework
                using (AdventureWorksModel database = new AdventureWorksModel())
                {
                    // Find the first product that matches the specified product number
                    Product matchingProduct = database.Products.First(
                    p => String.Compare(p.ProductNumber, productNumber) == 0);
                    productData = new ProductData()
                    {
                        Name = matchingProduct.Name,
                        ProductNumber = matchingProduct.ProductNumber,
                        Color = matchingProduct.Color,
                        ListPrice = matchingProduct.ListPrice
                    };
                }
            }
            catch
            {
                // Ignore exceptions in this implementation
            }
            // Return the product
            return productData;
        }
    }
}