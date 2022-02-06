<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Objection_FinalKey.aspx.vb" Inherits="CollegeBoard.Objection_FinalKey"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Objection_FinalKey</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK id="Link1" href="../../../Images/Login/StyleSheet_Report.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="1"
				cellPadding="1" width="100%" align="center" border="1" borderColor="#ff9966">
				<TR>
					<TD align="center">
						<asp:Label id="Label1" runat="server" CssClass="SUBHEADING1" Width="100%" Font-Size="Small">FINAL KEY CORRECTIONS</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="500" align="center" border="1"
							bgColor="#cc9966">
							<TR>
								<TD align="center" width="15%">
									<asp:Label id="Label2" runat="server" CssClass="lables" Width="100%">ExamName</asp:Label></TD>
								<TD align="center" width="30%">
									<asp:DropDownList id="DrpExamName" runat="server" Width="100%" AutoPostBack="True"></asp:DropDownList></TD>
								<TD align="center" width="15%">
									<asp:Label id="Label3" runat="server" CssClass="lables" Width="100%">ExamDate</asp:Label></TD>
								<TD align="center" width="30%">
									<asp:DropDownList id="DrpExamDate" runat="server" Width="100%" AutoPostBack="True"></asp:DropDownList></TD>
								<TD align="center" width="10%">
									<asp:ImageButton id="IbtnGo" runat="server" ImageUrl="../../../Images/NewImages/go.gif" Height="20px"></asp:ImageButton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<asp:Label id="LblPs" runat="server" CssClass="Gridmain" Width="100%" ForeColor="Blue" Font-Bold="True"></asp:Label></TD>
				</TR>
				<TR>
					<TD align="center">
						<asp:DataGrid id="dgFinal" runat="server" CssClass="GRIDmain" AutoGenerateColumns="False" BorderColor="#FF8000">
							<ItemStyle Height="22px"></ItemStyle>
							<HeaderStyle Height="25px" CssClass="GRIDHEADER"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="SNO">
									<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
									<ItemTemplate>
										<%#Container.DataSetIndex+1%>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="SBJNAME" HeaderText="SUBJECT">
									<HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="OBJQUESTIONNO" HeaderText="Q.NO">
									<HeaderStyle HorizontalAlign="Center" Width="10px" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="OBJGIVENKEY" HeaderText="GIVEN.KEY">
									<HeaderStyle HorizontalAlign="Center" Width="20px" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="OBJCOUNT" HeaderText="OBJECTIONS">
									<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="USERNAME" HeaderText="FINALIZED.BY">
									<HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="OBJACTION" HeaderText="ACTION">
									<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="OBJFINALKEY" HeaderText="FINALKEY">
									<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="Red" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="OBJREMARKS" HeaderText="REMARKS">
									<HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
						</asp:DataGrid></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
