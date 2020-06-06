using eRecept.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRecept.Repositories
{
    public class RecipeRepository
    {

        private static RecipeRepository instance=null;
        private static readonly object padlock = new object();

        RecipeRepository() { }

        public static RecipeRepository Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new RecipeRepository();
                    }
                    return instance;
                }
            }
        }


        public List<Recipe> getAllRecipes()
        {
            //TODO: return all recipes from database
            return null;
        }

        public Recipe getRecipe(int id)
        {
            //TODO: return recipe by its id
            return null;
        }

        public void insertRecipe(Recipe recipe)
        {
            //TODO: insert recipe into the database
        }

        public void deleteRecipe(int id)
        {
            //TODO: delete recipe from database using its id
        }

        public void updateRecipe(Recipe recipe)
        {
            //TODO: update recipe using its id
        }

        public List<Recipe> getFilteredRecipes(String mealType, String recipeTag)
        {

            //TODO: get recipes from database by its mealType and recipeTag
            List<Recipe> returnRecipes = new List<Recipe>();
            return returnRecipes;
        }

        public List<Recipe> getSavedRecipes(int userId)
        {
            //TODO: get saved recipes of a specific user
            List<Recipe> returnRecipes = new List<Recipe>();
            return returnRecipes;
        }

        public int saveRecipeForUser(int userId, int recipeId)
        {

            //TODO: check if user has thhe recipe
            //has-> return 0
            //doesnt-> save it and return 1

            return 0;

        }





    }
}
