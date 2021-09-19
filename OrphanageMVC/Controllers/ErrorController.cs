using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrphanageMVC.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Error(string e)
        {
            ViewBag.message = e;
            return View();
        }
    }
}