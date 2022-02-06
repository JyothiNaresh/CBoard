<%@ Page Language="vb" AutoEventWireup="false" Codebehind="EmpEbMappingView.aspx.vb" Inherits="CollegeBoard.EmpEbMappingView"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>:: :: </title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK id="Link1" href="../../Images/Login/StyleSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout" background="../Images/NewImages/innerpage-bg1.jpg">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="0"
				cellPadding="1" width="100%" border="0">
				<TR>
					<TD vAlign="top" align="center">
						<TABLE id="Table2" cellSpacing="0" cellPadding="1" width="714" align="center" border="1">
							<TR>
								<TD vAlign="top" nowrap="nowrap" align="center">
									<TABLE id="Table1" borderColor="activeborder" cellSpacing="1" cellPadding="1" width="714"
										align="center" border="0">
										<TR>
											<TD vAlign="middle" align="center">
												<asp:label id="Label1" runat="server" Width="100%" CssClass="SubHeading1" Font-Bold="True">View All Users</asp:label></TD>
										</TR>
										<TR>
											<TD vAlign="middle" align="center">
												<TABLE id="Table4" cellSpacing="0" cellPadding="1" width="300" border="0">
													<TR>
														<TD nowrap="nowrap">
															<asp:label id="Label6" runat="server" CssClass="Lables" Width="120px">Academic Year</asp:label></TD>
														<TD nowrap="nowrap">
															<asp:dropdownlist id="drpAcaSlno" runat="server" CssClass="DropDownList" Width="153px" AutoPostBack="True"></asp:dropdownlist></TD>
														<TD nowrap="nowrap">
															<asp:label id="Label2" runat="server" CssClass="Lables" Width="110px">Exam&nbspBranch&nbsp;*</asp:label></TD>
														<TD nowrap="nowrap">
															<asp:dropdownlist id="DrpExamBranch" runat="server" CssClass="DropDownList" Width="153px"></asp:dropdownlist></TD>
														<TD nowrap="nowrap">
															<asp:imagebutton id="iBtnSearch" accessKey="E" runat="server" Width="80px" Height="20px" ImageUrl="../../Images/NewImages/search.gif"></asp:imagebutton></TD>
													</TR>
													<TR>
														<TD nowrap="nowrap">
															<asp:label id="Label11" runat="server" CssClass="Lables" Width="100%">Department</asp:label></TD>
														<TD nowrap="nowrap">
															<asp:dropdownlist id="DrpDepartment" runat="server" CssClass=" " Width="156px"></asp:dropdownlist></TD>
														<TD nowrap="nowrap"></TD>
														<TD nowrap="nowrap"></TD>
														<TD nowrap="nowrap"></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD vAlign="top" align="center">
												<asp:datagrid id="dgVusers" runat="server" Width="714px" CssClass="GridMain" PageSize="16" CellPadding="0"
													BorderWidth="0px" CellSpacing="2" BorderStyle="None" OnItemCreated="DeleteConformationMessage"
													AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False">
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
														<asp:BoundColumn Visible="False" DataField="UserSlno" HeaderText="User Slno"></asp:BoundColumn>
														<asp:BoundColumn DataField="UserId" SortExpression="UserId" HeaderText="User Id"></asp:BoundColumn>
														<asp:BoundColumn DataField="Name" SortExpression="Name" HeaderText="Name"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="FromDate" HeaderText="From Date"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="TOFATE" HeaderText="To Date"></asp:BoundColumn>
														<asp:BoundColumn DataField="USERSTATUS" HeaderText="User Status">
															<HeaderStyle Wrap="False"></HeaderStyle>
															<ItemStyle Wrap="False"></ItemStyle>
															<FooterStyle Wrap="False"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="REGISTER" HeaderText="Register">
															<HeaderStyle Wrap="False"></HeaderStyle>
															<ItemStyle Wrap="False"></ItemStyle>
															<FooterStyle Wrap="False"></FooterStyle>
														</asp:BoundColumn>
														<asp:EditCommandColumn Visible="False" ButtonType="PushButton" UpdateText="Update" CancelText="Cancel"
															EditText="Edit"></asp:EditCommandColumn>
														<asp:ButtonColumn Visible="False" Text="Del / Add" ButtonType="PushButton" CommandName="Delete"></asp:ButtonColumn>
														<asp:TemplateColumn Visible="False">
															<ItemTemplate>
																<asp:Button id="BtnUnRegister" runat="server" Text="Un Register"></asp:Button>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn DataField="EMPNAME" HeaderText="Employee">
															<HeaderStyle Wrap="False"></HeaderStyle>
															<ItemStyle Wrap="False"></ItemStyle>
															<FooterStyle Wrap="False"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="EMPCODE" HeaderText="Employee Code">
															<HeaderStyle Wrap="False"></HeaderStyle>
															<ItemStyle Wrap="False"></ItemStyle>
															<FooterStyle Wrap="False"></FooterStyle>
														</asp:BoundColumn>
													</Columns>
													<PagerStyle VerticalAlign="Middle" HorizontalAlign="Center" PageButtonCount="100" CssClass="GridPager"
														Mode="NumericPages"></PagerStyle>
												</asp:datagrid></TD>
										</TR>
										<TR>
											<TD vAlign="top" align="right">
												<asp:imagebutton id="iBtnBatchUpdate" accessKey="A" runat="server" Width="80px" ImageUrl="../../Images/NewImages/batchupdate.gif"
													Height="20px" AlternateText="Batch Update" Visible="False"></asp:imagebutton>
												<asp:imagebutton id="ibtnSingle" accessKey="S" runat="server" Width="80px" AlternateText="Single"
													Height="20px" ImageUrl="../../Images/NewImages/singlemode1.gif"></asp:imagebutton>&nbsp;</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
