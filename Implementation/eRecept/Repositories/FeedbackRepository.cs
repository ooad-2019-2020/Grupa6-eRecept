using eRecept.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace eRecept.Repositories
{

    [System.ComponentModel.DataAnnotations.Schema.Table("Feedback")]
    public class FeedbackRepository : DbContext
    {

        public FeedbackRepository(DbContextOptions<FeedbackRepository> options) : base(options)
        {
        }

        public DbSet<Feedback> Feedbacks { get; set; }



        public List<Feedback> getAllRecipes()
        {
            return this.Feedbacks.ToList<Feedback>();
        }

        public List<Feedback> getFeedbackForRecipe(int id)
        {

            return this.Feedbacks.Where(i => i.RecipeId == id).ToList<Feedback>();

        }

        public List<Feedback> getFeedbackForUser(int id)
        {

            return this.Feedbacks.Where(i => i.UserId == id).ToList<Feedback>();

        }

        public void addFeedback(Feedback feedback)
        {

            this.Feedbacks.Add(feedback);

        }


    }
}
