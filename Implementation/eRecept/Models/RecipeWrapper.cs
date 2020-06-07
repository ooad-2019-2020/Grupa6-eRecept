using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRecept.Models
{
    public class RecipeWrapper
    {

        Recipe recipe;
        int amount;


        public RecipeWrapper(Recipe recipe, int amount)
        {
            this.recipe = recipe;
            this.amount = amount;


        }

        public Recipe Recipe { get => recipe; set => recipe = value; }
        public int Amount { get => amount; set => amount = value; }
    }
}
