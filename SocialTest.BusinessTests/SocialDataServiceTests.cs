using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialTest.Business.Implementation;
using SocialTest.Business.Interfaces;
using SocialTest.Models;

namespace SocialTest.BusinessTests
{

    [TestClass]
    public class SocialDataServiceTests
    {
        private readonly string providerName1 = "p1";
        private readonly string firstName1 = "f1";
        private Mock<ISocialDataProvider> _mockedSocialDataProvider1;
        private readonly string providerName2 = "p2";
        private readonly string firstName2 = "f2";
        private Mock<ISocialDataProvider> _mockedSocialDataProvider2;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockedSocialDataProvider1 = new Mock<ISocialDataProvider>();
            _mockedSocialDataProvider1.Setup(x => x.GetSocialData(It.IsAny<string>()))
                .Returns(new SocialDataDetail
                {
                    ProviderName = providerName1,
                    FirstName = firstName1
                });

            _mockedSocialDataProvider2 = new Mock<ISocialDataProvider>();
            _mockedSocialDataProvider2.Setup(x => x.GetSocialData(It.IsAny<string>()))
                .Returns(new SocialDataDetail
                {
                    ProviderName = providerName2,
                    FirstName = firstName2
                });
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestNullProvidersThrowsNullReferenceException()
        {
            var sut = new SocialDataService(null);
            var result = sut.GetSocialData("");
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestNoProvidersThrowsNullReferenceExceptio()
        {
            var sut = new SocialDataService(new List<ISocialDataProvider>());
            var result = sut.GetSocialData("");
        }

        [TestMethod]
        public void TestOneMockedProviderReturnsListOfOne()
        {
            var mockedProviders = new List<ISocialDataProvider>()
            {
                _mockedSocialDataProvider1.Object
            };
            var sut = new SocialDataService(mockedProviders);
            var result = sut.GetSocialData("");

            Assert.AreEqual(1, result.SocialDataDetails.Count);

            Assert.AreEqual(providerName1, result.SocialDataDetails[0].ProviderName);
            Assert.AreEqual(firstName1, result.SocialDataDetails[0].FirstName);
        }

        [TestMethod]
        public void TestTwoMockedProvidersReturnListOfTwo()
        {
            var mockedProviders = new List<ISocialDataProvider>()
            {
                _mockedSocialDataProvider1.Object,
                _mockedSocialDataProvider2.Object
            };
            var sut = new SocialDataService(mockedProviders);
            var result = sut.GetSocialData("");

            Assert.AreEqual(2, result.SocialDataDetails.Count);

            Assert.AreEqual(providerName1, result.SocialDataDetails[0].ProviderName);
            Assert.AreEqual(firstName1, result.SocialDataDetails[0].FirstName);
            Assert.AreEqual(providerName2, result.SocialDataDetails[1].ProviderName);
            Assert.AreEqual(firstName2, result.SocialDataDetails[1].FirstName);

        }

    }
}
