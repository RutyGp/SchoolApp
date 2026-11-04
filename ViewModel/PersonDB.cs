using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace ViewModel
{
    public class PersonDb: BaseDB
    {
    public PersonTblList SelectAll()
    {
        string sql = "SELECT * FROM PersonTbl";
        return new PersonTblList(base.Select(sql));
    }


    protected override BaseEntity CreateModel(BaseEntity entity, OleDbDataReader reader)
    {
        PersonTbl ct = entity as PersonTbl;
        if (ct != null)
        {
            base.CreateModel(entity, reader);
            ct.FirstName = reader["firstName"] != DBNull.Value ? reader["firstName"].ToString() : string.Empty;
            ct.LastName = reader["lastName"] != DBNull.Value ? reader["lastName"].ToString() : string.Empty;
            ct.LivingCity = reader["CityCode"] != DBNull.Value ? 
                                         CityDb.SelectById(int.Parse(reader["CityCode"].ToString())) : null;
            ct.IsActive = reader["isActive"] != DBNull.Value && bool.Parse(reader["isActive"].ToString());
        }
        return ct;
    }

    public override BaseEntity NewEntity()
    {
        return new PersonTbl();
    }

    public static PersonTblList list = new PersonDb().SelectAll();
    public static PersonTbl SelectById(int id)
    {
        PersonDb db = new PersonDb();
        PersonDb.list = db.SelectAll();
        return PersonDb.list.Find(item => item.Id == id);        
    }



}
}