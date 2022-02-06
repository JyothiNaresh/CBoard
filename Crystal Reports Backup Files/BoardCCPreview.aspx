<%@ Page Language="vb" AutoEventWireup="false" Codebehind="BoardCCPreview.aspx.vb" Inherits="CollegeBoard.BoardCCPreview" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>BoardCCPreview</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK id="Link1" href="../../../Images/Login/StyleSheet.css" type="text/css" rel="stylesheet">
		<script type="text/javascript">
		function GoBackToPreviousPage () {           
			  parent.history.back();
			  return false;
				}
		
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="1" cellSpacing="1" cellPadding="1" width="582" align="center"
				height="535">
				<TR>
					<TD class="subheading1" height="30" width="108" colSpan="4" align="right">
						<asp:Table id="TableBack" runat="server" align="center" Width="560px"></asp:Table></TD>
				</TR>
				<TR>
					<TD height="50" width="348" colSpan="2" align="center" class="subheading1">RC No :
						<asp:Label id="lblRcno" runat="server">Label</asp:Label></TD>
					<TD height="50" width="45%" colSpan="2" align="center" class="subheading1">Adm.No :
						<asp:Label id="LblAdmno" runat="server" style="Z-INDEX: 0">Label</asp:Label></TD>
				</TR>
				<TR>
					<TD height="100" width="5%" align="center" class="lables">1</TD>
					<TD height="100" width="316" align="left" vAlign="top" class="lables">
						<P align="left">
							<asp:Label id="Label1" runat="server" CssClass="lables" Width="100%" Height="20">Name of the College</asp:Label></P>
						<P>
							<asp:Label id="Label2" runat="server" CssClass="lables" Width="100%" Height="20px">(Place and District)</asp:Label></P>
					</TD>
					<TD height="100" width="15" align="center" class="lables"><STRONG>:</STRONG></TD>
					<TD height="100" width="45%" align="left" class="lables">
						<P>
							<asp:Label id="lblClgNameCode" runat="server" Font-Bold="True">Label</asp:Label></P>
						<P>
							<asp:Label id="lblClgAddress1" runat="server" Font-Bold="True">Label</asp:Label></P>
						<P>
							<asp:Label id="lblClgAddress2" runat="server" Font-Bold="True">Label</asp:Label></P>
					</TD>
				</TR>
				<TR>
					<TD align="center" height="30" class="lables">2</TD>
					<TD align="left" height="30" class="lables" width="316">
						<asp:Label id="Label3" runat="server">Name of the Student</asp:Label></TD>
					<TD align="center" height="30" class="lables" width="15"><STRONG>:</STRONG></TD>
					<TD align="left" height="30" class="lables">
						<asp:Label id="lblStuName" runat="server">Label</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center" height="30" class="lables">3</TD>
					<TD align="center" height="30" class="lables" width="316">
						<asp:Label id="Label4" runat="server">Name of the Father</asp:Label></TD>
					<TD align="center" height="30" class="lables" width="15"><STRONG>:</STRONG></TD>
					<TD align="left" height="30" class="lables">
						<asp:Label id="lblStuFname" runat="server">Label</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center" height="30" class="lables">4</TD>
					<TD align="center" height="30" class="lables" width="316">
						<asp:Label id="Label5" runat="server">Studying in</asp:Label></TD>
					<TD align="center" height="30" class="lables" width="15"><STRONG>:</STRONG></TD>
					<TD align="left" height="30" class="lables">
						<asp:Label id="lblStydin" runat="server">Label</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center" height="30" class="lables">5</TD>
					<TD align="center" height="30" class="lables" width="316">
						<asp:Label id="Label6" runat="server">Group</asp:Label></TD>
					<TD align="center" height="30" class="lables" width="15"><STRONG>:</STRONG></TD>
					<TD align="left" height="30" class="lables">
						<asp:Label id="lblGroup" runat="server">Label</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center" height="40" class="lables">6</TD>
					<TD align="center" height="40" class="lables" width="316">Medium</TD>
					<TD align="center" height="40" class="lables" width="15"><STRONG>:</STRONG></TD>
					<TD align="left" height="40" class="lables">
						<asp:Label id="lblMedium" runat="server">Label</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center" height="30" class="lables">7</TD>
					<TD align="center" height="30" class="lables" width="316">Academic Year From</TD>
					<TD align="center" height="30" class="lables" width="15"><STRONG>:</STRONG></TD>
					<TD align="left" height="30" class="lables">
						<asp:Label id="lblAcdFrom" runat="server">Label</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center" height="30" class="lables">8</TD>
					<TD align="center" height="30" class="lables" width="316">Academic Year To</TD>
					<TD align="center" height="30" class="lables" width="15"><STRONG>:</STRONG></TD>
					<TD align="left" height="30" class="lables">
						<asp:Label id="lblAcdTo" runat="server">Label</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center" height="30" class="lables">9</TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 316px">
						<asp:Label id="Label32" runat="server" Height="20px">Conduct</asp:Label></TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 15px"><STRONG>:</STRONG></TD>
					<TD align="left" height="30" class="lables">
						<asp:Label id="lblConduct" runat="server">GOOD</asp:Label></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
