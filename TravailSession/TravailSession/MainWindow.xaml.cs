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
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            mainFrame.Navigate(typeof(PageListeProjet));
        }

        private void abButtonListeEmploy�_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(PageListeEmploye));
        }

        private void abButtonAjoutEmploy�_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(PageAjoutEmploye));
        }

        private void abButtonListeClient_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(PageListeClient));
        }

        private void abButtonAjoutClient_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(PageAjoutClient));
        }

        private void abButtonListeProjet_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(PageListeProjet));
        }

        private void abButtonAjoutProjet_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(PageAjoutProjet));
        }
    }
}
