using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.AccountManagementClient proxy = new ServiceReference1.AccountManagementClient("BasicHttpBinding_IAccountManagement");
            var obj = proxy.GetProductList();
            var obj2 = proxy.GetProductForACategory("3");
            var obj3 = proxy.GetProductDetails("062C7EF0-4D59-E511-95BC-F01FAF30E486");

            //ServiceReference2.Service1Client proxy2 = new ServiceReference2.Service1Client();
            //string s=proxy2.GetData(6);
            //var obj = proxy2.GetProductList1();
            Console.Read();
        }
    }
}
