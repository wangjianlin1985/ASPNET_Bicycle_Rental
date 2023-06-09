using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*租车业务逻辑层*/
    public class bllCarRent{
        /*添加租车*/
        public static bool AddCarRent(ENTITY.CarRent carRent)
        {
            return DAL.dalCarRent.AddCarRent(carRent);
        }

        /*根据rentId获取某条租车记录*/
        public static ENTITY.CarRent getSomeCarRent(int rentId)
        {
            return DAL.dalCarRent.getSomeCarRent(rentId);
        }

        /*更新租车*/
        public static bool EditCarRent(ENTITY.CarRent carRent)
        {
            return DAL.dalCarRent.EditCarRent(carRent);
        }

        /*删除租车*/
        public static bool DelCarRent(string p)
        {
            return DAL.dalCarRent.DelCarRent(p);
        }

        /*查询租车*/
        public static System.Data.DataSet GetCarRent(string strWhere)
        {
            return DAL.dalCarRent.GetCarRent(strWhere);
        }

        /*根据条件分页查询租车*/
        public static System.Data.DataTable GetCarRent(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalCarRent.GetCarRent(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的租车*/
        public static System.Data.DataSet getAllCarRent()
        {
            return DAL.dalCarRent.getAllCarRent();
        }
    }
}
