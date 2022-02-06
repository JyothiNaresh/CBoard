<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SchoolCCGeneratenew.aspx.vb" Inherits="CollegeBoard.SchoolCCGeneratenew"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HEAD>
	<title>SchBoardTCReport</title>
	<meta content="False" name="vs_snapToGrid">
	<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
	<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
	<meta content="JavaScript" name="vs_defaultClientScript">
	<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	<LINK id="Link1" href="../../../Images/Login/StyleSheet.css" type="text/css" rel="stylesheet">
</HEAD>
<body MS_POSITIONING="GridLayout">
	<form id="Form1" method="post" runat="server">
		<TABLE id="Table7" style="Z-INDEX: 104; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="0"
			cellPadding="1" width="100%" border="0">
			<TR>
				<TD align="center">
					<TABLE id="Table4" style="HEIGHT: 284px" cellSpacing="1" cellPadding="1" width="600" border="1"
						runat="server">
						<TR>
							<TD align="center" colSpan="2"><asp:label id="Label1" runat="server" Width="100%" CssClass="SubHeading1">STUDY AND CONDUCT CERTIFICATE</asp:label></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 479px" width="479"><asp:label id="Label13" runat="server" Width="100%" CssClass="Lables" Height="15px">Admno:</asp:label></TD>
							<TD width="40%"><asp:label id="LblAmdno" runat="server" Width="100%" CssClass="Lables">Label</asp:label></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 479px" width="479"><asp:label id="Label14" runat="server" Width="100%" CssClass="Lables" Height="15px">Student Name:</asp:label></TD>
							<TD><asp:label id="LblStuname" runat="server" Width="100%" CssClass="Lables" Height="15px">Label</asp:label></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 479px" width="479"><asp:label id="Label4" runat="server" Width="100%" CssClass="Lables" Height="15px"> FatherName:</asp:label></TD>
							<TD><asp:label id="lBLFname" runat="server" Width="100%" CssClass="Lables" Height="15px">Label</asp:label></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 479px" width="479"><asp:label id="Label3" runat="server" Width="100%" CssClass="Lables" Height="15px"> Student Studying When Leaving School:</asp:label></TD>
							<TD width="20%">
								<P><asp:dropdownlist id="DrpCourseLeav" runat="server" Width="100%" CssClass=" "></asp:dropdownlist></P>
							</TD>
						</TR>
						<TR>
							<TD style="WIDTH: 479px" width="479"><asp:label id="Label5" runat="server" Width="100%" CssClass="Lables" Height="15px">Which Class Student Joined In the School:</asp:label></TD>
							<TD><asp:dropdownlist id="Drpjoinedfrm" runat="server" Width="100%" CssClass=" "></asp:dropdownlist></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 479px" width="479"><asp:label id="Label6" runat="server" Width="100%" CssClass="Lables" Height="15px">Year on which the Pupil Joined School:</asp:label></TD>
							<TD><asp:textbox id="txtfrm" runat="server" Width="110px" Tooltip="YYYY"></asp:textbox></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 479px" width="479"><asp:label id="Label17" runat="server" Width="100%" CssClass="Lables" Height="15px">Date on which the pupil has actually left the College :</asp:label></TD>
							<TD><asp:textbox id="TxtDateleaving" runat="server" Width="110px" Tooltip="YYYY"></asp:textbox></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 768px" width="768" colSpan="2"><asp:dropdownlist id="DrpBoardCollege" runat="server" Width="100%" CssClass=" " AutoPostBack="True"></asp:dropdownlist></TD>
						</TR>
						<TR>
							<TD align="right" colSpan="2"><asp:button id="BtnPreview" runat="server" Height="24px" Font-Bold="True" Font-Size="Larger"
									Text="Priview"></asp:button><asp:button id="btnGenerate" runat="server" Height="24px" Font-Bold="True" Font-Size="Larger"
									Text="Generate"></asp:button><asp:dropdownlist id="DrpQualifiedUniv" runat="server" Width="0px" CssClass=" ">
									<asp:ListItem Value="0" Selected="True">NONE</asp:ListItem>
									<asp:ListItem Value="1">YES</asp:ListItem>
									<asp:ListItem Value="2">NO</asp:ListItem>
								</asp:dropdownlist></TD>
						</TR>
					</TABLE>
					<P align="center"></P>
					<P>&nbsp;</P>
					<P></P>
				</TD>
			</TR>
			<TR>
			</TR>
		</TABLE>
	</form>
</body>
