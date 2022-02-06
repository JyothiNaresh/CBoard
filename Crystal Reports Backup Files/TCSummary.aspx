<%@ Page Language="vb" AutoEventWireup="false" Codebehind="TCSummary.aspx.vb" Inherits="CollegeBoard.TCSummary" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>TCSummary</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK id="Link1" rel="stylesheet" type="text/css" href="../../../Images/Login/StyleSheet_Report_gk.css">
		<script language="javascript" type="text/javascript" src="../../Include/PanelSet.js"></script>
		<script type="text/javascript" src="../../Include/Slide/highslide-with-html.js"></script>
		<LINK rel="stylesheet" type="text/css" href="../../Include/Slide/highslide.css">
		<script type="text/javascript">
			hs.graphicsDir = '../../Include/Slide/Graphics/';
			hs.outlineType = 'rounded-white';
			hs.showCredits = false;
			hs.wrapperClassName = 'draggable-header';
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server" autocomplete="off">
			<TABLE id="Tablek" border="0" cellSpacing="1" cellPadding="1" width="100%">
				<TBODY>
					<TR>
						<TD vAlign="top" align="center"><asp:table id="TableMain1" runat="server" GridLines="Both" CellSpacing="0" CellPadding="4"
								BorderStyle="Solid" BorderColor="Chocolate" HorizontalAlign="Center"></asp:table><asp:table id="TableMain2" runat="server" GridLines="Both" CellSpacing="0" CellPadding="4"
								BorderStyle="Solid" BorderColor="Chocolate" HorizontalAlign="Center"></asp:table>
							<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" runat="server">
								<TR>
									<TD class="DarkColor">
										<TABLE id="Table2" border="0" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD vAlign="top" width="11"><IMG src="../../../Images/Login/table-lcorw.gif" width="11" height="11"></TD>
												<TD class="SubHeading"><asp:label id="lblHeading" runat="server" Font-Bold="True" CssClass="SubHeading1" Width="100%"> TC Report </asp:label></TD>
												<TD vAlign="top" width="11"><IMG src="../../../Images/Login/table-rcorw.gif" width="11" height="11"></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD class="TdBorder"><IMG src="../../../Images/Login/spacer.gif" width="1" height="1"></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 62px" class="TableBorder" vAlign="top" align="center">
										<TABLE id="Table10" border="0" cellSpacing="0" cellPadding="0" width="280">
											<TR>
												<TD vAlign="top"><asp:label id="Label14" runat="server" CssClass="Lables" Width="100%">ReportType</asp:label></TD>
												<TD vAlign="top" colSpan="3"><asp:dropdownlist id="drpReportType" runat="server" CssClass="DropDownList" Width="100%" AutoPostBack="True"
														Height="40px">
														<asp:ListItem Value="1">ExamBranch Wise</asp:ListItem>
														<asp:ListItem Value="2">Division Wise</asp:ListItem>
														<asp:ListItem Value="3">Zone Wise</asp:ListItem>
														<asp:ListItem Value="4">VC Wise</asp:ListItem>
													</asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 405px"><asp:radiobutton id="rdbRegion" runat="server" CssClass="Lables" Width="100%" AutoPostBack="True"
														GroupName="1" Checked="True" Text="Division"></asp:radiobutton></TD>
												<TD><asp:radiobutton id="rdbZone" runat="server" CssClass="Lables" Width="100%" AutoPostBack="True" GroupName="1"
														Text="Zone"></asp:radiobutton></TD>
												<TD><asp:radiobutton id="rdbDos" runat="server" CssClass="Lables" Width="100%" AutoPostBack="True" GroupName="1"
														Text="D.Os"></asp:radiobutton></TD>
												<TD><asp:radiobutton id="rdbVC" runat="server" CssClass="Lables" Width="100%" AutoPostBack="True" GroupName="1"
														Text="V.Cs"></asp:radiobutton></TD>
											</TR>
											<TR>
												<TD><asp:label id="lblRZ" runat="server" CssClass="Lables" Width="100%" Height="17px"> Division</asp:label></TD>
												<TD colSpan="3"><asp:dropdownlist id="drpRZ" runat="server" CssClass="DropDownList" Width="100%" AutoPostBack="True"
														Height="16px"></asp:dropdownlist></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD vAlign="top" colSpan="4" align="center">
										<TABLE id="Table12" border="0" cellSpacing="0" cellPadding="0">
											<TR>
												<TD><asp:label id="Label10" runat="server" CssClass="Lables" Width="100%">Exam Branch</asp:label></TD>
												<TD></TD>
												<TD style="WIDTH: 110px"><asp:label id="Label3" runat="server" CssClass="Lables" Width="150px">Selected</asp:label></TD>
											</TR>
											<TR>
												<TD vAlign="top"><asp:listbox id="LSTExamBranch" runat="server" CssClass=" " Width="160px" Height="241px" Rows="100"
														SelectionMode="Multiple"></asp:listbox></TD>
												<TD vAlign="top">
													<TABLE id="Table7" border="0" cellSpacing="0" cellPadding="0" width="30">
														<tr>
															<td>
																<P>&nbsp;</P>
																<P>&nbsp;</P>
															</td>
														</tr>
														<TR>
															<TD><asp:imagebutton id="BtnSelEB" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Select.gif"></asp:imagebutton></TD>
															<td></td>
														</TR>
														<TR>
															<TD><asp:imagebutton id="BtnSelEBAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/SelectAll.gif"></asp:imagebutton></TD>
															<td></td>
														</TR>
														<TR>
															<TD><asp:imagebutton id="BtnRemEB" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Remove.gif"></asp:imagebutton></TD>
															<td></td>
														</TR>
														<TR>
															<TD><asp:imagebutton id="BtnRemEBAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/RemoveAll.gif"></asp:imagebutton></TD>
															<td></td>
														</TR>
													</TABLE>
												</TD>
												<TD style="WIDTH: 110px" vAlign="top"><asp:listbox id="LSTSelExamBranch" runat="server" CssClass=" " Width="150px" Height="241px" Rows="20"
														SelectionMode="Multiple"></asp:listbox></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 284px; HEIGHT: 13px" class="TableBorder" vAlign="top" colSpan="3"
													align="center">
													<TABLE style="HEIGHT: 23px" id="Table3" border="1" cellSpacing="0" cellPadding="0" width="270">
														<TR>
															<TD><asp:label id="Label2" runat="server" CssClass="Lables" Width="74px" Height="19px">Report&nbsp;On</asp:label></TD>
															<TD><asp:dropdownlist id="DrpReporton" runat="server" CssClass="DropDownlist" Width="250px">
																	<asp:ListItem Value="1">SUMMARY</asp:ListItem>
																	<asp:ListItem Value="2">DETAILS</asp:ListItem>
																</asp:dropdownlist></TD>
														</TR>
														<tr>
															<TD><asp:label id="Label1" runat="server" CssClass="Lables" Width="74px" Height="19px">Course</asp:label></TD>
															<TD><asp:dropdownlist id="DrpCourse" runat="server" CssClass="DropDownlist" Width="250px">
																	<asp:ListItem Value="0" Selected="True">--ALL--</asp:ListItem>
																	<asp:ListItem Value="1">JUNIOR</asp:ListItem>
																	<asp:ListItem Value="2">SENIOR</asp:ListItem>
																</asp:dropdownlist></TD>
														</tr>
													</TABLE>
													<asp:checkbox style="Z-INDEX: 0" id="ChkDetails" runat="server" CssClass="lables" Width="87px"
														Text="Details" Visible="False"></asp:checkbox></TD>
											</TR>
											<TR>
												<TD class="TableBorder" vAlign="top" colSpan="3" align="right"><asp:imagebutton accessKey="R" id="iBtnReport" tabIndex="5" runat="server" Width="92px" Height="20px"
														ImageUrl="../../../Images/NewImages/report.gif"></asp:imagebutton></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 284px; HEIGHT: 13px" class="TableBorder" vAlign="top" colSpan="3"
													align="center"></TD>
											</TR>
										</TABLE>
									</TD>
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
