
//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace eCommservices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AccountManagement" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AccountManagement.svc or AccountManagement.svc.cs at the Solution Explorer and start debugging.
    public class AccountManagement : IAccountManagement
    {
        static string SqlConnectionString = ConfigurationManager.ConnectionStrings["EcomDB"].ConnectionString;
        public void DoWork()
        {
        }
        public string GetProductList()
        {
            SqlConnection sqlConnection1 = new SqlConnection(SqlConnectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            DataTable dt = new DataTable();
            string productListJson = String.Empty;
            cmd.CommandText = "getDevicesInfo";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = sqlConnection1;
            cmd.Parameters.Add(new SqlParameter("@DataRequiredType", 1));
            cmd.Parameters.Add(new SqlParameter("@DeviceType", 3));
            sqlConnection1.Open();
            try
            {
                dt.Load(cmd.ExecuteReader());
                sqlConnection1.Close();
                productListJson = ConvertDataTableTojSonString(dt);
            }
            catch (Exception)
            {
                throw;
            }

            return productListJson;
        }

        public string GetProductDetails(string productID)
        {
            SqlConnection sqlConnection1 = new SqlConnection(SqlConnectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            DataTable dt = new DataTable();
            string productDetails = String.Empty;
            cmd.CommandText = "getDeviceSpecificInfo";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = sqlConnection1;
            cmd.Parameters.Add(new SqlParameter("@ProductId", productID));
            sqlConnection1.Open();
            try
            {
                dt.Load(cmd.ExecuteReader());
                sqlConnection1.Close();
                productDetails = ConvertDataTableTojSonString(dt);
            }
            catch (Exception)
            {
                throw;
            }

            return productDetails;
        }

        public string GetProductForACategory(string productTypeID)
        {
            int productTypeIDInt;
            int.TryParse(productTypeID, out productTypeIDInt);
            SqlConnection sqlConnection1 = new SqlConnection(SqlConnectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            DataTable dt = new DataTable();
            string sameProductTypeJson = String.Empty;
            cmd.CommandText = "getAllCategoryDevices";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = sqlConnection1;
            cmd.Parameters.Add(new SqlParameter("@DeviceCategoryType", productTypeIDInt));
            //cmd.Parameters.Add(new SqlParameter("@RequestedDeviceStartIndex", 0));
            //cmd.Parameters.Add(new SqlParameter("@RequestedDeviceEndIndex", 20));
            sqlConnection1.Open();
            try
            {
                dt.Load(cmd.ExecuteReader());
              
                sameProductTypeJson = ConvertDataTableTojSonString(dt);
                sqlConnection1.Close();
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                throw;
            }

            return sameProductTypeJson;        
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
        public String ConvertDataTableTojSonString(DataTable dataTable)
        {
            System.Web.Script.Serialization.JavaScriptSerializer serializer =
                   new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<String, Object>> tableRows = new List<Dictionary<String, Object>>();
            Dictionary<String, Object> row;
            foreach (DataRow dr in dataTable.Rows)
            {
                row = new Dictionary<String, Object>();
                foreach (DataColumn col in dataTable.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                tableRows.Add(row);
            }
            return serializer.Serialize(tableRows);
        }



        private string GetProductCost(string productID)
        {
            string ProductCost = String.Empty;
            //using (var cmd = DbConn.GetStoredProcCommand("stroredProcName"))
            //{

            //    try
            //    {
            //        DbConn.AddInParameter(cmd, "@nameofthecolumn", SqlDbType.NVarChar, productID);
            //        using (var objDataReader = DbConn.ExecuteReader(cmd))
            //        {
            //            while (objDataReader.Read())
            //            {
            //                var obj = new Product();
            //                ProductCost = objDataReader["productID"].ToString();
            //                // objProductList.lstProduct.Add(obj);

            //            }
            //        }
            //    }
            //    catch (Exception ex)
            //    {

            //    }
            //}
            return ProductCost;

        }
    }
}
