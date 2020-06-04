using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRecept.Models
{
    public class Ingredient
    {

        private int id;
        private int amount;
        private string title;

        public Ingredient(int id, int amount, string title)
        {
            this.id = id;
            this.amount = amount;
            this.title = title;
        }

        public int Id { get => id; set => id = value; }
        public int Amount { get => amount; set => amount = value; }
        public string Title { get => title; set => title = value; }
    }
}
