using MySql.Data.MySqlClient;
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
        MySqlConnection con = new MySqlConnection("Server=localhost;Database=exointerfacemaison2;Uid=root;Pwd=;");

        ObservableCollection<Client> liste;
        static SingletonClient instance = null;

        public SingletonClient()
        {
            liste = new ObservableCollection<Client>();
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
