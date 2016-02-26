using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestSharp;
using SocialTest.Models;

namespace SocialTest.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(SocialDataRequest socialDataRequest)
        {
            // TODO: use config for url
            var client = new RestClient("http://localhost:59381/api");
            var request = new RestRequest("SocialData/GetSocialData");
            request.RequestFormat = DataFormat.Json;
            request.AddBody(socialDataRequest);
            var response = client.Execute(request);

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