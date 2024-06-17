using endef_keygen;

namespace endef_cryptor;

public class ENDEFcryptor
{
    private const byte BYTE255 = 0b11111111;

    public void _encrypt(string openFile, string saveFile)
    {
        using BinaryReader readFile = new(File.Open(openFile, FileMode.Open));
        using BinaryWriter writeFile = new(File.Open(saveFile, FileMode.Create));

        string key = new ENDEFkeygen()._keygen();
        byte[] _keyBytes = new ENDEFkeygen()._keyBytes(key);

        while (readFile.BaseStream.Position != readFile.BaseStream.Length)
        {
            byte wb = readFile.ReadByte();
            foreach (byte b in _keyBytes)
            {
                wb ^= b;
                wb = (byte)(BYTE255 - wb);
            }
            writeFile.Write(wb);
        }

        Console.WriteLine($"Ключ для файла {saveFile}: {key}");
    }

    public void _decrypt(string openFile, string saveFile, string key)
    {
        using BinaryReader readFile = new(File.Open(openFile, FileMode.Open));
        using BinaryWriter writeFile = new(File.Open(saveFile, FileMode.Create));

        while (readFile.BaseStream.Position != readFile.BaseStream.Length)
        {
            byte wb = readFile.ReadByte();
            foreach (byte b in key.Reverse())
            {
                wb ^= b;
                wb = (byte)(BYTE255 - wb);
            }
            writeFile.Write(wb);
        }
    }
}
