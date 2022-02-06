<%@ Page Language="vb" AutoEventWireup="false" Codebehind="DatabaseConnections.aspx.vb" Inherits="CollegeBoard.DatabaseConnections"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>DatabaseConnections</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="../../Images/Login/StyleSheet_Report.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="1"
				cellPadding="1" width="100%" border="0">
				<TR>
					<TD vAlign="top" align="center">
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="251" border="0" style="WIDTH: 251px; HEIGHT: 104px">
							<TR>
								<TD>
									<asp:Label id="Label5" runat="server" CssClass="subheading1" Width="100%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Database Connections</asp:Label></TD>
							</TR>
							<TR>
								<TD vAlign="top" align="center">
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="250" border="1">
										<TR>
											<TD style="WIDTH: 157px">
												<asp:Label id="Label1" runat="server" CssClass="Lables" Width="100%">Open Connections</asp:Label></TD>
											<TD vAlign="top" align="center">
												<asp:Label id="lblOpen" runat="server" Width="100%"></asp:Label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 157px">
												<asp:Label id="Label2" runat="server" CssClass="Lables" Width="100%">Close Connections</asp:Label></TD>
											<TD vAlign="top" align="center">
												<asp:Label id="lblClose" runat="server" Width="100%"></asp:Label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 157px">
												<asp:Label id="Label3" runat="server" CssClass="Lables" Width="100%">Report Open Connections</asp:Label></TD>
											<TD vAlign="top" align="center">
												<asp:Label id="lblRptOpen" runat="server" Width="100%"></asp:Label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 157px">
												<asp:Label id="Label4" runat="server" CssClass="Lables" Width="100%">Report Close Connections</asp:Label></TD>
											<TD vAlign="top" align="center">
												<asp:Label id="lblRptClose" runat="server" Width="100%"></asp:Label></TD>
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
