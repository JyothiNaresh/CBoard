<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="BoardKarnatakaHome.aspx.vb" Inherits="CollegeBoard.BoardKarnatakaHome" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">

<HTML>
	<HEAD>
		<title>Board Transfor Certificate Home</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK id="Link1" href="../../../Images/Login/StyleSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table7" style="Z-INDEX: 105; POSITION: absolute; TOP: 8px; LEFT: 8px" cellSpacing="0"
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
														<TD vAlign="top" align="center"><asp:label id="LblHeading" runat="server" Width="960px" CssClass="SubHeading1"> Board&nbsp;Colleges&nbsp;Details</asp:label></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD vAlign="top" align="center">
												<TABLE id="Table4" style="WIDTH: 735px; HEIGHT: 120px" cellSpacing="0" cellPadding="0"
													width="735" border="1">
													<TR>
														<TD style="HEIGHT: 4px" width="10%"><asp:label id="Label3" runat="server" Width="100%" CssClass="Lables">ExamBranch</asp:label></TD>
														<TD style="HEIGHT: 4px" width="15%"><asp:dropdownlist id="DrpExamBranch" runat="server" Width="200px" CssClass=" " AutoPostBack="True"></asp:dropdownlist></TD>
														<TD style="HEIGHT: 4px" width="15%"><asp:label id="lblCourse" runat="server" Width="100%" CssClass="Lables">Board&nbsp;College</asp:label></TD>
														<TD style="HEIGHT: 4px" width="50%"><asp:dropdownlist id="DrpBoardCollege" runat="server" Width="100%" CssClass=" " AutoPostBack="True"></asp:dropdownlist></TD>
													</TR>
													<TR>
														<TD vAlign="middle" align="right" colSpan="5"><asp:imagebutton id="iBtnGo" accessKey="G" runat="server" Width="80px" Height="20px" ImageUrl="../../../Images/NewImages/search.gif"
																Visible="False"></asp:imagebutton></TD>
													</TR>
													<TR>
														<TD vAlign="middle" align="center" colSpan="5">
															<TABLE id="Table6" style="WIDTH: 545px; HEIGHT: 30px" cellSpacing="1" cellPadding="1" width="545"
																border="1">
																<TR>
																	<TD><asp:radiobutton id="Rbtntc" runat="server" Width="280px" CssClass="Lables" AutoPostBack="True" Height="1px"
																			TextAlign="Left" GroupName="Opt" Text="LEAVING CERTIFICATE"></asp:radiobutton></TD>
																	<TD><asp:radiobutton id="Rbtncc" runat="server" Width="272px" CssClass="lables" AutoPostBack="True" Height="15px"
																			TextAlign="Left" GroupName="Opt" Text="CONDUCT CERTIFICATE" Checked="True"></asp:radiobutton></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD vAlign="top" align="center" colSpan="5">
															<TABLE id="Table8" style="VISIBILITY: hidden" cellSpacing="0" cellPadding="0" width="100%"
																border="0">
																<TR>
																	<TD align="center" width="10%"><asp:label id="Label1" runat="server" Width="100%" CssClass="Lables">Select</asp:label></TD>
																	<TD align="center" width="15%"><asp:dropdownlist id="drpSelect" runat="server" Width="100%" CssClass=" ">
																			<asp:ListItem Value="1">ADMNO</asp:ListItem>
																			<asp:ListItem Value="2">Name</asp:ListItem>
																		</asp:dropdownlist></TD>
																	<TD align="center" width="65%"><asp:textbox id="TxtSelect" runat="server" Width="100%"></asp:textbox></TD>
																	<TD vAlign="middle" align="left" width="50%"><asp:imagebutton id="IbtnSearch" accessKey="G" runat="server" Width="80px" Height="20px" ImageUrl="../../../Images/NewImages/search.gif"></asp:imagebutton></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD vAlign="top" align="center">
												<TABLE id="Table5" cellSpacing="1" cellPadding="1" width="100%" border="0">
													<TR>
														<TD vAlign="top" align="center"><asp:datagrid id="dgGrid" tabIndex="13" runat="server" Width="100%" CssClass="GridMain" PageSize="20"
																AutoGenerateColumns="False" BorderWidth="0px" CellPadding="0" AllowSorting="True" BorderStyle="None" CellSpacing="2">
																<FooterStyle BackColor="#D1CBCB"></FooterStyle>
																<AlternatingItemStyle CssClass="GridAlternateItem"></AlternatingItemStyle>
																<ItemStyle CssClass="GridItem"></ItemStyle>
																<HeaderStyle Font-Bold="True" CssClass="GridHeader"></HeaderStyle>
																<Columns>
																	<asp:BoundColumn Visible="False" DataField="uniqueno"></asp:BoundColumn>
																	<asp:BoundColumn Visible="False" DataField="ADMSLNO"></asp:BoundColumn>
																	<asp:BoundColumn Visible="False" DataField="BOARDCOLLEGESLNO"></asp:BoundColumn>
																	<asp:TemplateColumn HeaderText="Sl.No">
																		<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Center"></ItemStyle>
																		<ItemTemplate>
																			<asp:Label id=Label5 runat="server" Text='<%# DataBinder.Eval(Container, "DataSetIndex")+1 %>'>
																			</asp:Label>
																		</ItemTemplate>
																	</asp:TemplateColumn>
																	<asp:BoundColumn Visible="False" DataField="EXAMBRANCH" HeaderText="EXAMBRANCH / CODE"></asp:BoundColumn>
																	<asp:BoundColumn Visible="False" DataField="BOARDCOLLEGE" HeaderText="COLLEGE CODE"></asp:BoundColumn>
																	<asp:BoundColumn DataField="ADMNO" HeaderText="ADMNO" Visible="False">
																		<HeaderStyle Wrap="False" HorizontalAlign="Center"></HeaderStyle>
																		<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
																		<FooterStyle Wrap="False"></FooterStyle>
																	</asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="GRNO" HeaderText="GRNO">
																		<HeaderStyle Wrap="False" HorizontalAlign="Center"></HeaderStyle>
																		<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
																		<FooterStyle Wrap="False"></FooterStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn Visible="False" DataField="BADMNO" HeaderText="BOARD ADMNO"></asp:BoundColumn>
																	<asp:BoundColumn DataField="STUDENTNAME" HeaderText="NAME">
																		<ItemStyle Wrap="False"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="CODE" HeaderText="CODE">
																		<ItemStyle Wrap="False"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="PAIDPER" HeaderText="PAIDPER">
																		<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="STATUS" HeaderText="STATUS">
																		<ItemStyle Wrap="False"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:ButtonColumn Text="Generate" ButtonType="PushButton" CommandName="Delete">
																		<HeaderStyle HorizontalAlign="Center" Width="15px"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Center"></ItemStyle>
																	</asp:ButtonColumn>
																	<asp:BoundColumn Visible="False" DataField="SPONSORSLNO" HeaderText="SPONSORSLNO"></asp:BoundColumn>
																	<asp:BoundColumn Visible="False" DataField="TCNO" HeaderText="TCNO"></asp:BoundColumn>
																	<asp:BoundColumn Visible="False" DataField="TCREQAPPROVED" HeaderText="TCREQAPPROVED"></asp:BoundColumn>
																	<asp:BoundColumn Visible="False" DataField="TSTATESLNO" HeaderText="TSTATESLNO"></asp:BoundColumn>
																</Columns>
																<PagerStyle HorizontalAlign="Center" CssClass="GridPager" Mode="NumericPages"></PagerStyle>
															</asp:datagrid></TD>
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
