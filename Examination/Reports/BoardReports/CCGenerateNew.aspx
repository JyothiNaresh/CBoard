<%@ Page Language="vb" AutoEventWireup="false" Codebehind="CCGenerateNew.aspx.vb" Inherits="CollegeBoard.CCGenerateNew" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
		<title>CCGenerateNew</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
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
	<body MS_POSITIONING="GridLayout" onload="pageset();">
		<form id="Form1" method="post" runat="server">
			<TABLE style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px" id="Table4" border="0"
				cellSpacing="1" cellPadding="1" width="100%">
				<TR>
					<TD align="center">
						<TABLE style="WIDTH: 585px; HEIGHT: 534px" id="Table1" border="0" cellSpacing="1" cellPadding="1"
							width="585">
							<TR>
								<TD style="HEIGHT: 218px">
									<TABLE style="WIDTH: 627px; HEIGHT: 136px" id="Table2" border="0" cellSpacing="1" cellPadding="1">
										<TR>
											<TD style="WIDTH: 181px; HEIGHT: 120px"><asp:image id="Image1" runat="server" Width="100px" Height="109px" ImageUrl=""></asp:image></TD>
											<TD style="HEIGHT: 120px" align="center">
												<P>
													<asp:label id="lblCCColName" runat="server" Height="30px" Width="519px" Font-Size="20pt" Font-Names="Calibri"
														CssClass="lables">Name of the College</asp:label>
													<asp:label id="Label36" runat="server" Height="9px" Width="100%" Font-Size="Smaller" Font-Names="Calibri"
														CssClass="lables">( Recognised by Govt. of Andhra Pradesh - Affiliated to BIE ,Andhra Pradesh )</asp:label>
													<asp:Label id="LblColAddr" runat="server" Width="100%" Font-Size="9pt" Font-Names="Calibri"
														CssClass="lables"></asp:Label></P>
												<P>&nbsp;</P>
											</TD>
										</TR>
										<TR>
											<TD colSpan="2" align="center" vAlign="middle" height="50">
												<asp:label id="Label35" runat="server" Width="514px" Height="24px" CssClass="lables" Font-Names="Calibri"
													Font-Size="Larger" Font-Bold="True" Font-Underline="True">Study And Conduct Certificate</asp:label>
											</TD>
										</TR>
									</TABLE>
									<TABLE style="WIDTH: 625px; HEIGHT: 23px" id="Table3" border="0" cellSpacing="1" cellPadding="1"
										width="625" align="center">
										<TR>
											<TD style="WIDTH: 105px"><STRONG>Admission No:</STRONG></TD>
											<TD style="WIDTH: 360px"><asp:label id="LblAdmno" runat="server" Font-Bold="True">Label</asp:label></TD>
											<TD style="WIDTH: 43px"><STRONG>Date:</STRONG></TD>
											<TD><asp:label id="LblDate" runat="server" Font-Bold="True">Label</asp:label></TD>
										</TR>
									</TABLE>
									<P>&nbsp;</P>
								</TD>
							</TR>
							<TR>
								<TD vAlign="top" align="center">
									<P>
										<TABLE style="WIDTH: 629px; HEIGHT: 160px" id="Table5" border="0" cellSpacing="1" cellPadding="1"
											width="629">
											<TR>
												<TD>
													<TABLE style="WIDTH: 624px; HEIGHT: 27px" id="Table7" border="0" cellSpacing="1" cellPadding="1"
														width="624">
														<TR>
															<TD style="WIDTH: 205px"><FONT face="Brush Script MT"><FONT size="4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
																		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; This is certify That</FONT>&nbsp;&nbsp;&nbsp;</FONT>
															</TD>
															<TD>
																<asp:label id="Lblname" runat="server" Width="100%" Font-Names="Calibri" Font-Bold="True">Label</asp:label>
																<asp:image id="Image5" runat="server" Width="400px" Height="2px" ImageUrl="Templates/underline.jpg"></asp:image></TD>
														</TR>
													</TABLE>
													<TABLE style="HEIGHT: 48px" id="Table9" border="0" cellSpacing="1" cellPadding="1" width="100%">
														<TR>
															<TD style="WIDTH: 132px"><FONT size="4" face="Brush Script MT">Son &nbsp;/&nbsp; 
																	Daughter of</FONT></TD>
															<TD style="WIDTH: 324px">
																<asp:label id="LblFather" runat="server" Width="100%" Font-Names="Calibri" Font-Bold="True">Label</asp:label>
																<asp:image id="Image3" runat="server" Width="100%" Height="2px" ImageUrl="Templates/underline.jpg"></asp:image></TD>
															<TD><FONT face="Brush Script MT">&nbsp; <FONT size="4">is /was a student of this</FONT></FONT></TD>
														</TR>
													</TABLE>
													<TABLE style="HEIGHT: 50px" id="Table11" border="0" cellSpacing="1" cellPadding="1" width="100%">
														<TR>
															<TD style="WIDTH: 188px"><FONT size="4" face="Brush Script MT">college and studying 
																	/studied</FONT>
															</TD>
															<TD style="WIDTH: 154px">
																<TABLE style="WIDTH: 152px; HEIGHT: 27px" id="Table12" border="0" cellSpacing="1" cellPadding="1"
																	width="152">
																	<TR>
																		<TD><asp:label id="LblCourse" runat="server" Width="100%" Font-Names="Calibri" Font-Bold="True">Label</asp:label><asp:image id="Image2" runat="server" Width="100%" Height="2px" ImageUrl="Templates/underline.jpg"></asp:image></TD>
																	</TR>
																</TABLE>
															<TD style="WIDTH: 1px"><FONT face="Brush Script MT"><FONT size="4">in</FONT> </FONT>
															</TD>
															<TD style="WIDTH: 97px">
																<TABLE style="WIDTH: 96px; HEIGHT: 27px" id="Table13" border="0" cellSpacing="1" cellPadding="1"
																	width="96">
																	<TR>
																		<TD align="center"><asp:label id="lBLgRP" runat="server" Width="88px" Font-Names="Calibri" Font-Bold="True">Label</asp:label><asp:image id="Image6" runat="server" Width="100%" Height="2px" ImageUrl="Templates/underline.jpg"></asp:image></TD>
																	</TR>
																</TABLE>
															</TD>
															<TD style="WIDTH: 75px"><FONT size="4" face="Brush Script MT">group with</FONT></TD>
															<TD>
																<TABLE style="WIDTH: 69px; HEIGHT: 27px" id="Table14" border="0" cellSpacing="1" cellPadding="1">
																	<TR>
																		<TD><asp:label id="LblMed" runat="server" Width="80px" Font-Names="Calibri" Font-Bold="True">Label</asp:label><asp:image id="Image8" runat="server" Width="80px" Height="2px" ImageUrl="Templates/underline.jpg"></asp:image></TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
													</TABLE>
													<TABLE id="Table6" border="0" cellSpacing="1" cellPadding="1" width="100%">
														<TR>
															<TD><FONT size="4" face="Brush Script MT">medium during the academicyear (s)</FONT></TD>
															<TD style="WIDTH: 167px" align="center">
																<asp:label id="LblFrom" runat="server" Width="176px" Font-Names="Calibri" Font-Bold="True">Label</asp:label>
																<asp:image id="Image4" runat="server" Width="176px" Height="2px" ImageUrl="Templates/underline.jpg"></asp:image></TD>
															<TD><FONT face="Brush Script MT">.<FONT size="4"> His&nbsp;/ Her</FONT></FONT>&nbsp;<FONT size="4" face="Brush Script MT">conduct 
																	is</FONT>&nbsp; <STRONG><U><FONT size="4" face="Calibri">Good</FONT></U></STRONG>
																.</TD>
														</TR>
													</TABLE>
													<P></P>
													<P>&nbsp;</P>
													<P>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
													</P>
													<P>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
																<asp:Label id="Label1" runat="server" Width="53px" Font-Size="12pt" Font-Names="Bodoni MT"
																	Font-Bold="True">Principal</asp:Label></P>
												</TD>
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
