using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace eRecept.Models
{
    public class Recipe
    {

        private int id;
        private string title;
        private string description;
        private HashSet<Ingredient> ingredients;
        private List<Feedback> feedbacks;
        private string mealType;
        private List<string> recipeTags;
        private List<Direction> directions;
        private string sideNote;

        public Recipe(int id, string title, string description, HashSet<Ingredient> ingredients, List<Feedback> feedbacks, string mealType, List<string> recipeTags, List<string> directions, string sideNote)
        {
            this.id = id;
            this.title = title;
            this.description = description;
            this.ingredients = ingredients;
            this.feedbacks = feedbacks;
            this.mealType = mealType;
            this.recipeTags = recipeTags;
            this.directions = directions;
            this.sideNote = sideNote;
        }

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }
        public HashSet<Ingredient> Ingredients { get => ingredients; set => ingredients = value; }
        public List<Feedback> Feedbacks { get => feedbacks; set => feedbacks = value; }
        public string MealType { get => mealType; set => mealType = value; }
        public List<string> RecipeTags { get => recipeTags; set => recipeTags = value; }
        public List<Direction> Directions { get => directions; set => directions = value; }
        public string SideNote { get => sideNote; set => sideNote = value; }

        public void addRecipeTag(string recipeTag)
        {
            recipeTags.Add(recipeTag);
        }

        public void addFeedback(Feedback feedback)
        {
            feedbacks.Add(feedback);
        }

        public void addDirection(Direction direction)
        {
            directions.Add(direction);
        }


    }


}
