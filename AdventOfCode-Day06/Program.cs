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

            int count_of_people = 0;
            
            foreach (var line in listOfAnswers)
            {
                if (line == "")
                {
                    answers_per_row.Add(row_data);
                    row_data = "";
                    count_of_people = 0;
                }
                else
                {
                    row_data = row_data + " " + line;
                    count_of_people++;
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
        
        public static void Part2()
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
                    if (row_data == "")
                        row_data = line;
                    else
                        row_data = row_data + "-" + line;
                }
            }

            answers_per_row.Add(row_data);
            int answer_count = 0;

            foreach (var group in answers_per_row)
            {
                String[] group_answers = group.Split('-');

                for (int i = 0; i < group_answers.Length; i++)
                {
                    Console.WriteLine(group_answers[i]);
                }

                if (group_answers.Length > 1)
                {
                    List<string> answers = new List<string>();
                    List<string> yes_answers = new List<string>();

                    answers.AddRange(group_answers[0].Select(c => c.ToString()));
                    yes_answers.AddRange(group_answers[0].Select(c => c.ToString()));
                
                    for (int i = 1; i < group_answers.Length; i++)
                    {
                        List<string> current_answer = new List<string>();
                        current_answer.AddRange(group_answers[i].Select(c => c.ToString()));  
                    
                        foreach (var a in answers)
                        {
                            bool found_match = false;
                            
                            foreach (var c in current_answer)
                            {
                                if (a == c)
                                {
                                    found_match = true;
                                }
                            }

                            if (!found_match)
                            {
                                yes_answers.Remove(a);
                            }
                        }
                    }
                    answer_count = answer_count + yes_answers.Count;
                }
                else
                {
                    answer_count = answer_count + group_answers[0].Length;
                }
            }

            Console.WriteLine(answer_count);
        }
        public static void Main(string[] args)
        {
            Part2();
        }
    }
}