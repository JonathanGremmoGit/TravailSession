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

        public bool isTitreValide(string titre)
        {
            if (!string.IsNullOrEmpty(titre.Trim()))
                return true;
            else
                return false;
        }

        public bool isDateDebutValide(int dateDebut)
        {
            if (dateDebut != 1600)
                return true;
            else
                return false;
        }

        public bool isDescriptionValide(string description)
        {
            if (!string.IsNullOrEmpty(description.Trim()))
                return true;
            else
                return false;
        }

        public bool isBudgetValide(string budget)
        {
            if (!string.IsNullOrEmpty(budget.Trim()))
                return true;
            else
                return false;
        }

        public bool isEmployesRequisValide(double nbEmployesRequis)
        {
            if (nbEmployesRequis <= 5)
                return true;
            else
                return false;
        }














    }
}
