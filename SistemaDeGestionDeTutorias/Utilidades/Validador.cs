using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SistemaDeGestionDeTutorias.Utilidades
{
    public static class Validador
    {
        public static bool EsCorreoElectronicoValido(string correo)
        {
            bool esValido = false;
            if (!Regex.IsMatch(correo, @"^[a-zA-Z][\w\.-][a-zA-Z0-9]@[a-zA-Z0-9][\w\.-][a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                esValido = true;
            }
            return esValido;
        }
        public static bool EsCorreoInstitucionalProfesorValido(string correo)
        {
            bool esValido = false;
            if (EsCorreoElectronicoValido(correo) &&
                correo.EndsWith("profesores.uv.mx")) 
            { 
                esValido = true; 
            }
            
            return esValido;
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
