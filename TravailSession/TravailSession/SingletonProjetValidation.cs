using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravailSession
{
    internal class SingletonProjetValidation
    {
        static SingletonProjetValidation instance;

        public SingletonProjetValidation() { }

        public static SingletonProjetValidation getInstance()
        {
            if (instance == null)
                instance = new SingletonProjetValidation();

            return instance;
        }














    }
}
