using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LanzhouBeefNoodles.Controllers
{
    //[Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        public String Index()
        {
            return "Hello From Home";
        }

        public String About()
        {
            return "Hello From About";
        }
    }
}
