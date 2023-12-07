using Google.Protobuf.WellKnownTypes;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using WinRT;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TravailSession
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PageAjoutProjet : Page
    {
        public PageAjoutProjet()
        {
            this.InitializeComponent();

            dtpDateDebutProjet.MinYear = new DateTimeOffset(new DateTime(2024, 1, 1));
        }

        private void btConfirmerAjoutProjet_Click(object sender, RoutedEventArgs e)
        {
            resetErreurs();
            bool valide = true;

            if (SingletonProjetValidation.getInstance().isTitreValide(tbxTitreProjet.Text) == false)
            {
                tblTitreProjetErreur.Text = "Veuillez entrer un titre";
                valide = false;
            }

            if (SingletonEmployeValidation.getInstance().isDateNaissanceValide(dtpDateDebutProjet.Date.Year) == false)
            {
                tblDateDebutProjetErreur.Text = "Veuillez entrer une date";
                valide = false;
            }

            if (SingletonProjetValidation.getInstance().isDescriptionValide(tbxDescriptionProjet.Text) == false)
            {
                tblDescriptionProjetErreur.Text = "Veuillez entrer une description";
                valide = false;
            }

            if (SingletonProjetValidation.getInstance().isBudgetValide(nbxBudgetProjet.Text) == false)
            {
                tblBudgetProjetErreur.Text = "Veuillez entrer une valeur valide";
                valide = false;
            }

            if (SingletonProjetValidation.getInstance().isEmployesRequisValide(nbxEmployesRequisProjet.Value) == false)
            {
                tblEmployesRequisProjetErreur.Text = "Veuillez entrer une valeur valide";
                valide = false;
            }
            if (valide == true)
            {
                Projet projet = new Projet
                {
                    NumeroProjet = 0,
                    Titre = tbxTitreProjet.Text,
                    DateDebut = dtpDateDebutProjet.Date.Date,
                    Description = tbxDescriptionProjet.Text,
                    Budget = Decimal.Parse(nbxBudgetProjet.Text),
                    NombreEmployesRequis = (int)nbxEmployesRequisProjet.Value,
                    TotalSalairesPayer = 0,
                    ClientIdentifiant = 0,
                    Statut = ""
                };
                SingletonProjet.getInstance().AjouterProjet(projet);
            }
        }

        private void resetErreurs()
        {
            tblTitreProjetErreur.Text = string.Empty;
            tblDateDebutProjetErreur.Text = string.Empty;
            tblDescriptionProjetErreur.Text = string.Empty;
            tblBudgetProjetErreur.Text = string.Empty;
            tblEmployesRequisProjetErreur.Text = string.Empty;
        }

    }
}
