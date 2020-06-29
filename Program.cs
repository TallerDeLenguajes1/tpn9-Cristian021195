using System;
using System.Collections.Generic;
using System.Text;
using DiccionarioMorse.Helpers;
using System.IO;

namespace DiccionarioMorse
{
    class Program
    {
        static void Main(string[] args)
        {
            int cond = 0;
            string entrada = "";
            string resTM = "";
            IDictionary<string, string> dict = new Dictionary<string, string>();
            IDictionary<string, string> rev = new Dictionary<string, string>();
            dict["a"] = ".- ";
            dict["b"] = "-... ";
            dict["c"] = "-.-. ";
            dict["d"] = "-.. ";
            dict["e"] = ". ";
            dict["f"] = "..-. ";
            dict["g"] = "--. ";
            dict["h"] = ".... ";
            dict["i"] = ".. ";
            dict["j"] = ".--- ";
            dict["k"] = "-.- ";
            dict["l"] = ".-.. ";
            dict["m"] = "-- ";
            dict["n"] = "-. ";
            dict["o"] = "--- ";
            dict["p"] = ".--. ";
            dict["q"] = "--.- ";
            dict["r"] = ".-. ";
            dict["s"] = "... ";
            dict["t"] = "- ";
            dict["u"] = "..- ";
            dict["v"] = "...- ";
            dict["w"] = ".-- ";
            dict["x"] = "-..- ";
            dict["y"] = "-.-- ";
            dict["z"] = "--.. ";
            dict["1"] = ".---- ";
            dict["2"] = "..--- ";
            dict["3"] = "...-- ";
            dict["4"] = "....- ";
            dict["5"] = "..... ";
            dict["6"] = "-.... ";
            dict["7"] = "--... ";
            dict["8"] = "---.. ";
            dict["9"] = "----. ";
            dict["0"] = "----- ";
            dict[" "] = "/";

            foreach (var entry in dict)//tomamos el diccionario creado, e invertimos agregando todo a otro diccionario
            {
                if (!rev.ContainsKey(entry.Value)) { 
                    rev.Add(entry.Value, entry.Key);
                }
            }
            do
            {
                Console.WriteLine("1 TEXTO A MORSE - 2 MORSE A TEXTO - 3 VER MORSES GUARDADOS - 0 SALIR!: ");
                cond = Convert.ToInt32(Console.ReadLine());
                if (cond == 1)
                {
                    int condIf = 0;
                    Console.WriteLine("Ingrese en Texto para convertir a Morse: ");
                    entrada = Console.ReadLine().ToLower();
                    resTM = ConversorDeMorse.TextoAMorse(entrada, dict, rev);
                    Console.WriteLine(resTM);

                    
                    do
                    {
                        Console.WriteLine("IMPRIMIR MORSE -> TXT FILE? 1 SI - 0 NO: ");
                        condIf = Convert.ToInt32(Console.ReadLine());

                        if (condIf == 1) {
                            ConversorDeMorse.imprimirMorseATexto(resTM);
                            condIf = 0;
                        }
                    } while (condIf != 0);
                }
                else if (cond == 2) {
                    Console.WriteLine("Ingrese en Morse para convertir a Texto: ");
                    entrada = Console.ReadLine().ToLower();
                    resTM = ConversorDeMorse.MorseATexto(entrada, dict, rev);
                    Console.WriteLine(resTM);
                }else if(cond == 3)
                {
                    string indice = "";
                    string respuesta="";
                    int cond3 = 0;
                    indice = ConversorDeMorse.verTextosEnMorse().ToString();
                    //Console.WriteLine(indice);
                    respuesta = ConversorDeMorse.MorseFileATexto(indice, dict, rev);
                    Console.WriteLine(respuesta);
                    Console.WriteLine("Desea guardar este texto traducido en la carpeta TXT? 1 SI - 0 NO");
                    cond3 = Convert.ToInt32(Console.ReadLine());
                    if (cond3 == 1) {
                        ConversorDeMorse.MorseTextATextFile(respuesta, dict, rev);
                    }
                }
            } while (cond != 0);
        }
    }
}
