<!--<%@ Register TagPrefix="cr" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>-->
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="BOARDRPTS.aspx.vb" Inherits="CollegeBoard.BOARDRPTS" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>BOARDRPTS</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK id="Link1" rel="stylesheet" type="text/css" href="../../../Images/Login/StyleSheet_Report.css">
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
												<TD vAlign="top" width="11"><IMG src="../../../Images/Login/table-lcorw.gif" width="11" height="11"></TD>
												<TD class="SubHeading"><asp:label id="lblHeading" runat="server" Width="100%" CssClass="SubHeading1" Font-Bold="True"> College Details Reports </asp:label></TD>
												<TD vAlign="top" width="11"><IMG src="../../../Images/Login/table-rcorw.gif" width="11" height="11"></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD class="TdBorder"><IMG src="../../../Images/Login/spacer.gif" width="1" height="1"></TD>
								</TR>
								<TR>
									<TD class="TableBorder" vAlign="top" align="right">
										<TABLE id="Table3" border="1" cellSpacing="0" cellPadding="0" width="261" style="WIDTH: 261px; HEIGHT: 24px">
											<TR>
												<TD><asp:label id="Label2" runat="server" Width="105px" CssClass="Lables" Height="20px">College Code</asp:label></TD>
												<TD><asp:textbox id="Txtccode" runat="server" Width="89px" CssClass=" " MaxLength="10"></asp:textbox></TD>
												<TD class="TableBorder" vAlign="middle" align="right">
													<asp:imagebutton accessKey="R" id="ImgCCode" tabIndex="1" runat="server" Width="75px" Height="17px"
														ImageUrl="../../../Images/NewImages/ccodewise.gif"></asp:imagebutton></TD>
											</TR>
										</TABLE>
										<TABLE id="Table4" border="1" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD><asp:radiobutton id="rdbAffil" runat="server" Width="100%" CssClass="Lables" AutoPostBack="True"
														Checked="True" GroupName="1" Text="District Wise Affilation &amp; Add Sections"></asp:radiobutton></TD>
											</TR>
											<TR>
												<TD><asp:radiobutton id="rdbcert" runat="server" Width="100%" CssClass="Lables" AutoPostBack="True" GroupName="1"
														Text="District Wise Certificates"></asp:radiobutton></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center">
							<asp:Table id="TblBrdRpt" runat="server"></asp:Table></TD>
					</TR>
				</TBODY>
			</TABLE>
		</form>
		</TD></TR></TBODY></TABLE>
	</body>
</HTML>
