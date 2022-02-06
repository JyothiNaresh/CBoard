<%@ Page Language="vb" AutoEventWireup="false" Codebehind="UserDetailsPopUp.aspx.vb" Inherits="CollegeBoard.UserDetailsPopUp" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>UserDetailsPopUp</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../Styles/StyleSheet_ASR.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 16px; WIDTH: 505px; POSITION: absolute; TOP: 32px; HEIGHT: 72px"
				cellSpacing="0" cellPadding="1" width="505" align="center" border="0">
				<TR>
					<TD vAlign="baseline" nowrap="nowrap" align="center"></TD>
				</TR>
				<TR>
					<TD vAlign="baseline" nowrap="nowrap" align="center">
						<asp:table id="tabDetails" runat="server" GridLines="Both" CellPadding="4" CellSpacing="0"
							Width="416px" BorderWidth="1px"></asp:table>
						<asp:label id="lblnote" runat="server" CssClass="Lables" Width="443px" Visible="False"></asp:label></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
