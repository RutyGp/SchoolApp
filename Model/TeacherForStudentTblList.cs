using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class TeacherForStudentTblList : List<TeacherForStudentTbl>
    {
        public TeacherForStudentTblList() { }
        public TeacherForStudentTblList(IEnumerable<TeacherForStudentTbl> list) : base(list) { }
        public TeacherForStudentTblList(IEnumerable<BaseEntity> list) : base(list.Cast<TeacherForStudentTbl>().ToList()) { }
    }
}
