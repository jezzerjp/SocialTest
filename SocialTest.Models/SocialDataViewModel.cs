using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SocialTest.Models
{
    public class SocialDataViewModel
    {
        public string Email { get; set; }
        public string[] SelectedProviders { get; set; }
        public MultiSelectList Providers { get; set; }
    }
}
