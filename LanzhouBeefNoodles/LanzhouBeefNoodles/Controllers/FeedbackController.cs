using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanzhouBeefNoodles.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace LanzhouBeefNoodles.Controllers
{
    [Authorize]
    public class FeedbackController : Controller
    {
        private IFeedbackRepository _feedbackRepository;

        public FeedbackController(IFeedbackRepository feedbackRepository) 
        {
            _feedbackRepository = feedbackRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Feedback feedback) 
        {
            //Tag Hleper
            if (ModelState.IsValid) 
            {
                _feedbackRepository.AddFeedBack(feedback);
                return RedirectToAction("FeedbackComplete");
            }

            return View();
            //return View(_feedbackRepository.GetAllFeedbacks().ToList());
        }

        public IActionResult FeedbackComplete() 
        {
            return View();
        }

    }
}
