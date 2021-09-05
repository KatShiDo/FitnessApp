using System;
using System.Collections;
using System.Collections.Generic;

namespace FitnessApp.BL.Model
{
    [Serializable]
    public class User
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public int? GenderId { get; set; }

        public virtual Gender Gender { get; set; }

        public DateTime BirthDate { get; set; } = DateTime.Now;

        public double Weight { get; set; }

        public double Height { get; set; }

        public virtual ICollection<Eating> Eatings { get; set; }
        
        public virtual ICollection<Exercise> Exercises { get; set; }

        public int Age => DateTime.Now.Year - BirthDate.Year;

        public User()
        {
        }

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

        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name), "User name cannot be empty");
            }

            Name = name;
        }

        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}