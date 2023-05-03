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
    /// Lógica de interacción para Tutores.xaml
    /// </summary>
    public partial class Profesores : Page
    {

        List<Profesor> listaProfesores;

        public Profesores()
        {
            InitializeComponent();
            Cargar();
        }

        private void BotonNuevo_Click(object sender, RoutedEventArgs e)
        {
            NuevoProfesor nuevoProfesor = new NuevoProfesor();
            Application.Current.MainWindow = nuevoProfesor;
            nuevoProfesor.Show();
        }

        private async void Cargar()
        {
            DG.ItemsSource = null;
            listaProfesores = await DataAccess.ProfesorManager.BuscarTodosLosProfesorsAsync();
            if (listaProfesores.Count < 1)
            {
                MessageBox.Show("No se encontraron Profesors a mostrar");
            }
            else
            {
                DG.ItemsSource = listaProfesores;
            }
        }

        private void BotonModificar_Click(object sender, RoutedEventArgs e)
        {
            Profesor ProfesorSeleccionado = (Profesor)DG.SelectedItem;
            if (ProfesorSeleccionado == null)
            {
                MensajeUsuario.SinSeleccionar();
            }
            else
            {
                ModificarProfesor modificarProfesor = new ModificarProfesor(ProfesorSeleccionado);
                Application.Current.MainWindow = modificarProfesor;
                modificarProfesor.Show();
            }
        }

        private async void BotonBuscar_Click(object sender, RoutedEventArgs e)
        {
            string numeroBuscar = NumeroDePersonal.Text;

            if (String.IsNullOrEmpty(numeroBuscar) || numeroBuscar == "Numero De Personal")
            {
                MensajeUsuario.DatosNoValidos();
            }
            else
            {

                var Profesor = await DataAccess.ProfesorManager.BuscarProfesorPorNumeroDePersonalAsync(numeroBuscar);
                if (Profesor == null)
                {
                    MensajeUsuario.DatosNoValidos();
                }
                else
                {
                    DG.ItemsSource = null;
                    listaProfesores.Add(Profesor);
                    if (listaProfesores.Count < 1)
                    {
                        MessageBox.Show("No se encontraron Profesors a mostrar");
                    }
                    else
                    {
                        DG.ItemsSource = listaProfesores;
                    }
                }
            }
        }

        private async void BotonEliminar_Click(object sender, RoutedEventArgs e)
        {
            Profesor ProfesorSeleccionado = (Profesor)DG.SelectedItem;
            if (ProfesorSeleccionado == null)
            {
                MensajeUsuario.SinSeleccionar();
            }
            else
            {
                await DataAccess.ProfesorManager.EliminarProfesorAsync(ProfesorSeleccionado.NumeroDePersonal);
                MensajeUsuario.EliminacionExitosa();
                Cargar();
            }
        }
    }
}
