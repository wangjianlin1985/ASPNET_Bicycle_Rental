using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*���г���Ϣҵ���߼���*/
    public class bllCarInfo{
        /*������г���Ϣ*/
        public static bool AddCarInfo(ENTITY.CarInfo carInfo)
        {
            return DAL.dalCarInfo.AddCarInfo(carInfo);
        }

        /*����chepaiNo��ȡĳ�����г���Ϣ��¼*/
        public static ENTITY.CarInfo getSomeCarInfo(string chepaiNo)
        {
            return DAL.dalCarInfo.getSomeCarInfo(chepaiNo);
        }

        /*�������г���Ϣ*/
        public static bool EditCarInfo(ENTITY.CarInfo carInfo)
        {
            return DAL.dalCarInfo.EditCarInfo(carInfo);
        }

        /*ɾ�����г���Ϣ*/
        public static bool DelCarInfo(string p)
        {
            return DAL.dalCarInfo.DelCarInfo(p);
        }

        /*��ѯ���г���Ϣ*/
        public static System.Data.DataSet GetCarInfo(string strWhere)
        {
            return DAL.dalCarInfo.GetCarInfo(strWhere);
        }

        /*����������ҳ��ѯ���г���Ϣ*/
        public static System.Data.DataTable GetCarInfo(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalCarInfo.GetCarInfo(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е����г���Ϣ*/
        public static System.Data.DataSet getAllCarInfo()
        {
            return DAL.dalCarInfo.getAllCarInfo();
        }
    }
}
