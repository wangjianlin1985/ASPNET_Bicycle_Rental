<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontList.aspx.cs" Inherits="CarRent_frontList" %>
<%@ Register Src="../header.ascx" TagName="header" TagPrefix="uc" %>
<%@ Register Src="../footer.ascx" TagName="footer" TagPrefix="uc" %>
<%
    String path = Request.ApplicationPath;
    String basePath = path + "/"; 
%>
<!DOCTYPE html>
<html>
<head>
<meta charset="utf-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1 , user-scalable=no">
<title>租车查询</title>
<link href="<%=basePath %>plugins/bootstrap.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-dashen.css" rel="stylesheet">
<link href="<%=basePath %>plugins/font-awesome.css" rel="stylesheet">
<link href="<%=basePath %>plugins/animate.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-datetimepicker.min.css" rel="stylesheet" media="screen">
</head>
<body style="margin-top:70px;">
<div class="container">
<uc:header ID="header" runat="server" />
 <form id="form2" runat="server">
	<div class="row"> 
		<div class="col-md-9 wow fadeInDown" data-wow-duration="0.5s">
			<div>
				<!-- Nav tabs -->
				<ul class="nav nav-tabs" role="tablist">
			    	<li><a href="../index.aspx">首页</a></li>
			    	<li role="presentation" class="active"><a href="#carRentListPanel" aria-controls="carRentListPanel" role="tab" data-toggle="tab">租车列表</a></li>
			    	<li role="presentation" ><a href="frontAdd.aspx" style="display:none;">添加租车</a></li>
				</ul>
			  	<!-- Tab panes -->
			  	<div class="tab-content">
				    <div role="tabpanel" class="tab-pane active" id="carRentListPanel">
				    		<div class="row">
				    			<div class="col-md-12 top5">
				    				<div class="table-responsive">
				    				<table class="table table-condensed table-hover">
				    					<tr class="success bold"><td>序号</td><td>出租编号</td><td>出租自行车</td><td>租车用户</td><td>租车开始时间</td><td>还车时间</td><td>租金</td><td>操作</td></tr>
				    					<asp:Repeater ID="RpCarRent" runat="server">
 										<ItemTemplate>
 										<tr>
 											<td><%#(Container.ItemIndex + 1)%></td>
 											<td><%#Eval("rentId")%></td>
 											<td><%#GetCarInfocarObj(Eval("carObj").ToString())%></td>
 											<td><%#GetUserInfouserObj(Eval("userObj").ToString())%></td>
 											<td><%#Eval("rentTime")%></td>
 											<td><%#Eval("returnTime")%></td>
 											<td><%#Eval("rentMoney")%></td>
 											<td>
 												<a href="frontshow.aspx?rentId=<%#Eval("rentId")%>"><i class="fa fa-info"></i>&nbsp;查看</a>&nbsp;
 												<a href="#" onclick="carRentEdit('<%#Eval("rentId")%>');" style="display:none;"><i class="fa fa-pencil fa-fw"></i>编辑</a>&nbsp;
 												<a href="#" onclick="carRentDelete('<%#Eval("rentId")%>');" style="display:none;"><i class="fa fa-trash-o fa-fw"></i>删除</a>
 											</td> 
 										</tr>
 										</ItemTemplate>
 										</asp:Repeater>
				    				</table>
				    				</div>
				    			</div>
				    		</div>

				    		<div class="row">
					            <div class="col-md-12">
						            <nav class="pull-left">
						                <ul class="pagination">
						                    <asp:LinkButton ID="LBHome" runat="server" CssClass="pageBtn"
						                      onclick="LBHome_Click">[首页]</asp:LinkButton>
						                    <asp:LinkButton ID="LBUp" runat="server" CssClass="pageBtn" 
						                      onclick="LBUp_Click">[上一页]</asp:LinkButton>
						                    <asp:LinkButton ID="LBNext" runat="server" CssClass="pageBtn"
						                      onclick="LBNext_Click">[下一页]</asp:LinkButton>
						                    <asp:LinkButton ID="LBEnd" runat="server" CssClass="pageBtn"
						                      onclick="LBEnd_Click">[尾页]</asp:LinkButton>
						                    <asp:HiddenField ID="HSelectID" runat="server" Value=""/>
						                    <asp:HiddenField ID="HWhere" runat="server" Value=""/>
						                    <asp:HiddenField ID="HNowPage" runat="server" Value="1"/>
						                    <asp:HiddenField ID="HPageSize" runat="server" Value="8"/>
						                    <asp:HiddenField ID="HAllPage" runat="server" Value="0"/>
						                </ul>
						            </nav>
						            <div class="pull-right" style="line-height:75px;" ><asp:Label runat="server" ID="PageMes"></asp:Label></div>
					            </div>
				            </div> 
				    </div>
				</div>
			</div>
		</div>
	<div class="col-md-3 wow fadeInRight">
		<div class="page-header">
    		<h1>租车查询</h1>
		</div>
            <div class="form-group">
            	<label for="carObj_rentId">出租自行车：</label>
                <asp:DropDownList ID="carObj" runat="server"  CssClass="form-control" placeholder="请选择出租自行车"></asp:DropDownList>
            </div>
            <div class="form-group">
            	<label for="userObj_rentId">租车用户：</label>
                <asp:DropDownList ID="userObj" runat="server"  CssClass="form-control" placeholder="请选择租车用户"></asp:DropDownList>
            </div>
			<div class="form-group">
				<label for="rentTime">租车开始时间:</label>
				<asp:TextBox ID="rentTime"  runat="server" CssClass="form-control" placeholder="请选择租车开始时间" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="returnTime">还车时间:</label>
				<asp:TextBox ID="returnTime" runat="server"  CssClass="form-control" placeholder="请输入还车时间"></asp:TextBox>
			</div>
            <input type=hidden name=currentPage value="" />
            <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="查询" onclick="btnSearch_Click" />
	</div>

	</div>
 </form>
