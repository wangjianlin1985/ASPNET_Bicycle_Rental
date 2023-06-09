using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class CarInfo_frontList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
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
            li = new ListItem(dr["colorName"].ToString(),dr["colorId"].ToString());
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
            li = new ListItem(dr["shiftName"].ToString(),dr["shitWayId"].ToString());
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
            li = new ListItem(dr["stateName"].ToString(),dr["stateId"].ToString());
            rentStateObj.Items.Add(li);
        }
        rentStateObj.SelectedValue = "0";
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
            Response.Redirect("frontList.aspx?chepaiNo=" + chepaiNo.Text.Trim() + "&&carName=" + carName.Text.Trim() + "&&colorObj=" + colorObj.SelectedValue.Trim() + "&&shiftWayObj=" + shiftWayObj.SelectedValue.Trim()+ "&&outDate=" + outDate.Text.Trim() + "&&rentStateObj=" + rentStateObj.SelectedValue.Trim());
        }

}
