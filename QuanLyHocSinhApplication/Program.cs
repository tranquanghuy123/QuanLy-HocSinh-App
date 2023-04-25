using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocSinhApplication
{
    public class HocSinh
    {
        public string Hoten;
        public double DiemToan;
        public double DiemVan;
        public double DiemAnhVan;
        public double DiemTB;
    }
    internal class Program
    {
        public HocSinh NhapThongTinHocSinh()
        {
            HocSinh hs = new HocSinh();
            Console.Write("Nhap ho ten hoc sinh: ");
            hs.Hoten = Console.ReadLine();
            Console.Write("Nhap diem Toan: ");
            hs.DiemToan = double.Parse(Console.ReadLine());
            Console.Write("Nhap diem Van: ");
            hs.DiemVan = double.Parse(Console.ReadLine());
            Console.Write("Nhap diem Anh Van: ");
            hs.DiemAnhVan = double.Parse(Console.ReadLine());
            hs.DiemTB = (hs.DiemToan + hs.DiemVan + hs.DiemAnhVan) / 3;
            Console.WriteLine("Diem trung binh cua hoc sinh la: " + hs.DiemTB);
            Console.WriteLine("======================");
            return hs;
        }
        public void XuatThongTinHocSinh(List<HocSinh> hs)
        {
            for (int i = 0; i < hs.Count; i++)
            {
                Console.WriteLine("Thong tin hoc sinh thu " + (i + 1));
                Console.WriteLine("Ho ten: " + hs[i].Hoten);
                Console.WriteLine("Diem Toan: " + hs[i].DiemToan);
                Console.WriteLine("Diem Van: " + hs[i].DiemVan);
                Console.WriteLine("Diem Anh Van: " + hs[i].DiemAnhVan);
                Console.WriteLine("Diem Trung Binh: " + hs[i].DiemTB);
            }
        }


        static void Main(string[] args)
        {

            //Khởi tạo danh sách học sinh
            List<HocSinh> mylist = new List<HocSinh>();
            Console.Write("Nhap so luong hoc sinh: ");
            string nReadline = Console.ReadLine();

            // Kiểm tra chữ số nhập vào có phải số nguyên hay k
            int nNumber = int.Parse(nReadline);

            HocSinh hs = new HocSinh();
            Program program = new Program();

            //Thực hiện vòng lặp để nhập thông tin học sinh
            for (int i = 0; i < nNumber; i++)
            {
                Console.WriteLine("Thong tin hoc sinh thu " + (i + 1));
                
                hs = program.NhapThongTinHocSinh();
                mylist.Add(hs);
            }

            //Xuất thông tin học sinh
            program.XuatThongTinHocSinh(mylist);

            //Sắp xếp diểm trung bình từ thấp đến cao
            mylist.Sort(
                    (p1, p2) =>
                    {
                        if (p1.DiemTB == p2.DiemTB) return 0;
                        if (p1.DiemTB < p2.DiemTB) return -1;
                        return 1;
                    }
                    );
            //In ra màn hình điểm trung bình từ thấp đến cao
            Console.WriteLine("====================");
            Console.WriteLine("Diem TB tu thap den cao:");

            //Thực hiện vòng lặp để xuất thông tin học sinh
            foreach (var hocsinh in mylist)
            {
                Console.WriteLine($"{hocsinh.Hoten} - {hocsinh.DiemTB}");
            }

            //Xuất ra hs có DTB lớn nhất
            double max = mylist[0].DiemTB;
            string hsmax = mylist[0].Hoten;
            //Thực hiện vòng lặp để xuất ra hs có điểm tb cao nhất
            for (int i = 1; i < mylist.Count; i++)
            {
                if (mylist[i].DiemTB > max)
                {
                    max = mylist[i].DiemTB;
                    hsmax = mylist[i].Hoten;
                }
            }
            Console.Write("Hoc sinh co diem trung binh cao nhat la:");
            Console.WriteLine($" {hsmax} - {max}");


            //Xuất ra học sinh có điểm môn toán lớn hơn 8
            List<HocSinh> hsToan8 = new List<HocSinh>();
            for (int i = 0; i < mylist.Count; i++)
            {
                if (mylist[i].DiemToan >= 8)
                {
                    hsToan8.Add(mylist[i]);
                }
            }
            if (hsToan8.Count > 0)
            {
                Console.Write("Hoc sinh co diem toan >=8: ");
                for (int i = 0; i < hsToan8.Count; i++)
                {
                    Console.WriteLine($"{hsToan8[i].Hoten} - {hsToan8[i].DiemToan}");
                }
            }
            else
            {
                Console.WriteLine("Khong co hoc sinh co diem toan >=8");
            }
        }


    }
}