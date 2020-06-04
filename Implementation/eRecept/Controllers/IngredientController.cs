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
            //TODO: return all ingredients
            return returnList;
        }

        public Ingredient getIngredient(int ingredientId)
        {
            //TODO: return ingredient by its id
            return null;
        }

        public void deleteIngrediant(int ingrediantId)
        {
            //TODO: delete ingredient
        }

        public void saveIngrediant(Ingredient ingredient)
        {
            //TODO: save ingredient
        }

    }
}
