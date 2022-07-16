using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    abstract class ThietBi
    {
        protected string maTB, tenTB, noiSX;
        protected int soluongTB = 0;
        public virtual void Nhap_TB()
        {
            Console.Write("\t\t\tMa thiet bi: ");
            maTB = Console.ReadLine();
            Console.Write("\t\t\tTen thiet bi: ");
            tenTB = Console.ReadLine();
            Console.Write("\t\t\tNoi san xuat: ");
            noiSX = Console.ReadLine();
            do
            {
                try
                {
                    Console.Write("\t\t\tSo luong thiet bi: ");
                    soluongTB = int.Parse(Console.ReadLine());
                    if (soluongTB <= 0) Console.WriteLine("\t\t\tSo luong phai > 0");
                }
                catch (Exception err)
                {
                    Console.WriteLine("\t\t\t" + err.Message + "Nhap lai");
                }
            }
            while (soluongTB <= 0);
        }
        public abstract string Xuat_TB();
        public abstract double Gia_TB();
    }
}
