using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*���г���ɫҵ���߼���*/
    public class bllColor{
        /*������г���ɫ*/
        public static bool AddColor(ENTITY.Color color)
        {
            return DAL.dalColor.AddColor(color);
        }

        /*����colorId��ȡĳ�����г���ɫ��¼*/
        public static ENTITY.Color getSomeColor(int colorId)
        {
            return DAL.dalColor.getSomeColor(colorId);
        }

        /*�������г���ɫ*/
        public static bool EditColor(ENTITY.Color color)
        {
            return DAL.dalColor.EditColor(color);
        }

        /*ɾ�����г���ɫ*/
        public static bool DelColor(string p)
        {
            return DAL.dalColor.DelColor(p);
        }

        /*��ѯ���г���ɫ*/
        public static System.Data.DataSet GetColor(string strWhere)
        {
            return DAL.dalColor.GetColor(strWhere);
        }

        /*����������ҳ��ѯ���г���ɫ*/
        public static System.Data.DataTable GetColor(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalColor.GetColor(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е����г���ɫ*/
        public static System.Data.DataSet getAllColor()
        {
            return DAL.dalColor.getAllColor();
        }
    }
}
