using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*启动方式业务逻辑层*/
    public class bllShiftWay{
        /*添加启动方式*/
        public static bool AddShiftWay(ENTITY.ShiftWay shiftWay)
        {
            return DAL.dalShiftWay.AddShiftWay(shiftWay);
        }

        /*根据shitWayId获取某条启动方式记录*/
        public static ENTITY.ShiftWay getSomeShiftWay(int shitWayId)
        {
            return DAL.dalShiftWay.getSomeShiftWay(shitWayId);
        }

        /*更新启动方式*/
        public static bool EditShiftWay(ENTITY.ShiftWay shiftWay)
        {
            return DAL.dalShiftWay.EditShiftWay(shiftWay);
        }

        /*删除启动方式*/
        public static bool DelShiftWay(string p)
        {
            return DAL.dalShiftWay.DelShiftWay(p);
        }

        /*查询启动方式*/
        public static System.Data.DataSet GetShiftWay(string strWhere)
        {
            return DAL.dalShiftWay.GetShiftWay(strWhere);
        }

        /*根据条件分页查询启动方式*/
        public static System.Data.DataTable GetShiftWay(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalShiftWay.GetShiftWay(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的启动方式*/
        public static System.Data.DataSet getAllShiftWay()
        {
            return DAL.dalShiftWay.getAllShiftWay();
        }
    }
}
