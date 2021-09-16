using OrphanageMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace OrphanageMVC.Controllers
{
    public class CardController : Controller
    {
        //[Authorize]
        // GET: Card
        public ActionResult Index()
        {
            IEnumerable<OrphanageRegistrationView> all = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:64581/api/HelpingHand");
            var consumeapi = hc.GetAsync("HelpingHand");
            consumeapi.Wait();
            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<IList<OrphanageRegistrationView>>();

                displaydata.Wait();

                all = displaydata.Result;
            }
            else
            {
                all = Enumerable.Empty<OrphanageRegistrationView>();
                ModelState.AddModelError(string.Empty, "Server Error Occured!");
            }


            return View(all);
            
        }
        //public ActionResult Donor()
        //{
        //    return View();

        //}
        // [HttpPost]
        public ActionResult Donor(int id)
        {
            TempData["message"] = id;
            IEnumerable<reqTable> all = null;
            //reqTable req = new reqTable();
            //req.oId = id;

            HttpClient hc = new HttpClient();
            string id1 = id.ToString();
            string MainURI = "http://localhost:64581/api/helpinghand/Requirement";
            hc.BaseAddress = new Uri(MainURI);
            var consumeapi = hc.GetAsync("?id="+id1);
            consumeapi.Wait();
            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<IList<reqTable>>();

                displaydata.Wait();

                all = displaydata.Result;
            }
            else
            {
                all = Enumerable.Empty<reqTable>();
                ModelState.AddModelError(string.Empty, "Server Error Occured!");
            }


            return View(all);
            //return View();

        }

        public ActionResult Dummy(int id, TransactionTable tt)
        {

            if (tt.Amount == 0)
            {
                return View("Pay");
            }
            else
            {
                HttpClient hc = new HttpClient();
                tt.oId = id;
                hc.BaseAddress = new Uri("http://localhost:64581/api/Pay");
                var consumeapi = hc.PostAsJsonAsync("Pay", tt);

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