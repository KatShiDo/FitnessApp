using System;
using System.Reflection.Metadata;
using FitnessApp.BL.Controller;
using FitnessApp.BL.Model;

namespace FitnessApp.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("FitnessApp\nEnter user name: ");

            var name = Console.ReadLine();
            
            var userController = new UserController(name);

            if (userController.IsNewUser)
            {
                Console.Write("Enter user's gender: ");
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime();
                var weight = ParseDouble("weight");
                var height = ParseDouble("height");

                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);
        }

        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write("Enter user's birth date (DD.MM.YYYY): ");
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