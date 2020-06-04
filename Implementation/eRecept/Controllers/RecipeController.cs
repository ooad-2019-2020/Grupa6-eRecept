using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eRecept.Models;
using Microsoft.AspNetCore.Mvc;

namespace eRecept.Controllers
{
    public class RecipeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<Recipe> getAllRecipes()
        {
            //TODO: return all recipes
            return null;
        }

        public Recipe getRecipe(int id)
        {
            //TODO: return recipe by its id
            return null;
        }

        public void deleteRecipe(int id)
        {
            //TODO: delete recipe using its id
        }

        public void saveRecipe(Recipe recipe)
        {
            //TODO: save recipe using its id
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

        public int addIngredient(int recipeId, int ingredientId)
        {
            //TODO: add ingredients to a recipe
            // if it already has it return 0
            // if not add it and return 1
            return 0;
        }

        public int removeIngredient(int recipeId, int ingredientId)
        {
            //TODO: add ingredients to a recipe
            // if it doesnt have it return 0
            // if does remove it and return 1
            return 0;
        }

    }
}
