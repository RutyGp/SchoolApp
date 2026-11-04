using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace ViewModel
{
    public class CityDb :BaseDB
    {

        public CityTblList SelectAll()
        {
            string sql = "SELECT * FROM CityTbl";
            return new CityTblList(base.Select(sql));
        }


        protected override BaseEntity CreateModel(BaseEntity entity, OleDbDataReader reader)
        {
            CityTbl ct = entity as CityTbl;
            if (ct != null)
            {
                base.CreateModel(entity, reader);
                ct.CityName = reader["CityName"] != DBNull.Value ? reader["CityName"].ToString() : string.Empty;
            }
            return ct;
        }

        public override BaseEntity NewEntity()
        {
            return new CityTbl();
        }

        public static CityTblList list = new CityDb().SelectAll();
        public static CityTbl SelectById(int id)
        {
            CityDb db = new CityDb();
            if(CityDb.list.Count== 0)
            {
                CityDb.list = db.SelectAll();
                return CityDb.list.Find(item => item.Id == id);
            }
            return CityDb.list.Find(item => item.Id == id);
        }


    }
}
