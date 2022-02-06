<%@ Page Language="vb" AutoEventWireup="false" Codebehind="TcRequetAprolls.aspx.vb" Inherits="CollegeBoard.TcRequetAprolls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>TcRequetAprolls</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK id="Link1" rel="stylesheet" type="text/css" href="../../../Images/Login/StyleSheet.css">
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
															<TD vAlign="top" width="11"><IMG src="../../../Images/Login/table-lcorw.gif" width="11" height="11"></TD>
															<TD class="SubHeading"><asp:label id="lblHeading" runat="server" Width="100%" CssClass="SubHeading1" Font-Bold="True"> TC Student Approval </asp:label></TD>
															<TD vAlign="top" width="11"><IMG src="../../../Images/Login/table-rcorw.gif" width="11" height="11"></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD class="TdBorder"><IMG src="../../../Images/Login/spacer.gif" width="1" height="1"></TD>
											</TR>
											<TR>
												<TD class="TableBorder" vAlign="top" align="center">
													<TABLE id="Table4" border="0" cellSpacing="0" cellPadding="0" width="240">
														<TR>
															<TD align="center">
																<TABLE id="Table5" border="0" cellSpacing="1" cellPadding="1" width="100%">
																	<TR>
																		<TD><asp:label id="Label4" runat="server" Height="19px" Width="100%" CssClass="Lables"> Exam&nbsp;Branch</asp:label></TD>
																		<TD><asp:dropdownlist id="drpBranch" runat="server" Width="170px" CssClass=" ">
																				<asp:ListItem Value="1" Selected="True">ExamBranch</asp:ListItem>
																			</asp:dropdownlist></TD>
																		<TD align="left"><asp:imagebutton accessKey="G" id="imgBtnGo" tabIndex="2" runat="server" Height="17px" Width="75px"
																				ImageUrl="../../../Images/NewImages/search.gif"></asp:imagebutton></TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD class="TableBorder" vAlign="middle" align="right"><asp:datagrid id="dgGridTcReqst" runat="server" Width="100%" CssClass="GridMain" CellSpacing="2"
														BorderWidth="0px" BorderStyle="None" CellPadding="0" AutoGenerateColumns="False" ShowFooter="True">
														<AlternatingItemStyle CssClass="GridAlternateItem"></AlternatingItemStyle>
														<ItemStyle CssClass="GridItem"></ItemStyle>
														<HeaderStyle CssClass="GridHeader"></HeaderStyle>
														<Columns>
															<asp:TemplateColumn HeaderText="Sl.No">
																<HeaderStyle HorizontalAlign="Center" Width="2%" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																<ItemTemplate>
																	<asp:Label id="Label2" runat="server" Text='<%# DataBinder.Eval(Container, "DataSetIndex") +1 %>'>
																	</asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn Visible="False" DataField="ADMSLNO" HeaderText="ADMSLNO">
																<HeaderStyle Wrap="False" HorizontalAlign="Center" Width="0%" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																<FooterStyle Wrap="False"></FooterStyle>
															</asp:BoundColumn>
															<asp:BoundColumn Visible="False" DataField="ADMNO" HeaderText="ADMNO">
																<HeaderStyle Wrap="False" HorizontalAlign="Center" Width="3%" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																<FooterStyle Wrap="False"></FooterStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="BOARDADMNO" HeaderText="Board Admno">
																<HeaderStyle Wrap="False" Width="2%"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																<FooterStyle Wrap="False"></FooterStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="CODE" HeaderText="Code">
																<HeaderStyle Wrap="False" Width="10%"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																<FooterStyle Wrap="False"></FooterStyle>
															</asp:BoundColumn>
															<asp:BoundColumn Visible="False" DataField="UNIQUENO" HeaderText="Uniqueno">
																<HeaderStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																<FooterStyle Wrap="False"></FooterStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="NAME" HeaderText="Name">
																<HeaderStyle Wrap="False" HorizontalAlign="Center" Width="5%" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																<FooterStyle Wrap="False"></FooterStyle>
															</asp:BoundColumn>
															<asp:BoundColumn Visible="False" DataField="BRANCHSLNO" HeaderText="BRANCHSLNO">
																<HeaderStyle Wrap="False"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																<FooterStyle Wrap="False"></FooterStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="BALANCE" HeaderText="Balance">
																<HeaderStyle Wrap="False" HorizontalAlign="Center" Width="3%" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																<FooterStyle Wrap="False"></FooterStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="TCREMARK" HeaderText="TC Remarks">
																<HeaderStyle Wrap="False" Width="10%"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																<FooterStyle Wrap="False"></FooterStyle>
															</asp:BoundColumn>
															<asp:BoundColumn Visible="False" DataField="TCREQAPPROVED" HeaderText="TCREQAPPROVED">
																<HeaderStyle Wrap="False" Width="3%"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																<FooterStyle Wrap="False"></FooterStyle>
															</asp:BoundColumn>
															<asp:TemplateColumn HeaderText="OriginalTC">
																<HeaderStyle Width="3%"></HeaderStyle>
																<ItemTemplate>
																	<asp:CheckBox id="ChkOriginal" runat="server" CssClass="lables" Width="100px"></asp:CheckBox>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="CHECK">
																<HeaderStyle Wrap="False" HorizontalAlign="Center" Width="3%" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle Wrap="False"></ItemStyle>
																<HeaderTemplate>
																	Approval
																</HeaderTemplate>
																<ItemTemplate>
																	<asp:CheckBox id="ChkTarget" runat="server" CssClass="LABLES" Width="100px" TextAlign="Left"></asp:CheckBox>
																</ItemTemplate>
																<FooterStyle Wrap="False"></FooterStyle>
															</asp:TemplateColumn>
														</Columns>
														<PagerStyle VerticalAlign="Middle" Font-Bold="True" HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
													</asp:datagrid></TD>
											</TR>
											<TR>
												<TD class="TableBorder" vAlign="middle" align="right"><asp:imagebutton accessKey="S" id="iBtnSave" tabIndex="5" runat="server" Height="20px" Width="92px"
														ImageUrl="../../../Images/NewImages/save.gif"></asp:imagebutton>&nbsp;&nbsp;&nbsp;</TD>
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
