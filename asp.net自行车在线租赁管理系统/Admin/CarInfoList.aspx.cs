using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace chengxusheji.Admin
{
    public partial class CarInfoList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindcolorObj();
                BindshiftWayObj();
                BindrentStateObj();
                string sqlstr = " where 1=1 ";
                if (Request["chepaiNo"] != null && Request["chepaiNo"].ToString() != "")
                {
                    sqlstr += "  and chepaiNo like '%" + Request["chepaiNo"].ToString() + "%'";
                    chepaiNo.Text = Request["chepaiNo"].ToString();
                }
                if (Request["carName"] != null && Request["carName"].ToString() != "")
                {
                    sqlstr += "  and carName like '%" + Request["carName"].ToString() + "%'";
                    carName.Text = Request["carName"].ToString();
                }
                if (Request["colorObj"] != null && Request["colorObj"].ToString() != "0")
                {
                    sqlstr += "  and colorObj=" + Request["colorObj"].ToString();
                    colorObj.SelectedValue = Request["colorObj"].ToString();
                }
                if (Request["shiftWayObj"] != null && Request["shiftWayObj"].ToString() != "0")
                {
                    sqlstr += "  and shiftWayObj=" + Request["shiftWayObj"].ToString();
                    shiftWayObj.SelectedValue = Request["shiftWayObj"].ToString();
                }
                if (Request["outDate"] != null && Request["outDate"].ToString() != "")
                {
                    sqlstr += "  and Convert(varchar,outDate,120) like '" + Request["outDate"].ToString() + "%'";
                    outDate.Text = Request["outDate"].ToString();
                }
                if (Request["rentStateObj"] != null && Request["rentStateObj"].ToString() != "0")
                {
                    sqlstr += "  and rentStateObj=" + Request["rentStateObj"].ToString();
                    rentStateObj.SelectedValue = Request["rentStateObj"].ToString();
                }
                HWhere.Value = sqlstr;
                BindData("");
            }
        }
        private void BindcolorObj()
        {
            ListItem li = new ListItem("不限制", "0");
            colorObj.Items.Add(li);
            DataSet colorObjDs = BLL.bllColor.getAllColor();
            for (int i = 0; i < colorObjDs.Tables[0].Rows.Count; i++)
            {
                DataRow dr = colorObjDs.Tables[0].Rows[i];
                li = new ListItem(dr["colorName"].ToString(), dr["colorName"].ToString());
                colorObj.Items.Add(li);
            }
            colorObj.SelectedValue = "0";
        }

        private void BindshiftWayObj()
        {
            ListItem li = new ListItem("不限制", "0");
            shiftWayObj.Items.Add(li);
            DataSet shiftWayObjDs = BLL.bllShiftWay.getAllShiftWay();
            for (int i = 0; i < shiftWayObjDs.Tables[0].Rows.Count; i++)
            {
                DataRow dr = shiftWayObjDs.Tables[0].Rows[i];
                li = new ListItem(dr["shiftName"].ToString(), dr["shiftName"].ToString());
                shiftWayObj.Items.Add(li);
            }
            shiftWayObj.SelectedValue = "0";
        }

        private void BindrentStateObj()
        {
            ListItem li = new ListItem("不限制", "0");
            rentStateObj.Items.Add(li);
            DataSet rentStateObjDs = BLL.bllRentState.getAllRentState();
            for (int i = 0; i < rentStateObjDs.Tables[0].Rows.Count; i++)
            {
                DataRow dr = rentStateObjDs.Tables[0].Rows[i];
                li = new ListItem(dr["stateName"].ToString(), dr["stateName"].ToString());
                rentStateObj.Items.Add(li);
            }
            rentStateObj.SelectedValue = "0";
        }

        protected void BtnCarInfoAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("CarInfoEdit.aspx");
        }

        protected void BtnAllDel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(HSelectID.Value.Trim()))
            {
                try
                {
                    if (BLL.bllCarInfo.DelCarInfo(HSelectID.Value.Trim()))
                    {
                        Common.ShowMessage.Show(Page, "suess", "信息成功删除..", "CarInfoList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "error", "信息删除失败，请重试或联系管理人员..");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "error", "删除失败..");
                }
            }
        }

        private void BindData(string strClass)
        {
            int DataCount = 0;
            int NowPage = 1;
            int AllPage = 0;
            int PageSize = Convert.ToInt32(HPageSize.Value);
            switch (strClass)
            {
                case "next":
                    NowPage = Convert.ToInt32(HNowPage.Value) + 1;
                    break;
                case "up":
                    NowPage = Convert.ToInt32(HNowPage.Value) - 1;
                    break;
                case "end":
                    NowPage = Convert.ToInt32(HAllPage.Value);
                    break;
                default:
                    break;
            }
            DataTable dsLog = BLL.bllCarInfo.GetCarInfo(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
            if (dsLog.Rows.Count == 0 || AllPage == 1)
            {
                LBEnd.Enabled = false;
                LBHome.Enabled = false;
                LBNext.Enabled = false;
                LBUp.Enabled = false;
            }
            else if (NowPage == 1)
            {
                LBHome.Enabled = false;
                LBUp.Enabled = false;
                LBNext.Enabled = true;
                LBEnd.Enabled = true;
            }
            else if (NowPage == AllPage)
            {
                LBHome.Enabled = true;
                LBUp.Enabled = true;
                LBNext.Enabled = false;
                LBEnd.Enabled = false;
            }
            else
            {
                LBEnd.Enabled = true;
                LBHome.Enabled = true;
                LBNext.Enabled = true;
                LBUp.Enabled = true;
            }
            RpCarInfo.DataSource = dsLog;
            RpCarInfo.DataBind();
            PageMes.Text = string.Format("[每页<font color=green>{0}</font>条 第<font color=red>{1}</font>页／共<font color=green>{2}</font>页   共<font color=green>{3}</font>条]", PageSize, NowPage, AllPage, DataCount);
            HNowPage.Value = Convert.ToString(NowPage++);
            HAllPage.Value = AllPage.ToString();
        }

        protected void LBHome_Click(object sender, EventArgs e)
        {
            BindData("");
        }
        protected void LBUp_Click(object sender, EventArgs e)
        {
            BindData("up");
        }
        protected void LBNext_Click(object sender, EventArgs e)
        {
            BindData("next");
        }
        protected void LBEnd_Click(object sender, EventArgs e)
        {
            BindData("end");
        }
        protected void RpCarInfo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                try
                {
                    if (BLL.bllCarInfo.DelCarInfo((e.CommandArgument.ToString())))
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除成功...", "CarInfoList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除失败，请重试或联系管理人员...", "CarInfoList.aspx");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "seuss", "删除失败...", "CarInfoList.aspx");
                }
            }
        }
        public string GetColorcolorObj(string colorObj)
        {
            return BLL.bllColor.getSomeColor(int.Parse(colorObj)).colorName;
        }

        public string GetShiftWayshiftWayObj(string shiftWayObj)
        {
            return BLL.bllShiftWay.getSomeShiftWay(int.Parse(shiftWayObj)).shiftName;
        }

        public string GetRentStaterentStateObj(string rentStateObj)
        {
            return BLL.bllRentState.getSomeRentState(int.Parse(rentStateObj)).stateName;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("CarInfoList.aspx?chepaiNo=" + chepaiNo.Text.Trim() + "&&carName=" + carName.Text.Trim() + "&&colorObj=" + colorObj.SelectedValue.Trim() + "&&shiftWayObj=" + shiftWayObj.SelectedValue.Trim()+ "&&outDate=" + outDate.Text.Trim() + "&&rentStateObj=" + rentStateObj.SelectedValue.Trim());
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataSet carInfoDataSet = BLL.bllCarInfo.GetCarInfo(HWhere.Value); 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            sb.Append("<table borderColor='black' border='1' >");
            sb.Append("<thead><tr><th colSpan='9'>自行车信息记录</th></tr>");
            sb.Append("<tr class='title'>");
            sb.Append("<th>车牌号码</th>");
            sb.Append("<th>型号</th>");
            sb.Append("<th>自行车名称</th>");
            sb.Append("<th>颜色</th>");
            sb.Append("<th>启动方式</th>");
            sb.Append("<th>每小时单价</th>");
            sb.Append("<th>出厂日期</th>");
            sb.Append("<th>自行车图片</th>");
            sb.Append("<th>出租状态</th>");
            sb.Append("</tr></thead>");
            sb.Append("<tbody>");
            for (int i = 0; i < carInfoDataSet.Tables[0].Rows.Count; i++)
            {
                DataRow dr = carInfoDataSet.Tables[0].Rows[i];
                sb.Append("<tr height='60' class=content>");
                sb.Append("<td>" + dr["chepaiNo"].ToString() + "</td>");
                sb.Append("<td>" + dr["serialNo"].ToString() + "</td>");
                sb.Append("<td>" + dr["carName"].ToString() + "</td>");
                sb.Append("<td>" + BLL.bllColor.getSomeColor(Convert.ToInt32(dr["colorObj"])).colorName + "</td>");
                sb.Append("<td>" + BLL.bllShiftWay.getSomeShiftWay(Convert.ToInt32(dr["shiftWayObj"])).shiftName + "</td>");
                sb.Append("<td>" + dr["price"].ToString() + "</td>");
                sb.Append("<td>" + Convert.ToDateTime(dr["outDate"]).ToShortDateString() + "</td>");
                sb.Append("<td width=80><span align='center'><img width='80' height='60' border='0' src='" + GetBaseUrl() + "/" +  dr["carPhoto"].ToString() + "'/></span></td>");
                sb.Append("<td>" + BLL.bllRentState.getSomeRentState(Convert.ToInt32(dr["rentStateObj"])).stateName + "</td>");
                sb.Append("</tr>");
            } 
           sb.Append("</tbody></table>");
            string content = sb.ToString();
            string css = ".content{color:red;text-align:center;}";
            string filename = "自行车信息记录.xls";
            CommonTool.ExportToExcel(filename, content, css);
        }

        protected string GetBaseUrl()
        {
            return Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf("/Admin"));
        }
    }
}
