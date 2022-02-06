<%@ Page Language="vb" AutoEventWireup="false" Codebehind="NoticeDisplaySettings.aspx.vb" Inherits="CollegeBoard.NoticeDisplaySettings" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>FONTSCOLORS</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Styles/UseCaseStyle/StyleSheet_Report.css" type="text/css" rel="stylesheet">
		<script language="javascript" type="text/javascript">
	
	function dispClose()
	{
	
	window.close()
	
	}
	
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" style="Z-INDEX: 137; LEFT: 8px; WIDTH: 360px; POSITION: absolute; TOP: 8px; HEIGHT: 152px"
				cellSpacing="0" cellPadding="0" width="360" align="center" border="0">
				<TR>
					<TD align="center" colSpan="5" style="HEIGHT: 27px"><asp:label id="Label5" runat="server" Height="24px" Width="100%" Font-Bold="True" CssClass="Lables"
							BorderStyle="Solid" BorderWidth="1px">Rows Colors & Fonts</asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 91px"><asp:label id="Label1" runat="server" Height="24px" Width="100%" CssClass="Lables">Back Color</asp:label></TD>
					<TD style="WIDTH: 1px"><asp:dropdownlist id="rowBackColor" runat="server" Height="32px" Width="120px"></asp:dropdownlist></TD>
					<TD style="WIDTH: 49px"></TD>
					<TD style="WIDTH: 117px" align="center"><asp:label id="Label6" runat="server" Height="24px" Width="100%" CssClass="Lables">Font Family</asp:label></TD>
					<TD><asp:dropdownlist id="rowFontName" runat="server" Height="40px" Width="200px"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 91px; HEIGHT: 23px"><asp:label id="Label3" runat="server" Height="24px" Width="100%" CssClass="Lables">Fore Color</asp:label></TD>
					<TD style="WIDTH: 1px; HEIGHT: 23px"><asp:dropdownlist id="rowForeColor" runat="server" Height="40px" Width="120px"></asp:dropdownlist></TD>
					<TD style="WIDTH: 49px; HEIGHT: 23px"></TD>
					<TD style="WIDTH: 117px; HEIGHT: 23px"><asp:label id="Label7" runat="server" Height="24px" Width="100%" CssClass="Lables">Font Size</asp:label></TD>
					<TD style="HEIGHT: 23px">&nbsp;
						<asp:dropdownlist id="DrpFontSizeRow" runat="server" Height="16px" Width="64px"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 91px"></TD>
					<TD style="WIDTH: 1px"></TD>
					<TD style="WIDTH: 49px"></TD>
					<TD style="WIDTH: 117px"></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 281px" colSpan="2"><asp:table id="Table1" runat="server" Height="149px" Width="264px" BackColor="#FF8000" BorderStyle="Solid"
							CellSpacing="0" CellPadding="2">
							<asp:TableRow>
								<asp:TableCell BackColor="DarkOrange" ForeColor="Blue" Font-Size="Medium" HorizontalAlign="Center"
									Text="Notice Board"></asp:TableCell>
							</asp:TableRow>
							<asp:TableRow ForeColor="White" BackColor="#0000C0">
								<asp:TableCell Text="First Row"></asp:TableCell>
							</asp:TableRow>
							<asp:TableRow ForeColor="White" BackColor="#0000C0">
								<asp:TableCell Text="Second Roe"></asp:TableCell>
							</asp:TableRow>
							<asp:TableRow ForeColor="White" BackColor="#0000C0">
								<asp:TableCell ForeColor="GhostWhite" Font-Bold="True" Text="Third Row.."></asp:TableCell>
							</asp:TableRow>
						</asp:table></TD>
					<TD style="WIDTH: 49px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
						&nbsp;&nbsp;
					</TD>
					<TD vAlign="top" align="center" colSpan="2" rowSpan="1">
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="300" border="1" style="WIDTH: 300px; HEIGHT: 32px"
							borderColor="#cc9933">
							<TR>
								<TD style="WIDTH: 81px; HEIGHT: 2px" colSpan="4" vAlign="top"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 81px; HEIGHT: 12px">
									<asp:RadioButton id="rbHand" runat="server" Height="16px" Width="104px" Text="Hand" GroupName="gP"
										CssClass="Lables"></asp:RadioButton></TD>
								<TD style="WIDTH: 59px; HEIGHT: 12px">
									<asp:Image id="Image1" runat="server" Height="16px" Width="40px" ImageUrl="../../Images/hand.gif"></asp:Image></TD>
								<TD style="HEIGHT: 12px">
									<asp:RadioButton id="rbNew" runat="server" Height="16px" Width="100%" Text="new" GroupName="gA" CssClass="Lables"></asp:RadioButton></TD>
								<TD style="HEIGHT: 12px">
									<asp:Image id="Image4" runat="server" Height="16px" Width="32px" ImageUrl="../../Images/ExaminatinImages/new_alert.gif"></asp:Image></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 81px; HEIGHT: 24px">
									<asp:RadioButton id="rbRight" runat="server" Height="24px" Width="104px" Text="Right" GroupName="gP"
										Checked="True" CssClass="Lables"></asp:RadioButton></TD>
								<TD style="WIDTH: 59px; HEIGHT: 24px">
									<asp:Image id="Image2" runat="server" Height="24px" Width="32px" ImageUrl="../../Images/noticeArrow.gif"></asp:Image></TD>
								<TD style="HEIGHT: 24px">
									<asp:RadioButton id="rbAlert" runat="server" Height="24px" Width="100%" Text="alert" GroupName="gA"
										CssClass="Lables"></asp:RadioButton></TD>
								<TD style="HEIGHT: 24px">
									<asp:Image id="Image5" runat="server" Height="16px" Width="31px"></asp:Image></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 81px; HEIGHT: 1px">
									<asp:RadioButton id="rbMesg" runat="server" Height="24px" Width="100%" Text="Message" GroupName="gP"
										CssClass="Lables"></asp:RadioButton></TD>
								<TD style="WIDTH: 59px; HEIGHT: 1px">
									<asp:Image id="rbMessage" runat="server" Height="24px" Width="32px" ImageUrl="../../Images/ExaminatinImages/msg.GIF"></asp:Image></TD>
								<TD style="HEIGHT: 1px">
									<asp:RadioButton id="rbNone" runat="server" Height="24px" Width="100%" Text="None" GroupName="gA"
										Checked="True" CssClass="Lables"></asp:RadioButton></TD>
								<TD style="HEIGHT: 1px"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 81px; HEIGHT: 17px"></TD>
								<TD style="WIDTH: 59px; HEIGHT: 17px"></TD>
								<TD style="HEIGHT: 17px"></TD>
								<TD style="HEIGHT: 17px"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 281px" colSpan="2">
						<P><FONT size="3"></FONT>&nbsp;</P>
					</TD>
					<TD style="WIDTH: 49px"></TD>
					<TD vAlign="top" align="center" colSpan="2"></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 281px" align="center" colSpan="2">
						<asp:button id="Button1" runat="server" Height="32px" Width="120px" Text="Preview" Font-Bold="True"></asp:button></TD>
					<TD style="WIDTH: 49px"></TD>
					<TD align="center" colSpan="2">
						<asp:button id="Button2" runat="server" Height="30px" Width="120px" Text="Apply Changes" Font-Bold="True"></asp:button>&nbsp;&nbsp;
						<asp:Button id="Button3" runat="server" Height="31px" Width="92px" Font-Bold="True" Text="Set Defaults"></asp:Button>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
