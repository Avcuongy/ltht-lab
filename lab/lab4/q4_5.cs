using System;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;

public class q4_5
{
    public static void Solution()
    {
        string inputFile = "data.txt";
        string secureFile = "secure.bin";
        string outputFile = "output.txt";

        File.WriteAllText(inputFile, "Sensitive information");

        byte[] key, iv;

        // Encrypt + Compress
        byte[] plainData = File.ReadAllBytes(inputFile);

        using (Aes aes = Aes.Create())
        {
            key = aes.Key;
            iv = aes.IV;

            byte[] encrypted = aes.CreateEncryptor()
                .TransformFinalBlock(plainData, 0, plainData.Length);

            using (FileStream fs = new FileStream(secureFile, FileMode.Create))
            using (GZipStream gzip = new GZipStream(fs, CompressionMode.Compress))
            {
                gzip.Write(encrypted, 0, encrypted.Length);
            }
        }

        // Decompress + Decrypt
        byte[] compressed = File.ReadAllBytes(secureFile);
        byte[] decrypted;

        using (MemoryStream ms = new MemoryStream(compressed))
        using (GZipStream gzip = new GZipStream(ms, CompressionMode.Decompress))
        using (MemoryStream outMs = new MemoryStream())
        {
            gzip.CopyTo(outMs);
            byte[] encryptedData = outMs.ToArray();

            using (Aes aes2 = Aes.Create())
            {
                aes2.Key = key;
                aes2.IV = iv;

                decrypted = aes2.CreateDecryptor()
                    .TransformFinalBlock(encryptedData, 0, encryptedData.Length);
            }
        }

        File.WriteAllBytes(outputFile, decrypted);
        Console.WriteLine("Secure storage process completed.");
    }
}
