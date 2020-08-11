using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanzhouBeefNoodles.Controllers
{
    //创建一个控制器的三种方式
    //1.类名Controller
    //2.面向切面编程：类名称上加上注解 [Controller]
    //3.继承Controller
    //[Controller]
    public class Test : Controller
    {
        public String Index()
        {
            return "Hello From Test Index";
        }

        public ActionResult Index1()
        {
            //Content中内容可以是json、string、List等等
            return Content("Hello From Test Index ActionResult");
        }

        public ActionResult Contant()
        {
            return View();
        }
    }
}
