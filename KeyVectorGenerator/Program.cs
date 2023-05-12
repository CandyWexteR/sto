using System.Security.Cryptography;
using System.Text;

namespace KeyVectorGenerator;

public static class Progam
{
    public static void Main(string[] args)
    {
        var key = string.Empty;
        var vector = string.Empty;
        using (var rng = new RNGCryptoServiceProvider())
        {
            byte[] keyy = new byte[32];
            rng.GetBytes(keyy);
            key = Convert.ToBase64String(keyy);
        }
        
        using (var rng = new RNGCryptoServiceProvider())
        {
            var iv = new byte[16];
            rng.GetBytes(iv);
            vector = Convert.ToBase64String(iv);
        }

        Console.WriteLine($"Base 64 format\n");
        Console.WriteLine($"Key: {key}");
        Console.WriteLine($"Vector: {vector}");
        Console.WriteLine($"\nPress any key to continue");
        Console.ReadKey();
    }
}