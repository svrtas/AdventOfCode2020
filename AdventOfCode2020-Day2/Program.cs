using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020_Day2
{
    internal class Program
    {
        public static void Part1()
        {
            List<string> listOfPasswords = File.ReadAllLines("../../input.txt").ToList();

            int correct_counter = 0;

            foreach (var line in listOfPasswords)
            {
                //1-3 m: kdjfskdjfnnm
                var split = line.Split(' '); //split 0: from-to 1: char 2: pw

                var from_to = split[0].Split('-');
                int min = int.Parse(from_to[0]);
                int max = int.Parse(from_to[1]);
                char ch = split[1].ToCharArray()[0];

                int character_frequency = 0;

                foreach (var c in split[2].ToCharArray())
                {
                    if (c == ch)
                    {
                        character_frequency++;
                    }
                }

                if (character_frequency >= min && character_frequency <= max)
                {
                    correct_counter++;
                    //Console.WriteLine("correct: " + min + " bis " + max + " : " + ch + " " + split[2] + " " + character_frequency);
                }
                else
                {
                    //Console.WriteLine("wrong: " + min + " bis " + max + " : " + ch + " " + split[2] + " " + character_frequency );
                }

            }

            Console.WriteLine("Correct passwords: " + correct_counter); //546

        }
        
        public static void Part2()
        {
            List<string> listOfPasswords = File.ReadAllLines("../../input.txt").ToList();

            int correct_counter = 0; //correct when character on 1 position

            foreach (var line in listOfPasswords)
            {
                //1-3 m: kdjfskdjfnnm
                var split = line.Split(' '); //split 0: from-to 1: char 2: pw

                var from_to = split[0].Split('-');
                int pos1 = int.Parse(from_to[0]) - 1;
                int pos2 = int.Parse(from_to[1]) - 1;
                
                char ch = split[1].ToCharArray()[0];

                var pw = split[2].ToCharArray();

                if ((pw[pos1] == ch && pw[pos2] != ch) || (pw[pos1] != ch && pw[pos2] == ch))
                    correct_counter++;

            }

            Console.WriteLine("Correct passwords: " + correct_counter); //546

        }
        
        public static void Main(string[] args)
        {
            //Part1();
            Part2();
        }
    }
}