using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Helper
{
    public static class SoporteParaConfiguracion
    {
        public static string CrearArchivo()
        {
            string carpeta = @"C:\repo9cele\";
            string NombreArch = "prueba";
            string RutarArch = carpeta + NombreArch + ".DAT";
            File.Create(RutarArch); // Crea un archivo Prueba .dat

            if (File.Exists(RutarArch)) //  Comprueba si existe el archivo
            {
                Console.WriteLine("Existe "+NombreArch+".DAT");
            }
            
            return RutarArch;
        }
        public static void LeerConfiguracion()
        {
            string carpeta = @"C:\repo9cele\prub.dat";
            if (File.Exists(carpeta))
            {
                using (BinaryWriter lectura = new BinaryWriter(File.Open(carpeta, FileMode.Open)))
                {
                    lectura.Write("hola cele :D");

                }

                using (BinaryReader lectura = new BinaryReader(File.Open(carpeta, FileMode.Open)))
                {
                    
                    string salida = lectura.ReadString();
                   Console.Write(salida);

                }
             
            }
            else
            {
                File.Create(carpeta);
                using (BinaryReader lectura = new BinaryReader(File.Open(carpeta, FileMode.Open)))
                {
                   // Console.Write("kajjaaa");
                    string salida = lectura.ReadString();
                }
            }
        }
        

    }
    public static class ConversorDeMorse
    {
        public static void TextoAMorse(string text)
        {
            
            string palabras = text;

            Dictionary<string, string> codigos = new Dictionary<string, string>

                        {

                            {"a", ".-   "}, {"b", "-... "}, {"c", "-.-. "}, {"d", "-..  "},

                            {"e", "."}, {"f", "..-. "}, {"g", "--.  "}, {"h", "...."},

                            {"i", "..   "}, {"j", ".--- "}, {"k", "-.-  "}, {"l", ".-.. "},

                            {"m", "--   "}, {"n", "-.   "}, {"o", "---  "}, {"p", ".--. "},

                            {"q", "--.- "}, {"r", ".-.  "}, {"s", "...  "}, {"t", "-    "},

                            {"u", "..-  "}, {"v", "...- "}, {"w", ".--  "}, {"x", "-..- "},

                            {"y", "-.-- "}, {"z", "--.. "}, {"0", "-----"}, {"1", ".----"},

                            {"2", "..---"}, {"3", "...--"}, {"4", "....-"}, {"5", "....."},

                            {"6", "-...."}, {"7", "--..."}, {"8", "---.."}, {"9", "----."},

                            {" ", "//// "}, {".",".-.-.-"}, {",","--..--"}, {"?","..--.."},

                            {"!", "-.---"}

                        };
            Console.Write("\n EL TEXTO TRADUCIDO a MORSE ES: ");
            string textTraduc = "";//variable con nombre de texto traducido
            foreach (char letra in palabras)
            {
                Console.Write(codigos[letra.ToString()] + " ");
                textTraduc += codigos[letra.ToString()];
            }
            //Creo un archivo .txt y guardar el texto traducido
            string archivo = @"C:\repo9cele\morse.txt";
            if (!File.Exists(archivo))
            {
                File.Create(archivo);
                string[] TEXT = File.ReadAllLines(archivo);
                string yaExiste = "";
                foreach (string ANT in TEXT)
                {
                    yaExiste += ANT + " " + textTraduc;
                }

                using (BinaryWriter lectura = new BinaryWriter(File.Open(archivo, FileMode.Open)))
                {
                    lectura.Write(yaExiste);
                }

            }
            else
            {
                string[] TEXT = File.ReadAllLines(archivo);
                string yaExiste = "";
                foreach(string ANT in TEXT)
                {
                    yaExiste += ANT + " " + textTraduc;
                }

                using (BinaryWriter lectura = new BinaryWriter(File.Open(archivo, FileMode.Open)))
                {
                    lectura.Write(yaExiste);
                }
            }

        }
        public static void MorseATexto(string morse)
        {

            string palabras2 = morse;

            Dictionary<string, string> codigos2 = new Dictionary<string, string>

                    {

                            {".-   ", "a"}, { "-... ", "b"}, {"-.-. ", "c"}, {"-..  ", "d"},

                            {".    ", "e"}, {"..-. ", "f"}, {"--.  ", "g"}, {".... ", "h"},

                            {"..   ", "i"}, {".--- ", "j"}, {"-.-  ", "k"}, {".-.. ", "l"},

                            {"--    ", "m"}, {"-.   ", "n"}, {"---  ", "o"}, {".--. ", "p"},

                            {"--.- ", "q"}, {".-.  ", "r"}, {"...  ", "s"}, {"-    ", "t"},

                            {"..-  ", "u"}, {"...- ", "v"}, {".--  ", "w"}, {"-..-  ", "x"},

                            {"-.-- ", "y"}, {"--.. ", "z"}, {"-----", "0"}, {".----", "1"},

                            {"..---", "2"}, {"...--", "3"}, {"....-", "4"}, {".....", "5"},

                            {"-....", "6"}, {"--...", "7"}, {"---..", "8"}, {"----.", "9"},

                            {"//// ", " "}, {".-.-.-","."}, {"--..--",","}, {"..--..","?"},

                            {"-.---", "!"}

                     };
            Console.Write("\n MORSE TRADUCIDO a TEXTO ES: ");
            string textTraduc = "";//variable con nombre de texto traducido
            int cont = 0;
            string unaLetra=""; //para leer cada 
            foreach (char letra2 in palabras2)
            {
                cont++;
                unaLetra += letra2;
                if(cont % 5 == 0)
                {
                    Console.Write(codigos2[unaLetra]);
                    textTraduc += codigos2[unaLetra];
                    unaLetra = "";
                }
                
            }
            //Creo un archivo .txt y guardar el texto traducido
            string archivo = @"C:\repo9cele\texto.txt";
            if (!File.Exists(archivo))
            {
                File.Create(archivo);
               
                string[] TEXT = File.ReadAllLines(archivo);
                string yaExiste = "";
                foreach (string ANT in TEXT)
                {
                    yaExiste += ANT + " " + textTraduc;
                }

                using (BinaryWriter lectura = new BinaryWriter(File.Open(archivo, FileMode.Open)))
                {
                    lectura.Write(yaExiste);
                }

            }
            else
            {
                string[] TEXT = File.ReadAllLines(archivo);
                string yaExiste = "";
                foreach (string ANT in TEXT)
                {
                    yaExiste += ANT + " " + textTraduc;
                }

                using (BinaryWriter lectura = new BinaryWriter(File.Open(archivo, FileMode.Open)))
                {
                    lectura.Write(yaExiste);
                }
            }
           
        }

        public static void MorseMp3( string morse)
        {
            string punto = @"C:\repo9cele\punto.mp3";
            string raya = @"C:\repo9cele\raya.mp3";
            string MORSE = @"C:\repo9cele\Morse.mp3";

            FileStream origenP = new FileStream(punto, FileMode.Open);
            FileStream origenR = new FileStream(raya, FileMode.Open);
            FileStream destino = new FileStream(MORSE, FileMode.Create);
            BinaryWriter destinob = new BinaryWriter(destino);
            //morse = ".";
            char[] Morse = morse.ToArray();
            //int pos = 0;
            for( int i = 0; i < Morse.Length; i++)
            {
                Console.Write(Morse[i]);
                 if (Morse[i] == '.')
                {
                   // Console.Write("\n----------------jajaja\n");
                    byte[] valorArchi = leerBinario(origenP);
                    //pos ++;
                    destinob.Write(valorArchi, 0,  valorArchi.Length);
                    Console.Write("\n");
                    Console.Write(destinob);
                    Console.Write("\n");
                }
                else
                {
                    if (Morse[i] == '-')
                    {
                        byte[] valorArchi = leerBinario(origenR);
                      //  Console.Write("\nllllllllllllllllllllllllll\n");
                        destinob.Write(valorArchi, 0, valorArchi.Length);
                        Console.Write("\n");
                        Console.Write(destinob);
                        Console.Write("\n");
                    }
                }
            }
            origenP.Close();
            origenR.Close();
            destino.Flush();
            destino.Close();
        }


        public static byte[] leerBinario (Stream stream)
        {
            byte[] buffer = new byte[32768];
            using (MemoryStream ms = new MemoryStream()) // creando un memory stream 
            {
                while (true)
                {
                    int read = stream.Read(buffer, 0, buffer.Length); // lee desde la última posición hasta el tamaño del buffer
                    if (read <= 0)
                        return ms.ToArray(); // convierte el stream en array 
                    ms.Write(buffer, 0, read); // graba en el stream 
                }
            }
        }



    }
}
