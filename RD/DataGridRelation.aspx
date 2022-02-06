<%@ Page Language="vb" AutoEventWireup="false" Codebehind="DataGridRelation.aspx.vb" Inherits="CollegeBoard.DataGridRelation"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>DataGridRelation</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK id="Link1" href="../Images/Login/StyleSheet_Report.css" type="text/css" rel="stylesheet">
		<script>
			setInterval("x()",1);
			self.focus();
			function x(){window.status=" Powerd By Navayuga InfoTech Pvt Ltd., CMM Level-4 Company.     :: Narayana Educational Sociaty :: "}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:datagrid id="dgSets" style="Z-INDEX: 100; LEFT: 32px; POSITION: absolute; TOP: 8px" tabIndex="11"
				runat="server" GridLines="Horizontal" BackColor="White" BorderColor="#E7E7FF" CssClass="GridMain"
				AllowSorting="True" CellPadding="3" BorderWidth="1px" AutoGenerateColumns="False" BorderStyle="None"
				PageSize="6" Width="456px">
				<SelectedItemStyle Font-Bold="True" ForeColor="#F7F7F7" BackColor="#738A9C"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#F7F7F7"></AlternatingItemStyle>
				<ItemStyle ForeColor="#4A3C8C" CssClass="GridItem" BackColor="#E7E7FF"></ItemStyle>
				<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="#F7F7F7" CssClass="GridHeader"
					BackColor="#4A3C8C"></HeaderStyle>
				<FooterStyle ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="SUBJECTSLNO" HeaderText="SUBJECTSLNO">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="SUBJECTNAME" HeaderText="Subject"></asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:LinkButton id="Linkbutton12" runat="server" CommandName="LbtnUnRead">
								<%# DataBinder.Eval(Container, "DataItem.SUBJECTNAME") %>
							</asp:LinkButton>
							<asp:DataGrid id="Datagrid4" runat="server" Width="100%" AutoGenerateColumns="False">
								<SelectedItemStyle Font-Bold="True" ForeColor="#F7F7F7" BackColor="#738A9C"></SelectedItemStyle>
								<AlternatingItemStyle BackColor="#F7F7F7"></AlternatingItemStyle>
								<ItemStyle ForeColor="#4A3C8C" CssClass="GridItem" BackColor="#E7E7FF"></ItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="SUBJECTSLNO" HeaderText="SUBJECTSLNO"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="TOPICSLNO" HeaderText="TOPICSLNO"></asp:BoundColumn>
									<asp:BoundColumn DataField="TOPICNAME" HeaderText="Topics">
										<HeaderStyle Wrap="False"></HeaderStyle>
										<ItemStyle Wrap="False"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
							</asp:DataGrid>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Right" ForeColor="#4A3C8C" BackColor="#E7E7FF" CssClass="GridPager"
					Mode="NumericPages"></PagerStyle>
			</asp:datagrid><asp:datagrid id="Datagrid1" style="Z-INDEX: 101; LEFT: 32px; POSITION: absolute; TOP: 200px"
				tabIndex="11" runat="server" CssClass="GridMain" AllowSorting="True" CellPadding="0" BorderWidth="0px" AutoGenerateColumns="False"
				BorderStyle="None" PageSize="6" Width="456px" CellSpacing="2">
				<SelectedItemStyle Font-Bold="True"></SelectedItemStyle>
				<AlternatingItemStyle CssClass="GridAlternateItem"></AlternatingItemStyle>
				<ItemStyle CssClass="GridItem"></ItemStyle>
				<HeaderStyle Font-Bold="True" HorizontalAlign="Center" CssClass="GridHeader"></HeaderStyle>
				<Columns>
					<asp:TemplateColumn>
						<HeaderStyle Width="15px"></HeaderStyle>
						<HeaderTemplate>
							<asp:CheckBox id="chkAll" onclick="return ChecksOne();" runat="server" Width="20px"></asp:CheckBox>
						</HeaderTemplate>
						<ItemTemplate>
							<asp:CheckBox id="chkOne" onclick="return ChecksOne();" runat="server" Width="20px"></asp:CheckBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Sl.No">
						<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
						<ItemTemplate>
							<asp:Label id=Label00 runat="server" text='<%# DataBinder.Eval(Container,"DataSetIndex")+1 %>'>
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="SUBJECTSLNO" HeaderText="SUBJECTSLNO">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="SUBJECTNAME" HeaderText="Subject"></asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:LinkButton id="LbtnUnRead" runat="server" CommandName="LbtnUnRead">
								<%# DataBinder.Eval(Container, "DataItem.SUBJECTNAME") %>
							</asp:LinkButton>
							<asp:DataGrid id="DataGrid2" runat="server" Width="100%" AutoGenerateColumns="False" CssClass="GridMain">
								<ItemStyle CssClass="GridItem"></ItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="SUBJECTSLNO" HeaderText="SUBJECTSLNO"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="TOPICSLNO" HeaderText="TOPICSLNO"></asp:BoundColumn>
									<asp:BoundColumn DataField="TOPICNAME" HeaderText="Topics">
										<HeaderStyle Wrap="False"></HeaderStyle>
										<ItemStyle Wrap="False"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
							</asp:DataGrid>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" CssClass="GridPager" Mode="NumericPages"></PagerStyle>
			</asp:datagrid>&nbsp;
		</form>
	</body>
</HTML>
