<%@ Page Language="vb" AutoEventWireup="false" Codebehind="AcaEbBrdColMapBatch.aspx.vb" Inherits="CollegeBoard.AcaEbBrdColMapBatch" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>AcaEbBrdColMapBatch</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="JavaScript" type="text/javascript" src="../../Include/ExamScheduleHome.js"></script>
		<LINK id="Link1" href="../../../Images/Login/StyleSheet_Report.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="AcaEbBrdColMapBatch" method="post" runat="server">
			<TABLE id="Table7" style="Z-INDEX: 105; LEFT: 8px; WIDTH: 991px; POSITION: absolute; TOP: 8px; HEIGHT: 366px"
				cellSpacing="1" cellPadding="1" width="991" border="0">
				<TR>
					<TD vAlign="top" align="center">
						<TABLE id="Table1" style="WIDTH: 930px" cellSpacing="0" cellPadding="1" width="930" align="center"
							border="1">
							<TR>
								<TD vAlign="top" align="center">
									<TABLE id="Table2" style="WIDTH: 922px" cellSpacing="1" cellPadding="1" width="922" align="center"
										border="0">
										<TR>
											<TD vAlign="top" align="center" colSpan="1" rowSpan="1">
												<TABLE id="Table3" style="WIDTH: 917px; HEIGHT: 8px" cellSpacing="1" cellPadding="1" width="917"
													border="0">
													<TR>
														<TD vAlign="top" align="center"><asp:label id="lblHeading" runat="server" CssClass="SubHeading1" Width="100%"> AcademicYear- ExamBranch-College Mapping</asp:label></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD vAlign="top" align="center">
												<TABLE id="Table4" style="WIDTH: 505px; HEIGHT: 24px" cellSpacing="1" cellPadding="1" border="0">
													<TR>
														<TD><asp:label id="lblCourse" runat="server" CssClass="Lables" Width="100%">Academic&nbsp;Year</asp:label></TD>
														<TD><asp:dropdownlist id="drpAcaSlno" runat="server" Width="200px"></asp:dropdownlist></TD>
														<TD><asp:label id="lblGroup" runat="server" CssClass="Lables" Width="100%"> District</asp:label></TD>
														<TD><asp:dropdownlist id="DrpDist" runat="server" CssClass="textboxASR" Width="200px" AutoPostBack="True"></asp:dropdownlist></TD>
														<TD><asp:imagebutton id="Ibtngo" accessKey="S" runat="server" Width="100%" Height="20px" ImageUrl="../../../Images/NewImages/go.gif"></asp:imagebutton></TD>
													</TR>
													<TR>
														<TD>
															<asp:label id="Label2" runat="server" Width="100%" CssClass="Lables">College/Code</asp:label></TD>
														<TD colSpan="3">
															<asp:textbox id="txtSearch" runat="server" Width="100%" CssClass="textboxASR"></asp:textbox></TD>
														<TD>
															<asp:imagebutton id="IbtnSearch" accessKey="S" runat="server" Width="100%" ImageUrl="../../../Images/NewImages/go.gif"
																Height="20px"></asp:imagebutton></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD vAlign="top" align="center">
												<TABLE id="Table8" cellSpacing="1" cellPadding="1" width="300" border="1">
													<TR>
														<TD><asp:label id="Label3" runat="server" CssClass="Lables" Width="102px">ExamBranch</asp:label></TD>
														<TD><asp:dropdownlist id="drpBranchSearch" runat="server" CssClass="textboxASR" Width="200px" AutoPostBack="True"></asp:dropdownlist></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD vAlign="top" align="center">
												<TABLE id="Table5" style="WIDTH: 915px" cellSpacing="1" cellPadding="1" border="0">
													<TR>
														<TD vAlign="top" align="center"><asp:datagrid id="DgColl" tabIndex="13" runat="server" CssClass="GridMain" Width="100%" AutoGenerateColumns="False"
																BorderWidth="0px" CellPadding="0" BorderStyle="None" CellSpacing="2">
																<AlternatingItemStyle CssClass="GridAlternateItem"></AlternatingItemStyle>
																<ItemStyle CssClass="GridItem"></ItemStyle>
																<HeaderStyle Font-Bold="True" CssClass="GridHeader"></HeaderStyle>
																<Columns>
																	<asp:TemplateColumn HeaderText="Sl.No">
																		<HeaderStyle HorizontalAlign="Center" Width="100px"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
																		<ItemTemplate>
																			<asp:Label id=Label1 runat="server" Width="0px" Text='<%# DataBinder.Eval(Container, "DataSetIndex") +1 %>'>
																			</asp:Label>
																		</ItemTemplate>
																	</asp:TemplateColumn>
																	<asp:BoundColumn Visible="False" DataField="COLLSLNO" HeaderText="SLNO"></asp:BoundColumn>
																	<asp:BoundColumn DataField="DIST" HeaderText="DISTRICT"></asp:BoundColumn>
																	<asp:BoundColumn DataField="CODE" HeaderText="CODE">
																		<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="COLLEGENAME" HeaderText="COLLEGE NAME"></asp:BoundColumn>
																	<asp:TemplateColumn>
																		<HeaderTemplate>
																			<asp:CheckBox id="chkHT" onclick="return BrdCheckAll();" runat="server"></asp:CheckBox>
																		</HeaderTemplate>
																		<ItemTemplate>
																			<asp:CheckBox id="chkIT" runat="server" AutoPostBack="False"></asp:CheckBox>
																		</ItemTemplate>
																	</asp:TemplateColumn>
																</Columns>
																<PagerStyle VerticalAlign="Middle" HorizontalAlign="Center" CssClass="GridPager" Mode="NumericPages"></PagerStyle>
															</asp:datagrid></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD vAlign="top" align="center">
												<TABLE id="Table6" style="WIDTH: 916px" cellSpacing="1" cellPadding="1" width="916" border="0">
													<TR>
														<TD vAlign="top" align="center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
															<asp:imagebutton id="iBtnSave" accessKey="S" runat="server" Width="80px" Height="20px" ImageUrl="../../../Images/NewImages/save.gif"></asp:imagebutton><asp:imagebutton id="iBtnCancel" accessKey="C" runat="server" Width="80px" Height="20px" ImageUrl="../../../Images/NewImages/cancel.gif"></asp:imagebutton></TD>
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
			<asp:textbox id="txtSetfocus" style="Z-INDEX: 101; LEFT: 24px; POSITION: absolute; TOP: 8px"
				runat="server" Width="0px" Height="32px"></asp:textbox><asp:textbox id="txtMessage" style="Z-INDEX: 102; LEFT: 40px; POSITION: absolute; TOP: 8px" runat="server"
				Width="0px" Height="32px"></asp:textbox><br>
			<br>
		</form>
	</body>
</HTML>
