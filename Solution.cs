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
            //var median = 0d;
            //var sortedX = new List<int>(X);
            //sortedX.Sort();
            //median = sortedX[N / 2];//: ((decimal)(sortedX[N/2]+sortedX[(N/2)+1]))/2;
            //Console.WriteLine(median);
        }

        public static decimal Mean(int[] values)
        {
            var mean = 0m;
            foreach (var element in values) mean += element;
            return mean / values.Length;
        }
    }
}