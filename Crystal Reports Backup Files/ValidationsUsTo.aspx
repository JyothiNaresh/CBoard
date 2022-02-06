<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ValidationsUsTo.aspx.vb" Inherits="CollegeBoard.ValidationsUsTo"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>ValidationsUsTo</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script id="clientEventHandlersJS" src="../Include/ValidationUserTo.js" type="text/javascript"> 		</script>
		<Link href="../../Images/Login/StyleSheet.css" rel="stylesheet" type="text/css">
	</HEAD>
	<body onload="javascript:btnGo_onClick()" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 104; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="0"
				cellPadding="0" width="100%" border="0">
				<TR>
					<TD vAlign="top" align="center">
						<TABLE class="TableBorder" id="Table4" cellSpacing="0" cellPadding="0" width="300" border="1">
							<TR>
								<TD>
									<TABLE id="Table3" style="WIDTH: 347px; HEIGHT: 72px" cellSpacing="3" cellPadding="0" width="347"
										border="0">
										<TR>
											<TD>
												<asp:label id="Label5" runat="server" CssClass="Lables" Width="100%">User&nbsp;Id&nbsp;*</asp:label></TD>
											<TD>
												<asp:label id="LblDisUserId" runat="server" CssClass="Lables" Width="100%"></asp:label></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 17px"></TD>
											<TD style="HEIGHT: 17px"></TD>
										</TR>
										<TR>
											<TD vAlign="top" align="center" colSpan="2">
												<asp:Button id="BtnRegistr" accessKey="R" runat="server" Width="174px" Text="Click here To Register"></asp:Button></TD>
										</TR>
										<TR>
											<TD vAlign="top" align="center" colSpan="2">
												<asp:label id="Label1" runat="server" CssClass="Lables" Width="100%">Without&nbsp;User&nbsp;Registration&nbsp;Your&nbsp;User&nbsp;will&nbsp;not&nbsp;be&nbsp;Accessed</asp:label></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="300" border="0">
							<TR>
								<TD><asp:textbox id="Txt1" runat="server" Width="0px" Height="0px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD><asp:textbox id="Txt2" runat="server" Width="0px" Height="0px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD><asp:textbox id="Txt3" runat="server" Width="0px" Height="0px"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
