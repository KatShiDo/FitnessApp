using System;

namespace FitnessApp.BL.Model
{
    [Serializable]
    public class Food
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public double Proteins { get; set; }
        public double Fats { get; set; }
        public double Carbohydrates { get; set; }
        public double Calories { get; set; }

        private double CaloriesOneGram => Calories / 100.0;
        private double ProteinsOneGram => Proteins / 100.0;
        private double FatsOneGram => Fats / 100.0;
        private double CarbohydratesOneGram => Carbohydrates / 100.0;

        public Food()
        {
        }

        public Food(string name, double calories = 0, double proteins = 0, double fats = 0, double carbohydrates = 0)
        {
            Name = name;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Calories = calories / 100.0;
            Carbohydrates = carbohydrates / 100.0;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}