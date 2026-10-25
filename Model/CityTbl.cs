using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class CityTbl : BaseEntity
    {
        private string cityName;

        public string CityName { get => cityName; set => cityName = value; }

        public override string ToString()
        {
            return base.ToString()+" " + CityName.ToString();
        }
    }

  
}
