<%@ Page Language="vb" AutoEventWireup="false" Codebehind="StudentBoardDetailsEntryTC.aspx.vb" Inherits="CollegeBoard.StudentBoardDetailsEntryTC" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>StudentBoardDetailsEntryNew</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../Images/Login/StyleSheet.css" type="text/css" rel="stylesheet">
	    <style type="text/css">
            .auto-style1 {
                width: 131px;
            }
            .auto-style2 {
                height: 15px;
                width: 131px;
            }
            .auto-style3 {
                height: 3px;
                width: 131px;
            }
            </style>
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
																	<TD style="WIDTH: 184px"><asp:textbox id="txtSName" runat="server" Width="178px" CssClass="textboxASR" ReadOnly="True"></asp:textbox></TD>
																	<TD style="WIDTH: 82px"><asp:label id="Label2" runat="server" Width="80px" CssClass="LABLES">Father Name</asp:label></TD>
																	<TD><asp:textbox id="txtFname" runat="server" Width="144px" CssClass="textboxASR" ReadOnly="True"></asp:textbox></TD>
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
														<TD class="DarkColor">
															<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD vAlign="top" width="11"></TD>
																	<TD class="SubHeading">Student TC Information</TD>
																	<TD vAlign="top" width="11"></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD class="TableBorder" vAlign="top">
															<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	
																	<TD style="WIDTH: 53px"><asp:label id="Label31" runat="server" Width="82px" CssClass="LABLES">G.RNO:</asp:label></TD>
																	<TD style="WIDTH: 184px"><asp:textbox id="txtGRO" runat="server" Width="180px" CssClass="textboxASR" ></asp:textbox></TD>
																 <TD style="WIDTH: 78px"><asp:label id="Label34" runat="server" Width="85px" CssClass="LABLES" Visible="false">UDISE NO:</asp:label></TD>
																	<TD><asp:textbox id="txtudise" runat="server" Width="144px" CssClass="textboxASR"   Visible="false"></asp:textbox></TD>
																	<TD style="WIDTH: 78px"><asp:label id="Label35" runat="server" Width="85px" CssClass="LABLES" Visible="false">INDEX No:</asp:label></TD>
																	<TD><asp:textbox id="txtcodenum" runat="server" Width="144px" CssClass="textboxASR" Visible="false" ></asp:textbox></TD>
																</TR>
																
                                                                <TR>
                                                                    <%--<TD style="WIDTH: 78px"><asp:label id="Label36" runat="server" Width="85px" CssClass="LABLES">Student ID:</asp:label></TD>
																	<TD><asp:textbox id="txtstudentId" runat="server" Width="180px" CssClass="textboxASR" ></asp:textbox></TD>--%>
																	<TD style="HEIGHT: 14px"><asp:label id="Label9" runat="server" Width="100%" CssClass="LABLES">DateofBirth*</asp:label></TD>
																	<TD style="WIDTH: 127px; HEIGHT: 14px"><asp:textbox id="TxtDob" runat="server" Width="144px" CssClass="textboxASR"></asp:textbox></TD>
                                                                    <TD style="WIDTH: 78px"><asp:label id="Label33" runat="server" Width="85px" CssClass="LABLES">Medium</asp:label></TD>
																	<TD><asp:dropdownlist id="drpmedium" runat="server" Width="139px" CssClass="textboxASR" Height="16px"></asp:dropdownlist></TD></TD>
																</TR>
                                                                <TR runat="server" visible="false">
																	
																	<TD style="WIDTH: 56px"><asp:label id="Label38" runat="server" Width="85px" CssClass="LABLES">Dist:</asp:label></TD>
																	<TD><asp:textbox id="Textbox1" runat="server" Width="180px" CssClass="textboxASR" ></asp:textbox></TD>
                                                                    <TD style="WIDTH: 78px"><asp:label id="Label39" runat="server" Width="85px" CssClass="LABLES">State:</asp:label></TD>
																	<TD><asp:textbox id="Textbox2" runat="server" Width="144px" CssClass="textboxASR" ></asp:textbox></TD>
                                                                      <TD style="WIDTH: 78px"><asp:label id="Label40" runat="server" Width="85px" CssClass="LABLES">Country:</asp:label></TD>
																	<TD><asp:textbox id="Textbox3" runat="server" Width="144px" CssClass="textboxASR" ></asp:textbox></TD>
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
                                                                <TR><td><asp:label id="Label26" runat="server" Width="150px" CssClass="LABLES">Code-College</asp:label></td>
                                                                    <td><asp:dropdownlist id="DrpColl" runat="server" Width="300px" CssClass="textboxASR" Height="17px"></asp:dropdownlist></td>
                                                                    <td><asp:label id="Label7" runat="server" Width="96px" CssClass="LABLES" Height="18px">Student ID:</asp:label></td>
                                                                    <td><asp:textbox id="txtboardadmno" runat="server" Width="225px" CssClass="textboxASR" Height="22px" ></asp:textbox></td>
                                                                    <td><asp:label id="Label29" runat="server" Width="100px" CssClass="LABLES">UID(Adhar No) *</asp:label></td>
                                                                    <td><asp:textbox id="txtAadhar" runat="server" Width="110px" CssClass="textboxASR" MaxLength="12" Height="22px"></asp:textbox></td></TR>
																<TR>
																	
																	
																	<TD style="WIDTH: 98px"><asp:label id="Label20" runat="server" Width="187%" CssClass="LABLES">Name *</asp:label></TD>
																	<TD><asp:textbox id="TxtBName" runat="server" Width="300px" CssClass="textboxASR" MaxLength="100"></asp:textbox></TD>
                                                                    <TD style="WIDTH: 98px"><asp:label id="Label21" runat="server" Width="100%" CssClass="LABLES">Father&nbsp;Name *</asp:label></TD>
																	<TD class="auto-style1"><asp:textbox id="TxtBFname" runat="server" Width="225px" CssClass="textboxASR" MaxLength="60"></asp:textbox></TD>
                                                                    <TD style="WIDTH: 98px; HEIGHT: 2px"><asp:label id="Label14" runat="server" Width="100%" CssClass="LABLES">Mother&nbsp;Name *</asp:label></TD>
																	<TD style="HEIGHT: 2px"><asp:textbox id="TxtBMname" runat="server" Width="98%" CssClass="textboxASR" MaxLength="60"></asp:textbox></TD>
																</TR>
                                                                <TR>
																																		
																	<TD style="WIDTH: 98px"><asp:label id="Label11" runat="server" Width="187%" CssClass="LABLES">SurName</asp:label></TD>
																	<TD><asp:textbox id="TxtSName2" runat="server" Width="300px" CssClass="textboxASR" MaxLength="100"></asp:textbox></TD>                                                                    
																</TR>
																<TR>
																	<TD><asp:label id="Label8" runat="server" Width="100%" CssClass="LABLES">Religion*</asp:label></TD>
																	<TD style="WIDTH: 127px"><asp:dropdownlist id="DrpComm" runat="server" Width="300px" CssClass="textboxASR" Height="25px"></asp:dropdownlist></TD>
																	<TD style="WIDTH: 98px"><asp:label id="Label16" runat="server" Width="100%" CssClass="LABLES">Caste *</asp:label></TD>
																	<TD style="WIDTH: 98px"><asp:dropdownlist id="DrpCaste" runat="server" Width="225%" CssClass="textboxASR" AutoPostBack="True" Height="20px"></asp:dropdownlist></TD>
																	<TD style="WIDTH: 98px">
																		<asp:label id="Label28" runat="server" Width="100%" CssClass="LABLES">Sub Caste *</asp:label></TD>
																	<TD style="WIDTH: 127px; HEIGHT: 2px">
																		<asp:dropdownlist id="DrpSubCaste" runat="server" Width="110px" CssClass="textboxASR" Height="16px"></asp:dropdownlist></TD>
																	
																</TR>
															
															
																<TR>
																	<TD style="HEIGHT: 15px"><asp:label id="Label10" runat="server" Width="100%" CssClass="LABLES">YearofPass</asp:label></TD>
																	<TD style="WIDTH: 127px; HEIGHT: 15px"><asp:dropdownlist id="DrpYOp" runat="server" Width="300px" CssClass="textboxASR" Height="25px"></asp:dropdownlist></TD>
																<TD style="HEIGHT: 15px"><asp:label id="Label12" runat="server" Width="100%" CssClass="LABLES">Prev.School Name</asp:label></TD>
																	<TD class="auto-style2"><asp:textbox id="txtprvscl" runat="server" Width="225px" CssClass="textboxASR" Height="22px"></asp:textbox></TD>
																	<TD style="HEIGHT: 15px"><asp:label id="Label13" runat="server" Width="100%" CssClass="LABLES">Prev.Class </asp:label></TD>
																	<TD style="WIDTH: 127px; HEIGHT: 15px"><asp:textbox id="txtprvclass" runat="server" Width="110px" CssClass="textboxASR"></asp:textbox></TD>
																</TR>
																
																<TR>
																	<TD style="WIDTH: 78px; HEIGHT: 15px"><asp:label id="Label5" runat="server" Width="188%" CssClass="LABLES">DateofAdmn*</asp:label></TD>
																	<TD style="WIDTH: 127px; HEIGHT: 15px"><asp:textbox id="TxtDtAdm" runat="server" Width="300px" CssClass="textboxASR" Height="18px"></asp:textbox></TD>
																	
																	<TD style="WIDTH: 78px; HEIGHT: 15px"><asp:label id="Label6" runat="server" Width="95%" CssClass="LABLES" Height="17px">Admited&nbsp;Class*</asp:label></TD>
																	<TD class="auto-style3"><asp:dropdownlist id="DrpCourse" runat="server" Width="225px" CssClass="textboxASR" Height="19px"></asp:dropdownlist></TD>
                                                                    <TD style="WIDTH: 98px; HEIGHT: 15px"><asp:label id="Label41" runat="server" Width="100%" CssClass="LABLES">Country</asp:label></TD>
																	<TD style="WIDTH: 122px; HEIGHT: 15px"><asp:textbox id="txtCountry" runat="server" Width="110px" CssClass="textboxASR" MaxLength="35"></asp:textbox></TD>
																</TR>
                                                                <TR>
                                                                    <td><asp:label id="Label42" runat="server" Width="100%" CssClass="LABLES">Place of Birth(City/Village)</asp:label></td>
                                                                    <td><asp:textbox id="txtVillage" runat="server" Width="300px" CssClass="textboxASR" MaxLength="35"></asp:textbox></td>
                                                                    <td><asp:label id="Label43" runat="server" Width="100%" CssClass="LABLES">District</asp:label></td>
                                                                    <td><asp:textbox id="txtDistrict" runat="server" Width="225px" CssClass="textboxASR" Height="22px" MaxLength="35"></asp:textbox></td>
                                                                    <td><asp:label id="Label44" runat="server" Width="100%" CssClass="LABLES">State</asp:label></td>
                                                                    <td><asp:textbox id="txtState" runat="server" Width="110px" CssClass="textboxASR" MaxLength="35"></asp:textbox></td>
                                                                </TR>
																<TR>
                                                                    
																	<TD style="WIDTH: 98px; HEIGHT: 3px"><asp:label id="lblBoardBranch" runat="server" Width="190%" CssClass="Lables">Board&nbsp;Branch *</asp:label></TD>
																	<TD style="HEIGHT: 3px"><asp:dropdownlist id="drpAdmBranch" runat="server" Width="300px" CssClass="textboxASR" Height="16px"></asp:dropdownlist></TD>
                                                                    <TD style="WIDTH: 98px; HEIGHT: 6px"><asp:label id="Label24" runat="server" Width="121%" CssClass="LABLES">MotherTongue</asp:label></TD>
																	<TD>
																		<asp:dropdownlist id="DrpMotherTounge" runat="server" Width="225px" CssClass="textboxASR" Height="31px"></asp:dropdownlist></TD>
                                                                     <TD style="WIDTH: 98px; HEIGHT: 6px"><asp:label id="Label15" runat="server" Width="98%" CssClass="LABLES">NSpira Admno*</asp:label></TD>
																	<TD style="WIDTH: 127px; HEIGHT: 15px"><asp:textbox id="txtnspiradmno" runat="server" Width="110px" CssClass="textboxASR"></asp:textbox></TD>
																</TR>
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
