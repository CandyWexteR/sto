namespace Core.Encryption;

public interface IEncrypter
{
    public Task<byte[]> Encrypt(string value);
    public Task<string> EncryptToBase64(string value);
}