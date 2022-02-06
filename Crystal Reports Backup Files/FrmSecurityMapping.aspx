<%@ Page Language="vb" AutoEventWireup="false" Codebehind="FrmSecurityMapping.aspx.vb" Inherits="CollegeBoard.FrmSecurityMapping" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>CreateOperators</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Images/Login/StyleSheet_Report.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body background="../Images/NewImages/innerpage-bg1.jpg" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="0"
				cellPadding="1" width="100%" border="0">
				<TR>
					<TD vAlign="top" align="center">
						<TABLE id="Table4" style="WIDTH: 946px; HEIGHT: 232px" cellSpacing="0" cellPadding="1"
							width="946" align="center" border="1">
							<TR>
								<TD vAlign="baseline" nowrap="nowrap" align="center">
									<TABLE id="Table2" style="WIDTH: 939px; HEIGHT: 168px" cellSpacing="0" cellPadding="1"
										width="939" align="center" border="0">
										<TR>
											<TD vAlign="middle" align="center"><asp:label id="lblHeading" runat="server" CssClass="SubHeading1" Width="935px">User Mapping To FilesManager</asp:label></TD>
										</TR>
										<TR>
											<TD align="center">
												<TABLE id="Table9" cellSpacing="0" cellPadding="0" width="300" border="0">
													<TR>
														<TD vAlign="top" align="center" style="HEIGHT: 68px">
															<TABLE id="Table12" cellSpacing="0" cellPadding="0" width="300" border="0">
																<TR>
																	<TD vAlign="top">
																		<asp:label id="Label14" runat="server" Width="100%" CssClass="Lables">Search&nbsp;On&nbsp;*</asp:label></TD>
																	<TD vAlign="top">
																		<TABLE id="Table13" cellSpacing="0" cellPadding="0" width="300" border="0">
																			<TR>
																				<TD style="HEIGHT: 12px"></TD>
																				<TD style="HEIGHT: 12px">
																					<asp:dropdownlist id="DrpCSSearch" runat="server" Width="170px">
																						<asp:ListItem Value="1">Name</asp:ListItem>
																						<asp:ListItem Value="2" Selected="True">User Id</asp:ListItem>
																					</asp:dropdownlist></TD>
																				<TD style="HEIGHT: 12px">
																					<asp:label id="Label13" runat="server" Width="100%" CssClass="Lables">Name&nbsp;/&nbsp;UserId</asp:label></TD>
																				<TD style="HEIGHT: 12px">
																					<asp:textbox id="TxtUserNameId" runat="server" Width="215px"></asp:textbox></TD>
																				<TD style="HEIGHT: 12px">
																					<asp:imagebutton id="IbtnUserSearch" runat="server" Width="80px" Height="20px" ImageUrl="../../Images/NewImages/search.gif"></asp:imagebutton></TD>
																			</TR>
																		</TABLE>
																	</TD>
																</TR>
																<TR>
																	<TD>
																		<asp:label id="Label12" runat="server" Width="110px" CssClass="Lables">User&nbsp;*</asp:label></TD>
																	<TD>
																		<asp:dropdownlist id="DrpCoScUsers" runat="server" Width="817px" CssClass="DropDownList" AutoPostBack="True"></asp:dropdownlist></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD vAlign="top" align="center">
															<HR width="100%" SIZE="1">
														</TD>
													</TR>
													<TR>
														<TD vAlign="top" align="center">
															<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="300" border="0">
																<TR>
																	<TD vAlign="top">
																		<asp:label id="Label9" runat="server" Width="100%" CssClass="Lables">Search&nbsp;On&nbsp;*</asp:label></TD>
																	<TD>
																		<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="300" border="0">
																			<TR>
																				<TD style="HEIGHT: 12px"></TD>
																				<TD style="HEIGHT: 12px">
																					<asp:dropdownlist id="DrpSearch" runat="server" Width="170px">
																						<asp:ListItem Value="1">Name</asp:ListItem>
																						<asp:ListItem Value="2" Selected="True">EmpNo</asp:ListItem>
																					</asp:dropdownlist></TD>
																				<TD style="HEIGHT: 12px">
																					<asp:label id="LblDisplaySearch" runat="server" Width="100%" CssClass="Lables">Name&nbsp;/&nbsp;EmpNo</asp:label></TD>
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
																		<asp:label id="Label8" runat="server" Width="110px" CssClass="Lables">Employees&nbsp;*</asp:label></TD>
																	<TD>
																		<asp:dropdownlist id="DrpEmployees" runat="server" Width="817px" CssClass="DropDownList" AutoPostBack="True"></asp:dropdownlist></TD>
																</TR>
																<TR>
																	<TD></TD>
																	<TD><asp:textbox id="txtUid" runat="server" CssClass="Textbox" Width="0px" ReadOnly="True" MaxLength="20"></asp:textbox></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
											</TD>
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
