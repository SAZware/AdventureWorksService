using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AdventureWorks
{
    // Data contract describing the details of a product passed to client applications
    [DataContract]
    public class ProductData
    {
        [DataMember]
        public string Name;
        [DataMember]
        public string ProductNumber;
        [DataMember]
        public string Color;
        [DataMember]
        public decimal ListPrice;
    }

    // Service contract describing the operations provided by the WCF service
    [ServiceContract]
    public interface IAdventureWorksService
    {
        // Get the product number of every product
        [OperationContract]
        List<string> ListProducts();
        // Get the details of a single product
        [OperationContract]
        ProductData GetProduct(string productNumber);
    }
}
