using OrphanageMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace OrphanageMVC.Controllers
{
    public class VisitController : Controller
    {
        // GET: Visit
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Adopter(int id, OrphanageVisit sv)
        {
            if (sv.aName == null)
            {
                return View("Adopter");
            }
            else
            {

                HttpClient hc = new HttpClient();
                sv.aId= Guid.NewGuid();
                sv.oId = id;

                sv.aCurrenntDate = DateTime.Now;
                hc.BaseAddress = new Uri("http://localhost:64581/api/Adopter");
                var consumeapi = hc.PostAsJsonAsync("Adopter", sv);

                consumeapi.Wait();

                var readdata = consumeapi.Result;

                if (readdata.IsSuccessStatusCode)
                {

                    TempData["message"] = "Payment Successfull!!";
                    //return RedirectToAction("Index", "Home");
                    return View("Success");
                }
                return View("Success");
            }
        }
    }
}