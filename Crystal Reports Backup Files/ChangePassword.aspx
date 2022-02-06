<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ChangePassword.aspx.vb" Inherits="CollegeBoard.ChangePassword" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>ChangePassword</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="../../Images/Login/StyleSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout" background="../Images/NewImages/innerpage-bg1.jpg">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 152px"
				cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD vAlign="baseline" nowrap="nowrap" align="center" colSpan="1" rowSpan="1">
						<TABLE id="Table5" cellSpacing="0" cellPadding="0" align="center" border="0">
							<TR>
								<TD class="DarkColor" vAlign="top">
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td vAlign="top" width="11"><IMG height="11" src="../../Images/Login/table-lcorw.gif" width="11"></td>
											<td class="SubHeading">Change Password</td>
											<td vAlign="top" width="11"><IMG height="11" src="../../Images/Login/table-rcorw.gif" width="11"></td>
										</tr>
									</table>
								</TD>
							</TR>
							<TR>
								<td valign="top" class="TableBorder"><table width="100%" border="0" cellspacing="0" cellpadding="0">
										<tr>
											<td class="TdBorder"><img src="images/spacer.gif" width="1" height="1"></td>
										</tr>
										<tr>
											<td>
												<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="136" border="0">
													<TR>
														<TD>
															<asp:Label id="Label1" runat="server" Width="130px" CssClass="Lables">Old&nbsp;Password&nbsp;*</asp:Label></TD>
														<TD>
															<asp:TextBox id="txtOpasswd" runat="server" Width="160px" CssClass="Textbox" MaxLength="20" TextMode="Password"></asp:TextBox></TD>
													</TR>
													<TR>
														<TD>
															<asp:Label id="Label2" runat="server" Width="130px" CssClass="Lables">New&nbsp;Password&nbsp;*</asp:Label></TD>
														<TD>
															<asp:TextBox id="txtNpasswd" runat="server" Width="160px" CssClass="Textbox" MaxLength="20" TextMode="Password"></asp:TextBox></TD>
													</TR>
													<TR>
														<TD>
															<asp:Label id="Label3" runat="server" Width="130px" CssClass="Lables">Confirm&nbsp;Password&nbsp;*</asp:Label></TD>
														<TD>
															<asp:TextBox id="txtCpasswd" runat="server" Width="160px" CssClass="Textbox" MaxLength="20" TextMode="Password"></asp:TextBox></TD>
													</TR>
												</TABLE>
											</td>
										</tr>
										<tr>
											<td class="TdBorder"><img src="images/spacer.gif" width="1" height="1"></td>
										</tr>
									</table>
								</td>
							</TR>
							<TR>
								<TD nowrap="nowrap" align="center"></TD>
							</TR>
							<TR>
								<TD vAlign="middle" nowrap="nowrap" align="right">
									<asp:ImageButton id="ibtnSave" accessKey="U" runat="server" Width="80px" ImageUrl="../../Images/NewImages/save.gif"
										Height="20px"></asp:ImageButton>
									<asp:ImageButton id="ibtnCancel" accessKey="C" runat="server" Width="80px" ImageUrl="../../Images/NewImages/cancel.gif"
										Visible="False" Height="20px"></asp:ImageButton></TD>
							</TR>
							<TR>
								<TD vAlign="middle" nowrap="nowrap" align="right"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
