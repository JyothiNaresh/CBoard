<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CCGenerateCBSE.aspx.vb" Inherits="CollegeBoard.CCGenerateCBSE" %>

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
		    function pageset() {
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
						<TABLE style="WIDTH: 705px; HEIGHT: 534px" id="Table1" border="0" cellSpacing="1" cellPadding="1"
							width="705">
							<TR>
								<TD style="HEIGHT: 218px">
									<TABLE style="WIDTH: 680px; HEIGHT: 136px" id="Table2" border="0" cellSpacing="1" cellPadding="1">
										<TR>
											<TD style="WIDTH: 181px; HEIGHT: 120px"><asp:image id="Image1" runat="server" Width="100px" Height="109px" ImageUrl=""></asp:image></TD>
											<TD style="HEIGHT: 120px" align="center">
												<P>
													<asp:label id="lblCCColName" runat="server" Height="30px" Width="519px" Font-Size="20pt" Font-Names="Calibri"
														CssClass="lables">Name of the College</asp:label>
													<asp:label id="Label36" runat="server" Height="9px" Width="100%" Font-Size="Smaller" Font-Names="Calibri"
														CssClass="lables">(AFFILIATED TO CBSE, GOVT. OF INDIA, NEW DELHI) </asp:label>
                                                    <asp:Label id="Label2" runat="server" Width="100%" Font-Size="Smaller" Font-Names="Calibri"
														CssClass="lables">NO. 10+2 CBSE/ AFF./ 3630202, School No. : 57718</asp:Label>
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
									<TABLE style="WIDTH: 800px; HEIGHT: 23px" id="Table3" border="0" cellSpacing="1" cellPadding="1"
										width="800" align="center">
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
										<TABLE style="WIDTH: 800px; HEIGHT: 160px" id="Table5" border="0" cellSpacing="1" cellPadding="1"
											width="700">
											<TR>
												<TD>
													<TABLE style="WIDTH: 724px; HEIGHT: 27px" id="Table7" border="0" cellSpacing="1" cellPadding="1"
														width="724">
														<TR>
															<TD style="WIDTH: 300px"><FONT face="Calibri"><FONT size="4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
																		&nbsp;&nbsp; This is to Certify that Miss/Master </FONT>&nbsp;&nbsp;&nbsp;</FONT>
															</TD>
															<TD>
																<asp:label id="Lblname" runat="server" Width="100%" Font-Names="Calibri" Font-Bold="True">Label</asp:label>
																<asp:image id="Image5" runat="server" Width="400px" Height="2px" ImageUrl="Templates/underline.jpg"></asp:image></TD>
														</TR>
													</TABLE>
													<TABLE style="HEIGHT: 48px" id="Table9" border="0" cellSpacing="1" cellPadding="1" width="100%">
														<TR>
															<TD style="WIDTH: 222px"><FONT size="4" face="Calibri">Son &nbsp;/&nbsp; 
																	Daughter of Sri</FONT></TD>
															<TD style="WIDTH: 324px">
																<asp:label id="LblFather" runat="server" Width="100%" Font-Names="Calibri" Font-Bold="True">Label</asp:label>
																<asp:image id="Image3" runat="server" Width="100%" Height="2px" ImageUrl="Templates/underline.jpg"></asp:image></TD>
															<TD style="WIDTH: 494px"><FONT face="Calibri">&nbsp; <FONT size="4">is a bonafide student of this college and </FONT></FONT></TD>
														</TR>
													</TABLE>
													<TABLE style="HEIGHT: 50px" id="Table11" border="0" cellSpacing="1" cellPadding="1" width="740px">
														<TR>
															<TD style="WIDTH: 132px"><FONT size="4" face="Calibri">&nbsp;studying 
																	/studied</FONT>
															</TD>
															<TD style="WIDTH: 40px">

																<TABLE style="WIDTH: 152px; HEIGHT: 27px" id="Table12" border="0" cellSpacing="1" cellPadding="1"
																	width="152">
																	<TR>
																		<TD><asp:label id="LblCourse" runat="server" Width="50%" Font-Names="Calibri" Font-Bold="True">Label</asp:label><asp:image id="Image2" runat="server" Width="100%" Height="2px" ImageUrl="Templates/underline.jpg"></asp:image></TD>
																	</TR>
																</TABLE>
															<TD style="WIDTH: 253px"><FONT face="Calibri"><FONT size="4">Class during the academicyear (s)</FONT> </FONT>
															</TD>
															
													</TABLE>
													<TABLE id="Table6" border="0" cellSpacing="1" cellPadding="1" width="100%">
														<TR>
															
															<TD style="WIDTH: 167px" align="center">
																<asp:label id="LblFrom" runat="server" Width="176px" Font-Names="Calibri" Font-Bold="True">Label</asp:label>
																<asp:image id="Image4" runat="server" Width="176px" Height="2px" ImageUrl="Templates/underline.jpg"></asp:image></TD>
															<TD style="WIDTH: 327px"><FONT face="Calibri"><FONT size="4"> His&nbsp;/ Her date of birth as per our records is </FONT></FONT>
																	
																</TD>
                                                            <TD style="WIDTH: 187px" align="center">
																<asp:label id="lblDOB" runat="server" Width="176px" Font-Names="Calibri" Font-Bold="True">Label</asp:label>
																<asp:image id="Image7" runat="server" Width="176px" Height="2px" ImageUrl="Templates/underline.jpg"></asp:image></TD>
														</TR>
                                                      
													</TABLE>

                                                    <TABLE id="Table6" border="0" cellSpacing="1" cellPadding="1" width="100%">
														<TR>
															
															<TD>
																</TD>
														</TR>
                                                       <TR>
															
															<TD><FONT face="Calibri"><FONT size="4">And  His&nbsp;/ Her</FONT></FONT>&nbsp;<FONT size="4" face="Calibri">conduct for the above said period 
																	is</FONT>&nbsp; <STRONG><U><FONT size="4" face="Calibri">Good</FONT></U></STRONG>
																.</TD>
														</TR>
													</TABLE>
													<P></P>
													<P>&nbsp;</P>
                                                    <P><asp:Label id="Label1" runat="server" Width="53px" Font-Size="12pt" Font-Names="Bodoni MT"
																	Font-Bold="True">Place:HYDERABAD</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
																<asp:Label id="Label3" runat="server" Width="53px" Font-Size="12pt"  Font-Names="Bodoni MT"
																	Font-Bold="True">Principal</asp:Label>
													</P>
                                                    <P>	<asp:Label id="Label4" runat="server" Width="53px" Font-Size="12pt" Font-Names="Bodoni MT"
																	Font-Bold="True">Date:
                                                       	</asp:Label>
													</P>
													<P>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
													</P>
													
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