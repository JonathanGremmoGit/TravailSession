using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravailSession
{
    internal class SingletonEmployeValidation
    {
        static SingletonEmployeValidation instance;

        public SingletonEmployeValidation() { }

        public static SingletonEmployeValidation getInstance()
        {
            if (instance == null)
                instance = new SingletonEmployeValidation();

            return instance;
        }

        public bool isNomValide(string nom)
        {
            if (!string.IsNullOrEmpty(nom.Trim()))
                return true;
            else
                return false;
        }

        public bool isPrenomValide(string prenom)
        {
            if (!string.IsNullOrEmpty(prenom.Trim()))
                return true;
            else
                return false;
        }

        public bool isDateNaissanceValide(int dateNaissance)
        {
            if(dateNaissance != 1600)
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

        public bool isAdresseValide(string adresse)
        {
            if (!string.IsNullOrEmpty(adresse.Trim()))
                return true;
            else
                return false;
        }

        public bool isDateEmbaucheValide(int dateEmbauche)
        {
            if (dateEmbauche != 1600)
                return true;
            else
                return false;
        }

        public bool isTauxHoraireValid(double tauxHoraire)
        {
            if (tauxHoraire >= 15)
                return true;
            else
                return false;
        }











    }
}
