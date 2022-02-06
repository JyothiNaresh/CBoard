<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PasswordFound.aspx.vb" Inherits="CollegeBoard.PasswordFound" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>PasswordFound</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="1"
				cellPadding="1" width="100%" align="center" border="0">
				<TR>
					<TD nowrap="nowrap" align="center">
						<TABLE id="Table2" style="WIDTH: 135px; HEIGHT: 109px" cellSpacing="1" cellPadding="1"
							width="135" align="center" border="1">
							<TR>
								<TD nowrap="nowrap" align="center">
									<asp:TextBox id="TextBox1" runat="server" Width="350px"></asp:TextBox></TD>
							</TR>
							<TR>
								<TD nowrap="nowrap" align="center">
									<TABLE id="Table3" style="WIDTH: 107px; HEIGHT: 24px" cellSpacing="0" cellPadding="0" width="107"
										border="0">
										<TR>
											<TD nowrap="nowrap">
												<asp:Button id="Button1" runat="server" Text="Encrypt"></asp:Button></TD>
											<TD nowrap="nowrap">
												<asp:Button id="Button2" runat="server" Text="Decrypt"></asp:Button></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD nowrap="nowrap" align="center">
									<asp:TextBox id="TextBox2" runat="server" Width="350px"></asp:TextBox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
