using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
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
    public sealed partial class PageModifierEmploye : Page
    {
        int index = -1;
        public PageModifierEmploye()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is not null)
            {
                index = (int)e.Parameter;
                Employe employe = SingletonEmploye.getInstance().getEmploye(index);

                tbxModifierNomEmploye.Text = employe.Nom;
                tbxModifierPrenomEmploye.Text = employe.Prenom;
                tbxModifierEmailEmploye.Text = employe.Email;
                tbxModifierAdresseEmploye.Text = employe.Adresse;
                nbxModifierTauxHoraireEmploye.Text = employe.TauxHoraire.ToString();
                tbxModifierPhotoIdentiteEmploye.Text = employe.PhotoIdentite;
            }
        }

        private void btConfirmerModifierEmploye_Click(object sender, RoutedEventArgs e)
        {
            resetErreurs();
            bool valide = true;

            if (SingletonEmployeValidation.getInstance().isNomValide(tbxModifierNomEmploye.Text) == false)
            {
                tblModifierNomEmployeErreur.Text = "Veuillez entrer un nom";
                valide = false;
            }

            if (SingletonEmployeValidation.getInstance().isPrenomValide(tbxModifierPrenomEmploye.Text) == false)
            {
                tblModifierPrenomEmployeErreur.Text = "Veuillez entrer un prénom";
                valide = false;
            }

            if (SingletonEmployeValidation.getInstance().isEmailValide(tbxModifierEmailEmploye.Text) == false)
            {
                tblModifierEmailEmployeErreur.Text = "Veuillez entrer une adresse email";
                valide = false;
            }

            if (SingletonEmployeValidation.getInstance().isAdresseValide(tbxModifierAdresseEmploye.Text) == false)
            {
                tblModifierAdresseEmployeErreur.Text = "Veuillez entrer une adresse";
                valide = false;
            }

            if (SingletonEmployeValidation.getInstance().isTauxHoraireValid(nbxModifierTauxHoraireEmploye.Value) == false)
            {
                tblModifierTauxHoraireEmployeErreur.Text = "Veuillez entrer une valeur valide";
                valide = false;
            }

            if (SingletonEmployeValidation.getInstance().isPhotoIdentiteValide(tbxModifierPhotoIdentiteEmploye.Text) == false)
            {
                tblModifierPhotoIdentiteEmployeErreur.Text = "Veuillez entrer une URL d'image";
                valide = false;
            }

            if (SingletonEmployeValidation.getInstance().isStatusValide(brModifierStatus.SelectedIndex) == false)
            {
                tblModifierStatusEmployeErreur.Text = "Veuillez choisir un status";
                valide = false;
            }

            if (valide == true)
            {
                Employe employe = new Employe
                {
                    Nom = tbxModifierNomEmploye.Text,
                    Prenom = tbxModifierPrenomEmploye.Text,
                    Email = tbxModifierEmailEmploye.Text,
                    Adresse = tbxModifierAdresseEmploye.Text,
                    TauxHoraire = double.Parse(nbxModifierTauxHoraireEmploye.Text),
                    PhotoIdentite = tbxModifierPhotoIdentiteEmploye.Text,
                    Statut = brModifierStatus.SelectedItem.ToString(),
                };

                SingletonEmploye.getInstance().modifier(index, employe);

                this.Frame.Navigate(typeof(PageListeEmploye));
            }

        }

        private void resetErreurs()
        {
            tblModifierNomEmployeErreur.Text = string.Empty;
            tblModifierPrenomEmployeErreur.Text = string.Empty;
            tblModifierEmailEmployeErreur.Text = string.Empty;
            tblModifierAdresseEmployeErreur.Text = string.Empty;
            tblModifierTauxHoraireEmployeErreur.Text = string.Empty;
            tblModifierPhotoIdentiteEmployeErreur.Text = string.Empty;
            tblModifierStatusEmployeErreur.Text = string.Empty;
        }

    }
}
