<%@ Page Language="vb" AutoEventWireup="false" Codebehind="NoticeEntry.aspx.vb" Inherits="CollegeBoard.NoticeEntry" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>addNotice</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK id="Link1" href="../Styles/UseCaseStyle/StyleSheet_Report.css" type="text/css" rel="stylesheet">
		<script language="javascript" type="text/javascript">
	function disProp(msgslno)
	{
	
	var msg;
	var slno;
	var qs;
	var url;
	var temp;
	qs='?MSGSLNO='
	msg=qs+msgslno;	
	temp='NoticeDisplaySettings.aspx'
	url=temp+msg
	
	window.open(url,'mine','menubar=no,toolbar=no,scrollbars=yes,height=300,width=650')
	}
	
	
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" style="WIDTH: 760px; HEIGHT: 610px" cellSpacing="0" cellPadding="0"
				width="760" border="0">
				<TR>
					<TD vAlign="top" align="center" colSpan="5">
						<TABLE id="Table3" style="WIDTH: 732px; HEIGHT: 597px" cellSpacing="0" cellPadding="0"
							width="732" align="center" border="0">
							<TR>
								<TD style="HEIGHT: 8px"></TD>
							</TR>
							<TR>
								<TD vAlign="top">
									<TABLE id="Table2" style="WIDTH: 738px; HEIGHT: 571px" cellSpacing="0" cellPadding="0"
										width="738" align="center" border="0">
										<TR>
											<TD style="HEIGHT: 23px" colSpan="3"><asp:table id="Table1" runat="server" CssClass="MainTable" Width="760px" Font-Size="Medium"></asp:table></TD>
										</TR>
										<TR>
											<TD vAlign="top" align="center" colSpan="3"></TD>
										</TR>
										<TR>
											<TD align="center" colSpan="3"><asp:panel id="Panel1" runat="server" Height="408px" ForeColor="Chocolate" Visible="False">
													<P align="center"><STRONG><FONT color="#ff9933" size="3">
																<TABLE id="Table5" style="WIDTH: 666px; HEIGHT: 355px" cellSpacing="1" cellPadding="1"
																	width="666" border="0">
																	<TR>
																		<TD style="WIDTH: 132px" align="right" colSpan="1" rowSpan="1">
																			<asp:Label id="Label2" runat="server" ForeColor="Chocolate" Font-Names="Verdana">Notice Heading :</asp:Label>&nbsp;</TD>
																		<TD>
																			<asp:TextBox id="txtCaption" runat="server" Font-Size="Medium" Width="471px" ForeColor="Black"
																				Height="32px" Font-Names="Verdana" MaxLength="250"></asp:TextBox></TD>
																		<TD></TD>
																	</TR>
																	<TR>
																		<TD style="WIDTH: 132px; HEIGHT: 190px" align="right">
																			<asp:Label id="Label4" runat="server" ForeColor="Chocolate" Font-Names="Verdana">Notice Text :</asp:Label>&nbsp;</TD>
																		<TD style="HEIGHT: 190px">
																			<asp:TextBox id="txtNotice" runat="server" Font-Size="Medium" Width="477px" ForeColor="Black"
																				Height="175px" Font-Names="Verdana" MaxLength="1000" TextMode="MultiLine"></asp:TextBox></TD>
																		<TD style="HEIGHT: 190px"></TD>
																	</TR>
																	<TR>
																		<TD style="WIDTH: 132px"></TD>
																		<TD>
																			<P>&nbsp;</P>
																		</TD>
																		<TD></TD>
																	</TR>
																	<TR>
																		<TD style="WIDTH: 132px">
																			<P align="right">
																				<asp:Label id="Label1" runat="server" ForeColor="Chocolate" Height="11px" Font-Names="Verdana">Browse file to attach :</asp:Label>&nbsp;</P>
																		</TD>
																		<TD><INPUT id="fileNoticeboard" style="WIDTH: 475px; BORDER-TOP-STYLE: solid; BORDER-RIGHT-STYLE: solid; BORDER-LEFT-STYLE: solid; HEIGHT: 22px; BORDER-BOTTOM-STYLE: solid"
																				type="file" size="60" name="File1" runat="server"></TD>
																		<TD></TD>
																	</TR>
																	<TR>
																		<TD style="WIDTH: 132px"></TD>
																		<TD vAlign="middle" align="center">
																			<asp:Button id="btnSave" runat="server" Width="84px" ForeColor="#C04000" Height="25px" Text="Save"></asp:Button>
																			<asp:Button id="btnCancel" runat="server" Width="85px" ForeColor="#C04000" Height="25px" Text="Cancel"></asp:Button></TD>
																		<TD></TD>
																	</TR>
																</TABLE>
															</FONT></STRONG>&nbsp;&nbsp;&nbsp;&nbsp;
													</P>
													<P>&nbsp;</P>
												</asp:panel></TD>
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
