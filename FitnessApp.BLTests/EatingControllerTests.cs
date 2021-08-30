using System;
using System.Linq;
using FitnessApp.BL.Controller;
using FitnessApp.BL.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FitnessApp.BLTests
{
    [TestClass]
    public class EatingControllerTests
    {
        [TestMethod]
        public void AddTest()
        {
            var userName = Guid.NewGuid().ToString();
            var foodName = Guid.NewGuid().ToString();
            var rnd = new Random();
            var userController = new UserController(userName);
            var eatingController = new EatingController(userController.CurrentUser);
            var food = new Food(foodName, rnd.Next(50, 500),
                rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500));

            eatingController.Add(food, 100);
            
            Assert.AreEqual(food.Name, eatingController.Eating.Foods.First().Key.Name);
        }
    }
}