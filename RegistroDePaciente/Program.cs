using System;

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
        }

        // Calcular la prioridad

        static int CalcularPrioridad(int nivel_de_emergencia, string tipoSolicitud)
        {
            int prioridad;
            prioridad = nivel_de_emergencia * 2;
            tipoSolicitud = tipoSolicitud.ToUpper();

            if (tipoSolicitud == "AMBULANCIA" || tipoSolicitud == "MEDICAMENTOS")
            {
                prioridad = prioridad + 3;
            }

            return prioridad;
        }

        static void Main(string[] args)
        {
            // Datos para la creacion del Registro de Paciente

            int contador_paciente, i;
            string continuar, codigo_busqueda, decision, estado;
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
            string[] nivel_de_estado = new string[100];

            contador_paciente = 1;
            continuar = "S";

            // Registro de paciente:

            do
            {
                Console.WriteLine("=======================");
                Console.WriteLine("");
                Console.WriteLine("REGISTROS DE PACIENTES");
                Console.WriteLine("");
                Console.WriteLine("=======================");

                // Generacion del codigo de pacientes:

                codigos_actual[contador_paciente - 1] =
                    GenerarCodigoDePaciente(contador_paciente);

                // Nombres y apellidos del paciente

                do
                {
                    Console.WriteLine("Ingrese sus nombres:");
                    nombres[contador_paciente - 1] = Console.ReadLine();

                    if (nombres[contador_paciente - 1] == "")
                    {
                        Console.WriteLine("Error: El campo de nombres no puede estar vacío. Por favor, ingrese sus nombres.");
                    }

                } while (nombres[contador_paciente - 1] == "");

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

                do
                {
                    repetido = false;

                    Console.WriteLine("Ingrese su DNI:");
                    int.TryParse(Console.ReadLine(), out DNI[contador_paciente - 1]);

                    if (DNI[contador_paciente - 1] < 10000000 ||DNI[contador_paciente - 1] > 99999999)
                    {
                        Console.WriteLine("Error: El DNI debe tener 8 dígitos.");
                        repetido = true;
                    }
                    else
                    {
                        i = 0;

                        while (i < contador_paciente - 1)
                        {
                            if (DNI[i] == DNI[contador_paciente - 1])
                            {
                                repetido = true;
                                Console.WriteLine("Error: este DNI ya fue registrado. Intente nuevamente.");
                                break;
                            }

                            i++;
                        }
                    }

                } while (repetido);

                // Fecha de registro:

                fecha[contador_paciente - 1] = DateTime.Now.ToString("dd/MM/yyyy");

                // Informacion:

                distrito[contador_paciente - 1] = "El Agustino";
                centroSalud[contador_paciente - 1] = "Hospital Nacional Unanue";
                tipoSolicitud[contador_paciente - 1] = "Ambulancia";
                descripcion[contador_paciente - 1] = "Requiere oxígeno de emergencia";

                // Niveles de Emergencia:

                do
                {
                    Console.WriteLine("Nivel de Emergencia (1 al 5)");

                    int.TryParse(Console.ReadLine(), out nivel_de_emergencia[contador_paciente - 1]);

                    switch (nivel_de_emergencia[contador_paciente - 1])
                    {
                        case 1:
                            Console.WriteLine("Nivel de emergencia: Muy Bajo");
                            estado = "Leve";
                            break;

                        case 2:
                            Console.WriteLine("Nivel de emergencia: Bajo");
                            estado = "Poco leve";
                            break;

                        case 3:
                            Console.WriteLine("Nivel de emergencia: Normal");
                            estado = "Severo";
                            break;

                        case 4:
                            Console.WriteLine("Nivel de emergencia: Alta");
                            estado = "Poco severo";
                            break;

                        case 5:
                            Console.WriteLine("Nivel de emergencia: Muy alta");
                            estado = "Peligroso";
                            break;

                        default:
                            Console.WriteLine("Error: Ingrese un nivel correctamente.");
                            estado = "";
                            break;
                    }

                    nivel_de_estado[contador_paciente - 1] = estado;

                } while (nivel_de_emergencia[contador_paciente - 1] < 1 ||
                         nivel_de_emergencia[contador_paciente - 1] > 5);

                // Calcular prioridad

                prioridad_final[contador_paciente - 1] = CalcularPrioridad(nivel_de_emergencia[contador_paciente - 1], tipoSolicitud[contador_paciente - 1]);

                // Mostrar registro

                Console.WriteLine("=======================");
                Console.WriteLine("SOLICITUD REGISTRADA");
                Console.WriteLine("=======================");

                Console.WriteLine("Codigo: " + codigos_actual[contador_paciente - 1]);
                Console.WriteLine("Fecha: " + fecha[contador_paciente - 1]);
                Console.WriteLine("Paciente: " + nombres[contador_paciente - 1] + " " + apellidos[contador_paciente - 1]);
                Console.WriteLine("DNI: " + DNI[contador_paciente - 1]);
                Console.WriteLine("Centro de Salud: " + centroSalud[contador_paciente - 1]);
                Console.WriteLine("Distrito: " + distrito[contador_paciente - 1]);
                Console.WriteLine("Tipo de Solicitud: " + tipoSolicitud[contador_paciente - 1]);
                Console.WriteLine("Nivel de Emergencia: " + nivel_de_emergencia[contador_paciente - 1]);
                Console.WriteLine("Estado: " + nivel_de_estado[contador_paciente - 1]);
                Console.WriteLine("Prioridad: " + prioridad_final[contador_paciente - 1]);
                Console.WriteLine("Descripcion: " + descripcion[contador_paciente - 1]);
                
                // Registrar otro paciente

                Console.WriteLine("¿Desea registrar otro paciente? (S/N)");
                continuar = (Console.ReadLine().ToUpper());

                if (continuar == "S")
                {
                    if (contador_paciente < 101)
                    {
                        contador_paciente++;
                    }
                    else
                    {
                        Console.WriteLine("Se alcanzo el limite de 100 pacientes.");
                        continuar = "N";
                    }
                }
                else
                {
                    continuar = "N";
                }

            } while (continuar == "S");

            // Busqueda de pacientes

            do
            {
                Console.WriteLine("");
                Console.WriteLine("=======================");
                Console.WriteLine("BUSCAR PACIENTE");
                Console.WriteLine("=======================");

                Console.WriteLine("Ingrese el codigo del paciente:");
                codigo_busqueda = Console.ReadLine();

                encontrado = false;

                for (i = 0; i < contador_paciente; i++)
                {
                    if (codigo_busqueda == codigos_actual[i])
                    {
                        encontrado = true;

                        Console.WriteLine("");
                        Console.WriteLine("=======================");
                        Console.WriteLine("PACIENTE ENCONTRADO");
                        Console.WriteLine("=======================");

                        Console.WriteLine("Codigo: " + codigos_actual[i]);
                        Console.WriteLine("Fecha: " + fecha[i]);
                        Console.WriteLine("Paciente: " + nombres[i] + " " + apellidos[i]);
                        Console.WriteLine("DNI: " + DNI[i]);
                        Console.WriteLine("Centro de Salud: " + centroSalud[i]);
                        Console.WriteLine("Distrito: " + distrito[i]);
                        Console.WriteLine("Tipo de Solicitud: " + tipoSolicitud[i]);
                        Console.WriteLine("Nivel de Emergencia: " + nivel_de_emergencia[i]);
                        Console.WriteLine("Estado: " + nivel_de_estado[i]);
                        Console.WriteLine("Prioridad: " + prioridad_final[i]);
                        Console.WriteLine("Descripcion: " + descripcion[i]);

                        break;
                    }
                }

                if (encontrado == false)
                {
                    Console.WriteLine("Error: no se encontro ningun paciente con ese codigo.");
                }

                Console.WriteLine("¿Desea buscar otro paciente? (S/N)");
                decision = (Console.ReadLine().ToUpper());

            } while (decision == "S");
        }
    }
}