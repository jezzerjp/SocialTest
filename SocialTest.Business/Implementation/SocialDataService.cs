using System;
using System.Collections.Generic;
using SocialTest.Business.Interfaces;
using SocialTest.Models;

namespace SocialTest.Business.Implementation
{
    public class SocialDataService : ISocialDataService
    {
        private readonly List<ISocialDataProvider> _socialDataProviders;

        public SocialDataService(List<ISocialDataProvider> socialDataProviders)
        {
            if (socialDataProviders == null)
            {
                throw new NullReferenceException();
            }
            if (socialDataProviders.Count == 0)
            {
                throw new NullReferenceException();
            }
            _socialDataProviders = socialDataProviders;
        }

        public SocialData GetSocialData(string email)
        {
            var socialData = new SocialData {SocialDataDetails = new List<SocialDataDetail>()};
            foreach (var provider in _socialDataProviders)
            {
                var providerData = provider.GetSocialData(email);
                if (providerData != null)
                { 
                    socialData.SocialDataDetails.Add(providerData);
                }
            }
            
            return socialData;
        }
    }
}
