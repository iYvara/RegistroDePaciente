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
            while (numerodecodigo.Length < 4) ;
            {
                numerodecodigo = "0" + numerodecodigo;
            }
            return "PAC-" + numerodecodigo;

            // Calcular la prioridad

            static int CalcularPrioridad(int nivel_de_emergencia, string tipoSolicitud)
            {   
                int prioridad;
                prioridad = nivel_de_emergencia * 2;
                tipoSolicitud = tipoSolicitud.ToUpper();
                if (tipoSolicitud == "AMBULANCIA") || (tipoSolicitud == "MEDICAMENTOS")
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

            while (i < contador_paciente)
            {
                if (pacientes[i].Dni == dniIngresado)
                {
                    repetido = true;
                    break;
                }
                i++;
            }
            // Fecha de registro:

            fecha[contador_paciente - 1] =
    DateTime.Now.ToString("dd/MM/yyyy");

            // Informacion: 

            string distrito = "El Agustino";
            string centroSalud = "Hospital Nacional Unanue";
            string tipoSolicitud = "Ambulancia";
            string descripcion = "Requiere oxígeno de emergencia";

            // Niveles de Emergencia:
            do
            {
                Console.Writeline("Nivel de Emergencia (1 al 5)");
                nivel_de_emergencia[contador_paciente - 1] = Console.ReadLine();
                switch {
                        case 1:
                            Console.WriteLine("Nivel de emergencia: Muy Bajo");
                            break;
                        case 2:
                            Console.WriteLine("Nivel de emergencia: Bajo");
                            break;
                        case 3:
                            Console.WriteLine("Nivel de emergencia: Normal");
                            break;
                        case 4:
                            Console.WriteLine("Nivel de emergencia: Alta");
                            break;
                        case 5:
                            Console.WriteLine("Nivel de emergencia: Muy alta");
                            break;
                    default:
                        Console.WriteLine("Error: Ingrese un nivel correctamente.")
                    }
            }

        }
    }