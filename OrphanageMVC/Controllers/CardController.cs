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
                HttpClient hc = new HttpClient
                {
                    BaseAddress = new Uri("http://localhost:64581/api/HelpingHand")
                };
                var consumeapi = hc.GetAsync("HelpingHand");
            var readdata = new HttpResponseMessage();
            try
            {
                consumeapi.Wait();
                readdata = consumeapi.Result;
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Error", new { p = e.Message });
            }

            if (readdata.IsSuccessStatusCode)
                {
                    var displaydata = readdata.Content.ReadAsAsync<IList<OrphanageRegistrationView>>();
                    displaydata.Wait();
                    all = displaydata.Result;
                }
                else
                {
                    if(readdata.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        all = Enumerable.Empty<OrphanageRegistrationView>();
                        ModelState.AddModelError(string.Empty, "Server Error Occured!");
                    }
                    else
                    {
                        var error = readdata.Content.ReadAsStringAsync().Result;
                        return RedirectToAction("Error", "Error", new { p = error });
                    }
                    
                }
                return View(all);
        }
        



        public ActionResult Donor(int id)
        {
            
                IEnumerable<reqTable> all = null;
                HttpClient hc = new HttpClient();
                string id1 = id.ToString();
                string MainURI = "http://localhost:64581/api/helpinghand/Requirement";
                hc.BaseAddress = new Uri(MainURI);
                var consumeapi = hc.GetAsync("?id=" + id1);
            consumeapi.Wait();
            var readdata = new HttpResponseMessage();
            try
            {
                consumeapi.Wait();
                readdata = consumeapi.Result;
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Error", new { p = e });
            }

            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<IList<reqTable>>();

                displaydata.Wait();

                all = displaydata.Result;
            }
            else
            {
                if(readdata.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    all = Enumerable.Empty<reqTable>();
                    ModelState.AddModelError(string.Empty, "Server Error Occured!");
                }
                else
                {
                    string error = readdata.Content.ReadAsStringAsync().Result;
                    return RedirectToAction("Error", "Error", new { p = error });
                }
                
            }


            return View(all);

        }

        public ActionResult Dummy(int oid,string id,TransactionTable tt)
        {
            if (tt.Amount == 0)
            {
                return View("Pay");
            }
            else
            {
                HttpClient hc = new HttpClient();
                tt.rId = id;
                tt.oId = oid;
                tt.tId = Guid.NewGuid().ToString();
                hc.BaseAddress = new Uri("http://localhost:64581/api/Pay");
                var consumeapi = hc.PostAsJsonAsync("Pay", tt);
                consumeapi.Wait();
                var readdata = new HttpResponseMessage();
                try
                {
                    consumeapi.Wait();
                    readdata = consumeapi.Result;
                }
                catch (Exception e)
                {
                    return RedirectToAction("Error", "Error", new { p = e });
                }


                if (readdata.IsSuccessStatusCode)
                {
                    TempData["message"] = "your transaction id :" + tt.tId;
                    return View("Success");
                }
                else
                {
                    var error = readdata.Content.ReadAsStringAsync().Result;
                    return RedirectToAction("Error", "Error", new { p = error });
                }
                
            }
            }



        }
}