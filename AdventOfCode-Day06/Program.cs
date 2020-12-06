using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode_Day06
{
    internal class Program
    {
        public static void Part1()
        {
            
            List<string> listOfAnswers = File.ReadAllLines("../../input.txt").ToList();

            List<string> answers_per_row = new List<string>();
            string row_data = "";

            foreach (var line in listOfAnswers)
            {
                if (line == "")
                {
                    answers_per_row.Add(row_data);
                    row_data = "";
                }
                else
                {
                    row_data = row_data + " " + line;
                }
            }

            answers_per_row.Add(row_data);

            int answer_count = 0;
            
            foreach (var group in answers_per_row)
            {
                var group_answers = group.ToCharArray();
                
                List<char> answers_per_group = new List<char>();
                
                foreach (var answer in group_answers)
                {
                    if (!answers_per_group.Contains(answer))
                    {
                        answers_per_group.Add(answer);
                    }
                }

                answer_count = answer_count + (answers_per_group.Count - 1); //-1 to remove empty character
            }

            Console.WriteLine(answer_count);
        }
        public static void Main(string[] args)
        {
            Part1();
        }
    }
}