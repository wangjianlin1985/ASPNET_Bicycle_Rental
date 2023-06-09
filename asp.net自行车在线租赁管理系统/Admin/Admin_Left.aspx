<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_Left.aspx.cs" Inherits="WebSystem.Admin.Admin_Left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link href="Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JavaScript/Jquery.js"></script>
    <script src="JavaScript/Admin.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="LeftNote">
    <img src="Images/MenuTop.jpg"/><br /><img src="images/menu_topline.gif" alt=""/>
    
        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;用户管理</div>
        <div class="MenuNote" style="display:none;" id="UserInfoDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="UserInfoEdit.aspx" target="main">添加用户</a></li>
                <li><a href="UserInfoList.aspx" target="main">用户查询</a></li> 
            </ul>
        </div>


         <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;自行车信息管理</div>
        <div class="MenuNote" style="display:none;" id="CarInfoDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="CarInfoEdit.aspx" target="main">添加自行车信息</a></li>
                <li><a href="CarInfoList.aspx" target="main">自行车信息查询</a></li>
                <li><a href="ColorEdit.aspx" target="main">添加自行车颜色</a></li>
                <li><a href="ColorList.aspx" target="main">自行车颜色查询</a></li>
                <li><a href="ShiftWayEdit.aspx" target="main">添加启动方式</a></li>
                <li><a href="ShiftWayList.aspx" target="main">启动方式查询</a></li>
                <li><a href="RentStateEdit.aspx" target="main">添加出租状态</a></li>
                <li><a href="RentStateList.aspx" target="main">出租状态查询</a></li> 
            </ul>
        </div>
         

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;租车管理</div>
        <div class="MenuNote" style="display:none;" id="CarRentDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="CarRentEdit.aspx" target="main">添加租车</a></li>
                <li><a href="CarRentList.aspx" target="main">租车查询</a></li> 
            </ul>
        </div>

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;新闻公告管理</div>
        <div class="MenuNote" style="display:none;" id="NoticeDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="NoticeEdit.aspx" target="main">添加新闻公告</a></li>
                <li><a href="NoticeList.aspx" target="main">新闻公告查询</a></li> 
            </ul>
        </div>

 
    <!--
         <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;客户信息管理</div>
        <div class="MenuNote" style="display:none;" id="Div2" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
          
                <li><a href="M_CusList.aspx" target="main">客户信息列表</a></li>  
            </ul>
        </div>
        
       <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;系统信息管理</div>
        <div class="MenuNote" style="display:none;" id="sysDiv"  runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
           <li><a href="M_AddUsersInfo.aspx" target="main">添加管理员</a></li>
             <li><a href="M_UsersList.aspx" target="main">管理员列表</a></li>           
            </ul>
        </div> -->


        <asp:HiddenField ID="Hvalue" runat="server" />
    </div>
    </form>
</body>
</html>
