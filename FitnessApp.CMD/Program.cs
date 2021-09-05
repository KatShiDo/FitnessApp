using System;
using System.Globalization;
using System.Resources;
using FitnessApp.BL.Controller;
using FitnessApp.BL.Model;

namespace FitnessApp.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("en");
            var resourceManager = new ResourceManager("FitnessApp.CMD.Languages.Messages", typeof(Program).Assembly);
            
            Console.Write(resourceManager.GetString("Hello", culture) + '\n' + resourceManager.GetString("EnterName", culture));

            var name = Console.ReadLine();
            
            var userController = new UserController(name);
            
            if (userController.IsNewUser)
            {
                Console.Write(resourceManager.GetString("EnterGender", culture));
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime("user's birth date");
                var weight = ParseDouble("weight");
                var height = ParseDouble("height");

                userController.SetNewUserData(gender, birthDate, weight, height);
            }
            
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);

            Console.WriteLine(userController.CurrentUser);

            while (true)
            {
                Console.WriteLine("Choose action\nE - enter eating\nA - enter exercise\n" +
                                  "Q - quit");
                var key = Console.ReadKey();
                Console.WriteLine();
                
                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterEating();
                        eatingController.Add(foods.Food, foods.Weight);

                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t{item.Key} - {item.Value}");
                        }
                        break;
                    case ConsoleKey.A:
                        var exe = EnterExercise();
                        exerciseController.Add(exe.Activity, exe.Begin, exe.End);

                        foreach (var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"\t{item.Activity} from {item.Start.ToShortTimeString()}" +
                                              $" to {item.Finish.ToShortTimeString()}");
                        }
                        
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        private static (DateTime Begin, DateTime End, Activity Activity) EnterExercise()
        {
            Console.WriteLine("Enter the name of exercise: ");
            var name = Console.ReadLine();

            var energy = ParseDouble("energy consumption per minute");

            var begin = ParseDateTime("exercise start time");
            var end = ParseDateTime("exercise end time");

            var activity = new Activity(name, energy);
            return new (begin, end, activity);
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("Enter product name: ");
            var food = Console.ReadLine();

            var calories = ParseDouble("calories");
            var proteins = ParseDouble("proteins");
            var fats = ParseDouble("fats");
            var carbohydrates = ParseDouble("carbohydrates");
            
            var weight = ParseDouble("weight of the portion");
            var product = new Food(food, calories, proteins, fats, carbohydrates);

            return (product, weight);
        }

        private static DateTime ParseDateTime(string value)
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write($"Enter {value} (DD.MM.YYYY): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect date format");
                }
            }

            return birthDate;
        }
        
        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Enter {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Incorrect {name} format");
                }
            }
        }
    }
}