using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRecept.Models
{
    public class Feedback
    {

        private int userId;
        private int recipeId;
        private int rating;
        private string comment;

        public Feedback(int userId, int recipeId, int rating, string comment)
        {
            this.userId = userId;
            this.recipeId = recipeId;
            this.rating = rating;
            this.comment = comment;
        }

        public int UserId { get => userId; set => userId = value; }
        public int RecipeId { get => recipeId; set => recipeId = value; }
        public int Rating { get => rating; set => rating = value; }
        public string Comment { get => comment; set => comment = value; }
    }
}
