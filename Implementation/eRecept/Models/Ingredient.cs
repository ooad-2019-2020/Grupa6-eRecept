using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eRecept.Models
{
    public class Ingredient
    {
        public Ingredient(int id, int amount, string title)
        {
            Id = id;
            Amount = amount;
            Title = title;
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(5)")]
        public int Amount { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")] 
        public string Title { get; set; }
    }
}
