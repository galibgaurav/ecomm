using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace eCommservices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILaptopManagement" in both code and config file together.
    [ServiceContract]
    public interface ILaptopManagement
    {
        [OperationContract]
        void DoWork();
        //[OperationContract]
        //Product GetProductDetails(string ProductID);
        //[OperationContract]
        //ProductList GetProductForACategory(string productTypeID);
    }
}
