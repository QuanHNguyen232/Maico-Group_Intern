using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Thiet_Bi.May_Lanh
{
    abstract class May_Lanh : ThietBi
    {
        protected bool isInverter;
        public override void Nhap_TB()
        {
            base.Nhap_TB();
            int ans = 0;
            do
            {
                try
                {
                    Console.Write("\t\t\tChon may lanh co inverter? (0 - khong, 1 - co): ");
                    ans = int.Parse(Console.ReadLine());
                    if (ans == 0 || ans == 1) break;
                    else Console.WriteLine("\t\t\tNhap lai (chi duoc chon 0 hoac 1)");
                }
                catch (Exception error)
                {
                    Console.WriteLine("\t\t\t" + error.Message + " Nhap lai (chi duoc chon 0 hoac 1)");
                }
            }
            while (true);
            isInverter = ans == 1 ? true : false;
        }
    }
}
