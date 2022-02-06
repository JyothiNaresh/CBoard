<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Affilation_Dt.aspx.vb" Inherits="CollegeBoard.Affilation_Dt" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Affilation_Dt</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK id="Link1" rel="stylesheet" type="text/css" href="../../Images/Login/StyleSheet_Report.css">
		<LINK rel="stylesheet" type="text/css" href="../../Styles/MultiComboSelect/jquery.multiselect.css">
		<LINK rel="stylesheet" type="text/css" href="../../Styles/MultiComboSelect/jquery.multiselect.filter.css">
		<LINK rel="stylesheet" type="text/css" href="../../Styles/MultiComboSelect/jquery-ui.css">
		<LINK rel="stylesheet" type="text/css" href="../../Styles/MultiComboSelect/prettify.css">
		<%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.js"></script>
		<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1/jquery-ui.min.js"></script>
		<script type="text/javascript" src="http://www.erichynds.com/examples/jquery-ui-multiselect-widget/src/jquery.multiselect.js"></script>
		<script type="text/javascript" src="http://www.erichynds.com/examples/jquery-ui-multiselect-widget/src/jquery.multiselect.filter.js"></script>
		<SCRIPT language="javascript" type="text/javascript" src="../../Modules/ts_picker.js">
		
		function showFocus()
		 {
			var id = event.srcElement.id
			alert("Pick Date")
		}
		
		</SCRIPT>
		<script language="javascript" type="text/javascript">
		 function checkNum()
			{
				var carCode = event.keyCode;if ((carCode < 48) || (carCode > 57))
			{
				alert('Please enter only numbers.');
				event.cancelBubble = true
				event.returnValue = false;
			}}
		</script>
		<script type="text/javascript">
			$(function(){
				
				$("#lstmCode").multiselect({multiple: true,noneSelectedText: "Select College Code",checkAllText:'Sel.All',uncheckAllText:'Rem.All',selectedList: 3,minWidth:200}).multiselectfilter({filter: function(event, matches){
					if( !matches.length ){ 
						}	}	});									
				});			
		</script>--%>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server" autocomplete="off">
			<asp:textbox id="txtlblCode" runat="server" Height="32px" Width="0px">XXXXXX</asp:textbox>
			<TABLE id="Table0" border="0" cellSpacing="1" cellPadding="1" width="100%">
				<TBODY>
					<TR>
						<TD vAlign="top" align="center">
							<TABLE id="Table1" class="Panel" border="0" cellSpacing="0" cellPadding="0">
								<TR>
									<TD align="center">
										<TABLE id="Table2" border="0" cellSpacing="0" cellPadding="0">
											<TR>
												<TD class="DarkColor">
													<TABLE id="Table3" border="0" cellSpacing="0" cellPadding="0" width="100%">
														<TR>
															<TD vAlign="top" width="11"><IMG src="../../Images/Login/table-lcorw.gif" width="11" height="11"></TD>
															<TD class="SubHeading"><asp:label id="lblHeading" runat="server" Width="100%" CssClass="SubHeading1" Font-Bold="True"> List  of College Wise  Details  of Affiliations  </asp:label></TD>
															<TD vAlign="top" width="11"><IMG src="../../Images/Login/table-rcorw.gif" width="11" height="11"></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD class="TdBorder"><IMG src="../../Images/Login/spacer.gif" width="1" height="1"></TD>
											</TR>
											<TR>
												<TD class="TableBorder" vAlign="top" align="center">
													<TABLE id="Table12" border="0" cellSpacing="0" cellPadding="0" width="200">
														<TR>
															<%--<TD width="250"><SELECT style="Z-INDEX: 0; WIDTH: 100px" multiple name="Prdcity" RUNAT="server" id="lstmCode"></SELECT></TD>--%>
                                                            <TD width="250">
                                                                <asp:TextBox ID="lstmCode" runat="server" Width="152px"></asp:TextBox>
                                                            </TD>
															<TD><asp:imagebutton accessKey="G" style="Z-INDEX: 0" id="imgBtnGoo1" tabIndex="1" runat="server" Width="40px"
																	Height="17px" ImageUrl="../../Images/NewImages/go.gif"></asp:imagebutton></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD class="TableBorder" vAlign="top" align="center"></TD>
											</TR>
											<TR>
												<TD class="TableBorder" vAlign="top" align="center"><asp:datagrid id="dgGridSection" tabIndex="1" runat="server" Width="198px" CssClass="GridMain"
														AllowPaging="True" AutoGenerateColumns="False" BorderWidth="0px" CellPadding="0" BorderStyle="Dotted" OnItemCreated="DeleteConformationMessage"
														CellSpacing="2">
														<SelectedItemStyle Font-Bold="True"></SelectedItemStyle>
														<AlternatingItemStyle CssClass="GridAlternateItem"></AlternatingItemStyle>
														<HeaderStyle Font-Bold="True" CssClass="GridHeader"></HeaderStyle>
														<Columns>
															<asp:TemplateColumn HeaderText="S.No">
																<HeaderStyle HorizontalAlign="Center" Width="10%" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																<ItemTemplate>
																	<asp:Label id=Label5 runat="server" Text='<%# DataBinder.Eval(Container, "DataSetIndex")+1 %>'>
																	</asp:Label>
																</ItemTemplate>
																<FooterStyle Wrap="False"></FooterStyle>
															</asp:TemplateColumn>
															<asp:BoundColumn Visible="False" DataField="AFFLSLNO" HeaderText="SLNO">
																<HeaderStyle VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="CCODE" HeaderText="College Code">
																<HeaderStyle Wrap="False" HorizontalAlign="Center" Width="10%" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="COLLEGENAME" HeaderText="College Name">
																<HeaderStyle Wrap="False" Width="10%" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle Wrap="False" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:EditCommandColumn ButtonType="PushButton" UpdateText="Update" CancelText="Cancel" EditText="Edit">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:EditCommandColumn>
															<asp:ButtonColumn Text="Delete" ButtonType="PushButton" CommandName="Delete">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:ButtonColumn>
														</Columns>
														<PagerStyle HorizontalAlign="Center" CssClass="GridPager" Mode="NumericPages"></PagerStyle>
													</asp:datagrid></TD>
											</TR>
											<TR>
												<TD class="TableBorder" vAlign="middle" align="right"><asp:imagebutton accessKey="S" id="iBtnAdd" tabIndex="5" runat="server" Height="20px" Width="92px"
														ImageUrl="../../Images/NewImages/add.gif"></asp:imagebutton>&nbsp;&nbsp;&nbsp;
												</TD>
											</TR>
										</TABLE>
										<p></p>
									</TD>
								</TR>
							</TABLE>
							<TABLE id="Table4" border="0" cellSpacing="0" cellPadding="0" width="384" runat="server">
								<TR>
									<TD align="center">
										<TABLE id="Table6" class="Panel" border="0" cellSpacing="0" cellPadding="0">
											<TR>
												<TD align="center">
													<TABLE id="Table7" border="0" cellSpacing="0" cellPadding="0">
														<TR>
															<TD class="DarkColor">
																<TABLE id="Table8" border="0" cellSpacing="0" cellPadding="0" width="100%">
																	<TR>
																		<TD vAlign="top" width="11"><IMG src="../../Images/Login/table-lcorw.gif" width="11" height="11"></TD>
																		<TD class="SubHeading"><asp:label id="Label10" runat="server" Height="8px" Width="264px" CssClass="SubHeading1" Font-Bold="True"> Affiliation Entry Details </asp:label></TD>
																		<TD vAlign="top" width="11"><IMG src="../../Images/Login/table-rcorw.gif" width="11" height="11"></TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
														<TR>
															<TD class="TdBorder"><IMG src="../../Images/Login/spacer.gif" width="1" height="1"></TD>
														</TR>
														<TR>
															<TD class="TableBorder" vAlign="top" align="left">
																<TABLE id="Table9" border="0" cellSpacing="0" cellPadding="0">
																</TABLE>
																<TABLE id="Table5" border="0" cellSpacing="0" cellPadding="0" width="208" style="WIDTH: 208px; HEIGHT: 51px">
																	<TR>
																		<TD style="WIDTH: 189px"><asp:label id="Label2" runat="server" Height="19px" Width="136px" CssClass="Lables">College Code</asp:label></TD>
																		<TD><asp:textbox id="Txtccode" runat="server" Width="59px" CssClass=" " MaxLength="5"></asp:textbox></TD>
																		<TD align="left"><asp:imagebutton accessKey="G" id="imgBtnGo" tabIndex="1" runat="server" Height="17px" Width="75px"
																				ImageUrl="../../Images/NewImages/search.gif"></asp:imagebutton></TD>
																	</TR>
																	<TR>
																		<TD colSpan="3" align="center"><asp:label id="LBLCLGNAME" runat="server" Height="19px" Width="270px" CssClass="Lables" BackColor="Info">College Name</asp:label></TD>
																	</TR>
																	<TR>
																		<TD colSpan="3">
																			<TABLE id="Table10" border="0" cellSpacing="0" cellPadding="0" width="216" style="WIDTH: 216px; HEIGHT: 188px">
																				<TR>
																					<TD style="WIDTH: 128px"><asp:label id="Label1" runat="server" Height="14px" Width="136px" CssClass="Lables" style="Z-INDEX: 0"> Paid Amount</asp:label></TD>
																					<TD><asp:textbox id="Textbox1" runat="server" Width="104px" CssClass=" " MaxLength="16" style="Z-INDEX: 0"
																							tabIndex="2"></asp:textbox></TD>
																				</TR>
																				<TR>
																					<TD style="WIDTH: 128px"><asp:label id="Label7" runat="server" Height="14px" Width="136px" CssClass="Lables" style="Z-INDEX: 0"> Due Amount</asp:label></TD>
																					<TD><asp:textbox id="Textbox2" runat="server" Width="104px" CssClass=" " MaxLength="16" style="Z-INDEX: 0"
																							tabIndex="3"></asp:textbox></TD>
																				</TR>
																				<TR>
																					<TD style="WIDTH: 128px"><asp:label id="Label11" runat="server" Height="14px" Width="136px" CssClass="Lables" style="Z-INDEX: 0"> Surplus with BIE</asp:label></TD>
																					<TD><asp:textbox id="Textbox3" runat="server" Width="104px" CssClass=" " MaxLength="16" style="Z-INDEX: 0"
																							tabIndex="4"></asp:textbox></TD>
																				</TR>
																				<TR>
																					<TD style="WIDTH: 128px"><asp:label id="Label6" runat="server" Height="14px" Width="136px" CssClass="Lables" style="Z-INDEX: 0"> Affiliation Year</asp:label></TD>
																					<TD><asp:textbox id="Textbox4" runat="server" Width="104px" CssClass=" " MaxLength="10" style="Z-INDEX: 0"
																							tabIndex="5"></asp:textbox></TD>
																				</TR>
																				<TR>
																					<TD style="WIDTH: 128px; HEIGHT: 2px"><asp:label id="Label17" runat="server" Height="14px" Width="136px" CssClass="Lables" style="Z-INDEX: 0">  Additional  Sections</asp:label></TD>
																					<TD style="HEIGHT: 2px"><asp:textbox id="Textbox13" runat="server" Width="104px" CssClass=" " MaxLength="10" style="Z-INDEX: 0"
																							tabIndex="5"></asp:textbox></TD>
																				</TR>
																				<TR>
																					<TD style="WIDTH: 128px"><asp:label id="Label8" runat="server" Height="14px" Width="136px" CssClass="Lables" style="Z-INDEX: 0"> Application Cost</asp:label></TD>
																					<TD><asp:textbox id="Textbox5" runat="server" Width="104px" CssClass=" " MaxLength="10" style="Z-INDEX: 0"
																							tabIndex="6"></asp:textbox></TD>
																				</TR>
																				<TR>
																					<TD style="WIDTH: 128px"><asp:label id="Label9" runat="server" Height="14px" Width="136px" CssClass="Lables" style="Z-INDEX: 0"> Original Sections Fee</asp:label></TD>
																					<TD><asp:textbox id="Textbox6" runat="server" Width="104px" CssClass=" " MaxLength="10" style="Z-INDEX: 0"
																							tabIndex="7"></asp:textbox></TD>
																				</TR>
																				<TR>
																					<TD style="WIDTH: 128px"><asp:label id="Label12" runat="server" Height="14px" Width="136px" CssClass="Lables" style="Z-INDEX: 0"> Additional Sections Fee</asp:label></TD>
																					<TD><asp:textbox id="Textbox7" runat="server" Width="104px" CssClass=" " MaxLength="10" style="Z-INDEX: 0"
																							tabIndex="8"></asp:textbox></TD>
																				</TR>
																				<TR>
																					<TD style="WIDTH: 128px"><asp:label id="Label13" runat="server" Height="14px" Width="136px" CssClass="Lables" style="Z-INDEX: 0"> Inspection Fee</asp:label></TD>
																					<TD><asp:textbox id="Textbox8" runat="server" Width="104px" CssClass=" " MaxLength="10" style="Z-INDEX: 0"
																							tabIndex="9"></asp:textbox></TD>
																				</TR>
																				<TR>
																					<TD style="WIDTH: 128px"><asp:label id="Label14" runat="server" Height="14px" Width="136px" CssClass="Lables" style="Z-INDEX: 0"> Late Fee</asp:label></TD>
																					<TD><asp:textbox id="Textbox9" runat="server" Width="104px" CssClass=" " MaxLength="10" style="Z-INDEX: 0"
																							tabIndex="10"></asp:textbox></TD>
																				</TR>
																				<TR>
																					<TD style="WIDTH: 128px"><asp:label id="Label15" runat="server" Height="14px" Width="136px" CssClass="Lables" style="Z-INDEX: 0"> Payment Type</asp:label></TD>
																					<TD><asp:dropdownlist id="drppgtype" tabIndex="11" runat="server" Width="105px" CssClass=" " style="Z-INDEX: 0">
																							<asp:ListItem Value="0">Select</asp:ListItem>
																							<asp:ListItem Value="1">Challan</asp:ListItem>
																							<asp:ListItem Value="2">DD</asp:ListItem>
																						</asp:dropdownlist></TD>
																				</TR>
																			</TABLE>
																		</TD>
																	</TR>
																</TABLE>
																<TABLE id="Table20" border="0" cellSpacing="0" cellPadding="0" width="100%">
																	<TBODY>
																		<TR>
																			<TD colSpan="2">
																				<TABLE id="tblbuld" border="0" cellSpacing="0" cellPadding="0" width="256" runat="server">
																					<TR>
																						<TD style="WIDTH: 144px"><asp:label id="Label18" runat="server" Height="19px" Width="136px" CssClass="Lables" style="Z-INDEX: 0"> Bank Name</asp:label></TD>
																						<TD style="WIDTH: 66px"><asp:textbox id="Textbox14" tabIndex="12" runat="server" Width="104px" CssClass=" " MaxLength="50"></asp:textbox></TD>
																					</TR>
																					<TR>
																						<TD style="WIDTH: 144px"><asp:label id="Label16" runat="server" Height="19px" Width="136px" CssClass="Lables" style="Z-INDEX: 0"> No</asp:label></TD>
																						<TD style="WIDTH: 66px"><asp:textbox id="Textbox10" tabIndex="13" runat="server" Width="104px" CssClass=" " MaxLength="16"></asp:textbox></TD>
																					</TR>
																					<TR>
																						<TD style="WIDTH: 144px"><asp:label id="Label3" runat="server" Height="18px" Width="100%" CssClass="Lables"> Date</asp:label></TD>
																						<TD style="WIDTH: 66px"><asp:textbox id="Textbox11" tabIndex="14" runat="server" Width="104px" CssClass=" " MaxLength="11"></asp:textbox></TD>
																						<TD><A href="javascript:NewCal('<% =Textbox11.ClientID %>','DDMMMYYYY')" ><IMG border="0" align="absBottom" src="../../Images/calendar.gif" width="24" height="19"
																									useMap="../../../Images/ReportImages/calendar.gif"></A></TD>
																					</TR>
																					<TR>
																						<TD style="WIDTH: 144px"><asp:label id="Label4" runat="server" Height="18px" Width="100%" CssClass="Lables"> Amount</asp:label></TD>
																						<TD style="WIDTH: 66px"><asp:textbox id="Textbox12" tabIndex="15" runat="server" Width="104px" CssClass=" " MaxLength="16"></asp:textbox></TD>
																					</TR>
																				</TABLE>
																			</TD>
																		</TR>
															</TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD class="TableBorder" vAlign="middle" align="right"><asp:imagebutton accessKey="S" id="iBtnSave" tabIndex="16" runat="server" Height="20px" Width="92px"
														ImageUrl="../../Images/NewImages/save.gif"></asp:imagebutton></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD align="center"></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
			</TD></TR></TBODY></TABLE></form>
		</TD></TR></TBODY></TABLE>
	</body>
</HTML>
