<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Society_Clg_Mapping.aspx.vb" Inherits="CollegeBoard.Society_Clg_Mapping" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Society_Clg_Mapping</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK id="Link1" rel="stylesheet" type="text/css" href="../../Images/Login/StyleSheet.css">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server" autocomplete="off">
			<asp:textbox style="Z-INDEX: 101; POSITION: absolute; TOP: 8px; LEFT: 8px" id="txtSetfocus" runat="server"
				Width="0px" Height="32px"></asp:textbox><asp:textbox style="Z-INDEX: 102; POSITION: absolute; TOP: 8px; LEFT: 8px" id="txtMessage" runat="server"
				Width="0px" Height="32px"></asp:textbox><asp:textbox id="txtlblCode" runat="server" Width="0px" Height="32px">XXXXXX</asp:textbox>
			<TABLE id="Table0" border="0" cellSpacing="1" cellPadding="1" width="100%">
				<TBODY>
					<TR>
						<TD vAlign="top" align="center">
							<TABLE style="WIDTH: 397px; HEIGHT: 288px" id="Table1" class="Panel" border="0" cellSpacing="0"
								cellPadding="0">
								<TR>
									<TD align="center">
										<TABLE style="WIDTH: 360px; HEIGHT: 248px" id="Table2" border="0" cellSpacing="0" cellPadding="0">
											<TR>
												<TD class="DarkColor">
													<TABLE id="Table3" border="0" cellSpacing="0" cellPadding="0" width="100%">
														<TR>
															<TD vAlign="top" width="11"><IMG src="../../Images/Login/table-lcorw.gif" width="11" height="11"></TD>
															<TD class="SubHeading"><asp:label id="lblHeading" runat="server" Width="100%" Font-Bold="True" CssClass="SubHeading1"> Society Wise College Mapping </asp:label></TD>
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
													<TABLE id="Table4" border="0" cellSpacing="0" cellPadding="0" width="240">
														<TR>
															<TD align="center">
																<TABLE style="WIDTH: 328px; HEIGHT: 45px" id="Table5" border="0" cellSpacing="1" cellPadding="1"
																	width="328">
																	<tr>
																		<td><asp:label id="Label3" runat="server" Width="86px" Height="19px" CssClass="Lables"> Society Name</asp:label></td>
																		<td><asp:textbox id="txtccname" tabIndex="1" runat="server" Width="170px" CssClass=" " MaxLength="10"></asp:textbox></td>
																	</tr>
																	<TR>
																		<TD><asp:label id="Label4" runat="server" Width="100%" Height="19px" CssClass="Lables"> Select District</asp:label></TD>
																		<TD><asp:dropdownlist id="DrpDistrict" runat="server" Width="170px" CssClass=" ">
																				<asp:ListItem Value="1" Selected="True">District</asp:ListItem>
																			</asp:dropdownlist></TD>
																		<TD align="left"><asp:imagebutton accessKey="G" id="imgBtnGo" tabIndex="2" runat="server" Width="75px" Height="17px"
																				ImageUrl="../../Images/NewImages/search.gif"></asp:imagebutton></TD>
																	</TR>
																</TABLE>
																<TABLE style="WIDTH: 105px; HEIGHT: 16px" id="Table7" border="0" cellSpacing="0" cellPadding="0"
																	width="105" align="center">
																	<TR>
																		<TD style="WIDTH: 98px; HEIGHT: 19px" align="right"><asp:label id="Label1" runat="server" Width="92px" Height="19px" CssClass="Lables"> Society Name</asp:label></TD>
																		<TD style="HEIGHT: 19px"><asp:dropdownlist id="drpSociety" runat="server" Width="252px" Height="16px" CssClass=" "></asp:dropdownlist></TD>
																	</TR>
																</TABLE>
																<TABLE style="WIDTH: 264px; HEIGHT: 112px" id="Table6" border="0" cellSpacing="1" cellPadding="1"
																	width="264">
																	<TR>
																		<TD align="center"><asp:datagrid id="dgGridCollege" runat="server" Width="568px" Height="168px" CssClass="GridMain"
																				ShowFooter="True" AutoGenerateColumns="False" CellPadding="0" BorderStyle="None" BorderWidth="0px" CellSpacing="2">
																				<AlternatingItemStyle CssClass="GridAlternateItem"></AlternatingItemStyle>
																				<ItemStyle CssClass="GridItem"></ItemStyle>
																				<HeaderStyle CssClass="GridHeader"></HeaderStyle>
																				<Columns>
																					<asp:TemplateColumn HeaderText="Sl.No">
																						<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																						<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																						<ItemTemplate>
																							<asp:Label id="Label2" runat="server" Text='<%# DataBinder.Eval(Container, "DataSetIndex") +1 %>'>
																							</asp:Label>
																						</ItemTemplate>
																					</asp:TemplateColumn>
																					<asp:BoundColumn DataField="CODE" HeaderText="College Code">
																						<HeaderStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																						<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																						<FooterStyle Wrap="False"></FooterStyle>
																					</asp:BoundColumn>
																					<asp:BoundColumn DataField="NAME" HeaderText="College Name">
																						<HeaderStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																						<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																						<FooterStyle Wrap="False"></FooterStyle>
																					</asp:BoundColumn>
																					<asp:BoundColumn DataField="SOCT_NAME" HeaderText="Society Name">
																						<HeaderStyle Wrap="False"></HeaderStyle>
																						<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																						<FooterStyle Wrap="False"></FooterStyle>
																					</asp:BoundColumn>
																					<asp:TemplateColumn HeaderText="CHECK">
																						<HeaderStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																						<ItemStyle Wrap="False"></ItemStyle>
																						<HeaderTemplate>
																							Check Society
																						</HeaderTemplate>
																						<ItemTemplate>
																							<asp:CheckBox id="ChkTarget" runat="server" Width="100%" TextAlign="Left"></asp:CheckBox>
																						</ItemTemplate>
																						<FooterStyle Wrap="False"></FooterStyle>
																					</asp:TemplateColumn>
																					<asp:BoundColumn Visible="False" DataField="SOCIETY_REGISTER_NO"></asp:BoundColumn>
																				</Columns>
																				<PagerStyle VerticalAlign="Middle" Font-Bold="True" HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
																			</asp:datagrid></TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD class="TableBorder" vAlign="middle" align="right"><asp:imagebutton accessKey="S" id="iBtnDelete" tabIndex="5" runat="server" Width="92px" Height="20px"
														ImageUrl="../../Images/NewImages/delete.gif"></asp:imagebutton><asp:imagebutton accessKey="S" id="iBtnSave" tabIndex="5" runat="server" Width="92px" Height="20px"
														ImageUrl="../../Images/NewImages/save.gif"></asp:imagebutton>&nbsp;&nbsp;&nbsp;</TD>
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
