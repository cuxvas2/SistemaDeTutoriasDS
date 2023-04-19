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
    /// Lógica de interacción para ModificarJefeDeCarrera.xaml
    /// </summary>
    public partial class ModificarJefeDeCarrera : Page
    {
        public ModificarJefeDeCarrera()
        {
            InitializeComponent();
            LlenarListaDeJefes();


        }

        private void LlenarListaDeJefes()
        {
            List<String> lista = new List<String>();
            lista.Add("Ocharan");
            foreach(String jefe in lista){
                ListBoxItem listBoxItemMensaje = new ListBoxItem();
                listBoxItemMensaje.Content = jefe;
                JefesDeCarrera.Items.Add(listBoxItemMensaje);
            }
        }

    }
}
