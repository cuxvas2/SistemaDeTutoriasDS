using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SistemaDeGestionDeTutorias.Utilidades
{
    public static class MensajeUsuario
    {
        public static void MostrarGuardadoExitoso()
        {
            MessageBox.Show(
                "Guardado exitoso",
                "Guardado Exitoso",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }
        public static void MostrarErrorConexionBD()
        {
            MessageBox.Show(
                "No hay conexion a base de datos",
                "Error En Base de datos",
                MessageBoxButton.OK, 
                MessageBoxImage.Error);
        }
        public static void MostrarOperacionNoValidaBD()
        {
            MessageBox.Show(
                "No se puede llevar a cabo esa operacion en base de datos",
                "Error En Base de datos",
                MessageBoxButton.OK, 
                MessageBoxImage.Error);
        }
        public static void MostrarErrorEscrituraLecturaBD()
        {
            MessageBox.Show(
                "Error de lectura/escritura en la base de datos",
                "Error En Base de datos",
                MessageBoxButton.OK, 
                MessageBoxImage.Error);
        }

        public static void MostrarErrorDesconocidoBD(string _mensajeExcepcion)
        {
            MessageBox.Show(
                "Error Desconocido En Base de datos: " + 
                _mensajeExcepcion,
                "Error En Base de datos",
                MessageBoxButton.OK, 
                MessageBoxImage.Error);
        }
        public static void MostrarErrorInesperado()
        {
            MessageBox.Show(
                "Error inesperado, excepcion no contemplada " ,
                "Error En sistema",
                MessageBoxButton.OK, 
                MessageBoxImage.Error);
        }

        public static bool MostrarCofirmacionCancelar()
        {
            MessageBoxResult messageResult = MessageBox.Show(
                "Confirmar cancelacion? ",
                "Perdera todo el progreso no guardado",
                MessageBoxButton.YesNo, 
                MessageBoxImage.Warning);
            return messageResult == MessageBoxResult.Yes ? true : false;
        }

        public static void MostrarCamposVacios()
        {
            MessageBox.Show(
                "No pude dejar campos vacios, verifique y vuelva a intentar",
                "Campos vacios",
                MessageBoxButton.OK,
                MessageBoxImage.Stop);
        }
    }
}
