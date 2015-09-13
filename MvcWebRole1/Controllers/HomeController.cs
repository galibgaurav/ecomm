using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eCommservicesClient;
namespace MvcWebRole1.Controllers
{
    public class HomeController : Controller
    {
       
        
        public ActionResult Index()
        {
            //EcommServiceClient obj=new EcommServiceClient();
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            return View();
        }
        public string LaptopInfo()
        {
            EcommServiceClient obj = new EcommServiceClient();
            string str = obj.GetSpecificCategory("1");
            return str;
        }
        public string TableInfo()
        {
            EcommServiceClient obj = new EcommServiceClient();
            string str = obj.GetSpecificCategory("2");
            return str;
        }
        public string MobileInfo()
        {
            EcommServiceClient obj = new EcommServiceClient();
            string str = obj.GetSpecificCategory("3");
            return str;
        }
        public string MounseInfo()
        {
            EcommServiceClient obj = new EcommServiceClient();
            string str = obj.GetSpecificCategory("4");
            return str;
        }
        public string CameraInfo()
        {
            EcommServiceClient obj = new EcommServiceClient();
            string str = obj.GetSpecificCategory("5");
            return str;
        }
        

        public string ProductSummary()
        {
         EcommServiceClient obj = new EcommServiceClient();
         string str=obj.GetProducts();
         return str;   
        }
        public string SpecificProductDetails(string productID)
        {
            EcommServiceClient obj = new EcommServiceClient();
            string str = obj.GetSpecificProduct(productID);
            return str;
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
