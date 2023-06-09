<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontList.aspx.cs" Inherits="CarInfo_frontList" %>
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
<title>自行车信息查询</title>
<link href="<%=basePath %>plugins/bootstrap.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-dashen.css" rel="stylesheet">
<link href="<%=basePath %>plugins/font-awesome.css" rel="stylesheet">
<link href="<%=basePath %>plugins/animate.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-datetimepicker.min.css" rel="stylesheet" media="screen">
</head>
<body style="margin-top:70px;">
<div class="container">
<uc:header ID="header" runat="server" />
 <form id="form1" runat="server">
	<div class="col-md-9 wow fadeInLeft">
		<ul class="breadcrumb">
  			<li><a href="../index.aspx">首页</a></li>
  			<li><a href="frontList.aspx">自行车信息信息列表</a></li>
  			<li class="active">查询结果显示</li>
  			<a class="pull-right" href="frontAdd.aspx" style="display:none;">添加自行车信息</a>
		</ul>
		<div class="row">
			<asp:Repeater ID="RpCarInfo" runat="server">
			<ItemTemplate>
			<div class="col-md-3 bottom15" <%#(((Container.ItemIndex+0)%4==0)?"style='clear:left;'":"") %>>
			  <a href="frontshow.aspx?chepaiNo=<%#Eval("chepaiNo")%>"><img class="img-responsive" src="../<%#Eval("carPhoto")%>" /></a>
			     <div class="showFields">
			     	<div class="field">
	            		车牌号码: <%#Eval("chepaiNo")%>
			     	</div>
			     	<div class="field">
	            		型号: <%#Eval("serialNo")%>
			     	</div>
			     	<div class="field">
	            		自行车名称: <%#Eval("carName")%>
			     	</div>
			     	<div class="field">
	            		颜色:<%#GetColorcolorObj(Eval("colorObj").ToString())%>
			     	</div>
			     	<div class="field">
	            		启动方式:<%#GetShiftWayshiftWayObj(Eval("shiftWayObj").ToString())%>
			     	</div>
			     	<div class="field">
	            		每小时单价: <%#Eval("price")%>
			     	</div>
			     	<div class="field">
	            		出厂日期: <%#Eval("outDate")%>
			     	</div>
			     	<div class="field">
	            		出租状态:<%#GetRentStaterentStateObj(Eval("rentStateObj").ToString())%>
			     	</div>
			        <a class="btn btn-primary top5" href="frontShow.aspx?chepaiNo=<%#Eval("chepaiNo")%>">详情</a>
			        <a class="btn btn-primary top5" onclick="carInfoEdit('<%#Eval("chepaiNo")%>');" style="display:none;">修改</a>
			        <a class="btn btn-primary top5" onclick="carInfoDelete('<%#Eval("chepaiNo")%>');" style="display:none;">删除</a>
			     </div>
			</div>
			</ItemTemplate>
			</asp:Repeater>

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

	<div class="col-md-3 wow fadeInRight">
		<div class="page-header">
    		<h1>自行车信息查询</h1>
		</div>
			<div class="form-group">
				<label for="chepaiNo">车牌号码:</label>
				<asp:TextBox ID="chepaiNo" runat="server"  CssClass="form-control" placeholder="请输入车牌号码"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="carName">自行车名称:</label>
				<asp:TextBox ID="carName" runat="server"  CssClass="form-control" placeholder="请输入自行车名称"></asp:TextBox>
			</div>
            <div class="form-group">
            	<label for="colorObj_colorId">颜色：</label>
                <asp:DropDownList ID="colorObj" runat="server"  CssClass="form-control" placeholder="请选择颜色"></asp:DropDownList>
            </div>
            <div class="form-group">
            	<label for="shiftWayObj_shitWayId">启动方式：</label>
                <asp:DropDownList ID="shiftWayObj" runat="server"  CssClass="form-control" placeholder="请选择启动方式"></asp:DropDownList>
            </div>
			<div class="form-group">
				<label for="outDate">出厂日期:</label>
				<asp:TextBox ID="outDate"  runat="server" CssClass="form-control" placeholder="请选择出厂日期" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>
			</div>
            <div class="form-group">
            	<label for="rentStateObj_stateId">出租状态：</label>
                <asp:DropDownList ID="rentStateObj" runat="server"  CssClass="form-control" placeholder="请选择出租状态"></asp:DropDownList>
            </div>
        <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="查询" onclick="btnSearch_Click" />
	</div>
  </form>
