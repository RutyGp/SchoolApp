using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    
    public class StudentTblList : List<StudentTbl>
    {
        public StudentTblList() { }
        public StudentTblList(IEnumerable<StudentTbl> list) : base(list) { }
        public StudentTblList(IEnumerable<BaseEntity> list) : base(list.Cast<StudentTbl>().ToList()) { }
    }
}
