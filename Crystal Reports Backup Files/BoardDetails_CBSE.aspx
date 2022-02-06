<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="BoardDetails_CBSE.aspx.vb" Inherits="CollegeBoard.BoardDetails_CBSE" %>
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
																	<TD class="Heading" style="WIDTH: 216px" width="216"><asp:textbox id="txtAdmno" runat="server" Width="0px"></asp:textbox>STUDENT BOARD DETAILS</TD>
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
														<TD class="SubHeading1" vAlign="top">Board Information</TD>
													</TR>
													<TR>
														<TD class="TableBorder" vAlign="top">
															<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                                <TR><td><asp:label id="Label26" runat="server" Width="150px" CssClass="LABLES">Code-College</asp:label></td>
                                                                    <td><asp:dropdownlist id="DrpColl" runat="server" Width="300px" CssClass="textboxASR" Height="17px"></asp:dropdownlist></td>
                                                                    <td><asp:label id="Label7" runat="server" Width="96px" CssClass="LABLES" Height="18px">Board AdmNo:</asp:label></td>
                                                                    <td><asp:textbox id="txtboardadmno" runat="server" Width="225px" CssClass="textboxASR" Height="22px" ></asp:textbox></td>
                                                                    <td><asp:label id="Label29" runat="server" Width="100px" CssClass="LABLES" Visible="False">UID(Adhar No) *</asp:label></td>
                                                                    <td><asp:textbox id="txtAadhar" runat="server" Width="110px" CssClass="textboxASR" MaxLength="12" Height="22px" Visible="False"></asp:textbox></td></TR>
																<TR>
																	
																	
																	<TD style="WIDTH: 98px"><asp:label id="Label20" runat="server" Width="187%" CssClass="LABLES">Name *</asp:label></TD>
																	<TD><asp:textbox id="TxtBName" runat="server" Width="300px" CssClass="textboxASR" MaxLength="100"></asp:textbox></TD>
                                                                    <TD style="WIDTH: 98px"><asp:label id="Label21" runat="server" Width="100%" CssClass="LABLES">Father&nbsp;Name *</asp:label></TD>
																	<TD class="auto-style1"><asp:textbox id="TxtBFname" runat="server" Width="225px" CssClass="textboxASR" MaxLength="60"></asp:textbox></TD>
                                                                    <TD style="WIDTH: 98px; HEIGHT: 2px"><asp:label id="Label14" runat="server" Width="100%" CssClass="LABLES">Mother&nbsp;Name *</asp:label></TD>
																	<TD style="HEIGHT: 2px"><asp:textbox id="TxtBMname" runat="server" Width="98%" CssClass="textboxASR" MaxLength="60"></asp:textbox></TD>
																</TR>
                                                                <TR>
																																		
																	<TD style="HEIGHT: 14px"><asp:label id="Label9" runat="server" Width="100%" CssClass="LABLES">DateofBirth*</asp:label></TD>
																	<TD style="WIDTH: 127px; HEIGHT: 14px"><asp:textbox id="TxtDob" runat="server" Width="300px" CssClass="textboxASR"></asp:textbox></TD>  
                                                                    <TD><asp:label id="Label11" runat="server" Width="100%" CssClass="LABLES">Nationality*</asp:label></TD>
																	<TD style="WIDTH: 14px"><asp:textbox id="txtNationality" runat="server" Width="225px" CssClass="textboxASR"></asp:textbox></TD>                                                                
                                                                    <TD><asp:label id="Label8" runat="server" Width="100%" CssClass="LABLES">Religion*</asp:label></TD>
																	<TD style="WIDTH: 127px"><asp:dropdownlist id="DrpComm" runat="server" Width="225px" CssClass="textboxASR" Height="25px"></asp:dropdownlist></TD>
																</TR>
																<TR>
																	
																	<TD style="WIDTH: 98px"><asp:label id="Label16" runat="server" Width="151%" CssClass="LABLES">Caste *</asp:label></TD>
																	<TD style="WIDTH: 98px"><asp:dropdownlist id="DrpCaste" runat="server" Width="300%" CssClass="textboxASR" AutoPostBack="True" Height="20px"></asp:dropdownlist></TD>
																	<TD style="HEIGHT: 15px"><asp:label id="Label10" runat="server" Width="100%" CssClass="LABLES">YearofPass</asp:label></TD>
																	<TD style="WIDTH: 127px; HEIGHT: 15px"><asp:dropdownlist id="DrpYOp" runat="server" Width="225px" CssClass="textboxASR" Height="25px"></asp:dropdownlist></TD>
                                                                     <TD style="WIDTH: 78px; HEIGHT: 15px"><asp:label id="Label5" runat="server" Width="123%" CssClass="LABLES">DateofAdmn*</asp:label></TD>
																	<TD style="WIDTH: 127px; HEIGHT: 15px"><asp:textbox id="TxtDtAdm" runat="server" Width="225px" CssClass="textboxASR" Height="18px"></asp:textbox></TD>
																</TR>
															
															
																
																
																<TR>
																	
																	<TD style="WIDTH: 98px; HEIGHT: 6px"><asp:label id="Label24" runat="server" Width="150%" CssClass="LABLES">MotherTongue</asp:label></TD>
																	<TD>
																		<asp:dropdownlist id="DrpMotherTounge" runat="server" Width="300px" CssClass="textboxASR" Height="31px"></asp:dropdownlist></TD>
																	<TD style="WIDTH: 78px; HEIGHT: 15px"><asp:label id="Label6" runat="server" Width="95%" CssClass="LABLES" Height="17px">Admited&nbsp;Class*</asp:label></TD>
																	<TD class="auto-style3"><asp:dropdownlist id="DrpCourse" runat="server" Width="225px" CssClass="textboxASR" Height="19px"></asp:dropdownlist></TD>
                                                                    <TD style="WIDTH: 98px; HEIGHT: 15px"><asp:label id="Label45" runat="server" Width="100%" CssClass="LABLES">Ncc</asp:label></TD>
																	<TD style="WIDTH: 122px; HEIGHT: 15px"><asp:textbox id="txtNCC" runat="server" Width="225px" CssClass="textboxASR" MaxLength="35"></asp:textbox></TD>
																</TR>
                                                                 <TR>
                                                                    <td><asp:label id="Label15" runat="server" Width="100%" CssClass="LABLES">Games</asp:label></td>
                                                                    <td><asp:textbox id="txtGames" runat="server" Width="300px" CssClass="textboxASR" MaxLength="35"></asp:textbox></td>
                                                                    <td><asp:label id="Label17" runat="server" Width="100%" CssClass="LABLES">Present Days*</asp:label></td>
                                                                    <td><asp:textbox id="txtPreDays" runat="server" Width="225px" CssClass="textboxASR" Height="22px" MaxLength="35"></asp:textbox></td>
                                                                    <td><asp:label id="Label18" runat="server" Width="100%" CssClass="LABLES">Working Days*</asp:label></td>
                                                                    <td><asp:textbox id="txtWrkDays" runat="server" Width="225px" CssClass="textboxASR" MaxLength="35"></asp:textbox></td>
                                                                </TR>
                                                                <TR>
                                                                    <td><asp:label id="Label42" runat="server" Width="100%" CssClass="LABLES">Subject.18</asp:label></td>
                                                                    <td><asp:textbox id="txtSubject1" runat="server" Width="300px" CssClass="textboxASR" MaxLength="35"></asp:textbox></td>
                                                                    <td><asp:label id="Label43" runat="server" Width="100%" CssClass="LABLES">Subject.2*</asp:label></td>
                                                                    <td><asp:textbox id="txtSubject2" runat="server" Width="225px" CssClass="textboxASR" Height="22px" MaxLength="35"></asp:textbox></td>
                                                                    <td><asp:label id="Label44" runat="server" Width="100%" CssClass="LABLES">Subject.3*</asp:label></td>
                                                                    <td><asp:textbox id="txtSubject3" runat="server" Width="225px" CssClass="textboxASR" MaxLength="35"></asp:textbox></td>
                                                                </TR>
                                                                <TR>
                                                                    <td><asp:label id="Label12" runat="server" Width="100%" CssClass="LABLES">Subject.4*</asp:label></td>
                                                                    <td><asp:textbox id="txtSubject4" runat="server" Width="300px" CssClass="textboxASR" MaxLength="35"></asp:textbox></td>
                                                                    <td><asp:label id="Label13" runat="server" Width="100%" CssClass="LABLES">Subject.5*</asp:label></td>
                                                                    <td><asp:textbox id="txtSubject5" runat="server" Width="225px" CssClass="textboxASR" Height="22px" MaxLength="35"></asp:textbox></td>
                                                                    
                                                                </TR>
																<TR>
                                                                    
																	<TD style="WIDTH: 98px; HEIGHT: 3px"><asp:label id="lblBoardBranch" runat="server" Width="190%" CssClass="Lables">Board&nbsp;Branch *</asp:label></TD>
																	<TD style="HEIGHT: 3px"><asp:dropdownlist id="drpAdmBranch" runat="server" Width="300px" CssClass="textboxASR" Height="16px"></asp:dropdownlist></TD>
                                                                    
                                                                     <TD style="WIDTH: 98px; HEIGHT: 6px">&nbsp;</TD>
																	<TD style="WIDTH: 127px; HEIGHT: 15px">&nbsp;</TD>
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
