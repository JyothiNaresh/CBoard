<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="BoardDetailsEntryBenglore.aspx.vb" Inherits="CollegeBoard.BoardDetailsEntryBenglore" %>

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
																	<TD style="WIDTH: 127px"><asp:label id="Label9" runat="server" Width="200px" CssClass="LABLES">Student No: *</asp:label></TD>
																	<TD style="WIDTH: 98px"><asp:textbox id="txtstudent" runat="server" Width="300px" CssClass="textboxASR" MaxLength="18"></asp:textbox></TD>
																</TR>
                                                                <tr>
                                                                    <TD style="WIDTH: 127px"><asp:label id="Label18" runat="server" Width="200px" CssClass="LABLES">SATS No: *</asp:label></TD>
																	<TD style="WIDTH: 98px"><asp:textbox id="txtSAT" runat="server" Width="300px" CssClass="textboxASR" MaxLength="18"></asp:textbox></TD>
                                                                 <TD style="WIDTH: 122px"><asp:label id="Label26" runat="server" Width="200px" CssClass="LABLES">Code-College</asp:label></TD>
																	<TD style="WIDTH: 98px"><asp:dropdownlist id="DrpColl" runat="server" Width="300px" CssClass="textboxASR" Height="16px"></asp:dropdownlist></TD>
                                                                </tr>
																
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
																	<TD style="WIDTH: 127px"><asp:label id="lblreligion" runat="server" Width="200px" CssClass="LABLES">Religion *</asp:label></TD>
																	<TD style="WIDTH: 98px"><asp:textbox id="txtreligion" runat="server" Width="300px" CssClass="textboxASR" MaxLength="50"></asp:textbox></TD>
																	<TD style="WIDTH: 127px"><asp:label id="lblcaste" runat="server" Width="200px" CssClass="LABLES">Caste</asp:label></TD>
																	<TD style="WIDTH: 98px"><asp:textbox id="txtcaste" runat="server" Width="300px" CssClass="textboxASR" MaxLength="18"></asp:textbox></TD>
																</TR>
                                                                <tr>
                                                                    <TD style="WIDTH: 127px"><asp:label id="Label10" runat="server" Width="200px" CssClass="LABLES">Sub-Caste</asp:label></TD>
																	<TD style="WIDTH: 98px"><asp:textbox id="txtsubcaste" runat="server" Width="300px" CssClass="textboxASR" MaxLength="18"></asp:textbox></TD>
                                                                </tr>
																<TR>																	
																	<TD style="WIDTH: 122px"><asp:label id="Label29" runat="server" Width="200px" CssClass="LABLES">Whether the Student belongs to SC/ST</asp:label></TD>
																	<TD style="WIDTH: 98px">
                                                                        <asp:dropdownlist id="radSCST" runat="server" Width="300px" CssClass="textboxASR" Height="16px">
                                                                        <asp:ListItem  Value="1">YES</asp:ListItem>
                                                                        <asp:ListItem  Value="2" Selected="True">NO</asp:ListItem>
																	                        </asp:dropdownlist>


																	</TD>
                                                                    <TD style="WIDTH: 127px"><asp:label id="Label30" runat="server" Width="200px" CssClass="LABLES">Gender</asp:label></TD>
																	<TD style="WIDTH: 98px"><asp:dropdownlist id="drpgender" AutoPostBack="true" runat="server" Width="300px" CssClass="textboxASR" Height="16px">
                                                                        <asp:ListItem  Selected="True" Value="1">MALE</asp:ListItem>
                                                                        <asp:ListItem  Value="2">FEMALE</asp:ListItem>
																	                        </asp:dropdownlist></TD>
																</TR>
                                                                <TR>
                                                                      <td>

                                                                    </td>
														<TD class="SubHeading1" vAlign="top">Details of subject studied in I/II PUC</TD>
                                                                  
													</TR>

                                                              
																  <TR>
                                                                     
														<TD class="SubHeading1" vAlign="top">PART-I</TD>
                                                                  
													</TR>
                                                                	<TR>																	
																	<TD style="WIDTH: 122px"><asp:label id="Label16" runat="server" Width="200px" CssClass="LABLES">Languages Studied</asp:label></TD>
																	<TD style="WIDTH: 98px; margin-left: 40px;">
                                                                        <asp:dropdownlist id="radlanguage" AutoPostBack="true" runat="server" Width="300px" CssClass="textboxASR" Height="16px">
                                                                        <asp:ListItem Selected="true" Value="1">KARNATAKA</asp:ListItem>
                                                                        <asp:ListItem  Value="2">ENGLISH</asp:ListItem>
																	                        </asp:dropdownlist>
																	</TD>
																	</TD>
                                                                  </TR>

                                                    <TR>																	
																	<TD style="WIDTH: 122px"><asp:label id="Label161" runat="server" Width="200px" CssClass="LABLES">Languages Studied-II</asp:label></TD>
																	<TD style="WIDTH: 98px; margin-left: 40px;">

                                                                        <asp:dropdownlist id="RadioButtonList2" AutoPostBack="true" runat="server" Width="300px" CssClass="textboxASR" Height="16px">
                                                                         <asp:ListItem Selected="True"  Value="1">ENGLISH</asp:ListItem>
                                                                        <asp:ListItem Value="2" >HINDI</asp:ListItem>
                                                                            <asp:ListItem Value="3" >SANSKRIT</asp:ListItem>
                                                                            <asp:ListItem Value="4" >FRENCH</asp:ListItem>
                                                                             <asp:ListItem Value="5" >OTHER</asp:ListItem>
																	                        </asp:dropdownlist>																	</TD>
																	</TD>
                                                                  </TR>

                                         <TR>																	
																	<TD style="WIDTH: 122px"></TD>
																	<TD style="WIDTH: 98px; margin-left: 40px;">

                                                                       <asp:textbox id="txtother" runat="server" Width="300px" CssClass="textboxASR" MaxLength="20"  ReadOnly="true"></asp:textbox>
																	</TD>
																	</TD>
                                                                  </TR>
                                                                  <TR>
                                                                     
														<TD class="SubHeading1" vAlign="top">PART-II</TD>
                                                                  
													</TR>
                                                                	<TR>																	
																	<TD style="WIDTH: 122px"><asp:label id="Label11" runat="server" Width="200px" CssClass="LABLES">Subject Studied 1.</asp:label></TD>
																	<TD style="WIDTH: 98px; margin-left: 40px;"><asp:textbox id="txtSubject1" runat="server" Width="300px" CssClass="textboxASR" MaxLength="20"></asp:textbox></TD>
                                                                    <TD style="WIDTH: 127px"><asp:label id="Label12" runat="server" Width="200px" CssClass="LABLES">Subject Studied 2.</asp:label></TD>
																	<TD style="WIDTH: 98px"><asp:textbox id="txtSubject2" runat="server" Width="300px" CssClass="textboxASR" MaxLength="20"></asp:textbox></TD>
																</TR>
																
																<TR>																	
																	<TD style="WIDTH: 122px"><asp:label id="Label13" runat="server" Width="200px" CssClass="LABLES">Subject Studied 3.</asp:label></TD>
																	<TD style="WIDTH: 98px; margin-left: 40px;"><asp:textbox id="txtSubject3" runat="server" Width="300px" CssClass="textboxASR" MaxLength="20"></asp:textbox></TD>
                                                                    <TD style="WIDTH: 127px"><asp:label id="Label14" runat="server" Width="200px" CssClass="LABLES">Subject Studied 4.</asp:label></TD>
																	<TD style="WIDTH: 98px"><asp:textbox id="txtSubject4" runat="server" Width="300px" CssClass="textboxASR" MaxLength="20"></asp:textbox></TD>
																</TR>
																
																    <TR>																	
																	<TD style="WIDTH: 122px"><asp:label id="Label41" runat="server" Width="200px" CssClass="LABLES">Medium Instruction.</asp:label></TD>
																	<TD style="WIDTH: 98px; margin-left: 40px;"><asp:textbox id="txtmedium" runat="server" Width="300px" CssClass="textboxASR" MaxLength="20"></asp:textbox></TD>
                                                                    </TR>
																<TR>																	
																	<TD style="WIDTH: 122px"><asp:label id="Label31" runat="server" Width="200px" CssClass="LABLES">Date of Birth (in figures)</asp:label></TD>
																	<TD style="WIDTH: 98px; margin-left: 40px;"><asp:textbox id="TxtDob" runat="server" Width="300px" CssClass="textboxASR" MaxLength="20" placeholder="dd-mm-yyyy"></asp:textbox></TD>
                                                                      <TD style="WIDTH: 127px"><asp:label id="Label44" runat="server" Width="200px" CssClass="LABLES">Whether Qualified for promotion to the higher standard</asp:label></TD>
																	<TD style="WIDTH: 98px">
                                                                     <asp:dropdownlist id="ddlQualClass_words" runat="server" Width="300px" CssClass="textboxASR" Height="16px">
                                                                        <asp:ListItem  Value="1" Selected="True">YES</asp:ListItem>
                                                                        <asp:ListItem  Value="2" >NO</asp:ListItem>
																	                        </asp:dropdownlist>

																	</TD>
																</TR>
                                                    <tr>
                                                        <td>
                                                            <TD style="WIDTH: 122px"><asp:label id="Label8" runat="server" Width="308px" Font-Bold="True" ForeColor="Red">date format should be DD/MM/YYYY</asp:label></TD>
                                                        </td>
                                                    </tr>
																<TR>
                                                                   																
																	
																																	
																	<TD style="WIDTH: 122px"><asp:label id="Label33" runat="server" Width="200px" CssClass="LABLES">Standar in which the pupil was studyig at the time of leaving the college(inwords)</asp:label></TD>
																	<TD style="WIDTH: 98px; margin-left: 40px;">
                                                           

                                                                         <asp:dropdownlist id="ddlLastStudied" AutoPostBack="true" runat="server" Width="300px" CssClass="textboxASR" Height="16px">
                                                                        <asp:ListItem   Value="1" Selected="True" >FIRST PUC</asp:ListItem>
                                                                        <asp:ListItem  Value="2">SECOND PUC</asp:ListItem>
																	                        </asp:dropdownlist>
																	</TD>
                                                                    
																</TR>
																
																<TR>																	
																	<TD style="WIDTH: 122px"><asp:label id="Label35" runat="server" Width="200px" CssClass="LABLES">Fees concessions ,if any (nature & period to be specified) </asp:label></TD>
																	<TD style="WIDTH: 98px; margin-left: 40px;"><asp:textbox id="txtConcession" runat="server" Width="300px" CssClass="textboxASR" MaxLength="50"></asp:textbox></TD>
                                                                   
																</TR>
																
																<TR>																	
																	<TD style="WIDTH: 122px"><asp:label id="Label37" runat="server" Width="200px" CssClass="LABLES">Date of admission to the college</asp:label></TD>
																	<TD style="WIDTH: 98px; margin-left: 40px;"><asp:textbox id="txtDateofAdm" runat="server" Width="300px" CssClass="textboxASR" MaxLength="20"></asp:textbox></TD>
                                                                    <TD style="WIDTH: 127px"><asp:label id="Label38" runat="server" Width="200px" CssClass="LABLES">Whether the student has paid all the fees dues to college</asp:label></TD>
																	<TD style="WIDTH: 98px">
                                                                       
                                                                         <asp:dropdownlist id="RadioPaid" runat="server" Width="300px" CssClass="textboxASR" Height="16px">
                                                                        <asp:ListItem  Value="1" Selected="True">YES</asp:ListItem>
                                                                        <asp:ListItem  Value="2" >NO</asp:ListItem>
																	                        </asp:dropdownlist>
																	</TD>
																</TR>
																
																<TR>																	
																	<TD style="WIDTH: 122px"><asp:label id="Label39" runat="server" Width="200px" CssClass="LABLES">Date of student last attended at the college</asp:label></TD>
																	<TD style="WIDTH: 98px; margin-left: 40px;"><asp:textbox id="txtlastattend" runat="server" Width="300px" CssClass="textboxASR" MaxLength="20"></asp:textbox></TD>
                                                                    <TD style="WIDTH: 127px"><asp:label id="Label40" runat="server" Width="200px" CssClass="LABLES">Date of issue of the transfer certificate</asp:label></TD>
																	<TD style="WIDTH: 98px"><asp:textbox id="txtIssueCert" runat="server" Width="300px" CssClass="textboxASR" MaxLength="20"></asp:textbox></TD>
																</TR>														
																
																<TR>																	
																	<TD style="WIDTH: 122px"><asp:label id="Label51" runat="server" Width="200px" CssClass="LABLES">Number of college days up to the date of leaving</asp:label></TD>
																	<TD style="WIDTH: 98px; margin-left: 40px;"><asp:textbox id="txtTotWork" runat="server" Width="300px" CssClass="textboxASR" MaxLength="3"></asp:textbox></TD>
                                                                    <TD style="WIDTH: 127px"><asp:label id="Label46" runat="server" Width="200px" CssClass="LABLES">Number of college days the pupil attended</asp:label></TD>
																	<TD style="WIDTH: 98px"><asp:textbox id="txtWorkPre" runat="server" Width="300px" CssClass="textboxASR" MaxLength="3"></asp:textbox></TD>
																</TR>
																
																
																
																<TR>																	
																	<TD style="WIDTH: 122px"><asp:label id="Label53" runat="server" Width="200px" CssClass="LABLES">Conduct and character of the student</asp:label></TD>
																	<TD style="WIDTH: 98px; margin-left: 40px;"><asp:textbox id="txtConduct" runat="server" Width="300px" CssClass="textboxASR" MaxLength="20"></asp:textbox></TD>
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
