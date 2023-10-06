// -----------------------------------------------------------------------
// <copyright file="Gui.cs" company="m">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace PostSingleton
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public static class Util
    {
        public static int PromptForInt(string msg)
        {
            int resp = 0;
            Console.Write(msg + "> ");
            string s = Console.ReadLine();
            if (!string.IsNullOrEmpty(s))
            {
                if (IsNumber(s))
                    resp = Convert.ToInt32(s);
            }
            return resp;
        }

        internal static void Pause()
        {
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue...");
            Console.ReadKey();
        }

        internal static string Prompt(string message)
        {
            string input = null;
            Console.Write(message);
            input = Console.ReadLine();
            return input;
        }

        static bool IsNumber(string s)
        {
            string pattern = @"^\d+$";
            if (Regex.Match(s, pattern).Success)
                return true;
            return false;
        }

        internal static void DisplayMenu(string[] menu, char[] options)
        {
            Console.WriteLine();
            for (int i = 0; i < menu.Length;i++ )
            {
                Console.WriteLine("\t{0}) {1}.", options[i], menu[i]);
            }
            Console.WriteLine();
        }

        internal static void DisplayMenu(string[] menu)
        {
            Console.WriteLine();
            int counter = 1;
            foreach (var item in menu)
            {
                Console.WriteLine("\t{0}) {1}.",counter,item);
                counter++;
            }
            Console.WriteLine();
        }

        internal static void Title(string msg)
        {
            Console.WriteLine();
            var arr = msg.ToUpper().ToCharArray();
            Console.WriteLine();
            Console.Write("\n\t");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(" {0}",arr[i]);
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        internal static char PromptOption(string msg)
        {
            Console.Write("\t" + msg);
            Console.Write(" > ");
            string option = Console.ReadLine();
            return option[0];
        }

        internal static int[] PromptForArray(int size)
        {
            int[] resp = new int[size];
            for (int i = 0; i < size; i++)
            {
                int v = PromptForInt(string.Format("\tValor de  [{0}]= ",i));
                resp[i] = v;
            }
            return resp;
        }

        internal static void Print(string msg)
        {
            Console.WriteLine("\t{0}",msg);
        }
    }
}