</div> 
<div id="carRentEditDialog" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title"><i class="fa fa-edit"></i>&nbsp;租车信息编辑</h4>
      </div>
      <div class="modal-body" style="height:450px; overflow: scroll;">
      	<form class="form-horizontal" name="carRentEditForm" id="carRentEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="carRent_rentId_edit" class="col-md-3 text-right">出租编号:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="carRent_rentId_edit" name="carRent.rentId" class="form-control" placeholder="请输入出租编号" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="carRent_carObj_chepaiNo_edit" class="col-md-3 text-right">出租自行车:</label>
		  	 <div class="col-md-9">
			    <select id="carRent_carObj_chepaiNo_edit" name="carRent.carObj.chepaiNo" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="carRent_userObj_user_name_edit" class="col-md-3 text-right">租车用户:</label>
		  	 <div class="col-md-9">
			    <select id="carRent_userObj_user_name_edit" name="carRent.userObj.user_name" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="carRent_rentTime_edit" class="col-md-3 text-right">租车开始时间:</label>
		  	 <div class="col-md-9">
                <div class="input-group date carRent_rentTime_edit col-md-12" data-link-field="carRent_rentTime_edit">
                    <input class="form-control" id="carRent_rentTime_edit" name="carRent.rentTime" size="16" type="text" value="" placeholder="请选择租车开始时间" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="carRent_returnTime_edit" class="col-md-3 text-right">还车时间:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="carRent_returnTime_edit" name="carRent.returnTime" class="form-control" placeholder="请输入还车时间">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="carRent_rentMoney_edit" class="col-md-3 text-right">租金:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="carRent_rentMoney_edit" name="carRent.rentMoney" class="form-control" placeholder="请输入租金">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="carRent_rentMemo_edit" class="col-md-3 text-right">备注信息:</label>
		  	 <div class="col-md-9">
			    <textarea id="carRent_rentMemo_edit" name="carRent.rentMemo" rows="8" class="form-control" placeholder="请输入备注信息"></textarea>
			 </div>
		  </div>
		</form> 
	    <style>#carRentEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
      <div class="modal-footer"> 
      	<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
      	<button type="button" class="btn btn-primary" onclick="ajaxCarRentModify();">提交</button>
      </div>
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->
<uc:footer ID="footer" runat="server" />
<script src="<%=basePath %>plugins/jquery.min.js"></script>
<script src="<%=basePath %>plugins/bootstrap.js"></script>
<script src="<%=basePath %>plugins/wow.min.js"></script>
<script src="<%=basePath %>plugins/bootstrap-datetimepicker.min.js"></script>
<script src="<%=basePath %>plugins/locales/bootstrap-datetimepicker.zh-CN.js"></script>
<script type="text/javascript" src="<%=basePath %>js/jsdate.js"></script>
<script>
var basePath = "<%=basePath%>";
/*弹出修改租车界面并初始化数据*/
function carRentEdit(rentId) {
	$.ajax({
		url :  basePath + "CarRent/CarRentController.aspx?action=getCarRent&rentId=" + rentId,
		type : "get",
		dataType: "json",
		success : function (carRent, response, status) {
			if (carRent) {
				$("#carRent_rentId_edit").val(carRent.rentId);
				$.ajax({
					url: basePath + "CarInfo/CarInfoController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(carInfos,response,status) { 
						$("#carRent_carObj_chepaiNo_edit").empty();
						var html="";
		        		$(carInfos).each(function(i,carInfo){
		        			html += "<option value='" + carInfo.chepaiNo + "'>" + carInfo.carName + "</option>";
		        		});
		        		$("#carRent_carObj_chepaiNo_edit").html(html);
		        		$("#carRent_carObj_chepaiNo_edit").val(carRent.carObjPri);
					}
				});
				$.ajax({
					url: basePath + "UserInfo/UserInfoController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(userInfos,response,status) { 
						$("#carRent_userObj_user_name_edit").empty();
						var html="";
		        		$(userInfos).each(function(i,userInfo){
		        			html += "<option value='" + userInfo.user_name + "'>" + userInfo.name + "</option>";
		        		});
		        		$("#carRent_userObj_user_name_edit").html(html);
		        		$("#carRent_userObj_user_name_edit").val(carRent.userObjPri);
					}
				});
				$("#carRent_rentTime_edit").val(carRent.rentTime);
				$("#carRent_returnTime_edit").val(carRent.returnTime);
				$("#carRent_rentMoney_edit").val(carRent.rentMoney);
				$("#carRent_rentMemo_edit").val(carRent.rentMemo);
				$('#carRentEditDialog').modal('show');
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*删除租车信息*/
function carRentDelete(rentId) {
	if(confirm("确认删除这个记录")) {
		$.ajax({
			type : "POST",
			url : basePath + "CarRent/CarRentController.aspx?action=delete",
			data : {
				rentId : rentId,
			},
			dataType: "json",
			success : function (obj) {
				if (obj.success) {
					alert("删除成功");
					$("#btnSearch").click();
					//location.href= basePath + "CarRent/frontList.aspx";
				}
				else 
					alert(obj.message);
			},
		});
	}
}

/*ajax方式提交租车信息表单给服务器端修改*/
function ajaxCarRentModify() {
	$.ajax({
		url :  basePath + "CarRent/CarRentController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#carRentEditForm")[0]),
		success : function (obj, response, status) {
            if(obj.success){
                alert("信息修改成功！");
                $("#btnSearch").click();
            }else{
                alert(obj.message);
            } 
		},
		processData: false,
		contentType: false,
	});
}

$(function(){
	/*小屏幕导航点击关闭菜单*/
    $('.navbar-collapse a').click(function(){
        $('.navbar-collapse').collapse('hide');
    });
    new WOW().init();

    /*租车开始时间组件*/
    $('.carRent_rentTime_edit').datetimepicker({
    	language:  'zh-CN',  //语言
    	format: 'yyyy-mm-dd hh:ii:ss',
    	weekStart: 1,
    	todayBtn:  1,
    	autoclose: 1,
    	minuteStep: 1,
    	todayHighlight: 1,
    	startView: 2,
    	forceParse: 0
    });
})
</script>
</body>
</html>

