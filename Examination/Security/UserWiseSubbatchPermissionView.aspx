<%@ Page Language="vb" AutoEventWireup="false" Codebehind="UserWiseSubbatchPermissionView.aspx.vb" Inherits="CollegeBoard.UserWiseSubbatchPermissionView" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>UserWiseSubbatchPermissionView</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK id="Link1" href="../../Images/Login/StyleSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body background="../Images/NewImages/innerpage-bg1.jpg" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="0"
				cellPadding="1" width="100%" border="0">
				<TR>
					<TD vAlign="top" align="center">
						<TABLE id="Table2" cellSpacing="0" cellPadding="1" width="531" align="center" border="1">
							<TR>
								<TD vAlign="top" nowrap="nowrap" align="center">
									<TABLE id="Table1" borderColor="activeborder" cellSpacing="1" cellPadding="1" width="469"
										align="center" border="0">
										<TR>
											<TD vAlign="top" align="center"><asp:label id="Label1" runat="server" Width="100%" CssClass="SubHeading1" Font-Bold="True"> Users Subbatch Permissions</asp:label></TD>
										</TR>
										<TR>
											<TD vAlign="top" align="center">
												<TABLE id="Table4" cellSpacing="0" cellPadding="1" border="0">
													<TR>
														<TD nowrap="nowrap"><asp:label id="Label2" runat="server" Width="100%" CssClass="Lables">User&nbsp;Types&nbsp;*</asp:label></TD>
														<TD style="HEIGHT: 18px" nowrap="nowrap"><asp:dropdownlist id="DrpUserTypes" runat="server" Width="153px" CssClass="DropDownList" AutoPostBack="True"></asp:dropdownlist></TD>
														<TD style="HEIGHT: 18px" nowrap="nowrap"><asp:label id="Label6" runat="server" Width="120px" CssClass="Lables">Academic Year</asp:label></TD>
														<TD nowrap="nowrap"><asp:dropdownlist id="drpAcaSlno" runat="server" Width="153px" CssClass="DropDownList"></asp:dropdownlist></TD>
													</TR>
													<TR>
														<TD nowrap="nowrap"><asp:label id="Label3" runat="server" Width="100%" CssClass="Lables">Users</asp:label></TD>
														<TD nowrap="nowrap"><asp:dropdownlist id="DrpUsers" runat="server" Width="153px" CssClass="DropDownList"></asp:dropdownlist></TD>
														<TD nowrap="nowrap"></TD>
														<TD nowrap="nowrap"></TD>
													</TR>
													<TR>
														<TD nowrap="nowrap"><asp:label id="lblCourse" runat="server" Width="100%" CssClass="Lables">Course&nbsp;*</asp:label></TD>
														<TD nowrap="nowrap"><asp:dropdownlist id="drpCourse" runat="server" Width="153px" CssClass="Lables" AutoPostBack="True"></asp:dropdownlist></TD>
														<TD nowrap="nowrap"><asp:label id="lblGroup" runat="server" Width="100%" CssClass="Lables">Group&nbsp;*</asp:label></TD>
														<TD nowrap="nowrap"><asp:dropdownlist id="drpGroup" runat="server" Width="100%" CssClass="Lables" AutoPostBack="True"></asp:dropdownlist></TD>
													</TR>
													<TR>
														<TD nowrap="nowrap"><asp:label id="lblBatch" runat="server" Width="100%" CssClass="Lables">Batch&nbsp;*</asp:label></TD>
														<TD nowrap="nowrap"><asp:dropdownlist id="drpBatch" runat="server" Width="153px" CssClass="Lables" AutoPostBack="True">
																<asp:ListItem Value="0">ALL</asp:ListItem>
															</asp:dropdownlist></TD>
														<TD nowrap="nowrap"><asp:imagebutton id="iBtnSearch" accessKey="E" runat="server" Width="80px" Height="20px" ImageUrl="../../Images/NewImages/search.gif"></asp:imagebutton></TD>
														<TD nowrap="nowrap"></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 14px" vAlign="top" align="center">
												<HR width="100%" SIZE="1">
												&nbsp;
											</TD>
										</TR>
										<TR>
											<TD vAlign="top" align="center"><asp:datagrid id="dgVusers" runat="server" Width="520px" CssClass="GridMain" CellPadding="0" BorderWidth="0px"
													CellSpacing="2" BorderStyle="None" OnItemCreated="DeleteConformationMessage" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False">
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
														<asp:BoundColumn Visible="False" DataField="EUSBMAPSLNO" HeaderText="EUSBMAPSLNO"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="USERSLNO" HeaderText="User Slno"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="COURSESLNO" HeaderText="COURSESLNO"></asp:BoundColumn>
														<asp:BoundColumn DataField="COURSE" HeaderText="Course"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="GROUPSLNO" HeaderText="GROUPSLNO"></asp:BoundColumn>
														<asp:BoundColumn DataField="GROUPNAME" HeaderText="Group"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="BATCHSLNO" HeaderText="BATCHSLNO"></asp:BoundColumn>
														<asp:BoundColumn DataField="BATCH" HeaderText="Batch"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="SUBBATCHSLNO" HeaderText="SUBBATCHSLNO"></asp:BoundColumn>
														<asp:BoundColumn DataField="SUBBATCH" HeaderText="Subbatch"></asp:BoundColumn>
														<asp:ButtonColumn Text="Delete" ButtonType="PushButton" CommandName="Delete"></asp:ButtonColumn>
													</Columns>
													<PagerStyle VerticalAlign="Middle" HorizontalAlign="Center" PageButtonCount="100" CssClass="GridPager"
														Mode="NumericPages"></PagerStyle>
												</asp:datagrid></TD>
										</TR>
										<TR>
											<TD vAlign="top" align="right">
												<TABLE id="Table5" style="WIDTH: 88px; HEIGHT: 8px" cellSpacing="0" cellPadding="0" width="88"
													border="0">
													<TR>
														<TD><asp:imagebutton id="ibtnEdit" accessKey="S" runat="server" Width="80px" Height="20px" ImageUrl="../../Images/NewImages/edit.gif"
																AlternateText="Single"></asp:imagebutton></TD>
														<TD><asp:imagebutton id="ibtnBatch" accessKey="S" runat="server" Width="80px" Height="20px" ImageUrl="../../Images/NewImages/batchmode.gif"
																AlternateText="Single"></asp:imagebutton></TD>
													</TR>
												</TABLE>
												&nbsp;</TD>
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
