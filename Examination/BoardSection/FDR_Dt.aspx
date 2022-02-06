<%@ Page Language="vb" AutoEventWireup="false" Codebehind="FDR_Dt.aspx.vb" Inherits="CollegeBoard.FDR_DT" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>FDR_DT</title>
		<meta name="vs_showGrid" content="False">
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
		<style type="text/css">.watermark { COLOR: gray }
		</style>
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
															<TD class="SubHeading"><asp:label id="lblHeading" runat="server" Width="100%" Font-Bold="True" CssClass="SubHeading1"> List  of College Wise  Details  of  FDR Details  </asp:label></TD>
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
															<asp:BoundColumn Visible="False" DataField="FDRSLNO" HeaderText="SLNO">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="CCODE" HeaderText="College Code">
																<HeaderStyle Wrap="False" HorizontalAlign="Left" Width="10%" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																<FooterStyle HorizontalAlign="Left"></FooterStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="COLLEGENAME" HeaderText="College Name">
																<HeaderStyle Wrap="False" Width="10%" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle Wrap="False" VerticalAlign="Middle"></ItemStyle>
																<FooterStyle HorizontalAlign="Left"></FooterStyle>
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
										<p></p>
									</TD>
								</TR>
							</TABLE>
							<TABLE id="Table4" border="0" cellSpacing="0" cellPadding="0" width="384" runat="server">
								<TR>
									<TD align="center">
										<TABLE id="Table6" class="Panel" border="0" cellSpacing="0" cellPadding="0">
											<TR>
												<TD align="center" style="WIDTH: 365px">
													<TABLE id="Table7" border="0" cellSpacing="0" cellPadding="0">
														<TR>
															<TD style="WIDTH: 376px" class="DarkColor">
																<TABLE id="Table8" border="0" cellSpacing="0" cellPadding="0" width="100%">
																	<TR>
																		<TD vAlign="top" width="11"><IMG src="../../Images/Login/table-lcorw.gif" width="11" height="11"></TD>
																		<TD class="SubHeading"><asp:label id="Label10" runat="server" Height="8px" Width="296px" CssClass="SubHeading1" Font-Bold="True"> FDR Entry Details </asp:label></TD>
																		<TD vAlign="top" width="11"><IMG src="../../Images/Login/table-rcorw.gif" width="11" height="11"></TD>
																	</TR>
																</TABLE>
																&nbsp;&nbsp;&nbsp;
															</TD>
														</TR>
														<TR>
															<TD class="TdBorder" style="WIDTH: 375px"><IMG src="../../Images/Login/spacer.gif" width="1" height="1"></TD>
														</TR>
														<TR>
															<TD class="TableBorder" vAlign="top" align="left" style="WIDTH: 376px; HEIGHT: 206px">
																<TABLE id="Table5" border="0" cellSpacing="0" cellPadding="0" width="376" style="WIDTH: 376px; HEIGHT: 218px">
																	<TR>
																		<TD></TD>
																		<TD style="WIDTH: 208px">
																			<TABLE style="Z-INDEX: 0" id="Table13" border="1" cellSpacing="1" cellPadding="1" width="300">
																				<TR>
																					<TD>
																						<asp:label style="Z-INDEX: 0" id="Label2" runat="server" Height="19px" Width="112px" CssClass="Lables">College Code</asp:label></TD>
																					<TD>
																						<asp:textbox style="Z-INDEX: 0" id="Txtccode" runat="server" Width="144px" CssClass=" " MaxLength="5"></asp:textbox></TD>
																					<TD>
																						<asp:imagebutton accessKey="S" style="Z-INDEX: 0" id="imgBtnGo" tabIndex="1" runat="server" Height="17px"
																							Width="75px" ImageUrl="../../Images/NewImages/search.gif"></asp:imagebutton></TD>
																				</TR>
																			</TABLE>
																			<asp:label id="LBLCLGNAME" runat="server" Height="16px" Width="352px" CssClass="Lables" BackColor="Info"
																				style="Z-INDEX: 0">College Name</asp:label>
																			<TABLE style="Z-INDEX: 0; WIDTH: 304px; HEIGHT: 243px" id="Table9" border="0" cellSpacing="0"
																				width="304">
																				<TR>
																					<TD style="WIDTH: 114px">
																						<asp:label style="Z-INDEX: 0" id="Label1" runat="server" Height="15px" Width="120px" CssClass="Lables"> FDR No</asp:label></TD>
																					<TD>
																						<asp:textbox style="Z-INDEX: 0" id="txtfdrno" tabIndex="2" runat="server" Width="180px" CssClass=" "
																							MaxLength="16"></asp:textbox></TD>
                                                                                    <TD></TD>
                                                                                   
																				</TR>
																				<TR>
																					<TD style="WIDTH: 114px">
																						<asp:label style="Z-INDEX: 0" id="Label9" runat="server" Height="14px" Width="120px" CssClass="Lables"> FDR A/C.No</asp:label></TD>
																					<TD>
																						<asp:textbox style="Z-INDEX: 0" id="txtfdracno" tabIndex="3" runat="server" Width="180px" CssClass=" "
																							MaxLength="16"></asp:textbox></TD>
                                                                                    <TD></TD>
                                                                                    
																				</TR>
																				<TR>
																					<TD style="WIDTH: 114px">
																						<asp:label style="Z-INDEX: 0" id="Label3" runat="server" Height="14px" Width="120px" CssClass="Lables">Deposit Date</asp:label></TD>
																					<TD>
																						<asp:textbox style="Z-INDEX: 0" id="txtfdrdate" tabIndex="4" runat="server" Width="180px" CssClass=" "
																							MaxLength="16" ToolTip="DD/MM/YYYY"></asp:textbox></TD>                                                                                    
																					<TD>
																						<asp:RegularExpressionValidator style="Z-INDEX: 0" id="RegularExpressionValidator1" runat="server" Width="55px"
																							Font-Bold="True" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((1[6-9]|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((1[6-9]|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((1[6-9]|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"
																							ErrorMessage="X Error" ControlToValidate="txtfdrdate" Font-Size="X-Small"></asp:RegularExpressionValidator></TD>
																				
                                                                                </TR>
																				<TR>
																					<TD style="WIDTH: 114px">
																						<asp:label style="Z-INDEX: 0" id="Label11" runat="server" Height="14px" Width="120px" CssClass="Lables"> Deposit Amount</asp:label></TD>
																					<TD>
																						<asp:textbox style="Z-INDEX: 0" id="txtamt" tabIndex="5" runat="server" Width="180px" CssClass=" "
																							MaxLength="16"></asp:textbox></TD>
																					<TD></TD>
                                                                                    
																				</TR>
																				<TR>
																					<TD style="WIDTH: 114px; HEIGHT: 26px">
																						<asp:label style="Z-INDEX: 0" id="Label4" runat="server" Height="19px" Width="120px" CssClass="Lables"> FDR Maturity Date</asp:label></TD>
																					<TD style="HEIGHT: 26px">
																						<asp:textbox style="Z-INDEX: 0" id="txtfdrmdate" tabIndex="6" runat="server" Width="180px" CssClass=" "
																							MaxLength="16" ToolTip="DD/MM/YYYY"></asp:textbox></TD>
																					<TD style="HEIGHT: 26px">
																						<asp:RegularExpressionValidator style="Z-INDEX: 0" id="RegularExpressionValidator2" runat="server" Width="53px"
																							Font-Bold="True" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((1[6-9]|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((1[6-9]|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((1[6-9]|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"
																							ErrorMessage="X Error" ControlToValidate="txtfdrmdate" Font-Size="X-Small"></asp:RegularExpressionValidator></TD>
                                                                                    
																				</TR>
																				<TR>
																					<TD style="WIDTH: 114px">
																						<asp:label style="Z-INDEX: 0" id="Label12" runat="server" Height="14px" Width="120px" CssClass="Lables"> Maturity Amount</asp:label></TD>
																					<TD>
																						<asp:textbox style="Z-INDEX: 0" id="txtMaturityamt" tabIndex="7" runat="server" Width="180px"
																							CssClass=" " MaxLength="16"></asp:textbox></TD>
																					<TD>&nbsp;&nbsp;&nbsp;&nbsp;
																					</TD>
                                                                                   
																				</TR>
																				<TR>
																					<TD style="WIDTH: 114px">
																						<asp:label style="Z-INDEX: 0" id="Label7" runat="server" Height="14px" Width="120px" CssClass="Lables"> Bank & Branch</asp:label></TD>
																					<TD>
																						<asp:textbox style="Z-INDEX: 0" id="txtbkname" tabIndex="8" runat="server" Width="180px" CssClass=" "
																							MaxLength="50"></asp:textbox></TD>
																					<TD></TD>
                                                                                    
																				</TR>
																				<TR>
																					<TD style="WIDTH: 114px">
																						<asp:label style="Z-INDEX: 0" id="Label13" runat="server" Height="14px" Width="120px" CssClass="Lables"> Rate of Interest in%</asp:label></TD>
																					<TD>
																						<asp:textbox style="Z-INDEX: 0" id="txtInterest" tabIndex="9" runat="server" Width="180px" CssClass=" "
																							MaxLength="16"></asp:textbox></TD>
																					<TD></TD>
                                                                                    
																				</TR>
																				<TR>
																					<TD style="WIDTH: 114px">
																						<asp:label style="Z-INDEX: 0" id="Label6" runat="server" Height="14px" Width="120px" CssClass="Lables"> Release or Not </asp:label></TD>
																					<TD>
																						<asp:dropdownlist style="Z-INDEX: 0" id="Drprels" tabIndex="10" runat="server" Width="180px" CssClass=" "
																							AutoPostBack="True">
																							<asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
																							<asp:ListItem Value="1">Yes</asp:ListItem>
																							<asp:ListItem Value="2">No</asp:ListItem>
																						</asp:dropdownlist></TD>
																					<TD></TD>
                                                                                    
																				</TR>
																				<TR>
																					<TD style="WIDTH: 114px">
																						<asp:label style="Z-INDEX: 0" id="Label8" runat="server" Height="14px" Width="120px" CssClass="Lables"> Date of Release</asp:label></TD>
																					<TD>
																						<asp:textbox style="Z-INDEX: 0" id="txtreldate" tabIndex="11" runat="server" Width="180px" CssClass=" "
																							MaxLength="16" ToolTip="DD/MM/YYYY"></asp:textbox></TD>
																					<TD>
																						<asp:RegularExpressionValidator style="Z-INDEX: 0" id="RegularExpressionValidator15" runat="server" Width="54px"
																							Font-Bold="True" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((1[6-9]|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((1[6-9]|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((1[6-9]|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"
																							ErrorMessage="X Error" ControlToValidate="txtreldate" Font-Size="X-Small"></asp:RegularExpressionValidator></TD>
                                                                                   
																				</TR>
																			</TABLE>
																		</TD>
																		<TD></TD>
																	</TR>
																	<TR>
																		<TD colSpan="3" align="left">
																		</TD>
																	</TR>
																	<TR>
																		<TD colSpan="3" align="left">
																		</TD>
																	</TR>
																</TABLE>
																<TABLE id="Table20" border="0" cellSpacing="0" cellPadding="0" width="100%">
																	<TBODY>
																		<TR>
																			<TD colSpan="2">
																				<TABLE id="tblbuld" border="0" cellSpacing="0" cellPadding="0" width="224" runat="server">
																				</TABLE>
																			</TD>
																		</TR>
															</TD>
														</TR>
													</TABLE>
													<TABLE id="Table10" border="0" cellSpacing="0" cellPadding="0" runat="server" width="176">
														<TR>
															<TD style="WIDTH: 106px"></TD>
															<TD></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD class="TableBorder" vAlign="middle" align="right" style="WIDTH: 375px"><asp:imagebutton accessKey="S" id="iBtnSave" tabIndex="12" runat="server" Height="20px" Width="92px"
														ImageUrl="../../Images/NewImages/save.gif"></asp:imagebutton></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD align="center" style="WIDTH: 365px"></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
			<TABLE id="Table11" border="1" cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
			</TABLE>
			</TD></TR></TBODY></TABLE></form>
		</TD></TR></TBODY></TABLE>
	</body>
</HTML>
