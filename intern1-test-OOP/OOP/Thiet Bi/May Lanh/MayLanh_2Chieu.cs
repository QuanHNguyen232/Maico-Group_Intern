using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Thiet_Bi.May_Lanh
{
    class MayLanh_2Chieu : May_Lanh
    {
        private bool khuMui, khuKhuan;
        private int giaLanh_2;
        public override void Nhap_TB()
        {
            base.Nhap_TB();
            // Bat loi Khu mui ?
            int ansMui = 0;
            do
            {
                try
                {
                    Console.Write("\t\t\tKhu mui? (0 - khong, 1 - co): ");
                    ansMui = int.Parse(Console.ReadLine());
                    if (ansMui == 0 || ansMui == 1) break;
                    else Console.WriteLine("\t\t\tNhap lai (chi duoc chon 0 hoac 1)");
                }
                catch (Exception error)
                {
                    Console.WriteLine("\t\t\t" + error.Message + " Nhap lai (chi duoc chon 0 hoac 1)");
                }
            }
            while (true);
            khuMui = ansMui == 1 ? true : false;
            // Bat loi Khu khuan ?
            int ansKhuan = 0;
            do
            {
                try
                {
                    Console.Write("\t\t\tKhu khuan? (0 - khong, 1 - co): ");
                    ansKhuan = int.Parse(Console.ReadLine());
                    if (ansKhuan == 0 || ansKhuan == 1) break;
                    else Console.WriteLine("\t\t\tNhap lai (chi duoc chon 0 hoac 1)");
                }
                catch (Exception error)
                {
                    Console.WriteLine("\t\t\t" + error.Message + " Nhap lai (chi duoc chon 0 hoac 1)");
                }
            }
            while (true);
            khuKhuan = ansKhuan == 1 ? true : false;
            giaLanh_2 = isInverter ? 2500 : 2000;
            giaLanh_2 = khuKhuan ? giaLanh_2 += 500 : giaLanh_2;
            giaLanh_2 = khuMui ? giaLanh_2 += 500 : giaLanh_2;
        }
        public override string Xuat_TB()
        {
            string mayLanh_2 = $"\tMay lanh: Ma: {maTB}; may lanh 2 chieu loai: {tenTB}, san xuat o: {noiSX}";
            if (isInverter) mayLanh_2 += "; co cong nghe Inverter";
            if (khuKhuan) mayLanh_2 += "; co cong nghe khu khuan";
            if (khuMui) mayLanh_2 += "; co cong nghe khu mui";
            mayLanh_2 += $"; don gia: {giaLanh_2}; so luong: {soluongTB}; tong gia chi tiet: {giaLanh_2 * soluongTB}";
            return mayLanh_2;
        }
        public override double Gia_TB() { return giaLanh_2 * soluongTB; }
    }
}
