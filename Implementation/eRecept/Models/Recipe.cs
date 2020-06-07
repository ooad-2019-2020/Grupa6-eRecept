using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace eRecept.Models
{
    public class Recipe
    {


        public Recipe(int id, string title, string description, string mealType, string sideNote)
        {
            Id = id;
            Title = title;
            Description = description;
            MealType = mealType;
            SideNote = sideNote;
        }


        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Title { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Description { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string MealType { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string SideNote { get; set; }
        
    

    }


}
