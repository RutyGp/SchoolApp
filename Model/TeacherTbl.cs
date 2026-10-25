using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class TeacherTbl : PersonTbl
    {
        private bool isEducator;
        private DateTime startWorkingDate;

        public bool IsEducator { get => isEducator; set => isEducator = value; }
        public DateTime StartWorkingDate { get => startWorkingDate; set => startWorkingDate = value; }

        public override string ToString()
        {
            return $"{base.ToString()}  IsEducator :{IsEducator} startWorking {StartWorkingDate}";
        }
    }
   

}
