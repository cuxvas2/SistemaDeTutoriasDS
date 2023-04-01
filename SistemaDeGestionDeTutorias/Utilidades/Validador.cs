using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeGestionDeTutorias.Utilidades
{
    public static class Validador
    {
        public static bool EsCorreoElectronicoValido(string correo)
        {
            if (correo.Length == 0) { return false; }
            if (correo.Contains(" ")) { return false; }
            if (!correo.Contains("@")) { return false; }
            if (correo.StartsWith("@")) { return false; }
            String[] emailParts = correo.Split('@');
            if (emailParts[0].Length == 0) { return false; }
            if (!emailParts[1].Contains('.')) { return false; }
            return true;
        }
        public static bool EsCorreoInstitucionalProfesorValido(string correo)
        {
            if (!EsCorreoElectronicoValido(correo)) { return false; }
            if (!correo.EndsWith("profesores.uv.mx")) { return false; }
            return true;
        }
        public static bool EsCorreoInstitucionalEstudianteValido(string correo)
        {
            if (!EsCorreoElectronicoValido(correo)) { return false; }
            if (!correo.EndsWith("estudiantes.uv.mx")) { return false; }
            return true;
        }
        public static bool EsApellidoValido(string apellido)
        {
            if (apellido.Length == 0) { return false; }
            if (!apellido.Any(c => char.IsLetter(c))) { return false; }
            return true;
        }
        public static bool EsPasswordValido(string password)
        {
            if (password.Length < 8) { return false; }
            if (!password.Any(c => char.IsLower(c))) { return false; } 
            if (!password.Any(c => char.IsUpper(c))) { return false; }  
            if (!password.Any(c => char.IsNumber(c))) { return false; } 
            if (!password.Any(c => char.IsPunctuation(c))) { return false; }  
            return true;
        }
    }
}
