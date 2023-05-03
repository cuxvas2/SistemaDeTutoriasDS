using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SistemaDeGestionDeTutorias.View
{
    /// <summary>
    /// Lógica de interacción para MenuTutores.xaml
    /// </summary>
    public partial class MenuTutores : Page
    {
        public MenuTutores()
        {
            InitializeComponent();
        }

        private void BotonAsignaciones_Click(object sender, RoutedEventArgs e)
        {
            Home home = (Home)Application.Current.MainWindow;
            if (home != null)
            {
                home.frame.Navigate(new System.Uri("View/AsigarTutor.xaml", UriKind.RelativeOrAbsolute));
            }
            else
            {
                Application.Current.MainWindow = new Home();
            }

        }

        private void BotonGestionProfesores_Click(object sender, RoutedEventArgs e)
        {
            Home home = (Home)Application.Current.MainWindow;
            if (home != null)
            {
                home.frame.Navigate(new System.Uri("View/Tutores.xaml", UriKind.RelativeOrAbsolute));
            }
            else
            {
                Application.Current.MainWindow = new Home();
            }

        }
    }
}
