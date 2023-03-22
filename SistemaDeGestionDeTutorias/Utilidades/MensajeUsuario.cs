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
            MessageBox.Show("Guardado Exitoso", "Guardado exitoso",MessageBoxButton.OK,MessageBoxImage.Information);
        }
        public static void MostrarErrorBD()
        {
            MessageBox.Show("Error En Base de datos", "Error En Base de datos", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public static bool MostrarCofirmacionCancelar()
        {
            MessageBoxResult messageResult = MessageBox.Show("Perdera todo el progreso no guardado", "Confirmar cancelacion? ", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if(messageResult == MessageBoxResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
