
using Newtonsoft.Json;
using OrphanageMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OrphanageMVC.Controllers
{
    public class OrphanageMController : Controller
    {
        ////GET: OrphanageM
        //public ActionResult Index()
        //{
        //    IEnumerable<OrphanageRegistrationView> orpObj = null;

        //    using(var hc=new HttpClient())
        //    {
        //        hc.BaseAddress = new Uri("https://localhost:44309/api/Orphanage");
        //        var consumeapi = hc.GetAsync("Orphanage");
        //        consumeapi.Wait();
        //        var readdata = consumeapi.Result;
        //        if (readdata.IsSuccessStatusCode)
        //        {
        //            var displaydata = readdata.Content.ReadAsAsync<IList<OrphanageRegistrationView>>();

        //            displaydata.Wait();

        //            orpObj = displaydata.Result;
        //        }
        //        else
        //        {
        //            orpObj = Enumerable.Empty<OrphanageRegistrationView>();
        //            ModelState.AddModelError(string.Empty, "Server Error Occured!");
        //        }
        //    }
        //    //HttpClient hc = new HttpClient();









        //    return View(orpObj);
        //}

        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(OrphanageRegistrationView orp)
        {
            HttpClient hc = new HttpClient();

            hc.BaseAddress = new Uri("http://localhost:64581/api/orphanage/register");
            var consumeapi = hc.PostAsJsonAsync("register", orp);

            consumeapi.Wait();

            var readdata = consumeapi.Result;

            if (readdata.IsSuccessStatusCode)
            {

                TempData["message"] = "Registration Successfull... Please Login!";
                //return RedirectToAction("Index", "Home");
                return RedirectToAction("Index");
            }
            return View("Create");
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Index(OrphanageRegistrationView orp)
        {
            if (ModelState.IsValid)
            {

                FormsAuthentication.SetAuthCookie(orp.oId.ToString(), true);
                
                HttpClient hc = new HttpClient();

                hc.BaseAddress = new Uri("http://localhost:64581/api/orphanage/login");
                var consumeapi = hc.PostAsJsonAsync<OrphanageRegistrationView>("Login", orp);

                consumeapi.Wait();

                var readdata = consumeapi.Result;

                if (readdata.IsSuccessStatusCode)
                {

                    TempData["message"] = "Login Successful!";
                    //return RedirectToAction("Index", "Home");
                    string res = readdata.Content.ReadAsStringAsync().Result;
                    TempData["token"] = res;
                    //Console.WriteLine(res);
                    Session["token"] = res;
                   // OrphanageRegistrationView resp = JsonConvert.DeserializeObject<OrphanageRegistrationView>(res);
                    return View("Dashboard");
                }
                else
                {
                    TempData["message"] = "Login Failed !Enter correct Credentials!";
                    return View("Index");
                }
                
            }
            return View("Create");
        }


        public ActionResult ChildRegistration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChildRegistration(childRegisteration child)
        {
            HttpClient hc = new HttpClient();

            OrphanageRegistrationView orp = JsonConvert.DeserializeObject<OrphanageRegistrationView>(Session["token"].ToString());
            child.oId = orp.oId;
            hc.BaseAddress = new Uri("http://localhost:64581/api/orphanage/add/addchild");
            var consumeapi = hc.PostAsJsonAsync<childRegisteration>("addchild", child);

            consumeapi.Wait();

            var readdata = consumeapi.Result;

            if (readdata.IsSuccessStatusCode)
            {

                TempData["message"] = "Child Registration Successfull... Please Login!";
                //return RedirectToAction("Index", "Home");
                return RedirectToAction("Index");
            }
            else
            {
                TempData["message"] = readdata.StatusCode;
            }
            return View("Dashboard");
        }



        public ActionResult OrphanageRequirement()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OrphanageRequirement(reqTable child)
        {
            HttpClient hc = new HttpClient();


            child.oId = int.Parse(Session["Oid"].ToString());
            hc.BaseAddress = new Uri("https://localhost:44309/api/Child");
            var consumeapi = hc.PostAsJsonAsync<reqTable>("Child", child);

            consumeapi.Wait();

            var readdata = consumeapi.Result;

            if (readdata.IsSuccessStatusCode)
            {

                TempData["message"] = "Child Registration Successfull... Please Login!";
                //return RedirectToAction("Index", "Home");
                return RedirectToAction("Index");
            }
            return View("Dashboard");
        }
    }
}