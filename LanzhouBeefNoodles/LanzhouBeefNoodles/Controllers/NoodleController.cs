using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LanzhouBeefNoodles.Controllers
{
    public class NoodleController : Controller
    {
        public IList<string> Index()
        {
            return new List<string> { "牛肉面", "鸡蛋面", "排骨面"};
        }
    }
}
