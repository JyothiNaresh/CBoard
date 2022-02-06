<%@ Page Language="vb" AutoEventWireup="false" Codebehind="UserWiseSubbatchPermisionSingle.aspx.vb" Inherits="CollegeBoard.UserWiseSubbatchPermisionSingle" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>UserWiseSubbatchPermisionSingle</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK id="Link2" href="../../Images/Login/StyleSheet_Report.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body background="../Images/NewImages/innerpage-bg1.jpg" MS_POSITIONING="GridLayout">
		<form id="Form2" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 102; POSITION: absolute; TOP: 8px; LEFT: 8px" cellSpacing="0"
				cellPadding="1" width="100%" border="0">
				<TR>
					<TD vAlign="top" align="center">
						<TABLE id="Table4" cellSpacing="0" cellPadding="1" align="center" border="1">
							<TR>
								<TD vAlign="baseline" nowrap="nowrap" align="center">
									<TABLE id="Table2" cellSpacing="0" cellPadding="1" align="center" border="0">
										<TR>
											<TD vAlign="middle" align="center"><asp:label id="lblHeading" runat="server" CssClass="SubHeading1" Width="100%">User Wise Subbatch Permission(Single)</asp:label></TD>
										</TR>
										<TR>
											<TD vAlign="top" align="center">
												<TABLE id="Table3" cellSpacing="0" cellPadding="1" width="300" border="0">
													<TR>
														<TD nowrap="nowrap"><asp:label id="Label5" runat="server" CssClass="Lables" Width="110px" Visible="False">User&nbsp;Types&nbsp;*</asp:label></TD>
														<TD nowrap="nowrap"><asp:dropdownlist id="DrpUserTypes" runat="server" CssClass="DropDownList" Width="153px" Visible="False"></asp:dropdownlist></TD>
														<TD nowrap="nowrap"><asp:label id="Label6" runat="server" CssClass="Lables" Width="120px">Academic Year</asp:label></TD>
														<TD nowrap="nowrap"><asp:dropdownlist id="drpAcaSlno" runat="server" CssClass="DropDownList" Width="153px"></asp:dropdownlist></TD>
														<TD nowrap="nowrap"><asp:imagebutton id="iBtnSearch" accessKey="E" runat="server" Width="80px" Height="20px" ImageUrl="../../Images/NewImages/search.gif"></asp:imagebutton></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD vAlign="top" align="center">
												<TABLE id="Table5" style="WIDTH: 410px; HEIGHT: 19px" cellSpacing="0" cellPadding="0" width="410"
													border="0">
													<TR>
														<TD style="WIDTH: 64px"><asp:label id="lblCourse" runat="server" CssClass="Lables" Width="100%">Course&nbsp;*</asp:label></TD>
														<TD style="WIDTH: 136px"><asp:dropdownlist id="drpCourse" runat="server" CssClass="Lables" Width="153px" AutoPostBack="True"></asp:dropdownlist></TD>
														<TD style="WIDTH: 6px"><asp:label id="lblGroup" runat="server" CssClass="Lables" Width="24px">Group&nbsp;*</asp:label></TD>
														<TD><asp:dropdownlist id="drpGroup" runat="server" CssClass="Lables" Width="153px" AutoPostBack="True"></asp:dropdownlist></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD></HR>
											</TD>
										</TR>
										<TR>
											<TD vAlign="middle" align="center">
												<TABLE id="TblBatch" style="WIDTH: 544px; HEIGHT: 24px" cellSpacing="0" cellPadding="0"
													width="544" border="0" runat="server">
													<TR>
														<TD align="center"><b>Batch
																<asp:checkbox id="ChkCheckbatch" runat="server" CssClass="Lables" AutoPostBack="True" Text="Check/Uncheck"></asp:checkbox></b></TD>
													</TR>
													<TR>
														<TD align="center"><br>
														</TD>
													</TR>
													<TR>
														<TD vAlign="middle" align="center"><asp:checkboxlist id="ChkBatches" runat="server" CssClass="Lables" Width="542px" RepeatColumns="5"></asp:checkboxlist></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 24px" vAlign="middle" align="center">
												&nbsp;
												<asp:imagebutton id="ibtnSBSearch" accessKey="E" runat="server" Width="80px" Height="20px" ImageUrl="../../Images/NewImages/search.gif"></asp:imagebutton></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 24px" vAlign="middle" align="center"><b></b></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 24px" vAlign="middle" align="center">
												<TABLE id="TblSubbatch" cellSpacing="0" cellPadding="0" width="300" border="0" runat="server">
													<TR>
														<TD align="center"><B>SubBatch
																<asp:checkbox id="ChkCheckSubbatch" runat="server" CssClass="Lables" AutoPostBack="True" Text="Check/Uncheck"></asp:checkbox></B></TD>
													</TR>
													<TR>
														<TD align="center"><br>
														</TD>
													</TR>
													<TR>
														<TD><asp:checkboxlist id="ChkSubbatches" runat="server" CssClass="Lables" Width="542px" RepeatColumns="5"></asp:checkboxlist></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 24px" vAlign="middle" align="center"></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 24px" vAlign="middle" align="center"></TD>
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
