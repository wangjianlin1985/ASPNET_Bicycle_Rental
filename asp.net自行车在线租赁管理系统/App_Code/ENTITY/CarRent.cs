using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace ENTITY
{
    /// <summary>
    ///CarRent 的摘要说明：租车实体
    /// </summary>

    public class CarRent
    {
        /*出租编号*/
        private int _rentId;
        public int rentId
        {
            get { return _rentId; }
            set { _rentId = value; }
        }

        /*出租自行车*/
        private string _carObj;
        public string carObj
        {
            get { return _carObj; }
            set { _carObj = value; }
        }

        /*租车用户*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

        /*租车开始时间*/
        private DateTime _rentTime;
        public DateTime rentTime
        {
            get { return _rentTime; }
            set { _rentTime = value; }
        }

        /*还车时间*/
        private string _returnTime;
        public string returnTime
        {
            get { return _returnTime; }
            set { _returnTime = value; }
        }

        /*租金*/
        private float _rentMoney;
        public float rentMoney
        {
            get { return _rentMoney; }
            set { _rentMoney = value; }
        }

        /*备注信息*/
        private string _rentMemo;
        public string rentMemo
        {
            get { return _rentMemo; }
            set { _rentMemo = value; }
        }

    }
}
