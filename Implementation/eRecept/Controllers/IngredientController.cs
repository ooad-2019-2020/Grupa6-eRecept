using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eRecept.Models;
using Microsoft.AspNetCore.Mvc;

namespace eRecept.Controllers
{
    public class IngredientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<Ingredient> getAllIngredients()
        {
            List<Ingredient> returnList = new List<Ingredient>();
            returnList = Repositories.IngredientRepository.Instance.getAllIngredients();
            //TODO: return all ingredients
            return returnList;
        }

        public Ingredient getIngredient(int ingredientId)
        {
            //TODO: return ingredient by its id
            Ingredient returnIngredient = Repositories.IngredientRepository.Instance.getIngredient(ingredientId);
            return returnIngredient;
        }

        public void deleteIngredient(int ingredientId)
        {
            Repositories.IngredientRepository.Instance.deleteIngredient(ingredientId);
            //TODO: delete ingredient
        }

        public void saveIngredient(Ingredient ingredient)
        {
            Repositories.IngredientRepository.Instance.updateIngredient(ingredient);
            //TODO: save ingredient
        }

    }
}
