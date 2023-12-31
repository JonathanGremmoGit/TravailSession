﻿using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravailSession
{
    internal class SingletonProjet
    {
        MySqlConnection con = new MySqlConnection("Server=cours.cegep3r.info;Database=a2023_420325ri_fabeq15;Uid=1842975;Pwd=1842975;");

        ObservableCollection<Projet> liste;
        static SingletonProjet instance = null;

        public SingletonProjet()
        {
            liste = new ObservableCollection<Projet>();
        }

        public static SingletonProjet getInstance()
        {
            if (instance == null)
                instance = new SingletonProjet();

            return instance;
        }

        public Projet getProjet(int position)
        {
            return liste[position];
        }

        public void AjouterProjet(Projet projet)
        {
            MySqlCommand commande = new MySqlCommand("p_ajouter_projet");
            commande.Connection = con;
            commande.CommandType = System.Data.CommandType.StoredProcedure;
            commande.Parameters.AddWithValue("p_NumeroProjet", $"{projet.NumeroProjet}");
            commande.Parameters.AddWithValue("p_Titre", $"{projet.Titre}");
            commande.Parameters.AddWithValue("p_DateDebut", projet.DateDebut);
            commande.Parameters.AddWithValue("p_Description", $"{projet.Description}");
            commande.Parameters.AddWithValue("p_Budget", projet.Budget);
            commande.Parameters.AddWithValue("p_NombreEmployesRequis", projet.NombreEmployesRequis);
            commande.Parameters.AddWithValue("p_ClientIdentifiant", projet.ClientIdentifiant);
            commande.Parameters.AddWithValue("p_TotalSalairesPayer", projet.TotalSalairesPayer);
            commande.Parameters.AddWithValue("p_Statut", $"{projet.Statut}");

            con.Open();
            commande.Prepare();
            int i = commande.ExecuteNonQuery();

            con.Close();
        }


        public ObservableCollection<Projet> GetListeProjets()
        {

            liste.Clear();

            MySqlCommand commande = new MySqlCommand("p_get_liste_projets");
            commande.Connection = con;
            commande.CommandType = System.Data.CommandType.StoredProcedure;

            con.Open();

            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {
                string numeroProjet = (string)r["numeroProjet"];
                string titre = (string)r["titre"];
                DateTime dateDebut = (DateTime)r["dateDebut"];
                string description = (string)r["description"];
                decimal budget = (decimal)r["budget"];
                int nombreEmployesRequis = (int)r["nombreEmployesRequis"];
                decimal totalSalairesPayer = (decimal)r["totalSalairesPayer"];
                int clientIdentifiant = (int)r["clientIdentifiant"];
                string statut = (string)r["statut"];

                Projet projet = new Projet
                {
                    NumeroProjet = numeroProjet,
                    Titre = titre,
                    DateDebut = dateDebut,
                    Description = description,
                    Budget = budget,
                    NombreEmployesRequis = nombreEmployesRequis,
                    TotalSalairesPayer = totalSalairesPayer,
                    ClientIdentifiant = clientIdentifiant,
                    Statut = statut
                };

                liste.Add(projet);
            }

            r.Close();

            con.Close();

            return liste;
        }

        public void AssignerEmployeAProjet(int projetNumero, Employe employe)
        {
            MySqlCommand commande = new MySqlCommand("p_assigner_employe_projet");
            commande.Connection = con;
            commande.CommandType = System.Data.CommandType.StoredProcedure;
            commande.Parameters.AddWithValue("p_ProjetNumero", projetNumero);
            commande.Parameters.AddWithValue("p_MatriculeEmploye", employe.Matricule);

            con.Open();
            commande.Prepare();
            int i = commande.ExecuteNonQuery();

            con.Close();
        }

        public ObservableCollection<Employe> GetListeEmployesPourProjet(int projetNumero)
        {
            ObservableCollection<Employe> employes = new ObservableCollection<Employe>();

            using (MySqlCommand commande = new MySqlCommand("p_get_liste_employes_projet", con))
            {
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                commande.Parameters.AddWithValue("p_ProjetNumero", projetNumero);

                con.Open();

                using (MySqlDataReader r = commande.ExecuteReader())
                {
                    while (r.Read())
                    {
                        string matricule = (string)r["matricule"];
                        string nom = (string)r["nom"];
                        string prenom = (string)r["prenom"];
                        DateTime dateNaissance = (DateTime)r["dateNaissance"];
                        string email = (string)r["email"];
                        string adresse = (string)r["adresse"];
                        DateTime dateEmbauche = (DateTime)r["dateEmbauche"];
                        double tauxHoraire = (double)r["tauxHoraire"];
                        string photoIdentite = (string)r["photoIdentite"];
                        string statut = (string)r["statut"];

                        Employe employe = new Employe
                        {
                            Matricule = matricule,
                            Nom = nom,
                            Prenom = prenom,
                            DateNaissance = dateNaissance,
                            Email = email,
                            Adresse = adresse,
                            DateEmbauche = dateEmbauche,
                            TauxHoraire = tauxHoraire,
                            PhotoIdentite = photoIdentite,
                            Statut = statut
                        };

                        employes.Add(employe);
                    }
                }
            }

            return employes;
        }

        public decimal CalculerTotalSalairesPourProjet(int projetNumero)
        {
            decimal totalSalaires = 0;

            using (MySqlCommand commande = new MySqlCommand("p_calculer_total_salaires_projet", con))
            {
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                commande.Parameters.AddWithValue("p_ProjetNumero", projetNumero);

                con.Open();

                using (MySqlDataReader r = commande.ExecuteReader())
                {
                    while (r.Read())
                    {
                        totalSalaires = (decimal)r["totalSalaires"];
                    }
                }
            }

            con.Close();

            return totalSalaires;
        }

        public bool ClientExiste(int clientIdentifiant)
        {
            bool existe = false;
            string query = "SELECT COUNT(*) FROM Client WHERE Identifiant = @clientIdentifiant";

            using (MySqlCommand cmd = new MySqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@clientIdentifiant", clientIdentifiant);
                con.Open();

                existe = Convert.ToInt32(cmd.ExecuteScalar()) > 0;

                con.Close();
            }
            
            return existe;
        }



    }
}
