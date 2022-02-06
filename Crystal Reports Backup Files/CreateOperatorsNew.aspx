<%@ Page Language="vb" AutoEventWireup="false" Codebehind="CreateOperatorsNew.aspx.vb" Inherits="CollegeBoard.CreateOperatorsNew" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>CreateOperators</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Images/Login/StyleSheet_Report.css" type="text/css" rel="stylesheet">
		<style type="text/css">BODY { SCROLLBAR-ARROW-COLOR: black; SCROLLBAR-FACE-COLOR: #ebded6 }
		</style>
	</HEAD>
	<body background="../Images/NewImages/innerpage-bg1.jpg" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" style="Z-INDEX: 101; POSITION: absolute; HEIGHT: 32px; TOP: 8px; LEFT: 8px"
				cellSpacing="0" cellPadding="1" width="100%" align="center" border="0">
				<TR>
					<TD vAlign="baseline" nowrap="nowrap" align="center">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="854" align="center" border="1">
							<TR>
								<TD vAlign="middle" align="center"><asp:label id="lblHeading" runat="server" Width="100%" CssClass="SubHeading1">User Creation</asp:label></TD>
							</TR>
							<TR>
								<TD vAlign="middle" align="center">
									<TABLE id="Table7" style="WIDTH: 277px; HEIGHT: 32px" cellSpacing="0" cellPadding="0" width="277"
										border="0">
										<TR>
											<TD style="HEIGHT: 17px"><asp:radiobutton id="RbtnPayRollUser" runat="server" CssClass="Lables" BorderColor="Gray" BorderWidth="1px"
													BorderStyle="Double" GroupName="ASR" Checked="True" Text="Pay Roll User" AutoPostBack="True"></asp:radiobutton></TD>
											<TD style="HEIGHT: 17px"><asp:radiobutton id="RbtnNormalUser" accessKey="N" runat="server" CssClass="Lables" BorderColor="Gray"
													BorderWidth="1px" BorderStyle="Double" GroupName="ASR" Text="Normal User" AutoPostBack="True"></asp:radiobutton></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD vAlign="middle" align="center">
									<TABLE id="Table9" cellSpacing="0" cellPadding="0" width="300" border="1">
										<TR>
											<TD vAlign="top" align="center"><asp:panel id="Panel1" runat="server" HorizontalAlign="Center">
													<TABLE id="Table8" border="1" cellSpacing="1" cellPadding="1" width="300">
													</TABLE>
													<TABLE id="Table11" border="0" cellSpacing="0" cellPadding="0" width="300">
														<TR>
															<TD>
																<asp:label id="Label22" runat="server" CssClass="Lables" Width="100%" Font-Names="Arial"> Office&nbsp;Type</asp:label></TD>
															<TD>
																<asp:dropdownlist id="drpCStype" runat="server" CssClass="DropDownList" Width="170px" AutoPostBack="True"
																	Height="20px"></asp:dropdownlist></TD>
														</TR>
														<TR>
															<TD style="HEIGHT: 13px">
																<asp:label id="Label7" runat="server" CssClass="Lables" Width="110px">PayRoll&nbsp;Branch*</asp:label></TD>
															<TD style="HEIGHT: 13px">
																<asp:dropdownlist id="DrpParolBarnch" runat="server" CssClass="DropDownList" Width="170px" AutoPostBack="True"></asp:dropdownlist></TD>
														</TR>
														<TR>
															<TD>
																<asp:label id="Label9" runat="server" CssClass="Lables" Width="100%">Search&nbsp;On&nbsp;*</asp:label></TD>
															<TD>
																<TABLE id="Table10" border="0" cellSpacing="0" cellPadding="0" width="300">
																	<TR>
																		<TD style="HEIGHT: 12px"></TD>
																		<TD style="HEIGHT: 12px">
																			<asp:dropdownlist id="DrpSearch" runat="server" Width="170px">
																				<asp:ListItem Value="1" Selected="True">Name</asp:ListItem>
																				<asp:ListItem Value="2">EmpNo</asp:ListItem>
																			</asp:dropdownlist></TD>
																		<TD style="HEIGHT: 12px">
																			<asp:label id="LblDisplaySearch" runat="server" CssClass="Lables" Width="100%">Name&nbsp;/&nbsp;EmpNo</asp:label></TD>
																		<TD style="HEIGHT: 12px">
																			<asp:textbox id="TxtEmpNameNo" runat="server" Width="215px"></asp:textbox></TD>
																		<TD style="HEIGHT: 12px">
																			<asp:imagebutton id="ImgEmpNameNoSearch" runat="server" Width="80px" Height="20px" ImageUrl="../../Images/NewImages/search.gif"></asp:imagebutton></TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
														<TR>
															<TD>
																<asp:label id="Label10" runat="server" CssClass="Lables" Width="110px">Employees&nbsp;*</asp:label></TD>
															<TD>
																<asp:dropdownlist id="DrpEmployees" runat="server" CssClass="DropDownList" Width="817px" AutoPostBack="True"></asp:dropdownlist></TD>
														</TR>
													</TABLE>
												</asp:panel></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD vAlign="middle" align="center">
									<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="660" border="0">
										<TR>
											<TD nowrap="nowrap"><asp:label id="Label1" runat="server" Width="100%" CssClass="Lables">User&nbsp;ID&nbsp;*</asp:label></TD>
											<TD nowrap="nowrap"><asp:textbox id="txtUid" runat="server" Width="152px" CssClass="Textbox" MaxLength="20"></asp:textbox></TD>
											<TD nowrap="nowrap"><asp:label id="Label2" runat="server" Width="100%" CssClass="Lables">User&nbsp;Name&nbsp;*</asp:label></TD>
											<TD nowrap="nowrap"><asp:textbox id="txtUname" runat="server" Width="152px" CssClass="Textbox" MaxLength="50"></asp:textbox></TD>
											<TD nowrap="nowrap"><asp:label id="Label6" runat="server" Width="100%" CssClass="Lables">Academic Year</asp:label></TD>
											<TD nowrap="nowrap"><asp:dropdownlist id="drpAcaSlno" runat="server" Width="153px" CssClass="DropDownList" AutoPostBack="True"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD nowrap="nowrap"><asp:label id="Label3" runat="server" Width="100%" CssClass="Lables">Password&nbsp;*</asp:label></TD>
											<TD nowrap="nowrap"><asp:textbox id="txtPasswd" runat="server" Width="152px" CssClass="Textbox" MaxLength="20" TextMode="Password"></asp:textbox></TD>
											<TD nowrap="nowrap"><asp:label id="Label4" runat="server" Width="100%" CssClass="Lables">Confirm&nbsp;Password&nbsp;*</asp:label></TD>
											<TD nowrap="nowrap"><asp:textbox id="txtPasswdCon" runat="server" Width="152px" CssClass="Textbox" MaxLength="20"
													TextMode="Password"></asp:textbox></TD>
											<TD nowrap="nowrap"></TD>
											<TD nowrap="nowrap"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD vAlign="middle" align="center"></TD>
							</TR>
							<TR>
								<TD vAlign="middle" align="center"><asp:checkbox id="chkUserTypes" runat="server" CssClass="Lables" Text="User Types" AutoPostBack="True"></asp:checkbox></TD>
							</TR>
							<TR>
								<TD vAlign="middle" align="center"><asp:checkboxlist id="chklStuType" runat="server" Width="844px" CssClass="Lables" RepeatColumns="4"></asp:checkboxlist></TD>
							</TR>
							<TR>
								<TD vAlign="middle" align="center">
									<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="244" border="0">
										<TR>
											<TD nowrap="nowrap"><asp:label id="Label5" runat="server" Width="120px" CssClass="Lables">Type</asp:label></TD>
											<TD nowrap="nowrap"><asp:dropdownlist id="drpType" runat="server" Width="153px" CssClass="DropDownList" AutoPostBack="True">
													<asp:ListItem Value="0">All</asp:ListItem>
													<asp:ListItem Value="6">VC</asp:ListItem>
													<asp:ListItem Value="4">DO</asp:ListItem>
													<asp:ListItem Value="2">Zone</asp:ListItem>
													<asp:ListItem Value="1">Region</asp:ListItem>
													<asp:ListItem Value="3">Addl-Region</asp:ListItem>
													<asp:ListItem Value="5">Divisional Auditor</asp:ListItem>
												</asp:dropdownlist></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD vAlign="middle" align="center">
									<BLOCKQUOTE>
										<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="300" border="0">
											<TR>
												<TD nowrap="nowrap"><asp:label id="lblType" runat="server" Width="100%" CssClass="Lables">Region</asp:label></TD>
												<TD nowrap="nowrap"></TD>
												<TD nowrap="nowrap"><asp:label id="Label8" runat="server" Width="100%" CssClass="Lables">Select</asp:label></TD>
											</TR>
											<TR>
												<TD nowrap="nowrap"><asp:listbox id="lstAllBranch" runat="server" Width="210px" CssClass="Label" Height="154px" Rows="100"
														SelectionMode="Multiple"></asp:listbox></TD>
												<TD nowrap="nowrap">
													<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="32" border="0">
														<TR>
															<TD vAlign="middle"><asp:imagebutton id="cmdBranchSelect" runat="server" Width="30px" Height="30px" ImageUrl="../../Images/NewImages/Select.gif"></asp:imagebutton></TD>
														</TR>
														<TR>
															<TD style="HEIGHT: 34px"><asp:imagebutton id="cmdBranchSelectAll" runat="server" Width="30px" Height="30px" ImageUrl="../../Images/NewImages/SelectAll.gif"></asp:imagebutton></TD>
														</TR>
														<TR>
															<TD><asp:imagebutton id="cmdBranchRemove" runat="server" Width="30px" Height="30px" ImageUrl="../../Images/NewImages/Remove.gif"></asp:imagebutton></TD>
														</TR>
														<TR>
															<TD><asp:imagebutton id="cmdBranchRemoveAll" runat="server" Width="30px" Height="30px" ImageUrl="../../Images/NewImages/RemoveAll.gif"></asp:imagebutton></TD>
														</TR>
													</TABLE>
												</TD>
												<TD nowrap="nowrap"><asp:listbox id="lstSelBranch" runat="server" Width="210px" CssClass="Label" Height="154px" Rows="100"
														SelectionMode="Multiple"></asp:listbox></TD>
											</TR>
										</TABLE>
									</BLOCKQUOTE>
								</TD>
							</TR>
							<TR>
								<TD vAlign="middle" align="center"><asp:checkbox id="chkAreaTypes" runat="server" CssClass="Lables" Text="Area Types" AutoPostBack="True"></asp:checkbox></TD>
							</TR>
							<TR>
								<TD vAlign="middle" align="center"><asp:checkboxlist id="chklAreaType" runat="server" Width="100%" CssClass="Lables" RepeatColumns="6"></asp:checkboxlist></TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE id="Table12" border="0" cellSpacing="0" cellPadding="0" width="28">
										<TR>
											<TD>
												<asp:imagebutton accessKey="G" id="ibtGo" runat="server" CssClass="button" Width="40px" Height="20px"
													ImageUrl="../../Images/NewImages/go.gif" BorderStyle="None"></asp:imagebutton></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
                             <TR>
								<TD vAlign="middle" align="center"><asp:checkbox id="chkSegment" runat="server" CssClass="Lables" Text="Segments" AutoPostBack="True" Visible="False"></asp:checkbox></TD>
							</TR>
							<TR>
								<TD vAlign="middle" align="center"><asp:checkboxlist id="chklSegment" runat="server" CssClass="Lables" Width="844px" RepeatColumns="4" Visible="False"></asp:checkboxlist></TD>
							</TR>
							<TR>
								<TD vAlign="middle" align="center"><asp:checkbox id="chkBranchs" runat="server" CssClass="Lables" Text="Branches" AutoPostBack="True"></asp:checkbox></TD>
							</TR>
							<TR>
								<TD vAlign="middle" align="center"><asp:checkboxlist id="chklBranch" runat="server" CssClass="Lables" Width="844px" RepeatColumns="4"></asp:checkboxlist></TD>
							</TR>
							<TR>
								<TD vAlign="middle" align="right"><asp:imagebutton id="ibtSave" accessKey="S" runat="server" CssClass="button" Width="80px" Height="20px"
										ImageUrl="../../Images/NewImages/save.gif"></asp:imagebutton>&nbsp;&nbsp;
									<asp:imagebutton id="ibtnCancel" accessKey="C" runat="server" CssClass="button" Width="80px" Height="20px"
										ImageUrl="../../Images/NewImages/cancel.gif"></asp:imagebutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			<asp:textbox id="txtCrDate" style="Z-INDEX: 102; POSITION: absolute; TOP: 400px; LEFT: 408px"
				runat="server" CssClass="Textbox" Width="0px" MaxLength="10" Height="0px"></asp:textbox></form>
	</body>
</HTML>
