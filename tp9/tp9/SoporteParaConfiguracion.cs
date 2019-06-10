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
            string carpeta = @"C:\taller_1\repo9";
            string NombreArch = "prueba";
            string RutarArch = carpeta + NombreArch + ".DAT";
            File.Create(RutarArch); // Crea un archivo Prueba .dat

            if (File.Exists(RutarArch)) // Crea un Comprueba si existe el archivo
            {
                Console.WriteLine("Existe "+NombreArch+".DAT");
            }
            
            return RutarArch;
        }
        public static void LeerConfiguracion()
        {
            string carpeta = @"C:\taller_1\repo9\prub.dat";
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

                            {"e", ".    "}, {"f", "..-. "}, {"g", "--.  "}, {"h", ".... "},

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
            string archivo = @"C:\taller_1\repo9\morse.txt";
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

                            {".-", "a"}, { "-... ", "b"}, {"-.-. ", "c"}, {"-..  ", "d"},

                            {".     ", "e"}, {"..-. ", "f"}, {"--.  ", "g"}, {".... ", "h"},

                            {"..   ", "i"}, {".--- ", "j"}, {"-.-  ", "k"}, {".-.. ", "l"},

                            {"--   ", "m"}, {"-.    ", "n"}, {"---  ", "o"}, {".--. ", "p"},

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
            foreach (char letra2 in palabras2)
            {
                Console.Write(codigos2[letra2.ToString()] + " ");
                textTraduc += codigos2[letra2.ToString()];
            }
            //Creo un archivo .txt y guardar el texto traducido
            string archivo = @"C:\taller_1\repo9\texto.txt";
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

    }
}
