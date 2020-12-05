using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode_Day4
{
    internal class Program
    {
        public static void Part1()
        {
            List<string> listOfLines = File.ReadAllLines("../../input.txt").ToList();

            List<string> data = new List<string>();
            string pp_data = "";

            foreach (var line in listOfLines)
            {
                if (line == "")
                {
                    data.Add(pp_data);
                    pp_data = "";
                }
                else
                {
                    pp_data = pp_data + " " + line;
                }
            }
            
            data.Add(pp_data);

            foreach (var d in data)
            {
                Console.WriteLine(d);
            }

            int valid_data = 0;
            foreach (var entry in data)
            {
                var kvp = entry.Split(' ')
                    .Select(s => s.Split(':'))
                    .ToDictionary(s => s.First(), s => s.Last());

                if (kvp.ContainsKey("byr") && kvp.ContainsKey("iyr") && kvp.ContainsKey("eyr") && kvp.ContainsKey("hgt")
                    && kvp.ContainsKey("hcl") && kvp.ContainsKey("ecl") && kvp.ContainsKey("pid"))
                {
                    valid_data++;
                }

            }

            Console.WriteLine(valid_data);
        }

        public static bool is_valid(Dictionary<string, string> kvp) //> 166 < 242
        {
            //Restrictions
            /*
             * byr - 4 digits, 1920 - 2002
             * iyr - 4 digits, 2010 - 2020
             * eyr - 4 digits, 2020 - 2030
             * hgt - number + cm/in, cm: 150 - 193, in: 59 - 76 59in|6[0-9]in|7[0-6]in
             * hcl - # followode by 6 character 0-9 || a-f
             * ecl - amd || blu || brn || gry || grn || hzl || oth
             * pid - 9 digit number, leading 0 ok?
             */
            
            Regex regex_byr = new Regex("^(19[2-9][0-9]|200[0-2])");
            Regex regex_iyr = new Regex("^(201[0-9]|2020)");
            Regex regex_eyr = new Regex("^(202[0-9]|2030)");
            Regex regex_hgt = new Regex("^(1[5-9][0-9]cm|19[0-3]cm|59in|6[0-9]in|7[0-6]in)");
            Regex regex_hcl = new Regex("^#([a-fA-F0-9]{6})");
            Regex regex_ecl = new Regex("amb|blu|brn|gry|grn|hzl|oth");
            Regex regex_pid = new Regex("^[0-9]{9}$");
            
            if (kvp.ContainsKey("byr") && kvp.ContainsKey("iyr") && kvp.ContainsKey("eyr") && kvp.ContainsKey("hgt")
                && kvp.ContainsKey("hcl") && kvp.ContainsKey("ecl") && kvp.ContainsKey("pid"))
            {
                if (regex_byr.IsMatch(kvp["byr"]) &&
                    regex_iyr.IsMatch(kvp["iyr"]) &&
                    regex_eyr.IsMatch(kvp["eyr"]) &&
                    regex_hgt.IsMatch(kvp["hgt"]) &&
                    regex_hcl.IsMatch(kvp["hcl"]) &&
                    regex_ecl.IsMatch(kvp["ecl"]) &&
                    regex_pid.IsMatch(kvp["pid"]))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            
        }

        public static void Part2()
        {
            //Restrictions
            /*
             * byr - 4 digits, 1920 - 2002
             * iyr - 4 digits, 2010 - 2020
             * eyr - 4 digits, 2020 - 2030
             * hgt - number + cm/in, cm: 150 - 193, in: 59 - 76 59in|6[0-9]in|7[0-6]in
             * hcl - # followode by 6 character 0-9 || a-f
             * ecl - amd || blu || brn || gry || grn || hzl || oth
             * pid - 9 digit number, leading 0 ok?
             */
            
            List<string> listOfLines = File.ReadAllLines("../../input.txt").ToList();

            List<string> data = new List<string>();
            string pp_data = "";

            foreach (var line in listOfLines)
            {
                if (line == "")
                {
                    data.Add(pp_data);
                    pp_data = "";
                }
                else
                {
                    pp_data = pp_data + " " + line;
                }
            }
            
            data.Add(pp_data);

            foreach (var d in data)
            {
                Console.WriteLine(d);
            }

            int valid_data = 0;
            foreach (var entry in data)
            {
                var kvp = entry.Split(' ')
                    .Select(s => s.Split(':'))
                    .ToDictionary(s => s.First(), s => s.Last());
  
                if(is_valid(kvp))
                    valid_data++;
                
            }

            Console.WriteLine(valid_data);
        }


            public static void Main(string[] args)
        {
            /*string input = "Id=1000;Name=xyzabc;DB=1.2.3.4;DBUserName=admin;DBPassword";

            
            var kvp = input.Split(';')
                .Select(s => s.Split('='))
                .ToDictionary(s => s.First(), s => s.Last());

            foreach (var key in kvp.Keys)
            {
                Console.WriteLine(key);
            }*/
            Part2();
        }
    }
}