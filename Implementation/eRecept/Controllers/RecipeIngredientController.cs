using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eRecept.Models;
using eRecept.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace eRecept.Controllers
{
    public class RecipeIngredientController : Controller
    {
        private readonly RecipeIngredientRepository _recipeIngredientRepository;

        public RecipeIngredientController(RecipeIngredientRepository recipeIngredientRepository)
        {
            _recipeIngredientRepository = recipeIngredientRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public List<RecipeIngredientRepository> getAllRecipeIngredients()
        {
            return _recipeIngredientRepository.getAllRecipeIngredients();
        }

        public List<RecipeIngredientWrapper> getAllRecipesWithIngredients(List<Ingredient> ingredients)
        {

            //  this.RecipeIngredients.FromSqlRaw

            return null;
        }




    }
}
