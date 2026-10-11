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

            // Listas para los pacientes
            string[] codigos_actual = new string[100];
            string[] nombres = new string[100];
            string[] apellidos = new string[100];
            int[] DNI = new int[100];
            string[] fecha = new string[100];
            string[] distrito = new string[100];
            string[] centroSalud = new string[100];
            string[] tipoSolicitud = new string[100];
            string[] descripcion = new string[100];
            int[] nivel_de_emergencia = new int[100];
            int[] prioridad_final = new int[100];
            int[] nivel_de_estado = new int[100];

            // Registro de paciente:

        do 
            { 
            Console.WriteLine("=======================");
            Console.WriteLine("");
            Console.WriteLine("REGISTROS DE PACIENTES");
            Console.WriteLine("");
            Console.WriteLine("=======================");
           }
            // Generacion del codigo de pacientes:

        codigoActual[contadorPacientes - 1] =
                    GenerarCodigoPaciente(contadorPacientes);

        }

    }
}