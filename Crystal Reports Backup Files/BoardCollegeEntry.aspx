<%@ Page Language="vb" AutoEventWireup="false" Codebehind="BoardCollegeEntry.aspx.vb" Inherits="CollegeBoard.BoardCollegeEntry" %>
<%@ Register TagPrefix="uc1" TagName="AddressInfo" Src="../../UserControls/AddressInfo.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Installment</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../../Images/Login/StyleSheet.css">
	</HEAD>
	<body background="../../../Images/NewImages/innerpage-bg1.jpg" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE style="Z-INDEX: 101; POSITION: absolute; TOP: 8px; LEFT: 8px" id="Table4" border="0"
				cellSpacing="1" cellPadding="1" width="100%">
				<TR>
					<TD vAlign="top" align="center">
						<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="1" width="795" align="center">
							<TR>
								<TD vAlign="top" nowrap="nowrap" align="center">
									<TABLE style="WIDTH: 788px" id="Table2" border="0" cellSpacing="0" cellPadding="0" width="788"
										align="center" height="216">
										<TR>
											<TD vAlign="top" align="center">
												<TABLE border="0" cellSpacing="0" cellPadding="0" width="100%">
													<TR>
														<TD style="WIDTH: 740px" class="TopLine"></TD>
													</TR>
													<TR>
														<TD style="WIDTH: 739px" class="DarkColor">
															<TABLE border="0" cellSpacing="0" cellPadding="0" width="100%">
																<TR>
																	<TD vAlign="top" width="11"></TD>
																	<TD style="WIDTH: 821px" class="subHeading" align="center">COLLEGE ENTRY</TD>
																	<TD style="WIDTH: 26px" vAlign="top" width="26"></TD>
																</TR>
																<TR>
																	<TD vAlign="top" width="11"></TD>
																	<TD style="WIDTH: 821px" class="SubHeading">Board College Information</TD>
																	<TD style="WIDTH: 26px" vAlign="top" width="26"></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD style="WIDTH: 739px" class="TableBorder" vAlign="top">
															<TABLE id="Table3" border="0" cellSpacing="0" cellPadding="0" width="784">
																<TR>
																	<TD style="WIDTH: 106px"><asp:label id="Label4" runat="server" Width="100%" CssClass="LABLES">Code*</asp:label></TD>
																	<TD><asp:textbox id="TxtCollcode" runat="server" Width="144px" CssClass="textboxASR" ToolTip="Enter 5 Digit College Code"></asp:textbox></TD>
																	<TD><asp:label id="Label5" runat="server" Width="100%" CssClass="LABLES">College&nbsp;Name*</asp:label></TD>
																	<TD colSpan="3"><asp:textbox id="TxtCollName" runat="server" Width="100%" CssClass="textboxASR"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD style="WIDTH: 106px"><asp:label id="Label6" runat="server" Width="100%" CssClass="LABLES">Old&nbsp;Code</asp:label></TD>
																	<TD><asp:textbox id="Txtoldcode" runat="server" Width="144px" CssClass="textboxASR"></asp:textbox></TD>
																	<TD><asp:label id="Label7" runat="server" Width="100%" CssClass="LABLES">Name&nbsp;with&nbsp;Address*</asp:label></TD>
																	<TD colSpan="3"><asp:textbox id="TxtColadr" runat="server" Width="100%" CssClass="textboxASR"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD style="HEIGHT: 12px"><asp:label id="Label3" runat="server" Width="100%" CssClass="LABLES">College&nbsp;Type</asp:label></TD>
																	<TD style="HEIGHT: 12px"><asp:dropdownlist id="DrpColltype" runat="server" Width="144px" CssClass=" " AutoPostBack="True"></asp:dropdownlist></TD>
																	<TD style="HEIGHT: 12px"><asp:label id="Label1" runat="server" Width="100%" CssClass="LABLES">Narayana&nbsp;Jr&nbsp;College</asp:label></TD>
																	<TD style="HEIGHT: 12px"><asp:dropdownlist id="DrpNarayana" runat="server" Width="144px" CssClass=" " AutoPostBack="True">
																			<asp:ListItem Value="2">Yes</asp:ListItem>
																			<asp:ListItem Value="1">No</asp:ListItem>
																			<asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
																		</asp:dropdownlist></TD>
																	<TD style="WIDTH: 109px; HEIGHT: 12px"><asp:label id="Label2" runat="server" Width="100%" CssClass="LABLES">Narayana&nbsp;Group</asp:label></TD>
																	<TD style="HEIGHT: 12px"><asp:dropdownlist id="DrpGroup" runat="server" Width="144px" CssClass=" " AutoPostBack="True">
																			<asp:ListItem Value="2">Yes</asp:ListItem>
																			<asp:ListItem Value="1">No</asp:ListItem>
																			<asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
																		</asp:dropdownlist></TD>
																</TR>
																<TR>
																	<TD style="HEIGHT: 17px"><asp:label id="Label8" runat="server" Width="100%" CssClass="LABLES">Year&nbsp;of&nbsp;Start*</asp:label></TD>
																	<TD style="HEIGHT: 17px"><asp:textbox id="TxtYos" runat="server" Width="144px" CssClass="textboxASR"></asp:textbox></TD>
																	<TD style="HEIGHT: 17px"><asp:label id="Label9" runat="server" Width="100%" CssClass="LABLES">Corporate&nbsp;College</asp:label></TD>
																	<TD style="HEIGHT: 17px"><asp:dropdownlist id="drpCorpColl" runat="server" Width="100%" CssClass=" " AutoPostBack="True"></asp:dropdownlist></TD>
																	<TD style="HEIGHT: 17px"><asp:label id="Label10" runat="server" Width="100%" CssClass="LABLES">Board&nbsp;District</asp:label></TD>
																	<TD style="HEIGHT: 17px"><asp:dropdownlist id="DrpBoardDist" runat="server" Width="100%" CssClass=" " AutoPostBack="True"></asp:dropdownlist></TD>
																</TR>
																<TR>
																	<TD><asp:label id="Label11" runat="server" Width="100%" CssClass="LABLES">Description</asp:label></TD>
																	<TD colSpan="5"><asp:textbox id="TxtDesc" runat="server" Width="100%" CssClass="textboxASR"></asp:textbox></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD style="WIDTH: 739px" class="SubHeading1" vAlign="top">Address Information</TD>
													</TR>
													<TR>
														<TD style="WIDTH: 739px" class="TableBorder" vAlign="top"><uc1:addressinfo id="UcAddress" runat="server"></uc1:addressinfo></TD>
													</TR>
													<TR>
														<TD style="WIDTH: 739px" class="TableBorder" vAlign="top"></TD>
													</TR>
													<TR>
														<TD style="WIDTH: 739px" class="SubHeading1" vAlign="top">Other Information</TD>
													</TR>
													<TR>
														<TD style="WIDTH: 739px; HEIGHT: 143px" class="TableBorder" vAlign="top">
															<TABLE style="WIDTH: 780px; HEIGHT: 326px" id="Table5" border="0" cellSpacing="0" cellPadding="0"
																width="780">
																<TR>
																	<TD style="WIDTH: 105px"><asp:label id="Label12" runat="server" Width="112px" CssClass="LABLES" Height="19px">Loc of the College</asp:label></TD>
																	<TD style="WIDTH: 127px"><asp:dropdownlist id="drploc" runat="server" Width="144px" CssClass=" ">
																			<asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
																			<asp:ListItem Value="1">CROP</asp:ListItem>
																			<asp:ListItem Value="2">MUNC</asp:ListItem>
																			<asp:ListItem Value="3">MDL</asp:ListItem>
																			<asp:ListItem Value="4">PAN</asp:ListItem>
																		</asp:dropdownlist></TD>
																	<TD><asp:label id="Label14" runat="server" Width="100%" CssClass="LABLES">Principal Name</asp:label></TD>
																	<TD style="WIDTH: 129px"><asp:textbox id="Textbox2" runat="server" Width="144px" CssClass="textboxASR" ToolTip="Enter 5 Digit College Code"></asp:textbox></TD>
																	<TD style="WIDTH: 116px"><asp:label id="Label15" runat="server" Width="112px" CssClass="LABLES">Principal Mobile </asp:label></TD>
																	<TD><asp:textbox id="Textbox3" runat="server" Width="144px" CssClass="textboxASR" ToolTip="Enter 5 Digit College Code"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD style="WIDTH: 105px"><asp:label id="Label27" runat="server" Width="105%" CssClass="LABLES">Zone</asp:label></TD>
																	<TD style="WIDTH: 127px"><asp:textbox id="Textbox4" runat="server" Width="144px" CssClass="textboxASR" ToolTip="Enter 5 Digit College Code"></asp:textbox></TD>
																	<TD><asp:label id="Label25" runat="server" Width="100%" CssClass="LABLES">Clg Bank Branch</asp:label></TD>
																	<TD style="WIDTH: 129px"><asp:textbox id="Textbox5" runat="server" Width="144px" CssClass="textboxASR" ToolTip="Enter 5 Digit College Code"></asp:textbox></TD>
																	<TD style="WIDTH: 116px"><asp:label id="Label26" runat="server" Width="100%" CssClass="LABLES" Height="8px">Running Status</asp:label></TD>
																	<TD><asp:dropdownlist id="drpclgrun" runat="server" Width="144px" CssClass=" ">
																			<asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
																			<asp:ListItem Value="1">FUNCTIONING</asp:ListItem>
																			<asp:ListItem Value="2">NON FUNCTIONING</asp:ListItem>
																		</asp:dropdownlist></TD>
																</TR>
																<TR>
																	<TD style="WIDTH: 105px; HEIGHT: 20px"><asp:label id="Label29" runat="server" Width="105%" CssClass="LABLES">Name of I/c</asp:label></TD>
																	<TD style="WIDTH: 127px; HEIGHT: 20px"><asp:textbox id="Textbox6" runat="server" Width="144px" CssClass="textboxASR" ToolTip="Enter 5 Digit College Code"></asp:textbox></TD>
																	<TD style="HEIGHT: 20px"><asp:label id="Label30" runat="server" Width="103px" CssClass="LABLES"> I/C Mobile No</asp:label></TD>
																	<TD style="WIDTH: 129px; HEIGHT: 20px"><asp:textbox id="Textbox7" runat="server" Width="144px" CssClass="textboxASR" ToolTip="Enter 5 Digit College Code"></asp:textbox></TD>
																	<TD style="WIDTH: 116px; HEIGHT: 20px"><asp:label id="Label31" runat="server" Width="100%" CssClass="LABLES">Board Clerk Name</asp:label></TD>
																	<TD style="HEIGHT: 20px"><asp:textbox id="Textbox8" runat="server" Width="144px" CssClass="textboxASR" ToolTip="Enter 5 Digit College Code"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD style="WIDTH: 105px"><asp:label id="Label32" runat="server" Width="105%" CssClass="LABLES">Mobile No</asp:label></TD>
																	<TD style="WIDTH: 127px"><asp:textbox id="Textbox9" runat="server" Width="144px" CssClass="textboxASR" ToolTip="Enter 5 Digit College Code"></asp:textbox></TD>
																	<TD><asp:label id="Label33" runat="server" Width="100%" CssClass="LABLES">LOI GO No</asp:label></TD>
																	<TD style="WIDTH: 129px"><asp:textbox id="Textbox10" runat="server" Width="144px" CssClass="textboxASR" ToolTip="Enter 5 Digit College Code"></asp:textbox></TD>
																	<TD style="WIDTH: 116px"><asp:label id="Label34" runat="server" Width="100%" CssClass="LABLES">LOI GO Date</asp:label></TD>
																	<TD><asp:textbox id="Textbox11" runat="server" Width="144px" CssClass="textboxASR" ToolTip="Enter 5 Digit College Code"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD style="WIDTH: 105px"></TD>
																	<TD style="WIDTH: 127px"></TD>
																	<TD></TD>
																	<TD style="WIDTH: 129px"></TD>
																	<TD style="WIDTH: 116px"></TD>
																	<TD></TD>
																</TR>
																<TR>
																	<TD style="HEIGHT: 55px" colSpan="6">
																		<TABLE id="Table10" border="0" cellSpacing="0" cellPadding="0" width="100%">
																			<TR>
																				<TD><asp:label id="Label22" runat="server" Width="776px" CssClass="LABLES">Groups</asp:label></TD>
																			</TR>
																			<TR>
																				<TD><asp:checkboxlist id="Chkgroup" runat="server" Width="100%" CssClass="Lables" Height="10px" RepeatColumns="5"></asp:checkboxlist></TD>
																			</TR>
																		</TABLE>
																	</TD>
																</TR>
																<TR>
																	<TD colSpan="6">
																		<TABLE id="Table8" border="0" cellSpacing="0" cellPadding="0" width="100%">
																			<TR>
																				<TD style="WIDTH: 244px"><asp:label id="Label19" runat="server" Width="776px" CssClass="LABLES">Second Language</asp:label></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 244px"><asp:checkboxlist id="ChkSLang" runat="server" Width="100%" CssClass="Lables" Height="2px" RepeatColumns="5"></asp:checkboxlist></TD>
																			</TR>
																		</TABLE>
																	</TD>
																</TR>
																<TR>
																	<TD colSpan="6">
																		<TABLE id="Table9" border="0" cellSpacing="0" cellPadding="0" width="100%">
																			<TR>
																				<TD style="WIDTH: 106px"><asp:label id="Label20" runat="server" Width="775px" CssClass="LABLES">Sanctioned Media</asp:label></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 106px"><asp:checkboxlist id="ChkMedium" runat="server" Width="100%" CssClass="Lables" RepeatColumns="5"></asp:checkboxlist></TD>
																			</TR>
																		</TABLE>
																		<TABLE style="WIDTH: 384px; HEIGHT: 44px" id="Table11" border="0" cellSpacing="0" cellPadding="0"
																			width="384">
																			<TR>
																				<TD><asp:label id="Label23" runat="server" Width="100%" CssClass="LABLES">Whether submitted for latest Affiliation</asp:label></TD>
																				<TD><asp:dropdownlist id="drpafflatest" runat="server" Width="144px" CssClass=" ">
																						<asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
																						<asp:ListItem Value="1">YES</asp:ListItem>
																						<asp:ListItem Value="2">NO</asp:ListItem>
																					</asp:dropdownlist></TD>
																			</TR>
																			<TR>
																				<TD><asp:label id="Label21" runat="server" Width="100%" CssClass="LABLES">College or School</asp:label></TD>
																				<TD><asp:dropdownlist id="drpclgsch" runat="server" Width="144px" CssClass=" " AutoPostBack="True">
																						<asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
																						<asp:ListItem Value="1">COLLEGE</asp:ListItem>
																						<asp:ListItem Value="2">SCHOOL</asp:ListItem>
																					</asp:dropdownlist></TD>
																			</TR>
																		</TABLE>
																	</TD>
																</TR>
															</TABLE>
															<TABLE id="Table6" border="0" cellSpacing="0" cellPadding="0" width="384" runat="server">
																<TR>
																	<TD style="WIDTH: 234px"><asp:label id="Label37" runat="server" Width="232px" CssClass="LABLES">For Schools Affiliation Nos</asp:label></TD>
																	<TD></TD>
																</TR>
																<TR>
																	<TD style="WIDTH: 234px"><asp:label id="Label38" runat="server" Width="100%" CssClass="LABLES">Ist to  V th</asp:label></TD>
																	<TD><asp:textbox id="Textbox12" runat="server" Width="144px" CssClass="textboxASR" ToolTip="Enter 5 Digit College Code"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD style="WIDTH: 234px"><asp:label id="Label39" runat="server" Width="100%" CssClass="LABLES">VI th to X th</asp:label></TD>
																	<TD><asp:textbox id="Textbox13" runat="server" Width="144px" CssClass="textboxASR" ToolTip="Enter 5 Digit College Code"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD style="WIDTH: 234px"></TD>
																	<TD></TD>
																</TR>
															</TABLE>
															<TABLE id="Table7" border="0" cellSpacing="0" cellPadding="0" width="384" runat="server">
																<TR>
																	<TD style="WIDTH: 234px"><asp:label id="Label18" runat="server" Width="100%" CssClass="LABLES">For College Proceedings No</asp:label></TD>
																	<TD></TD>
																</TR>
																<TR>
																	<TD style="WIDTH: 234px"><asp:label id="Label17" runat="server" Width="100%" CssClass="LABLES" Visible="False">Ist to  V th</asp:label></TD>
																	<TD><asp:textbox id="Textbox14" runat="server" Width="144px" CssClass="textboxASR" ToolTip="Enter 5 Digit College Code"
																			Visible="False"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD style="WIDTH: 234px"><asp:label id="Label16" runat="server" Width="100%" CssClass="LABLES" Visible="False">VI th to X th</asp:label></TD>
																	<TD><asp:textbox id="Textbox15" runat="server" Width="144px" CssClass="textboxASR" ToolTip="Enter 5 Digit College Code"
																			Visible="False"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD style="WIDTH: 234px"><asp:label id="Label13" runat="server" Width="100%" CssClass="LABLES">Approved Plan / BRS Given By Prod.No</asp:label></TD>
																	<TD><asp:textbox id="Textbox16" runat="server" Width="144px" CssClass="textboxASR" ToolTip="Enter 5 Digit College Code"></asp:textbox></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD style="WIDTH: 739px" vAlign="top" nowrap="nowrap" align="center">&nbsp;</TD>
													</TR>
													<TR>
														<TD style="WIDTH: 739px" vAlign="top" nowrap="nowrap" align="right"><asp:imagebutton accessKey="S" id="iBtnSave" runat="server" Width="80px" Height="20px" ImageUrl="../../../Images/NewImages/save.gif"></asp:imagebutton></TD>
													</TR>
												</TABLE>
											</TD>
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
