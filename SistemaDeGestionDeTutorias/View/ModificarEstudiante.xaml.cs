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
    /// Lógica de interacción para ModificarEstudiante.xaml
    /// </summary>
    public partial class ModificarEstudiante : Window
    {
        public ModificarEstudiante(DataModel.Estudiante estudiante)
        {
            InitializeComponent();
            LlenarCampos(estudiante);
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

            if (!String.IsNullOrEmpty(matricula) &&
               !String.IsNullOrEmpty(nombre) &&
               !String.IsNullOrEmpty(apellidoPaterno) &&
               !String.IsNullOrEmpty(apellidoMaterno) &&
               !String.IsNullOrEmpty(correoInstitucional) &&
               !String.IsNullOrEmpty(correoPersonal) //&&
                                                     // !String.IsNullOrEmpty(programa)
               )
            {

                if (Validador.EsStringValido(nombre) &&
                     Validador.EsStringValido(apellidoPaterno) &&
                     Validador.EsStringValido(apellidoMaterno) &&
                     Validador.EsCorreoInstitucionalEstudianteValido(correoInstitucional) &&
                     Validador.EsCorreoElectronicoValido(correoPersonal)
                     )
                {
                    await EstudianteManager.ModificarEstudianteAsync(matricula, nombre, apellidoPaterno, apellidoMaterno, correoPersonal, correoInstitucional);
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

        private void LlenarCampos(DataModel.Estudiante estudiante)
        {
            txtMatricula.Text = estudiante.Matricula;
            txtNombre.Text = estudiante.Nombres;
            txtApellidoPat.Text = estudiante.ApellidoPaterno;
            txtApellidoMat.Text = estudiante.ApellidoMaterno;
            txtCorreoInstitucional.Text = estudiante.CorreoInstitucional;
            txtCorreoPersonal.Text = estudiante.CorreoPersonal;
        }
    }
}
