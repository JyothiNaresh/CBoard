<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SchStuCertificate.aspx.vb" Inherits="CollegeBoard.SchStuCertificate" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>SchStuCertificate</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK id="Link1" href="../../../Images/Login/StyleSheet.css" type="text/css" rel="stylesheet">
		<LINK id="Link1" href="../../../Images/Login/StyleSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table7" style="Z-INDEX: 105; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="0"
				cellPadding="1" width="100%" border="0">
				<TR>
					<TD>
						<TABLE id="Table1" style="WIDTH: 980px" cellSpacing="0" cellPadding="1" width="980" align="center"
							border="1">
							<TR>
								<TD vAlign="top" align="center">
									<TABLE id="Table2" style="WIDTH: 972px" cellSpacing="1" cellPadding="1" width="972" align="center"
										border="0" DESIGNTIMEDRAGDROP="13">
										<TR>
											<TD vAlign="top" align="center">
												<TABLE id="Table3" style="WIDTH: 966px" cellSpacing="1" cellPadding="1" width="966" border="0">
													<TR>
														<TD vAlign="top" align="center"><asp:label id="LblHeading" runat="server" CssClass="SubHeading1" Width="960px">School&nbsp;Study&nbsp;Certificate</asp:label></TD>
													</TR>
												</TABLE>
												<TABLE id="Table4" style="WIDTH: 100%; HEIGHT: 268px" cellSpacing="0" cellPadding="0" border="1">
													<TR>
														<TD vAlign="middle" align="center" colSpan="5">
															<TABLE id="Table6" cellSpacing="1" cellPadding="1" width="100%" border="1">
																<TR>
																	<TD style="HEIGHT: 40px">
																		<TABLE id="Table8" cellSpacing="1" cellPadding="1" width="100%" border="1">
																			<TR>
																				<TD style="WIDTH: 124px">
																					<asp:label id="Label3" runat="server" Width="100%" CssClass="Lables">ExamBranch</asp:label></TD>
																				<TD style="WIDTH: 243px">
																					<asp:dropdownlist id="DrpExamBranch" runat="server" Width="100%" CssClass=" " AutoPostBack="True"></asp:dropdownlist></TD>
																				<TD style="WIDTH: 144px">
																					<asp:label id="Label2" runat="server" Width="100%" CssClass="Lables">PeresentCourse</asp:label></TD>
																				<TD>
																					<asp:dropdownlist id="DrpCourse" runat="server" Width="100%" CssClass=" " AutoPostBack="True"></asp:dropdownlist></TD>
																			</TR>
																		</TABLE>
																	</TD>
																</TR>
															</TABLE>
															<asp:datagrid id="dgGrid" tabIndex="13" runat="server" Width="100%" CssClass="GridMain" CellSpacing="2"
																BorderStyle="None" AllowSorting="True" CellPadding="0" BorderWidth="0px" AutoGenerateColumns="False"
																PageSize="20" Height="116px">
																<FooterStyle BackColor="#D1CBCB"></FooterStyle>
																<AlternatingItemStyle CssClass="GridAlternateItem"></AlternatingItemStyle>
																<ItemStyle CssClass="GridItem"></ItemStyle>
																<HeaderStyle Font-Bold="True" CssClass="GridHeader"></HeaderStyle>
																<Columns>
																	<asp:BoundColumn Visible="False" DataField="uniqueno"></asp:BoundColumn>
																	<asp:BoundColumn Visible="False" DataField="ADMSLNO"></asp:BoundColumn>
																	<asp:TemplateColumn HeaderText="Sl.No">
																		<HeaderStyle HorizontalAlign="Center" Width="5px"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Center"></ItemStyle>
																		<ItemTemplate>
																			<asp:Label id=Label5 runat="server" Text='<%# DataBinder.Eval(Container, "DataSetIndex")+1 %>'>
																			</asp:Label>
																		</ItemTemplate>
																	</asp:TemplateColumn>
																	<asp:BoundColumn DataField="ADMNO" HeaderText="ADMNO">
																		<HeaderStyle Wrap="False" HorizontalAlign="Center" Width="8px"></HeaderStyle>
																		<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
																		<FooterStyle Wrap="False"></FooterStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="NAME" HeaderText="NAME">
																		<HeaderStyle Width="42px"></HeaderStyle>
																		<ItemStyle Wrap="False"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="EXAMBRANCH" HeaderText="EXAMBRANCH">
																		<HeaderStyle Width="20px"></HeaderStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="CODE" HeaderText="CODE">
																		<HeaderStyle Width="30px"></HeaderStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="PAIDPER" HeaderText="PAIDPER">
																		<HeaderStyle Width="5px"></HeaderStyle>
																		<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="STATUS" HeaderText="STATUS">
																		<HeaderStyle Width="2px"></HeaderStyle>
																		<ItemStyle Wrap="False"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:ButtonColumn Text="Generate" ButtonType="PushButton" CommandName="Delete">
																		<HeaderStyle HorizontalAlign="Center" Width="15px"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Center"></ItemStyle>
																	</asp:ButtonColumn>
																	<asp:BoundColumn Visible="False" DataField="FNAME" HeaderText="FATHERNAME">
																		<HeaderStyle Width="20px"></HeaderStyle>
																	</asp:BoundColumn>
																</Columns>
																<PagerStyle HorizontalAlign="Center" CssClass="GridPager" Mode="NumericPages"></PagerStyle>
															</asp:datagrid></TD>
													</TR>
													<TR>
														<TD vAlign="top" colSpan="5"></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD vAlign="top" align="center">
											</TD>
										</TR>
										<TR>
											<TD vAlign="top" align="center">
												<TABLE id="Table5" cellSpacing="1" cellPadding="1" width="100%" border="0">
													<TR>
														<TD vAlign="top" align="center"></TD>
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
			<br>
		</form>
	</body>
</HTML>
