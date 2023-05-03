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
    /// Lógica de interacción para Home.xaml
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
            frame.Navigate(new System.Uri("View/MenuEstudiantes.xaml", UriKind.RelativeOrAbsolute));
        }

        private void botonProfesores_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new System.Uri("View/MenuTutores.xaml", UriKind.RelativeOrAbsolute));
        }

        private void botonTutores_Click(object sender, RoutedEventArgs e)
        {
            // frame.Navigate(new System.Uri("PageTutores.xaml", UriKind.RelativeOrAbsolute));
        }

        private void botonExperiencias_Click(object sender, RoutedEventArgs e)
        {
            // frame.Navigate(new System.Uri("PageExperiencias.xaml", UriKind.RelativeOrAbsolute));
        }

        private void botonProgramas_Click(object sender, RoutedEventArgs e)
        {
            //frame.Navigate(new System.Uri("PageProgramas.xaml", UriKind.RelativeOrAbsolute));
        }

        private void botonAsistencias_Click(object sender, RoutedEventArgs e)
        {
            //frame.Navigate(new System.Uri("PageAsistencias.xaml", UriKind.RelativeOrAbsolute));
        }

        private void botonTutorias_Click(object sender, RoutedEventArgs e)
        {
            // frame.Navigate(new System.Uri("PageTutorias.xaml", UriKind.RelativeOrAbsolute));
        }

        private void botonReportes_Click(object sender, RoutedEventArgs e)
        {
            // frame.Navigate(new System.Uri("PageReportes.xaml", UriKind.RelativeOrAbsolute));
        }

    }
}
