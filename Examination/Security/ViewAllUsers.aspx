<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ViewAllUsers.aspx.vb" Inherits="CollegeBoard.ViewAllUsers" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>ViewAllUsers</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK id="Link1" href="../../Images/Login/StyleSheet_Report.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body background="../Images/NewImages/innerpage-bg1.jpg" MS_POSITIONING="GridLayout">
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
											<TD vAlign="middle" align="center"><asp:label id="Label1" runat="server" Font-Bold="True" CssClass="SubHeading1" Width="100%">View All Users</asp:label></TD>
										</TR>
										<TR>
											<TD vAlign="middle" align="center">
												<TABLE id="Table4" cellSpacing="0" cellPadding="1" width="300" border="0">
													<TR>
														<TD nowrap="nowrap"><asp:label id="Label2" runat="server" CssClass="Lables" Width="110px">User&nbsp;Types&nbsp;*</asp:label></TD>
														<TD nowrap="nowrap"><asp:dropdownlist id="DrpUserTypes" runat="server" CssClass="DropDownList" Width="153px"></asp:dropdownlist></TD>
														<TD nowrap="nowrap"><asp:label id="Label6" runat="server" CssClass="Lables" Width="120px">Academic Year</asp:label></TD>
														<TD nowrap="nowrap"><asp:dropdownlist id="drpAcaSlno" runat="server" CssClass="DropDownList" Width="153px"></asp:dropdownlist></TD>
														<TD nowrap="nowrap"><asp:imagebutton id="iBtnSearch" accessKey="E" runat="server" Width="80px" ImageUrl="../../Images/NewImages/search.gif"
																Height="20px"></asp:imagebutton></TD>
													</TR>
													<TR>
														<TD nowrap="nowrap"><asp:dropdownlist id="DrpSearch" runat="server" Width="100%">
																<asp:ListItem Value="1">Name</asp:ListItem>
																<asp:ListItem Value="2" Selected="True">User Id</asp:ListItem>
																<asp:ListItem Value="3">ExamBranch</asp:ListItem>
																<asp:ListItem Value="4">PayrollBranch</asp:ListItem>
															</asp:dropdownlist></TD>
														<TD nowrap="nowrap" colSpan="3"><asp:textbox id="TxtUserID" runat="server" Width="100%"></asp:textbox></TD>
														<TD nowrap="nowrap"><asp:imagebutton id="iBtnUser" accessKey="E" runat="server" Width="80px" ImageUrl="../../Images/NewImages/search.gif"
																Height="20px"></asp:imagebutton></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD vAlign="top" align="center"><asp:datagrid id="dgVusers" runat="server" CssClass="GridMain" Width="714px" AutoGenerateColumns="False"
													AllowSorting="True" AllowPaging="True" OnItemCreated="DeleteConformationMessage" BorderStyle="None" CellSpacing="2" BorderWidth="0px"
													CellPadding="0" PageSize="16">
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
														<asp:BoundColumn DataField="UserId" SortExpression="UserId" HeaderText="User Id">
															<ItemStyle Wrap="False"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Name" SortExpression="Name" HeaderText="Name">
															<ItemStyle Wrap="False"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="EBRANCH" HeaderText="EBranch">
															<HeaderStyle Width="20px"></HeaderStyle>
															<ItemStyle Wrap="False"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="PBRANCH" HeaderText="PBranch">
															<HeaderStyle Width="20px"></HeaderStyle>
															<ItemStyle Wrap="False"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="USERSTATUS" HeaderText="Status">
															<HeaderStyle Wrap="False"></HeaderStyle>
															<ItemStyle Wrap="False"></ItemStyle>
															<FooterStyle Wrap="False"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="REGISTER" HeaderText="Register">
															<HeaderStyle Wrap="False"></HeaderStyle>
															<ItemStyle Wrap="False"></ItemStyle>
															<FooterStyle Wrap="False"></FooterStyle>
														</asp:BoundColumn>
														<asp:EditCommandColumn ButtonType="PushButton" UpdateText="Update" HeaderText="Edit" CancelText="Cancel"
															EditText="Edit"></asp:EditCommandColumn>
														<asp:ButtonColumn Text="Del/Add" ButtonType="PushButton" HeaderText="Status" CommandName="Delete">
															<ItemStyle Wrap="False"></ItemStyle>
														</asp:ButtonColumn>
														<asp:TemplateColumn HeaderText="User Reg">
															<ItemTemplate>
																<asp:Button id="BtnUnRegister" runat="server" Text="UnReg."></asp:Button>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn DataField="VSATSTATUS" HeaderText="Vsat">
															<ItemStyle Wrap="False"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Hint" HeaderText="Hint">
															<ItemStyle Wrap="False"></ItemStyle>
														</asp:BoundColumn>
													</Columns>
													<PagerStyle VerticalAlign="Middle" HorizontalAlign="Center" PageButtonCount="100" CssClass="GridPager"
														Mode="NumericPages"></PagerStyle>
												</asp:datagrid></TD>
										</TR>
										<TR>
											<TD vAlign="top" align="right"><asp:imagebutton id="iBtnBatchUpdate" accessKey="A" runat="server" Width="80px" ImageUrl="../../Images/NewImages/batchupdate.gif"
													Height="20px" AlternateText="Batch Update"></asp:imagebutton><asp:imagebutton id="ibtnSingle" accessKey="S" runat="server" Width="80px" ImageUrl="../../Images/NewImages/singlemode1.gif"
													Height="20px" AlternateText="Single"></asp:imagebutton>&nbsp;</TD>
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
