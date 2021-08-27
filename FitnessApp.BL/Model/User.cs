using System;

namespace FitnessApp.BL.Model
{
    public class User
    {
        public string Name { get; }

        public Gender Gender { get; }

        public DateTime BirthDate { get; }

        public double Weight { get; set; }

        public double Height { get; set; }

        public User(string name, Gender gender, DateTime birthDate, double weight, double height)
        {
            #region Check

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name), "User name cannot be empty");
            }

            if (birthDate < DateTime.Parse("01.01.1900") || birthDate > DateTime.Now)
            {
                throw new ArgumentOutOfRangeException(nameof(birthDate), "Incorrect birth date");
            }

            if (weight <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(weight), "Weight cannot be lower than 0");
            }

            if (height <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(height), "Height cannot be lower than 0");
            }

            #endregion

            Name = name;
            Gender = gender ?? throw new ArgumentNullException(nameof(gender), "User gender cannot be null");
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}