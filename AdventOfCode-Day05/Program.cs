using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode_Day05
{
    internal class Program
    {
        public static void Part1()
        {
            List<string> listOfBoardPasses = File.ReadAllLines("../../input.txt").ToList();

            int seat_id_max = 0;

            foreach (var pass in listOfBoardPasses)
            {
                
                var id = pass.ToCharArray();

                int[] row = new int[2];
                row[0] = 0;
                row[1] = 127;
                
                int[] col = new int[2];
                col[0] = 0;
                col[1] = 7;

                int seat_id = 0;
                
                foreach (var c in id)
                {
                    if (c == 'F')
                    {
                        row[1] = row[0] + ( (row[1] - row[0]) / 2 );
                    }

                    if (c == 'B')
                    {
                        row[0] = row[1] - ( (row[1] - row[0]) / 2 );
                    }
                    
                    if (c == 'L')
                    {
                        col[1] = col[0] + ( (col[1] - col[0]) / 2 );
                    }

                    if (c == 'R')
                    {
                        col[0] = col[1] - ( (col[1] - col[0]) / 2 );
                    }

                }

                seat_id = row[0] * 8 + col[0];

                if (seat_id > seat_id_max)
                    seat_id_max = seat_id;

                Console.WriteLine("row: " + row[0] + " col: " + col[0] + " seat_id: " + seat_id);
                
            }

            Console.WriteLine(seat_id_max);

        }

        public static void Part2()
        {
            List<string> listOfBoardPasses = File.ReadAllLines("../../input.txt").ToList();

            List<int> seat_ids = new List<int>();

            foreach (var pass in listOfBoardPasses)
            {
                
                var id = pass.ToCharArray();

                int[] row = new int[2];
                row[0] = 0;
                row[1] = 127;
                
                int[] col = new int[2];
                col[0] = 0;
                col[1] = 7;

                int seat_id = 0;
                
                foreach (var c in id)
                {
                    if (c == 'F')
                    {
                        row[1] = row[0] + ( (row[1] - row[0]) / 2 );
                    }

                    if (c == 'B')
                    {
                        row[0] = row[1] - ( (row[1] - row[0]) / 2 );
                    }
                    
                    if (c == 'L')
                    {
                        col[1] = col[0] + ( (col[1] - col[0]) / 2 );
                    }

                    if (c == 'R')
                    {
                        col[0] = col[1] - ( (col[1] - col[0]) / 2 );
                    }

                }

                seat_id = row[0] * 8 + col[0];

                seat_ids.Add(seat_id);

                Console.WriteLine("row: " + row[0] + " col: " + col[0] + " seat_id: " + seat_id);
                
            }

            seat_ids.Sort();
            var result = Enumerable.Range(0, 880).Except(seat_ids);
            foreach (var entry in result)
            {
                Console.WriteLine(entry);
            }
        }
        public static void Main(string[] args)
        {
            //Part1();
            Part2();
        }
    }
}