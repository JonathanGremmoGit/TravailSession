using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravailSession
{
    internal class Projet
    {
        public string NumeroProjet { get; set; }
        public string Titre { get; set; }
        public DateTime DateDebut { get; set; }
        public string Description { get; set; }
        public decimal Budget { get; set; }
        public int NombreEmployesRequis { get; set; }
        public decimal TotalSalairesPayer { get; set; }
        public int ClientIdentifiant { get; set; }
        public string Statut { get; set; }
    }
}
