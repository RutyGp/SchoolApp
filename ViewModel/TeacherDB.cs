using Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;
using System.Text;
 
namespace ViewModel
{
    public class TeacherDB : PersonDb
    {
        public TeacherTblList SelectAll()
        {
            string sql = "SELECT TeacherTBL.id, TeacherTBL.isEducator," +
                " TeacherTBL.startWorkingDate, PersonTBL.firstName, " +
                " PersonTBL.lastNAme, PersonTBL.cityCode, PersonTBL.isActive " +
                " FROM ( TeacherTBL INNER JOIN " +
                        " PersonTBL ON TeacherTBL.id = PersonTBL.id) ";
            return new TeacherTblList(base.Select(sql));
        }


        protected override BaseEntity CreateModel(BaseEntity entity, OleDbDataReader reader)
        {
            TeacherTbl t = entity as TeacherTbl;
            if (t != null)
            {
                base.CreateModel(entity, reader);
                t.IsEducator = reader["isEducator"] != DBNull.Value &&
                                        bool.Parse(reader["isEducator"].ToString());
                t.StartWorkingDate = reader["startWorkingDate"] != DBNull.Value ? 
                       DateTime.Parse(reader["startWorkingDate"].ToString()) :
                       DateTime.MinValue;
            }
            return t;
        }

        public override BaseEntity NewEntity()
        {
            return new TeacherTbl();
        }

        public static TeacherTblList list = new TeacherDB().SelectAll();
        public static TeacherTbl SelectById(int id)
        {
            TeacherDB db = new TeacherDB();
            TeacherDB.list = db.SelectAll();
            return TeacherDB.list.Find(item => item.Id == id);
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            TeacherTbl teacher = entity as TeacherTbl;
            if (teacher != null)
            {
                cmd.CommandText = "UPDATE TeacherTbl SET " +
                                  "isEducator = @isEducator, " +
                                  "startWorkingDate = @startWorkingDate " +
                                  "WHERE id = @id";
                // 1. עבור ה-Boolean (isEducator)
                OleDbParameter isEducatorParam = new OleDbParameter("@isEducator", OleDbType.Boolean);
                isEducatorParam.Value = teacher.IsEducator;
                cmd.Parameters.Add(isEducatorParam);

                // 2. עבור ה-DateTime (startWorkingDate)
                OleDbParameter dateParam = new OleDbParameter("@startWorkingDate", OleDbType.Date);
                dateParam.Value = teacher.StartWorkingDate;
                cmd.Parameters.Add(dateParam);
           
                
                cmd.Parameters.AddWithValue("@id", teacher.Id);
            }
        }
        //protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        //{
        //    TeacherTbl teacher = entity as TeacherTbl;
        //    if (teacher != null)
        //    {
        //        // ב-OleDb מומלץ להשתמש בסימני שאלה (?), מכיוון שהשמות המילוליים של הפרמטרים אינם נחשבים
        //        cmd.CommandText = "UPDATE TeacherTbl SET " +
        //                          "isEducator = ?, " +
        //                          "startWorkingDate = ? " +
        //                          "WHERE id = ?";

        //        // חובה להוסיף את הפרמטרים בדיוק לפי סדר הופעתם בשאילתה!

        //        // 1. עבור ה-Boolean (isEducator)
        //        OleDbParameter isEducatorParam = new OleDbParameter("@isEducator", OleDbType.Boolean);
        //        isEducatorParam.Value = teacher.IsEducator;
        //        cmd.Parameters.Add(isEducatorParam);

        //        // 2. עבור ה-DateTime (startWorkingDate)
        //        OleDbParameter dateParam = new OleDbParameter("@startWorkingDate", OleDbType.Date);
        //        dateParam.Value = teacher.StartWorkingDate;
        //        cmd.Parameters.Add(dateParam);

        //        // 3. עבור ה-ID (WHERE id = ?)
        //        OleDbParameter idParam = new OleDbParameter("@id", OleDbType.Integer); // או OleDbType.VarWChar אם זה טקסט
        //        idParam.Value = teacher.Id;
        //        cmd.Parameters.Add(idParam);
        //    }
        //}

        public override void Update(BaseEntity entity)
        {
            TeacherTbl Teacher = entity as TeacherTbl;
            if (Teacher != null)
            {
                updated.Add(new ChangeEntity(this.CreateUpdatedSQL, entity));
                updated.Add(new ChangeEntity(base.CreateUpdatedSQL, entity));
            }

        }

    }
}
