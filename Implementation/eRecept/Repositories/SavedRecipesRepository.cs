using eRecept.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRecept.Repositories
{
    [System.ComponentModel.DataAnnotations.Schema.Table("SavedRecipes")]
    public class SavedRecipesRepository : DbContext
    {

        public SavedRecipesRepository(DbContextOptions<SavedRecipesRepository> options) : base(options)
        {
        }

        public DbSet<SavedRecipes> SavedRecipes { get; set; }

        public List<SavedRecipes> getAllRecipeIngredients()
        {
            return this.SavedRecipes.ToList<SavedRecipes>();
        }

        public void saveRecipe(SavedRecipes savedRecipe)
        {

            this.Add(savedRecipe);
            this.SaveChanges();

        }

        public void unsaveRecipe(int userId,int recipeId)
        {

            this.SavedRecipes.FromSqlRaw("Delete from SavedRecipes where recipeId=" + recipeId+" and userId="+userId, null);
            this.SaveChanges();


        }


    }
}
