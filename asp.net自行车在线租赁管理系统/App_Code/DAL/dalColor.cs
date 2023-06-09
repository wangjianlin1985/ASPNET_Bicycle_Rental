using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*自行车颜色业务逻辑层实现*/
    public class dalColor
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加自行车颜色实现*/
        public static bool AddColor(ENTITY.Color color)
        {
            string sql = "insert into Color(colorName) values(@colorName)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@colorName",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = color.colorName; //颜色名称

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据colorId获取某条自行车颜色记录*/
        public static ENTITY.Color getSomeColor(int colorId)
        {
            /*构建查询sql*/
            string sql = "select * from Color where colorId=" + colorId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Color color = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                color = new ENTITY.Color();
                color.colorId = Convert.ToInt32(DataRead["colorId"]);
                color.colorName = DataRead["colorName"].ToString();
            }
            return color;
        }

        /*更新自行车颜色实现*/
        public static bool EditColor(ENTITY.Color color)
        {
            string sql = "update Color set colorName=@colorName where colorId=@colorId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@colorName",SqlDbType.VarChar),
             new SqlParameter("@colorId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = color.colorName;
            parm[1].Value = color.colorId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除自行车颜色*/
        public static bool DelColor(string p)
        {
            string sql = "delete from Color where colorId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询自行车颜色*/
        public static DataSet GetColor(string strWhere)
        {
            try
            {
                string strSql = "select * from Color" + strWhere + " order by colorId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询自行车颜色*/
        public static System.Data.DataTable GetColor(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Color";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "colorId", strShow, strSql, strWhere, " colorId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllColor()
        {
            try
            {
                string strSql = "select * from Color";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
