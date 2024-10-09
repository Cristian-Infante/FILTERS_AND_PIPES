using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace EncriptarArchivoTextoSHA256;

class EncriptarArchivoTextoSHA256
{
    static void Main(string[] args)
    {
        using (var reader = new StreamReader(Console.OpenStandardInput()))
        {
            string inputText = reader.ReadToEnd();
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(inputText));

                // Convertir los bytes a formato hexadecimal
                StringBuilder hexHash = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    hexHash.Append(b.ToString("x2"));
                }

                // Si no hay más tuberías, guarda el archivo
                if (!Console.IsOutputRedirected)
                {
                    string outputFilePath = "archivo_encriptado_SHA256.txt";
                    File.WriteAllText(outputFilePath, hexHash.ToString());
                    Console.WriteLine($"Archivo guardado en: {outputFilePath}");
                }
                else
                {
                    // Escribir el hash en hexadecimal a stdout
                    Console.Write(hexHash.ToString());
                }
            }
        }
    }
}