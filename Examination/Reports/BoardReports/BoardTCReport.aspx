<%@ Page Language="vb" AutoEventWireup="false" Codebehind="BoardTCReport.aspx.vb" Inherits="CollegeBoard.BoardTCReport" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>BoardTCReport</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK id="Link1" href="../../../Images/Login/StyleSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table7" style="Z-INDEX: 104; POSITION: absolute; TOP: 8px; LEFT: 8px" cellSpacing="0"
				cellPadding="1" width="100%" border="0">
				<TR>
					<TD>
						<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="100%" border="1" runat="server">
							<TR>
								<TD colSpan="2"><asp:label id="Label1" runat="server" Width="100%" CssClass="SubHeading1">TRANSFER CERTIFICATE DETAILS</asp:label></TD>
							</TR>
							<TR>
								<TD width="60%"><asp:label id="Label4" runat="server" Width="100%" Height="15px" CssClass="Lables">Class in which the pupil was reading at ther time of leaving (in words)</asp:label></TD>
								<TD width="20%"><asp:dropdownlist id="DrpCourse" runat="server" Width="120px" CssClass=" "></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD width="60%"><asp:label id="Label3" runat="server" Width="100%" Height="15px" CssClass="Lables">Whether qualified to study II year class of Intermediate Course? (In case of student leaving after completing 1st year class)</asp:label></TD>
								<TD width="20%"><asp:dropdownlist id="DrpIIyear" runat="server" Width="120px" CssClass=" ">
										<asp:ListItem Value="1" Selected="True">YES</asp:ListItem>
										<asp:ListItem Value="2">N/A</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD width="60%"><asp:label id="Label5" runat="server" Width="100%" Height="15px" CssClass="Lables">Whether the pupil has been declared eligible by the Board of Intermediate Education for University Course of Study.</asp:label></TD>
								<TD width="20%"><asp:dropdownlist id="Drpbieucs" runat="server" Width="120px" CssClass=" ">
										<asp:ListItem Value="0" Selected="True">--Select--</asp:ListItem>
										<asp:ListItem Value="1">YES</asp:ListItem>
										<asp:ListItem Value="2">NO</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD width="60%" style="HEIGHT: 18px"><asp:label id="Label6" runat="server" Width="100%" Height="15px" CssClass="Lables">Date on which the pupil has actually left the College :</asp:label></TD>
								<TD style="HEIGHT: 18px"><asp:textbox id="TxtDateleaving" runat="server" Width="110px"></asp:textbox><asp:label id="Label2" runat="server" ForeColor="Red">Ex : dd/mm/yyyy</asp:label></TD>
							</TR>
							<TR>
								<TD width="60%" style="HEIGHT: 2px"><asp:label id="Label7" runat="server" Width="100%" Height="15px" CssClass="Lables">TC DATE :</asp:label></TD>
								<TD style="HEIGHT: 2px"><asp:textbox id="TxtTcDate" runat="server" Width="110px"></asp:textbox><asp:label id="Label10" runat="server" ForeColor="Red">Ex : dd/mm/yyyy</asp:label></TD>
							</TR>
							<TR>
								<TD align="right" colSpan="2">
									<asp:Button id="btnGeneratenewTC" runat="server" Height="24px" Text="Generate" Font-Size="Larger"
										Font-Bold="True" Visible="TRUE"></asp:Button><asp:button id="BtnTc" runat="server" Height="24px" Font-Bold="True" Font-Size="Larger" Text="Priview"></asp:button><asp:button id="btnGenerate" runat="server" Height="24px" Font-Bold="True" Font-Size="Larger"
										Text="Generate" Enabled="False"></asp:button><asp:dropdownlist id="DrpQualifiedUniv" runat="server" Width="0px" CssClass=" ">
										<asp:ListItem Value="0" Selected="True">NONE</asp:ListItem>
										<asp:ListItem Value="1">YES</asp:ListItem>
										<asp:ListItem Value="2">NO</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD align="right" colSpan="2">
									<TABLE id="Table2" style="WIDTH: 967px; HEIGHT: 24px" cellSpacing="1" cellPadding="1" width="967"
										border="0">
										<TR>
											<TD style="WIDTH: 49px; HEIGHT: 15px"><FONT color="#ff3333" size="3"><STRONG>Note:*</STRONG></FONT></TD>
											<TD style="WIDTH: 19px; HEIGHT: 15px"><STRONG><FONT size="3">1.</FONT></STRONG></TD>
											<TD style="HEIGHT: 15px">
												<P><FONT size="3"><FONT color="#ff3300"><STRONG>Select On your Browser and&nbsp; as per 
																instructions *</STRONG><U> </U></FONT><FONT color="#336600"><STRONG><U>View&gt;Text 
																	Size&gt; Medium.</U></STRONG></FONT></FONT></P>
											</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 49px"></TD>
											<TD style="WIDTH: 19px"><FONT size="3"><STRONG>2.</STRONG></FONT></TD>
											<TD><FONT color="#ff9900"><FONT color="#ff3300" size="3"><STRONG>Select Pageset up And Clear 
															Header And Footer(<FONT color="#336600"><U>Should Be&nbsp;Empty On the Fields</U></FONT>)&nbsp;,And 
															Select <U>Lega</U>l.</STRONG></FONT></FONT></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 49px"></TD>
											<TD style="WIDTH: 19px"><STRONG><FONT size="3">3.</FONT></STRONG></TD>
											<TD><FONT color="#ff9900"><FONT color="#ff3300" size="3"><STRONG>Select Printer With <FONT color="#336600">
																<U>Legal Paper</U></FONT> and give print.</STRONG></FONT></FONT></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
						<P align="center">
							<TABLE id="Tablecc" style="WIDTH: 517px; HEIGHT: 149px" cellSpacing="1" cellPadding="1"
								width="517" border="1" runat="server">
								<TR>
									<TD>
										<P>
											<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0" runat="server">
												<TR>
													<TD colSpan="2"><asp:label id="Label12" runat="server" Width="100%" CssClass="SubHeading1">BONAFIDE AND CONDUCT CERTIFICATE</asp:label></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 734px" width="734"><asp:label id="Label11" runat="server" Width="400px" Height="15px" CssClass="Lables">Student of this College and Studying / Studied in Year</asp:label></TD>
													<TD width="20%"><asp:dropdownlist id="DrpStdYear" runat="server" Width="110px" CssClass=" "></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 734px" width="734"><asp:label id="Label8" runat="server" Width="400px" Height="15px" CssClass="Lables">During the Academic Year From</asp:label></TD>
													<TD><asp:textbox id="Txtfrom" runat="server" Width="110px"></asp:textbox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 734px" width="734"><asp:label id="Label9" runat="server" Width="400px" Height="15px" CssClass="Lables">During the Academic Year To</asp:label></TD>
													<TD><asp:textbox id="Txtto" runat="server" Width="110px"></asp:textbox></TD>
												</TR>
												<TR>
													<TD align="right" colSpan="2">
														<asp:Button id="btnGeneratenewCC" runat="server" Height="24px" Visible="TRUE" Font-Bold="True"
															Font-Size="Larger" Text="Generate"></asp:Button><asp:button id="BtnCc" runat="server" Height="24px" Font-Bold="True" Font-Size="Larger" Text="Priview"></asp:button><asp:button id="btnCCGenerate" runat="server" Height="24px" Font-Bold="True" Font-Size="Larger"
															Text="Generate" Visible="False" Enabled="False"></asp:button><asp:dropdownlist id="Dropdownlist1" runat="server" Width="0px" CssClass=" ">
															<asp:ListItem Value="0" Selected="True">NONE</asp:ListItem>
															<asp:ListItem Value="1">YES</asp:ListItem>
															<asp:ListItem Value="2">NO</asp:ListItem>
														</asp:dropdownlist></TD>
												</TR>
											</TABLE>
										</P>
									</TD>
								</TR>
							</TABLE>
						</P>
						<P>&nbsp;</P>
						<P></P>
					</TD>
				</TR>
				<TR>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
