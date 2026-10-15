using System;

namespace RegistroDePaciente
{
    class Program
    {
        static string ruta = "pacientes.txt";

        // arma el codigo tipo PAC-0001
        static string GenerarCodigoDePaciente(int contador)
        {
            string numerodecodigo = Convert.ToString(contador);

            while (numerodecodigo.Length < 4)
            {
                numerodecodigo = "0" + numerodecodigo;
            }

            return "PAC-" + numerodecodigo;
        }

        static int CalcularPrioridad(int nivel_de_emergencia, string tipoSolicitud)
        {
            int prioridad = nivel_de_emergencia * 2;
            tipoSolicitud = tipoSolicitud.ToUpper();

            if (tipoSolicitud == "AMBULANCIA" || tipoSolicitud == "MEDICAMENTOS")
            {
                prioridad = prioridad + 3;
            }

            return prioridad;
        }

        static void Main(string[] args)
        {
            string opcion;

            do
            {
                Console.WriteLine();
                Console.WriteLine("=======================");
                Console.WriteLine("SISTEMA DE PACIENTES");
                Console.WriteLine("=======================");
                Console.WriteLine("1. Registrar paciente");
                Console.WriteLine("2. Mostrar pacientes guardados");
                Console.WriteLine("3. Buscar paciente por codigo");
                Console.WriteLine("4. Borrar todos los pacientes");
                Console.WriteLine("5. Salir");
                Console.WriteLine("=======================");
                Console.WriteLine("Ingrese una opcion:");
                opcion = Console.ReadLine();

                if (opcion == "1")
                {
                    RegistrarPacientes();
                }
                else if (opcion == "2")
                {
                    ArchivoPacientes.Mostrar();
                    Pausar();
                }
                else if (opcion == "3")
                {
                    BuscarPaciente();
                }
                else if (opcion == "4")
                {
                    Console.WriteLine("¿Esta seguro de borrar todos los pacientes? (S/N)");
                    string respuesta = Console.ReadLine().ToUpper();

                    if (respuesta == "S")
                    {
                        ArchivoPacientes.Borrar();
                        Console.WriteLine("Se borraron los registros.");
                    }
                    else
                    {
                        Console.WriteLine("Operacion cancelada.");
                    }
                    Pausar();
                }
                else if (opcion == "5")
                {
                    Console.WriteLine("Saliendo del sistema...");
                }
                else
                {
                    Console.WriteLine("Error: opcion no valida.");
                    Pausar();
                }

            } while (opcion != "5");
        }

