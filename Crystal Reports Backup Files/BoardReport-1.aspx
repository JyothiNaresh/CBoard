<%@ Page Language="vb" AutoEventWireup="false" Codebehind="BoardReport-1.aspx.vb" Inherits="CollegeBoard.BoardReport_1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>BoardReport_1</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta charset="utf-8">
		<link rel="stylesheet" href="http://code.jquery.com/ui/1.10.2/themes/smoothness/jquery-ui.css">
		<script type="text/javascript" src="http://highslide.com/highslide/highslide-full.js"></script>
		<LINK rel="stylesheet" type="text/css" href="http://highslide.com/highslide/highslide.css">
		<script type="text/javascript">
			hs.graphicsDir = '../../Include/Slide/Graphics/';
			hs.outlineType = 'rounded-white';
			hs.showCredits = false;
			hs.fadeInOut = true;
			hs.headingEval = 'this.a.title';
			hs.wrapperClassName = 'draggable-header';
		</script>
		<!--<script src="http://code.jquery.com/jquery-1.9.1.js"></script>
		<script src="http://code.jquery.com/ui/1.10.2/jquery-ui.js"></script>
		<LINK rel="stylesheet" href="/resources/demos/style.css">-->
		<LINK id="Link1" rel="stylesheet" type="text/css" href="../../../Images/Login/StyleSheet_Report.css">
		<LINK rel="stylesheet" type="text/css" href="../../../Styles/MultiComboSelect/jquery.multiselect.css">
		<LINK rel="stylesheet" type="text/css" href="../../../Styles/MultiComboSelect/jquery.multiselect.filter.css">
		<LINK rel="stylesheet" type="text/css" href="../../../Styles/MultiComboSelect/jquery-ui.css">
		<LINK rel="stylesheet" type="text/css" href="../../../Styles/MultiComboSelect/prettify.css">
		<link rel="stylesheet" type="text/css" href="http://www.jeasyui.com/easyui/themes/default/easyui.css">
		<link rel="stylesheet" type="text/css" href="http://www.jeasyui.com/easyui/themes/icon.css">
		<%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.js"></script>
		<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1/jquery-ui.min.js"></script>--%>
        <%--<script type="text/javascript" src="http://www.erichynds.com/examples/jquery-ui-multiselect-widget/src/jquery.multiselect.js"></script>
		<script type="text/javascript" src="http://www.erichynds.com/examples/jquery-ui-multiselect-widget/src/jquery.multiselect.filter.js"></script>
		<script type="text/javascript" src="http://www.erichynds.com/examples/jquery-ui-multiselect-widget/demos/assets/prettify.js"></script>--%>
        <%--<script src="../../Include/MultiComboSelect/jquery.multiselect.js" type="text/javascript"></script>
		<script src="../../Include/MultiComboSelec/jquery.multiselect.filter.js" type="text/javascript"></script>--%>
        <%--<script src="../../Include/MultiComboSelec/prettify.js" type="text/javascript"></script>
        		<script type="text/javascript">
			$(function(){
			    $("#seldistrict").multiselect({ noneSelectedText: "Select District", checkAllText: 'Sel.All', uncheckAllText: 'Rem.All', selectedList: 0, minWidth: 200 });
				$("#selsociety").multiselect({noneSelectedText: "Select Society",checkAllText:'Sel.All',uncheckAllText:'Rem.All',selectedList: 1,minWidth:200});
				$("#selyearstart").multiselect({noneSelectedText: "Sel. College Start Year",checkAllText:'Sel.All',uncheckAllText:'Rem.All',selectedList: 2,minWidth:150});
			});		
            
		</script>--%>
		<script src="../../Include/ExcelExporting.js"></script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE style="WIDTH: 955px; HEIGHT: 168px" id="Table0" border="0" cellSpacing="0" cellPadding="0"
				width="955" align="center" runat="server">
				<TBODY>
					<TR>
						<TD vAlign="top" align="center">
							<TABLE id="Table6" border="0" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD vAlign="top" align="center">
										<TABLE style="WIDTH: 951px; HEIGHT: 160px" id="Table4" border="0" cellSpacing="0" cellPadding="0"
											width="951" runat="server">
											<tr>
												<td></td>
												<td></td>
											</tr>
											<TR>
												<TD vAlign="top" align="center">
													<TABLE id="Table5" border="1" cellSpacing="0" cellPadding="0" width="85%" runat="server"
														borderColor="#b2262f">
														<tr>
															<td colSpan="5" align="center">
																<asp:label id="lblHeading" runat="server" CssClass="SubHeading12" Width="100%" Font-Bold="True"> Board College Details </asp:label>
															</td>
														</tr>
														<TR>
															<TD>
																<TABLE id="Table121" border="1" cellSpacing="0" borderColor="whitesmoke" cellPadding="0"
																	width="100%" align="center" runat="server">
																	<TR>
																		<TD colSpan="5" align="center"></TD>
																	</TR>
																	<TR>
																		<TD colSpan="5" align="center">
																			<TABLE id="Table1" border="1" cellSpacing="0" cellPadding="0" width="45%">
																				<TR>
																					<TD><asp:checkbox style="Z-INDEX: 0" id="ChkBldng" runat="server" CssClass="lables1" Width="120px"
																							Checked="True" Text="Building "></asp:checkbox></TD>
																					<TD><asp:checkbox style="Z-INDEX: 0" id="ChkAfl" runat="server" CssClass="lables1" Width="120px" Checked="True"
																							Text="Affiliation"></asp:checkbox></TD>
																					<TD><asp:checkbox style="Z-INDEX: 0" id="ChkFdr" runat="server" CssClass="lables1" Width="120px" Checked="True"
																							Text="FDR"></asp:checkbox></TD>
																					<TD><asp:checkbox style="Z-INDEX: 0" id="ChkCert" runat="server" CssClass="lables1" Width="120px"
																							Checked="True" Text="Certificates"></asp:checkbox></TD>
																					<TD><asp:checkbox style="Z-INDEX: 0" id="CHKSOCIETY" runat="server" CssClass="lables1" Width="120px"
																							Checked="True" Text="SOCIETY"></asp:checkbox></TD>
																					<TD>
																						<asp:checkbox style="Z-INDEX: 0" id="CHKYearStart" runat="server" Width="120px" CssClass="lables1"
																							Text="Year Start" Checked="True"></asp:checkbox></TD>
																				</TR>
																			</TABLE>
																		</TD>
																	</TR>
																	<TR>
																		<TD style="HEIGHT: 18px" colSpan="5" align="center">
																			<TABLE id="Table2" border="0" cellSpacing="0" cellPadding="0" width="300">
																				<TR>
																					<TD><asp:label id="lblFdrletter" CssClass="Lables1" Width="100%" Runat="server" style="Z-INDEX: 0">FDR Release Letter</asp:label></TD>
																					<TD><asp:radiobutton id="RdYes" runat="server" CssClass="Lables1" Width="100%" Text="Yes" GroupName="C"
																							AutoPostBack="True" style="Z-INDEX: 0"></asp:radiobutton></TD>
																					<TD><asp:radiobutton id="RdNo" runat="server" CssClass="Lables1" Width="100%" Checked="True" Text="No"
																							GroupName="C" AutoPostBack="True"></asp:radiobutton></TD>
																				</TR>
																			</TABLE>
																		</TD>
																	</TR>
																	<TR>
																		<TD align="center">
																			<TABLE id="Table3" border="0" cellSpacing="0" cellPadding="0" width="300">
																				<TR>
																					<TD><asp:label id="Label10" runat="server" CssClass="Lables" Width="100%">District</asp:label></TD>
								                                                    <TD></TD>
								                                                    <TD><asp:label id="Label3" runat="server" CssClass="Lables" Width="100%">Selected</asp:label></TD>
								                                                    <TD>
									                                                    <asp:label id="Label1" runat="server" CssClass="Lables" Width="100%">Society</asp:label></TD>
								                                                    <TD></TD>
								                                                    <TD>
									                                                <asp:label id="Label5" runat="server" CssClass="Lables" Width="100%">Selected</asp:label></TD>
																				</TR>
                                                                                
                                                                                <TR>
								                                                    <TD vAlign="top"><asp:listbox id="LstDistrict" runat="server" CssClass=" " Width="200px" Height="150px" Rows="100"
										                                                SelectionMode="Multiple"></asp:listbox></TD>
								                                                    <TD vAlign="top">
									                                            <TABLE id="Table7" cellSpacing="0" cellPadding="0" width="30" border="0">
										                        <TR>
											                          <TD><asp:imagebutton id="BtnSelDistrict" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Select.gif"></asp:imagebutton></TD>
										                        </TR>
										                        <TR>
											                        <TD><asp:imagebutton id="BtnSelDistrictAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/SelectAll.gif"></asp:imagebutton></TD>
										                        </TR>
										                        <TR>
											                        <TD><asp:imagebutton id="BtnRemDistrict" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Remove.gif"></asp:imagebutton></TD>
										                        </TR>
										                        <TR>
											                        <TD><asp:imagebutton id="BtnRemDistrictAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/RemoveAll.gif"></asp:imagebutton></TD>
										                        </TR>
									                        </TABLE>
								                                </TD>
								<TD vAlign="top"><asp:listbox id="LstSelDistrict" runat="server" CssClass=" " Width="200px" Height="150px" Rows="100"
										SelectionMode="Multiple" TabIndex="1"></asp:listbox></TD>
								<TD vAlign="top">
									<asp:listbox id="LstSociety" runat="server" CssClass=" " Width="200px" SelectionMode="Multiple"
										Rows="100" Height="150px" TabIndex="2"></asp:listbox></TD>
								<TD vAlign="top">
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="30" border="0">
										<TR>
											<TD>
												<asp:imagebutton id="BtnSelSociety" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Select.gif"></asp:imagebutton></TD>
										</TR>
										<TR>
											<TD>
												<asp:imagebutton id="BtnSelSocietyAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/SelectAll.gif"></asp:imagebutton></TD>
										</TR>
										<TR>
											<TD>
												<asp:imagebutton id="BtnRemSociety" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Remove.gif"></asp:imagebutton></TD>
										</TR>
										<TR>
											<TD>
												<asp:imagebutton id="BtnRemSocietyAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/RemoveAll.gif"></asp:imagebutton></TD>
										</TR>
									</TABLE>
								</TD>
								<TD vAlign="top">
									<asp:listbox id="LstSelSociety" runat="server" CssClass=" " Width="200px" SelectionMode="Multiple"
										Rows="100" Height="150px" TabIndex="3"></asp:listbox></TD>
								
							</TR>
                                                                                <TR>
																					<TD><asp:label id="Label2" runat="server" CssClass="Lables" Width="100%">Year of Start</asp:label></TD>
								                                                    <TD></TD>
								                                                    <TD><asp:label id="Label4" runat="server" CssClass="Lables" Width="100%">Selected</asp:label></TD>
								                                                    
																				</TR>

                                                                                <TR>
																					<TD><asp:listbox id="LstYear" runat="server" CssClass=" " Width="200px" Height="150px" Rows="100"
										                                                SelectionMode="Multiple" TabIndex="4"></asp:listbox></TD>
								                                                    <TD>
									                                            <TABLE id="Table122" cellSpacing="0" cellPadding="0" width="30" border="0">
										                        <TR>
											                          <TD><asp:imagebutton id="BtnSelYear" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Select.gif"></asp:imagebutton></TD>
										                        </TR>
										                        <TR>
											                        <TD><asp:imagebutton id="BtnSelYearAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/SelectAll.gif"></asp:imagebutton></TD>
										                        </TR>
										                        <TR>
											                        <TD><asp:imagebutton id="BtnRemYear" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Remove.gif"></asp:imagebutton></TD>
										                        </TR>
										                        <TR>
											                        <TD><asp:imagebutton id="BtnRemYearAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/RemoveAll.gif"></asp:imagebutton></TD>
										                        </TR>
									                        </TABLE>
								                                                    </TD>
								                                                    <TD><asp:listbox id="LstSelYear" runat="server" CssClass=" " Width="200px" Height="150px" Rows="100"
										SelectionMode="Multiple" TabIndex="5"></asp:listbox></TD>
								                                                    
																				</TR>

							</TABLE>
							<TABLE id="Table11" border="1" cellSpacing="1" cellPadding="1" width="100%">
							    <TR>
								    <TD><asp:checkbox id="Chkblddate" runat="server" CssClass="lables1" Width="100%" Text="Search On Buliding Maturity Date"
									    AutoPostBack="True"></asp:checkbox></TD>
									<TD><asp:checkbox id="Chkfdrdate" runat="server" CssClass="lables1" Width="100%" Text="Search On Fdr Maturity Date"
									    AutoPostBack="True"></asp:checkbox></TD>
									<TD><asp:checkbox id="ChkAffilidate" runat="server" CssClass="lables1" Width="100%" Text="Search On Affiliation Date"
									    AutoPostBack="True"></asp:checkbox></TD>
								</TR>
								<TR>
								    <TD><asp:panel style="Z-INDEX: 0" id="PNL1" Width="250px" Runat="server"><FONT color="#cc9966"><STRONG>&nbsp;&nbsp;&nbsp; 
									    FROM DATE</STRONG>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<STRONG>
										TO DATE</STRONG></FONT>
																							<asp:TextBox id="Bldfromdate" Font-Bold="True" Width="120px" Runat="server" ForeColor="Black"></asp:TextBox>
																							<asp:TextBox id="bldtodate" Font-Bold="True" Width="120px" Runat="server" ForeColor="Black"></asp:TextBox>
																						</asp:panel></TD>
																					<TD><asp:panel style="Z-INDEX: 0" id="PNL2" Width="250px" Runat="server"><FONT color="#cc9966"><STRONG>&nbsp;&nbsp; 
																									FROM DATE</STRONG>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<STRONG>
																									TO DATE</STRONG></FONT>
																							<asp:TextBox id="FDRFROMDATE" Font-Bold="True" Width="120px" Runat="server" ForeColor="Black"></asp:TextBox>
																							<asp:TextBox id="fdrtodate" Font-Bold="True" Width="120px" Runat="server" ForeColor="Black"></asp:TextBox>
																						</asp:panel></TD>
																					<TD><asp:panel style="Z-INDEX: 0" id="PNL3" Width="250px" Runat="server"><FONT color="#cc9966"><STRONG>&nbsp;&nbsp;&nbsp; 
																									FROM&nbsp;YEAR</STRONG>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<STRONG>
																									TO&nbsp;YEAR</STRONG></FONT>
																							<asp:TextBox id="AFFILFROMDATE" Font-Bold="True" Width="120px" Runat="server" ForeColor="Black"></asp:TextBox>
																							<asp:TextBox id="Affilitodate" Font-Bold="True" Width="120px" Runat="server" ForeColor="Black"></asp:TextBox>
																						</asp:panel></TD>
																				</TR>
																			</TABLE>
																		</TD>
																	</TR>
																	<TR>
																		<TD colSpan="5" align="right"><asp:imagebutton accessKey="S" id="iBtnSave" tabIndex="10" runat="server" Width="92px" Height="20px"
																				ImageUrl="../../../Images/NewImages/report.gif"></asp:imagebutton></TD>
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
								<TR>
									<TD vAlign="top" align="center">
										<TABLE style="Z-INDEX: 0; WIDTH: 154px; HEIGHT: 29px" id="Table10" border="0" cellSpacing="1"
											cellPadding="1" width="154" align="center">
											<TR>
												<TD align="center">&nbsp;
													<TABLE id="Table8" border="0" cellSpacing="0" cellPadding="0" width="100" runat="server">
														<TR>
															<TD><INPUT style="Z-INDEX: 0; TEXT-ALIGN: center; BACKGROUND-COLOR: #ff6666; WIDTH: 120px; HEIGHT: 25px; COLOR: #ffffcc"
																	onclick="excelExp('tblSecAdopt','CollegeBoard');" value="Download Excel" type="button"></TD>
														</TR>
													</TABLE>
												</TD>
												<TD align="center">
													<asp:textbox style="Z-INDEX: 0" id="txtfilename" runat="server" Width="0px"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
							<asp:table id="tblSecAdopt" runat="server"></asp:table></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center">
						</TD>
					</TR>
				</TBODY>
			</TABLE>
			</TD></TR></TBODY></TABLE></form>
	</body>
</HTML>
