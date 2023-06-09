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
    ///Color 的摘要说明：自行车颜色实体
    /// </summary>

    public class Color
    {
        /*颜色编号*/
        private int _colorId;
        public int colorId
        {
            get { return _colorId; }
            set { _colorId = value; }
        }

        /*颜色名称*/
        private string _colorName;
        public string colorName
        {
            get { return _colorName; }
            set { _colorName = value; }
        }

    }
}
