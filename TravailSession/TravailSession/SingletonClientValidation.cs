using MySql.Data.MySqlClient;
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

        public bool isNomValide(string nom)
        {
            if (!string.IsNullOrEmpty(nom.Trim()))
                return true;
            else
                return false;
        }

        public bool isAdresseValide(string adresse)
        {
            if (!string.IsNullOrEmpty(adresse.Trim()))
                return true;
            else
                return false;
        }

        public bool isNumeroTelephoneValide(string numeroTelephone)
        {
            if (!string.IsNullOrEmpty(numeroTelephone.Trim()))
                return true;
            else
                return false;
        }

        public bool isEmailValide(string email)
        {
            if (!string.IsNullOrEmpty(email.Trim()))
                return true;
            else
                return false;
        }
















    }
}
