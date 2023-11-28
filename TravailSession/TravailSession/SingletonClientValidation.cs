﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravailSession
{
    internal class SingletonClientValidation
    {
        static SingletonClientValidation instance;

        public SingletonClientValidation() { }

        public static SingletonClientValidation getInstance()
        {
            if (instance == null)
                instance = new SingletonClientValidation();

            return instance;
        }
















    }
}
