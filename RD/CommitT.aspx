<%@ Page Language="vb" AutoEventWireup="false" Codebehind="CommitT.aspx.vb" Inherits="CollegeBoard.CommitT" Transaction="RequiresNew"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>CommitT</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Button id="iBtnGo" style="Z-INDEX: 101; LEFT: 368px; POSITION: absolute; TOP: 216px" runat="server"
				Text="Go" Width="64px"></asp:Button>
			<asp:RegularExpressionValidator id="RegularExpressionValidator1" style="Z-INDEX: 103; LEFT: 512px; POSITION: absolute; TOP: 72px"
				runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="TextBox1" Display="Dynamic"></asp:RegularExpressionValidator>
			<asp:TextBox id="TextBox1" style="Z-INDEX: 102; LEFT: 344px; POSITION: absolute; TOP: 72px" runat="server"></asp:TextBox>
		</form>
	</body>
</HTML>
