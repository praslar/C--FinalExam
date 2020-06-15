using System;
using System.Collections.Generic;
using System.Text;

namespace KiemTra
{
    public class Teacher : Human
    {
        private string _id;
        private string _subject;

        public string Subject { get => _subject; set => _subject = value; }
        public string Id { get => _id; }

        public Teacher()
        {
            _id = "Gv";
        }

        public Teacher(string ms, string firstName, string lastName,  string subject) : base(firstName,lastName,ms)
        {
            _id = "GV";
            _subject = subject;
        }
    }
}
