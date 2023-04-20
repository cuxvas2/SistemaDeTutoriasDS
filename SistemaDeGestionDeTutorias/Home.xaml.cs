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

namespace SistemaDeGestionDeTutorias
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            frame.Source = new Uri(e.Uri.ToString(), UriKind.Relative);
        }

        private void botonEstudiantes_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new System.Uri("View/PageEstudiantesMenu.xaml", UriKind.RelativeOrAbsolute));
        }

        private void botonProfesores_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new System.Uri("View/PageProfesores.xaml", UriKind.RelativeOrAbsolute));
        }

        private void botonTutores_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new System.Uri("View/PageTutores.xaml", UriKind.RelativeOrAbsolute));
        }

        private void botonExperiencias_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new System.Uri("View/PageExperiencias.xaml", UriKind.RelativeOrAbsolute));
        }

        private void botonProgramas_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new System.Uri("View/PageProgramas.xaml", UriKind.RelativeOrAbsolute));
        }

        private void botonAsistencias_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new System.Uri("View/PageAsistencias.xaml", UriKind.RelativeOrAbsolute));
        }

        private void botonTutorias_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new System.Uri("View/PageTutorias.xaml", UriKind.RelativeOrAbsolute));
        }

        private void botonReportes_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new System.Uri("View/PageReportes.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
