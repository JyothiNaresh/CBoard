<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="StudentBoardDetailsRes.aspx.vb" Inherits="CollegeBoard.StudentBoardDetailsRes" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>StudentBoardDetailsRes</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../Images/Login/StyleSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" style="Z-INDEX: 102; POSITION: absolute; TOP: 8px; LEFT: 8px" cellSpacing="1"
				cellPadding="1" width="100%" border="0">
				<TR>
					<TD vAlign="top" align="center">
						<TABLE id="Table1" style="WIDTH: 795px" cellSpacing="0" cellPadding="1" width="795" align="center"
							border="1">
							<TR>
								<TD vAlign="top" nowrap="nowrap" align="left">
									<TABLE id="Table2" style="WIDTH: 788px" height="216" cellSpacing="0" cellPadding="0" width="788"
										align="center" border="0">
										<TR>
											<TD vAlign="top" align="center">
												<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD class="TopLine">
															<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD class="Heading" style="WIDTH: 216px" width="216"><asp:textbox id="txtAdmno" runat="server" Width="0px"></asp:textbox>STUDENT 
																		BOARD DETAILS</TD>
																	<TD align="right" width="25%">
																		<TABLE style="WIDTH: 161px; HEIGHT: 24px" cellSpacing="0" cellPadding="0" width="161" border="0">
																			<TR>
																				<TD class="FormNoLable" nowrap="nowrap" width="31%"></TD>
																				<TD class="FormNoLable" vAlign="middle" nowrap="nowrap" align="center" width="31%"><asp:label id="lblFound" runat="server" Width="144px" CssClass="Lables"></asp:label><asp:label id="LblAdmNoSearch" runat="server" Width="72px" CssClass="Lables">Adm&nbsp;No *</asp:label></TD>
																				<TD width="132"><asp:textbox id="txtAdmNoSearch" runat="server" Width="56px" CssClass="textboxASR" MaxLength="7"></asp:textbox></TD>
																				<TD width="17%"><asp:label id="lblBranchSearch" runat="server" Width="55px" CssClass="Lables">Exam&nbsp;Branch</asp:label></TD>
																				<TD width="17%"><asp:dropdownlist id="drpBranchSearch" runat="server" Width="200px" CssClass="textboxASR"></asp:dropdownlist></TD>
																				<TD width="17%"><asp:imagebutton id="iBtnSearch" accessKey="E" runat="server" Width="80px" Height="20px" ImageUrl="../../../Images/NewImages/search.gif"></asp:imagebutton></TD>
																			</TR>
																		</TABLE>
																	</TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD nowrap="nowrap" align="center">&nbsp;</TD>
													</TR>
													<TR>
														<TD class="DarkColor">
															<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD vAlign="top" width="11"></TD>
																	<TD class="SubHeading">Student Information</TD>
																	<TD vAlign="top" width="11"></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD class="TableBorder" vAlign="top">
															<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD style="WIDTH: 78px"><asp:label id="Label3" runat="server" Width="85px" CssClass="LABLES">SurName</asp:label></TD>
																	<TD style="WIDTH: 147px"><asp:textbox id="txtSurName" runat="server" Width="144px" CssClass="textboxASR" ReadOnly="True"></asp:textbox></TD>
																	<TD style="WIDTH: 53px"><asp:label id="Label1" runat="server" Width="50px" CssClass="LABLES">Name</asp:label></TD>
																	<TD style="WIDTH: 184px"><asp:textbox id="txtSName" runat="server" Width="184px" CssClass="textboxASR" ReadOnly="True"></asp:textbox></TD>
																	<TD style="WIDTH: 82px"><asp:label id="Label2" runat="server" Width="80px" CssClass="LABLES">Father Name</asp:label></TD>
																	<TD><asp:textbox id="txtFname" runat="server" Width="100%" CssClass="textboxASR" ReadOnly="True"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD style="WIDTH: 78px"><asp:label id="Label4" runat="server" Width="85px" CssClass="LABLES">Code</asp:label></TD>
																	<TD style="WIDTH: 147px" colSpan="4"><asp:label id="LblCode" runat="server" Width="465px" CssClass="LABLES"></asp:label></TD>
																	<TD></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD class="SubHeading1" vAlign="top">Board Information</TD>
													</TR>
													<TR>
														<TD class="TableBorder" vAlign="top">
															<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD style="HEIGHT: 6px"><asp:label id="Label25" runat="server" Width="100%" CssClass="LABLES" Enabled="False">District</asp:label></TD>
																	<TD style="WIDTH: 127px; HEIGHT: 6px"><asp:dropdownlist id="DrpDist" runat="server" Width="100%" CssClass="textboxASR" Enabled="False"></asp:dropdownlist></TD>
																	<TD style="WIDTH: 98px; HEIGHT: 6px"><asp:label id="Label26" runat="server" Width="100%" CssClass="LABLES">Code-College</asp:label></TD>
																	<TD style="WIDTH: 97px; HEIGHT: 6px" colSpan="3"><asp:dropdownlist id="DrpColl" runat="server" Width="530px" CssClass="textboxASR"></asp:dropdownlist></TD>
																</TR>
																<TR>
																	<TD><asp:label id="Label7" runat="server" Width="100%" CssClass="LABLES" Enabled="False">Board&nbsp;ID</asp:label></TD>
																	<TD style="WIDTH: 127px"><asp:textbox id="TxtBid" runat="server" Width="100%" CssClass="textboxASR" MaxLength="5" ReadOnly="True"
																			Enabled="False"></asp:textbox></TD>
																	<TD style="WIDTH: 98px"><asp:label id="Label15" runat="server" Width="100%" CssClass="LABLES">Board&nbsp;AdmNo *</asp:label></TD>
																	<TD style="WIDTH: 122px"><asp:textbox id="TxtBAdmno" runat="server" Width="100%" CssClass="textboxASR" MaxLength="18"></asp:textbox></TD>
																	<TD style="WIDTH: 98px"><asp:label id="Label20" runat="server" Width="100%" CssClass="LABLES">Name *</asp:label></TD>
																	<TD><asp:textbox id="TxtBName" runat="server" Width="100%" CssClass="textboxASR" MaxLength="100"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD><asp:label id="Label8" runat="server" Width="100%" CssClass="LABLES">Community*</asp:label></TD>
																	<TD style="WIDTH: 127px"><asp:dropdownlist id="DrpComm" runat="server" Width="100%" CssClass="textboxASR"></asp:dropdownlist></TD>
																	<TD style="WIDTH: 98px"><asp:label id="Label16" runat="server" Width="100%" CssClass="LABLES">Caste *</asp:label></TD>
																	<TD style="WIDTH: 122px"><asp:dropdownlist id="DrpCaste" runat="server" Width="100%" CssClass="textboxASR" AutoPostBack="True"></asp:dropdownlist></TD>
																	<TD style="WIDTH: 98px"><asp:label id="Label21" runat="server" Width="100%" CssClass="LABLES">Father&nbsp;Name *</asp:label></TD>
																	<TD><asp:textbox id="TxtBFname" runat="server" Width="100%" CssClass="textboxASR" MaxLength="60"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD style="HEIGHT: 2px">
																		<asp:label id="Label28" runat="server" Width="100%" CssClass="LABLES">Sub Caste *</asp:label></TD>
																	<TD style="WIDTH: 127px; HEIGHT: 2px" colSpan="3">
																		<asp:dropdownlist id="DrpSubCaste" runat="server" Width="345px" CssClass="textboxASR"></asp:dropdownlist></TD>
																	<TD style="WIDTH: 98px; HEIGHT: 2px"><asp:label id="Label14" runat="server" Width="100%" CssClass="LABLES">Mother&nbsp;Name *</asp:label></TD>
																	<TD style="HEIGHT: 2px"><asp:textbox id="TxtBMname" runat="server" Width="100%" CssClass="textboxASR" MaxLength="60"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD style="HEIGHT: 14px"><asp:label id="Label9" runat="server" Width="100%" CssClass="LABLES">DateofBirth*</asp:label></TD>
																	<TD style="WIDTH: 127px; HEIGHT: 14px"><asp:textbox id="TxtDob" runat="server" Width="100%" CssClass="textboxASR"></asp:textbox></TD>
																	<TD style="WIDTH: 98px; HEIGHT: 14px"><asp:label id="Label17" runat="server" Width="100%" CssClass="LABLES">Previous&nbsp;Exam</asp:label></TD>
																	<TD style="WIDTH: 122px; HEIGHT: 14px"><asp:dropdownlist id="DrpPrvExm" runat="server" Width="100%" CssClass="textboxASR"></asp:dropdownlist></TD>
																	<TD style="WIDTH: 98px; HEIGHT: 14px"><asp:label id="Label22" runat="server" Width="100%" CssClass="LABLES">Previous&nbsp;Htno</asp:label></TD>
																	<TD style="HEIGHT: 14px"><asp:textbox id="TxtBhtno" runat="server" Width="100%" CssClass="textboxASR" MaxLength="100"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD style="HEIGHT: 15px"><asp:label id="Label10" runat="server" Width="100%" CssClass="LABLES">YearofPass</asp:label></TD>
																	<TD style="WIDTH: 127px; HEIGHT: 15px"><asp:dropdownlist id="DrpYOp" runat="server" Width="100%" CssClass="textboxASR"></asp:dropdownlist></TD>
																	<TD style="WIDTH: 98px; HEIGHT: 15px"><asp:label id="Label18" runat="server" Width="100%" CssClass="LABLES">Category *</asp:label></TD>
																	<TD style="WIDTH: 122px; HEIGHT: 15px"><asp:dropdownlist id="DrpCateg" runat="server" Width="100%" CssClass="textboxASR"></asp:dropdownlist></TD>
																	<TD style="WIDTH: 98px; HEIGHT: 15px"><asp:label id="Label23" runat="server" Width="100%" CssClass="LABLES">Blind&nbsp;or&nbsp;PH</asp:label></TD>
																	<TD style="HEIGHT: 15px"><asp:dropdownlist id="DrpPh" runat="server" Width="150px" CssClass="textboxASR"></asp:dropdownlist><asp:textbox id="TxtPhper" runat="server" Width="155px" CssClass="textboxASR" MaxLength="10"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD style="HEIGHT: 6px"><asp:label id="Label11" runat="server" Width="100%" CssClass="LABLES">First&nbsp;Lang.</asp:label></TD>
																	<TD style="WIDTH: 127px; HEIGHT: 6px"><asp:dropdownlist id="DrpFlang" runat="server" Width="100%" CssClass="textboxASR"></asp:dropdownlist></TD>
																	<TD style="WIDTH: 98px; HEIGHT: 6px"><asp:label id="Label19" runat="server" Width="100%" CssClass="LABLES">Second&nbsp;Lang. *</asp:label></TD>
																	<TD style="WIDTH: 122px; HEIGHT: 6px"><asp:dropdownlist id="DrpSlang" runat="server" Width="100%" CssClass="textboxASR"></asp:dropdownlist></TD>
																	<TD style="WIDTH: 98px; HEIGHT: 6px"><asp:label id="Label24" runat="server" Width="100%" CssClass="LABLES">MotherTongue *</asp:label></TD>
																	<TD style="HEIGHT: 6px">
																		<asp:dropdownlist id="DrpMotherTounge" runat="server" Width="150px" CssClass="textboxASR"></asp:dropdownlist></TD>
																</TR>
																<TR>
																	<TD style="WIDTH: 78px; HEIGHT: 3px"><asp:label id="Label5" runat="server" Width="100%" CssClass="LABLES">DateofAdmn*</asp:label></TD>
																	<TD style="WIDTH: 127px; HEIGHT: 3px"><asp:textbox id="TxtDtAdm" runat="server" Width="100%" CssClass="textboxASR"></asp:textbox></TD>
																	<TD style="WIDTH: 98px; HEIGHT: 3px"><asp:label id="Label6" runat="server" Width="100%" CssClass="LABLES">Admited&nbsp;Class*</asp:label></TD>
																	<TD style="WIDTH: 122px; HEIGHT: 3px"><asp:dropdownlist id="DrpCourse" runat="server" Width="100%" CssClass="textboxASR"></asp:dropdownlist></TD>
																	<TD style="WIDTH: 98px; HEIGHT: 3px"><asp:label id="lblBoardBranch" runat="server" Width="100%" CssClass="Lables">Board&nbsp;Branch *</asp:label></TD>
																	<TD style="HEIGHT: 3px"><asp:dropdownlist id="drpAdmBranch" runat="server" Width="305px" CssClass="textboxASR" Height="16px"></asp:dropdownlist></TD>
																</TR>
                                                                <tr>
                                                                    <TD style="WIDTH: 78px; HEIGHT: 3px"><asp:label id="Label29" runat="server" Width="100%" CssClass="LABLES">Aadhar No *</asp:label></TD>
                                                                    <TD style="WIDTH: 127px; HEIGHT: 3px"><asp:textbox id="txtAadhar" runat="server" Width="175%" CssClass="textboxASR" MaxLength="12"></asp:textbox></TD>
                                                                </tr>
																<TR>
																	<TD style="HEIGHT: 6px"><asp:label id="Label12" runat="server" Width="100%" CssClass="LABLES">1.&nbsp;A&nbsp;Mole&nbsp;on*</asp:label></TD>
																	<TD style="WIDTH: 98px" colSpan="5"><asp:textbox id="TxtMole1" runat="server" Width="755px" CssClass="textboxASR" MaxLength="200"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD><asp:label id="Label13" runat="server" Width="100%" CssClass="LABLES">2.&nbsp;A&nbsp;Mole&nbsp;on*</asp:label></TD>
																	<TD style="WIDTH: 98px" colSpan="5"><asp:textbox id="TxtMole2" runat="server" Width="755px" CssClass="textboxASR" MaxLength="200"></asp:textbox></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD vAlign="top" nowrap="nowrap" align="left">
															<asp:Label id="Label27" runat="server" Font-Bold="True" ForeColor="Red">* Fields Mandatory</asp:Label>&nbsp;</TD>
													</TR>
													<TR>
														<TD vAlign="top" nowrap="nowrap" align="right"><asp:imagebutton id="iBtnSave" accessKey="S" runat="server" Width="80px" Height="20px" ImageUrl="../../../Images/NewImages/save.gif"></asp:imagebutton></TD>
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
