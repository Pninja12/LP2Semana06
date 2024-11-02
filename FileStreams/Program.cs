using System;
using System.IO;
using System.Text;

namespace FileStreams
{
    public class Program
    {
        // Nomes dos ficheiros
        private const string filenameText = "dados.txt";
        private const string filenameBinary = "dados.bin";

        // Dados a escrever e ler nos ficheiros
        private const string dataString = "Hello world!";
        private const int dataInt = 18;
        private const float dataFloat = 3.1415f;

        private static void Main()
        {
            // String para onde ler opção inserida pelo utilizador
            string option;

            // Ciclo do menu principal
            do
            {
                // Apresentar menu principal
                Console.WriteLine("==== Que programa devo executar? ==== \n");
                Console.WriteLine("\t1. Escreve ficheiro em modo de texto");
                Console.WriteLine("\t2. Lê ficheiro em modo de texto");
                Console.WriteLine("\t3. Escreve ficheiro em modo binário");
                Console.WriteLine("\t4. Lê ficheiro em modo binário");
                Console.WriteLine("\t5. Sair");
                Console.Write("\n>");

                // Solicitar opção ao utilizador
                option = Console.ReadLine();

                // Tratar opção do utilizador
                switch (option)
                {
                    case "1":
                        EscreverTexto(); break;
                    case "2":
                        LerTexto(); break;
                    case "3":
                        EscreverBin(); break;
                    case "4":
                        LerBin(); break;
                    case "5":
                        Console.WriteLine("Obrigado e até à próxima!");
                        break;
                    default:
                        Console.WriteLine("**** Opção inválida! ****");
                        break;
                }

                Console.WriteLine(
                    "Pressione qualquer tecla para continuar...");
                Console.ReadKey();

            } while (option != "5");
        }

        // 1. Escreve ficheiro em modo de texto
        private static void EscreverTexto()
        {
            using (TextWriter tw = File.CreateText(filenameText))
            {
                tw.WriteLine(dataString);
                tw.WriteLine(dataInt);
                tw.WriteLine(dataFloat);
            }
        }

        // 2. Lê ficheiro em modo de texto
        private static void LerTexto()
        {
            using (TextReader tr = File.OpenText(filenameText))
        {
            string s;
            while ((s = tr.ReadLine()) != null)
            {
                Console.WriteLine(s);
            }
        }
        }

        // 3. Escreve ficheiro em modo binário
        private static void EscreverBin()
        {
            using (var stream = File.Open(filenameBinary, FileMode.Create))
        {
            using (var bw = new BinaryWriter(stream, Encoding.UTF8, false))
            {
                bw.Write(dataString);
                bw.Write(dataInt);
                bw.Write(dataFloat);
            }
            }
        }

        // 4. Lê ficheiro em modo binário
        private static void LerBin()
        {
            string stringRead;
            int intRead;
            float floatRead;

            using (var stream = File.Open(filenameBinary, FileMode.Open))
            {
                using (var reader = new BinaryReader(stream, Encoding.UTF8, false))
                {
                    stringRead = reader.ReadString();
                    intRead = reader.ReadInt32();
                    floatRead = reader.ReadSingle();
                }
            }

            Console.WriteLine($"{stringRead}, {intRead}, {floatRead}");
        }
    }
}
