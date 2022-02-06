<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Building_PG_Dt.aspx.vb" Inherits="CollegeBoard.BUILDING_PG_DT" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>BUILDING_PG_DT</title>
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
		<form id="Form1" method="post" autocomplete="off" runat="server">
			<asp:textbox id="txtlblCode" runat="server" Width="0px" Height="32px">XXXXXX</asp:textbox>
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
															<TD class="SubHeading"><asp:label id="lblHeading" runat="server" Width="100%" Font-Bold="True" CssClass="SubHeading1"> List  of College Wise Details  of Build and  Play Ground </asp:label></TD>
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
                                                            <TD width="250"><asp:TextBox ID="lstmCode" runat="server" Width="152px"></asp:TextBox>
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
														CellSpacing="2" OnItemCreated="DeleteConformationMessage" BorderStyle="Dotted" CellPadding="0" BorderWidth="0px" AutoGenerateColumns="False"
														AllowPaging="True">
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
															<asp:BoundColumn Visible="False" DataField="BLDSLNO" HeaderText="SLNO">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
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
												<TD class="TableBorder" vAlign="middle" align="right"><asp:imagebutton accessKey="S" id="iBtnAdd" tabIndex="5" runat="server" Width="92px" Height="20px"
														ImageUrl="../../Images/NewImages/add.gif"></asp:imagebutton>&nbsp;&nbsp;&nbsp;
												</TD>
											</TR>
										</TABLE>
										<TABLE id="Table4" border="0" cellSpacing="0" cellPadding="0" width="426" runat="server">
											<TR>
												<TD align="center">
													<P>&nbsp;</P>
													<P>&nbsp;</P>
												</TD>
											</TR>
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
																					<TD class="SubHeading"><asp:label id="Label10" runat="server" Width="264px" Height="8px" Font-Bold="True" CssClass="SubHeading1"> Building and  Play Ground Details </asp:label></TD>
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
																			<TABLE id="Table5" border="0" cellSpacing="0" cellPadding="0" width="330">
																				<TR>
																					<TD style="WIDTH: 116px"><asp:label style="Z-INDEX: 0" id="Label2" runat="server" Width="128px" Height="19px" CssClass="Lables">College Code</asp:label></TD>
																					<TD style="WIDTH: 29px"><asp:textbox style="Z-INDEX: 0" id="Txtccode" runat="server" Width="59px" CssClass=" " MaxLength="10"></asp:textbox></TD>
																					<TD align="left"><asp:imagebutton accessKey="G" id="imgBtnGo" tabIndex="1" runat="server" Width="75px" Height="17px"
																							ImageUrl="../../Images/NewImages/search.gif"></asp:imagebutton></TD>
																				</TR>
																				<TR>
																					<TD colSpan="3" align="center"><asp:label style="Z-INDEX: 0" id="LBLCLGNAME" runat="server" Width="100%" Height="19px" CssClass="Lables"
																							BackColor="Info">College Name</asp:label></TD>
																				</TR>
																			</TABLE>
																			<TABLE id="Table10" border="0" cellSpacing="0" cellPadding="0" width="100%">
																				<TR>
																					<TD style="WIDTH: 108px"><asp:label id="Label1" runat="server" Width="100%" Height="14px" CssClass="Lables"> Building</asp:label></TD>
																					<TD><asp:dropdownlist id="drpBuilding" tabIndex="2" runat="server" Width="150px" CssClass=" " AutoPostBack="True">
																							<asp:ListItem Value="0">Select</asp:ListItem>
																							<asp:ListItem Value="1">Rented</asp:ListItem>
																							<asp:ListItem Value="2">Registered Lease</asp:ListItem>
																						</asp:dropdownlist></TD>
																				</TR>
																				<TR>
																					<TD colSpan="2">
																						<TABLE id="tblbuld" border="0" cellSpacing="0" cellPadding="0" width="305" runat="server">
																							<TR>
																								<TD style="WIDTH: 109px; HEIGHT: 19px"><asp:label id="Label3" runat="server" Width="100%" Height="19px" CssClass="Lables">Period From</asp:label></TD>
																								<TD style="WIDTH: 122px; HEIGHT: 19px"><asp:textbox id="txtrlpfrom" tabIndex="3" runat="server" Width="100%" CssClass=" " MaxLength="11"></asp:textbox></TD>
																								<TD style="HEIGHT: 19px"><A href="javascript:NewCal('<% =txtrlpfrom.ClientID %>','DDMMMYYYY')" ><IMG border="0" align="absBottom" src="../../Images/calendar.gif" width="24" height="19"
																											useMap="../Images/ReportImages/calendar.gif"></A></TD>
																							</TR>
																							<TR>
																								<TD style="WIDTH: 109px"><asp:label id="Label4" runat="server" Width="100%" Height="19px" CssClass="Lables"> Period To</asp:label></TD>
																								<TD style="WIDTH: 122px"><asp:textbox id="txtrlpto" tabIndex="4" runat="server" Width="100%" CssClass=" " MaxLength="11"></asp:textbox></TD>
																								<TD><A href="javascript:NewCal('<% =txtrlpto.ClientID %>','DDMMMYYYY')" ><IMG border="0" align="absBottom" src="../../Images/calendar.gif" width="24" height="19"
																											useMap="../Images/ReportImages/calendar.gif"></A></TD>
																							</TR>
																						</TABLE>
																					</TD>
																				</TR>
																				<TR>
																					<TD style="WIDTH: 108px"><asp:label id="Label6" runat="server" Width="100%" Height="14px" CssClass="Lables"> Plinth Area</asp:label></TD>
																					<TD><asp:textbox id="txtplingarea" tabIndex="5" runat="server" Width="150px" CssClass=" " MaxLength="10"></asp:textbox></TD>
																				</TR>
																				<TR>
																					<TD style="WIDTH: 108px"><asp:label id="Label7" runat="server" Width="100%" Height="14px" CssClass="Lables"> Play Ground Type</asp:label></TD>
																					<TD><asp:dropdownlist id="drppgtype" tabIndex="6" runat="server" Width="150px" CssClass=" " AutoPostBack="True">
																							<asp:ListItem Value="0">Select</asp:ListItem>
																							<asp:ListItem Value="1">Rented</asp:ListItem>
																							<asp:ListItem Value="2">Registered Lease</asp:ListItem>
																							<asp:ListItem Value="3">Sft</asp:ListItem>
																							<asp:ListItem Value="4">NILL</asp:ListItem>
																						</asp:dropdownlist></TD>
																				</TR>
																				<TR>
																					<TD colSpan="2">
																						<TABLE id="Tblpg" border="0" cellSpacing="0" cellPadding="0" width="304" runat="server">
																							<TR>
																								<TD style="WIDTH: 108px"><asp:label id="Label9" runat="server" Width="100%" Height="19px" CssClass="Lables">Period From</asp:label></TD>
																								<TD style="WIDTH: 124px"><asp:textbox id="txtpgpfrom" tabIndex="7" runat="server" Width="100%" CssClass=" " MaxLength="10"
																										ReadOnly="True"></asp:textbox></TD>
																								<TD><A href="javascript:NewCal('<% =txtpgpfrom.ClientID %>','DDMMMYYYY')" ><IMG border="0" align="absBottom" src="../../Images/calendar.gif" width="24" height="19"
																											useMap="../Images/ReportImages/calendar.gif"></A></TD>
																							</TR>
																							<TR>
																								<TD style="WIDTH: 108px"><asp:label id="Label8" runat="server" Width="100%" Height="19px" CssClass="Lables"> Period To</asp:label></TD>
																								<TD style="WIDTH: 124px"><asp:textbox id="txtpgpto" tabIndex="8" runat="server" Width="100%" CssClass=" " MaxLength="10"
																										ReadOnly="True"></asp:textbox></TD>
																								<TD><A href="javascript:NewCal('<% =txtpgpto.ClientID %>','DDMMMYYYY')" ><IMG border="0" align="absBottom" src="../../Images/calendar.gif" width="24" height="19"
																											useMap="../Images/ReportImages/calendar.gif"></A></TD>
																							</TR>
																						</TABLE>
																				<TR>
																					<TD style="WIDTH: 108px"><asp:label id="Label11" runat="server" Width="100%" Height="14px" CssClass="Lables"> Land Type</asp:label></TD>
																					<TD><asp:dropdownlist id="drplandtype" tabIndex="9" runat="server" Width="150px" CssClass=" " AutoPostBack="True">
																							<asp:ListItem Value="0">Select</asp:ListItem>
																							<asp:ListItem Value="1">Acres</asp:ListItem>
																							<asp:ListItem Value="2">Gunta</asp:ListItem>
																						</asp:dropdownlist></TD>
																				</TR>
																				<TR>
																					<TD style="WIDTH: 108px"><asp:label id="Label12" runat="server" Width="100%" Height="14px" CssClass="Lables"> Distance PGround</asp:label></TD>
																					<TD><asp:textbox id="txtdistpg" tabIndex="10" runat="server" Width="150px" CssClass=" " MaxLength="10"></asp:textbox></TD>
																				</TR>
																				<TR>
																					<TD style="WIDTH: 108px"><asp:label id="Label13" runat="server" Width="100%" Height="14px" CssClass="Lables"> Parking Area</asp:label></TD>
																					<TD><asp:textbox id="txtparkarea" tabIndex="11" runat="server" Width="150px" CssClass=" " MaxLength="10"></asp:textbox></TD>
																				</TR>
																				<TR>
																					<TD style="WIDTH: 108px">
																						<asp:label style="Z-INDEX: 0" id="Label14" runat="server" Height="14px" Width="100%" CssClass="Lables">Building Type</asp:label></TD>
																					<TD>
																						<asp:dropdownlist style="Z-INDEX: 0" id="Drpbuldtype" tabIndex="12" runat="server" Width="150px" CssClass=" "
																							AutoPostBack="True">
																							<asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
																							<asp:ListItem Value="1">RCC</asp:ListItem>
																							<asp:ListItem Value="2">ACC</asp:ListItem>
																							<asp:ListItem Value="3">Shed</asp:ListItem>
																						</asp:dropdownlist></TD>
																				</TR>
																		</TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
														<TR>
															<TD class="TableBorder" vAlign="middle" align="right"><asp:imagebutton accessKey="S" style="Z-INDEX: 0" id="iBtnSave" tabIndex="13" runat="server" Width="92px"
																	Height="20px" ImageUrl="../../Images/NewImages/save.gif"></asp:imagebutton>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
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
			</TD></TR></TBODY></TABLE></form>
		</TD></TR></TBODY></TABLE>
	</body>
</HTML>
