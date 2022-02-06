<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MTMUserExamBranch.aspx.vb" Inherits="CollegeBoard.MTMUserExamBranch" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>CreateOperators</title>
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
											<TD vAlign="middle" align="center"><asp:label id="lblHeading" runat="server" Width="100%" CssClass="SubHeading1">User Wise Exam Branchs</asp:label></TD>
										</TR>
										<TR>
											<TD vAlign="middle" align="center">
												<TABLE id="Table3" cellSpacing="0" cellPadding="1" width="300" border="0">
													<TR>
														<TD nowrap="nowrap"><asp:label id="Label5" runat="server" Width="110px" CssClass="Lables">User&nbsp;Types&nbsp;*</asp:label></TD>
														<TD nowrap="nowrap"><asp:dropdownlist id="DrpUserTypes" runat="server" Width="153px" CssClass="DropDownList"></asp:dropdownlist></TD>
														<TD nowrap="nowrap"><asp:label id="Label6" runat="server" Width="120px" CssClass="Lables">Academic Year</asp:label></TD>
														<TD nowrap="nowrap"><asp:dropdownlist id="drpAcaSlno" runat="server" Width="153px" CssClass="DropDownList"></asp:dropdownlist></TD>
														<TD nowrap="nowrap"><asp:imagebutton id="iBtnSearch" accessKey="E" runat="server" Width="80px" ImageUrl="../../Images/NewImages/search.gif"
																Height="20px"></asp:imagebutton></TD>
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
											<TD style="HEIGHT: 24px" vAlign="middle" align="center"><asp:checkbox id="chkUser" runat="server" CssClass="Lables" Text="Users" AutoPostBack="True"></asp:checkbox></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 24px" vAlign="middle" align="center"><asp:checkboxlist id="chklStuType" runat="server" Width="844px" CssClass="Lables" RepeatColumns="5"></asp:checkboxlist></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 24px" vAlign="middle" align="center">
												<HR width="100%" SIZE="1">
											</TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 24px" vAlign="middle" align="center">
												<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="244" border="0">
													<TR>
														<TD nowrap="nowrap"><asp:label id="Label1" runat="server" Width="120px" CssClass="Lables">Type</asp:label></TD>
														<TD nowrap="nowrap"><asp:dropdownlist id="drpType" runat="server" Width="153px" CssClass="DropDownList" AutoPostBack="True">
																<asp:ListItem Value="0">All</asp:ListItem>
																<asp:ListItem Value="1">Region</asp:ListItem>
																<asp:ListItem Value="2">Zone</asp:ListItem>
																<asp:ListItem Value="3">Addl-Region</asp:ListItem>
																<asp:ListItem Value="4">Vc</asp:ListItem>
																<asp:ListItem Value="5">Divisional Auditor</asp:ListItem>
															</asp:dropdownlist></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 24px" vAlign="middle" align="center">
												<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="300" border="0">
													<TR>
														<TD nowrap="nowrap"><asp:label id="lblType" runat="server" Width="100%" CssClass="Lables">Region</asp:label></TD>
														<TD nowrap="nowrap"></TD>
														<TD nowrap="nowrap"><asp:label id="Label8" runat="server" Width="100%" CssClass="Lables">Select</asp:label></TD>
													</TR>
													<TR>
														<TD nowrap="nowrap"><asp:listbox id="lstAllBranch" runat="server" Width="130px" CssClass="Label" Height="154px" SelectionMode="Multiple"
																Rows="100"></asp:listbox></TD>
														<TD nowrap="nowrap">
															<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="32" border="0">
																<TR>
																	<TD vAlign="middle" colSpan="1" rowSpan="1"><asp:imagebutton id="cmdBranchSelect" runat="server" Width="30px" ImageUrl="../../Images/NewImages/Select.gif"
																			Height="30px"></asp:imagebutton></TD>
																</TR>
																<TR>
																	<TD style="HEIGHT: 34px"><asp:imagebutton id="cmdBranchSelectAll" runat="server" Width="30px" ImageUrl="../../Images/NewImages/SelectAll.gif"
																			Height="30px"></asp:imagebutton></TD>
																</TR>
																<TR>
																	<TD><asp:imagebutton id="cmdBranchRemove" runat="server" Width="30px" ImageUrl="../../Images/NewImages/Remove.gif"
																			Height="30px"></asp:imagebutton></TD>
																</TR>
																<TR>
																	<TD><asp:imagebutton id="cmdBranchRemoveAll" runat="server" Width="30px" ImageUrl="../../Images/NewImages/RemoveAll.gif"
																			Height="30px"></asp:imagebutton></TD>
																</TR>
															</TABLE>
														</TD>
														<TD nowrap="nowrap"><asp:listbox id="lstSelBranch" runat="server" Width="130px" CssClass="Label" Height="154px" SelectionMode="Multiple"
																Rows="100"></asp:listbox></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 24px" vAlign="middle" align="center"><asp:checkbox id="chkBranchs" runat="server" CssClass="Lables" Text="Branches" AutoPostBack="True"></asp:checkbox></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 24px" vAlign="middle" align="center"><asp:checkboxlist id="chklBranch" runat="server" Width="844px" CssClass="Lables" RepeatColumns="4"></asp:checkboxlist></TD>
										</TR>
										<TR>
											<TD vAlign="middle" align="right"><asp:imagebutton id="ibtSave" accessKey="S" runat="server" Width="80px" CssClass="button" ImageUrl="../../Images/NewImages/save.gif"
													Height="20px" AlternateText="Save"></asp:imagebutton>&nbsp;&nbsp;
												<asp:imagebutton id="ibtnCancel" accessKey="C" runat="server" Width="80px" CssClass="button" ImageUrl="../../Images/NewImages/cancel.gif"
													Height="20px" AlternateText="Cancel"></asp:imagebutton></TD>
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
