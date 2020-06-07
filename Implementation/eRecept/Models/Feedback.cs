using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eRecept.Models
{
    public class Feedback
    {

     

        public Feedback(int id,int userId, int recipeId, int rating, string comment)
        {

            Id = id;
            UserId = userId;
            RecipeId = recipeId;
            Rating = rating;
            Comment = comment;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(5)")]
        public int RecipeId { get; set; }
        [Required]
        [Column(TypeName = "varchar(5)")]
        public int UserId { get; set; }
        [Required]
        [Column(TypeName = "varchar(5)")]
        public int Rating { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Comment { get; set; }

    }
}
