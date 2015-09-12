using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace eCommservices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAccountManagement" in both code and config file together.
    [ServiceContract]
    public interface IAccountManagement
    {
        [OperationContract]
        void DoWork();
        [OperationContract]
        ProductList GetProductList();
        //[OperationContract]
        //string GetPurchaseList(IList<PurchaseItem> purchaseLst);

    }

    [DataContract]
    public class ProductList
    {
        [DataMember]
        public List<Product> lstProduct { get; set; }
    }
    [DataContract] 
    public class Product
    {
    public string productID {get;set;}
    public string productTypeID {get;set;}
    public string productCate {get;set;}
    public string productName {get;set;}
    public string productDesc {get;set;}
    public string productPrice {get;set;}
    public string productReviewID {get;set;}
    public string iconPathSmall{get;set;}
    public string iconPathLarge{get;set;}
    }
    [DataContract]
    public class PurchaseItem
    {
        public string productID { get; set; }
        public string productQuantity { get; set; }
    }

}
