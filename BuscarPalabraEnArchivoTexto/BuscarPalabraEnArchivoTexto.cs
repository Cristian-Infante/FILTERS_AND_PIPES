using System;
using System.IO;

namespace BuscarPalabraEnArchivoTexto;

class BuscarPalabraEnArchivoTexto
{
    static void Main(string[] args)
    {
        if (args.Length < 1)
        {
            Console.WriteLine("Por favor, proporciona una palabra para buscar.");
            return;
        }

        string palabra = args[0];

        string contenido;

        // Leer el contenido desde stdin
        if (Console.IsInputRedirected)
        {
            using (var reader = new StreamReader(Console.OpenStandardInput()))
            {
                contenido = reader.ReadToEnd();
            }
        }
        else
        {
            Console.WriteLine("No se ha proporcionado un archivo o no se puede leer el archivo.");
            return;
        }

        // Buscar la palabra en el contenido
        bool encontrado = contenido.Contains(palabra);

        // Mostrar el resultado en consola
        if (encontrado)
        {
            Console.WriteLine($"La palabra '{palabra}' fue encontrada en el archivo.");
        }
        else
        {
            Console.WriteLine($"La palabra '{palabra}' NO fue encontrada en el archivo.");
        }
    }
}