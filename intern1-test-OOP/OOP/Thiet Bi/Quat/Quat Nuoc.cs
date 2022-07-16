using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Thiet_Bi.Quat
{
    class Quat_Nuoc : Quat
    {
        private double nuoc = 0, giaQuatNuoc;
        public override void Nhap_TB()
        {
            base.Nhap_TB();
            do
            {
                try
                {
                    Console.Write("\t\t\tDung tich binh nuoc (lit): ");
                    nuoc = double.Parse(Console.ReadLine());
                    if (nuoc <= 0) Console.WriteLine("\t\t\tNhap lai (Dung tich binh nuoc > 0)");
                }
                catch (Exception error)
                {
                    Console.WriteLine("\t\t\t" + error.Message + " Nhap lai");
                }
            }
            while (nuoc <= 0);
            giaQuatNuoc = nuoc * 400;
        }
        public override string Xuat_TB()
        {
            return ($"\tMay quat: Ma: {maTB}; quat hoi nuoc loai: {tenTB}, san xuat o: {noiSX}; dung tich nuoc: {nuoc}(lit); don gia: {giaQuatNuoc}; so luong: {soluongTB}; tong gia chi tiet: {giaQuatNuoc * soluongTB}");
        }
        public override double Gia_TB() { return giaQuatNuoc * soluongTB; }
    }
}
