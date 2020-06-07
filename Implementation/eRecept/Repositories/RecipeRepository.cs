using eRecept.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRecept.Repositories
{
    [System.ComponentModel.DataAnnotations.Schema.Table("Recipes")]
    public class RecipeRepository:DbContext
    {

        public RecipeRepository(DbContextOptions<RecipeRepository> options) : base(options)
        {
        }


        public DbSet<Recipe> Recipes { get; set; }

        public List<Recipe> getAllRecipes()
        {
             return new List<Recipe>(this.Recipes);
        }

        public Recipe getRecipe(int id)
        {
            return this.Recipes.Find(id);
            //TODO: return recipe by its id
        }

        public void insertRecipe(Recipe recipe)
        {

            this.Add(recipe);

            //TODO: insert recipe into the database
        }

        public void deleteRecipe(int id)
        {
            this.Remove(id);
            //TODO: delete recipe from database using its id
        }

        public void updateRecipe(Recipe recipe)
        {
            this.Update(recipe);
            //TODO: update recipe using its id
        }

        public List<Recipe> getFilteredRecipes(String mealType, String recipeTag)
        {

            //TODO: get recipes from database by its mealType and recipeTag
            List<Recipe> returnRecipes = new List<Recipe>();
            return returnRecipes;
        }

        public List<Recipe> getSavedRecipes(int userId)
        {
            //TODO: get saved recipes of a specific user
            List<Recipe> returnRecipes = new List<Recipe>();
            return returnRecipes;
        }

        public int saveRecipeForUser(int userId, int recipeId)
        {

            //TODO: check if user has thhe recipe
            //has-> return 0
            //doesnt-> save it and return 1

            return 0;

        }





    }
}