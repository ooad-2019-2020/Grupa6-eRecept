using eRecept.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace eRecept.Repositories
{

    [System.ComponentModel.DataAnnotations.Schema.Table("RecipeIngredients")]
    public class RecipeIngredientRepository:DbContext
    {

        public RecipeIngredientRepository(DbContextOptions<RecipeIngredientRepository> options) : base(options)
        {
        }

        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }

        public List<RecipeIngredient> getAllRecipeIngredients()
        {
            return new List<RecipeIngredient>(this.RecipeIngredients);
        }
        

        public void addRecipeIngredient(RecipeIngredient recipeIngredient)
        {

            this.Add(recipeIngredient);
            this.SaveChanges();

        }
      

        public void removeRecipe(int recipeId)
        {

            this.RecipeIngredients.FromSqlRaw("Delete from RecipeIngredients where recipeId="+recipeId,null);
            this.SaveChanges();

        }

     




    }
}
