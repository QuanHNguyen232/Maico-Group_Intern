using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class KhachHang
    {
        private string maKH, tenKH, diaChi, soDT = "+84";
        public string Get_maKH() { return maKH; }
        public string Get_tenKH() { return tenKH; }
        public string Get_diaChi() { return diaChi; }
        public string Get_soDT() { return soDT; }
        public void Nhap_Khach()
        {
            Console.Write("\tMa khach hang: ");
            maKH = Console.ReadLine();
            Console.Write("\tTen khach hang: ");
            tenKH = Console.ReadLine();
            Console.Write("\tDia chi: ");
            diaChi = Console.ReadLine();
            while (true)
            {
                try
                {
                    Console.Write("\tSo dien thoai: ");
                    int sdt = Int32.Parse(Console.ReadLine());
                    soDT += sdt.ToString();
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("\tSDT khong duoc nhap ki tu");
                }
            }
        }
    }
}
