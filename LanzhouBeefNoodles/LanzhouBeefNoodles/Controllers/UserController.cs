using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LanzhouBeefNoodles.Controllers
{
    //在路由前面加上特定前缀admin/user/index才能访问
    [Route("admin/[controller]/[action]")]
    public class UserController : Controller
    {
        public IList<string> Index()
        {
            return new List<string> { "阿莱克斯", "莱克斯", "克斯", "斯"};
        }
    }
}
