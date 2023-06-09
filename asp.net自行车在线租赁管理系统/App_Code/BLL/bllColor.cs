using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*自行车颜色业务逻辑层*/
    public class bllColor{
        /*添加自行车颜色*/
        public static bool AddColor(ENTITY.Color color)
        {
            return DAL.dalColor.AddColor(color);
        }

        /*根据colorId获取某条自行车颜色记录*/
        public static ENTITY.Color getSomeColor(int colorId)
        {
            return DAL.dalColor.getSomeColor(colorId);
        }

        /*更新自行车颜色*/
        public static bool EditColor(ENTITY.Color color)
        {
            return DAL.dalColor.EditColor(color);
        }

        /*删除自行车颜色*/
        public static bool DelColor(string p)
        {
            return DAL.dalColor.DelColor(p);
        }

        /*查询自行车颜色*/
        public static System.Data.DataSet GetColor(string strWhere)
        {
            return DAL.dalColor.GetColor(strWhere);
        }

        /*根据条件分页查询自行车颜色*/
        public static System.Data.DataTable GetColor(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalColor.GetColor(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的自行车颜色*/
        public static System.Data.DataSet getAllColor()
        {
            return DAL.dalColor.getAllColor();
        }
    }
}
