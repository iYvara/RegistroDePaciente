using System;
using System.IO;

namespace RegistroDePaciente
{
    internal class ArchivoPacientes
    {
        static string ruta = "pacientes.txt";

        // guarda un paciente sin borrar los anteriores
        public static void Guardar(string informacion)
        {
            File.AppendAllText(ruta, informacion + Environment.NewLine);
        }

        // lanza el mensaje de error en caso de no exista el archivo
        public static string[] Cargar()
        {
            if (!File.Exists(ruta))
            {
                return new string[0];
            }

            return File.ReadAllLines(ruta);
        }

        public static void Mostrar()
        {
            if (!File.Exists(ruta))
            {
                Console.WriteLine("Todavia no existe el archivo de pacientes.");
                return;
            }

            string[] pacientes = File.ReadAllLines(ruta);
            bool hayPacientes = false;

            Console.WriteLine("=== PACIENTES REGISTRADOS ===");

            foreach (string paciente in pacientes)
            {
                if (string.IsNullOrWhiteSpace(paciente))
                    continue;

                string[] datos = paciente.Split(';');

                if (datos.Length >= 12)
                {
                    Console.WriteLine("Codigo: " + datos[0] + " | Nombre: " + datos[1] + " " + datos[2] + " | DNI: " + datos[3] + " | Prioridad: " + datos[10]);
                }
                else
                {
                    Console.WriteLine(paciente);
                }

                hayPacientes = true;
            }

            if (!hayPacientes)
            {
                Console.WriteLine("No hay pacientes registrados.");
            }
        }

        // borra todos los pacientes
        public static void Borrar()
        {
            File.WriteAllText(ruta, "");
        }
    }
}