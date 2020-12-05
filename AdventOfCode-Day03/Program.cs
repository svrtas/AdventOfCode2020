using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode_Day3
{
    internal class Program
    {
        public static void Print2DArray<T>(T[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }
        public static void Part1()
        {
            List<string> listOfMaps = File.ReadAllLines("../../input.txt").ToList();


            int rows = listOfMaps.Count;
            int columns = listOfMaps[0].Length;
            
            char[,] map = new char[rows , columns];

            int row_num = 0;
            int col_num = 0;
            
            foreach (var row in listOfMaps)
            {
                foreach (var ch in row.ToCharArray())
                {
                    map[row_num, col_num] = ch;
                    col_num++;
                }

                row_num++;
                col_num = 0;
            }

            

            int mv_col = 3;
            int mb_row = 1;

            int column_pos = 0;
            int tree_count = 0;

            for (int i = 1; i < rows; i++)
            {
                //travel 3 columns --> column_pos + mv_col
                //check # or .
                //print
                //ig column_pos >= columns column_pos = columns - column_pos

                column_pos = column_pos + mv_col;

                if (column_pos >= columns)
                    column_pos = column_pos - columns;

                if (map[i, column_pos] == '#')
                    tree_count++;

            }
            //Print2DArray(map);
            Console.WriteLine(tree_count);
            Console.WriteLine(map.GetLength(0) + " - " + map.GetLength(1));

        }

        public static int count_trees_in_slope(char[,] map, int mv_col, int mv_row)
        {
            int column_pos = 0;
            int tree_count = 0;

            int rows = map.GetLength(0);
            int columns = map.GetLength(1);
            
            for (int i = mv_row; i < rows; i = i + mv_row)
            {
                //travel 3 columns --> column_pos + mv_col
                //check # or .
                //print
                //ig column_pos >= columns column_pos = columns - column_pos

                column_pos = column_pos + mv_col;

                if (column_pos >= columns)
                    column_pos = column_pos - columns;

                if (map[i, column_pos] == '#')
                    tree_count++;

            }

            return tree_count;
        }
        

        public static void Part2()
        {
            /*
             *  Right 1, down 1.
                Right 3, down 1. (This is the slope you already checked.)
                Right 5, down 1.
                Right 7, down 1.
                Right 1, down 2.
             */
            
            List<string> listOfMaps = File.ReadAllLines("../../input.txt").ToList();


            int rows = listOfMaps.Count;
            int columns = listOfMaps[0].Length;
            
            char[,] map = new char[rows , columns];

            int row_num = 0;
            int col_num = 0;
            
            foreach (var row in listOfMaps)
            {
                foreach (var ch in row.ToCharArray())
                {
                    map[row_num, col_num] = ch;
                    col_num++;
                }

                row_num++;
                col_num = 0;
            }

            int trees_multiplied = count_trees_in_slope(map, 1, 1);
            trees_multiplied = trees_multiplied * count_trees_in_slope(map, 3, 1);
            trees_multiplied = trees_multiplied * count_trees_in_slope(map, 5, 1);
            trees_multiplied = trees_multiplied * count_trees_in_slope(map, 7, 1);
            trees_multiplied = trees_multiplied * count_trees_in_slope(map, 1, 2);

            Console.WriteLine(trees_multiplied);

        }
        public static void Main(string[] args)
        {
            Part2();
        }
    }
}