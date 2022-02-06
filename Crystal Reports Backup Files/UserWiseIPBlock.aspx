<%@ Page Language="vb" AutoEventWireup="false" Codebehind="UserWiseIPBlock.aspx.vb" Inherits="CollegeBoard.UserWiseIPBlock" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>UserWiseIPBlock</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../Images/Login/StyleSheet_Report.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 957px; POSITION: absolute; TOP: 8px; HEIGHT: 536px"
				cellSpacing="0" cellPadding="1" width="957" align="center" border="0">
				<TR>
					<TD vAlign="top" nowrap="nowrap" align="center">
						<TABLE id="Table2" style="WIDTH: 281px; HEIGHT: 112px" cellSpacing="0" cellPadding="1"
							width="281" border="0">
							<TR>
								<TD vAlign="middle" nowrap="nowrap" align="center">
									<TABLE id="Table3" style="WIDTH: 278px; HEIGHT: 80px" cellSpacing="0" cellPadding="1" width="278"
										border="1">
										<TR>
											<TD style="HEIGHT: 7px" nowrap="nowrap" colSpan="2"><asp:label id="Label1" runat="server" Width="100%" CssClass="SubHeading1">User&nbsp;IP&nbsp;Block</asp:label></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 7px" nowrap="nowrap"><asp:label id="Label2" runat="server" Width="100%" CssClass="Lables">Adm/Exam</asp:label></TD>
											<TD style="HEIGHT: 7px" nowrap="nowrap"><asp:dropdownlist id="drpAdmExam" runat="server" Width="196px" CssClass="DropDownList" AutoPostBack="True">
													<asp:ListItem Value="A">Admissions</asp:ListItem>
													<asp:ListItem Value="E">Examination</asp:ListItem>
												</asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD nowrap="nowrap"><asp:label id="Label3" runat="server" Width="100%" CssClass="Lables">User&nbsp;Name</asp:label></TD>
											<TD nowrap="nowrap"><asp:dropdownlist id="DrpUser" runat="server" Width="196px" CssClass="DropDownList"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD nowrap="nowrap"><asp:label id="Label11" runat="server" Width="100%" CssClass="Lables">IP&nbsp;Address</asp:label></TD>
											<TD nowrap="nowrap"><asp:textbox id="txtIP" runat="server" Width="196px" CssClass="Textbox" MaxLength="15"></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD vAlign="middle" nowrap="nowrap" align="right"><asp:imagebutton id="ibtnSave" accessKey="S" runat="server" Width="80px" CssClass="button" Height="20px"
										ImageUrl="../../../Images/NewImages/save.gif"></asp:imagebutton>&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
