using DataModel;
using SistemaDeGestionDeTutorias.Utilidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SistemaDeGestionDeTutorias.View
{
    /// <summary>
    /// Lógica de interacción para AsigarTutor.xaml
    /// </summary>
    public partial class AsigarTutor : Page
    {

        List<Profesor> listaProfesores;
        List<Estudiante> listaAsignados;
        List<Estudiante> listaNoAsignados;

        public AsigarTutor()
        {
            InitializeComponent();
            LoadTodosLosProfesores();
            LoadTodosLosEstudiantes();
        }

        public async Task LoadTodosLosProfesores()
        {
            DG.ItemsSource = null;
            listaProfesores = await DataAccess.ProfesorManager.BuscarProfesorPorSiEsTutorAsync();
            if (listaProfesores.Count < 1)
            {
                System.Windows.MessageBox.Show("No se encontraron Profesors a mostrar");
            }
            else
            {
                DG.ItemsSource = listaProfesores;
            }
        }

        private void DG_MouseUp (object sender, MouseButtonEventArgs e)
        {
            Profesor profesor = (Profesor)DG.SelectedItem;
            CargarAsignados(profesor);
        }

        public async Task CargarAsignados(Profesor profesor)
        {
            DGAsignados.ItemsSource = null;
            listaAsignados = await DataAccess.EstudianteManager.BuscarEstudiantesPorTutorAsync(profesor);
            if (listaAsignados.Count < 1)
            {
                System.Windows.MessageBox.Show("No se encontraron Estudiantes asignados");
            }
            else
            {
                DGAsignados.ItemsSource = listaAsignados;
            }
        }

        public async Task LoadTodosLosEstudiantes()
        {
            DGNoAsignados.ItemsSource = null;
            Profesor tutor = await DataAccess.ProfesorManager.BuscarProfesorPorNumeroDePersonalAsync("0000");
            listaNoAsignados = await DataAccess.EstudianteManager.BuscarEstudiantesPorTutorAsync(tutor);
            if (listaNoAsignados.Count < 1)
            {
                System.Windows.MessageBox.Show("No se encontraron Estudiantes sin tutor");
            }
            else
            {
                DGNoAsignados.ItemsSource = listaNoAsignados;
            }
        }

        private async void botonEliminarAsignacion_Click(object sender, RoutedEventArgs e)
        {
            Estudiante estudiante = (Estudiante)DGAsignados.SelectedItem;
            if(estudiante == null)
            {
                MensajeUsuario.SinSeleccionar();
            }
            else
            {
                listaAsignados.Remove(estudiante);
                await DataAccess.EstudianteManager.ModificarTutorEstudianteAsync(estudiante.Matricula, "0000");
                listaNoAsignados.Add(estudiante);
                Profesor profesor = (Profesor)DG.SelectedItem;
                CargarAsignados(profesor);
                LoadTodosLosEstudiantes();
            }
        }

        private async void botonAsignar_Click(object sender, RoutedEventArgs e)
        {
            Estudiante estudiante = (Estudiante)DGNoAsignados.SelectedItem;
            if (estudiante == null)
            {
                MensajeUsuario.SinSeleccionar();
            }
            else
            {
                listaNoAsignados.Remove(estudiante);
                Profesor profesor = (Profesor)DG.SelectedItem;
                await DataAccess.EstudianteManager.ModificarTutorEstudianteAsync(estudiante.Matricula, profesor.NumeroDePersonal);
                listaAsignados.Add(estudiante);
                CargarAsignados(profesor);
                LoadTodosLosEstudiantes();
            }
        }
    }
}
