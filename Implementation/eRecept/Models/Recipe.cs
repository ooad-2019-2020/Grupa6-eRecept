using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace eRecept.Models
{
    public class Recipe
    {

        public Recipe(int id, string title, string description, string mealType, string sideNote)
        {
            Id = id;
            Title = title;
            Description = description;
            MealType = mealType;
            SideNote = sideNote;
        }
        /*public Recipe(int id, string title, string description, HashSet<Ingredient> ingredients, List<Feedback> feedbacks, string mealType, List<string> recipeTags, List<Direction> directions, string sideNote)
        {
            Id = id;
            Title = title;
            Description = description;
            Ingredients = ingredients;
            Feedbacks = feedbacks;
            MealType = mealType;
            RecipeTags = recipeTags;
            Directions = directions;
            SideNote = sideNote;
        }*/
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Title { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Description { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string MealType { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string SideNote { get; set; }
        /*[Required]
        public HashSet<Ingredient> Ingredients { get; set; }
     
        public List<Feedback> Feedbacks { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string MealType { get; set; }
        [Required]
        public List<string> RecipeTags { get; set; }
        [Required]
        public List<Direction> Directions { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string SideNote { get; set; }

        public void addRecipeTag(string recipeTag)
        {
            RecipeTags.Add(recipeTag);
        }

        public void addFeedback(Feedback feedback)
        {
            Feedbacks.Add(feedback);
        }

        public void addDirection(Direction direction)
        {
            Directions.Add(direction);
        }

        */
    }


}
