using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*自行车信息业务逻辑层实现*/
    public class dalCarInfo
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加自行车信息实现*/
        public static bool AddCarInfo(ENTITY.CarInfo carInfo)
        {
            string sql = "insert into CarInfo(chepaiNo,serialNo,carName,colorObj,shiftWayObj,price,outDate,makeAddress,carPhoto,cofigParam,rentStateObj) values(@chepaiNo,@serialNo,@carName,@colorObj,@shiftWayObj,@price,@outDate,@makeAddress,@carPhoto,@cofigParam,@rentStateObj)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@chepaiNo",SqlDbType.VarChar),
             new SqlParameter("@serialNo",SqlDbType.VarChar),
             new SqlParameter("@carName",SqlDbType.VarChar),
             new SqlParameter("@colorObj",SqlDbType.Int),
             new SqlParameter("@shiftWayObj",SqlDbType.Int),
             new SqlParameter("@price",SqlDbType.Float),
             new SqlParameter("@outDate",SqlDbType.DateTime),
             new SqlParameter("@makeAddress",SqlDbType.VarChar),
             new SqlParameter("@carPhoto",SqlDbType.VarChar),
             new SqlParameter("@cofigParam",SqlDbType.VarChar),
             new SqlParameter("@rentStateObj",SqlDbType.Int)
            };
            /*给参数赋值*/
            parm[0].Value = carInfo.chepaiNo; //车牌号码
            parm[1].Value = carInfo.serialNo; //型号
            parm[2].Value = carInfo.carName; //自行车名称
            parm[3].Value = carInfo.colorObj; //颜色
            parm[4].Value = carInfo.shiftWayObj; //启动方式
            parm[5].Value = carInfo.price; //每小时单价
            parm[6].Value = carInfo.outDate; //出厂日期
            parm[7].Value = carInfo.makeAddress; //厂家地址
            parm[8].Value = carInfo.carPhoto; //自行车图片
            parm[9].Value = carInfo.cofigParam; //参数配置
            parm[10].Value = carInfo.rentStateObj; //出租状态

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据chepaiNo获取某条自行车信息记录*/
        public static ENTITY.CarInfo getSomeCarInfo(string chepaiNo)
        {
            /*构建查询sql*/
            string sql = "select * from CarInfo where chepaiNo='" + chepaiNo + "'"; 
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.CarInfo carInfo = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                carInfo = new ENTITY.CarInfo();
                carInfo.chepaiNo = DataRead["chepaiNo"].ToString();
                carInfo.serialNo = DataRead["serialNo"].ToString();
                carInfo.carName = DataRead["carName"].ToString();
                carInfo.colorObj = Convert.ToInt32(DataRead["colorObj"]);
                carInfo.shiftWayObj = Convert.ToInt32(DataRead["shiftWayObj"]);
                carInfo.price = float.Parse(DataRead["price"].ToString());
                carInfo.outDate = Convert.ToDateTime(DataRead["outDate"].ToString());
                carInfo.makeAddress = DataRead["makeAddress"].ToString();
                carInfo.carPhoto = DataRead["carPhoto"].ToString();
                carInfo.cofigParam = DataRead["cofigParam"].ToString();
                carInfo.rentStateObj = Convert.ToInt32(DataRead["rentStateObj"]);
            }
            return carInfo;
        }

        /*更新自行车信息实现*/
        public static bool EditCarInfo(ENTITY.CarInfo carInfo)
        {
            string sql = "update CarInfo set serialNo=@serialNo,carName=@carName,colorObj=@colorObj,shiftWayObj=@shiftWayObj,price=@price,outDate=@outDate,makeAddress=@makeAddress,carPhoto=@carPhoto,cofigParam=@cofigParam,rentStateObj=@rentStateObj where chepaiNo=@chepaiNo";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@serialNo",SqlDbType.VarChar),
             new SqlParameter("@carName",SqlDbType.VarChar),
             new SqlParameter("@colorObj",SqlDbType.Int),
             new SqlParameter("@shiftWayObj",SqlDbType.Int),
             new SqlParameter("@price",SqlDbType.Float),
             new SqlParameter("@outDate",SqlDbType.DateTime),
             new SqlParameter("@makeAddress",SqlDbType.VarChar),
             new SqlParameter("@carPhoto",SqlDbType.VarChar),
             new SqlParameter("@cofigParam",SqlDbType.VarChar),
             new SqlParameter("@rentStateObj",SqlDbType.Int),
             new SqlParameter("@chepaiNo",SqlDbType.VarChar)
            };
            /*为参数赋值*/
            parm[0].Value = carInfo.serialNo;
            parm[1].Value = carInfo.carName;
            parm[2].Value = carInfo.colorObj;
            parm[3].Value = carInfo.shiftWayObj;
            parm[4].Value = carInfo.price;
            parm[5].Value = carInfo.outDate;
            parm[6].Value = carInfo.makeAddress;
            parm[7].Value = carInfo.carPhoto;
            parm[8].Value = carInfo.cofigParam;
            parm[9].Value = carInfo.rentStateObj;
            parm[10].Value = carInfo.chepaiNo;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除自行车信息*/
        public static bool DelCarInfo(string p)
        {
            string sql = "";
            string[] ids = p.Split(',');
            for(int i=0;i<ids.Length;i++)
            {
                if(i != ids.Length-1)
                  sql += "'" + ids[i] + "',";
                else
                  sql += "'" + ids[i] + "'";
            }
            sql = "delete from CarInfo where chepaiNo in (" + sql + ")";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询自行车信息*/
        public static DataSet GetCarInfo(string strWhere)
        {
            try
            {
                string strSql = "select * from CarInfo" + strWhere + " order by chepaiNo asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询自行车信息*/
        public static System.Data.DataTable GetCarInfo(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from CarInfo";
                string strShow = "*";
                return DAL.DBHelp.ExecutePagerWhenPrimaryIsString(PageIndex, PageSize, "chepaiNo", strShow, strSql, strWhere, " chepaiNo asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllCarInfo()
        {
            try
            {
                string strSql = "select * from CarInfo";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
