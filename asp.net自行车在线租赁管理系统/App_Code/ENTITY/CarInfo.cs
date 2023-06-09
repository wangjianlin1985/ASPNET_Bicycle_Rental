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
    ///CarInfo 的摘要说明：自行车信息实体
    /// </summary>

    public class CarInfo
    {
        /*车牌号码*/
        private string _chepaiNo;
        public string chepaiNo
        {
            get { return _chepaiNo; }
            set { _chepaiNo = value; }
        }

        /*型号*/
        private string _serialNo;
        public string serialNo
        {
            get { return _serialNo; }
            set { _serialNo = value; }
        }

        /*自行车名称*/
        private string _carName;
        public string carName
        {
            get { return _carName; }
            set { _carName = value; }
        }

        /*颜色*/
        private int _colorObj;
        public int colorObj
        {
            get { return _colorObj; }
            set { _colorObj = value; }
        }

        /*启动方式*/
        private int _shiftWayObj;
        public int shiftWayObj
        {
            get { return _shiftWayObj; }
            set { _shiftWayObj = value; }
        }

        /*每小时单价*/
        private float _price;
        public float price
        {
            get { return _price; }
            set { _price = value; }
        }

        /*出厂日期*/
        private DateTime _outDate;
        public DateTime outDate
        {
            get { return _outDate; }
            set { _outDate = value; }
        }

        /*厂家地址*/
        private string _makeAddress;
        public string makeAddress
        {
            get { return _makeAddress; }
            set { _makeAddress = value; }
        }

        /*自行车图片*/
        private string _carPhoto;
        public string carPhoto
        {
            get { return _carPhoto; }
            set { _carPhoto = value; }
        }

        /*参数配置*/
        private string _cofigParam;
        public string cofigParam
        {
            get { return _cofigParam; }
            set { _cofigParam = value; }
        }

        /*出租状态*/
        private int _rentStateObj;
        public int rentStateObj
        {
            get { return _rentStateObj; }
            set { _rentStateObj = value; }
        }

    }
}
