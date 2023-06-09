using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*自行车信息业务逻辑层*/
    public class bllCarInfo{
        /*添加自行车信息*/
        public static bool AddCarInfo(ENTITY.CarInfo carInfo)
        {
            return DAL.dalCarInfo.AddCarInfo(carInfo);
        }

        /*根据chepaiNo获取某条自行车信息记录*/
        public static ENTITY.CarInfo getSomeCarInfo(string chepaiNo)
        {
            return DAL.dalCarInfo.getSomeCarInfo(chepaiNo);
        }

        /*更新自行车信息*/
        public static bool EditCarInfo(ENTITY.CarInfo carInfo)
        {
            return DAL.dalCarInfo.EditCarInfo(carInfo);
        }

        /*删除自行车信息*/
        public static bool DelCarInfo(string p)
        {
            return DAL.dalCarInfo.DelCarInfo(p);
        }

        /*查询自行车信息*/
        public static System.Data.DataSet GetCarInfo(string strWhere)
        {
            return DAL.dalCarInfo.GetCarInfo(strWhere);
        }

        /*根据条件分页查询自行车信息*/
        public static System.Data.DataTable GetCarInfo(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalCarInfo.GetCarInfo(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的自行车信息*/
        public static System.Data.DataSet getAllCarInfo()
        {
            return DAL.dalCarInfo.getAllCarInfo();
        }
    }
}
