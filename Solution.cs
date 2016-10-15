using System;
using System.Collections.Generic;
using System.IO;

namespace Day0MeanMedianAndMode
{
    public class Solution
    {
        public static void Main(String[] args)
        {
            /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
            var N = int.Parse(Console.ReadLine());
            var X = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));

            Console.WriteLine(Mean(X));

            Console.WriteLine(Median(X));

            Console.WriteLine(Mode(X));
        }

        public static decimal Mean(int[] values)
        {
            var mean = 0m;
            foreach (var element in values) mean += element;
            return mean / values.Length;
        }

        public static decimal Median(Int32[] values)
        {
            var median = 0m;
            var sortedX = new List<int>(values);
            sortedX.Sort();
            var count = sortedX.Count;
            median = count % 2 == 1 ? sortedX[count / 2] : ((decimal)(sortedX[(count / 2) - 1] + sortedX[count / 2])) / 2;
            return median;
        }

        public static int Mode(int[] values)
        {
            var sortedX = new List<int>(values);
            sortedX.Sort();

            var dictionary = new Dictionary<int, int>();
            foreach(var value in sortedX)
            {
                if (dictionary.ContainsKey(value)) dictionary[value] += 1;
                else dictionary.Add(value, 1);
            }
            var result = 0;
            var max = 0;
            foreach(var value in dictionary)
            {
                if (value.Value > max)
                {
                    result = value.Key;
                    max = value.Value;
                }
            }
            return result;            
        }
    }
}