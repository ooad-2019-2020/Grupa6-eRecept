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

        [HttpGet]
        public List<RecipeIngredient> getAllRecipeIngredients()
        {
            return _recipeIngredientRepository.getAllRecipeIngredients();
        }

        public List<RecipeWrapper> getAllRecipesWithIngredients(List<Ingredient> ingredients)
        {




            //  return _recipeIngredientRepository.getAllRecipesWithIngredients(ingredients);
            return null;

        }


       



    }
}
