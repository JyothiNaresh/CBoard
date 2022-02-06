<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PFDetails.aspx.vb" Inherits="CollegeBoard.PFDetails" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>PFDetails</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK id="Link1" rel="stylesheet" type="text/css" href="../../../Images/Login/StyleSheet_Report.css">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" width="100%" align="center">
				<TR>
					<TD align="center"><asp:datagrid id="DgDetails" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="GridMain"
							Font-Size="X-Small">
							<ItemStyle Height="20px"></ItemStyle>
							<HeaderStyle Height="25px" CssClass="GRIDHEADER"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="SNO">
									<HeaderStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
									<ItemTemplate>
										<%#Container.DataSetIndex+1 %>
									</ItemTemplate>
									<FooterStyle Wrap="False"></FooterStyle>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE style="WIDTH: 597px; HEIGHT: 120px" id="Table2" class="gridmain" border="0" cellSpacing="1"
							cellPadding="1" width="597" bgColor="#cc9966" align="center" runat="server">
							<TR>
								<TD height="25" colSpan="2" align="center"><asp:label id="Label3" runat="server" Width="100%" Font-Bold="True" ForeColor="Red">Any Clarification About Strength Contact Below Numbers [Only Deans]</asp:label></TD>
							</TR>
							<TR>
								<TD height="25" align="center"><asp:label id="Label1" runat="server" Font-Bold="True">Hyderabad Only</asp:label></TD>
								<TD height="25" align="center"><asp:label id="Label4" runat="server" Font-Bold="True">Nanda Gopal Garu : +919912343319</asp:label></TD>
							</TR>
							<TR>
								<TD height="25" align="center"><asp:label id="Label2" runat="server" Font-Bold="True">Coastal & Non-AP</asp:label></TD>
								<TD height="25" align="center"><asp:label id="Label5" runat="server" Font-Bold="True">Murali Krishna Garu  : +919912348687</asp:label></TD>
							</TR>
							<TR>
								<TD height="25" align="center"><asp:label id="Label6" runat="server" Font-Bold="True">RayalaSeema, Guntur, Prakasam & Nellore</asp:label></TD>
								<TD height="25" align="center"><asp:label id="Label7" runat="server" Font-Bold="True">Ramesh Garu  : +919912349777</asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
