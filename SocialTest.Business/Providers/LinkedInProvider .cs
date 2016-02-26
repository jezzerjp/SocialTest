using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialTest.Business.Interfaces;
using SocialTest.Models;

namespace SocialTest.Business.Providers
{
    public class LinkedInProvider : ISocialDataProvider
    {
        public SocialDataDetail GetSocialData(string email)
        {
            return new SocialDataDetail
            {
                ProviderName = "LinkedIn",
                FirstName = "LinkedIn name"
            };
        }
    }
}
