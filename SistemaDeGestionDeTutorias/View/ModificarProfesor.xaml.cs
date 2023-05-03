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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SistemaDeGestionDeTutorias.View
{
    /// <summary>
    /// Lógica de interacción para ModificarProfesor.xaml
    /// </summary>
    public partial class ModificarProfesor : Window
    {
        public ModificarProfesor(DataModel.Profesor Profesor)
        {
            InitializeComponent();
            LlenarCampos(Profesor);
        }

        private async void BotonGuardar_Click(object sender, RoutedEventArgs e)
        {
            BotonGuardar.IsEnabled = false;
            BotonCancelar.IsEnabled = false;

            string matricula = txtNumero.Text;
            string nombre = txtNombre.Text;
            string apellidoPaterno = txtApellidoPat.Text;
            string apellidoMaterno = txtApellidoMat.Text;
            string correoPersonal = txtCorreoPersonal.Text;
            string correoInstitucional = txtCorreoInstitucional.Text;
            string esTutor = "false";
            string esCoordinador = "false";
            bool esJefe = false;

            if(EsTutor.IsChecked == true)
            {
                esTutor = "true";
            }
            if(EsCoordinador.IsChecked == true)
            {
                esCoordinador = "true";
            }
            if(EsJefeDeCarrera.IsChecked == true)
            {
                esJefe = true;
            }

            if (!String.IsNullOrEmpty(matricula) &&
               !String.IsNullOrEmpty(nombre) &&
               !String.IsNullOrEmpty(apellidoPaterno) &&
               !String.IsNullOrEmpty(apellidoMaterno) &&
               !String.IsNullOrEmpty(correoInstitucional) &&
               !String.IsNullOrEmpty(correoPersonal)
               )
            {

                if (Validador.EsStringValido(nombre) &&
                     Validador.EsStringValido(apellidoPaterno) &&
                     Validador.EsStringValido(apellidoMaterno) &&
                     Validador.EsCorreoInstitucionalProfesorValido(correoInstitucional) &&
                     Validador.EsCorreoElectronicoValido(correoPersonal)
                     )
                {
                    await ProfesorManager.ModificarProfesorAsync(matricula, nombre, apellidoPaterno, apellidoMaterno, correoPersonal, correoInstitucional, esTutor, esCoordinador, esJefe);
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

        private void LlenarCampos(DataModel.Profesor Profesor)
        {
            txtNumero.Text = Profesor.NumeroDePersonal;
            txtNombre.Text = Profesor.Nombres;
            txtApellidoPat.Text = Profesor.ApellidoPaterno;
            txtApellidoMat.Text = Profesor.ApellidoMaterno;
            txtCorreoInstitucional.Text = Profesor.CorreoInstitucional;
            txtCorreoPersonal.Text = Profesor.CorreoPersonal;
            if(Profesor.EsTutor == "true")
            {
                EsTutor.IsChecked = true;
            }
            if (Profesor.EsCoordinador == "true")
            {
                EsCoordinador.IsChecked = true;
            }
            if (Profesor.EsJefeCarrera == true)
            {
                EsJefeDeCarrera.IsChecked = true;
            }
        }
    }
}
