using System.Security.Cryptography;
using Core.Encryption;

namespace WebApi.Additonal;

public class Crypter : IEncrypter, IDecrypter
{
    private readonly byte[] _vector;
    private readonly byte[] _key;

    public Crypter(IConfiguration config)
    {
        var encryptSection = config.GetSection("Encrypt");
        _vector = Convert.FromBase64String(encryptSection.GetValue<string>("Vector"));
        _key = Convert.FromBase64String(encryptSection.GetValue<string>("Key"));
    }

    public async Task<byte[]> Encrypt(string value)
    {
        byte[] encrypted;

        using (var aesAlg = Aes.Create())
        {
            aesAlg.Key = _key;
            aesAlg.IV = _vector;

            var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using (var msEncrypt = new MemoryStream())
            {
                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (var swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(value);
                    }

                    encrypted = msEncrypt.ToArray();
                }
            }
        }

        return encrypted;
    }

    public async Task<string> Decrypt(byte[] value)
    {
        var plaintext = string.Empty;

        using (var aesAlg = Aes.Create())
        {
            aesAlg.Key = _key;
            aesAlg.IV = _vector;

            var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using (var msDecrypt = new MemoryStream(value))
            {
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (var srDecrypt = new StreamReader(csDecrypt))
                    {
                        plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }
        }

        return plaintext;
    }

    public Task<string> DecryptFromBase64(string base64)
    {
        var bytes = Convert.FromBase64String(base64);
        return Decrypt(bytes);
    }

    public async Task<string> EncryptToBase64(string value)
    {
        var encryptedBytes = await Encrypt(value);
        return Convert.ToBase64String(encryptedBytes);
    }
}