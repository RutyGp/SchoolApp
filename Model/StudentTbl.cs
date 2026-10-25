using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public  class StudentTbl:PersonTbl
    {
        private string tel;

        public string Tel { get => tel; set => tel = value; }

        public override string ToString()
        {
            return $"{base.ToString()} Telnumber --> {Tel}" ;
        }
    }
}
