using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using blender.AppVariables;

namespace blender.Controllers
{
    public class AppVariablesController : Controller
    {
        public static string system { get; set; }

        // GET: AppVariables
        public ActionResult toggleSystem(string syst, string callingPage)
        {
            system = syst;
            return Redirect(callingPage);
        }
    }
}