using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Thiet_Bi.May_Lanh
{
    class MayLanh_1Chieu : May_Lanh
    {
        private int giaLanh_1;
        public override void Nhap_TB()
        {
            base.Nhap_TB();
            giaLanh_1 = isInverter ? 1500 : 1000;
        }
        public override string Xuat_TB()
        {
            string mayLanh_1 = $"\tMay lanh: Ma: {maTB}; may lanh 1 chieu loai: {tenTB}, san xuat o: {noiSX}";
            if (isInverter) mayLanh_1 += "; co cong nghe Inverter";
            mayLanh_1 += $"; don gia: {giaLanh_1}; so luong: {soluongTB}; tong gia chi tiet: {giaLanh_1 * soluongTB}";
            return mayLanh_1;
        }
        public override double Gia_TB() { return giaLanh_1 * soluongTB; }
    }
}
