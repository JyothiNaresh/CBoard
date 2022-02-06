<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls, Version=1.0.2.226, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="CreateDynamicTree.aspx.vb" Inherits="CollegeBoard.CreateDynamicTree" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>CreateDynamicTree</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<style type="text/css">BODY { SCROLLBAR-FACE-COLOR: #ebded6; SCROLLBAR-ARROW-COLOR: black }
		    #TreeView1 a:link, #TreeView1 a:hover, #TreeView1 a:visited {
                text-decoration:none !important;
		    }
		</style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<%--<iewc:TreeView id="TreeView1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server"
				DefaultStyle="font-family:VERDANA;color:#B8773D;font-size:9;font-weight:bold;" SelectedStyle="color:#3333cc;background-color:#FFFFFF;"
				ExpandLevel="1" SelectExpands="True"></iewc:TreeView>--%>
            <iewc:treeview id="TreeView1" runat="server" ExpandLevel="1" EnableViewState="true" accessKey="N" SelectExpands="True" BackColor="Transparent" 
DefaultStyle="font-family:VERDANA;color:#045373;font-size:11;font-weight:BOLD;"
SelectedStyle="color:#ffffff;background-color:#045373;" style="Z-INDEX: 102; LEFT: 0px; POSITION: absolute; TOP: 9px;text-decoration: none;" HoverStyle="border=solid 1px;color=white;background:black;font-size=12;font-weight:bold;text-decoration: none" 
ShowLines="true" ShowToolTip="true"></iewc:treeview>

		</form>
	</body>
</HTML>
