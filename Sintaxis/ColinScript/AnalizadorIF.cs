using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace ColinScript
{
    internal class AnalizadorIF
    {
        private static readonly Dictionary<string, List<string>> Gramaticas = new Dictionary<string, List<string>>
    {
        { "S", new List<string> { "COND" } },
        { "COND", new List<string> { "ARG OPRE ARG" } },
        { "ARG", new List<string> { "IDEN", "CAD", "CONS" } },
        { "CONS", new List<string> { "CNE", "CNR" } },
        { "OPRE", new List<string> { "<", ">", ">=", "<=", "==" } }
    };

        public bool ValidarCondicion(string entrada)
        {
            try
            {
                string[] partes = entrada.Split(' ');
                if (partes.Length != 3)
                {
                    MessageBox.Show("Error: La condición no tiene el formato correcto.");
                    return false;
                }

                string arg1 = partes[0];
                string opre = partes[1];
                string arg2 = partes[2];

                // Validar ARG 1
                if (!EsArgumentoValido(arg1))
                {
                    MessageBox.Show($"Error: El argumento '{arg1}' no es válido.");
                    return false;
                }

                // Validar OPRE
                if (!Gramaticas["OPRE"].Contains(opre))
                {
                    MessageBox.Show($"Error: El operador '{opre}' no es válido.");
                    return false;
                }

                // Validar ARG 2
                if (!EsArgumentoValido(arg2))
                {
                    MessageBox.Show($"Error: El argumento '{arg2}' no es válido.");
                    return false;
                }

                MessageBox.Show("La condición es válida.");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error durante la validación: {ex.Message}");
                return false;
            }
        }

        private bool EsArgumentoValido(string argumento)
        {
            // Validar si es identificador (IDEN)
            if (Regex.IsMatch(argumento, "^_[A-Z][a-zA-Z0-9]*$")) return true;

            // Validar si es constante entera (CNE)
            if (Regex.IsMatch(argumento, @"^-?\d+$")) return true;

           

            

            return false;
        }

        //private Queue<string> tokens;
        //private string tokenActual;

        //public AnalizadorIF(IEnumerable<string> entradaTokens)
        //{
        //    tokens = new Queue<string>(entradaTokens);
        //    Avanzar();
        //}

        //private void Avanzar()
        //{
        //    tokenActual = tokens.Count > 0 ? tokens.Dequeue() : null;
        //}

        //private bool Coincidir(string esperado)
        //{
        //    if (tokenActual == esperado)
        //    {
        //        Avanzar();
        //        return true;
        //    }
        //    return false;
        //}

        //public bool Analizar()
        //{
        //    return ReglaS() && tokenActual == null;
        //}

        //private bool ReglaS()
        //{
        //    if (Coincidir("COND"))
        //    {
        //        return ReglaCOND();
        //    }
        //    return false;
        //}

        //private bool ReglaCOND()
        //{
        //    return ReglaARG() && ReglaOPRE() && ReglaARG();
        //}

        //private bool ReglaARG()
        //{
        //    return Coincidir("IDEN") || Coincidir("CAD") || ReglaCONS();
        //}

        //private bool ReglaCONS()
        //{
        //    return Coincidir("CNE") || Coincidir("CNR") || Coincidir("CNX");
        //}

        //private bool ReglaOPRE()
        //{
        //    return Coincidir("OPR<") || Coincidir("OPR>") || Coincidir("OPR>=") || Coincidir("OPR<=") || Coincidir("OPR==");
        //}

        //public static void Main()
        //{
        //    Console.WriteLine("Introduce los tokens separados por espacio:");
        //    string entrada = Console.ReadLine();
        //    string[] tokens = entrada.Split(' ');

        //    var analizador = new AnalizadorIF(tokens);
        //    if (analizador.Analizar())
        //    {
        //        Console.WriteLine("La cadena es válida.");
        //    }
        //    else
        //    {
        //        Console.WriteLine("La cadena no es válida.");
        //    }
        //}
    }
}
