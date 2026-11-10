using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace ViewModel
{
    public class StudentDB :PersonDb
    {
        public StudentTblList SelectAll()
        {
            string sql = "SELECT PersonTBL.id, PersonTBL.firstName, PersonTBL.lastNAme, PersonTBL.cityCode, PersonTBL.isActive, StudentTbl.tel " +
                         "FROM  (PersonTBL INNER JOIN StudentTbl ON PersonTBL.id = StudentTbl.id)";
            return new StudentTblList(base.Select(sql));
        }


        protected override BaseEntity CreateModel(BaseEntity entity, OleDbDataReader reader)
        {
            StudentTbl ct = entity as StudentTbl;
            if (ct != null)
            {
                base.CreateModel(entity, reader);
                ct.Tel = reader["tel"] != DBNull.Value ? reader["tel"].ToString() : string.Empty;
            }
            return ct;
        }

        public override BaseEntity NewEntity()
        {
            return new StudentTbl();
        }

        public static StudentTblList list = new StudentDB().SelectAll();
        public static StudentTbl SelectById(int id)
        {
            StudentDB db = new StudentDB();
            StudentDB.list = db.SelectAll();
            return StudentDB.list.Find(item => item.Id == id);
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            StudentTbl student = entity as StudentTbl;
            if (student != null)
            {
                cmd.CommandText = $"UPDATE StudentTbl SET tel = @tel WHERE id = @id";
               
                cmd.Parameters.AddWithValue("@tel", student.Tel);
                cmd.Parameters.AddWithValue("@id", student.Id);
            }
        }
        public override void Update(BaseEntity entity)
        {
            BaseEntity reqEntity = this.NewEntity();
            if (entity != null && entity.GetType() == reqEntity.GetType())
            {
                updated.Add(new ChangeEntity(this.CreateUpdatedSQL, entity));
                updated.Add(new ChangeEntity(base.CreateUpdatedSQL, entity));
            }
        }

    }
}
