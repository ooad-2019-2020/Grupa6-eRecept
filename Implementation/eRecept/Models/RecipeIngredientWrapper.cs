using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRecept.Models
{
    public class RecipeIngredientWrapper
    {
        public RecipeIngredientWrapper(Recipe recipe, Ingredient ingredient)
        {
            Recipe = recipe;
            Ingredient = ingredient;
        }

        public Recipe Recipe { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
