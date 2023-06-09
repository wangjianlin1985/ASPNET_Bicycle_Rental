using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*启动方式业务逻辑层实现*/
    public class dalShiftWay
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加启动方式实现*/
        public static bool AddShiftWay(ENTITY.ShiftWay shiftWay)
        {
            string sql = "insert into ShiftWay(shiftName) values(@shiftName)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@shiftName",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = shiftWay.shiftName; //启动方式名称

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据shitWayId获取某条启动方式记录*/
        public static ENTITY.ShiftWay getSomeShiftWay(int shitWayId)
        {
            /*构建查询sql*/
            string sql = "select * from ShiftWay where shitWayId=" + shitWayId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.ShiftWay shiftWay = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                shiftWay = new ENTITY.ShiftWay();
                shiftWay.shitWayId = Convert.ToInt32(DataRead["shitWayId"]);
                shiftWay.shiftName = DataRead["shiftName"].ToString();
            }
            return shiftWay;
        }

        /*更新启动方式实现*/
        public static bool EditShiftWay(ENTITY.ShiftWay shiftWay)
        {
            string sql = "update ShiftWay set shiftName=@shiftName where shitWayId=@shitWayId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@shiftName",SqlDbType.VarChar),
             new SqlParameter("@shitWayId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = shiftWay.shiftName;
            parm[1].Value = shiftWay.shitWayId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除启动方式*/
        public static bool DelShiftWay(string p)
        {
            string sql = "delete from ShiftWay where shitWayId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询启动方式*/
        public static DataSet GetShiftWay(string strWhere)
        {
            try
            {
                string strSql = "select * from ShiftWay" + strWhere + " order by shitWayId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询启动方式*/
        public static System.Data.DataTable GetShiftWay(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from ShiftWay";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "shitWayId", strShow, strSql, strWhere, " shitWayId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllShiftWay()
        {
            try
            {
                string strSql = "select * from ShiftWay";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
