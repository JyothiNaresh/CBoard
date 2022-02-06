<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Cetificates_Dt.aspx.vb" Inherits="CollegeBoard.Cetificates_Dt" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>Cetificates_Dt</TITLE>
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
															<TD class="SubHeading"><asp:label id="lblHeading" runat="server" Width="100%" CssClass="SubHeading1" Font-Bold="True"> List  of College Wise Details  of Certificates </asp:label></TD>
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
												<TD class="TableBorder" vAlign="top" align="center">
													<asp:datagrid style="Z-INDEX: 0" id="dgGridSection" tabIndex="1" runat="server" CssClass="GridMain"
														Width="198px" AllowPaging="True" AutoGenerateColumns="False" BorderWidth="0px" CellPadding="0"
														BorderStyle="Dotted" OnItemCreated="DeleteConformationMessage" CellSpacing="2">
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
															<asp:BoundColumn Visible="False" DataField="CERTFSLNO" HeaderText="SLNO">
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
												<TD class="TableBorder" vAlign="middle" align="right"><asp:imagebutton accessKey="S" id="iBtnAdd" tabIndex="5" runat="server" Height="20px" Width="92px"
														ImageUrl="../../Images/NewImages/add.gif"></asp:imagebutton>&nbsp;&nbsp;&nbsp;
												</TD>
											</TR>
										</TABLE>
										<p></p>
									</TD>
								</TR>
							</TABLE>
							<TABLE style="Z-INDEX: 0" id="Table4" border="1" cellSpacing="0" cellPadding="0" width="384"
								runat="server">
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
																		<TD class="SubHeading">
																			<asp:label style="Z-INDEX: 0" id="Label10" runat="server" CssClass="SubHeading1" Font-Bold="True"
																				Width="264px" Height="8px"> Certificates Entry Details </asp:label></TD>
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
																<TABLE id="Table9" border="0" cellSpacing="0" cellPadding="0">
																</TABLE>
																<TABLE id="Table5" border="0" cellSpacing="0" cellPadding="0" width="330">
																	<TR>
																		<TD style="WIDTH: 358px">
																			<asp:label style="Z-INDEX: 0" id="Label2" runat="server" CssClass="Lables" Width="100%" Height="19px">College Code</asp:label></TD>
																		<TD style="WIDTH: 29px">
																			<asp:textbox style="Z-INDEX: 0" id="Txtccode" onkeypress="checkNum()" runat="server" CssClass=" "
																				Width="59px" MaxLength="5"></asp:textbox></TD>
																		<TD align="left">
																			<asp:imagebutton accessKey="G" id="imgBtnGo" tabIndex="1" runat="server" Width="75px" Height="17px"
																				ImageUrl="../../Images/NewImages/search.gif"></asp:imagebutton></TD>
																	</TR>
																	<TR>
																		<TD colSpan="3" align="center">
																			<asp:label style="Z-INDEX: 0" id="LBLCLGNAME" runat="server" CssClass="Lables" Width="344px"
																				Height="19px" BackColor="Info">College Name</asp:label></TD>
																	</TR>
																</TABLE>
																<TABLE id="Table20" border="1" cellSpacing="0" cellPadding="0" width="272" style="WIDTH: 272px; HEIGHT: 56px"
																	align="left">
																	<TBODY>
																		<TR>
																			<TD style="WIDTH: 106px; HEIGHT: 8px">
																				<asp:label id="Label1" runat="server" CssClass="Lables" Width="100%" Height="14px"> Fire Safety</asp:label></TD>
																			<TD style="WIDTH: 63px; HEIGHT: 8px">
																				<asp:dropdownlist style="Z-INDEX: 0" id="Drpfire1" tabIndex="3" runat="server" Width="91px" CssClass=" "
																					AutoPostBack="True">
																					<asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
																					<asp:ListItem Value="1">Yes</asp:ListItem>
																					<asp:ListItem Value="2">No</asp:ListItem>
																				</asp:dropdownlist></TD>
																			<TD style="HEIGHT: 8px">
																				<asp:dropdownlist style="Z-INDEX: 0" id="Drpfire2" tabIndex="4" runat="server" Width="88px" CssClass=" "
																					Visible="False">
																					<asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
																					<asp:ListItem Value="1">Submitted</asp:ListItem>
																					<asp:ListItem Value="2">Not Submitted</asp:ListItem>
																				</asp:dropdownlist></TD>
																		</TR>
																		<TR>
																			<TD style="WIDTH: 106px">
																				<asp:label id="Label7" runat="server" CssClass="Lables" Width="100%" Height="14px"> Sanitory</asp:label></TD>
																			<TD style="WIDTH: 63px">
																				<asp:dropdownlist id="drpsant1" tabIndex="5" runat="server" CssClass=" " Width="91px" style="Z-INDEX: 0"
																					AutoPostBack="True">
																					<asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
																					<asp:ListItem Value="1">Yes</asp:ListItem>
																					<asp:ListItem Value="2">No</asp:ListItem>
																				</asp:dropdownlist></TD>
																			<TD style="WIDTH: 91px">
																				<asp:dropdownlist style="Z-INDEX: 0" id="drpsant2" tabIndex="6" runat="server" Width="100%" CssClass=" "
																					Visible="False">
																					<asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
																					<asp:ListItem Value="1">Submitted</asp:ListItem>
																					<asp:ListItem Value="2">Not Submitted</asp:ListItem>
																				</asp:dropdownlist></TD>
																		</TR>
																		<TR>
																			<TD style="WIDTH: 106px">
																				<asp:label id="Label11" runat="server" CssClass="Lables" Width="100%" Height="14px"> Structural</asp:label></TD>
																			<TD style="WIDTH: 63px">
																				<asp:dropdownlist id="drpstruc1" tabIndex="7" runat="server" CssClass=" " Width="91px" style="Z-INDEX: 0"
																					AutoPostBack="True">
																					<asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
																					<asp:ListItem Value="1">Yes</asp:ListItem>
																					<asp:ListItem Value="2">No </asp:ListItem>
																				</asp:dropdownlist></TD>
																			<TD style="WIDTH: 91px">
																				<asp:dropdownlist style="Z-INDEX: 0" id="drpstruc2" tabIndex="8" runat="server" Width="100%" CssClass=" "
																					Visible="False">
																					<asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
																					<asp:ListItem Value="1">Submitted</asp:ListItem>
																					<asp:ListItem Value="2">Not Submitted</asp:ListItem>
																				</asp:dropdownlist></TD>
																		</TR>
																		<TR>
																			<TD style="WIDTH: 106px">
																				<asp:label id="Label3" runat="server" CssClass="Lables" Width="104px" Height="14px"> Mun. N O C</asp:label></TD>
																			<TD style="WIDTH: 63px">
																				<asp:dropdownlist style="Z-INDEX: 0" id="drpnoc1" tabIndex="9" runat="server" Width="91px" CssClass=" "
																					AutoPostBack="True">
																					<asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
																					<asp:ListItem Value="1">Yes</asp:ListItem>
																					<asp:ListItem Value="2">No </asp:ListItem>
																				</asp:dropdownlist></TD>
																			<TD style="WIDTH: 91px">
																				<asp:dropdownlist style="Z-INDEX: 0" id="drpnoc2" tabIndex="10" runat="server" Width="100%" CssClass=" "
																					Visible="False">
																					<asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
																					<asp:ListItem Value="1">Submitted</asp:ListItem>
																					<asp:ListItem Value="2">Not Submitted</asp:ListItem>
																				</asp:dropdownlist></TD>
																		</TR>
															</TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD class="TableBorder" vAlign="middle" align="right">
													<asp:imagebutton accessKey="S" id="iBtnSave" tabIndex="11" runat="server" Width="92px" Height="20px"
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
			</TD></TR></TBODY></TABLE>
		</form>
		</TD></TR></TBODY></TABLE>
	</body>
</HTML>
