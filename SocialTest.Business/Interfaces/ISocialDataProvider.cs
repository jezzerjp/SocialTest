using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialTest.Models;

namespace SocialTest.Business.Interfaces
{
    public interface ISocialDataProvider
    {
        SocialDataDetail GetSocialData(string email);
    }
}
