using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SistemaDeGestionDeTutorias.Utilidades
{
    public static class Validador
    {
        public static bool EsCorreoElectronicoValido(string correo)
        {
            return Regex.IsMatch(correo, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
        public static bool EsCorreoInstitucionalProfesorValido(string correo)
        {
            bool esValido = false;
            if (EsCorreoElectronicoValido(correo) &&
                correo.EndsWith("uv.mx")) 
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
        public static bool EsStringValido(string apellido)
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
