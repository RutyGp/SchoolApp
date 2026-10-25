using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class PersonTbl:BaseEntity
    {
        private string firstName;
        private string lastName;
        private CityTbl livingCity;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public CityTbl LivingCity { get => livingCity; set => livingCity = value; }

        public override string ToString()
        {
            return $"{ base.ToString()}  { FirstName} { LastName}"
                 + $" { LivingCity} ";
        }
    }
}
