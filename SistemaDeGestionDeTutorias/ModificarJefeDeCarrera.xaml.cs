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
    /// Lógica de interacción para ModificarJefeDeCarrera.xaml
    /// </summary>
    public partial class ModificarJefeDeCarrera : Page
    {
        private static List<Profesor> listaJefes = new List<Profesor>();
        public ModificarJefeDeCarrera()
        {
            InitializeComponent();
            LlenarListaDeJefes();


        }

        private async void LlenarListaDeJefes()
        {
            RespuestaConsulta<List<Profesor>> respuesta = await JefesCarrreraManager.RecuperarJefesDeCarreraAsync();
            if (respuesta.ResultadoConsulta == ResultadoConsulta.Exitosa)
            {
                if(!ManejadorDeExcepcionesEntity.HayExcepcionesEntity(respuesta))
                {
                    foreach(Profesor jefe in respuesta.Respuesta){
                        ListBoxItem listBoxItemMensaje = new ListBoxItem();
                        listBoxItemMensaje.Content = jefe.ProgramaEducativo;
                        JefesDeCarrera.Items.Add(listBoxItemMensaje);
                    }

                }
            }
        }

        private async void btn_guardar_Click(object sender, RoutedEventArgs e)
        {
            if (!HayCamposVacios())
            {
                Profesor profesor = new Profesor();
                String correo = TextCorreo.Text;
                if(Validador.EsCorreoElectronicoValido(correo))
                {
                    profesor.CorreoPersonal = correo;
                    profesor.Nombres = TextNombre.Text;
                    profesor.ApellidoMaterno = TextApellidoMaterno.Text;
                    profesor.ApellidoPaterno = TextApellidoPaterno.Text;
                    //Cambiaar en el dao que sea por numero de identificacion y no por id o por la carrera que tiene asociado
                    profesor.NumeroDePersonal = TextNumeroIdentificacion.Text;
                }

                RespuestaConsulta<Profesor> respuesta = await JefesCarrreraManager.ModificarJefeCarreraAsync(profesor);
                if (!ManejadorDeExcepcionesEntity.HayExcepcionesEntity(respuesta))
                {
                    MensajeUsuario.MostrarGuardadoExitoso();
                }
            }
        }

        private bool HayCamposVacios()
        {
            bool camposVacios = false;
            if (String.IsNullOrEmpty(TextNombre.Text) ||
                String.IsNullOrEmpty(TextNumeroIdentificacion.Text) ||
                String.IsNullOrEmpty(TextApellidoPaterno.Text) || 
                String.IsNullOrEmpty(TextApellidoMaterno.Text) ||
                String.IsNullOrEmpty(TextCorreo.Text))
            {
                MensajeUsuario.CamposVacios();
                camposVacios = true;
            }
            return camposVacios;

        }
    }
}
