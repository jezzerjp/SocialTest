using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialTest.Models
{
    public class SocialDataRequest
    {
        public string Email { get; set; }
        public string[] Providers { get; set; }
    }
}
