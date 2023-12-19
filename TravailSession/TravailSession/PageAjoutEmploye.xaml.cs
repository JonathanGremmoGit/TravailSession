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
    public sealed partial class PageAjoutEmploye : Page
    {
        public PageAjoutEmploye()
        {
            this.InitializeComponent();

            dtpDateNaissanceEmploye.MinYear = new DateTimeOffset(new DateTime(1958, 1, 1));
            dtpDateNaissanceEmploye.MaxYear = new DateTimeOffset(new DateTime(2005, 1, 1));

            dtpDateEmbaucheEmploye.MinYear = new DateTimeOffset(new DateTime(1976, 1, 1));
            dtpDateEmbaucheEmploye.MaxYear = new DateTimeOffset(new DateTime(2023, 1, 1));
        }

        private void btConfirmerAjoutEmploye_Click(object sender, RoutedEventArgs e)
        {
            resetErreurs();
            bool valide = true;

            if (SingletonEmployeValidation.getInstance().isNomValide(tbxNomEmploye.Text) == false)
            {
                tblNomEmployeErreur.Text = "Veuillez entrer un nom";
                valide = false;
            }

            if (SingletonEmployeValidation.getInstance().isPrenomValide(tbxPrenomEmploye.Text) == false)
            {
                tblPrenomEmployeErreur.Text = "Veuillez entrer un prénom";
                valide = false;
            }

            if (SingletonEmployeValidation.getInstance().isDateNaissanceValide(dtpDateNaissanceEmploye.Date.Year) == false)
            {
                tblDateNaissanceEmployeErreur.Text = "Veuillez entrer une date";
                valide = false;
            }

            if (SingletonEmployeValidation.getInstance().isEmailValide(tbxEmailEmploye.Text) == false)
            {
                tblEmailEmployeErreur.Text = "Veuillez entrer une adresse email";
                valide = false;
            }

            if (SingletonEmployeValidation.getInstance().isAdresseValide(tbxAdresseEmploye.Text) == false)
            {
                tblAdresseEmployeErreur.Text = "Veuillez entrer une adresse";
                valide = false;
            }

            if (SingletonEmployeValidation.getInstance().isDateEmbaucheValide(dtpDateEmbaucheEmploye.Date.Year) == false)
            {
                tblDateEmbaucheEmployeErreur.Text = "Veuillez entrer une date";
                valide = false;
            }

            if (SingletonEmployeValidation.getInstance().isTauxHoraireValid(nbxTauxHoraireEmploye.Value)  == false)
            {
                tblTauxHoraireEmployeErreur.Text = "Veuillez entrer une valeur valide";
                valide = false;
            }

            if (SingletonEmployeValidation.getInstance().isPhotoIdentiteValide(tbxPhotoIdentiteEmploye.Text) == false)
            {
                tblPhotoIdentiteEmployeErreur.Text = "Veuillez entrer une URL d'image";
                valide = false;
            }

            if (SingletonEmployeValidation.getInstance().isStatusValide(brStatus.SelectedIndex) == false)
            {
                tblStatusEmployeErreur.Text = "Veuillez choisir un status";
                valide = false;
            }
            if (valide == true)
            {
                Employe employe = new Employe
                {
                    Matricule = "",
                    Nom = tbxNomEmploye.Text,
                    Prenom = tbxPrenomEmploye.Text,
                    DateNaissance = dtpDateNaissanceEmploye.Date.Date,
                    Email = tbxEmailEmploye.Text,
                    Adresse = tbxAdresseEmploye.Text,
                    DateEmbauche = dtpDateEmbaucheEmploye.Date.Date,
                    TauxHoraire = nbxTauxHoraireEmploye.Value,
                    PhotoIdentite = tbxPhotoIdentiteEmploye.Text,
                    Statut = brStatus.SelectedItem.ToString()
                };
                SingletonEmploye.getInstance().Ajouter(employe);
                this.Frame.Navigate(typeof(PageListeEmploye));
            }
        }

        private void resetErreurs()
        {
            tblNomEmployeErreur.Text = string.Empty;
            tblPrenomEmployeErreur.Text = string.Empty;
            tblDateNaissanceEmployeErreur.Text = string.Empty;
            tblEmailEmployeErreur.Text = string.Empty;
            tblAdresseEmployeErreur.Text = string.Empty;
            tblDateEmbaucheEmployeErreur.Text = string.Empty;
            tblTauxHoraireEmployeErreur.Text = string.Empty;
            tblPhotoIdentiteEmployeErreur.Text = string.Empty;
            tblStatusEmployeErreur.Text = string.Empty;
        }

    }
}
