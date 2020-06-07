using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using eRecept.Models;
using eRecept.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace eRecept.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FeedbackController
    {

        private readonly FeedbackRepository _feedbackRepository;

        public FeedbackController(FeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        [HttpGet]
        public List<Feedback> getAllRecipes()
        {
            return _feedbackRepository.getAllRecipes();
        }

        [HttpGet("recipe")]
        public List<Feedback> getFeedbackForRecipe(int id)
        {
            return _feedbackRepository.getFeedbackForRecipe(id);
        }

        [HttpGet("user")]
        public List<Feedback> getFeedbackForUser(int id)
        {
            return _feedbackRepository.getFeedbackForUser(id);
        }

        [HttpGet("add")]
        public void addFeedback(Feedback feedback)
        {

            _feedbackRepository.addFeedback(feedback);

        }


    }





}
