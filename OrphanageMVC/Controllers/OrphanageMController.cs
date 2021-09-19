
using Newtonsoft.Json;
using OrphanageMVC.Common;
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

            Password EncryptData = new Password();
            orp.Password = EncryptData.Encode(orp.Password);
            HttpClient hc = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:64581/api/orphanage/register")
            };
            var consumeapi = hc.PostAsJsonAsync("register", orp);
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

                TempData["message"] = "Registration Successfull... Please Login!";
                //return RedirectToAction("Index", "Home");
                return RedirectToAction("Index");
            }
            else
            {
                string error = readdata.Content.ReadAsStringAsync().Result;
                return RedirectToAction("Error", "Error", new { p = error });
            }

        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Index(LoginModel orp)
        {
            if (ModelState.IsValid)
            {

                //FormsAuthentication.SetAuthCookie(orp.oId.ToString(), true);
                Password EncryptData = new Password();
                orp.Password = EncryptData.Encode(orp.Password);
                HttpClient hc = new HttpClient
                {
                    BaseAddress = new Uri("http://localhost:64581/api/orphanage/login")
                };
                var consumeapi = hc.PostAsJsonAsync<LoginModel>("Login", orp);

            
            var readdata = new HttpResponseMessage();
                try
                {
                    consumeapi.Wait();
                    readdata = consumeapi.Result;
                }
                catch (Exception e)
                {
                    return RedirectToAction("Error", "Error", new { p = e});
            }

                if (readdata.IsSuccessStatusCode)
                {
                    
                    string res = readdata.Content.ReadAsStringAsync().Result;
                    TempData["token"] = res;

                    Session["token"] = res;
                    
                    return View("Dashboard");
                }
                else
                {
                    if(readdata.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                       return  RedirectToAction("Error", "Error", "User Not Found");
                    }
                    else
                    {
                        string error = readdata.Content.ReadAsStringAsync().Result;
                        return RedirectToAction("Error", "Error", error);
                    }
                }
                
            }
            return View("Index");
        }


        public ActionResult ChildRegistration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChildRegistration(int oid,childRegisteration child)
        {
            HttpClient hc = new HttpClient();
            
            child.oId = oid;
            hc.BaseAddress = new Uri("http://localhost:64581/api/orphanage/add/addchild");
            var consumeapi = hc.PostAsJsonAsync<childRegisteration>("addchild", child);
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

                TempData["message"] = "Child Registration Successfull... Please Login!";
                //return RedirectToAction("Index", "Home");
                return View("Dashboard");
            }
            else
            {
                string error = readdata.Content.ReadAsStringAsync().Result;
                return RedirectToAction("Error", "Error", error);
            }

        }

        public ActionResult Dashboard(int id)
        {
            HttpClient hc = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:64581/api/orphanage/orphanagebyid/}")
            };
            var consumeapi = hc.GetAsync("?id="+id.ToString());
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

                //TempData["message"] = "Login Successful!";

                string res = readdata.Content.ReadAsStringAsync().Result;

                Session["orpinfo"] = res;

                return View();
            }
            else
            {
                string error = readdata.Content.ReadAsStringAsync().Result;
                return RedirectToAction("Error", "Error", error);
            }
        }


        /*[HttpPost]
        public ActionResult OrphanageRequirement(int amount)
        {
            HttpClient hc = new HttpClient();
            Requirement org = new Requirement();
            OrphanageRegistrationView orp = JsonConvert.DeserializeObject<OrphanageRegistrationView>(Session["token"].ToString());
            org.oId = orp.oId;
            org.requirementName = amount.ToString();
            org.requirementStatus = "Pending";
            hc.BaseAddress = new Uri("http://localhost:64581/api/Requirement");
            var consumeapi = hc.PostAsJsonAsync<Requirement>("Requirement", org);

            consumeapi.Wait();

            var readdata = consumeapi.Result;

            if (readdata.IsSuccessStatusCode)
            {

                TempData["message"] = "Requirement Added Successfully!";
                //return RedirectToAction("Index", "Home");
                return View("Dashboard");
            }
            else
            {
                TempData["message"] = readdata.StatusCode;
            }
            return View("Dashboard");
        }*/




    }
}