using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using eRecept.Models;
using eRecept.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace eRecept.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IngredientController : Controller
    {
        private readonly IngredientRepository _ingredientRepository;

        public IngredientController(IngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public List<Ingredient> getAllIngredients()
        {
            return _ingredientRepository.getAllIngredients();
        }

        public Ingredient getIngredient(int ingredientId)
        {

            return _ingredientRepository.getIngredient(ingredientId);
        }

        public void deleteIngredient(int ingredientId)
        {
            _ingredientRepository.deleteIngredient(ingredientId);
        }

        public void saveIngredient(Ingredient ingredient)
        {

            _ingredientRepository.insertIngredient(ingredient);


        }

    }
}
