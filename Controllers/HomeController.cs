using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Handlers;
using System.Threading.Tasks;
//using blender.App_Variables;

namespace blender.Controllers
{
    public class HomeController : Controller
    {
        public void toggleSystem()
        {
            Console.WriteLine("toggleSystem()");
        }
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult OnPost()
        {
            toggleSystem();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}