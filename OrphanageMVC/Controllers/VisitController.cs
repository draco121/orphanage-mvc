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
            if (ModelState.IsValid)
            {


                HttpClient hc = new HttpClient();
                sv.aId = Guid.NewGuid();
                sv.oId = id;

                sv.aCurrenntDate = DateTime.Now;
                hc.BaseAddress = new Uri("http://localhost:64581/api/Adopter");
                var consumeapi = hc.PostAsJsonAsync("Adopter", sv);
                consumeapi.Wait();
                var readdata = new HttpResponseMessage();
                try
                {
                    readdata = consumeapi.Result;
                }
                catch (Exception e)
                {
                    return RedirectToAction("Error", "Error", new { p = e });
                }

                if (readdata.IsSuccessStatusCode)
                {

                    TempData["message"] = "Visit Schedules Succesfully";
                    //return RedirectToAction("Index", "Home");
                    return View("Success");
                }
                else
                {
                    string error = readdata.Content.ReadAsStringAsync().Result;
                    return RedirectToAction("Error", "Error", new { p = error });
                }
                
            }
            else
            {
                return View("Adopter");
            }
        }
    }
}