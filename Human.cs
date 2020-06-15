using System;
using System.Collections.Generic;
using System.Text;

namespace KiemTra
{
    public class Human
    {
        protected string firstName;
        protected string lastName;
        protected string mssv;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Mssv { get => mssv; set => mssv = value; }

        public Human(string firstName, string lastName, string mssv)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.mssv = mssv;
        }

        public Human()
        {
        }
    }
}
