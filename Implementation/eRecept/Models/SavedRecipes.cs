using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eRecept.Models
{
    public class SavedRecipes
    {


        public SavedRecipes(int id, int userId, int recipeId)
        {
            Id = id;
            RecipeId = recipeId;
            UserId = userId;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public int UserId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public int RecipeId { get; set; }

    }

}



    

