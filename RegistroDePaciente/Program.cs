using System;
using static System.Net.Mime.MediaTypeNames;

namespace RegistroDePaciente
{
    class Program
    {
        // Generacion del codigo para el contador de pacientes

        static string GenerarCodigoDePaciente(int contador)
        {
            string numerodecodigo;
            numerodecodigo = Convert.ToString(contador);
            while (numerodecodigo.Length < 4)
            {
                numerodecodigo = "0" + numerodecodigo;
            }
            return "PAC-" + numerodecodigo;

            // Calcular la prioridad

            static int CalcularPrioridad(int nivel_de_emergencia, string tipoSolicitud)
            {
                int prioridad;
                prioridad  = nivel_de_emergencia * 2
                tipoSolicitud = tipoSolicitud.ToUpper();
                if (tipoSolicitud == "AMBULANCIA") || ( tipoSolicitud == "MEDICAMENTOS")
                        {
                    prioridad = prioridad + 3
                        }
                return prioridad;
            
            }

            // Datos para la creacion del Registro de Paciente
            int contador_paciente, i, DNI, nivel_de_emergencia, prioridad_final;
            string codigo_actual, nombres, apellidos, fecha,distrito, centroSalud, tipoSolicitud, descripcion, continuar, codigo_busqueda, decision, estado;
            bool repetido, encontrado;

        }

    }
}