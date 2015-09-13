using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eCommservicesClient
{
    public class EcommServiceClient
    {
        public EcommServiceClient()
        {
          //  eCommClientProxy = new ServiceReference1.AccountManagementClient();
        }
       public string GetProducts()
        {
              ServiceReference1.AccountManagementClient eCommClientProxy=eCommClientProxy = new ServiceReference1.AccountManagementClient("BasicHttpBinding_IAccountManagement");
            eCommClientProxy.Open();
            return eCommClientProxy.GetProductList();
        }
       public string GetSpecificProduct(string productID)
       {   ServiceReference1.AccountManagementClient eCommClientProxy=eCommClientProxy = new ServiceReference1.AccountManagementClient("BasicHttpBinding_IAccountManagement");
       
           string str=eCommClientProxy.GetProductDetails(productID);
           return str;
       }

        public string GetSpecificCategory(string productTypeID)
       {   ServiceReference1.AccountManagementClient eCommClientProxy=eCommClientProxy = new ServiceReference1.AccountManagementClient("BasicHttpBinding_IAccountManagement");

       string str = eCommClientProxy.GetProductForACategory(productTypeID);
           return str;
       }

        
    }

}
