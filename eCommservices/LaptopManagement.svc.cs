using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace eCommservices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LaptopManagement" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select LaptopManagement.svc or LaptopManagement.svc.cs at the Solution Explorer and start debugging.
    public class LaptopManagement : BaseDataAccess,ILaptopManagement
    {
        public void DoWork()
        {
        }
        public Product GetProductDetails(string productID)
        {
            using (var cmd = DbConn.GetStoredProcCommand("stroredProcName"))
            {
                var obj = new Product();                          
                try
                {
                    DbConn.AddInParameter(cmd, "@nameofthecolumn", SqlDbType.NVarChar, productID);
                    using (var objDataReader = DbConn.ExecuteReader(cmd))
                    {
                        while (objDataReader.Read())
                        {
                            //filling product
          
                        }
                    }
                }
                catch (Exception ex)
                {

                }
                return obj;
            }
        }

        public ProductList GetProductForACategory(string productTypeID)
        {
            var objProductList = new ProductList();
            using (var cmd = DbConn.GetStoredProcCommand("stroredProcName"))
            {
                 
                try
                {
                    DbConn.AddInParameter(cmd, "@nameofthecolumn", SqlDbType.NVarChar, productTypeID);
                    using (var objDataReader = DbConn.ExecuteReader(cmd))
                    {
                        while (objDataReader.Read())
                        {
                            var obj = new Product();
                            //filling product
                            objProductList.lstProduct.Add(obj);

                        }
                    }
                }
                catch (Exception ex)
                {

                }
                }
            return objProductList;
            
        }

    }
}
