using DataAccess;
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
using System.Windows.Shapes;

namespace SistemaDeGestionDeTutorias.View
{
    /// <summary>
    /// Lógica de interacción para NuevoProfesor.xaml
    /// </summary>
    public partial class NuevoProfesor : Window
    {
        public NuevoProfesor()
        {
            InitializeComponent();
        }

        private async void BotonGuardar_Click(object sender, RoutedEventArgs e)
        {
            BotonGuardar.IsEnabled = false;
            BotonCancelar.IsEnabled = false;

            string numero = txtNumero.Text;
            string nombre = txtNombre.Text;
            string apellidoPaterno = txtApellidoPat.Text;
            string apellidoMaterno = txtApellidoMat.Text;
            string correoPersonal = txtCorreoPersonal.Text;
            string correoInstitucional = txtCorreoInstitucional.Text;
            string esTutor = "false";
            string esCoordinador = "false";
            bool esJefe = false;

            if (EsTutor.IsChecked == true)
            {
                esTutor = "true";
            }
            if (EsCoordinador.IsChecked == true)
            {
                esCoordinador = "true";
            }
            if (EsJefeDeCarrera.IsChecked == true)
            {
                esJefe = true;
            }

            if (!String.IsNullOrEmpty(numero) &&
               !String.IsNullOrEmpty(nombre) &&
               !String.IsNullOrEmpty(apellidoPaterno) &&
               !String.IsNullOrEmpty(apellidoMaterno) &&
               !String.IsNullOrEmpty(correoInstitucional) &&
               !String.IsNullOrEmpty(correoPersonal) 
               )
            {
                if (await ProfesorManager.BuscarProfesorPorNumeroDePersonalAsync(numero) == null)
                {
                    if (Validador.EsStringValido(nombre) &&
                    Validador.EsStringValido(apellidoPaterno) &&
                    Validador.EsStringValido(apellidoMaterno) &&
                    Validador.EsCorreoInstitucionalProfesorValido(correoInstitucional) &&
                    Validador.EsCorreoElectronicoValido(correoPersonal)
                    )
                    {
                        DataModel.Profesor Profesor = new DataModel.Profesor();

                        Profesor.NumeroDePersonal = numero;
                        Profesor.Nombres = nombre;
                        Profesor.ApellidoPaterno = apellidoPaterno;
                        Profesor.ApellidoMaterno = apellidoMaterno;
                        Profesor.CorreoInstitucional = correoInstitucional;
                        Profesor.CorreoPersonal = correoPersonal;
                        Profesor.EsTutor = esTutor;
                        Profesor.EsCoordinador = esCoordinador;
                        Profesor.EsJefeCarrera = esJefe;

                        await ProfesorManager.AgregarProfesorAsync(Profesor);
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
            if (MensajeUsuario.MostrarCofirmacionCancelar() == true)
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