</div>
<div id="carInfoEditDialog" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title"><i class="fa fa-edit"></i>&nbsp;自行车信息信息编辑</h4>
      </div>
      <div class="modal-body" style="height:450px; overflow: scroll;">
      	<form class="form-horizontal" name="carInfoEditForm" id="carInfoEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="carInfo_chepaiNo_edit" class="col-md-3 text-right">车牌号码:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="carInfo_chepaiNo_edit" name="carInfo.chepaiNo" class="form-control" placeholder="请输入车牌号码" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="carInfo_serialNo_edit" class="col-md-3 text-right">型号:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="carInfo_serialNo_edit" name="carInfo.serialNo" class="form-control" placeholder="请输入型号">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="carInfo_carName_edit" class="col-md-3 text-right">自行车名称:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="carInfo_carName_edit" name="carInfo.carName" class="form-control" placeholder="请输入自行车名称">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="carInfo_colorObj_colorId_edit" class="col-md-3 text-right">颜色:</label>
		  	 <div class="col-md-9">
			    <select id="carInfo_colorObj_colorId_edit" name="carInfo.colorObj.colorId" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="carInfo_shiftWayObj_shitWayId_edit" class="col-md-3 text-right">启动方式:</label>
		  	 <div class="col-md-9">
			    <select id="carInfo_shiftWayObj_shitWayId_edit" name="carInfo.shiftWayObj.shitWayId" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="carInfo_price_edit" class="col-md-3 text-right">每小时单价:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="carInfo_price_edit" name="carInfo.price" class="form-control" placeholder="请输入每小时单价">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="carInfo_outDate_edit" class="col-md-3 text-right">出厂日期:</label>
		  	 <div class="col-md-9">
                <div class="input-group date carInfo_outDate_edit col-md-12" data-link-field="carInfo_outDate_edit" data-link-format="yyyy-mm-dd">
                    <input class="form-control" id="carInfo_outDate_edit" name="carInfo.outDate" size="16" type="text" value="" placeholder="请选择出厂日期" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="carInfo_makeAddress_edit" class="col-md-3 text-right">厂家地址:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="carInfo_makeAddress_edit" name="carInfo.makeAddress" class="form-control" placeholder="请输入厂家地址">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="carInfo_carPhoto_edit" class="col-md-3 text-right">自行车图片:</label>
		  	 <div class="col-md-9">
			    <img  class="img-responsive" id="carInfo_carPhotoImg" border="0px"/><br/>
			    <input type="hidden" id="carInfo_carPhoto" name="carInfo.carPhoto"/>
			    <input id="carPhotoFile" name="carPhotoFile" type="file" size="50" />
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="carInfo_cofigParam_edit" class="col-md-3 text-right">参数配置:</label>
		  	 <div class="col-md-9">
			    <textarea id="carInfo_cofigParam_edit" name="carInfo.cofigParam" rows="8" class="form-control" placeholder="请输入参数配置"></textarea>
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="carInfo_rentStateObj_stateId_edit" class="col-md-3 text-right">出租状态:</label>
		  	 <div class="col-md-9">
			    <select id="carInfo_rentStateObj_stateId_edit" name="carInfo.rentStateObj.stateId" class="form-control">
			    </select>
		  	 </div>
		  </div>
		</form> 
	    <style>#carInfoEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
      <div class="modal-footer"> 
      	<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
      	<button type="button" class="btn btn-primary" onclick="ajaxCarInfoModify();">提交</button>
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
/*弹出修改自行车信息界面并初始化数据*/
function carInfoEdit(chepaiNo) {
	$.ajax({
		url :  basePath + "CarInfo/CarInfoController.aspx?action=getCarInfo&chepaiNo=" + chepaiNo,
		type : "get",
		dataType: "json",
		success : function (carInfo, response, status) {
			if (carInfo) {
				$("#carInfo_chepaiNo_edit").val(carInfo.chepaiNo);
				$("#carInfo_serialNo_edit").val(carInfo.serialNo);
				$("#carInfo_carName_edit").val(carInfo.carName);
				$.ajax({
					url: basePath + "Color/ColorController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(colors,response,status) { 
						$("#carInfo_colorObj_colorId_edit").empty();
						var html="";
		        		$(colors).each(function(i,color){
		        			html += "<option value='" + color.colorId + "'>" + color.colorName + "</option>";
		        		});
		        		$("#carInfo_colorObj_colorId_edit").html(html);
		        		$("#carInfo_colorObj_colorId_edit").val(carInfo.colorObjPri);
					}
				});
				$.ajax({
					url: basePath + "ShiftWay/ShiftWayController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(shiftWays,response,status) { 
						$("#carInfo_shiftWayObj_shitWayId_edit").empty();
						var html="";
		        		$(shiftWays).each(function(i,shiftWay){
		        			html += "<option value='" + shiftWay.shitWayId + "'>" + shiftWay.shiftName + "</option>";
		        		});
		        		$("#carInfo_shiftWayObj_shitWayId_edit").html(html);
		        		$("#carInfo_shiftWayObj_shitWayId_edit").val(carInfo.shiftWayObjPri);
					}
				});
				$("#carInfo_price_edit").val(carInfo.price);
				$("#carInfo_outDate_edit").val(carInfo.outDate);
				$("#carInfo_makeAddress_edit").val(carInfo.makeAddress);
				$("#carInfo_carPhoto").val(carInfo.carPhoto);
				$("#carInfo_carPhotoImg").attr("src", basePath +　carInfo.carPhoto);
				$("#carInfo_cofigParam_edit").val(carInfo.cofigParam);
				$.ajax({
					url: basePath + "RentState/RentStateController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(rentStates,response,status) { 
						$("#carInfo_rentStateObj_stateId_edit").empty();
						var html="";
		        		$(rentStates).each(function(i,rentState){
		        			html += "<option value='" + rentState.stateId + "'>" + rentState.stateName + "</option>";
		        		});
		        		$("#carInfo_rentStateObj_stateId_edit").html(html);
		        		$("#carInfo_rentStateObj_stateId_edit").val(carInfo.rentStateObjPri);
					}
				});
				$('#carInfoEditDialog').modal('show');
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*删除自行车信息信息*/
function carInfoDelete(chepaiNo) {
	if(confirm("确认删除这个记录")) {
		$.ajax({
			type : "POST",
			url : basePath + "CarInfo/CarInfoController.aspx?action=delete",
			data : {
				chepaiNo : chepaiNo,
			},
			dataType: "json",
			success : function (obj) {
				if (obj.success) {
					alert("删除成功");
                    $("#btnSearch").click();
					//location.href= basePath + "CarInfo/frontList.aspx";
				}
				else 
					alert(obj.message);
			},
		});
	}
}

/*ajax方式提交自行车信息信息表单给服务器端修改*/
function ajaxCarInfoModify() {
	$.ajax({
		url :  basePath + "CarInfo/CarInfoController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#carInfoEditForm")[0]),
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

    /*出厂日期组件*/
    $('.carInfo_outDate_edit').datetimepicker({
    	language:  'zh-CN',  //语言
    	format: 'yyyy-mm-dd',
    	minView: 2,
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

