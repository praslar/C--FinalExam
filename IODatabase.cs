using System;
using System.Collections.Generic;
using System.Text;

namespace KiemTra
{
    interface IODatabase
    {
        void Read(string filename);
        void Write(string filename);
    }
}
