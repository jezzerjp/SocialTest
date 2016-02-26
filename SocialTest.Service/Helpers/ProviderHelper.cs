using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SocialTest.Business.Interfaces;
using SocialTest.Business.Providers;
using SocialTest.Models;

namespace SocialTest.Service.Helpers
{
    public static class ProviderHelper
    {
        public static List<ISocialDataProvider> BuildSocialDataProviders(string[] providerStrings)
        {
            var providerList = new List<ISocialDataProvider>();
            foreach (var provider in providerStrings)
            {
                try
                {
                    Enums.ProviderEnum providerEnum = (Enums.ProviderEnum)Enum.Parse(typeof(Enums.ProviderEnum), provider);

                    switch (providerEnum)
                    {
                        case Enums.ProviderEnum.Facebook:
                            providerList.Add(new FacebookProvider());
                            break;
                        case Enums.ProviderEnum.LinkedIn:
                            providerList.Add(new LinkedInProvider());
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception)
                {
                    //TODO: log error - not a known provider
                }
            }
            return providerList;
        }

    }
}