using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Thiet_Bi.Quat
{
    class Quat_Dung : Quat
    {
        private int giaQuat = 500;
        public override void Nhap_TB() { base.Nhap_TB(); }
        public override string Xuat_TB()
        {
            return ($"\tMay quat: Ma: {maTB}; quat dung loai: {tenTB}, san xuat o: {noiSX}; don gia: {giaQuat}; so luong: {soluongTB}; tong gia chi tiet: {giaQuat * soluongTB}");
        }
        public override double Gia_TB() { return giaQuat * soluongTB; }
    }
}
