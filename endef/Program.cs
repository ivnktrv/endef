using endef_cryptor;

namespace endef;

internal class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0) Console.WriteLine("Вы не передали параметров");

        else
        {
            ENDEFcryptor c = new();
            if (args[0] == "-e" || args[0] == "--encrypt")
                c._encrypt(args[1], args[2]);

            else if (args[0] == "-d" || args[0] == "--decrypt")
                c._decrypt(args[1], args[2], args[3]);

            else if (args[0] == "--version")
                Console.WriteLine("""
                    ENDEF cryptor, version 1.0 (17062024)
                    GitHub: https://github.com/ivnktrv/endef
                    """);
            else if (args[0] == "-h" || args[0] == "--help")
                Console.WriteLine("""
                    endef -h     | <= справка
                    endef --help |

                    endef -e [будучи зашифрованный файл] [имя зашифрованного файла]        | <= зашифровать файл
                    endef --encrypt [будучи зашифрованный файл] [имя зашифрованного файла] |

                    endef -d [зашифрованный файл] [имя расшифрованного файла] [ключ]        | <= расшифровать файл
                    endef --decrypt [зашифрованный файл] [имя расшифрованного файла] [ключ] |
                    
                    endef --version | <= версия программы
                    """);
            else
                Console.WriteLine("Неизвестный параметр");
        }
    }
}
//            0        1       2      3
// endef --decrypt file1.txt file2 f1f4f87f