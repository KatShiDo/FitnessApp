using System;

namespace FitnessApp.BL.Model
{
    public class Gender
    {
        private string Name { get; }

        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name), "Gender name cannot be empty");
            }

            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}