using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eRecept.Models;
using eRecept.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace eRecept.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class RecipeController : Controller
    {


        private readonly RecipeRepository _recipeRepository;

        public RecipeController(RecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public List<Recipe> getAllRecipes()
        {
            //TODO: return all recipes
            return _recipeRepository.getAllRecipes();
        }

        public Recipe getRecipe(int id)
        {
            //TODO: return recipe by its id
            return _recipeRepository.getRecipe(id);
        }

        public void deleteRecipe(int id)
        {
            //TODO: delete recipe using its id
            _recipeRepository.deleteRecipe(id);
        }

        public void saveRecipe(Recipe recipe)
        {
            //TODO: save recipe using its id
            _recipeRepository.insertRecipe(recipe);
        }

        public List<Recipe> getSavedRecipes(int userId)
        {
            //TODO: get saved recipes of a specific user
            // _recipeRepository.deleteRecipe(id);
            return null;
        }

        public int saveRecipeForUser(int userId, int recipeId)
        {
            return 0;
        }

        public int addIngredient(int recipeId, int ingredientId)
        {
            return 0;
        }

        public int removeIngredient(int recipeId, int ingredientId)
        {
            return 0;
        }

        [HttpGet("setup")]
        public void setup()
        {
            //id, title, dect,mealtype, sidenote
            Recipe r = new Recipe(0,"Soup","Description on how to make this meal goes here","Appetizer","Great with bread");
            this.saveRecipe(r);

             r = new Recipe(0, "Fish", "Description on how to make this meal goes here", "Main course", "Watch out for bones");
            this.saveRecipe(r);

             r = new Recipe(0, "Cake", "Description on how to make this meal goes here", "Dessert", "Little more vanila extract for the flavor");
            this.saveRecipe(r);

            /* r = new Recipe(0, "Soup", "Description on how to make this meal goes here", "Appetizer", "Great with bread");
            this.saveRecipe(r);

             r = new Recipe(0, "Soup", "Description on how to make this meal goes here", "Appetizer", "Great with bread");
            this.saveRecipe(r);*/

        }

    }
}
