using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRecept.Models
{
    public class IngredientWrapper
    {

        private String name;
        private int amount;

        public IngredientWrapper(string name, int amount)
        {
            this.name = name;
            this.amount = amount;
        }

        public string Name { get => name; set => name = value; }
        public int Amount { get => amount; set => amount = value; }
    }
}