        static void RegistrarPacientes()
        {
            int contador_paciente, i, p;
            string continuar, estado;
            bool repetido;

            string[] registros = ArchivoPacientes.Cargar();

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

            // primero cargo lo que ya estaba guardado en el archivo
            contador_paciente = 1;

            foreach (string registro_guardado in registros)
            {
                if (string.IsNullOrWhiteSpace(registro_guardado))
                    continue;

                string[] datos = registro_guardado.Split(';');

                if (datos.Length >= 12 && contador_paciente <= 100)
                {
                    p = contador_paciente - 1;

                    codigos_actual[p] = datos[0];
                    nombres[p] = datos[1];
                    apellidos[p] = datos[2];
                    int.TryParse(datos[3], out DNI[p]);
                    fecha[p] = datos[4];
                    distrito[p] = datos[5];
                    centroSalud[p] = datos[6];
                    tipoSolicitud[p] = datos[7];
                    descripcion[p] = datos[8];
                    int.TryParse(datos[9], out nivel_de_emergencia[p]);
                    int.TryParse(datos[10], out prioridad_final[p]);
                    nivel_de_estado[p] = datos[11];

                    contador_paciente++;
                }
            }

            if (contador_paciente > 100)
            {
                Console.WriteLine("Se alcanzo el limite de 100 pacientes.");
                Pausar();
                return;
            }

            continuar = "S";

            do
            {
                p = contador_paciente - 1;

                Console.WriteLine("=======================");
                Console.WriteLine("REGISTROS DE PACIENTES");
                Console.WriteLine("=======================");

                codigos_actual[p] = GenerarCodigoDePaciente(contador_paciente);

                // nombres
                do
                {
                    Console.WriteLine("Ingrese sus nombres:");
                    nombres[p] = Console.ReadLine();

                    if (nombres[p] == "")
                    {
                        Console.WriteLine("Error: El campo de nombres no puede estar vacio.");
                    }
                } while (nombres[p] == "");

                // apellidos
                do
                {
                    Console.WriteLine("Ingrese los apellidos completos:");
                    apellidos[p] = Console.ReadLine();

                    if (apellidos[p] == "")
                    {
                        Console.WriteLine("Error: debe ingresar los apellidos.");
                    }
                } while (apellidos[p] == "");

                // DNI (8 digitos y que no se repita)
                do
                {
                    repetido = false;

                    Console.WriteLine("Ingrese su DNI:");
                    int.TryParse(Console.ReadLine(), out DNI[p]);

                    if (DNI[p] < 10000000 || DNI[p] > 99999999)
                    {
                        Console.WriteLine("Error: El DNI debe tener 8 digitos.");
                        repetido = true;
                    }
                    else
                    {
                        for (i = 0; i < p; i++)
                        {
                            if (DNI[i] == DNI[p])
                            {
                                repetido = true;
                                Console.WriteLine("Error: este DNI ya fue registrado.");
                                break;
                            }
                        }
                    }
                } while (repetido);

                fecha[p] = DateTime.Now.ToString("dd/MM/yyyy");

                distrito[p] = "El Agustino";
                centroSalud[p] = "Hospital Nacional Unanue";
                tipoSolicitud[p] = "Ambulancia";
                descripcion[p] = "Requiere oxigeno de emergencia";

                // nivel de emergencia
                do
                {
                    Console.WriteLine("Nivel de Emergencia (1 al 5)");
                    int.TryParse(Console.ReadLine(), out nivel_de_emergencia[p]);

                    switch (nivel_de_emergencia[p])
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

                    nivel_de_estado[p] = estado;

                } while (nivel_de_emergencia[p] < 1 || nivel_de_emergencia[p] > 5);

                prioridad_final[p] = CalcularPrioridad(nivel_de_emergencia[p], tipoSolicitud[p]);

                Console.WriteLine("=======================");
                Console.WriteLine("SOLICITUD REGISTRADA");
                Console.WriteLine("=======================");
                Console.WriteLine("Codigo: " + codigos_actual[p]);
                Console.WriteLine("Fecha: " + fecha[p]);
                Console.WriteLine("Paciente: " + nombres[p] + " " + apellidos[p]);
                Console.WriteLine("DNI: " + DNI[p]);
                Console.WriteLine("Centro de Salud: " + centroSalud[p]);
                Console.WriteLine("Distrito: " + distrito[p]);
                Console.WriteLine("Tipo de Solicitud: " + tipoSolicitud[p]);
                Console.WriteLine("Nivel de Emergencia: " + nivel_de_emergencia[p]);
                Console.WriteLine("Estado: " + nivel_de_estado[p]);
                Console.WriteLine("Prioridad: " + prioridad_final[p]);
                Console.WriteLine("Descripcion: " + descripcion[p]);

                // guardo en el archivo (mismo formato de antes, con ; al final)
                string registro = codigos_actual[p] + ";" + nombres[p] + ";" + apellidos[p] + ";" +
                                  DNI[p] + ";" + fecha[p] + ";" + distrito[p] + ";" +
                                  centroSalud[p] + ";" + tipoSolicitud[p] + ";" + descripcion[p] + ";" +
                                  nivel_de_emergencia[p] + ";" + prioridad_final[p] + ";" +
                                  nivel_de_estado[p] + ";";

                ArchivoPacientes.Guardar(registro);
                Console.WriteLine("Paciente guardado correctamente.");

                Console.WriteLine("¿Desea registrar otro paciente? (S/N)");
                continuar = Console.ReadLine().ToUpper();

                if (continuar == "S")
                {
                    if (contador_paciente < 100)
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

            Pausar();
        }

        // busca en el archivo, asi funciona con pacientes de ejecuciones anteriores
        static void BuscarPaciente()
        {
            bool encontrado = false;

            Console.WriteLine("=======================");
            Console.WriteLine("BUSCAR PACIENTE");
            Console.WriteLine("=======================");

            Console.WriteLine("Ingrese el codigo del paciente:");
            string codigo_busqueda = Console.ReadLine();

            string[] registros = ArchivoPacientes.Cargar();

            foreach (string registro in registros)
            {
                if (string.IsNullOrWhiteSpace(registro))
                    continue;

                string[] datos = registro.Split(';');

                if (datos.Length >= 12 && codigo_busqueda == datos[0])
                {
                    encontrado = true;

                    Console.WriteLine("=======================");
                    Console.WriteLine("PACIENTE ENCONTRADO");
                    Console.WriteLine("=======================");
                    Console.WriteLine("Codigo: " + datos[0]);
                    Console.WriteLine("Fecha: " + datos[4]);
                    Console.WriteLine("Paciente: " + datos[1] + " " + datos[2]);
                    Console.WriteLine("DNI: " + datos[3]);
                    Console.WriteLine("Centro de Salud: " + datos[6]);
                    Console.WriteLine("Distrito: " + datos[5]);
                    Console.WriteLine("Tipo de Solicitud: " + datos[7]);
                    Console.WriteLine("Nivel de Emergencia: " + datos[9]);
                    Console.WriteLine("Estado: " + datos[11]);
                    Console.WriteLine("Prioridad: " + datos[10]);
                    Console.WriteLine("Descripcion: " + datos[8]);

                    break;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("Error: no se encontro ningun paciente con ese codigo.");
            }

            Pausar();
        }

        static void Pausar()
        {
            Console.WriteLine();
            Console.WriteLine("Presiona Enter para volver al menu.");
            Console.ReadLine();
        }
    }
}