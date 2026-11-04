using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class CityTblList : List<CityTbl>
    {
        public CityTblList() { }
        public CityTblList(IEnumerable<CityTbl> list) : base(list) { }
        public CityTblList(IEnumerable<BaseEntity> list) : base(list.Cast<CityTbl>().ToList()) { }
    }
}
