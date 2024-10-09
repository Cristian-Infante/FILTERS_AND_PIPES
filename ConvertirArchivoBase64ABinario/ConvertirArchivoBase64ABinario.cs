using System;
using System.IO;

namespace ConvertirArchivoBase64ABinario;

class ConvertirArchivoBase64ABinario
{
    static void Main(string[] args)
    {
        using (var reader = new StreamReader(Console.OpenStandardInput()))
        {
            string base64Data = reader.ReadToEnd();
            byte[] binaryData = Convert.FromBase64String(base64Data);

            // Si no hay más tuberías, guarda el archivo
            if (!Console.IsOutputRedirected)
            {
                string outputFilePath = "archivo_convertido_Base64ABinario.bin";
                File.WriteAllBytes(outputFilePath, binaryData);
                Console.WriteLine($"Archivo guardado en: {outputFilePath}");
            }
            else
            {
                // Escribir el binario a stdout para la siguiente tubería
                Console.OpenStandardOutput().Write(binaryData, 0, binaryData.Length);
            }
        }
    }
}