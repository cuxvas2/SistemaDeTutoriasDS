using DataAccess;
using DataModel;
using SistemaDeGestionDeTutorias.Utilidades;
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
    /// Lógica de interacción para GestionarProgramaEducativo.xaml
    /// </summary>
    public partial class GestionarProgramaEducativo : Page
    {
        List<ExperienciaEducativa> Listaexperiencias = new List<ExperienciaEducativa>();
        public GestionarProgramaEducativo()
        {
            InitializeComponent();
            LlenarComboBox();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            string busqueda = TextBuscar.Text;
            if(busqueda != null)
            {
                IEnumerable<String> listafiltrada = new List<string>();
                listafiltrada = ListViewExperienciasEducativas.Items.
                    Cast<String>().
                    ToList();
                listafiltrada = listafiltrada.Where(j => j.Contains(busqueda));
                ListViewExperienciasEducativas.Items.Clear();
                ListViewExperienciasEducativas.Items.Add(listafiltrada);
            }
            else
            {
                ListViewExperienciasEducativas.Items.Add(Listaexperiencias);
                MensajeUsuario.CamposVacios();
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (HayCamposVacios()) 
            {
                /* Comparar el numero de personal, si es diferente al actual que se 
                 * Elimine de la base de datos al profesor de esJefe
                 */
                String Nombre = TextNombre.Text;
                String NRC = TextNRC.Text;
                String NumeroDePersonal = TextNumeroDePersonal.Text;
                Profesor profesor = new Profesor();
                profesor.Nombres = Nombre;
                profesor.NumeroDePersonal = NumeroDePersonal;
                //profesor.NRC = NRC; El porofesor no tiene atributos de nrc
            }
        }

        private async void LlenarComboBox()
        {
            RespuestaConsulta<List<ProgramaEducativo>> programaEducativos = null;
            programaEducativos = await ProgramaEducativoManager.RecuperarLicenciaturasAsync();
            if (!ManejadorDeExcepcionesEntity.HayExcepcionesEntity(programaEducativos))
            {
                foreach(ProgramaEducativo programa in programaEducativos.Respuesta)
                {
                    comboLicenciaturas.Items.Add(programa.Nombre);
                }
            }
            else
            {
                //No cargar la pantalla?? O mandarlo a la pantalla de inicio?
            }

        }

        private bool HayCamposVacios()
        {
            bool camposVacios = false;
            if(TextNombre.Text == null ||
                TextNRC.Text == null ||
                TextNumeroDePersonal.Text == null)
            {
                camposVacios = true;
            }
            return camposVacios;
        }

        private void JefesDeCarrera_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem item = sender as ListBoxItem;
            String NRC = "";
            NRC = item.Content.ToString();
            String[] NRCSolo = NRC.Split('-');
            if( NRCSolo.Length > 0)
            {
                ExperienciaEducativa experiencia = Listaexperiencias.FirstOrDefault(ex => ex.Nrc == NRCSolo[1]);
                TextNombre.Text = experiencia.Nombre;
                TextNRC.Text = experiencia.Nrc;
                TextNumeroDePersonal.Text = experiencia.Profesor.NumeroDePersonal;
            }
        }

        private void comboLicenciaturas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox senderComboBox = (ComboBox)sender;
            String licenciatura = "";
            licenciatura = senderComboBox.SelectedItem.ToString();
            if(licenciatura != null && !licenciatura.Equals(""))
            {
                LlenarListaExperiencias(licenciatura);
            }
        }

        private async void LlenarListaExperiencias(String _licenciatura)
        {
            RespuestaConsulta<List<ExperienciaEducativa>> experienciasEducativas = null;
            experienciasEducativas = await ProgramaEducativoManager.RecuperarExperienciasEducativasPorLicenciaturaAsync(_licenciatura);
            if (!ManejadorDeExcepcionesEntity.HayExcepcionesEntity(experienciasEducativas))
            {
                foreach (ExperienciaEducativa programa in experienciasEducativas.Respuesta)
                {
                    ListBoxItem listBoxItemMensaje = new ListBoxItem();
                    listBoxItemMensaje.Content = programa.Nombre + "-" + programa.Nrc;
                    ListViewExperienciasEducativas.Items.Add(listBoxItemMensaje);
                }
                Listaexperiencias = experienciasEducativas.Respuesta;
            }
            else
            {
                //No cargar la pantalla?? O mandarlo a la pantalla de inicio?
            }
        }
    }
}
