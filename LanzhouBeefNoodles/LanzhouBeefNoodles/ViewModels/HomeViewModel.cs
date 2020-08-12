using LanzhouBeefNoodles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanzhouBeefNoodles.ViewModels
{
    public class HomeViewModel
    {
        public IList<Feedback> Feedbacks { get; set; }

        public IList<Noodle> Noodles { get; set; }
    }
}
