<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ModifyNodes.aspx.vb" Inherits="CollegeBoard.ModifyNodes" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>|| CreateNodes ||</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK id="Link1" href="../../Images/Login/StyleSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="0"
				cellPadding="1" width="100%" align="center" border="0">
				<TR>
					<TD vAlign="baseline" nowrap="nowrap" align="center">
						<TABLE id="Table1" style="WIDTH: 464px; HEIGHT: 271px" cellSpacing="1" cellPadding="1"
							width="464" border="1" align="center">
							<!--<TR>
								<TD>
									<asp:label id="Label1" runat="server" CssClass="Lables">ParentNode</asp:label></TD>
								<TD>
									<asp:textbox id="TextBox1" runat="server" CssClass="Textbox" ReadOnly="True"></asp:textbox></TD>
							</TR>-->
							<TR>
								<TD style="HEIGHT: 33px">
									<asp:label id="Label2" runat="server" CssClass="Lables" Width="100%">NodeDescription</asp:label></TD>
								<TD style="HEIGHT: 33px" vAlign="top" align="left" colSpan="1" rowSpan="1">
									<asp:textbox id="TextBox2" runat="server" CssClass=" "></asp:textbox>
									<asp:RequiredFieldValidator id="rfVDesc" runat="server" ControlToValidate="TextBox2" ErrorMessage="Should Not Empty"></asp:RequiredFieldValidator></TD>
							</TR>
							<TR>
								<TD vAlign="top" align="left">
									<asp:label id="Label3" runat="server" CssClass="Lables" Width="100%">NodeType</asp:label></TD>
								<TD vAlign="top" align="left">
									<asp:radiobuttonlist id="rbtType" runat="server" CssClass="Lables" AutoPostBack="True">
										<asp:ListItem Value="0" Selected="True">Parent</asp:ListItem>
										<asp:ListItem Value="1">Document</asp:ListItem>
									</asp:radiobuttonlist></TD>
							</TR>
							<TR>
								<TD vAlign="top" align="left" colSpan="1" rowSpan="1">
									<asp:panel id="Panel2" runat="server" Height="43px">
										<asp:label id="Label4" runat="server" CssClass="Lables" Width="100%">FileName</asp:label>
									</asp:panel></TD>
								<TD vAlign="top" align="left">
									<asp:panel id="Panel1" runat="server" Height="64px">
										<INPUT id="ftype" type="file" name="ftype" runat="server"></asp:panel></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD>
									<asp:ImageButton id="iBtnSave" accessKey="S" runat="server" ImageUrl="../../Images/NewImages/save.gif"
										CssClass="button" AlternateText="Save" Height="20px" Width="80px"></asp:ImageButton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
