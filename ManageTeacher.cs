using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace KiemTra
{   
    public class ManageTeacher : IODatabase, IBaoMat
    {
        private Teacher[] _teachers;
        private int _count;
        private int _max = 100;

        public ManageTeacher(int count)
        {
            _count = count;
            _teachers = new Teacher[_count];
        }

        public ManageTeacher()
        {
            _count = 0;
            _teachers = new Teacher[_max];
        }

        public void NhapDSGV()
        {
           while(true)
            {
                Console.Write("Nhap vao tong so giao vien: ");
                if (int.TryParse(Console.ReadLine(), out _count)) break;
            }

            for (int i = 0; i < _count; i++)
            {
                Console.WriteLine("Nhap vao thong tin giao vien {0} ", i);
                Console.Write("Ten: "); var firstName = Console.ReadLine();
                Console.Write("Ho: "); var lastName = Console.ReadLine();
                Console.Write("Bo Mon: "); var subject = Console.ReadLine();
                Console.Write("Ma So: "); var ms = Console.ReadLine();

                _teachers[i] = new Teacher(ms, firstName, lastName, subject);
            }
        }

        public void Output(Teacher t)
        {
            Console.WriteLine("{0,2} | {1,10} | {2,10} | {3,10} | {4,10}", t.Id, t.Mssv, t.FirstName, t.LastName, t.Subject);
        }

        public void Output()
        {
            Console.WriteLine("Danh sach giao vien: ");
            for (int i = 0; i < _count; i++)
            {
                Output(_teachers[i]);
            }
        }

        public Teacher Find(string firstName, string lastName)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_teachers[i].LastName == lastName && _teachers[i].FirstName == firstName)
                    return _teachers[i];
            }
            return null;
        }
        public Teacher Find(string ms)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_teachers[i].Mssv == ms)
                    return _teachers[i];
            }
            return null;
        }
        public void FindAll(string name)
        {
            var found = false;
            for (int i = 0; i < _count; i++)
            {
                if(_teachers[i].FirstName == name)
                {
                    found = true;
                    Output(_teachers[i]);
                }
            }
            if (!found) {
                Console.WriteLine("Khong tim thay!");
            }
        }

        public void Read(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open);
            StreamReader rd = new StreamReader(fs);

            _count = int.Parse(GiaiMa(rd.ReadLine()));

            for (int i = 0; i < _count; i++)
            {
                var s = rd.ReadLine().Split("\t");
                _teachers[i] = new Teacher(GiaiMa(s[1]), GiaiMa(s[2]), GiaiMa(s[3]), GiaiMa(s[4]));
            }

            rd.Close();
            fs.Close();
        }

        public void Write(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate);
            StreamWriter wr = new StreamWriter(fs);

            wr.WriteLine(MaHoa(_count.ToString()));

            for (int i = 0; i < _count; i++)
            {
                var t = _teachers[i];
                wr.Write(MaHoa(t.Id) + "\t");
                wr.Write(MaHoa(t.Mssv) + "\t");
                wr.Write(MaHoa(t.FirstName) + "\t");
                wr.Write(MaHoa(t.LastName) + "\t");
                wr.WriteLine(MaHoa(t.Subject));
            }

            wr.Close();
            fs.Close();
        }

        public string MaHoa(string data)
        {
            var rs = "";
            for (int i = 0; i < data.Length; i++)
            {
                var ascii = (int)data[i];
                rs += (char)(ascii+5);
            }
            return rs;
        }

        public string GiaiMa(string data)
        {
            var rs = "";
            for (int i = 0; i < data.Length; i++)
            {
                var ascii = (int)data[i];
                rs += (char)(ascii - 5);
            }
            return rs;
        }
    }
}
