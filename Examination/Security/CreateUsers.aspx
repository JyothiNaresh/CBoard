<%@ Page Language="vb" AutoEventWireup="false" Codebehind="CreateUsers.aspx.vb" Inherits="CollegeBoard.CreateUsers" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>CreateUsers</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Images/Login/StyleSheet_Report.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout" background="../Images/NewImages/innerpage-bg1.jpg">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="0"
				cellPadding="1" width="100%" align="center" border="0">
				<TR>
					<TD vAlign="baseline" nowrap="nowrap" align="center">
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="423" align="center" border="1">
							<TR>
								<TD class="Lables" vAlign="middle" align="center" style="HEIGHT: 22px"><asp:label id="lblHeading" runat="server" Width="100%" CssClass="SubHeading1">User&nbsp;Type&nbsp;Creation</asp:label></TD>
							</TR>
							<TR>
								<TD class="Lables" vAlign="top" align="center"><asp:datagrid id="dgUserType" runat="server" Width="413px" CssClass="GridMain" AutoGenerateColumns="False"
										AllowPaging="True" OnItemCreated="DeleteConformationMessage" BorderStyle="None" CellSpacing="2" BorderWidth="0px" CellPadding="0">
										<SelectedItemStyle Font-Bold="True" ForeColor="White"></SelectedItemStyle>
										<AlternatingItemStyle CssClass="GridAlternateItem"></AlternatingItemStyle>
										<ItemStyle CssClass="GridItem"></ItemStyle>
										<HeaderStyle Font-Bold="True" CssClass="GridHeader"></HeaderStyle>
										<FooterStyle ForeColor="#8C4510" BackColor="#F7DFB5"></FooterStyle>
										<Columns>
											<asp:BoundColumn DataField="DGSLNO" HeaderText="Sno"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="USERTYPESLNO" HeaderText="USERTYPESLNO"></asp:BoundColumn>
											<asp:BoundColumn DataField="NAME" HeaderText="User Type">
												<HeaderStyle Width="100px"></HeaderStyle>
												<ItemStyle Width="100px"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="DESCRIPTION" HeaderText="Description">
												<HeaderStyle Width="150px"></HeaderStyle>
												<ItemStyle Width="150px"></ItemStyle>
											</asp:BoundColumn>
											<asp:ButtonColumn Text="Edit" ButtonType="PushButton" CommandName="Edit"></asp:ButtonColumn>
											<asp:ButtonColumn Text="Delete" ButtonType="PushButton" CommandName="Delete"></asp:ButtonColumn>
										</Columns>
										<PagerStyle VerticalAlign="Middle" HorizontalAlign="Center" CssClass="GridPager" Mode="NumericPages"></PagerStyle>
									</asp:datagrid></TD>
							</TR>
							<TR>
								<TD vAlign="middle" align="right"><asp:imagebutton id="ibtnAdd" runat="server" ImageUrl="../../Images/NewImages/add.gif" Width="80px"
										Height="20px" AlternateText="Add"></asp:imagebutton></TD>
							</TR>
							<TR>
								<TD class="Lables" vAlign="middle" align="center"><asp:panel id="UserPanel" runat="server" Height="72px">
										<TABLE id="Table3" style="WIDTH: 398px; HEIGHT: 48px" cellSpacing="0" cellPadding="1" width="398"
											border="0">
											<TR>
												<TD>
													<asp:Label id="lblUserType" runat="server" CssClass="Lables">User&nbsp;Type&nbsp;*</asp:Label></TD>
												<TD>
													<asp:TextBox id="txtUserName" runat="server" CssClass="Textbox" Width="160px"></asp:TextBox></TD>
												<TD>
													<asp:Label id="Label1" runat="server" CssClass="Lables">Description</asp:Label></TD>
												<TD>
													<asp:TextBox id="txtDesc" runat="server" CssClass="Textbox" Width="94px"></asp:TextBox></TD>
											</TR>
											<TR>
												<TD vAlign="middle" align="center" colSpan="4"></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 2px" vAlign="middle" align="right" colSpan="4">&nbsp;
													<asp:ImageButton id="ibtnSave" runat="server" CssClass="button" Width="80px" AlternateText="Save"
														Height="24px" ImageUrl="../../Images/NewImages/save.gif"></asp:ImageButton>&nbsp;&nbsp;
													<asp:ImageButton id="ibtnCancel" runat="server" CssClass="button" Width="80px" AlternateText="Cancel"
														Height="24px" ImageUrl="../../Images/NewImages/cancel.gif"></asp:ImageButton></TD>
											</TR>
										</TABLE>
									</asp:panel></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
