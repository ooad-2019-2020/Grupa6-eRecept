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
        public double getFeedbackForRecipe(int id)
        {
            List<Feedback>list= _feedbackRepository.getFeedbackForRecipe(id);
            if (list.Count == 0) return 0;
            double sum = 0;
            foreach (Feedback feedback in list) sum += feedback.Rating;
            return sum / list.Count;
        }

        [HttpGet("user")]
        public List<Feedback> getFeedbackForUser(int id)
        {
            return _feedbackRepository.getFeedbackForUser(id);
        }

        [HttpGet("submit")]
        public void addFeedback(int rating, string comment, int userId, int recipeId)
        {
            Feedback feedback = new Feedback(0,userId,recipeId,rating,comment);
            _feedbackRepository.addFeedback(feedback);

        }


    }





}
