using eRecept.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRecept.Repositories
{
    public class IngredientRepository
    {

        public List<Ingredient> getAllIngredients()
        {
            List<Ingredient> returnList = new List<Ingredient>();
            //TODO: return all ingredients from database
            return returnList;
        }

        public Ingredient getIngredient(int ingredientId)
        {
            //TODO: return ingredient by its id
            return null;
        }

        public void insertIngredient(Ingredient ingredient)
        {
            //TODO: insert ingredient into the database
        }

        public void insertIngredients(List<Ingredient> ingredients)
        {
            //TODO: add all ingredients
            //maybe this
            foreach (Ingredient i in ingredients) insertIngredient(i);
        }

        public void deleteIngrediant(int ingrediantId)
        {
            //TODO: delete ingredient from database by its id
        }

        public void updateIngrediant (Ingredient ingredient)
        {
            //TODO: update ingredient from database
        }


    }
}
