using System;
using System.Collections.Generic;

namespace NumberList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            int num = 1;

            while (num != 0)
            {
                Console.WriteLine("Enter a number (0 to stop):");
                num = Convert.ToInt32(Console.ReadLine());
                if (num != 0)
                {
                    numbers.Add(num);
                }
            }

            int sum = 0;
            int max = int.MinValue;
            double avg = 0;
            foreach (int number in numbers)
            {
                sum += number;
                if (number > max)
                {
                    max = number;
                }
            }

            if (numbers.Count > 0)
            {
                avg = (double)sum / numbers.Count;
            }

            Console.WriteLine("The sum is: " + sum);
            Console.WriteLine("The average is: " + avg);

            if (max != int.MinValue)
            {
                Console.WriteLine("The largest number is: " + max);
            }

            // Stretch Challenge
            List<int> positiveNumbers = new List<int>();
            foreach (int number in numbers)
            {
                if (number > 0)
                {
                    positiveNumbers.Add(number);
                }
            }

            int minPositive = int.MaxValue;
            foreach (int number in positiveNumbers)
            {
                if (number < minPositive)
                {
                    minPositive = number;
                }
            }

            if (minPositive != int.MaxValue)
            {
                Console.WriteLine("The smallest positive number is: " + minPositive);
            }

            numbers.Sort();
            Console.WriteLine("The sorted list is:");
            foreach (int number in numbers)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }
    }
}
