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
    /// Lógica de interacción para MenuEstudiantes.xaml
    /// </summary>
    public partial class MenuEstudiantes : Page
    {
        public MenuEstudiantes()
        {
            InitializeComponent();
        }

        private void BotonGestionEstudiantes_Click(object sender, RoutedEventArgs e)
        {
            Home home = (Home)Application.Current.MainWindow;
            if (home != null)
            {
                home.frame.Navigate(new System.Uri("View/Estudiantes.xaml", UriKind.RelativeOrAbsolute));
            }
            else
            {
                Application.Current.MainWindow = new Home();
            }
            
        }
    }
}
