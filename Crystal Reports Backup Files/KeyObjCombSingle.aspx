<%@ Page Language="vb" AutoEventWireup="false" Codebehind="KeyObjCombSingle.aspx.vb" Inherits="CollegeBoard.KeyObjCombSingle" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>KeyObjCombSingle</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK id="Link2" href="../../Images/Login/StyleSheet_Report.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" autocomplete="off" runat="server">
			<asp:textbox id="txtlblCode" runat="server" Width="0px" Height="32px">XXXXXX</asp:textbox><asp:dropdownlist id="DrpUserTypes" runat="server" CssClass="DropDownList" Width="153px" Visible="False"
				style="Z-INDEX: 101; POSITION: absolute; TOP: 16px; LEFT: 336px"></asp:dropdownlist><asp:label id="Label5" runat="server" CssClass="Lables" Width="110px" Visible="False" style="Z-INDEX: 102; POSITION: absolute; TOP: 16px; LEFT: 544px">User&nbsp;Types&nbsp;*</asp:label>
			<TABLE id="Table0" border="0" cellSpacing="1" cellPadding="1" width="100%">
				<TBODY>
					<TR>
						<TD vAlign="top" align="center">
							<TABLE id="Table1" class="Panel" border="0" cellSpacing="0" cellPadding="0">
								<TR>
									<TD align="center">
										<TABLE id="Table2" border="0" cellSpacing="0" cellPadding="0">
											<TR>
												<TD class="DarkColor">
													<TABLE id="Table3" border="0" cellSpacing="0" cellPadding="0" width="100%">
														<TR>
															<TD vAlign="top" width="11"><IMG src="../../Images/Login/table-lcorw.gif" width="11" height="11"></TD>
															<TD class="SubHeading"><asp:label id="lblHeading" runat="server" Width="100%" CssClass="SubHeading1" Font-Bold="True"> Combinations for Key Objections(Single) </asp:label></TD>
															<TD vAlign="top" width="11"><IMG src="../../Images/Login/table-rcorw.gif" width="11" height="11"></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD class="TdBorder"><IMG src="../../Images/Login/spacer.gif" width="1" height="1"></TD>
											</TR>
											<TR>
												<TD class="TableBorder" vAlign="top" align="center">
													<TABLE id="Table4" cellSpacing="0" cellPadding="1" width="300" border="0">
														<TR>
															<TD nowrap="nowrap"><asp:label id="Label6" runat="server" CssClass="Lables" Width="120px">Academic Year</asp:label></TD>
															<TD nowrap="nowrap"><asp:dropdownlist id="drpAcaSlno" runat="server" CssClass="DropDownList" Width="153px"></asp:dropdownlist></TD>
															<TD nowrap="nowrap"><asp:imagebutton id="iBtnSearch" accessKey="E" runat="server" Width="80px" Height="20px" ImageUrl="../../Images/NewImages/search.gif"></asp:imagebutton></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 24px" vAlign="middle" align="center"><asp:checkbox id="chkUser" runat="server" CssClass="Lables" AutoPostBack="True" Text="Users" Visible="False"></asp:checkbox></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 24px" vAlign="middle" align="center"><asp:checkboxlist id="chklStuType" runat="server" CssClass="Lables" Width="542px" RepeatColumns="5"
														Visible="False"></asp:checkboxlist></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 24px" vAlign="middle" align="center"><asp:checkbox id="chkBranchs" runat="server" CssClass="Lables" AutoPostBack="True" Text="Combination Keys"></asp:checkbox></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 24px" vAlign="middle" align="center"><asp:checkboxlist id="chklBranch" runat="server" CssClass="Lables" RepeatColumns="4"></asp:checkboxlist></TD>
											</TR>
											<TR>
												<TD class="TableBorder" vAlign="middle" align="right"><asp:imagebutton accessKey="S" id="iBtnSave" tabIndex="5" runat="server" Width="92px" Height="20px"
														ImageUrl="../../Images/NewImages/save.gif"></asp:imagebutton>&nbsp;&nbsp;&nbsp;
													<asp:imagebutton accessKey="C" id="iBtnCancel" tabIndex="6" runat="server" Width="92px" Height="20px"
														ImageUrl="../../Images/NewImages/cancel.gif"></asp:imagebutton></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
		</form>
		</TD></TR></TBODY></TABLE>
	</body>
</HTML>
