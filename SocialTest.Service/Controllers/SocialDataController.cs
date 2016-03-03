using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Ajax.Utilities;
using SocialTest.Business.Implementation;
using SocialTest.Business.Interfaces;
using SocialTest.Business.Providers;
using SocialTest.Models;
using SocialTest.Service.Helpers;

namespace SocialTest.Service.Controllers
{
    public class SocialDataController : ApiController
    {
        private ISocialDataService _socialDataService;

        //public SocialDataController() : this(new SocialDataService())
        //{          
        //}

        //public SocialDataController(ISocialDataService socialDataService )
        //{
        //    _socialDataService = socialDataService;
        //}

        // GET api/socialdata
        [Route("api/SocialData/{email}")]
        public SocialData Get(string email)
        {
            return null;
            //return _socialDataService.GetSocialData(email);
        }

        [Route("api/SocialData/GetSocialData")]
        [HttpPost]
        public SocialData GetSocialData([FromBody] SocialDataRequest socialDataRequest)
        {
            
            var providerTypes = ProviderHelper.BuildSocialDataProviders(socialDataRequest.SelectedProviders);
            _socialDataService = new SocialDataService(providerTypes);

            return _socialDataService.GetSocialData(socialDataRequest.Email);
            //return new SocialData()
            //{
            //    SocialDataDetails = new List<SocialDataDetail>()
            //    {
            //        new SocialDataDetail()
            //        {
            //            FirstName="J", ProviderName = "P"
            //        }
            //    }
            //};
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
