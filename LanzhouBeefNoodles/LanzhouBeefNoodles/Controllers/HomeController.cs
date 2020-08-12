using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanzhouBeefNoodles.Models;
using LanzhouBeefNoodles.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanzhouBeefNoodles.Controllers
{
    //[Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private INoodleRepository _noodleRepository;

        private IFeedbackRepository _feedbackRepository;

        public HomeController(INoodleRepository noodleRepository, IFeedbackRepository feedbackRepository) 
        {
            _noodleRepository = noodleRepository;
            _feedbackRepository = feedbackRepository;
        }

        public IActionResult Index()
        {
            HomeViewModel viewModel = new HomeViewModel() 
            {
                Noodles = _noodleRepository.GetAllNoodles().ToList(),
                Feedbacks = _feedbackRepository.GetAllFeedbacks().ToList()
            };

            return View(viewModel);
        }

        public String About()
        {
            return "Hello From About";
        }
    }
}
