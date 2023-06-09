using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*租车业务逻辑层实现*/
    public class dalCarRent
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加租车实现*/
        public static bool AddCarRent(ENTITY.CarRent carRent)
        {
            string sql = "insert into CarRent(carObj,userObj,rentTime,returnTime,rentMoney,rentMemo) values(@carObj,@userObj,@rentTime,@returnTime,@rentMoney,@rentMemo)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@carObj",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@rentTime",SqlDbType.DateTime),
             new SqlParameter("@returnTime",SqlDbType.VarChar),
             new SqlParameter("@rentMoney",SqlDbType.Float),
             new SqlParameter("@rentMemo",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = carRent.carObj; //出租自行车
            parm[1].Value = carRent.userObj; //租车用户
            parm[2].Value = carRent.rentTime; //租车开始时间
            parm[3].Value = carRent.returnTime; //还车时间
            parm[4].Value = carRent.rentMoney; //租金
            parm[5].Value = carRent.rentMemo; //备注信息

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据rentId获取某条租车记录*/
        public static ENTITY.CarRent getSomeCarRent(int rentId)
        {
            /*构建查询sql*/
            string sql = "select * from CarRent where rentId=" + rentId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.CarRent carRent = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                carRent = new ENTITY.CarRent();
                carRent.rentId = Convert.ToInt32(DataRead["rentId"]);
                carRent.carObj = DataRead["carObj"].ToString();
                carRent.userObj = DataRead["userObj"].ToString();
                carRent.rentTime = Convert.ToDateTime(DataRead["rentTime"].ToString());
                carRent.returnTime = DataRead["returnTime"].ToString();
                carRent.rentMoney = float.Parse(DataRead["rentMoney"].ToString());
                carRent.rentMemo = DataRead["rentMemo"].ToString();
            }
            return carRent;
        }

        /*更新租车实现*/
        public static bool EditCarRent(ENTITY.CarRent carRent)
        {
            string sql = "update CarRent set carObj=@carObj,userObj=@userObj,rentTime=@rentTime,returnTime=@returnTime,rentMoney=@rentMoney,rentMemo=@rentMemo where rentId=@rentId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@carObj",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@rentTime",SqlDbType.DateTime),
             new SqlParameter("@returnTime",SqlDbType.VarChar),
             new SqlParameter("@rentMoney",SqlDbType.Float),
             new SqlParameter("@rentMemo",SqlDbType.VarChar),
             new SqlParameter("@rentId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = carRent.carObj;
            parm[1].Value = carRent.userObj;
            parm[2].Value = carRent.rentTime;
            parm[3].Value = carRent.returnTime;
            parm[4].Value = carRent.rentMoney;
            parm[5].Value = carRent.rentMemo;
            parm[6].Value = carRent.rentId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除租车*/
        public static bool DelCarRent(string p)
        {
            string sql = "delete from CarRent where rentId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询租车*/
        public static DataSet GetCarRent(string strWhere)
        {
            try
            {
                string strSql = "select * from CarRent" + strWhere + " order by rentId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询租车*/
        public static System.Data.DataTable GetCarRent(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from CarRent";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "rentId", strShow, strSql, strWhere, " rentId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllCarRent()
        {
            try
            {
                string strSql = "select * from CarRent";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
