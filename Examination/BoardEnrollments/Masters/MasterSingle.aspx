<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MasterSingle.aspx.vb" Inherits="CollegeBoard.MasterSingle" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>MasterSingle</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK id="Link1" rel="stylesheet" type="text/css" href="../../../Images/Login/StyleSheet.css">
		<script language="JavaScript" type="text/javascript" src="../../../Include/DateValidation.js"></script>
		<script language="javascript" type="text/javascript" src="../Include/Topics.js"></script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="GroupActivitySingle" method="post" runat="server">
			<asp:textbox style="Z-INDEX: 104; POSITION: absolute; TOP: 8px; LEFT: 64px" id="txtlblCode" runat="server"
				Height="32px" Width="0px">XXXXXX</asp:textbox>
			<TABLE style="Z-INDEX: 106; POSITION: absolute; TOP: 8px; LEFT: 8px" id="Table2" border="0"
				cellSpacing="1" cellPadding="1" width="100%">
				<TR>
					<TD vAlign="top" align="center">
						<TABLE style="WIDTH: 408px; HEIGHT: 160px" id="Table1" border="1" cellSpacing="0" cellPadding="1"
							width="408" align="center">
							<TR>
								<TD vAlign="top" align="center">
									<TABLE style="WIDTH: 400px; HEIGHT: 96px" id="Table3" border="0" cellSpacing="0" cellPadding="1"
										width="400" align="center">
										<TR>
											<TD style="HEIGHT: 16px" vAlign="top" align="center"><asp:label id="LblHeading" runat="server" Width="100%" CssClass="SubHeading1">Board&nbsp;Master&nbsp;(Single&nbsp;Mode)</asp:label></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 36px" vAlign="top" align="center">
												<TABLE id="Table5" border="0" cellSpacing="0" cellPadding="1" width="393">
													<TR>
														<TD align="left"><asp:label id="Ibtn" runat="server" Width="100%" CssClass="Lables">Code&nbsp;*</asp:label></TD>
														<TD align="left"><asp:textbox id="TxtCode" runat="server" Width="321px" CssClass=" " MaxLength="250"></asp:textbox></TD>
													</TR>
													<TR>
														<TD align="left"><asp:label id="LblTopic" runat="server" Width="100%" CssClass="Lables">Name&nbsp;*</asp:label></TD>
														<TD align="left"><asp:textbox id="TxtName" runat="server" Width="321px" CssClass=" " MaxLength="250"></asp:textbox></TD>
													</TR>
													<TR>
														<TD align="center"><asp:label id="LblDescription" runat="server" Width="100%" CssClass="Lables">Description</asp:label></TD>
														<TD align="left"><asp:textbox id="TxtDescription" runat="server" Width="100%" CssClass=" " MaxLength="250"></asp:textbox></TD>
													</TR>
													<TR>
														<TD style="HEIGHT: 18px" colSpan="2" align="left">
															<TABLE id="Table4" border="0" cellSpacing="0" cellPadding="0" width="100%" runat="server">
																<TR>
																	<TD style="WIDTH: 73px"><asp:label id="Label1" runat="server" Width="69px" CssClass="Lables">Caste&nbsp;*</asp:label></TD>
																	<TD><asp:dropdownlist id="DrpCaste" runat="server" Height="24px" Width="321px" CssClass=" " AutoPostBack="False"></asp:dropdownlist></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD vAlign="top" align="center"><asp:imagebutton accessKey="S" id="iBtnSave" runat="server" Height="20px" Width="80px" ImageUrl="../../../Images/NewImages/save.gif"></asp:imagebutton><asp:imagebutton accessKey="D" id="iBtnDelete" runat="server" Height="20px" Width="80px" ImageUrl="../../../Images/NewImages/delete.gif"
													Visible="False"></asp:imagebutton><asp:imagebutton accessKey="C" id="iBtnCancel" runat="server" Height="20px" Width="80px" ImageUrl="../../../Images/NewImages/cancel.gif"></asp:imagebutton><asp:button accessKey="C" id="cmdDelete" tabIndex="3" runat="server" Height="0px" Width="0px"
													ImageUrl="http://localhost/PrototypeFinal/Images1/ButtonImages/cancel.jpg" Font-Size="Smaller" Font-Bold="True" Font-Names="Arial" BackColor="MidnightBlue" ForeColor="White" Text="Cancel"></asp:button><asp:button accessKey="C" id="cmdCancel" tabIndex="3" runat="server" Height="0px" Width="0px"
													Font-Size="Smaller" Font-Bold="True" Font-Names="Arial" BackColor="MidnightBlue" ForeColor="White" Text="Cancel"></asp:button><asp:button accessKey="S" id="cmdSave" tabIndex="3" runat="server" Height="0px" Width="0px"
													Font-Size="Smaller" Font-Bold="True" Font-Names="Arial" BackColor="MidnightBlue" ForeColor="White" Text="Save"></asp:button></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			<asp:textbox style="Z-INDEX: 103; POSITION: absolute; TOP: 8px; LEFT: 8px" id="txtDeleteStatus"
				runat="server" Height="32px" Width="0px"></asp:textbox><asp:textbox style="Z-INDEX: 101; POSITION: absolute; TOP: 8px; LEFT: 24px" id="txtSetfocus"
				runat="server" Height="32px" Width="0px"></asp:textbox><asp:textbox style="Z-INDEX: 102; POSITION: absolute; TOP: 8px; LEFT: 40px" id="txtMessage" runat="server"
				Height="32px" Width="0px"></asp:textbox></form>
	</body>
</HTML>
