using System;
using System.IO;
using System.Text;

namespace ConvertirArchivoTextoABinario;

class ConvertirArchivoTextoABinario
{
    static void Main(string[] args)
    {
        using (var reader = new StreamReader(Console.OpenStandardInput()))
        {
            string input = reader.ReadToEnd();
            byte[] binaryData = Encoding.UTF8.GetBytes(input);

            // Si no hay más entrada estándar (indica que es el último en la cadena)
            if (!Console.IsOutputRedirected)
            {
                string outputFilePath = "archivo_convertido_TextoABinario.bin";
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
