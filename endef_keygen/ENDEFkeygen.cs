using System.Text;

namespace endef_keygen;

public class ENDEFkeygen
{
    private const string DICT = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

    public string _keygen()
    {
        string key = "";
        for (int i = 0; i < new Random().Next(8, 32); i++)
        {
            key += DICT[new Random().Next(DICT.Length)];
        }
        return key;
    }

    public byte[] _keyBytes(string key)
    {
        return Encoding.ASCII.GetBytes(key);
    }
}
