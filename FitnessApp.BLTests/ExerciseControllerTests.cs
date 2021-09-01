using System;
using System.Linq;
using FitnessApp.BL.Controller;
using FitnessApp.BL.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FitnessApp.BLTests
{
    [TestClass]
    public class ExerciseControllerTests
    {
        [TestMethod]
        public void AddTest()
        {
            var userName = Guid.NewGuid().ToString();
            var activityName = Guid.NewGuid().ToString();
            var rnd = new Random();
            var userController = new UserController(userName);
            var exerciseController = new ExerciseController(userController.CurrentUser);
            var activity = new Activity(activityName, rnd.Next(10, 50));

            exerciseController.Add(activity, DateTime.Now, DateTime.Now.AddHours(1));
            
            Assert.AreEqual(activityName, exerciseController.Activities.First().Name);
        }
    }
}