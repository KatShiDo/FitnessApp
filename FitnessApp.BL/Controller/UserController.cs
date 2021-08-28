using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using FitnessApp.BL.Model;

namespace FitnessApp.BL.Controller
{
    public class UserController
    {
        public List<User> Users { get; }
        
        public User CurrentUser { get; }

        public bool IsNewUser { get; } = false;

        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException(nameof(userName), "User name cannot be empty");
            }

            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
        }

        public void Save()
        {
            var formatter = new BinaryFormatter();

            using var fs = new FileStream("users.dat", FileMode.OpenOrCreate);
            formatter.Serialize(fs, Users);
        }

        private List<User> GetUsersData()
        {
            var formatter = new BinaryFormatter();
            
            using var fs = new FileStream("users.dat", FileMode.OpenOrCreate);

            if (fs.Length > 0 && formatter.Deserialize(fs) is List<User> users)
            {
                return users;
            }
            else
            {
                return new List<User>();
            }
        }

        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1)
        {
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }
    }
}