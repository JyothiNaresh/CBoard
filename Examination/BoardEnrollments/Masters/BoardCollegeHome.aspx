<%@ Page Language="vb" AutoEventWireup="false" Codebehind="BoardCollegeHome.aspx.vb" Inherits="CollegeBoard.BoardCollegeHome" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Board College Details</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="JavaScript" type="text/javascript" src="../../Include/StudentSection.js"></script>
		<LINK id="Link1" href="../../../Images/Login/StyleSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body onload="return StudentSectionDetailsLoad();" MS_POSITIONING="GridLayout">
		<form id="StudentSectionDetails" method="post" runat="server">
			<asp:textbox id="txtDeleteStatus" style="Z-INDEX: 103; POSITION: absolute; TOP: 8px; LEFT: 8px"
				runat="server" Height="32px" Width="0px"></asp:textbox>
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
												<TABLE id="Table4" style="WIDTH: 609px; HEIGHT: 80px" cellSpacing="0" cellPadding="0" width="609"
													border="1">
													<TR>
														<TD style="HEIGHT: 25px"><asp:label id="Label3" runat="server" Width="100%" CssClass="Lables">College&nbsp;District</asp:label></TD>
														<TD style="WIDTH: 173px; HEIGHT: 25px"><asp:dropdownlist id="drpDistrict" runat="server" Width="200px" CssClass=" " AutoPostBack="True">
																<asp:ListItem Value="0">ALL</asp:ListItem>
															</asp:dropdownlist></TD>
														<TD style="HEIGHT: 25px"><asp:label id="lblCourse" runat="server" Width="100%" CssClass="Lables">Narayana&nbsp;&nbsp;College</asp:label></TD>
														<TD style="WIDTH: 194px; HEIGHT: 25px"><asp:dropdownlist id="drpNarayana" runat="server" Width="200px" CssClass=" " AutoPostBack="True">
																<asp:ListItem Value="0">ALL</asp:ListItem>
																<asp:ListItem Value="1">Yes</asp:ListItem>
																<asp:ListItem Value="2">No</asp:ListItem>
															</asp:dropdownlist></TD>
													</TR>
													<TR>
														<TD style="HEIGHT: 6px"><asp:label id="lblGroup" runat="server" Width="100%" CssClass="Lables">Category</asp:label></TD>
														<TD style="WIDTH: 173px; HEIGHT: 6px"><asp:dropdownlist id="drpColltype" runat="server" Width="200px" CssClass=" " AutoPostBack="True">
																<asp:ListItem Value="0">ALL</asp:ListItem>
															</asp:dropdownlist></TD>
														<TD style="HEIGHT: 6px"><asp:label id="lblBatch" runat="server" Width="100%" CssClass="Lables">Corporate&nbsp;College</asp:label></TD>
														<TD style="WIDTH: 194px; HEIGHT: 6px"><asp:dropdownlist id="drpCorpColl" runat="server" Width="200px" CssClass=" " AutoPostBack="True">
																<asp:ListItem Value="0">ALL</asp:ListItem>
															</asp:dropdownlist></TD>
													</TR>
													<TR>
														<TD style="HEIGHT: 24px" vAlign="middle" align="right" colSpan="5"><asp:imagebutton id="iBtnGo" accessKey="G" runat="server" Height="20px" Width="80px" ImageUrl="../../../Images/NewImages/search.gif"></asp:imagebutton></TD>
													</TR>
													<TR>
														<TD style="WIDTH: 566px" vAlign="top" align="center" colSpan="5">
															<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="608" border="0">
																<TR>
																	<TD style="WIDTH: 50px" align="center"><asp:label id="Label1" runat="server" Width="100%" CssClass="Lables">Select</asp:label></TD>
																	<TD style="WIDTH: 87px" align="center"><asp:dropdownlist id="drpSelect" runat="server" Width="100%" CssClass=" ">
																			<asp:ListItem Value="1">Code</asp:ListItem>
																			<asp:ListItem Value="2">Name</asp:ListItem>
																		</asp:dropdownlist></TD>
																	<TD style="WIDTH: 387px" align="center"><asp:textbox id="TxtSelect" runat="server" Width="100%"></asp:textbox></TD>
																	<TD vAlign="middle" align="right"><asp:imagebutton id="IbtnSearch" accessKey="G" runat="server" Height="20px" Width="80px" ImageUrl="../../../Images/NewImages/search.gif"></asp:imagebutton></TD>
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
														<TD vAlign="top" align="center"><asp:datagrid id="dgGrid" tabIndex="13" runat="server" Width="100%" CssClass="GridMain" AllowPaging="True"
																AutoGenerateColumns="False" BorderWidth="0px" CellPadding="0" AllowSorting="True" BorderStyle="None" CellSpacing="2">
																<AlternatingItemStyle CssClass="GridAlternateItem"></AlternatingItemStyle>
																<ItemStyle CssClass="GridItem"></ItemStyle>
																<HeaderStyle Font-Bold="True" CssClass="GridHeader"></HeaderStyle>
																<FooterStyle BackColor="#D1CBCB"></FooterStyle>
																<Columns>
																	<asp:TemplateColumn HeaderText="Sl.No">
																		<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Center"></ItemStyle>
																		<ItemTemplate>
																			<asp:Label id=Label5 runat="server" Text='<%# DataBinder.Eval(Container, "DataSetIndex")+1 %>'>
																			</asp:Label>
																		</ItemTemplate>
																	</asp:TemplateColumn>
																	<asp:BoundColumn DataField="DISTRICT" HeaderText="District">
																		<HeaderStyle Wrap="False" HorizontalAlign="Center"></HeaderStyle>
																		<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
																		<FooterStyle Wrap="False"></FooterStyle>
																	</asp:BoundColumn>
																	<asp:TemplateColumn HeaderText="CODE">
																		<HeaderStyle Wrap="False" HorizontalAlign="Center"></HeaderStyle>
																		<ItemStyle Wrap="False"></ItemStyle>
																		<ItemTemplate>
																			<asp:HyperLink id=Hypnewlink runat="server" ForeColor="#ff0000" NavigateUrl='<%#"../../../Examination/BoardEnrollments/Masters/BoardCollegeEntry.aspx?Code=" &amp; DataBinder.Eval(Container.Dataitem, "CODE").ToString &amp; "&amp;Mode=EDIT" &amp; "&amp;PageIndex=" &amp; cstr(PageIndex)%>' Text='<%# Container.Dataitem("CODE")%>'>
																			</asp:HyperLink>
																		</ItemTemplate>
																		<FooterStyle Wrap="False"></FooterStyle>
																	</asp:TemplateColumn>
																	<asp:BoundColumn DataField="COLLEGENAME" HeaderText="NAME"></asp:BoundColumn>
																	<asp:BoundColumn DataField="CORPCOLLNAME" HeaderText="CORP.COLLEGE"></asp:BoundColumn>
																	<asp:BoundColumn DataField="COLLTYPE" HeaderText="CATEGORY"></asp:BoundColumn>
																	<asp:ButtonColumn Visible="False" Text="Delete" ButtonType="PushButton" HeaderText="Delete" CommandName="Delete">
																		<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Center"></ItemStyle>
																	</asp:ButtonColumn>
																</Columns>
																<PagerStyle HorizontalAlign="Center" CssClass="GridPager" Mode="NumericPages"></PagerStyle>
															</asp:datagrid></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD vAlign="top" align="center">
												<TABLE id="Table6" style="WIDTH: 967px" cellSpacing="1" cellPadding="1" width="967" border="0">
													<TR>
														<TD vAlign="top" align="center"><asp:imagebutton id="iBtnSingleMode" accessKey="S" runat="server" Height="20px" Width="80px" ImageUrl="../../../Images/NewImages/singlemode1.gif"></asp:imagebutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
															<asp:imagebutton id="iBtnCancel" runat="server" Height="20px" Width="80px" ImageUrl="../../../Images/NewImages/cancel.gif"
																Visible="False"></asp:imagebutton></TD>
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
			<asp:textbox id="txtSetfocus" style="Z-INDEX: 101; POSITION: absolute; TOP: 8px; LEFT: 24px"
				runat="server" Height="32px" Width="0px"></asp:textbox><asp:textbox id="txtMessage" style="Z-INDEX: 102; POSITION: absolute; TOP: 8px; LEFT: 40px" runat="server"
				Height="32px" Width="0px"></asp:textbox><br>
			<br>
		</form>
	</body>
</HTML>
