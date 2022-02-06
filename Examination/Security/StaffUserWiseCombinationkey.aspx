<%@ Page Language="vb" AutoEventWireup="false" Codebehind="StaffUserWiseCombinationkey.aspx.vb" Inherits="CollegeBoard.StaffUserWiseCombinationkey"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>:: User Wise Combination Key :: </title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK id="Link2" href="../../Images/Login/StyleSheet_Report.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body background="../Images/NewImages/innerpage-bg1.jpg" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="0"
				cellPadding="1" width="100%" border="0">
				<TR>
					<TD vAlign="top" align="center">
						<TABLE id="Table4" style="WIDTH: 874px; HEIGHT: 331px" cellSpacing="0" cellPadding="1"
							width="874" align="center" border="1">
							<TR>
								<TD vAlign="baseline" nowrap="nowrap" align="center">
									<TABLE id="Table2" style="WIDTH: 881px; HEIGHT: 312px" cellSpacing="0" cellPadding="1"
										width="881" align="center" border="0">
										<TR>
											<TD vAlign="middle" align="center"><asp:label id="lblHeading" runat="server" CssClass="SubHeading1" Width="100%">User Wise Staff Combination Key</asp:label></TD>
										</TR>
										<TR>
											<TD vAlign="middle" align="center">
												<TABLE id="Table3" cellSpacing="0" cellPadding="1" width="300" border="0">
													<TR>
														<TD nowrap="nowrap"><asp:label id="Label5" runat="server" CssClass="Lables" Width="110px">User&nbsp;Types&nbsp;*</asp:label></TD>
														<TD nowrap="nowrap"><asp:dropdownlist id="DrpUserTypes" runat="server" CssClass="DropDownList" Width="153px"></asp:dropdownlist></TD>
														<TD nowrap="nowrap"><asp:label id="Label6" runat="server" CssClass="Lables" Width="120px">Academic Year</asp:label></TD>
														<TD nowrap="nowrap"><asp:dropdownlist id="drpAcaSlno" runat="server" CssClass="DropDownList" Width="153px"></asp:dropdownlist></TD>
														<TD nowrap="nowrap"><asp:imagebutton id="iBtnSearch" accessKey="E" runat="server" Width="80px" Height="20px" ImageUrl="../../Images/NewImages/search.gif"></asp:imagebutton></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD vAlign="middle" align="center">
												<HR width="100%" SIZE="1">
											</TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 24px" vAlign="middle" align="center"><asp:checkbox id="chkUser" runat="server" CssClass="Lables" AutoPostBack="True" Text="Users"></asp:checkbox></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 24px" vAlign="middle" align="center"><asp:checkboxlist id="chklStuType" runat="server" CssClass="Lables" Width="542px" RepeatColumns="5"></asp:checkboxlist></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 24px" vAlign="middle" align="center">
												<HR width="100%" SIZE="1">
											</TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 24px" vAlign="middle" align="center"><asp:checkbox id="chkBranchs" runat="server" CssClass="Lables" AutoPostBack="True" Text="Combination Keys"></asp:checkbox></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 24px" vAlign="middle" align="center"><asp:checkboxlist id="chklBranch" runat="server" CssClass="Lables" RepeatColumns="4"></asp:checkboxlist></TD>
										</TR>
										<TR>
											<TD vAlign="middle" align="right"><asp:imagebutton id="ibtSave" accessKey="S" runat="server" CssClass="button" Width="80px" Height="20px"
													ImageUrl="../../Images/NewImages/save.gif" AlternateText="Save"></asp:imagebutton>&nbsp;&nbsp;
												<asp:imagebutton id="ibtnCancel" accessKey="C" runat="server" CssClass="button" Width="80px" Height="20px"
													ImageUrl="../../Images/NewImages/cancel.gif" AlternateText="Cancel"></asp:imagebutton></TD>
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
