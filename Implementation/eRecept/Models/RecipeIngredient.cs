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

        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string recipeId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string ingredientId { get; set; }
  

    }
}
