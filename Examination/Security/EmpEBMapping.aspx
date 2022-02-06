<%@ Page Language="vb" AutoEventWireup="false" Codebehind="EmpEBMapping.aspx.vb" Inherits="CollegeBoard.EmpEBMapping" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>:: :: </title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK id="Link1" href="../../Images/Login/StyleSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body background="../Images/NewImages/innerpage-bg1.jpg" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="0"
				cellPadding="1" width="100%" border="0">
				<TR>
					<TD vAlign="top" align="center">
						<TABLE id="Table2" cellSpacing="0" cellPadding="1" width="714" align="center" border="1">
							<TR>
								<TD vAlign="top" nowrap="nowrap" align="center">
									<TABLE id="Table1" borderColor="activeborder" cellSpacing="1" cellPadding="1" width="714"
										align="center" border="0">
										<TR>
											<TD vAlign="middle" align="center"><asp:label id="Label1" runat="server" Font-Bold="True" CssClass="SubHeading1" Width="100%">View All Users</asp:label></TD>
										</TR>
										<TR>
											<TD vAlign="middle" align="center">
												<TABLE id="Table4" cellSpacing="0" cellPadding="1" width="300" border="0">
													<TR>
														<TD style="WIDTH: 100px; HEIGHT: 21px" nowrap="nowrap"><asp:label id="Label6" runat="server" CssClass="Lables" Width="100%">Academic Year</asp:label></TD>
														<TD style="HEIGHT: 21px" nowrap="nowrap"><asp:dropdownlist id="drpAcaSlno" runat="server" CssClass="DropDownList" Width="153px" AutoPostBack="True"></asp:dropdownlist></TD>
														<TD style="HEIGHT: 21px" nowrap="nowrap"><asp:label id="Label2" runat="server" CssClass="Lables" Width="100%">Exam&nbspBranch&nbsp;*</asp:label></TD>
														<TD style="HEIGHT: 21px" nowrap="nowrap"><asp:dropdownlist id="DrpExamBranch" runat="server" CssClass="DropDownList" Width="153px" AutoPostBack="True"></asp:dropdownlist></TD>
														<TD style="HEIGHT: 21px" nowrap="nowrap"></TD>
													</TR>
													<TR>
														<TD style="WIDTH: 100px; HEIGHT: 15px" nowrap="nowrap"><asp:label id="Label4" runat="server" CssClass="Lables" Width="100%">User&nbsp;Types&nbsp;*</asp:label></TD>
														<TD style="HEIGHT: 15px" nowrap="nowrap"><asp:dropdownlist id="DrpUserTypes" runat="server" CssClass="DropDownList" Width="153px" AutoPostBack="True"></asp:dropdownlist></TD>
														<TD style="HEIGHT: 15px" nowrap="nowrap"><asp:label id="Label11" runat="server" CssClass="Lables" Width="100%">Department</asp:label></TD>
														<TD style="HEIGHT: 15px" nowrap="nowrap"><asp:dropdownlist id="DrpDepartment" runat="server" CssClass=" " Width="156px" AutoPostBack="True"></asp:dropdownlist></TD>
														<TD style="HEIGHT: 15px" nowrap="nowrap"></TD>
													</TR>
													<TR>
														<TD style="WIDTH: 100px" nowrap="nowrap"><asp:label id="Label5" runat="server" CssClass="Lables" Width="100%">Designation</asp:label></TD>
														<TD nowrap="nowrap"><asp:dropdownlist id="DrpDesignation" runat="server" CssClass=" " Width="156px" AutoPostBack="True"></asp:dropdownlist></TD>
														<TD nowrap="nowrap"></TD>
														<TD nowrap="nowrap"></TD>
														<TD nowrap="nowrap"></TD>
													</TR>
													<TR>
														<TD style="WIDTH: 100px" nowrap="nowrap"><asp:label id="Label10" runat="server" CssClass="Lables" Width="100%" Height="16px">Employees&nbsp;*</asp:label></TD>
														<TD nowrap="nowrap" colSpan="3"><asp:dropdownlist id="DrpEmployees" runat="server" CssClass="DropDownList" Width="597px" AutoPostBack="True"></asp:dropdownlist></TD>
														<TD nowrap="nowrap"></TD>
													</TR>
													<TR>
														<TD style="WIDTH: 100px" nowrap="nowrap"><asp:label id="Label3" runat="server" CssClass="Lables" Width="100%" Height="16px">Users&nbsp;*</asp:label></TD>
														<TD nowrap="nowrap" colSpan="3"><asp:dropdownlist id="DrpUser" runat="server" CssClass="DropDownList" Width="384px" AutoPostBack="True"></asp:dropdownlist></TD>
														<TD nowrap="nowrap"></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD vAlign="top" align="center"></TD>
										</TR>
										<TR>
											<TD vAlign="top" align="center"><asp:imagebutton id="ibtnSingle" accessKey="S" runat="server" Width="80px" Height="20px" ImageUrl="../../Images/NewImages/save.gif"
													AlternateText="Single"></asp:imagebutton><asp:imagebutton id="iBtnBatchUpdate" accessKey="C" runat="server" Width="80px" Height="20px" ImageUrl="../../Images/NewImages/cancel.gif"
													AlternateText="Batch Update"></asp:imagebutton>&nbsp;</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
