using System;

namespace KiemTra
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Final exam!");

            var ctk39 = new ManageTeacher();
            // Nhap danh sach giao vien
           ctk39.NhapDSGV();
           ctk39.Write(@"C:\Users\pxtha\source\repos\Lab9\KiemTra\data.txt");

            ctk39.Read(@"C:\Users\pxtha\source\repos\Lab9\KiemTra\data.txt");
            ctk39.Output();

            Console.Write("Nhap vao ten can tim: ");
            ctk39.FindAll(Console.ReadLine());

            Console.Write("Nhap ten can tim: ");
            var firstName = Console.ReadLine();
            Console.Write("Nhap ho can tim: ");
            var lastName = Console.ReadLine();
           

            var teacher = ctk39.Find(firstName,lastName);
            if (teacher != null)
            {
                ctk39.Output(teacher);
            } else
            {
                Console.WriteLine("Not found");
            }

            Console.Write("Nhap vao ms can tim: ");
            teacher = ctk39.Find(Console.ReadLine());
            if (teacher != null)
            {
                ctk39.Output(teacher);
            }
            else
            {
                Console.WriteLine("Not found");
            }

            Console.ReadKey();
        }
    }
}
