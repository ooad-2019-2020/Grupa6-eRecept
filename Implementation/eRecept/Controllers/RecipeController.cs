using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using eRecept.Models;
using eRecept.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eRecept.Controllers
{

    [EnableCors("AllowMyOrigin")]
    [Route("[controller]")]
    [ApiController]
    public class RecipeController : Controller
    {


        private readonly RecipeRepository _recipeRepository;
        private readonly RecipeIngredientRepository _recipeIngredientRepository;
        private readonly IngredientRepository _ingredientRepository;
        private readonly SavedRecipesRepository _savedRecipes;
        private readonly UserRepository _users;
        private readonly FeedbackRepository _feedback;

        public RecipeController(RecipeRepository recipeRepository, RecipeIngredientRepository recipeIngredientRepository, IngredientRepository ingredientRepository, SavedRecipesRepository savedRecipes, UserRepository users, FeedbackRepository feedback)
        {
            _recipeRepository = recipeRepository;
            _recipeIngredientRepository = recipeIngredientRepository;
            _ingredientRepository = ingredientRepository;
            _savedRecipes = savedRecipes;
            _users = users;
            _feedback = feedback;
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

        [HttpGet("getIngredients")]
        public List<IngredientWrapper> getIngredients(int id=-1)
        {
            if (id <0) return null;

            List<RecipeIngredient> temp = _recipeIngredientRepository.getAllRecipeIngredients();
            List<IngredientWrapper> returnList = new List<IngredientWrapper>();

            foreach (RecipeIngredient rp in temp)
                if (rp.IngredientId == id) returnList.Add(new IngredientWrapper(_ingredientRepository.getIngredient(rp.IngredientId).Title, rp.Amount));

            return returnList;

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

        [HttpGet("saved")]
        public List<Recipe> getSavedRecipes(int userId)
        {


            List<SavedRecipes> tempList= _savedRecipes.getAllRecipeIngredients();

            List<Recipe> returnList = new List<Recipe>();

            foreach(SavedRecipes sr in tempList)
            {
                returnList.Add(getRecipe(sr.RecipeId));
            }
            return returnList;

        }

        [HttpGet("save")]
        public int saveRecipeForUser(int userId, int recipeId)
        {
            //todo use local userid variable
            _savedRecipes.saveRecipe(new SavedRecipes(0,userId, recipeId));
            return 0;
        }

        public int addIngredient(int recipeId, int ingredientId,int amount)
        {
            _recipeIngredientRepository.addRecipeIngredient(new RecipeIngredient(0,recipeId,ingredientId,amount));
            return 0;
        }

        public int removeIngredient(int recipeId, int ingredientId)
        {
            String query = "Delete from RecipeIngredients where recipeId=" + recipeId + " and ingredientId" + ingredientId;
            _recipeIngredientRepository.RecipeIngredients.FromSqlRaw(query);
            return 0;
        }

        [HttpGet("setup")]
        public void setup()
        {
            //id, title, dect,mealtype, sidenote
            Recipe r = new Recipe(0,"Soup","Description on how to make this meal goes here","Appetizer","Great with bread");
            this.saveRecipe(r);
            this.addIngredient(r.Id,_ingredientRepository.getIngredient("Meat").Id,1);
            this.addIngredient(r.Id, _ingredientRepository.getIngredient("Eggs").Id, 1);

            r = new Recipe(0, "Fish", "Description on how to make this meal goes here", "MainCourse", "Watch out for bones");
            this.saveRecipe(r);
            this.addIngredient(r.Id, _ingredientRepository.getIngredient("Meat").Id, 2);
            this.addIngredient(r.Id, _ingredientRepository.getIngredient("Fish").Id, 1);

            r = new Recipe(0, "Cake", "Description on how to make this meal goes here", "Dessert", "Little more vanila extract for the flavor");
            this.saveRecipe(r);
            this.addIngredient(r.Id, _ingredientRepository.getIngredient("Milk").Id, 1);
            this.addIngredient(r.Id, _ingredientRepository.getIngredient("Eggs").Id, 1);
            this.addIngredient(r.Id, _ingredientRepository.getIngredient("Chocolate").Id, 1);

            r=new Recipe(0, " Cheeseburger", "Description on how to make this meal goes here","MainCourse","Beeschusger");
            this.saveRecipe(r);
            this.addIngredient(r.Id, _ingredientRepository.getIngredient("Cheese").Id, 2);
            this.addIngredient(r.Id, _ingredientRepository.getIngredient("Ketchup").Id, 1);
            this.addIngredient(r.Id, _ingredientRepository.getIngredient("Bread").Id, 2);


            List<User> users = new List<User>();
            users = _users.getAllUsers();
            List<Recipe> recipes = _recipeRepository.getAllRecipes();
           
            Random rnd = new Random();

            for (int i = 0; i < 3; i++)
            {
                SavedRecipes sr = new SavedRecipes(0, users[rnd.Next(users.Count)].UserId, recipes[rnd.Next(recipes.Count)].Id);
                _savedRecipes.saveRecipe(sr);
            }

            
                Feedback fb = new Feedback(0, 1, recipes[rnd.Next(recipes.Count)].Id,rnd.Next(5),"Testing comment "+rnd.Next(70));
                _feedback.addFeedback(fb);
                fb = new Feedback(0, 2, recipes[rnd.Next(recipes.Count)].Id, rnd.Next(5), "Testing comment " + rnd.Next(70));
                _feedback.addFeedback(fb);
                fb = new Feedback(0, 3, recipes[rnd.Next(recipes.Count)].Id, rnd.Next(5), "Testing comment " + rnd.Next(70));
                _feedback.addFeedback(fb);



        }

        [HttpGet("getDaily")]
        public Recipe getDaily()
        {
            Random r = new Random();

            List<Recipe> recipes = _recipeRepository.getAllRecipes();

            if (recipes.Count == 0) return null;
            return recipes[r.Next(recipes.Count)];

        }

        [HttpGet("getBest")]
        public Recipe getBest()
        {
            Random r = new Random();

            List<Recipe> recipes = _recipeRepository.getAllRecipes();

            if (recipes.Count == 0) return null;
            return recipes[r.Next(recipes.Count)];

        }

        [HttpGet("getOther")]
        public List<Recipe> getOther(int page = 1)
        {
            Random r = new Random();

            List<Recipe> recipes = _recipeRepository.getAllRecipes();

            List<Recipe> returnRecipes = new List<Recipe>();

            page--;
            for (int i = page * 6; i < (page + 1) * 6 && i<recipes.Count; i++)
                returnRecipes.Add(recipes[i]);

            return returnRecipes;


        }


        [HttpGet("few")]
        public List<RecipeWrapper> getFew(string list)//[FromUri] List<String> ing = null,int page = 1, string mealType = "NO", int missingMax = 0
        {



            List<Ingredient> ingredients = new List<Ingredient>();

            List<Recipe> recipes = _recipeRepository.getAllRecipes();

            List<RecipeWrapper> suggestedRecipes = new List<RecipeWrapper>();

            if (list == null)
            {

                foreach(Recipe r in recipes)
                {
                    suggestedRecipes.Add(new RecipeWrapper(r, 0));
                }
                return suggestedRecipes;
            }

   
            foreach (string name in list.Split(','))
                ingredients.Add(_ingredientRepository.getIngredient(name));
                
                
                foreach (Recipe recipe in recipes)
                {
                    int ingredientCount = _recipeIngredientRepository.RecipeIngredients.Count(p => p.RecipeId == recipe.Id);
                    int matchedIngredientCount = 0;
                    foreach (Ingredient ingredient in ingredients)
                    {
                        bool found = _recipeIngredientRepository.RecipeIngredients.Any(p => p.RecipeId == recipe.Id && p.IngredientId == ingredient.Id);
                        if (found) matchedIngredientCount++;
                    }
                    if (matchedIngredientCount > 0)
                    {
                        RecipeWrapper recipeWrapper = new RecipeWrapper(recipe, ingredientCount - matchedIngredientCount);
                        suggestedRecipes.Add(recipeWrapper);
                    }
                }

            return suggestedRecipes;


        }


    }
}
