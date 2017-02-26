using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            if ( args == null || args.Length == 0 || !File.Exists(args[0]))
            {
                Console.WriteLine("The file does not exist, no file path has been provided or there is retricted access to the file.");
                Console.WriteLine(@"To use count please supply the location and name of the file to be processed in the format c:\foldername\file.txt");
                Console.WriteLine("Press enter to exit.");
                Console.Read();
                Environment.Exit(1);
            }

            StreamReader file = new StreamReader(args[0]);
            string line;
            Int32 WordCounter = 0;
            Int32 LineCounter = 0;
            Int32 CharacterCounter = 0;
            var list = new List<char>();

            //List<KeyValuePair<char, int>> letters = new List<KeyValuePair<char, int>>();
            //letters.Add(new KeyValuePair<char, int>('a', 0));

            while ((line = file.ReadLine()) != null)
            {                
                string[] ThisLine = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                WordCounter = WordCounter + ThisLine.Length;
                LineCounter++;
                foreach ( string word in ThisLine)
                {
                    string LCword = word.ToLower();
                    char[] aWord = LCword.ToCharArray();
                    CharacterCounter = CharacterCounter + aWord.Length;
                    foreach (char letter in aWord)
                    {
                        list.Add(letter);
                        //letters.;
                    }
                }
            }
            file.Close();
            double AverageLetters = Math.Round(((double)CharacterCounter / (double)WordCounter), 2);
            Console.WriteLine("The total number of words in this text file is {0} word(s).", WordCounter.ToString());
            Console.WriteLine("The total number of lines in this text file is {0} line(s).", LineCounter.ToString());
            Console.WriteLine("The average number of letters per word in this text file is {0} letters(s).", AverageLetters.ToString());
            var MostCommonLetter = list.GroupBy(x => x).OrderByDescending(x => x.Count()).First().Key;
            Console.WriteLine("The most common letter is '{0}'.", MostCommonLetter.ToString());
            Console.WriteLine("Press enter to exit.");
            Console.Read();
        }
    }
}
