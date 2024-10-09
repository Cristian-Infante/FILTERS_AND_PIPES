using System;
using System.IO;
using System.Text;

namespace ConvertirArchivoBinarioATexto;

class ConvertirArchivoBinarioATexto
{
    static void Main(string[] args)
    {
        using (var reader = new BinaryReader(Console.OpenStandardInput()))
        {
            // Crear un MemoryStream para almacenar los datos leídos desde stdin
            using (MemoryStream ms = new MemoryStream())
            {
                byte[] buffer = new byte[1024];
                int bytesRead;

                // Leer hasta que no haya más datos
                while ((bytesRead = reader.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, bytesRead);
                }

                // Convertir el contenido del MemoryStream a texto
                string textData = Encoding.UTF8.GetString(ms.ToArray());

                // Si no hay más tuberías, guarda el archivo
                if (!Console.IsOutputRedirected)
                {
                    string outputFilePath = "archivo_convertido_BinarioATexto.txt";
                    File.WriteAllText(outputFilePath, textData);
                    Console.WriteLine($"Archivo guardado en: {outputFilePath}");
                }
                else
                {
                    // Escribir a stdout para la siguiente tubería
                    Console.Write(textData);
                }
            }
        }
    }
}