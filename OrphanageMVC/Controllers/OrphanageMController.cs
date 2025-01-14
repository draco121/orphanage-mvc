﻿
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

            Password EncryptData = new Password();
            orp.Password = EncryptData.Encode(orp.Password);
            HttpClient hc = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:64581/api/orphanage/register")
            };
            var consumeapi = hc.PostAsJsonAsync("register", orp);

            consumeapi.Wait();

            var readdata = consumeapi.Result;

            if (readdata.IsSuccessStatusCode)
            {

                TempData["message"] = "Registration Successfull... Please Login!";
                //return RedirectToAction("Index", "Home");
                return RedirectToAction("Index");
            }
            else
            {
                TempData["message"] = readdata.Content.ReadAsStringAsync().Result;
            }
            return View("Create");
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

                consumeapi.Wait();

                var readdata = consumeapi.Result;

                if (readdata.IsSuccessStatusCode)
                {

                    //TempData["message"] = "Login Successful!";
                    
                    string res = readdata.Content.ReadAsStringAsync().Result;
                    TempData["token"] = res;
                    
                    Session["token"] = res;
                    
                    return View("Dashboard");
                }
                else
                {
                    TempData["msg"] = readdata.Content.ReadAsStringAsync().Result;
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
                return View("Dashboard");
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