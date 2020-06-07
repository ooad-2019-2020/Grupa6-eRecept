using eRecept.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRecept.Repositories
{
    [System.ComponentModel.DataAnnotations.Schema.Table("Ingredients")]
    public class IngredientRepository:DbContext
    {
        public IngredientRepository(DbContextOptions<IngredientRepository> options) : base(options)
        {
        }

        IngredientRepository() { }

        public DbSet<Ingredient> Ingredients { get; set; }

        [HttpGet]
        public List<Ingredient> getAllIngredients()
        {
            //TODO: return all ingredients from database
            return new List<Ingredient>(this.Ingredients);        
        }

        public Ingredient getIngredient(int ingredientId)
        {
            //TODO: return ingredient by its id
            return this.Ingredients.Find(ingredientId);
        }
        public Ingredient getIngredient(String ingredientName)
        {

            if (!this.Ingredients.Any(i => i.Title == ingredientName))
                this.insertIngredient(new Ingredient(0, 1, ingredientName));
            

            return this.Ingredients.Where(i => i.Title == ingredientName).First();
        }

        public void insertIngredient(Ingredient ingredient)
        {

            this.Add(ingredient);
            this.SaveChanges();

            //this.Ingredients.Add(ingredient);
            //TODO: insert ingredient into the database
        }

        public void insertIngredients(List<Ingredient> ingredients)
        {
            //TODO: add all ingredients
            //maybe this
            foreach (Ingredient i in ingredients) this.Add(i);
            this.SaveChanges();
        }

        public void deleteIngredient(int ingredientId)
        {
            this.Remove(ingredientId);
            this.SaveChanges();
            //TODO: delete ingredient from database by its id
        }

        public void updateIngredient(Ingredient ingredient)
        {
            this.updateIngredient(ingredient);
            this.SaveChanges();
            //TODO: update ingredient from database
        }


    }
}