using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class PersonTblList : List<PersonTbl>
    {
        public PersonTblList() { }
        public PersonTblList(IEnumerable<PersonTbl> list) : base(list) { }
        public PersonTblList(IEnumerable<BaseEntity> list) : base(list.Cast<PersonTbl>().ToList()) { }
    }
}
