using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*出租状态业务逻辑层实现*/
    public class dalRentState
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加出租状态实现*/
        public static bool AddRentState(ENTITY.RentState rentState)
        {
            string sql = "insert into RentState(stateName) values(@stateName)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@stateName",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = rentState.stateName; //状态名称

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据stateId获取某条出租状态记录*/
        public static ENTITY.RentState getSomeRentState(int stateId)
        {
            /*构建查询sql*/
            string sql = "select * from RentState where stateId=" + stateId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.RentState rentState = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                rentState = new ENTITY.RentState();
                rentState.stateId = Convert.ToInt32(DataRead["stateId"]);
                rentState.stateName = DataRead["stateName"].ToString();
            }
            return rentState;
        }

        /*更新出租状态实现*/
        public static bool EditRentState(ENTITY.RentState rentState)
        {
            string sql = "update RentState set stateName=@stateName where stateId=@stateId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@stateName",SqlDbType.VarChar),
             new SqlParameter("@stateId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = rentState.stateName;
            parm[1].Value = rentState.stateId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除出租状态*/
        public static bool DelRentState(string p)
        {
            string sql = "delete from RentState where stateId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询出租状态*/
        public static DataSet GetRentState(string strWhere)
        {
            try
            {
                string strSql = "select * from RentState" + strWhere + " order by stateId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询出租状态*/
        public static System.Data.DataTable GetRentState(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from RentState";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "stateId", strShow, strSql, strWhere, " stateId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllRentState()
        {
            try
            {
                string strSql = "select * from RentState";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
