<%@ Page Language="vb" AutoEventWireup="false" Codebehind="KeyObj_Comb_View.aspx.vb" Inherits="CollegeBoard.KeyObj_Comb_View" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>KeyObj_Comb_View</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK id="Link1" rel="stylesheet" type="text/css" href="../../Images/Login/StyleSheet_Report.css">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" autocomplete="off" runat="server">
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
															<TD class="SubHeading"><asp:label id="lblHeading" runat="server" Width="100%" CssClass="SubHeading1" Font-Bold="True"> Combinations for Key Objections </asp:label></TD>
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
													<TABLE id="Table4" cellSpacing="0" cellPadding="1" width="511" border="0" style="WIDTH: 511px; HEIGHT: 45px">
														<TR>
															<TD nowrap="nowrap">
																<asp:label id="Label2" runat="server" CssClass="Lables" Width="100%">User&nbsp;Types&nbsp;*</asp:label></TD>
															<TD nowrap="nowrap" style="HEIGHT: 18px">
																<asp:dropdownlist id="DrpUserTypes" runat="server" CssClass="DropDownList" Width="153px" AutoPostBack="True"></asp:dropdownlist></TD>
															<TD nowrap="nowrap" style="HEIGHT: 18px">
																<asp:label id="Label6" runat="server" CssClass="Lables" Width="120px">Academic Year</asp:label></TD>
															<TD nowrap="nowrap">
																<asp:dropdownlist id="drpAcaSlno" runat="server" CssClass="DropDownList" Width="153px"></asp:dropdownlist></TD>
														</TR>
														<TR>
															<TD nowrap="nowrap">
																<asp:label id="Label3" runat="server" CssClass="Lables" Width="100%">Users</asp:label></TD>
															<TD nowrap="nowrap">
																<asp:dropdownlist id="DrpUsers" runat="server" CssClass="DropDownList" Width="153px"></asp:dropdownlist></TD>
															<TD nowrap="nowrap">
																<asp:imagebutton id="iBtnSearch" accessKey="E" runat="server" Width="80px" ImageUrl="../../Images/NewImages/search.gif"
																	Height="20px"></asp:imagebutton></TD>
															<TD nowrap="nowrap"></TD>
														</TR>
														<TR>
															<TD colSpan="4"></TD>
														</TR>
														<TR>
															<TD colspan="4">
																<TABLE id="Table5" border="0" cellSpacing="0" cellPadding="0" width="100%">
																	<TR>
																		<TD vAlign="top" align="center">
																			<asp:datagrid id="dgVusers" runat="server" Width="520px" CssClass="GridMain" CellPadding="0" BorderWidth="0px"
																				CellSpacing="2" BorderStyle="None" OnItemCreated="DeleteConformationMessage" AllowPaging="True"
																				AllowSorting="True" AutoGenerateColumns="False">
																				<SelectedItemStyle Font-Bold="True" ForeColor="White"></SelectedItemStyle>
																				<AlternatingItemStyle CssClass="GridAlternateItem "></AlternatingItemStyle>
																				<ItemStyle CssClass="GridItem"></ItemStyle>
																				<HeaderStyle Font-Bold="True" CssClass="GridHeader"></HeaderStyle>
																				<FooterStyle ForeColor="#8C4510" BackColor="#F7DFB5"></FooterStyle>
																				<Columns>
																					<asp:TemplateColumn HeaderText="Sl.No">
																						<HeaderStyle Width="50px"></HeaderStyle>
																						<ItemStyle Width="50px"></ItemStyle>
																						<ItemTemplate>
																							<asp:Label id=Label5 runat="server" Text='<%# DataBinder.Eval(Container, "DataSetIndex")+1 %>'>
																							</asp:Label>
																						</ItemTemplate>
																					</asp:TemplateColumn>
																					<asp:BoundColumn Visible="False" DataField="USERSLNO" HeaderText="User Slno"></asp:BoundColumn>
																					<asp:BoundColumn Visible="False" DataField="COMACADEMICSLNO" HeaderText="COMACADEMICSLNO"></asp:BoundColumn>
																					<asp:BoundColumn Visible="False" DataField="COMBINATIONKEY" HeaderText="COMBINATIONKEY"></asp:BoundColumn>
																					<asp:BoundColumn DataField="EXAMNAME" SortExpression="EXAMNAME" HeaderText="Combination Key">
																						<HeaderStyle Wrap="False" Width="300px"></HeaderStyle>
																						<ItemStyle Wrap="False"></ItemStyle>
																						<FooterStyle Wrap="False"></FooterStyle>
																					</asp:BoundColumn>
																					<asp:ButtonColumn Text="Delete" ButtonType="PushButton" CommandName="Delete"></asp:ButtonColumn>
																				</Columns>
																				<PagerStyle VerticalAlign="Middle" HorizontalAlign="Center" PageButtonCount="100" CssClass="GridPager"
																					Mode="NumericPages"></PagerStyle>
																			</asp:datagrid></TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
														<TR>
															<TD colSpan="4"></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD align="right">
													<asp:imagebutton id="ibtnEdit" accessKey="S" runat="server" Width="80px" Height="20px" ImageUrl="../../Images/NewImages/edit.gif"
														AlternateText="Single"></asp:imagebutton>
													<asp:imagebutton id="ibtnBatch" accessKey="S" runat="server" Width="80px" Height="20px" ImageUrl="../../Images/NewImages/batchmode.gif"
														AlternateText="Single" style="Z-INDEX: 0"></asp:imagebutton></TD>
												<TD></TD>
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
