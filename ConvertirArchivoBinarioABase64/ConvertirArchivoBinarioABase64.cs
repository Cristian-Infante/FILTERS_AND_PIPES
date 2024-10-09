using System;
using System.IO;

namespace ConvertirArchivoBinarioABase64;

class ConvertirArchivoBinarioABase64
{
    static void Main(string[] args)
    {
        using (var memoryStream = new MemoryStream())
        {
            // Leer los datos de la entrada estándar y almacenarlos en un MemoryStream
            var buffer = new byte[1024];
            int bytesRead;
            while ((bytesRead = Console.OpenStandardInput().Read(buffer, 0, buffer.Length)) > 0)
            {
                memoryStream.Write(buffer, 0, bytesRead);
            }

            // Convertir los datos leídos a Base64
            byte[] binaryData = memoryStream.ToArray();
            string base64String = Convert.ToBase64String(binaryData);

            // Si no hay más tuberías, guarda el archivo
            if (!Console.IsOutputRedirected)
            {
                string outputFilePath = "archivo_convertido_BinarioABase64.txt";
                File.WriteAllText(outputFilePath, base64String);
                Console.WriteLine($"Archivo guardado en: {outputFilePath}");
            }
            else
            {
                // Escribir a stdout para la siguiente tubería
                Console.Write(base64String);
            }
        }
    }
}