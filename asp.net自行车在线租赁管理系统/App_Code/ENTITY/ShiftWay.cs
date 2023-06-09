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
    ///ShiftWay 的摘要说明：启动方式实体
    /// </summary>

    public class ShiftWay
    {
        /*记录id*/
        private int _shitWayId;
        public int shitWayId
        {
            get { return _shitWayId; }
            set { _shitWayId = value; }
        }

        /*启动方式名称*/
        private string _shiftName;
        public string shiftName
        {
            get { return _shiftName; }
            set { _shiftName = value; }
        }

    }
}
