using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*出租状态业务逻辑层*/
    public class bllRentState{
        /*添加出租状态*/
        public static bool AddRentState(ENTITY.RentState rentState)
        {
            return DAL.dalRentState.AddRentState(rentState);
        }

        /*根据stateId获取某条出租状态记录*/
        public static ENTITY.RentState getSomeRentState(int stateId)
        {
            return DAL.dalRentState.getSomeRentState(stateId);
        }

        /*更新出租状态*/
        public static bool EditRentState(ENTITY.RentState rentState)
        {
            return DAL.dalRentState.EditRentState(rentState);
        }

        /*删除出租状态*/
        public static bool DelRentState(string p)
        {
            return DAL.dalRentState.DelRentState(p);
        }

        /*查询出租状态*/
        public static System.Data.DataSet GetRentState(string strWhere)
        {
            return DAL.dalRentState.GetRentState(strWhere);
        }

        /*根据条件分页查询出租状态*/
        public static System.Data.DataTable GetRentState(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalRentState.GetRentState(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的出租状态*/
        public static System.Data.DataSet getAllRentState()
        {
            return DAL.dalRentState.getAllRentState();
        }
    }
}
