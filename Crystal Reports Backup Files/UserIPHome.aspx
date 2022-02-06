<%@ Page Language="vb" AutoEventWireup="false" Codebehind="UserIPHome.aspx.vb" Inherits="CollegeBoard.UserIPHome" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>UserIPHome</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../Images/Login/StyleSheet_Report.css" type="text/css" rel="stylesheet">
		<style type="text/css">BODY { SCROLLBAR-FACE-COLOR: #ebded6; SCROLLBAR-ARROW-COLOR: black }
		</style>
	</HEAD>
	<body background="../../../Images/NewImages/innerpage-bg1.jpg" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="0"
				cellPadding="1" width="100%" align="center" border="0">
				<TR>
					<TD vAlign="baseline" nowrap="nowrap" align="center">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="265" align="center" border="1">
							<TR>
								<TD style="HEIGHT: 35px" vAlign="middle" nowrap="nowrap" align="center"><asp:label id="lblHeading" runat="server" Width="100%" CssClass="SubHeading1">User&nbsp;Wise&nbsp;IP&nbsp;Block</asp:label>
									<TABLE id="Table3" style="WIDTH: 193px; HEIGHT: 28px" cellSpacing="1" cellPadding="0" width="193"
										border="1">
										<TR>
											<TD nowrap="nowrap"><asp:label id="LblBranch" runat="server" Width="80px" CssClass="Lables" Font-Names="Arial">Adm/Exam</asp:label></TD>
											<TD nowrap="nowrap"><asp:dropdownlist id="DrpAdmExam" runat="server" Width="140px" CssClass="DropDownList" Height="20px"
													AutoPostBack="True">
													<asp:ListItem Value="1">Admissions</asp:ListItem>
													<asp:ListItem Value="2">Examination</asp:ListItem>
												</asp:dropdownlist></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD vAlign="middle" nowrap="nowrap" align="center"></TD>
							</TR>
							<TR>
								<TD vAlign="middle" nowrap="nowrap" align="center" colSpan="1" rowSpan="1"><asp:datagrid id="dgBBS" runat="server" Width="259px" CssClass="GridMain" AllowPaging="True" AutoGenerateColumns="False"
										BorderWidth="0px" CellPadding="0" OnItemCreated="DeleteConformationMessage" BorderStyle="None" CellSpacing="2">
										<FooterStyle Wrap="False"></FooterStyle>
										<SelectedItemStyle Font-Bold="True" Wrap="False" ForeColor="White" BackColor="#738A9C"></SelectedItemStyle>
										<EditItemStyle Wrap="False"></EditItemStyle>
										<AlternatingItemStyle Wrap="False" CssClass="GridAlternateItem"></AlternatingItemStyle>
										<ItemStyle Wrap="False" CssClass="GridItem"></ItemStyle>
										<HeaderStyle Font-Bold="True" Wrap="False" CssClass="GridHeader"></HeaderStyle>
										<Columns>
											<asp:TemplateColumn HeaderText="SL.No">
												<HeaderStyle Wrap="False"></HeaderStyle>
												<ItemStyle Wrap="False"></ItemStyle>
												<ItemTemplate>
													<asp:Label id=LabeSlno runat="server" Text='<%# DataBinder.Eval(Container, "DataSetIndex")+1 %>'>
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn Visible="False" DataField="GWUSERSLNO" HeaderText="GWUSERSLNO"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="USERSLNO" HeaderText="USERSLNO"></asp:BoundColumn>
											<asp:BoundColumn DataField="USERID" HeaderText="USERID">
												<ItemStyle Wrap="False"></ItemStyle>
												<FooterStyle Wrap="False"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="IPADDR" HeaderText="IP&amp;nbsp;Address"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="IPCOUNT" HeaderText="IPCOUNT"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="ADMOREXAM" HeaderText="ADMOREXAM"></asp:BoundColumn>
											<asp:EditCommandColumn ButtonType="PushButton" UpdateText="Update" CancelText="Cancel" EditText="Edit">
												<HeaderStyle Width="30px"></HeaderStyle>
												<ItemStyle Width="30px"></ItemStyle>
											</asp:EditCommandColumn>
											<asp:ButtonColumn Text="Delete" ButtonType="PushButton" CommandName="Delete">
												<HeaderStyle Width="30px"></HeaderStyle>
												<ItemStyle Width="30px"></ItemStyle>
											</asp:ButtonColumn>
										</Columns>
										<PagerStyle VerticalAlign="Middle" HorizontalAlign="Center" PageButtonCount="100" CssClass="GridPager"
											Wrap="False" Mode="NumericPages"></PagerStyle>
									</asp:datagrid></TD>
							</TR>
							<TR>
								<TD vAlign="middle" nowrap="nowrap" align="right" colSpan="1" rowSpan="1"><asp:imagebutton id="iBtnSingleMode" accessKey="S" runat="server" Width="80px" Height="20px" ImageUrl="../../../Images/NewImages/singlemode1.gif"></asp:imagebutton>&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			<asp:textbox id="txtDeleteStatus" Width="0" Height="0" Runat="server"></asp:textbox></form>
	</body>
</HTML>
