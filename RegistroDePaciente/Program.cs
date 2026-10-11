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
                    prioridad = prioridad + 3;
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

            // Nombres y apellidos del paciente
            do
            {
                Console.WriteLine("Ingrese sus nombres:");
                nombres[contador_paciente - 1] = Console.ReadLine();
                if (nombres == "")
                {
                    Console.WriteLine("Error: El campo de nombres no puede estar vacío. Por favor, ingrese sus nombres.");  

                }
                while (nombres[contador_paciente - 1] == "") ;
            }

            do
            {
                Console.WriteLine("Ingrese los apellidos completos:");
                apellidos[contador_paciente - 1] = Console.ReadLine();

                if (apellidos[contador_paciente - 1] == "")
                {
                    Console.WriteLine("Error: debe ingresar los apellidos.");
                }

            } while (apellidos[contador_paciente - 1] == "");

            // DNI
            Console.WriteLine("Ingrese su DNI:");
            DNI[contador_paciente - 1] = Convert.ToInt32(Console.ReadLine());

            if (DNI[contador_paciente - 1] <= 10000000) || (DNI[contador_paciente] >= 9999999 )
            {
                Console.WriteLine("Error: El DNI debe tener 8 dígitos.");
            }
            bool repetido = false;
            int i = 0;

            while (i < contador_pacientes)
            {
                if (pacientes[i].Dni == dniIngresado)
                {
                    repetido = true;
                    break;
                }
                i++;
            }
        }
        }

    }
}