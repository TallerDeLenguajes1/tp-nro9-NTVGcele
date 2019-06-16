using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helper;
using System.IO;

namespace tp9
{
    class Program
    {
        static void Main(string[] args)
        {

            string Archivo = SoporteParaConfiguracion.CrearArchivo();
            SoporteParaConfiguracion.LeerConfiguracion();
            string pegar = @"C:\repo9cele\tp9\tp9\bin\Debug";
            string copiar = @"C:\repo9cele";
            string result;
            string[] mostrar;
            result = Path.GetFileName(pegar);
            // Console.WriteLine("GetFileName('{0}') returns '{1}'",path1, result);
            try
            {
                mostrar = Directory.GetFiles(pegar);
                foreach (string leer in mostrar) {
                    Console.Write("\n" + leer);
                }
                string[] busque = Directory.GetFiles(pegar, "*.txt");
                foreach (string guarda in busque)
                {
                    string guardarm = guarda.Substring(pegar.Length + 1);
                    File.Copy(Path.Combine(pegar, guardarm), Path.Combine(copiar, guardarm));
                }
                busque = Directory.GetFiles(pegar, "*.mp3");

                foreach (string guarda in busque)
                {
                    string guardarm = guarda.Substring(pegar.Length + 1);
                    File.Copy(Path.Combine(pegar, guardarm), Path.Combine(copiar, guardarm));
                }
            }
            catch (Exception)
            {
                Console.Write("\nLos archivos ya existen");
            }

            //Paso 2. Creando el conversor de morse a texto y viceversa

            //TEXTO a MORSE
            string text;
            Console.Write("\nEscriba un texto para traducirlo: ");
            text = Convert.ToString(Console.ReadLine());
            ConversorDeMorse.TextoAMorse(text);

            //MORSE a TEXTO
            string morse;
            Console.Write("\nEscriba un texto en morse para traducirlo(respetando lo espacios): ");
            morse = Convert.ToString(Console.ReadLine());
            ConversorDeMorse.MorseATexto(morse);
            ConversorDeMorse.MorseMp3(morse);

            Console.ReadKey();

        }
        //string PUNTO = @"C:\repo9cele\punto.mp3";
        ////SONIDO RAYA mp3 
        //string RAYA = @"C:\repo9cele\raya.mp3";

        //string archiv = @"C:\repo9cele\morse.txt"; //archivo de texto a morse traducido
        //string contenido = File.ReadAllText(archiv);
        //byte[] buffer = new byte[128];
        ////LEER morse.mp3

        //string MORSE = @"c:\repo9cele\morse.mp3";
        //BinaryReader punt = new BinaryReader(File.Open(PUNTO, FileMode.Open));
        //BinaryReader Raya = new BinaryReader(File.Open(RAYA, FileMode.Open));
        //FileStream mors = new FileStream(MORSE, FileMode.Create);
        //    //for
        //    // foreach(char arch in contenido)
        //    for (int i = 0; i<contenido.Length; i++)
        //    {
        //        if (morse == ".")
        //        {
        //            buffer = punt.ReadBytes(32000000);
        //            mors.Write(buffer,0,buffer.Length);
        //        }
        //        else
        //        {
        //            //    mors.Write(Raya.Read());
        //        }
    }
}
