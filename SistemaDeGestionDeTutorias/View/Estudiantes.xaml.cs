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

namespace SistemaDeGestionDeTutorias.View
{
    /// <summary>
    /// Lógica de interacción para Estudiantes.xaml
    /// </summary>
    public partial class Estudiantes : Page
    {

        List<Estudiante> listaEstudiantes;

        public Estudiantes()
        {
            InitializeComponent();
            Cargar();
        }

        private void BotonNuevo_Click(object sender, RoutedEventArgs e)
        {
            NuevoEstudiante nuevoEstudiante = new NuevoEstudiante();
            Application.Current.MainWindow = nuevoEstudiante;
            nuevoEstudiante.Show();
        }

        private async void Cargar()
        {
            RadioTODOS.IsChecked = true;
            DG.ItemsSource = null;
            listaEstudiantes = await DataAccess.EstudianteManager.BuscarTodosLosEstudiantesAsync();
            if (listaEstudiantes.Count < 1)
            {
                MessageBox.Show("No se encontraron estudiantes a mostrar");
            }
            else
            {
                DG.ItemsSource = listaEstudiantes;
            }
        }

        private async void Recargar()
        {
            string ProgramaEducativo = ObtenerPrograma();
            DG.ItemsSource = null;
            listaEstudiantes = await DataAccess.EstudianteManager.BuscarEstudiantesPorProgramaEducativoAsync(ProgramaEducativo);
            if (listaEstudiantes.Count < 1)
            {
                MessageBox.Show("No se encontraron estudiantes a mostrar");
            }
            else
            {
                DG.ItemsSource = listaEstudiantes;
            }
        }

        private string ObtenerPrograma()
        {
            string programa = null;

            if (RadioLEST.IsChecked == true)
            {
                programa = "Licenciatura En Estadistica";
            }
            if (RadioLICIC.IsChecked == true)
            {
                programa = "Licenciatura en Ciberseguridad";
            }
            if (RadioLIS.IsChecked == true)
            {
                programa = "Ingenieria de Software";
            }
            if (RadioLISTI.IsChecked == true)
            {
                programa = "";
            }
            if (RadioLRSC.IsChecked == true)
            {
                programa = "Licenciatura En Redes y Servicios De Computo";
            }
            if (RadioLTC.IsChecked == true)
            {
                programa = "Licenciatura en Tecnologias Computacionales";
            }

            return programa;
        }

        private void RadioLIS_Checked(object sender, RoutedEventArgs e)
        {
            Recargar();
        }

        private void RadioLICIC_Checked(object sender, RoutedEventArgs e)
        {
            Recargar();
        }

        private void RadioLISTI_Checked(object sender, RoutedEventArgs e)
        {
            Recargar();
        }

        private void RadioLRSC_Checked(object sender, RoutedEventArgs e)
        {
            Recargar();
        }

        private void RadioLEST_Checked(object sender, RoutedEventArgs e)
        {
            Recargar();
        }

        private void RadioLTC_Checked(object sender, RoutedEventArgs e)
        {
            Recargar();
        }

        private void RadioTODOS_Checked(object sender, RoutedEventArgs e)
        {
            Cargar();
        }

        private void BotonModificar_Click(object sender, RoutedEventArgs e)
        {
            Estudiante EstudianteSeleccionado = (Estudiante)DG.SelectedItem;
            if(EstudianteSeleccionado == null)
            {
                MensajeUsuario.SinSeleccionar();
            }
            else
            {
                ModificarEstudiante modificarEstudiante = new ModificarEstudiante(EstudianteSeleccionado);
                Application.Current.MainWindow = modificarEstudiante;
                modificarEstudiante.Show();
            }
        }

        private async void BotonBuscar_Click(object sender, RoutedEventArgs e)
        {
            string matriculaBuscar = Matricula.Text;

            if(String.IsNullOrEmpty(matriculaBuscar) || matriculaBuscar == "Matricula")
            {
                MensajeUsuario.DatosNoValidos();
            }
            else
            {
                
                var estudiante = await DataAccess.EstudianteManager.BuscarEstudiantePorMatriculaAsync(matriculaBuscar);
                if(estudiante == null)
                {
                    MensajeUsuario.DatosNoValidos();
                }
                else
                {
                    DG.ItemsSource = null;
                    listaEstudiantes.Add(estudiante);
                    if (listaEstudiantes.Count < 1)
                    {
                        MessageBox.Show("No se encontraron estudiantes a mostrar");
                    }
                    else
                    {
                        DG.ItemsSource = listaEstudiantes;
                    }
                }
            }
        }

        private async void BotonEliminar_Click(object sender, RoutedEventArgs e)
        {
            Estudiante EstudianteSeleccionado = (Estudiante)DG.SelectedItem;
            if (EstudianteSeleccionado == null)
            {
                MensajeUsuario.SinSeleccionar();
            }
            else
            {
                await DataAccess.EstudianteManager.EliminarEstudianteAsync(EstudianteSeleccionado.Matricula);
                MensajeUsuario.EliminacionExitosa();
                Cargar();
            }
        }
    }
}
