<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SchoolCCPreview.aspx.vb" Inherits="CollegeBoard.SchoolCCPreview"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>SchoolCCPreview</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK id="Link1" href="../../../Images/Login/StyleSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="1"
				cellPadding="1" width="100%" border="0">
				<TR>
					<TD>
						<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="300" border="1" align="center">
							<TR>
								<TD align="center">
									<asp:Label id="Label8" runat="server" Height="100%" Width="100%" CssClass="Subheading1">
						Conduct Certifficate Preview</asp:Label></TD>
							</TR>
							<TR>
								<TD>
									<P>
										<TABLE id="Table1" style="WIDTH: 750px; HEIGHT: 326px" cellSpacing="1" cellPadding="1"
											width="750" align="center" border="1">
											<TR>
												<TD class="lables" style="WIDTH: 6px; HEIGHT: 1px" align="center" height="1">1</TD>
												<TD class="lables" style="WIDTH: 316px; HEIGHT: 1px" align="center" height="1">
													<asp:Label id="Label4" runat="server" Height="20" Width="100%">Name of the School</asp:Label></TD>
												<TD class="lables" style="WIDTH: 15px; HEIGHT: 1px" align="center" height="1">:</TD>
												<TD class="lables" style="HEIGHT: 1px" align="center" height="1">
													<asp:Label id="lblClgNameCode" runat="server" Font-Bold="True">Label</asp:Label></TD>
											</TR>
											<TR>
												<TD class="lables" style="WIDTH: 6px; HEIGHT: 5px" align="center" height="5"></TD>
												<TD class="lables" style="WIDTH: 316px; HEIGHT: 5px" align="center" height="5">
													<asp:Label id="Label5" runat="server" Height="20px" Width="100%">(Place and Address)</asp:Label></TD>
												<TD class="lables" style="WIDTH: 15px; HEIGHT: 5px" align="center" height="5">:</TD>
												<TD class="lables" style="HEIGHT: 5px" align="center" height="5">
													<asp:Label id="LblSchAddr" runat="server" Font-Bold="True">Label</asp:Label></TD>
											</TR>
											<TR>
												<TD class="lables" style="WIDTH: 6px; HEIGHT: 1px" align="center" height="1"></TD>
												<TD class="lables" style="WIDTH: 316px; HEIGHT: 1px" align="center" height="1"></TD>
												<TD class="lables" style="WIDTH: 15px; HEIGHT: 1px" align="center" height="1"></TD>
												<TD class="lables" style="HEIGHT: 1px" align="center" height="1">
													<asp:Label id="LblSchAddr2" runat="server" Font-Bold="True">Label</asp:Label></TD>
											</TR>
											<TR>
												<TD class="lables" style="WIDTH: 6px; HEIGHT: 14px" align="center" height="14">2</TD>
												<TD class="lables" style="WIDTH: 316px; HEIGHT: 14px" align="center" height="14">Admno</TD>
												<TD class="lables" style="WIDTH: 15px; HEIGHT: 14px" align="center" height="14">:</TD>
												<TD class="lables" style="HEIGHT: 14px" align="center" height="14">
													<asp:Label id="LblAdmno" runat="server" Font-Bold="True">Label</asp:Label></TD>
											</TR>
											<TR>
												<TD class="lables" style="WIDTH: 6px; HEIGHT: 14px" align="center" height="14">3</TD>
												<TD class="lables" style="WIDTH: 316px; HEIGHT: 14px" align="center" height="14">
													<asp:Label id="Label6" runat="server">Name of the Pupil</asp:Label></TD>
												<TD class="lables" style="WIDTH: 15px; HEIGHT: 14px" align="center" height="14">:</TD>
												<TD class="lables" style="HEIGHT: 14px" align="center" height="14">
													<asp:Label id="Lblname" runat="server" Font-Bold="True">Label</asp:Label></TD>
											</TR>
											<TR>
												<TD class="lables" style="WIDTH: 6px; HEIGHT: 1px" align="center" height="1">4</TD>
												<TD class="lables" style="WIDTH: 316px; HEIGHT: 1px" align="center" height="1">
													<asp:Label id="Label7" runat="server">Name of the Father</asp:Label></TD>
												<TD class="lables" style="WIDTH: 15px; HEIGHT: 1px" align="center" height="1">:</TD>
												<TD class="lables" style="HEIGHT: 1px" align="center" height="1">
													<asp:Label id="lblFname" runat="server" Font-Bold="True">Label</asp:Label></TD>
											</TR>
											<TR>
												<TD class="lables" style="WIDTH: 6px; HEIGHT: 1px" align="center" height="1">5</TD>
												<TD class="lables" style="WIDTH: 316px; HEIGHT: 1px" align="center" height="1">
													<asp:Label id="Label3" runat="server" Height="20px" Width="328px">Course on which the pupil has actually joined the School</asp:Label></TD>
												<TD class="lables" style="WIDTH: 15px; HEIGHT: 1px" align="center" height="1">:</TD>
												<TD class="lables" style="HEIGHT: 1px" align="center" height="1">
													<asp:Label id="LblJoinCrs" runat="server" Font-Bold="True">Label</asp:Label></TD>
											</TR>
											<TR>
												<TD class="lables" style="WIDTH: 6px; HEIGHT: 1px" align="center" height="1">6</TD>
												<TD class="lables" style="WIDTH: 316px; HEIGHT: 1px" align="center" height="1">
													<asp:Label id="Label2" runat="server" Height="20px">Course on which the pupil has actually left the School</asp:Label></TD>
												<TD class="lables" style="WIDTH: 15px; HEIGHT: 1px" align="center" height="1">:</TD>
												<TD class="lables" style="HEIGHT: 1px" align="center" height="1">
													<asp:Label id="LblLeftCrs" runat="server" Font-Bold="True">Label</asp:Label></TD>
											</TR>
											<TR>
												<TD class="lables" style="WIDTH: 6px; HEIGHT: 3px" align="center" height="3">7</TD>
												<TD class="lables" style="WIDTH: 316px; HEIGHT: 3px" align="center" height="3">
													<asp:Label id="Label1" runat="server" Height="20px">Date on which the pupil has actually joined the School</asp:Label></TD>
												<TD class="lables" style="WIDTH: 15px; HEIGHT: 3px" align="center" height="3">:</TD>
												<TD class="lables" style="HEIGHT: 3px" align="center" height="3">
													<asp:Label id="LblJoindate" runat="server" Font-Bold="True">Label</asp:Label></TD>
											</TR>
											<TR>
												<TD class="lables" style="WIDTH: 6px; HEIGHT: 1px" align="center" height="1">8</TD>
												<TD class="lables" style="WIDTH: 316px; HEIGHT: 1px" align="center" height="1">
													<asp:Label id="Label30" runat="server" Height="20px">Date on which the pupil has actually left the School</asp:Label></TD>
												<TD class="lables" style="WIDTH: 15px; HEIGHT: 1px" align="center" height="1"><STRONG>:</STRONG></TD>
												<TD class="lables" style="HEIGHT: 1px" align="center" height="1">
													<asp:Label id="Lblleftdate" runat="server" Font-Bold="True">Label</asp:Label></TD>
											</TR>
											<TR>
												<TD class="lables" style="WIDTH: 6px; HEIGHT: 2px" align="center" height="2">9</TD>
												<TD class="lables" style="WIDTH: 316px; HEIGHT: 2px" align="center" height="2">
													<asp:Label id="Label9" runat="server" Height="20px">Date of Birth (in words) as per School Records</asp:Label></TD>
												<TD class="lables" style="WIDTH: 15px; HEIGHT: 2px" align="center" height="2">:</TD>
												<TD class="lables" style="HEIGHT: 2px" align="center" height="2">
													<asp:Label id="Lbldob" runat="server" Font-Bold="True">Label</asp:Label></TD>
											</TR>
											<TR>
												<TD class="lables" style="WIDTH: 6px" align="center" height="30">10</TD>
												<TD class="lables" style="WIDTH: 316px" align="center" height="30">
													<asp:Label id="Label32" runat="server" Height="20px">Conduct</asp:Label></TD>
												<TD class="lables" style="WIDTH: 15px" align="center" height="30"><STRONG>:</STRONG></TD>
												<TD class="lables" align="center" height="30" rowSpan="1">
													<asp:Label id="lblPoint18" runat="server" Font-Bold="True">GOOD</asp:Label></TD>
											</TR>
										</TABLE>
									</P>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
