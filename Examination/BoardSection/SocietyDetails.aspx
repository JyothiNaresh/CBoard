<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SocietyDetails.aspx.vb" Inherits="CollegeBoard.SocietyDetails" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>SocietyDetails</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK id="Link1" rel="stylesheet" type="text/css" href="../../Images/Login/StyleSheet_Report.css">
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
															<TD class="SubHeading"><asp:label id="lblHeading" runat="server" Width="100%" CssClass="SubHeading1" Font-Bold="True"> List  of College  Wise Details  of Society </asp:label></TD>
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
													<TABLE id="Table10" border="0" cellSpacing="0" cellPadding="0" width="300">
														<TR>
															<TD>
																<asp:label style="Z-INDEX: 0" id="Label19" runat="server" Width="112px" Height="19px" CssClass="Lables">Registration No</asp:label></TD>
															<TD>
																<asp:textbox style="Z-INDEX: 0" id="Txtccode1" runat="server" Width="144px" CssClass=" " MaxLength="5"></asp:textbox></TD>
															<TD>
																<asp:imagebutton accessKey="G" style="Z-INDEX: 0" id="imgBtnGoo" tabIndex="1" runat="server" Width="40px"
																	Height="17px" ImageUrl="../../Images/NewImages/go.gif"></asp:imagebutton></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD class="TableBorder" vAlign="top" align="center"></TD>
											</TR>
											<TR>
												<TD class="TableBorder" vAlign="top" align="center"><asp:datagrid id="dgGridScoiety" tabIndex="1" runat="server" Width="872px" CssClass="GridMain"
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
															<asp:BoundColumn Visible="False" DataField="SOCIETYSLNO" HeaderText="SLNO">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="REGISTERED_NO" HeaderText="Registration No">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="REGISTERED_DATE" HeaderText="Registration Date">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="SOCT_NAME" HeaderText="Name">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="ADDRESS1" HeaderText="Address 1">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="ADDRESS2" HeaderText="Address 2">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle Wrap="False"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="CORRESPONDENTNAME" HeaderText="Correspondent Name">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="MOBILE" HeaderText="Mobile">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="YEAROFSTART" HeaderText="Year of Start">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="AFFILT_EXT_UPTO" HeaderText="Affilation Extention Upto">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
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
										<TABLE id="Table4" border="0" cellSpacing="0" cellPadding="0" width="893" runat="server">
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
																					<TD class="SubHeading"><asp:label id="Label10" runat="server" Height="8px" Width="100%" CssClass="SubHeading1" Font-Bold="True"> Society Entry Details </asp:label></TD>
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
																			<TABLE id="Table9" border="0" cellSpacing="0" cellPadding="0" Width="525">
																				<TR>
																					<TD colSpan="3">
																						<TABLE id="Table5" border="0" cellSpacing="0" cellPadding="0" width="100%">
																							<TR>
																								<TD colspan="3" style="HEIGHT: 11px">
																									<TABLE id="TBLROW1" border="0" cellSpacing="0" cellPadding="0" width="256">
																										<TR>
																											<TD><asp:label id="Label2" runat="server" Height="19px" Width="128px" CssClass="Lables"> Reg.Date</asp:label></TD>
																											<TD><asp:textbox id="Txtregdate" tabIndex="1" runat="server" Width="127px" CssClass=" " MaxLength="10"
																													ReadOnly="True"></asp:textbox></TD>
																											<TD><A   href="javascript:NewCal('<% =Txtregdate.ClientID %>','DDMMMYYYY')"><IMG border="0" align="absBottom" src="../../Images/calendar.gif" width="24" height="19"
																														useMap="../Images/ReportImages/calendar.gif"></A></TD>
																										</TR>
																									</TABLE>
																								</TD>
																							</TR>
																							<TR>
																								<TD><asp:label id="Label1" runat="server" Height="19px" Width="128px" CssClass="Lables" style="Z-INDEX: 0"> Reg.No</asp:label></TD>
																								<TD><asp:textbox id="txtregno" runat="server" Width="127px" CssClass=" " MaxLength="10" style="Z-INDEX: 0"></asp:textbox></TD>
																							</TR>
																							<TR>
																								<TD><asp:label id="Label8" runat="server" Height="19px" Width="128px" CssClass="Lables" style="Z-INDEX: 0"> Starting Year</asp:label></TD>
																								<TD><asp:textbox id="txtyos" tabIndex="2" runat="server" Width="128px" CssClass=" " MaxLength="10"
																										style="Z-INDEX: 0"></asp:textbox></TD>
																							</TR>
																							<TR>
																								<TD><asp:label id="Label3" runat="server" Height="19px" Width="128px" CssClass="Lables"> Name</asp:label></TD>
																								<TD><asp:textbox id="txtname" tabIndex="3" runat="server" Width="404px" CssClass=" " MaxLength="50"></asp:textbox></TD>
																							</TR>
																							<TR>
																								<TD><asp:label id="Label4" runat="server" Height="19px" Width="128px" CssClass="Lables"> Address 1</asp:label></TD>
																								<TD><asp:textbox id="txtaddr1" tabIndex="4" runat="server" Width="100%" CssClass=" " MaxLength="100"></asp:textbox></TD>
																							</TR>
																							<TR>
																								<TD style="WIDTH: 88px"><asp:label id="Label11" runat="server" Height="19px" Width="128px" CssClass="Lables"> Address 2</asp:label></TD>
																								<TD><asp:textbox id="txtaddr2" tabIndex="5" runat="server" Width="100%" CssClass=" " MaxLength="100"></asp:textbox></TD>
																							</TR>
																							<TR>
																								<TD style="WIDTH: 88px"><asp:label id="Label6" runat="server" Height="19px" Width="128px" CssClass="Lables">Correspondent Name</asp:label></TD>
																								<TD><asp:textbox id="txtcorpname" tabIndex="6" runat="server" Width="100%" CssClass=" " MaxLength="50"></asp:textbox></TD>
																							</TR>
																							<TR>
																								<TD style="WIDTH: 88px"><asp:label id="Label7" runat="server" Height="19px" Width="128px" CssClass="Lables"> Mobile</asp:label></TD>
																								<TD><asp:textbox id="txtmobile" tabIndex="7" runat="server" Width="104px" CssClass=" " MaxLength="10"></asp:textbox></TD>
																							</TR>
																							<TR>
																								<TD style="WIDTH: 88px"><asp:label id="Label9" runat="server" Height="19px" Width="128px" CssClass="Lables"> Renewal upto</asp:label></TD>
																								<TD><asp:textbox id="txtaffextupto" tabIndex="8" runat="server" Width="104px" CssClass=" " MaxLength="10"></asp:textbox></TD>
																							</TR>
																						</TABLE>
																					</TD>
																				</TR>
																			</TABLE>
																		</TD>
																	</TR>
																	<TR>
																		<TD class="TableBorder" vAlign="middle" align="right"><asp:imagebutton accessKey="S" id="iBtnSave" tabIndex="9" runat="server" Height="20px" Width="92px"
																				ImageUrl="../../Images/NewImages/save.gif"></asp:imagebutton>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
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
						</TD>
					</TR>
				</TBODY>
			</TABLE>
		</form>
		</TD></TR></TBODY></TABLE>
	</body>
</HTML>
