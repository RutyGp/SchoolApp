using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class CityList : List<CityTbl>
    {
        public CityList() { }
        public CityList(IEnumerable<CityTbl> list) : base(list) { }
        public CityList(IEnumerable<BaseEntity> list) : base(list.Cast<CityTbl>().ToList()) { }
    }
}
