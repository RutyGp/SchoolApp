using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class TeacherForStudentTbl : BaseEntity
    {
        private StudentTbl stud;
        private TeacherTbl teach;

        public TeacherTbl Teach { get => teach; set => teach = value; }
        public StudentTbl Stud { get => stud; set => stud = value; }

        public override string ToString()
        {
            return $"{base.ToString()} {Teach}  {Stud}";
        }
    }
}
