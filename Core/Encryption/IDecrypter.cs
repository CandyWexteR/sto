namespace Core.Encryption;

public interface IDecrypter
{
    public Task<string> Decrypt(byte[] value);
    public Task<string> DecryptFromBase64(string base64);
}