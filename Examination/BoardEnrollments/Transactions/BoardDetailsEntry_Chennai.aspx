<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="BoardDetailsEntry_Chennai.aspx.vb" Inherits="CollegeBoard.BoardDetailsEntry_Chennai" %>
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
                height: 13px;
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
									<TABLE id="Table2" style="WIDTH: 900px" height="216" cellSpacing="0" cellPadding="0" width="900"
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
																	<TD style="WIDTH: 127px"><asp:label id="Label15" runat="server" Width="200px" CssClass="LABLES">Board&nbsp;AdmNo *</asp:label></TD>
																	<TD style="WIDTH: 98px"><asp:textbox id="TxtBAdmno" runat="server" Width="300px" CssClass="textboxASR" MaxLength="18"></asp:textbox></TD>
																	<TD style="WIDTH: 122px"><asp:label id="Label26" runat="server" Width="200px" CssClass="LABLES">Code-College</asp:label></TD>
																	<TD style="WIDTH: 98px"><asp:dropdownlist id="DrpColl" runat="server" Width="300px" CssClass="textboxASR" Height="16px"></asp:dropdownlist></TD>
																</TR>
																<TR>
																	<TD style="WIDTH: 127px"><asp:label id="Label5" runat="server" Width="200px" CssClass="LABLES">Student&nbsp;Name *</asp:label></TD>
																	<TD style="WIDTH: 98px"><asp:textbox id="TxtBName" runat="server" Width="300px" CssClass="textboxASR" MaxLength="50"></asp:textbox></TD>
																	<TD style="WIDTH: 122px"><asp:label id="Label6" runat="server" Width="200px" CssClass="LABLES">Father's&nbsp;Name</asp:label></TD>
																	<TD style="WIDTH: 98px"><asp:textbox id="TxtBFname" runat="server" Width="300px" CssClass="textboxASR" MaxLength="50"></asp:textbox></TD>
																</TR>
                                                                <TR>
																	<TD style="WIDTH: 127px"><asp:label id="Label7" runat="server" Width="200px" CssClass="LABLES">Mother's&nbsp;Name *</asp:label></TD>
																	<TD style="WIDTH: 98px"><asp:textbox id="TxtBMname" runat="server" Width="300px" CssClass="textboxASR" MaxLength="50"></asp:textbox></TD>
																	<TD style="WIDTH: 127px"><asp:label id="Label28" runat="server" Width="200px" CssClass="LABLES">Nationality</asp:label></TD>
																	<TD style="WIDTH: 98px"><asp:textbox id="txtNationality" runat="server" Width="300px" CssClass="textboxASR" MaxLength="18"></asp:textbox></TD>
																</TR>
																<TR>																	
																	<TD style="WIDTH: 122px"><asp:label id="Label29" runat="server" Width="200px" CssClass="LABLES">Whether the candidate belongs to schedule Caste or schedule Tribe</asp:label></TD>
																	<TD style="WIDTH: 98px"><asp:textbox id="txtCaste" runat="server" Width="300px" CssClass="textboxASR" MaxLength="18"></asp:textbox></TD>
                                                                    <TD style="WIDTH: 127px"><asp:label id="Label30" runat="server" Width="200px" CssClass="LABLES">Date of first admission in the school with class</asp:label></TD>
																	<TD style="WIDTH: 98px"><asp:textbox id="txtSchool_Class" runat="server" Width="300px" CssClass="textboxASR" MaxLength="100"></asp:textbox></TD>
																</TR>
																
																<TR>																	
																	<TD style="WIDTH: 122px"><asp:label id="Label31" runat="server" Width="200px" CssClass="LABLES">Date of Birth (in Christian Era)according to Admission Register (in figures)</asp:label></TD>
																	<TD style="WIDTH: 98px; margin-left: 40px;"><asp:textbox id="TxtDob" runat="server" Width="300px" CssClass="textboxASR" MaxLength="20"></asp:textbox></TD>
                                                                    <TD style="WIDTH: 127px"><asp:label id="Label32" runat="server" Width="200px" CssClass="LABLES">Date of Birth (in Christian Era)according to Admission Register (in words)</asp:label></TD>
																	<TD style="WIDTH: 98px"><asp:textbox id="txtDobwords" runat="server" Width="300px" CssClass="textboxASR" MaxLength="80"></asp:textbox></TD>
																</TR>
																
																<TR>																	
																	<TD style="WIDTH: 122px"><asp:label id="Label33" runat="server" Width="200px" CssClass="LABLES">Class in which the pupil last studied (in figures)</asp:label></TD>
																	<TD style="WIDTH: 98px; margin-left: 40px;"><asp:textbox id="txtLastStudied" runat="server" Width="300px" CssClass="textboxASR" MaxLength="20"></asp:textbox></TD>
                                                                    <TD style="WIDTH: 127px"><asp:label id="Label34" runat="server" Width="200px" CssClass="LABLES">Class in which the pupil last studied (in words)</asp:label></TD>
																	<TD style="WIDTH: 98px"><asp:textbox id="txtLastStudies_words" runat="server" Width="300px" CssClass="textboxASR" MaxLength="80"></asp:textbox></TD>
																</TR>
																
																<TR>																	
																	<TD style="WIDTH: 122px"><asp:label id="Label35" runat="server" Width="200px" CssClass="LABLES">School / Board Annual examination last taken with result </asp:label></TD>
																	<TD style="WIDTH: 98px; margin-left: 40px;"><asp:textbox id="txtBoardLastExam" runat="server" Width="300px" CssClass="textboxASR" MaxLength="50"></asp:textbox></TD>
                                                                    <TD style="WIDTH: 127px"><asp:label id="Label36" runat="server" Width="200px" CssClass="LABLES">Whether failed, if so once / twice in the same class </asp:label></TD>
																	<TD style="WIDTH: 98px"><asp:textbox id="txtTwiceClass" runat="server" Width="300px" CssClass="textboxASR" MaxLength="30"></asp:textbox></TD>
																</TR>
																
																<TR>																	
																	<TD style="WIDTH: 122px"><asp:label id="Label37" runat="server" Width="200px" CssClass="LABLES">Subject Studied 1.</asp:label></TD>
																	<TD style="WIDTH: 98px; margin-left: 40px;"><asp:textbox id="txtSubject1" runat="server" Width="300px" CssClass="textboxASR" MaxLength="20"></asp:textbox></TD>
                                                                    <TD style="WIDTH: 127px"><asp:label id="Label38" runat="server" Width="200px" CssClass="LABLES">Subject Studied 2.</asp:label></TD>
																	<TD style="WIDTH: 98px"><asp:textbox id="txtSubject2" runat="server" Width="300px" CssClass="textboxASR" MaxLength="20"></asp:textbox></TD>
																</TR>
																
																<TR>																	
																	<TD style="WIDTH: 122px"><asp:label id="Label39" runat="server" Width="200px" CssClass="LABLES">Subject Studied 3.</asp:label></TD>
																	<TD style="WIDTH: 98px; margin-left: 40px;"><asp:textbox id="txtSubject3" runat="server" Width="300px" CssClass="textboxASR" MaxLength="20"></asp:textbox></TD>
                                                                    <TD style="WIDTH: 127px"><asp:label id="Label40" runat="server" Width="200px" CssClass="LABLES">Subject Studied 4.</asp:label></TD>
																	<TD style="WIDTH: 98px"><asp:textbox id="txtSubject4" runat="server" Width="300px" CssClass="textboxASR" MaxLength="20"></asp:textbox></TD>
																</TR>
																
																<TR>																	
																	<TD style="WIDTH: 122px"><asp:label id="Label41" runat="server" Width="200px" CssClass="LABLES">Subject Studied 5.</asp:label></TD>
																	<TD style="WIDTH: 98px; margin-left: 40px;"><asp:textbox id="txtSubject5" runat="server" Width="300px" CssClass="textboxASR" MaxLength="20"></asp:textbox></TD>
                                                                    <TD style="WIDTH: 127px"><asp:label id="Label42" runat="server" Width="200px" CssClass="LABLES">Subject Studied 6.</asp:label></TD>
																	<TD style="WIDTH: 98px"><asp:textbox id="txtSubject6" runat="server" Width="300px" CssClass="textboxASR" MaxLength="20"></asp:textbox></TD>
																</TR>
																
																<TR>																	
																	<TD style="WIDTH: 122px"><asp:label id="Label43" runat="server" Width="200px" CssClass="LABLES">Whether qualified for promotion to the higher class If so, to which class (in figures)</asp:label></TD>
																	<TD style="WIDTH: 98px; margin-left: 40px;"><asp:textbox id="txtQualClass" runat="server" Width="300px" CssClass="textboxASR" MaxLength="20"></asp:textbox></TD>
                                                                    <TD style="WIDTH: 127px"><asp:label id="Label44" runat="server" Width="200px" CssClass="LABLES">Whether qualified for promotion to the higher class If so, to which class (in words)</asp:label></TD>
																	<TD style="WIDTH: 98px"><asp:textbox id="txtQualClass_words" runat="server" Width="300px" CssClass="textboxASR" MaxLength="80"></asp:textbox></TD>
																</TR>
																
																<TR>																	
																	<TD style="WIDTH: 122px"><asp:label id="Label50" runat="server" Width="200px" CssClass="LABLES">Month up to which the (pupil has paid) school dues paid</asp:label></TD>
																	<TD style="WIDTH: 98px; margin-left: 40px;"><asp:textbox id="txtPaid" runat="server" Width="300px" CssClass="textboxASR" MaxLength="20"></asp:textbox></TD>
                                                                    <TD style="WIDTH: 127px"><asp:label id="Label45" runat="server" Width="200px" CssClass="LABLES">Any fee concession availed of : If so, the nature of such concession</asp:label></TD>
																	<TD style="WIDTH: 98px"><asp:textbox id="txtConcession" runat="server" Width="300px" CssClass="textboxASR" MaxLength="20"></asp:textbox></TD>
																</TR>
																
																<TR>																	
																	<TD style="WIDTH: 122px"><asp:label id="Label51" runat="server" Width="200px" CssClass="LABLES">Total No. of working days</asp:label></TD>
																	<TD style="WIDTH: 98px; margin-left: 40px;"><asp:textbox id="txtTotWork" runat="server" Width="300px" CssClass="textboxASR" MaxLength="3"></asp:textbox></TD>
                                                                    <TD style="WIDTH: 127px"><asp:label id="Label46" runat="server" Width="200px" CssClass="LABLES">Total No. of working days present</asp:label></TD>
																	<TD style="WIDTH: 98px"><asp:textbox id="txtWorkPre" runat="server" Width="300px" CssClass="textboxASR" MaxLength="3"></asp:textbox></TD>
																</TR>
																
																<TR>																	
																	<TD style="WIDTH: 122px"><asp:label id="Label52" runat="server" Width="200px" CssClass="LABLES">16.	Whether NCC Cadet / Boy Scout / Girl Guide (details may be given)</asp:label></TD>
																	<TD style="WIDTH: 98px; margin-left: 40px;"><asp:textbox id="txtNCC" runat="server" Width="300px" CssClass="textboxASR" MaxLength="20"></asp:textbox></TD>
                                                                    <TD style="WIDTH: 127px"><asp:label id="Label47" runat="server" Width="200px" CssClass="LABLES">Games played or extracurricular activities in which the pupil usually took part:</asp:label></TD>
																	<TD style="WIDTH: 98px"><asp:textbox id="txtGames" runat="server" Width="300px" CssClass="textboxASR" MaxLength="50"></asp:textbox></TD>
																</TR>
																
																<TR>																	
																	<TD style="WIDTH: 122px"><asp:label id="Label53" runat="server" Width="200px" CssClass="LABLES">General conduct</asp:label></TD>
																	<TD style="WIDTH: 98px; margin-left: 40px;"><asp:textbox id="txtConduct" runat="server" Width="300px" CssClass="textboxASR" MaxLength="20"></asp:textbox></TD>
                                                                    <TD style="WIDTH: 127px"><asp:label id="Label48" runat="server" Width="200px" CssClass="LABLES">Date of application for certificate</asp:label></TD>
																	<TD style="WIDTH: 98px"><asp:textbox id="txtApplCert" runat="server" Width="300px" CssClass="textboxASR" MaxLength="20"></asp:textbox></TD>
																</TR>
																
																<TR>																	
																	<TD style="WIDTH: 122px"><asp:label id="Label54" runat="server" Width="200px" CssClass="LABLES">Date of issue of certificate</asp:label></TD>
																	<TD style="WIDTH: 98px; margin-left: 40px;"><asp:textbox id="txtIssueCert" runat="server" Width="300px" CssClass="textboxASR" MaxLength="20"></asp:textbox></TD>
                                                                    <TD style="WIDTH: 127px"><asp:label id="Label49" runat="server" Width="200px" CssClass="LABLES">Reason for leaving the school </asp:label></TD>
																	<TD style="WIDTH: 98px"><asp:textbox id="txtLeaving" runat="server" Width="300px" CssClass="textboxASR" MaxLength="50"></asp:textbox></TD>
																</TR>
																
																<TR>																	
																	<TD style="WIDTH: 122px"><asp:label id="Label55" runat="server" Width="200px" CssClass="LABLES">Any other remarks</asp:label></TD>
																	<TD style="WIDTH: 98px; margin-left: 40px;"><asp:textbox id="txtRemarks" runat="server" Width="300px" CssClass="textboxASR" MaxLength="100"></asp:textbox></TD>
                                                                    <TD style="WIDTH: 127px"><asp:label id="Label56" runat="server" Width="200px" CssClass="LABLES">Aadhar No *</asp:label></TD>
																	<TD style="WIDTH: 98px"><asp:textbox id="txtAadhar" runat="server" Width="300px" CssClass="textboxASR" MaxLength="12"></asp:textbox></TD>
																</TR>
																
																<TR>
																	
																	<TD style="WIDTH: 122px"><asp:label id="lblBoardBranch" runat="server" Width="200px" CssClass="Lables">Board&nbsp;Branch *</asp:label></TD>
																	<TD style="WIDTH: 98px; margin-left: 40px;"><asp:dropdownlist id="drpAdmBranch" runat="server" Width="300px" CssClass="textboxASR" Height="16px"></asp:dropdownlist></TD>
																</TR>
																
																</TABLE>
														</TD>
													</TR>
													<TR>
														<TD vAlign="top" nowrap="nowrap" align="left" class="auto-style1">
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
