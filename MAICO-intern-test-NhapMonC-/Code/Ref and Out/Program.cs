using System;

namespace Ref_and_Out
{
    class Program
    {
        static void Main(string[] args) 
        {
            // Truyen tham chieu (Ref)
            int bienRef = 0;
            changeRef(ref bienRef);
            Console.WriteLine("bienRef: " + bienRef);

            // Truyen tham chieu (Out)
            int bienOut;
            changeOut(out bienOut);
            Console.WriteLine("bienOut: " + bienOut);

            // Truyen tham tri
            int bien = 1;
            change(bien);
            Console.WriteLine("bien: " + bien);
        }

        public static void changeRef(ref int a)
        {
            a += 10;
        }
        public static void changeOut(out int a)
        {
            a = 5;
        }

        public static void change(int a)
        {
            a += 2;
        }
    }
}
