using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.WindowsAppSDK.Runtime.Packages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TravailSession
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PageAjoutClient : Page
    {
        public PageAjoutClient()
        {
            this.InitializeComponent();
        }

        private void btConfirmerAjoutClient_Click(object sender, RoutedEventArgs e)
        {
            resetErreurs();
            bool valide = true;

            if (SingletonClientValidation.getInstance().isNomValide(tbxNomClient.Text) == false)
            {
                tblNomClientErreur.Text = "Veuillez entrer un nom";
                valide = false;
            }

            if (SingletonClientValidation.getInstance().isAdresseValide(tbxAdresseClient.Text) == false)
            {
                tblAdresseClientErreur.Text = "Veuillez entrer une adresse";
                valide = false;
            }

            if (SingletonClientValidation.getInstance().isNumeroTelephoneValide(tbxNumeroTelephoneClient.Text) == false)
            {
                tblNumeroTelephoneClientErreur.Text = "Veuillez entrer un numéro de téléphone";
                valide = false;
            }

            if (SingletonClientValidation.getInstance().isEmailValide(tbxEmailClient.Text) == false)
            {
                tblEmailClientErreur.Text = "Veuillez entrer une adresse email";
                valide = false;
            }
            if (valide == true)
            {
                Client client = new Client
                {
                    Identifiant = 0,
                    Nom = tbxNomClient.Text,
                    Adresse = tbxAdresseClient.Text,
                    NumeroTelephone = tbxNumeroTelephoneClient.Text,
                    Email = tbxEmailClient.Text
                };
                SingletonClient.getInstance().Ajouter(client);
            }
        }

        private void resetErreurs()
        {
            tblNomClientErreur.Text = string.Empty;
            tblAdresseClientErreur.Text = string.Empty;
            tblNumeroTelephoneClientErreur.Text = string.Empty;
            tblEmailClientErreur.Text = string.Empty;
        }

    }
}
