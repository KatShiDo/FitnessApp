﻿using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using FitnessApp.BL.Model;

namespace FitnessApp.BL.Controller
{
    public abstract class ControllerBase
    {
        private IDataSaver manager = new DatabaseSaver();

        protected void Save<T>(List<T> item) where T : class
        {
            manager.Save(item);
        }

        protected List<T> Load<T>() where T : class
        {
            return manager.Load<T>();
        }
    }
}