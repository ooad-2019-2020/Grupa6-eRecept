using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRecept.Models
{
    public class Direction
    {

        private int recipeId;
        private int stepNumber;
        private string text;
        private double stepDuration;

        public Direction(int recipeId, int stepNumber, string text, double stepDuration)
        {
            this.recipeId = recipeId;
            this.stepNumber = stepNumber;
            this.text = text;
            this.stepDuration = stepDuration;
        }

        public int RecipeId { get => recipeId; set => recipeId = value; }
        public int StepNumber { get => stepNumber; set => stepNumber = value; }
        public string Text { get => text; set => text = value; }
        public double StepDuration { get => stepDuration; set => stepDuration = value; }

    }
}
