using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace eCommservices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
        //public ProductList GetProductList1()
        //{
        //    var objProductList = new ProductList();
        //    using (var cmd = DbConn.GetStoredProcCommand("getDeviceInfo"))
        //    {
        //        try
        //        {
        //            DbConn.AddInParameter(cmd, "@DataRequiredType", SqlDbType.Int, 1);
        //            DbConn.AddInParameter(cmd, "@DeviceType", SqlDbType.Int, 1);
        //            using (var objDataReader = DbConn.ExecuteReader(cmd))
        //            {
        //                while (objDataReader.Read())
        //                {
        //                    var obj = new Product();
        //                    //filling product
        //                    objProductList.lstProduct.Add(obj);

        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {

        //        }
        //        return objProductList;
        //    }
        //}
      
    }
}
