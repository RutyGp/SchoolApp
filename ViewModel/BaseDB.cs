using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text;

namespace ViewModel
{
    public abstract class BaseDB
    {
        // protected static string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\nirgo\\source\\repos\\Model\\ViewModel\\ExampleProject.accdb";
        protected static string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source="
                      + System.IO.Path.GetFullPath(System.Reflection.Assembly.GetExecutingAssembly().Location
                      + "/../../../../../ViewModel/ExampleProject.accdb");


        protected static OleDbConnection connection;

    

        public BaseDB()
        {
            connection ??= new OleDbConnection(connectionString);
        }

        public abstract BaseEntity NewEntity();

        // שיטת Select אחת ויחידה, בטוחה שמונעת התנגשויות באמצעות Reader מקומי
        protected List<BaseEntity> Select(string sqlText)
        {
            List<BaseEntity> list = new List<BaseEntity>();

            using (OleDbConnection localConn = new OleDbConnection(connectionString))
            {
                using (OleDbCommand localCmd = new OleDbCommand(sqlText, localConn))
                {
                    try
                    {
                        localConn.Open();
                        using (OleDbDataReader localReader = localCmd.ExecuteReader())
                        {
                            while (localReader.Read())
                            {
                                BaseEntity entity = NewEntity();
                                list.Add(CreateModel(entity, localReader));
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.WriteLine(e.Message + "\nSQL:" + localCmd.CommandText);
                    }
                }
            }
            return list;
        }

        // שיטת עזר וירטואלית לקבלת הנתונים מה-Reader המקומי
        protected virtual BaseEntity CreateModel(BaseEntity entity, OleDbDataReader reader)
        {
            entity.Id = reader["id"] != DBNull.Value ? Convert.ToInt32(reader["id"]) : 0;
            return entity;
        }

        //// Insert, Update, Delete
        //protected abstract void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd);
        //public static List<ChangeEntity> deleted = new List<ChangeEntity>();

        //public virtual void Delete(BaseEntity entity)
        //{
        //    BaseEntity reqEntity = this.NewEntity();
        //    if (entity != null && entity.GetType() == reqEntity.GetType())
        //    {
        //        deleted.Add(new ChangeEntity(this.CreateDeletedSQL, entity));
        //    }
        //}

        //protected abstract void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd);
        //public static List<ChangeEntity> inserted = new List<ChangeEntity>();

        //public virtual void Insert(BaseEntity entity)
        //{
        //    BaseEntity reqEntity = this.NewEntity();
        //    if (entity != null && entity.GetType() == reqEntity.GetType())
        //    {
        //        inserted.Add(new ChangeEntity(this.CreateInsertdSQL, entity));
        //    }
        //}

        //protected abstract void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd);
        //public static List<ChangeEntity> updated = new List<ChangeEntity>();

        //public virtual void Update(BaseEntity entity)
        //{
        //    BaseEntity reqEntity = this.NewEntity();
        //    if (entity != null && entity.GetType() == reqEntity.GetType())
        //    {
        //        updated.Add(new ChangeEntity(this.CreateUpdatedSQL, entity));
        //    }
        //}

        //public int SaveChanges()
        //{
        //    int records_affected = 0;

        //    using (OleDbConnection localConn = new OleDbConnection(connectionString))
        //    {
        //        localConn.Open();
        //        using (OleDbTransaction trans = localConn.BeginTransaction())
        //        {
        //            using (OleDbCommand localCmd = new OleDbCommand())
        //            {
        //                localCmd.Connection = localConn;
        //                localCmd.Transaction = trans;

        //                try
        //                {
        //                    foreach (var entity in inserted)
        //                    {
        //                        localCmd.Parameters.Clear();
        //                        entity.CreateSql(entity.Entity, localCmd);
        //                        records_affected += localCmd.ExecuteNonQuery();

        //                        localCmd.Parameters.Clear();
        //                        localCmd.CommandText = "Select @@Identity";
        //                        entity.Entity.Id = (int)localCmd.ExecuteScalar();
        //                    }

        //                    foreach (var entity in updated)
        //                    {
        //                        localCmd.Parameters.Clear();
        //                        entity.CreateSql(entity.Entity, localCmd);
        //                        records_affected += localCmd.ExecuteNonQuery();
        //                    }

        //                    foreach (var entity in deleted)
        //                    {
        //                        localCmd.Parameters.Clear();
        //                        entity.CreateSql(entity.Entity, localCmd);
        //                        records_affected += localCmd.ExecuteNonQuery();
        //                    }

        //                    trans.Commit();
        //                }
        //                catch (Exception ex)
        //                {
        //                    trans.Rollback();
        //                    throw new Exception(ex.Message + "\n SQL:" + localCmd.CommandText);
        //                }
        //                finally
        //                {
        //                    inserted.Clear();
        //                    updated.Clear();
        //                    deleted.Clear();
        //                }
        //            }
        //        }
        //    }

        //    return records_affected;
        //}
    }
}



