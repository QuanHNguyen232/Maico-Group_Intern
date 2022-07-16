using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap so thu nhat (tu so trong phep chia): ");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Nhap so thu hai (tu so trong phep chia): ");
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine("Nhap so phep tinh (1, 2, 3, 4, 5 tuong ung cong, tru, nhan, chia, chia lay du): ");
            int c = int.Parse(Console.ReadLine());
            
            switch (c) 
            {
                case 1:
                    Console.WriteLine("{0} + {1} = {2:0.00}", a, b, (a + b));
                    break;
                case 2:
                    Console.WriteLine("{0} - {1} = {2:0.00}", a, b, (a - b));
                    break;
                case 3:
                    Console.WriteLine("{0} x {1} = {2:0.00}", a, b, (a * b));
                    break;
                case 4:
                    if (b == 0)
                    {
                        Console.WriteLine("Loi");
                    }
                    else
                    {
                        Console.WriteLine("{0} / {1} = {2:0.00}", a, b, (a / b));
                    }
                    break;
                case 5:
                    if (b == 0)
                    {
                        Console.WriteLine("Loi");
                    }
                    else
                    {
                        Console.WriteLine("{0} / {1} = {2} du {3}", a, b, ((int) a / (int) b), (a % b));
                    }
                    break;
            }
        }
    }
}
