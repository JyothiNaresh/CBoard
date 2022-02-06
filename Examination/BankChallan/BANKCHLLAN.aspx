<%@ Page Language="vb" AutoEventWireup="false" Codebehind="BANKCHLLAN.aspx.vb" Inherits="CollegeBoard.BANKCHLLAN" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>BANKCHLLAN</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK id="Link1" rel="stylesheet" type="text/css" href="../../Images/Login/StyleSheet_Report.css">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" autocomplete="off" runat="server">
			<TABLE id="Table0" border="0" cellSpacing="1" cellPadding="1" width="100%">
				<TBODY>
					<TR>
						<TD vAlign="top" align="center">
							<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0">
								<TR>
									<TD class="DarkColor">
										<TABLE id="Table2" border="0" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD vAlign="top" width="11"><IMG src="../../Images/Login/table-lcorw.gif" width="11" height="11"></TD>
												<TD class="SubHeading"><asp:label id="lblHeading" runat="server" Width="100%" CssClass="SubHeading1" Font-Bold="True"> CHALLAN COPY DETAILS FOR BANK & STUDENT </asp:label></TD>
												<TD vAlign="top" width="11"><IMG src="../../Images/Login/table-rcorw.gif" width="11" height="11"></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD class="TdBorder"><IMG src="../../Images/Login/spacer.gif" width="1" height="1"></TD>
								</TR>
								<TR>
									<TD class="TableBorder" vAlign="top" align="center">
										<TABLE id="Table3" border="1" cellSpacing="0" cellPadding="0" width="609" style="WIDTH: 609px; HEIGHT: 26px">
											<TR>
												<TD>
													<asp:radiobutton style="Z-INDEX: 0" id="RbtnAxis" runat="server" CssClass="Lables" Width="100%" Text=" AXIS BANK"
														GroupName="BtnSel" Checked="False" TextAlign="Left"></asp:radiobutton></TD>
												<TD>
													<asp:radiobutton style="Z-INDEX: 0" id="RbtnICICI" runat="server" CssClass="Lables" Width="100%"
														Text="ICICI BANK" GroupName="BtnSel" Checked="False" TextAlign="Left"></asp:radiobutton></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD class="TableBorder" vAlign="middle" align="right"><asp:imagebutton accessKey="G" id="iBtnGo" tabIndex="5" runat="server" Width="41px" Height="20px"
											ImageUrl="../../Images/NewImages/GO.gif"></asp:imagebutton>&nbsp;&nbsp;&nbsp;</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
		</form>
		</TD></TR></TBODY></TABLE>
	</body>
</HTML>
