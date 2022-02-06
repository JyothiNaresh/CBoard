<%@ Page Language="vb" AutoEventWireup="false" Codebehind="UserRegistrationTransfor.aspx.vb" Inherits="CollegeBoard.UserRegistrationTransfor"%>
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
						<TABLE id="Table4" style="WIDTH: 363px; HEIGHT: 263px" cellSpacing="0" cellPadding="1"
							width="363" align="center" border="1">
							<TR>
								<TD vAlign="baseline" nowrap="nowrap" align="center">
									<TABLE id="Table2" style="WIDTH: 541px; HEIGHT: 244px" cellSpacing="0" cellPadding="1"
										width="541" align="center" border="0">
										<TR>
											<TD vAlign="middle" align="center"><asp:label id="lblHeading" runat="server" CssClass="SubHeading1" Width="685px">User Registration Transfers</asp:label></TD>
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
																						<asp:ListItem Value="1" Selected="True">Name</asp:ListItem>
																						<asp:ListItem Value="2">UserId</asp:ListItem>
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
																		<asp:label id="Label12" runat="server" Width="110px" CssClass="Lables">To&nbsp;User&nbsp;*</asp:label></TD>
																	<TD>
																		<asp:dropdownlist id="DrpToUser" runat="server" Width="558px" CssClass="DropDownList" AutoPostBack="True"></asp:dropdownlist></TD>
																</TR>
																<TR>
																	<TD>
																		<asp:label id="Label1" runat="server" Width="110px" CssClass="Lables">No.Of&nbsp;Hours&nbsp;*</asp:label></TD>
																	<TD>
																		<asp:textbox id="TxtNoofHours" runat="server" Width="215px"></asp:textbox></TD>
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
																						<asp:ListItem Value="1" Selected="True">Name</asp:ListItem>
																						<asp:ListItem Value="2">UserId</asp:ListItem>
																					</asp:dropdownlist></TD>
																				<TD style="HEIGHT: 12px">
																					<asp:label id="LblDisplaySearch" runat="server" Width="100%" CssClass="Lables">Name&nbsp;/&nbsp;UserId</asp:label></TD>
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
																		<asp:label id="Label8" runat="server" Width="110px" CssClass="Lables">From&nbsp;User&nbsp;*</asp:label></TD>
																	<TD>
																		<asp:dropdownlist id="DrpFromUser" runat="server" Width="558px" CssClass="DropDownList" AutoPostBack="True"></asp:dropdownlist></TD>
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
											<TD vAlign="middle" align="center"><asp:imagebutton id="ibtSave" accessKey="S" runat="server" CssClass="button" Width="80px" Height="20px"
													ImageUrl="../../Images/NewImages/save.gif" AlternateText="Save"></asp:imagebutton>&nbsp;&nbsp;
												<asp:imagebutton id="ibtnRevote" accessKey="R" runat="server" CssClass="button" Width="80px" Height="20px"
													ImageUrl="../../Images/NewImages/Revert.gif" AlternateText="Revert"></asp:imagebutton></TD>
										</TR>
										<TR>
											<TD vAlign="middle" align="center">
												<asp:Panel id="PnlRevert" runat="server" Height="40px" Visible="False">
													<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="300" border="0">
														<TR>
															<TD vAlign="top" colSpan="2">
																<asp:label id="Label2" runat="server" Width="685px" CssClass="SubHeading1">User Registration Revert</asp:label></TD>
														</TR>
														<TR>
															<TD vAlign="top">
																<asp:label id="Label5" runat="server" Width="100%" CssClass="Lables">Search&nbsp;On&nbsp;*</asp:label></TD>
															<TD vAlign="top">
																<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="300" border="0">
																	<TR>
																		<TD style="HEIGHT: 12px"></TD>
																		<TD style="HEIGHT: 12px">
																			<asp:dropdownlist id="DrpReSearch" runat="server" Width="170px">
																				<asp:ListItem Value="1" Selected="True">Name</asp:ListItem>
																				<asp:ListItem Value="2">UserId</asp:ListItem>
																			</asp:dropdownlist></TD>
																		<TD style="HEIGHT: 12px">
																			<asp:label id="Label4" runat="server" Width="100%" CssClass="Lables">Name&nbsp;/&nbsp;UserId</asp:label></TD>
																		<TD style="HEIGHT: 12px">
																			<asp:textbox id="TxtRevUseId" runat="server" Width="215px"></asp:textbox></TD>
																		<TD style="HEIGHT: 12px">
																			<asp:imagebutton id="IbtnRevSearch" runat="server" Width="80px" ImageUrl="../../Images/NewImages/search.gif"
																				Height="20px"></asp:imagebutton></TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
														<TR>
															<TD>
																<asp:label id="Label3" runat="server" Width="110px" CssClass="Lables">To&nbsp;User&nbsp;*</asp:label></TD>
															<TD>
																<asp:dropdownlist id="DrpRevUsers" runat="server" Width="558px" CssClass="DropDownList" AutoPostBack="True"></asp:dropdownlist></TD>
														</TR>
														<TR>
															<TD align="center" colSpan="2">
																<asp:imagebutton id="Imagebutton1" accessKey="S" runat="server" Width="80px" CssClass="button" ImageUrl="../../Images/NewImages/save.gif"
																	Height="20px" AlternateText="Save"></asp:imagebutton>
																<asp:imagebutton id="IbtnCancle" accessKey="C" runat="server" Width="80px" CssClass="button" ImageUrl="../../Images/NewImages/cancel.gif"
																	Height="20px" AlternateText="Cancel"></asp:imagebutton></TD>
														</TR>
													</TABLE>
												</asp:Panel></TD>
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
