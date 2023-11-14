using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravailSession
{
    internal class Employe
    {
        public string Matricule { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public string Email { get; set; }
        public string Adresse { get; set; }
        public DateTime DateEmbauche { get; set; }
        public double TauxHoraire { get; set; }
        public string PhotoIdentite { get; set; }
        public string Statut { get; set; }
    }
}
