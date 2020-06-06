using eRecept.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRecept.Repositories
{
    public class IngredientRepository
    {

        private static IngredientRepository instance = null;
        private static readonly object padlock = new object();

        IngredientRepository() { }

        public static IngredientRepository Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new IngredientRepository();
                    }
                    return instance;
                }
            }
        }



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

        public void deleteIngredient(int ingredientId)
        {
            //TODO: delete ingredient from database by its id
        }

        public void updateIngredient (Ingredient ingredient)
        {
            //TODO: update ingredient from database
        }


    }
}
