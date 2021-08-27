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
            Console.WriteLine("FitnessApp\nEnter user name:");

            var name = Console.ReadLine();

            Console.WriteLine("Enter user's gender:");
            var gender = Console.ReadLine();

            Console.WriteLine("Enter user's birth date:");
            var birthDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter user's weight");
            var weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter user's height");
            var height = double.Parse(Console.ReadLine());

            var userController = new UserController(name, gender, birthDate, weight, height);
            userController.Save();
        }
    }
}