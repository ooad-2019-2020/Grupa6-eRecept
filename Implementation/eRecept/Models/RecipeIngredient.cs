using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace eRecept.Models
{
    public class RecipeIngredient
    {


        public RecipeIngredient(int id,int recipeId,int ingredientId, int amount)
        {
            Id = id;
            RecipeId = recipeId;
            IngredientId = ingredientId;
            Amount = amount;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public int RecipeId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public int IngredientId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public int Amount { get; set; }


    }
}
