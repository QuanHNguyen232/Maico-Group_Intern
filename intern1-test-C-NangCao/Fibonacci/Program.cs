using System;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Vi tri cua so trong Fibonacci sequence (bat dau tu 0): ");
            int n = int.Parse(Console.ReadLine());

            // Cach 1
            int[] fib = new int[n + 2];
            fib[0] = 0;
            fib[1] = 1;

            if (n > 1)
            {
                for (int i = 2; i <= n; i++)
                {
                    fib[i] = fib[i - 1] + fib[i - 2];
                }
            }
            Console.WriteLine($"So thu {n} trong Fibonacci sequence:");
            Console.WriteLine("Ket qua (basic): " + fib[n]);

            // Cach 2
            Console.WriteLine("Ket qua (recursion): " + fib_Recur(n));

            // Cach 3
            initialValue(fibList);
            Console.WriteLine("Ket qua (dynamic programming): " + fib_Dynamic(n));
        }

        // Recursion
        public static int fib_Recur(int n)
        {
            if (n == 0) // base case 1
            {
                return 0;
            }
            if (n == 1) // base case 2
            {
                return 1;
            }
            else
            {
                return fib_Recur(n - 1) + fib_Recur(n - 2);
            }
        }

        // Dynamic
        public static int[] fibList = new int[100];
        public static void initialValue(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = -1;
            }
        }

        public static int fib_Dynamic(int n)
        {
            if (fibList[n] == -1)
            {
                if (n == 0)
                {
                    fibList[0] = 0;
                }
                else if (n == 1)
                {
                    fibList[1] = 1;
                }
                else
                {
                    fibList[n] = fib_Dynamic(n - 1) + fib_Dynamic(n - 2);
                }
            }
            return fibList[n];
        }
    }
}