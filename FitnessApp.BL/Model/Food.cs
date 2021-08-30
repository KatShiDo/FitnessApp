using System;

namespace FitnessApp.BL.Model
{
    [Serializable]
    public class Food
    {
        public string Name { get; }

        public double Proteins { get; }
        public double Fats { get; }
        public double Carbohydrates { get; }
        public double Calories { get; }

        private double CaloriesOneGram => Calories / 100.0;
        private double ProteinsOneGram => Proteins / 100.0;
        private double FatsOneGram => Fats / 100.0;
        private double CarbohydratesOneGram => Carbohydrates / 100.0;

        public Food(string name) : this(name, 0, 0, 0, 0)
        {
        }

        public Food(string name, double calories, double proteins, double fats, double carbohydrates)
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