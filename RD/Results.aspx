<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Results.aspx.vb" Inherits="CollegeBoard.Results"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Results</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" type="text/javascript">
				var oshell 
				oshell = new ActiveXObject("WScript.shell");
					oshell.Run();			
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<INPUT id="FileUpload" style="Z-INDEX: 101; LEFT: 288px; POSITION: absolute; TOP: 43px"
				type="file" name="File1" runat="server">
			<asp:DataGrid id="DGFiles" style="Z-INDEX: 113; LEFT: 224px; POSITION: absolute; TOP: 400px" runat="server"></asp:DataGrid>
			<asp:button id="BtnPrint" style="Z-INDEX: 112; LEFT: 120px; POSITION: absolute; TOP: 384px"
				accessKey="p" runat="server" Text="Print"></asp:button>
			<TABLE id="Table2" style="Z-INDEX: 111; LEFT: 296px; POSITION: absolute; TOP: 288px" cellSpacing="1"
				cellPadding="1" width="300" border="1">
				<TR>
					<TD></TD>
					<TD vAlign="middle" align="center"><asp:placeholder id="PHTxtboxes" runat="server"></asp:placeholder></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD vAlign="middle" align="center"><asp:button id="AddingTextBox" runat="server" Text="Adding Text Boxes"></asp:button></TD>
					<TD></TD>
				</TR>
			</TABLE>
			<asp:button id="AddRows" style="Z-INDEX: 109; LEFT: 480px; POSITION: absolute; TOP: 224px" runat="server"
				Text="AddRow"></asp:button><asp:datagrid id="DataGrid1" style="Z-INDEX: 108; LEFT: 632px; POSITION: absolute; TOP: 24px"
				runat="server"></asp:datagrid><asp:table id="Table1" style="Z-INDEX: 107; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server"
				Width="64px"></asp:table><asp:button id="Button3" style="Z-INDEX: 106; LEFT: 256px; POSITION: absolute; TOP: 232px" runat="server"
				Text="Create Control"></asp:button><asp:textbox id="TextBox2" style="Z-INDEX: 105; LEFT: 368px; POSITION: absolute; TOP: 176px"
				runat="server"></asp:textbox><asp:textbox id="TextBox1" style="Z-INDEX: 104; LEFT: 144px; POSITION: absolute; TOP: 176px"
				runat="server"></asp:textbox><asp:button id="Button2" style="Z-INDEX: 103; LEFT: 289px; POSITION: absolute; TOP: 114px" runat="server"
				Text="Execute"></asp:button><asp:button id="Button1" style="Z-INDEX: 102; LEFT: 284px; POSITION: absolute; TOP: 78px" runat="server"
				Text="File Upload"></asp:button>&nbsp;
			<asp:panel id="Panel1" style="Z-INDEX: 110; LEFT: 24px; POSITION: absolute; TOP: 216px" runat="server"
				Width="168px" Height="88px">Panel</asp:panel>
		</form>
	</body>
</HTML>
