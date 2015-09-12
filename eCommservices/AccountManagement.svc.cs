using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace eCommservices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AccountManagement" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AccountManagement.svc or AccountManagement.svc.cs at the Solution Explorer and start debugging.
    public class AccountManagement : BaseDataAccess,IAccountManagement
    {

        public void DoWork()
        {
        }
        public ProductList GetProductList()
        {
            var objProductList = new ProductList();
            using(var cmd=DbConn.GetStoredProcCommand("getDeviceInfo"))
            {
                try
                {
                    DbConn.AddInParameter(cmd, "@DataRequiredType", SqlDbType.Int, 1);
                    DbConn.AddInParameter(cmd, "@DeviceType", SqlDbType.Int, 1);
                    using (var objDataReader=DbConn.ExecuteReader(cmd))
                    {
                        while (objDataReader.Read())
                        {
                            var obj = new Product();
                            //filling product
                            objProductList.lstProduct.Add(obj);

                        }
                    }
                }
                catch(Exception ex)
                {
                
                }
                return objProductList;
            }
        }
        public string GetPurchaseList(IList<PurchaseItem> purchaseLst)
        {
            int totalAmount = 0;
            int productCost = 0;
            int Quantity = 0;
            foreach (var item in purchaseLst)
            {
                int.TryParse(GetProductCost(item.productID), out productCost);
                int.TryParse(item.productQuantity, out Quantity);
                totalAmount = totalAmount + productCost * Quantity;
                //productCost = 0;
            }
            return totalAmount.ToString();

        }

        private string GetProductCost(string productID)
        {
            string ProductCost = String.Empty;
            using (var cmd = DbConn.GetStoredProcCommand("stroredProcName"))
            {

                try
                {
                    DbConn.AddInParameter(cmd, "@nameofthecolumn", SqlDbType.NVarChar, productID);
                    using (var objDataReader = DbConn.ExecuteReader(cmd))
                    {
                        while (objDataReader.Read())
                        {
                            var obj = new Product();
                            ProductCost = objDataReader["productID"].ToString();
                            // objProductList.lstProduct.Add(obj);

                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return ProductCost;

        }
    }
}
