<%@ Page Language="vb" AutoEventWireup="false" Codebehind="UserCombikeyView.aspx.vb" Inherits="CollegeBoard.UserCombikeyView" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>:: User Wise Combination Key :: </title>
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
						<TABLE id="Table2" cellSpacing="0" cellPadding="1" width="531" align="center" border="1">
							<TR>
								<TD vAlign="top" nowrap="nowrap" align="center">
									<TABLE id="Table1" borderColor="activeborder" cellSpacing="1" cellPadding="1" width="469"
										align="center" border="0" style="WIDTH: 469px; HEIGHT: 452px">
										<TR>
											<TD vAlign="middle" align="center">
												<asp:label id="Label1" runat="server" Width="100%" CssClass="SubHeading1" Font-Bold="True"> Users Combination Key</asp:label></TD>
										</TR>
										<TR>
											<TD vAlign="top" align="center" style="HEIGHT: 46px">
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
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD vAlign="top" align="center" style="HEIGHT: 14px">
												<HR width="100%" SIZE="1">
												&nbsp;
											</TD>
										</TR>
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
										<TR>
											<TD vAlign="top" align="right">
												<TABLE id="Table5" style="WIDTH: 88px; HEIGHT: 8px" cellSpacing="0" cellPadding="0" width="88"
													border="0">
													<TR>
														<TD>
															<asp:imagebutton id="ibtnEdit" accessKey="S" runat="server" Width="80px" Height="20px" ImageUrl="../../Images/NewImages/edit.gif"
																AlternateText="Single"></asp:imagebutton></TD>
														<TD>
															<asp:imagebutton id="ibtnBatch" accessKey="S" runat="server" Width="80px" Height="20px" ImageUrl="../../Images/NewImages/batchmode.gif"
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
