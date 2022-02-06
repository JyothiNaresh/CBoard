<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SchoolCndCertNew.aspx.vb" Inherits="CollegeBoard.SchoolCndCertNew"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>SchoolCndCertNew</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" type="text/javascript" src="Script.js"></script>
		<style type="text/css" media="print">@page {size: Legal; margin: 0; }
	@media Print { .page { MARGIN: 0px }}
		</style>
		<script>
		function pageset()
		{
		alert('Set Margins For A4 Paper Portrait for Printing');
		}
		</script>
	</HEAD>
	<body onload="pageset();" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="1"
				cellPadding="1" width="100%" border="0">
				<TR>
					<TD align="center">
						<TABLE id="Table1" style="WIDTH: 680px; HEIGHT: 686px" cellSpacing="1" cellPadding="1"
							width="706" border="0">
							<TR>
								<TD style="HEIGHT: 218px" vAlign="top">
									<P align="center">
										<TABLE id="TableNew" cellSpacing="1" cellPadding="1" width="100%" border="0">
											<TR>
												<TD style="HEIGHT: 168px">
													<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" border="0">
														<TR>
															<TD style="WIDTH: 71px; HEIGHT: 91px"><asp:image id="Image1" runat="server" Width="100px" Height="109px" ImageUrl="Templates/Narayana Logo.jpg"></asp:image></TD>
															<TD style="HEIGHT: 91px" align="center">
																<P><asp:label id="lblCCColName" runat="server" Width="519px" Height="30px" Font-Size="20pt" Font-Names="Bodoni MT"
																		CssClass="lables">NAME OF THE COLLEGE</asp:label><asp:label id="Label36" runat="server" Width="100%" Height="9px" Font-Size="Smaller" Font-Names="Calibri"
																		CssClass="lables"> ( Recognised by Govt. of Andhra Pradesh)</asp:label><asp:label id="LblColAddr" runat="server" Width="100%" Font-Size="9pt" Font-Names="Calibri"
																		CssClass="lables"></asp:label><asp:label id="LblebAddr" runat="server" Width="100%" Font-Size="9pt" Font-Names="Calibri"
																		CssClass="lables"></asp:label></P>
																<P>&nbsp;</P>
															</TD>
														</TR>
														<TR>
															<TD vAlign="middle" align="center" colSpan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
																<asp:label id="Label35" runat="server" Width="496px" Height="24px" Font-Size="Larger" Font-Names="Arial Black"
																	CssClass="lables" Font-Bold="True" Font-Underline="True">STUDY AND CONDUCT CERTIFICATE</asp:label></TD>
														</TR>
														<TR>
															<TD vAlign="middle" align="center" colSpan="2"></TD>
														</TR>
													</TABLE>
													<TABLE id="Table21" cellSpacing="1" cellPadding="1" width="100%" border="0">
														<TR>
															<TD>
																<TABLE id="Table3" style="HEIGHT: 8px" cellSpacing="1" cellPadding="1" width="100%" align="center"
																	border="0">
																	<TR>
																		<TD style="WIDTH: 113px"><STRONG>Admission No:</STRONG></TD>
																		<TD style="WIDTH: 63px"><asp:label id="LblAdmno" runat="server" Width="100%" Font-Bold="True"></asp:label><asp:image id="Image4" runat="server" Width="100%" Height="2px" ImageUrl="Templates/underline.jpg"></asp:image></TD>
																		<TD style="WIDTH: 310px"></TD>
																		<TD style="WIDTH: 98px" align="right"><STRONG>Date:</STRONG></TD>
																		<TD>&nbsp;<asp:label id="LblprintDate" runat="server" Width="91px" Font-Bold="True">Date</asp:label><asp:image id="Image2" runat="server" Width="100%" Height="2px" ImageUrl="Templates/underline.jpg"></asp:image></TD>
																	</TR>
																</TABLE>
																&nbsp;&nbsp;&nbsp;&nbsp;
															</TD>
														</TR>
													</TABLE>
													<TABLE id="Table14" style="HEIGHT: 48px" cellSpacing="1" cellPadding="1" width="100%" border="0">
														<TR>
															<TD style="WIDTH: 171px; HEIGHT: 29px"></TD>
															<TD style="HEIGHT: 29px">
																<P>&nbsp;</P>
															</TD>
														</TR>
														<TR>
															<TD style="WIDTH: 171px"><FONT face="Brush Script MT"><FONT size="4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
																		This is certify That</FONT></FONT></TD>
															<TD><asp:label id="LblStuname" runat="server" Width="446px" Font-Names="Calibri" Font-Bold="True"></asp:label><asp:image id="Image8" runat="server" Width="100%" Height="2px" ImageUrl="Templates/underline.jpg"></asp:image></TD>
														</TR>
													</TABLE>
													<TABLE id="Table12" cellSpacing="1" cellPadding="1" width="100%" border="0">
														<TR>
															<TD style="WIDTH: 156px"><FONT face="Brush Script MT" size="4">Son &nbsp;/&nbsp; 
																	Daughter of Sri</FONT></TD>
															<TD><asp:label id="LblFname" runat="server" Width="100%" Height="4px" Font-Names="Calibri" Font-Bold="True"></asp:label><asp:image id="Image9" runat="server" Width="100%" Height="2px" ImageUrl="Templates/underline.jpg"></asp:image></TD>
														</TR>
													</TABLE>
													<TABLE id="Table15" cellSpacing="1" cellPadding="1" width="100%" border="0">
														<TR>
															<TD style="WIDTH: 570px"><FONT face="Brush Script MT" size="4">is/was a bonified of 
																	this school and&nbsp;is studying/has studied class(es)from</FONT></TD>
															<TD style="WIDTH: 109px"><asp:label id="LblfrmCls" runat="server" Width="89px" Font-Names="Calibri" Font-Bold="True">clsf</asp:label><asp:image id="Image10" runat="server" Width="87px" Height="2px" ImageUrl="Templates/underline.jpg"></asp:image></TD>
															<TD style="WIDTH: 5px"><FONT face="Brush Script MT" size="4">to</FONT></TD>
															<TD><asp:label id="LblTocls" runat="server" Width="100px" Font-Names="Calibri" Font-Bold="True">toc</asp:label>
																<asp:image id="Image11" runat="server" Width="100px" Height="2px" ImageUrl="Templates/underline.jpg"></asp:image></TD>
														</TR>
													</TABLE>
													<TABLE id="Table16" cellSpacing="1" cellPadding="1" width="100%" border="0">
														<TR>
															<TD style="WIDTH: 200px"><FONT face="Brush Script MT" size="4">during the academic 
																	year(s) from</FONT>
															</TD>
															<TD style="WIDTH: 97px" align="center"><asp:label id="LblFrmYear" runat="server" Width="100px" Font-Names="Calibri" Font-Bold="True"></asp:label><asp:image id="Image12" runat="server" Width="100px" Height="2px" ImageUrl="Templates/underline.jpg"></asp:image></TD>
															<TD style="WIDTH: 31px"><FONT face="Brush Script MT" size="4">&nbsp;&nbsp;to</FONT></TD>
															<TD style="WIDTH: 96px" align="center"><asp:label id="LblToyear" runat="server" Width="100px" Font-Names="Calibri" Font-Bold="True"></asp:label><asp:image id="Image13" runat="server" Width="100px" Height="2px" ImageUrl="Templates/underline.jpg"></asp:image></TD>
															<TD style="WIDTH: 162px" align="center"><FONT face="Brush Script MT" size="4">&nbsp;&nbsp;&nbsp;.His/her&nbsp;date
																	<FONT face="Brush Script MT" size="4">of birth as</FONT></FONT></TD>
														</TR>
													</TABLE>
													<TABLE id="Table17" style="HEIGHT: 14px" cellSpacing="1" cellPadding="1" width="100%" border="0">
														<TR>
															<TD style="WIDTH: 192px"><FONT face="Brush Script MT" size="4"><FONT face="Brush Script MT" size="4">per 
																		school records(in words) is&nbsp; </FONT></FONT>
															</TD>
															<TD><asp:label id="LblDob" runat="server" Width="100%" Font-Names="Calibri" Font-Bold="True"></asp:label><asp:image id="Image14" runat="server" Width="100%" Height="2px" ImageUrl="Templates/underline.jpg"></asp:image></TD>
														</TR>
													</TABLE>
													<TABLE id="Table19" cellSpacing="1" cellPadding="1" width="100%" border="0">
														<TR>
															<TD style="HEIGHT: 28px"><FONT face="Brush Script MT" size="4">His&nbsp;/ Her</FONT></FONT>&nbsp;<FONT face="Brush Script MT" size="4">conduct 
																	is</FONT>&nbsp; <STRONG><U><FONT face="Calibri" size="4">Good</FONT></U></STRONG>
																.</TD>
														</TR>
													</TABLE>
													<TABLE id="Table6" cellSpacing="1" cellPadding="1" width="100%" border="0">
														<TR>
															<TD></TD>
														</TR>
														<TR>
															<TD>
																<P>&nbsp;</P>
																<P>&nbsp;</P>
															</TD>
														</TR>
													</TABLE>
													<TABLE id="Table7" cellSpacing="1" cellPadding="1" width="100%" border="0">
														<TR>
															<TD style="WIDTH: 444px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
																<asp:label id="Label10" runat="server" Width="34px" Font-Size="Smaller" Font-Bold="True">Clerk</asp:label></TD>
															<TD><asp:label id="Label11" runat="server" Font-Size="Smaller" Font-Bold="True">HeadMistress / Headmaster </asp:label></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 23px"></TD>
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
