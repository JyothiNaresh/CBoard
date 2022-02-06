<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MastersHome.aspx.vb" Inherits="CollegeBoard.MastersHome" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Board Masters Home</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK id="Link1" href="../../../Images/Login/StyleSheet_Report.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" type="text/javascript" src="src=../../Include/Topics.js"></script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="TopicDetails" method="post" runat="server">
			<asp:textbox id="txtSetfocus" style="Z-INDEX: 103; LEFT: 16px; POSITION: absolute; TOP: 16px"
				runat="server" Height="32px" Width="0px"></asp:textbox>
			<TABLE id="Table7" style="Z-INDEX: 105; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="0"
				cellPadding="1" width="100%" border="0">
				<TR>
					<TD>
						<TABLE class="panel" id="Table1" style="WIDTH: 565px" cellSpacing="0" cellPadding="1" width="565"
							align="center" border="1">
							<TR>
								<TD vAlign="top" align="center">
									<TABLE id="Table2" style="WIDTH: 559px" cellSpacing="0" cellPadding="1" width="559" border="0">
										<TR>
											<TD vAlign="top" align="center">
												<TABLE id="Table3" style="HEIGHT: 21px" cellSpacing="0" cellPadding="1" width="100%" border="0">
													<TR>
														<TD>
															<CENTER><asp:label id="lblHeading" runat="server" Width="100%" Font-Bold="True" CssClass="SubHeading1">Board&nbsp;Masters</asp:label></CENTER>
														</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD vAlign="top" align="center">
												<TABLE id="Table6" style="WIDTH: 253px; HEIGHT: 23px" cellSpacing="1" cellPadding="1" width="253"
													border="0">
													<TR>
														<TD><asp:label id="LblCourse" runat="server" Width="100%" CssClass="Lables">Select</asp:label></TD>
														<TD><asp:dropdownlist id="DrpBoardMaster" runat="server" Width="211px" CssClass=" " AutoPostBack="True">
																<asp:ListItem Value="1" Selected="True">District</asp:ListItem>
																<asp:ListItem Value="2">Previous Exam</asp:ListItem>
																<asp:ListItem Value="3">Year of Pass</asp:ListItem>
																<asp:ListItem Value="4">Category</asp:ListItem>
																<asp:ListItem Value="5">Medium</asp:ListItem>
																<asp:ListItem Value="6">Religion</asp:ListItem>
																<asp:ListItem Value="7">Caste</asp:ListItem>
																<asp:ListItem Value="14">Sub Caste</asp:ListItem>
																<asp:ListItem Value="8">Physical Status</asp:ListItem>
																<asp:ListItem Value="9">Subject</asp:ListItem>
																<asp:ListItem Value="10">Group</asp:ListItem>
																<asp:ListItem Value="11">Second Language</asp:ListItem>
																<asp:ListItem Value="12">College Type</asp:ListItem>
																<asp:ListItem Value="13">Corporate College</asp:ListItem>
															</asp:dropdownlist></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD vAlign="top" align="center">
												<TABLE id="Table5" style="WIDTH: 556px" cellSpacing="0" cellPadding="1" width="556" border="0">
													<TR>
														<TD vAlign="top" align="center"><asp:datagrid id="dgGridBatch" tabIndex="1" runat="server" Height="32px" Width="100%" CssClass="GridMain"
																AllowPaging="True" AutoGenerateColumns="False" BorderWidth="0px" CellPadding="0" BorderStyle="Dotted" OnItemCreated="DeleteConformationMessage"
																CellSpacing="2">
																<SelectedItemStyle Font-Bold="True"></SelectedItemStyle>
																<AlternatingItemStyle CssClass="GridAlternateItem"></AlternatingItemStyle>
																<ItemStyle CssClass="GridItem"></ItemStyle>
																<HeaderStyle Font-Bold="True" CssClass="GridHeader"></HeaderStyle>
																<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
																<Columns>
																	<asp:BoundColumn DataField="BESLNO" HeaderText="Sl.&#160;No.">
																		<HeaderStyle HorizontalAlign="Center" Width="50px" VerticalAlign="Top"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Center"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="CODE" HeaderText="Code"></asp:BoundColumn>
																	<asp:BoundColumn DataField="NAME" HeaderText="Name">
																		<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="Description" HeaderText="Description">
																		<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="SLNO" HeaderText="MasterSlno" Visible="False"></asp:BoundColumn>
																	<asp:EditCommandColumn ButtonType="PushButton" UpdateText="Update" CancelText="Cancel" EditText="Edit"></asp:EditCommandColumn>
																	<asp:ButtonColumn Text="Delete" ButtonType="PushButton" CommandName="Delete"></asp:ButtonColumn>
																</Columns>
																<PagerStyle HorizontalAlign="Center" CssClass="GridPager" Mode="NumericPages"></PagerStyle>
															</asp:datagrid></TD>
													</TR>
													<TR>
														<TD vAlign="top" align="center"><asp:imagebutton id="iBtnSingle" accessKey="S" tabIndex="3" runat="server" Height="20px" Width="80px"
																ImageUrl="../../../Images/NewImages/singlemode1.gif"></asp:imagebutton>&nbsp;
															<asp:imagebutton id="iBtnBatch" accessKey="B" tabIndex="3" runat="server" Height="20px" Width="80px"
																ImageUrl="../../../Images/NewImages/batchmode.gif"></asp:imagebutton>&nbsp;
															<asp:imagebutton id="iBtnCancel" accessKey="C" tabIndex="4" runat="server" Height="20px" Width="80px"
																ImageUrl="../../../Images/NewImages/cancel.gif" Visible="False"></asp:imagebutton><asp:button id="cmdCancel" accessKey="C" tabIndex="3" runat="server" Height="32px" Width="0px"
																Font-Bold="True" CssClass="Button" Visible="False" ForeColor="White" Text="Cancel"></asp:button>&nbsp;&nbsp;&nbsp;</TD>
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
			<asp:textbox id="txtMessage" style="Z-INDEX: 101; LEFT: 40px; POSITION: absolute; TOP: 16px"
				runat="server" Height="32px" Width="0px"></asp:textbox><asp:textbox id="txtDeleteStatus" style="Z-INDEX: 102; LEFT: 64px; POSITION: absolute; TOP: 16px"
				runat="server" Height="32px" Width="0px"></asp:textbox></form>
	</body>
</HTML>
