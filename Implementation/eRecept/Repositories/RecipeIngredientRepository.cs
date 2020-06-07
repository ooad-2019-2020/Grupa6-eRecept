using eRecept.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRecept.Repositories
{

    [System.ComponentModel.DataAnnotations.Schema.Table("RecipeIngredient")]
    public class RecipeIngredientRepository:DbContext
    {

        public RecipeIngredientRepository(DbContextOptions<RecipeIngredientRepository> options) : base(options)
        {
        }

        public DbSet<RecipeIngredientRepository> RecipeIngredients { get; set; }

        public List<RecipeIngredientRepository> getAllRecipeIngredients()
        {
            return new List<RecipeIngredientRepository>(this.RecipeIngredients);
        }

        public List<RecipeIngredientWrapper> getAllRecipesWithIngredients(List<Ingredient> ingredients)
        {


          //  this.RecipeIngredients.FromSqlRaw

            return null;
        }



    }
}
