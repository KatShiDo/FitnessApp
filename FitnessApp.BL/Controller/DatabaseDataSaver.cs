using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using FitnessApp.BL.Model;

namespace FitnessApp.BL.Controller
{
    public class DatabaseDataSaver : IDataSaver
    {
        public void Save<T>(List<T> item) where T : class
        {
            using (var db = new FitnessContext())
            {
                db.Set<T>().AddRange(item);
                db.SaveChanges();
            }
        }

        public List<T> Load<T>() where T : class
        {
            using (var db = new FitnessContext())
            {
                return db.Set<T>().Where(l => true).ToList();
            }
        }
    }
}