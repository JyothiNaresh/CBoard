<%@ Page Language="vb" AutoEventWireup="false" Codebehind="CreateOperators.aspx.vb" Inherits="CollegeBoard.CreateOperators" %>
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
						<TABLE id="Table4" style="WIDTH: 555px; HEIGHT: 327px" cellSpacing="0" cellPadding="1"
							width="555" align="center" border="1">
							<TR>
								<TD vAlign="baseline" nowrap="nowrap" align="center">
									<TABLE id="Table2" style="WIDTH: 560px; HEIGHT: 312px" cellSpacing="0" cellPadding="1"
										width="560" align="center" border="0">
										<TR>
											<TD vAlign="middle" align="center"><asp:label id="lblHeading" runat="server" CssClass="SubHeading1" Width="556px">User Creation</asp:label></TD>
										</TR>
										<TR>
											<TD vAlign="middle" align="center">
												<TABLE id="Table6" style="WIDTH: 277px; HEIGHT: 32px" cellSpacing="0" cellPadding="0" width="277"
													border="1">
													<TR>
														<TD style="HEIGHT: 17px">
															<asp:radiobutton id="RbtnPayRollUser" runat="server" CssClass="Lables" AutoPostBack="True" Text="Pay Roll User"
																BorderColor="Gray" BorderWidth="1px" BorderStyle="Double" GroupName="ASR" Checked="True"></asp:radiobutton></TD>
														<TD style="HEIGHT: 17px">
															<asp:radiobutton id="RbtnNormalUser" accessKey="N" runat="server" CssClass="Lables" AutoPostBack="True"
																Text="Normal User" BorderColor="Gray" BorderWidth="1px" BorderStyle="Double" GroupName="ASR"></asp:radiobutton></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD vAlign="middle" align="center">
												<TABLE id="Table9" cellSpacing="0" cellPadding="0" width="300" border="1">
													<TR>
														<TD vAlign="top" align="center">
															<asp:panel id="Panel1" runat="server" HorizontalAlign="Center">
																<TABLE id="Table8" cellSpacing="1" cellPadding="1" width="300" border="1">
																</TABLE>
																<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="300" border="0">
																	<TR>
																		<TD>
																			<asp:label id="Label22" runat="server" Width="100%" CssClass="Lables" Font-Names="Arial"> Office&nbsp;Type</asp:label></TD>
																		<TD>
																			<asp:dropdownlist id="drpCStype" runat="server" Width="170px" CssClass="DropDownList" AutoPostBack="True"
																				Height="20px"></asp:dropdownlist></TD>
																	</TR>
																	<TR>
																		<TD style="HEIGHT: 8px">
																			<asp:label id="Label7" runat="server" Width="110px" CssClass="Lables">PayRoll&nbsp;Branch*</asp:label></TD>
																		<TD style="HEIGHT: 8px">
																			<asp:dropdownlist id="DrpParolBarnch" runat="server" Width="170px" CssClass="DropDownList" AutoPostBack="True"></asp:dropdownlist></TD>
																	</TR>
																	<TR>
																		<TD>
																			<asp:label id="Label9" runat="server" Width="100%" CssClass="Lables">Search&nbsp;On&nbsp;*</asp:label></TD>
																		<TD>
																			<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="300" border="0">
																				<TR>
																					<TD style="HEIGHT: 12px"></TD>
																					<TD style="HEIGHT: 12px">
																						<asp:dropdownlist id="DrpSearch" runat="server" Width="170px">
																							<asp:ListItem Value="1" Selected="True">Name</asp:ListItem>
																							<asp:ListItem Value="2">EmpNo</asp:ListItem>
																						</asp:dropdownlist></TD>
																					<TD style="HEIGHT: 12px">
																						<asp:label id="LblDisplaySearch" runat="server" Width="100%" CssClass="Lables">Name&nbsp;/&nbsp;EmpNo</asp:label></TD>
																					<TD style="HEIGHT: 12px">
																						<asp:textbox id="TxtEmpNameNo" runat="server" Width="215px"></asp:textbox></TD>
																					<TD style="HEIGHT: 12px">
																						<asp:imagebutton id="ImgEmpNameNoSearch" runat="server" Width="80px" ImageUrl="../../Images/NewImages/search.gif"
																							Height="20px"></asp:imagebutton></TD>
																				</TR>
																			</TABLE>
																		</TD>
																	</TR>
																	<TR>
																		<TD>
																			<asp:label id="Label8" runat="server" Width="110px" CssClass="Lables">Employees&nbsp;*</asp:label></TD>
																		<TD>
																			<asp:dropdownlist id="DrpEmployees" runat="server" Width="817px" CssClass="DropDownList" AutoPostBack="True"></asp:dropdownlist></TD>
																	</TR>
																</TABLE>
															</asp:panel></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD vAlign="middle" align="center">
												<TABLE id="Table3" cellSpacing="0" cellPadding="1" width="552" border="0" style="WIDTH: 552px; HEIGHT: 64px">
													<TR>
														<TD nowrap="nowrap"><asp:label id="Label1" runat="server" CssClass="Lables" Width="110px">User&nbsp;ID&nbsp;*</asp:label></TD>
														<TD nowrap="nowrap"><asp:textbox id="txtUid" runat="server" CssClass="Textbox" Width="152px" MaxLength="20"></asp:textbox></TD>
														<TD nowrap="nowrap"><asp:label id="Label3" runat="server" CssClass="Lables" Width="120px">Password&nbsp;*</asp:label></TD>
														<TD nowrap="nowrap"><asp:textbox id="txtPasswd" runat="server" CssClass="Textbox" Width="152px" MaxLength="20" TextMode="Password"></asp:textbox></TD>
													</TR>
													<TR>
														<TD nowrap="nowrap"><asp:label id="Label2" runat="server" CssClass="Lables" Width="110px">User&nbsp;Name&nbsp;*</asp:label></TD>
														<TD nowrap="nowrap"><asp:textbox id="txtUname" runat="server" CssClass="Textbox" Width="152px" MaxLength="50"></asp:textbox></TD>
														<TD nowrap="nowrap"><asp:label id="Label4" runat="server" CssClass="Lables" Width="120px">Confirm&nbsp;Password&nbsp;*</asp:label></TD>
														<TD nowrap="nowrap"><asp:textbox id="txtPasswdCon" runat="server" CssClass="Textbox" Width="152px" MaxLength="20"
																TextMode="Password"></asp:textbox></TD>
													</TR>
													<TR>
														<TD nowrap="nowrap"><asp:label id="Label10" runat="server" CssClass="Lables" Width="110px">From&nbsp;Date&nbsp;*</asp:label></TD>
														<TD nowrap="nowrap"><asp:textbox id="txtFrDate" runat="server" CssClass="Textbox" Width="152px" MaxLength="12"></asp:textbox></TD>
														<TD nowrap="nowrap"><asp:label id="Label11" runat="server" CssClass="Lables" Width="120px">To&nbsp;Date&nbsp;*</asp:label></TD>
														<TD nowrap="nowrap"><asp:textbox id="txtToDate" runat="server" CssClass="Textbox" Width="152px" MaxLength="12"></asp:textbox></TD>
													</TR>
													<TR>
														<TD nowrap="nowrap"><asp:label id="Label5" runat="server" CssClass="Lables" Width="110px">Creation Date&nbsp;*</asp:label></TD>
														<TD nowrap="nowrap"><asp:textbox id="txtCrDate" runat="server" CssClass="Textbox" Width="153px" MaxLength="12"></asp:textbox></TD>
														<TD nowrap="nowrap"><asp:label id="Label6" runat="server" CssClass="Lables" Width="120px">Academic Year</asp:label></TD>
														<TD nowrap="nowrap"><asp:dropdownlist id="drpAcaSlno" runat="server" CssClass="DropDownList" Width="153px" AutoPostBack="True"></asp:dropdownlist></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD vAlign="middle" align="center"></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 24px" vAlign="middle" align="center"><asp:checkbox id="chkUserTypes" runat="server" CssClass="Lables" AutoPostBack="True" Text="User Types"></asp:checkbox></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 24px" vAlign="middle" align="center"><asp:checkboxlist id="chklStuType" runat="server" CssClass="Lables" Width="542px" RepeatColumns="3"></asp:checkboxlist></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 24px" vAlign="middle" align="center">
												<TABLE id="Table5" style="WIDTH: 205px; HEIGHT: 27px" cellSpacing="0" cellPadding="0" width="205"
													border="0">
													<TR>
														<TD><asp:label id="lblRZ" runat="server" CssClass="Lables" Width="100%"> Region</asp:label></TD>
														<TD><asp:dropdownlist id="drpRZ" runat="server" CssClass="DropDownList" Width="150px" AutoPostBack="True"></asp:dropdownlist></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 24px" vAlign="middle" align="center"><asp:checkbox id="chkBranchs" runat="server" CssClass="Lables" AutoPostBack="True" Text="Branches"></asp:checkbox></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 24px" vAlign="middle" align="center">
												<asp:checkboxlist id="chklBranch" runat="server" CssClass="Lables" RepeatColumns="4"></asp:checkboxlist></TD>
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
