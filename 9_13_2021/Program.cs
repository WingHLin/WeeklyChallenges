/*
Problem specification:
Create a function that takes a positive integer and returns a string expressing how the number can be made by multiplying powers of its prime factors.

Examples
ExpressFactors(2) --> "2"
ExpressFactors(4) --> "2^2"
ExpressFactors(10) --> "2 x 5"
ExpressFactors(60) --> "2^2 x 3 x 5"
*/

using System;
using System.Collections.Generic;

namespace _9_13_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("ExpressFactors(2) -> ");
            ExpressFactors(2);
            Console.Write("ExpressFactors(4) -> ");
            ExpressFactors(4);
            Console.Write("ExpressFactors(10) -> ");
            ExpressFactors(10);
            Console.Write("ExpressFactors(60) -> ");
            ExpressFactors(60);
            
            int x;
            Console.Write("\nEnter a positive integer: ");
            x = int.Parse(Console.ReadLine());
            ExpressFactors(x);
        }

        static void ExpressFactors(int x) 
        {
            int remainder = x;
            int divisor;
            int loopCount = 0;
            int keyCount = 0;
            Dictionary<int, int> count = new Dictionary<int, int>();

            for (divisor = 2; remainder > 1; divisor++) {
                if (remainder % divisor == 0)
                {
                    int exponent = 0;
                    while (remainder % divisor == 0)
                    {
                        remainder /= divisor;
                        exponent++;
                    }
                    count.Add(divisor,exponent);
                }
            }

            keyCount = count.Keys.Count;
            foreach (int key in count.Keys) {
                if (count[key] > 1) {
                    Console.Write("{0}^{1}",key,count[key]);
                    if (loopCount + 1 < keyCount) {
                        Console.Write(" x ");
                    }
                } else {
                    Console.Write("{0}",key);
                    if (loopCount + 1 < keyCount) {
                        Console.Write(" x ");
                    }
                }
                loopCount++;
            }

            Console.WriteLine("");
        }
    }
}
