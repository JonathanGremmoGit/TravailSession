﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravailSession
{
    internal class SingletonClient
    {
        MySqlConnection con = new MySqlConnection("Server=cours.cegep3r.info;Database=a2023_420325ri_fabeq15;Uid=1842975;Pwd=1842975;");

        ObservableCollection<Client> liste;
        static SingletonClient instance = null;

        public SingletonClient()
        {
            liste = new ObservableCollection<Client>();
            liste.Add(new Client { Identifiant = 100, Nom = "Robot", Adresse = "Library", NumeroTelephone = "819-101-0101", Email = "bookburner@gmail.com" });
            liste.Add(new Client { Identifiant = 101, Nom = "Lolan", Adresse = "District 9", NumeroTelephone = "819-609-0341", Email = "grade9@gmail.com" });
            liste.Add(new Client { Identifiant = 420, Nom = "Nutsack", Adresse = "District 12", NumeroTelephone = "819-420-6969", Email = "stoner@gmail.com" });
            liste.Add(new Client { Identifiant = 600, Nom = "BongBong", Adresse = "District 12", NumeroTelephone = "819-050-5050", Email = "bong@gmail.com" });
            liste.Add(new Client { Identifiant = 600, Nom = "BongBong", Adresse = "District 12", NumeroTelephone = "819-050-5050", Email = "bong@gmail.com" });
            liste.Add(new Client { Identifiant = 600, Nom = "BongBong", Adresse = "District 12", NumeroTelephone = "819-050-5050", Email = "bong@gmail.com" });
            liste.Add(new Client { Identifiant = 600, Nom = "BongBong", Adresse = "District 12", NumeroTelephone = "819-050-5050", Email = "bong@gmail.com" });
            liste.Add(new Client { Identifiant = 600, Nom = "BongBong", Adresse = "District 12", NumeroTelephone = "819-050-5050", Email = "bong@gmail.com" });
            liste.Add(new Client { Identifiant = 600, Nom = "BongBong", Adresse = "District 12", NumeroTelephone = "819-050-5050", Email = "bong@gmail.com" });
            liste.Add(new Client { Identifiant = 600, Nom = "BongBong", Adresse = "District 12", NumeroTelephone = "819-050-5050", Email = "bong@gmail.com" });
            liste.Add(new Client { Identifiant = 600, Nom = "BongBong", Adresse = "District 12", NumeroTelephone = "819-050-5050", Email = "bong@gmail.com" });
            liste.Add(new Client { Identifiant = 600, Nom = "BongBong", Adresse = "District 12", NumeroTelephone = "819-050-5050", Email = "bong@gmail.com" });
            liste.Add(new Client { Identifiant = 600, Nom = "BongBong", Adresse = "District 12", NumeroTelephone = "819-050-5050", Email = "bong@gmail.com" });
            liste.Add(new Client { Identifiant = 600, Nom = "BongBong", Adresse = "District 12", NumeroTelephone = "819-050-5050", Email = "bong@gmail.com" });
            liste.Add(new Client { Identifiant = 600, Nom = "BongBong", Adresse = "District 12", NumeroTelephone = "819-050-5050", Email = "bong@gmail.com" });
        }

        public static SingletonClient getInstance()
        {
            if (instance == null)
                instance = new SingletonClient();

            return instance;
        }

        public ObservableCollection<Client> GetListeClients()
        {

            liste.Clear();

            MySqlCommand commande = new MySqlCommand("p_get_liste_clients");
            commande.Connection = con;
            commande.CommandType = System.Data.CommandType.StoredProcedure;

            con.Open();

            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {
                int identifiant = (int)r["identifiant"];
                string nom = (string)r["nom"];
                string adresse = (string)r["adresse"];
                string numeroTelephone = (string)r["numeroTelephone"];
                string email = (string)r["email"];

                Client client = new Client
                {
                    Identifiant = identifiant,
                    Nom = nom,
                    Adresse = adresse,
                    NumeroTelephone = numeroTelephone,
                    Email = email
                };

                liste.Add(client);
            }

            r.Close();

            con.Close();

            return liste;
        }

        public void Ajouter(Client client)
        {

            MySqlCommand commande = new MySqlCommand("p_ajouter_client");
            commande.Connection = con;
            commande.CommandType = System.Data.CommandType.StoredProcedure;
            commande.Parameters.AddWithValue("p_Identifiant", $"{client.Identifiant}");
            commande.Parameters.AddWithValue("p_Nom", $"{client.Nom}");
            commande.Parameters.AddWithValue("p_Adresse", $"{client.Adresse}");
            commande.Parameters.AddWithValue("p_NumeroTelephone", $"{client.NumeroTelephone}");
            commande.Parameters.AddWithValue("p_Email", $"{client.Email}");

            con.Open();
            commande.Prepare();
            int i = commande.ExecuteNonQuery();

            con.Close();
        }

    }
}
