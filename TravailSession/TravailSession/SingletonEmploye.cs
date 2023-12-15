using Microsoft.WindowsAppSDK.Runtime.Packages;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravailSession
{
    internal class SingletonEmploye
    {
        MySqlConnection con = new MySqlConnection("Server=cours.cegep3r.info;Database=database1(placeholder);Uid=2003317;Pwd=2003317;");

        ObservableCollection<Employe> liste;
        static SingletonEmploye instance = null;

        public SingletonEmploye()
        {
            liste = new ObservableCollection<Employe>();
            liste.Add(new Employe { Matricule = "147423547", Nom = "dfdbrsb", Prenom = "gsfsfefsg", DateNaissance = DateTime.Now.Date, Email = "jonathangsxm@gmail.com", Adresse = "HFGBFDGB", DateEmbauche = DateTime.Now.Date, TauxHoraire = 20, PhotoIdentite = "dfvsfsf", Statut = "Permanent"});
            liste.Add(new Employe { Matricule = "147423547", Nom = "dfdbrsb", Prenom = "gsfsfefsg", DateNaissance = DateTime.Now.Date, Email = "svsvsvv", Adresse = "HFGBFDGB", DateEmbauche = DateTime.Now.Date, TauxHoraire = 20, PhotoIdentite = "dfvsfsf", Statut = "Permanent"});
            liste.Add(new Employe { Matricule = "147423547", Nom = "dfdbrsb", Prenom = "gsfsfefsg", DateNaissance = DateTime.Now.Date, Email = "bongbong@gmail.com", Adresse = "HFGBFDGB", DateEmbauche = DateTime.Now.Date, TauxHoraire = 20, PhotoIdentite = "dfvsfsf", Statut = "Permanent"});
            liste.Add(new Employe { Matricule = "147423547", Nom = "dfdbrsb", Prenom = "gsfsfefsg", DateNaissance = DateTime.Now.Date, Email = "svsvsvv", Adresse = "HFGBFDGB", DateEmbauche = DateTime.Now.Date, TauxHoraire = 20, PhotoIdentite = "dfvsfsf", Statut = "Permanent"});
            liste.Add(new Employe { Matricule = "147423547", Nom = "dfdbrsb", Prenom = "gsfsfefsg", DateNaissance = DateTime.Now.Date, Email = "svsvsvv", Adresse = "HFGBFDGB", DateEmbauche = DateTime.Now.Date, TauxHoraire = 20, PhotoIdentite = "dfvsfsf", Statut = "Permanent"});
            liste.Add(new Employe { Matricule = "147423547", Nom = "dfdbrsb", Prenom = "gsfsfefsg", DateNaissance = DateTime.Now.Date, Email = "svsvsvv", Adresse = "HFGBFDGB", DateEmbauche = DateTime.Now.Date, TauxHoraire = 20, PhotoIdentite = "dfvsfsf", Statut = "Permanent"});
            liste.Add(new Employe { Matricule = "147423547", Nom = "dfdbrsb", Prenom = "gsfsfefsg", DateNaissance = DateTime.Now.Date, Email = "svsvsvv", Adresse = "HFGBFDGB", DateEmbauche = DateTime.Now.Date, TauxHoraire = 20, PhotoIdentite = "dfvsfsf", Statut = "Permanent"});
            liste.Add(new Employe { Matricule = "147423547", Nom = "dfdbrsb", Prenom = "gsfsfefsg", DateNaissance = DateTime.Now.Date, Email = "svsvsvv", Adresse = "HFGBFDGB", DateEmbauche = DateTime.Now.Date, TauxHoraire = 20, PhotoIdentite = "dfvsfsf", Statut = "Permanent"});
        }

        public static SingletonEmploye getInstance()
        {
            if (instance == null)
                instance = new SingletonEmploye();

            return instance;
        }

        public ObservableCollection<Employe> GetListeEmployes()
        {

            //Enlever les commentaires plus tard quand la BD est la

            //liste.Clear();

            //MySqlCommand commande = new MySqlCommand("p_get_liste_employes");
            //commande.Connection = con;
            //commande.CommandType = System.Data.CommandType.StoredProcedure;

            //con.Open();

            //MySqlDataReader r = commande.ExecuteReader();

            //while (r.Read())
            //{
            //    string matricule = (string)r["matricule"];
            //    string nom = (string)r["nom"];
            //    string prenom = (string)r["prenom"];
            //    DateTime dateNaissance = (DateTime)r["dateNaissance"];
            //    string email = (string)r["email"];
            //    string adresse = (string)r["adresse"];
            //    DateTime dateEmbauche = (DateTime)r["dateEmbauche"];
            //    double tauxHoraire = (double)r["tauxHoraire"];
            //    string photoIdentite = (string)r["photoIdentite"];
            //    string statut = (string)r["statut"];

            //    Employe employe = new Employe { Matricule = matricule, Nom = nom, Prenom = prenom,
            //        DateNaissance = dateNaissance, Email = email, Adresse = adresse, DateEmbauche = dateEmbauche,
            //        TauxHoraire = tauxHoraire, PhotoIdentite = photoIdentite, Statut = statut };

            //    liste.Add(employe);
            //}

            //r.Close();

            //con.Close();

            return liste;
        }

        public void Ajouter(Employe employe)
        {

            MySqlCommand commande = new MySqlCommand("p_ajouter_employe");
            commande.Connection = con;
            commande.CommandType = System.Data.CommandType.StoredProcedure;
            commande.Parameters.AddWithValue("p_Matricule", $"{employe.Matricule}");
            commande.Parameters.AddWithValue("p_Nom", $"{employe.Nom}");
            commande.Parameters.AddWithValue("p_Prenom", $"{employe.Prenom}");
            commande.Parameters.AddWithValue("p_DateNaissance", $"{employe.DateNaissance}");
            commande.Parameters.AddWithValue("p_Email", $"{employe.Email}");
            commande.Parameters.AddWithValue("p_Adresse", $"{employe.Adresse}");
            commande.Parameters.AddWithValue("p_DateEmbauche", $"{employe.DateEmbauche}");
            commande.Parameters.AddWithValue("p_TauxHoraire", $"{employe.TauxHoraire}");
            commande.Parameters.AddWithValue("p_PhotoIdentite", $"{employe.PhotoIdentite}");
            commande.Parameters.AddWithValue("p_Statut", $"{employe.Statut}");
            con.Open();
            commande.Prepare();
            int i = commande.ExecuteNonQuery();

            con.Close();
        }

        public void Modifier(Employe employe, string attribut, string nouvelleValeur)
        {

            MySqlCommand commande = new MySqlCommand("p_modifier_employe");
            commande.Connection = con;
            commande.CommandType = System.Data.CommandType.StoredProcedure;
            commande.Parameters.AddWithValue("p_Matricule", $"{employe.Matricule}");
            commande.Parameters.AddWithValue("p_attribut", $"{attribut}");
            commande.Parameters.AddWithValue("p_attribut", $"{nouvelleValeur}");

            con.Open();
            commande.Prepare();
            int i = commande.ExecuteNonQuery();

            con.Close();
        }

        public void ChangerStatut(Employe employe)
        {

            MySqlCommand commande = new MySqlCommand("p_changer_statut");
            commande.Connection = con;
            commande.CommandType = System.Data.CommandType.StoredProcedure;
            commande.Parameters.AddWithValue("p_Matricule", $"{employe.Matricule}");

            con.Open();
            commande.Prepare();
            int i = commande.ExecuteNonQuery();

            con.Close();
        }

        public void ModifierInformations(Employe employe, string nouveauNom, string nouveauPrenom, string nouvelEmail, string nouvelleAdresse, double nouveauTauxHoraire, string nouvellePhotoIdentite, string nouveauStatut)
        {
            MySqlCommand commande = new MySqlCommand("p_modifier_informations_employe");
            commande.Connection = con;
            commande.CommandType = System.Data.CommandType.StoredProcedure;
            commande.Parameters.AddWithValue("p_Matricule", employe.Matricule);
            commande.Parameters.AddWithValue("p_NouveauNom", nouveauNom);
            commande.Parameters.AddWithValue("p_NouveauPrenom", nouveauPrenom);
            commande.Parameters.AddWithValue("p_NouvelEmail", nouvelEmail);
            commande.Parameters.AddWithValue("p_NouvelleAdresse", nouvelleAdresse);
            commande.Parameters.AddWithValue("p_NouveauTauxHoraire", nouveauTauxHoraire);
            commande.Parameters.AddWithValue("p_NouvellePhotoIdentite", nouvellePhotoIdentite);
            commande.Parameters.AddWithValue("p_NouveauStatut", nouveauStatut);

            con.Open();
            commande.Prepare();
            int i = commande.ExecuteNonQuery();

            con.Close();
        }

    }
}
