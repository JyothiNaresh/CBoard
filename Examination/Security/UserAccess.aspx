<%@ Page Language="vb" AutoEventWireup="false" Codebehind="UserAccess.aspx.vb" Inherits="CollegeBoard.UserAccess" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls, Version=1.0.2.226, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>User Permissions</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Images/Login/StyleSheet.css" type="text/css" rel="stylesheet">
		<script language="javascript" type="text/javascript" src="../Include/Report.js"></script>
		<script language="javascript" type="text/javascript">
		function funView()
		{
		document.Form1.TextBox2.value="Y";
		alert(document.Form1.TextBox2.value);
		
		}
		</script>
        <style type="text/css">BODY { SCROLLBAR-FACE-COLOR: #ffffff }
		    #TreeView1 a:link, #TreeView1 a:hover, #TreeView1 a:visited {
                text-decoration:none !important;
		    }
		</style>

	</HEAD>
	<body onload="javascript:ScrollIt()" onscroll="javascript:setcoords()" MS_POSITIONING="GridLayout"
		background="../Images/NewImages/innerpage-bg1.jpg">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="WIDTH: 999px; HEIGHT: 120px" cellSpacing="0" cellPadding="1"
				width="999" border="0">
				<TR>
					<TD vAlign="top" align="center">
						<TABLE id="Table2" style="WIDTH: 277px; HEIGHT: 96px" cellSpacing="0" cellPadding="1" width="277"
							align="center" border="1">
							<TR>
								<TD vAlign="baseline" nowrap="nowrap" align="center">
									<TABLE id="Table1" style="WIDTH: 274px; HEIGHT: 95px" cellSpacing="0" cellPadding="1" width="274"
										align="center" border="0">
										<TR>
											<TD class="Lables" style="HEIGHT: 23px" vAlign="middle" align="center">
												<asp:label id="lblHeading" runat="server" Width="100%" CssClass="SubHeading1">User&nbsp;Permissions</asp:label></TD>
										</TR>
										<TR>
											<TD class="Lables" style="HEIGHT: 23px">
												<asp:Label id="lblUserType" runat="server" CssClass="Lables">User&nbsp;Type&nbsp;*</asp:Label>&nbsp;
												<asp:dropdownlist id="drpUserType" runat="server" Width="180px" CssClass="DropDownList" AutoPostBack="True"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 23px" vAlign="middle" align="right">
												<asp:imagebutton id="iBtnSave" accessKey="S" runat="server" Width="80px" Height="20px" CssClass="button"
													AlternateText="Save" ImageUrl="../../Images/NewImages/save.gif"></asp:imagebutton></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD>
									<input type="hidden" id="PageX" name="PageX" value="0" runat="server"> <input type="hidden" id="PageY" name="PageY" value="0" runat="server">
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			<asp:textbox id="TextBox2" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server"
				Height="0px" Width="0px"></asp:textbox>&nbsp;
			<%--<iewc:treeview id="TreeView1" runat="server" AutoPostBack="True" ShowPlus="False" ShowLines="False"
				DefaultStyle="font-family:VERDANA;color:#B8773D;font-size:10;font-weight:bold;" SelectedStyle="color:#3333cc;background-color:#FFFFFF;"
				style="Z-INDEX: 102; LEFT: 136px; POSITION: absolute; TOP: 136px" ExpandLevel="1"></iewc:treeview>--%>
            <iewc:treeview id="TreeView1" runat="server" ExpandLevel="1" EnableViewState="true" accessKey="N" SelectExpands="True" BackColor="Transparent" 
DefaultStyle="font-family:VERDANA;color:#045373;font-size:11;font-weight:BOLD;"
SelectedStyle="color:#ffffff;background-color:#045373;" style="Z-INDEX: 102; LEFT: 0px; POSITION: absolute; TOP: 9px;text-decoration: none;" HoverStyle="border=solid 1px;color=white;background:black;font-size=12;font-weight:bold;text-decoration: none" 
ShowLines="true" ShowToolTip="true"></iewc:treeview>

		</form>
	</body>
</HTML>
