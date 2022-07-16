using System;
using System.Threading;
using System.IO;
using OOP.Thiet_Bi;
using OOP.Thiet_Bi.Quat;
using OOP.Thiet_Bi.May_Lanh;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            int ansSoHD = 0;
            do
            {
                try
                {
                    Console.Write("So luong hoa don muon nhap: ");
                    ansSoHD = int.Parse(Console.ReadLine());
                    if (ansSoHD <= 0) Console.WriteLine("Nhap lai (so luong > 0)");
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message + " Nhap lai");
                }
            }
            while (ansSoHD <= 0);
            Hoa_Don[] hdList = new Hoa_Don[ansSoHD];
            for (int i=0; i < ansSoHD; i++)
            {
                Console.WriteLine("Luu y: Hoa don se xuat ra o Desktop");
                Console.WriteLine($"Nhap thong tin hoa don {i + 1}:");
                hdList[i] = new Hoa_Don();
                hdList[i].Nhap_HD();
                hdList[i].Xuat_txt_file(i);

                Console.Clear();
            }
        }
    }
}
