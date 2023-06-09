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
    public partial class CarRentList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindcarObj();
                BinduserObj();
                string sqlstr = " where 1=1 ";
                if (Request["carObj"] != null && Request["carObj"].ToString() != "")
                {
                    sqlstr += "  and carObj='" + Request["carObj"].ToString() + "'";
                    carObj.SelectedValue = Request["carObj"].ToString();
                }
                if (Request["userObj"] != null && Request["userObj"].ToString() != "")
                {
                    sqlstr += "  and userObj='" + Request["userObj"].ToString() + "'";
                    userObj.SelectedValue = Request["userObj"].ToString();
                }
                if (Request["rentTime"] != null && Request["rentTime"].ToString() != "")
                {
                    sqlstr += "  and Convert(varchar,rentTime,120) like '" + Request["rentTime"].ToString() + "%'";
                    rentTime.Text = Request["rentTime"].ToString();
                }
                if (Request["returnTime"] != null && Request["returnTime"].ToString() != "")
                {
                    sqlstr += "  and returnTime like '%" + Request["returnTime"].ToString() + "%'";
                    returnTime.Text = Request["returnTime"].ToString();
                }
                HWhere.Value = sqlstr;
                BindData("");
            }
        }
        private void BindcarObj()
        {
            ListItem li = new ListItem("不限制", "");
            carObj.Items.Add(li);
            DataSet carObjDs = BLL.bllCarInfo.getAllCarInfo();
            for (int i = 0; i < carObjDs.Tables[0].Rows.Count; i++)
            {
                DataRow dr = carObjDs.Tables[0].Rows[i];
                li = new ListItem(dr["carName"].ToString(), dr["carName"].ToString());
                carObj.Items.Add(li);
            }
            carObj.SelectedValue = "";
        }

        private void BinduserObj()
        {
            ListItem li = new ListItem("不限制", "");
            userObj.Items.Add(li);
            DataSet userObjDs = BLL.bllUserInfo.getAllUserInfo();
            for (int i = 0; i < userObjDs.Tables[0].Rows.Count; i++)
            {
                DataRow dr = userObjDs.Tables[0].Rows[i];
                li = new ListItem(dr["name"].ToString(), dr["name"].ToString());
                userObj.Items.Add(li);
            }
            userObj.SelectedValue = "";
        }

        protected void BtnCarRentAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("CarRentEdit.aspx");
        }

        protected void BtnAllDel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(HSelectID.Value.Trim()))
            {
                try
                {
                    if (BLL.bllCarRent.DelCarRent(HSelectID.Value.Trim()))
                    {
                        Common.ShowMessage.Show(Page, "suess", "信息成功删除..", "CarRentList.aspx");
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
            DataTable dsLog = BLL.bllCarRent.GetCarRent(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
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
            RpCarRent.DataSource = dsLog;
            RpCarRent.DataBind();
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
        protected void RpCarRent_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                try
                {
                    if (BLL.bllCarRent.DelCarRent((e.CommandArgument.ToString())))
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除成功...", "CarRentList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除失败，请重试或联系管理人员...", "CarRentList.aspx");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "seuss", "删除失败...", "CarRentList.aspx");
                }
            }
        }
        public string GetCarInfocarObj(string carObj)
        {
            return BLL.bllCarInfo.getSomeCarInfo(carObj).carName;
        }

        public string GetUserInfouserObj(string userObj)
        {
            return BLL.bllUserInfo.getSomeUserInfo(userObj).name;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("CarRentList.aspx?carObj=" + carObj.SelectedValue.Trim() + "&&userObj=" + userObj.SelectedValue.Trim()+ "&&rentTime=" + rentTime.Text.Trim()+ "&&returnTime=" + returnTime.Text.Trim());
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataSet carRentDataSet = BLL.bllCarRent.GetCarRent(HWhere.Value); 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            sb.Append("<table borderColor='black' border='1' >");
            sb.Append("<thead><tr><th colSpan='6'>租车记录</th></tr>");
            sb.Append("<tr class='title'>");
            sb.Append("<th>出租编号</th>");
            sb.Append("<th>出租自行车</th>");
            sb.Append("<th>租车用户</th>");
            sb.Append("<th>租车开始时间</th>");
            sb.Append("<th>还车时间</th>");
            sb.Append("<th>租金</th>");
            sb.Append("</tr></thead>");
            sb.Append("<tbody>");
            for (int i = 0; i < carRentDataSet.Tables[0].Rows.Count; i++)
            {
                DataRow dr = carRentDataSet.Tables[0].Rows[i];
                sb.Append("<tr class=content>");
                sb.Append("<td>" + dr["rentId"].ToString() + "</td>");
                sb.Append("<td>" + BLL.bllCarInfo.getSomeCarInfo(dr["carObj"].ToString()).carName + "</td>");
                sb.Append("<td>" + BLL.bllUserInfo.getSomeUserInfo(dr["userObj"].ToString()).name + "</td>");
                sb.Append("<td>" + Convert.ToDateTime(dr["rentTime"]).ToShortDateString() + "</td>");
                sb.Append("<td>" + dr["returnTime"].ToString() + "</td>");
                sb.Append("<td>" + dr["rentMoney"].ToString() + "</td>");
                sb.Append("</tr>");
            } 
           sb.Append("</tbody></table>");
            string content = sb.ToString();
            string css = ".content{color:red;text-align:center;}";
            string filename = "租车记录.xls";
            CommonTool.ExportToExcel(filename, content, css);
        }

        protected string GetBaseUrl()
        {
            return Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf("/Admin"));
        }
    }
}
