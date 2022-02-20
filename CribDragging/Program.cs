//using System;

using System;
using System.Collections.Generic;

namespace CribDragging
{
    class Program
    {
        static void Main(string[] args)
        {
            //XORTest();
            Console.WriteLine("\n\n");

            string key1     = "AAAAAAAAAAAAAAAAAAAAAAA";
            string message1 = "The cat sat on the mat.";
            string message2 = "Hello, cruel old world.";

            var cipher1 = XORString(message1, key1);
            //PrintResult(cipher1, nameof(cipher1));

            var cipher2 = XORString(message2, key1);
            //PrintResult(cipher2, nameof(cipher2));

            var msg1XORmsg2 = XORString(message1, message2);
            var cipher1XORcipher2 = XORString(cipher1, cipher2);

            //PrintResult(msg1XORmsg2, nameof(msg1XORmsg2));
            //PrintResult(cipher1XORcipher2, nameof(cipher1XORcipher2));

            //---------------------------------------

            Console.WriteLine("From the results below you could expect to find decrypted chunks from the original message(s)");

            var cribDragResults = CribDrag(cipher1XORcipher2, "The ");
            PrintResult(cribDragResults, nameof(cribDragResults));


            cribDragResults = CribDrag(cipher1XORcipher2, " the ");
            PrintResult(cribDragResults, nameof(cribDragResults));

            cribDragResults = CribDrag(cipher1XORcipher2, "world");
            PrintResult(cribDragResults, nameof(cribDragResults));


            cribDragResults = CribDrag(cipher1XORcipher2, "cat sat on the mat");
            PrintResult(cribDragResults, nameof(cribDragResults));


            cribDragResults = CribDrag(cipher1XORcipher2, "o, cruel old world");
            PrintResult(cribDragResults, nameof(cribDragResults));



            Console.WriteLine("\n");

        }

        static IEnumerable<string> CribDrag(string xorCipher, string word)
        {
            Console.WriteLine("---------------------------------------------");
            var list = new List<string>();
            for (var i = 0; i <= xorCipher.Length - word.Length; i++ )
            {
                var chunk = xorCipher.Substring(i, word.Length);
                list.Add( XORString(word, chunk));
            }

            return list;
        }

        static void PrintResult( IEnumerable<string> results, string originalVarName = null)
        {
            foreach (var i in results)
            {
                PrintResult(i, originalVarName);
            }
        }

        static void PrintResult(string cipher, string originalVarName = null)
        {
            Console.WriteLine($"\t{originalVarName} |" + cipher + "|");
        }

        static string XORString(string str1, string str2)
        { 
            if(str1.Length != str2.Length) { return null; }

            var charset1 = str1.ToCharArray();
            var charset2 = str2.ToCharArray();
            

            for (var i = 0; i < charset1.Length; i++)
            {
                charset1[i] = (char)(charset1[i] ^ charset2[i]);
            }

            return new string(charset1);
        }

        static void XORTest()
        {
            Console.WriteLine(0 ^ 0);
            Console.WriteLine(0 ^ 1);
            Console.WriteLine(1 ^ 0);
            Console.WriteLine(1 ^ 1);
            Console.WriteLine("------------------------------");

            Console.WriteLine(9 ^ 12);
            Console.WriteLine(Convert.ToString(9 ^ 12, 2));
        }
    }
}
