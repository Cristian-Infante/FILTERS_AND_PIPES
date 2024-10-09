namespace CargarArchivoDeTexto;

using System;
using System.IO;

class CargarArchivoDeTexto
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Por favor, proporciona un archivo como parámetro.");
            return;
        }

        string inputFilePath = args[0];

        if (!File.Exists(inputFilePath))
        {
            Console.WriteLine($"El archivo '{inputFilePath}' no existe.");
            return;
        }

        // Leer el archivo y enviarlo a stdout
        string contenido = File.ReadAllText(inputFilePath);
        Console.Write(contenido);
    }
}
