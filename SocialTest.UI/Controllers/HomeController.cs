using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using RestSharp;
using SocialTest.Models;

namespace SocialTest.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var providers = new List<Provider>()
            {
                new Provider() {ProviderId = "Facebook", ProviderName = "Facebook"},
                new Provider() {ProviderId = "LinkedIn", ProviderName = "LinkedIn"}
            };

            var socialDataRequest = new SocialDataViewModel
            {
                Providers = new MultiSelectList(providers, "ProviderId", "ProviderName")
            };

            return View(socialDataRequest);
        }

        [HttpPost]
        public ActionResult Index(SocialDataViewModel socialDataViewModel)
        {
            var socialDataRequest = new SocialDataRequest()
            {
                Email = socialDataViewModel.Email,
                SelectedProviders = socialDataViewModel.SelectedProviders
            };

            // TODO: use config for url
            var client = new RestClient("http://localhost:59381/api");
            var request = new RestRequest("SocialData/GetSocialData");
            request.Method = Method.POST;
            request.RequestFormat = DataFormat.Json;
            request.AddBody(socialDataRequest);
            var response = client.Execute(request);

            var results = JsonConvert.DeserializeObject<SocialData>(response.Content);

            return PartialView("_Results", results);
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