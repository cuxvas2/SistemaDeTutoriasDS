using SistemaDeGestionDeTutorias.Utilidades;
using DataAccess;
using System;
using System.Windows;

namespace SistemaDeGestionDeTutorias.View
{
    /// <summary>
    /// Lógica de interacción para NuevoEstudiante.xaml
    /// </summary>
    public partial class NuevoEstudiante : Window
    {
        public NuevoEstudiante()
        {
            InitializeComponent();
        }

        private async void BotonGuardar_Click(object sender, RoutedEventArgs e)
        {
            BotonGuardar.IsEnabled = false;
            BotonCancelar.IsEnabled = false;

            string matricula = txtMatricula.Text;
            string nombre = txtNombre.Text;
            string apellidoPaterno = txtApellidoPat.Text;
            string apellidoMaterno = txtApellidoMat.Text;
            string correoPersonal = txtCorreoPersonal.Text;
            string correoInstitucional = txtCorreoInstitucional.Text;

            if(!String.IsNullOrEmpty(matricula) &&
               !String.IsNullOrEmpty(nombre)&&
               !String.IsNullOrEmpty(apellidoPaterno) &&
               !String.IsNullOrEmpty(apellidoMaterno) &&
               !String.IsNullOrEmpty(correoInstitucional) &&
               !String.IsNullOrEmpty(correoPersonal) //&&
              // !String.IsNullOrEmpty(programa)
               )
            {
                if (await EstudianteManager.BuscarEstudiantePorMatriculaAsync(matricula) == null)
                {
                    if (Validador.EsStringValido(nombre) &&
                    Validador.EsStringValido(apellidoPaterno) &&
                    Validador.EsStringValido(apellidoMaterno) &&
                    Validador.EsCorreoInstitucionalEstudianteValido(correoInstitucional) &&
                    Validador.EsCorreoElectronicoValido(correoPersonal)
                    )
                    {
                        DataModel.Estudiante estudiante = new DataModel.Estudiante();

                        estudiante.Matricula = matricula;
                        estudiante.Nombres = nombre;
                        estudiante.ApellidoPaterno = apellidoPaterno;
                        estudiante.ApellidoMaterno = apellidoMaterno;
                        estudiante.CorreoInstitucional = correoInstitucional;
                        estudiante.CorreoPersonal = correoPersonal;
                        Utilidades.ManejadorDeExcepcionesEntity.HayExcepcionesEntity(await EstudianteManager.AgregarEstudianteAsync(estudiante));
                        MensajeUsuario.MostrarGuardadoExitoso();
                        
                        this.Close();
                    }
                    else
                    {
                        MensajeUsuario.DatosNoValidos();
                        ActivarBotones();
                    }
                }
                else
                {
                    MensajeUsuario.MatriculaExistente();
                    ActivarBotones();
                }
            }
            else
            {
                MensajeUsuario.CamposVacios();
                ActivarBotones();
            }
        }

        private void BotonCancelar_Click(object sender, RoutedEventArgs e)
        {
            if(MensajeUsuario.MostrarCofirmacionCancelar() == true)
            {
                this.Close();
            }
        }

        private void ActivarBotones()
        {
            BotonGuardar.IsEnabled = true;
            BotonCancelar.IsEnabled = true;
        }
    }
}
