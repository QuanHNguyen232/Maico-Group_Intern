using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Thiet_Bi.Quat
{
    class Quat_Sac : Quat
    {
        private double pin, giaQuatSac;
        public override void Nhap_TB()
        {
            base.Nhap_TB();
            do
            {
                try
                {
                    Console.Write("\t\t\tDung luong pin: ");
                    pin = double.Parse(Console.ReadLine());
                    if (pin <= 0) Console.WriteLine("\t\t\tNhap lai (Dung luong pin > 0)");
                }
                catch (Exception error)
                {
                    Console.WriteLine("\t\t\t" + error.Message + " Nhap lai");
                }
            }
            while (pin <= 0);
            giaQuatSac = pin * 500;
        }
        public override string Xuat_TB()
        {
            return ($"\tMay quat: Ma: {maTB}; quat sac dien loai: {tenTB}, san xuat o: {noiSX}; dung luong pin: {pin}; don gia: {giaQuatSac}; so luong: {soluongTB}; tong gia chi tiet: {giaQuatSac * soluongTB}");
        }
        public override double Gia_TB() { return giaQuatSac * soluongTB; }
    }
}
