using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class TeacherTblList : List<TeacherTbl>
    {
        public TeacherTblList() { }
        public TeacherTblList(IEnumerable<TeacherTbl> list) : base(list) { }
        public TeacherTblList(IEnumerable<BaseEntity> list) : base(list.Cast<TeacherTbl>().ToList()) { }
    }

}
