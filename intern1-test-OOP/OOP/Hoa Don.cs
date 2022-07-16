using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OOP.Thiet_Bi;
using OOP.Thiet_Bi.May_Lanh;
using OOP.Thiet_Bi.Quat;

namespace OOP
{
    class Hoa_Don
    {
        private string maHD;
        private double tongTien = 0;
        private ThietBi[] thiet_bi;
        private DateTime date = DateTime.Now;
        private KhachHang kh = new KhachHang();
        public double Get_tongTien() { return tongTien; }
        public void Nhap_HD()
        {
            // Hoa don
            Console.Write("Ma hoa don: ");
            maHD = Console.ReadLine();
            Console.WriteLine($"Ngay lap hoa don: {date.Day}/{date.Month}/{date.Year}");
            // Khach hang
            Console.WriteLine("Thong tin khach hang:");
            kh.Nhap_Khach();
            // Thiet bi
            Console.WriteLine("Nhap danh sach cac chi tiet hoa don:");
            // So luong chi tiet
            int answer = 0;
            do
            {
                try
                {
                    Console.Write("\tSo luong chi tiet trong danh sach cac chi tiet hoa don: ");
                    answer = int.Parse(Console.ReadLine());
                    if (answer <= 0) Console.WriteLine("\tNhap lai (so luong > 0)");
                }
                catch (Exception error)
                {
                    Console.WriteLine("\t"+ error.Message + " Nhap lai");
                }
            }
            while (answer <= 0);
            thiet_bi = new ThietBi[answer];
            for (int i = 0; i < answer; i++)
            {
                Console.WriteLine($"\tNhap chi tiet hoa don thu {i+1}");
                int ansTB = 0;
                do // Bat loi nhap loai thiet bi
                {
                    try
                    {
                        Console.Write("\t\tChon loai thiet bi dien (1-may quat, 2- may lanh): ");
                        ansTB = int.Parse(Console.ReadLine());
                        if (ansTB == 1)
                        {
                            int ansQuat = 0;
                            do // Bat loi chon loai quat
                            {
                                try
                                {
                                    Console.Write("\t\t\tChon loai may quat (1-may quat dung,2- may quat hoi nuoc,3 – may quat sac dien): ");
                                    ansQuat = int.Parse(Console.ReadLine());
                                    if (ansQuat == 1)
                                        thiet_bi[i] = new Quat_Dung();
                                    else if (ansQuat == 2)
                                        thiet_bi[i] = new Quat_Nuoc();
                                    else if (ansQuat == 3)
                                        thiet_bi[i] = new Quat_Sac();
                                    else
                                    {
                                        Console.WriteLine("\t\t\tNhap lai");
                                    }
                                }
                                catch (Exception err)
                                {
                                    Console.WriteLine("\t\t\t" + err.Message);
                                }
                            }
                            while (ansQuat != 1 && ansQuat != 2 && ansQuat != 3);
                        }
                        else if (ansTB == 2)
                        {
                            int ansLanh = 0;
                            do // Bat loi chon loai may lanh
                            {
                                try
                                {
                                    Console.Write("\t\t\tChon loai may lanh (1-may lanh 1 chieu,2- may lanh 2 chieu): ");
                                    ansLanh = int.Parse(Console.ReadLine());
                                    if (ansLanh == 1)
                                        thiet_bi[i] = new MayLanh_1Chieu();
                                    else if (ansLanh == 2)
                                        thiet_bi[i] = new MayLanh_2Chieu();
                                    else
                                    {
                                        Console.WriteLine("\t\t\tNhap lai");
                                    }
                                }
                                catch (Exception err)
                                {
                                    Console.WriteLine("\t\t\t" + err.Message);
                                }
                            }
                            while (ansLanh != 1 && ansLanh != 2);
                        }
                        else
                        {
                            Console.WriteLine("\t\tNhap lai");
                        }
                    }
                    catch (Exception error)
                    {
                        Console.WriteLine("\t\t" + error.Message);
                    }
                }
                while (ansTB !=1 && ansTB != 2);
                thiet_bi[i].Nhap_TB();
                tongTien += thiet_bi[i].Gia_TB();
            }
        }
        public void Xuat_txt_file(int i)
        {
            //String filepath = $"D:/Desktop/danh_sach_hoa_don_{i+1}.txt";
            FileStream fs = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\danh_sach_hoa_don_"+ (i+1) +".txt", FileMode.Create);
            StreamWriter sWriter = new StreamWriter(fs);

            sWriter.WriteLine($"Hoa don:");
            sWriter.WriteLine($"\tMa hoa don: {maHD}");
            sWriter.WriteLine($"\tNgay lap: {date.Day}/{date.Month}/{date.Year}");
            sWriter.WriteLine($"\tTong gia: {tongTien}");
            sWriter.WriteLine();
            sWriter.WriteLine($"Thong tin khach hang:");
            sWriter.WriteLine($"\tMa khach hang: {kh.Get_maKH()}");
            sWriter.WriteLine($"\tTen khach hang: {kh.Get_tenKH()}");
            sWriter.WriteLine($"\tDia chi: {kh.Get_diaChi()}");
            sWriter.WriteLine($"\tSo dien thoai: {kh.Get_soDT()}");
            sWriter.WriteLine();
            sWriter.WriteLine("Danh sach cac chi tiet hoa don:");
            
            for (int soTB =0; soTB < thiet_bi.Length; soTB++)
            {
                sWriter.WriteLine(thiet_bi[soTB].Xuat_TB());
                sWriter.WriteLine();
            }
            sWriter.Flush();
            fs.Close();
        }
    }
}