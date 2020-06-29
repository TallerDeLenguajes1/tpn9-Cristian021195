using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace DiccionarioMorse.Helpers
{
    public static class ConversorDeMorse
    {
        
        public static string MorseATexto(string cadena, IDictionary<string, string> dict, IDictionary<string, string> rev)
        {
            string nueva = "";
            string[] separador = cadena.Split("/");
            for (int i = 0; i < separador.Length; i++)
            {
                string[] separadorInt = separador[i].Split(" ");
                for (int c = 0; c < separadorInt.Length - 1; c++)
                {//   .... --- .-.. .- /
                    string cm = separadorInt[c] + " ";
                    //Console.WriteLine(rev[cm]);
                    nueva += rev[cm];
                }
                nueva += " ";
            }
            //Console.WriteLine(nueva);
            return nueva;
        }
        public static string TextoAMorse(string cadena, IDictionary<string, string> dict, IDictionary<string, string> rev)
        {
            int cont = cadena.Length;
            string nueva = "";
            for (int i = 0; i < cont; i++)
            {
                char c = cadena[i];
                nueva += dict[c.ToString()];
            }
            //Console.WriteLine(nueva);
            return nueva;
        }
        public static void imprimirMorseATexto(string textoMorse) {
            DateTime act = DateTime.Now;
            string[] src = Directory.GetCurrentDirectory().Split(@"\");
            string current = "";
            for (int i = 0; i < src.Length -1; i++) {
                current += src[i]+@"\";
            }
            if (!File.Exists(current + @"MORSE\textToMorse" + act.ToString("yyyy-MM-dd-T-HH-mm-ss") + ".txt")){
                File.WriteAllText(current + @"MORSE\textToMorse" + act.ToString("yyyy-MM-dd-T-HH-mm-ss")+".txt", textoMorse);
                //Console.WriteLine(current + @"TXT\textToMorse" + act.ToString("yyyy-MM-dd-T-HH-mm-ss")+".txt");
            }
        }
        public static string verTextosEnMorse() {
            int cont = 0;
            int indice = 0;
            string[] src = Directory.GetCurrentDirectory().Split(@"\");
            string current = "";
            for (int i = 0; i < src.Length - 1; i++)
            {
                current += src[i] + @"\";
            }
            List<string> contenido = Directory.GetFiles(current+"MORSE").ToList();
            Console.WriteLine("CUAL TEXTO MORSE DESEA TRADUCIR A TEXTO? - INGRESE SEGUN INDICE INDICADO: /n");
            foreach(string morseFile in contenido)
            {
                cont++;
                Console.WriteLine("({0}) {1}",cont,morseFile);
            }
            do
            {
                Console.WriteLine("CUAL ARCHIVO DESEA TRADUCIR? : ");
                indice = Convert.ToInt32(Console.ReadLine());
            } while (indice < 0);
            
            return contenido[indice-1];
        }
        public static string MorseFileATexto(string cadena, IDictionary<string, string> dict, IDictionary<string, string> rev)
        {
            string texto = File.ReadAllText(cadena);
            string nueva = "";
            string[] separador = texto.Split("/");
            Console.WriteLine(cadena);
            for (int i = 0; i < separador.Length; i++)
            {
                string[] separadorInt = separador[i].Split(" ");
                for (int c = 0; c < separadorInt.Length - 1; c++)
                {//   .... --- .-.. .- /
                    string cm = separadorInt[c] + " ";
                    //Console.WriteLine(rev[cm]);
                    nueva += rev[cm];
                }
                nueva += " ";
            }
            return nueva;
        }
        public static void MorseTextATextFile(string cadena, IDictionary<string, string> dict, IDictionary<string, string> rev) {
            DateTime act = DateTime.Now;
            string[] src = Directory.GetCurrentDirectory().Split(@"\");
            string current = "";
            for (int i = 0; i < src.Length - 1; i++)
            {
                current += src[i] + @"\";
            }
            if (!File.Exists(current + @"TXT\MorseToText" + act.ToString("yyyy-MM-dd-T-HH-mm-ss")+".txt"))
            {
                File.WriteAllText(current + @"TXT\MorseToText" + act.ToString("yyyy-MM-dd-T-HH-mm-ss") + ".txt", cadena);
                //Console.WriteLine(current + @"TXT\textToMorse" + act.ToString("yyyy-MM-dd-T-HH-mm-ss")+".txt");
            }

        }
    }
}
