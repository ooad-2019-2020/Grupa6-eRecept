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

        [HttpGet("get")]
        public Recipe getRecipe(int id)
        {
            //TODO: return recipe by its id
            return _recipeRepository.getRecipe(id);
        }

        [HttpGet("getIngredients")]
        public List<IngredientWrapper> getIngredients(int id=-1)
        {
            if (id < 0) return null;

            List<RecipeIngredient> temp = _recipeIngredientRepository.getAllRecipeIngredients();
            List<IngredientWrapper> returnList = new List<IngredientWrapper>();

            foreach (RecipeIngredient rp in temp)
                if (rp.RecipeId == id) returnList.Add(new IngredientWrapper(_ingredientRepository.getIngredient(rp.IngredientId).Title, rp.Amount));

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
            Recipe r = new Recipe(0,"Soup", "Some soups simmer for hours, while others are ready in a half hour or less. Make a big batch of soup and freeze the extra, and you’ll always be minutes away from a delicious meal", "Appetizer","Great with bread", "https://www.bbcgoodfood.com/sites/default/files/recipe-collections/collection-image/2013/05/recipe-image-legacy-id-1074500_11.jpg");
            this.saveRecipe(r);
            this.addIngredient(r.Id,_ingredientRepository.getIngredient("Meat").Id,1);
            this.addIngredient(r.Id, _ingredientRepository.getIngredient("Eggs").Id, 1);

            r = new Recipe(0, "Fish", "Fish is a great meal for main course, quick to make, tasty and healthiest meat", "MainCourse", "Watch out for bones", "https://www.bbcgoodfood.com/sites/default/files/recipe-collections/collection-image/2013/05/baked-piri-piri-tilapia-with-crushed-potatoes.jpg");
            this.saveRecipe(r);
            this.addIngredient(r.Id, _ingredientRepository.getIngredient("Meat").Id, 2);
            this.addIngredient(r.Id, _ingredientRepository.getIngredient("Fish").Id, 1);

            r = new Recipe(0, "Cake", "Kids love cake so if you have kids make one they'll go crazy about it", "Dessert", "Little more vanila extract for the flavor", "https://www.handletheheat.com/wp-content/uploads/2015/03/Best-Birthday-Cake-with-milk-chocolate-buttercream-SQUARE.jpg");
            this.saveRecipe(r);
            this.addIngredient(r.Id, _ingredientRepository.getIngredient("Milk").Id, 1);
            this.addIngredient(r.Id, _ingredientRepository.getIngredient("Eggs").Id, 1);
            this.addIngredient(r.Id, _ingredientRepository.getIngredient("Chocolate").Id, 1);

            r = new Recipe(0, "Cheeseburger", "Beesechurger is a great meal for memers", "MainCourse", "Beeschusger", "https://i.kym-cdn.com/photos/images/original/001/404/055/8f5.jpg");
            this.saveRecipe(r);
            this.addIngredient(r.Id, _ingredientRepository.getIngredient("Cheese").Id, 2);
            this.addIngredient(r.Id, _ingredientRepository.getIngredient("Ketchup").Id, 1);
            this.addIngredient(r.Id, _ingredientRepository.getIngredient("Bread").Id, 2);

            r = new Recipe(0, "Beans", "Bosnians always love to eat beans", "MainCourse", "Beans", "https://img.24sata.hr/GJ56oBVA_eMw50OaVQHTViSldrw=/540x0/smart/media/images/src/20130100/8381a0a7efc24a38099bc79563205cab.jpg");
            this.saveRecipe(r);
            this.addIngredient(r.Id, _ingredientRepository.getIngredient("Cheese").Id, 2);
            this.addIngredient(r.Id, _ingredientRepository.getIngredient("Ketchup").Id, 1);
            this.addIngredient(r.Id, _ingredientRepository.getIngredient("Bread").Id, 2);

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
