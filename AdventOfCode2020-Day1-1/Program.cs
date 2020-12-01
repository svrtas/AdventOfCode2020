using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    internal class Program
    {
        public static void Part1()
        {
            List<int> listOfnumbers = File.ReadAllLines("../../input.txt").Select(int.Parse).ToList();

            /*foreach (var number in listOfnumbers)
            {
                if ((number + listOfnumbers.Min()) > 2020 || (number + listOfnumbers.Max()) < 2020)
                {
                    listOfnumbers.Remove(number);
                }
            }*/

            foreach (var number in listOfnumbers)
            {
                foreach (var n in listOfnumbers)
                {
                    if((number + n) == 2020) //252 * 1768 : 445536
                        Console.WriteLine(number + " * " + n + " : " + (number * n));
                }
            }
        }
        
        public static void Part2()
        {
            List<int> listOfnumbers = File.ReadAllLines("../../input.txt").Select(int.Parse).ToList();

            foreach (var n1 in listOfnumbers)
            {
                foreach (var n2 in listOfnumbers)
                {
                    foreach (var n3 in listOfnumbers)
                    {
                        if((n1+n2+n3) == 2020)
                            Console.WriteLine(n1 + " * " + n2 + " * " + n3 + " = " + (n1*n2*n3));
                    }
                }
            }
        }
        
        public static void Main(string[] args)
        {
            //Part1();
            Part2();
        }
    }
}