<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="BoardTCCBSEPreview.aspx.vb" Inherits="CollegeBoard.BoardTCCBSEPreview" %>

!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
		<title>BoardTCPreview</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK id="Link1" href="../../../Images/Login/StyleSheet.css" type="text/css" rel="stylesheet">
  </HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE style="Z-INDEX: 101; LEFT: 8px; WIDTH: 742px; POSITION: absolute; TOP: 8px; HEIGHT: 1079px"
				id="Table1" border="1" cellSpacing="1" cellPadding="1" width="742" align="center">
				<TR>
					<TD height="50" width="348" colSpan="2" align="center" class="subheading1" style="WIDTH: 348px">TC 
						No :
						<asp:Label id="lblTcno" runat="server">Label</asp:Label>
						&nbsp;/&nbsp;
						<asp:Label id="lblRcno" runat="server">Label</asp:Label></TD>
					<TD height="50" width="45%" colSpan="2" align="center" class="subheading1">Adm.No :
						<asp:Label id="LblAdmno" runat="server">Label</asp:Label></TD>
				</TR>
				<TR>
					<TD height="100" width="5%" align="center" class="lables">1</TD>
					<TD height="100" width="316" align="left" vAlign="top" class="lables" style="WIDTH: 316px">
						<P align="left">
							<asp:Label id="Label1" runat="server" CssClass="lables" Width="100%" Height="20">Name of the College</asp:Label></P>
						<P>
							<asp:Label id="Label2" runat="server" CssClass="lables" Width="100%" Height="20px">(Place and District)</asp:Label></P>
					</TD>
					<TD height="100" width="15" align="center" class="lables" style="WIDTH: 15px"><STRONG>:</STRONG></TD>
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
					<TD align="left" height="30" class="lables" style="WIDTH: 316px">
						<asp:Label id="Label3" runat="server">Name of the Pupil</asp:Label></TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 15px"><STRONG>:</STRONG></TD>
					<TD align="left" height="30" class="lables">
						<asp:Label id="lblStuName" runat="server">Label</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center" height="30" class="lables">3</TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 316px">
						<asp:Label id="Label4" runat="server">Name of the Father</asp:Label></TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 15px"><STRONG>:</STRONG></TD>
					<TD align="left" height="30" class="lables">
						<asp:Label id="lblStuFname" runat="server">Label</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center" height="30" class="lables">4</TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 316px">
						<asp:Label id="Label5" runat="server">Name of the Mother</asp:Label></TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 15px"><STRONG>:</STRONG></TD>
					<TD align="left" height="30" class="lables">
						<asp:Label id="lblStuMname" runat="server">Label</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center" height="30" class="lables">5</TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 316px">
						<asp:Label id="Label6" runat="server">Nationality, Religion & Mother Tongue</asp:Label></TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 15px"><STRONG>:</STRONG></TD>
					<TD align="left" height="30" class="lables">
						<asp:Label id="lblNationality" runat="server">Label</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center" height="30" class="lables">6</TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 316px">
						<P>
							<asp:Label id="Label7" runat="server" Width="100%" Height="20px">Wheather Candidate belongs to</asp:Label>
							<asp:Label id="Label8" runat="server" Height="20px">OC, BC, SC & ST</asp:Label>
						
							
					</TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 15px"><STRONG>:</STRONG></TD>
					<TD align="left" height="30" class="lables">
						<asp:Label id="lblCaste" runat="server">Label</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center" height="60" class="lables">7</TD>
					<TD align="center" height="60" class="lables" style="WIDTH: 316px">
						<P>
							<asp:Label id="Label12" runat="server">Date of Birth (In words) as entered in the</asp:Label></P>
						<P align="left">
                            Admission Register
						</P>
					</TD>
					<TD align="center" height="60" class="lables" style="WIDTH: 15px"><STRONG>:</STRONG></TD>
					<TD align="left" height="60" class="lables">
						<P>
							<asp:Label id="lblDob" runat="server">Label</asp:Label></P>
						<P>
							<asp:Label id="lblDobwords" runat="server">Label</asp:Label></P>
					</TD>
				</TR>
				
				<TR>
					<TD align="center" height="30" class="lables">8</TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 316px">Date of admission and class to which Admitted</TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 15px"><STRONG>:</STRONG></TD>
					<TD align="left" height="30" class="lables">
						<asp:Label id="lblPoint8b" runat="server">Label</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center" height="30" class="lables">9</TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 316px">Class in which the pupil last studied</TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 15px"><STRONG>:</STRONG></TD>
					<TD align="left" height="30" class="lables">
						<asp:Label id="lblPoint8c" runat="server">12th Class (10+2 Class)</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center" height="30" class="lables">10</TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 316px">Subjects Studied</TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 15px"><STRONG>:</STRONG></TD>
					<TD align="left" height="30" class="lables">
						<asp:Label id="lblPoint8d" runat="server">Label</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center" height="30" class="lables">11</TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 316px">Date on which the pupil actually left the school</TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 15px"><STRONG>:</STRONG></TD>
					<TD align="left" height="30" class="lables">
						<asp:Label id="lblMedium" runat="server">Label</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center" height="30" class="lables">12</TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 316px">Promotions to Higher Classses</TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 15px"><STRONG>:</STRONG></TD>
					<TD align="left" height="30" class="lables">
						<asp:Label id="lblDoa" runat="server">YES</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center" height="60" class="lables" style="HEIGHT: 60px">13</TD>
					<TD align="center" height="60" class="lables" style="WIDTH: 316px; HEIGHT: 60px">
						<P>
							<asp:Label id="Label13" runat="server" Height="20px">Date of Application for the T.C. </asp:Label>
							</P>
					</TD>
					<TD align="center" height="60" class="lables" style="WIDTH: 15px; HEIGHT: 60px"><STRONG>:</STRONG></TD>
					<TD align="left" height="60" class="lables" style="HEIGHT: 60px">
						<asp:Label id="lblAdmyear" runat="server">Label</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center" height="30" class="lables">14</TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 316px">
						<asp:Label id="Label16" runat="server" Width="281px" Height="20px">Reason for leaving</asp:Label>
						
						
					<TD align="center" height="30" class="lables" style="WIDTH: 15px"><STRONG>:</STRONG></TD>
					<TD align="left" height="30" class="lables">
						<asp:Label id="lblPoint12" runat="server">PROMOTED</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center" height="30" class="lables">15</TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 316px">
						<asp:Label id="Label19" runat="server" Height="20px">Attendance of the pupil</asp:Label>
						</TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 15px"><STRONG class="lables">:</STRONG></TD>
					<TD align="left" height="30" class="lables">
						<asp:Label id="lblpoint13a" runat="server">Label</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center" height="30" class="lables">16</TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 316px">
						<asp:Label id="Label24" runat="server" Height="20px">Total No. of Working days</asp:Label>
						</TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 15px"><STRONG>:</STRONG></TD>
					<TD align="left" height="30" class="lables">
						<asp:Label id="lblPoint14a" runat="server">Label</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center" height="30" class="lables">17</TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 316px">
						<asp:Label id="Label27" runat="server" Height="20px">Wheather the people has paid all the dues to the school</asp:Label>
						</TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 15px"><STRONG>:</STRONG></TD>
					<TD align="left" height="30" class="lables">
						<asp:Label id="lblPoint14b" runat="server">YES</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center" height="60" class="lables" valign="top">18</TD>
					<TD align="left" height="60" class="lables" style="WIDTH: 316px" vAlign="top">
						
							<asp:Label id="Label25" runat="server" Height="20px">Whether NCC Candidate</asp:Label>
							
					</TD>
					<TD align="center" height="60" class="lables" style="WIDTH: 15px" vAlign="top"><STRONG>:</STRONG></TD>
					<TD align="left" height="60" class="lables" style="WIDTH: 316px" vAlign="top">
						
							<asp:Label id="lblPoint15a" runat="server">Label</asp:Label>
						
					</TD>
				</TR>
				<TR>
					<TD align="center" height="30" class="lables">19</TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 316px">
						<asp:Label id="Label30" runat="server" Height="20px">Games Played</asp:Label></TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 15px"><STRONG>:</STRONG></TD>
					<TD align="left" height="30" class="lables">
						<asp:Label id="lblPoint16" runat="server">Label</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center" height="30" class="lables">20</TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 316px">
						<asp:Label id="Label31" runat="server" Height="20px">Date of Issue of Transfer Certificate</asp:Label></TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 15px"><STRONG>:</STRONG></TD>
					<TD align="left" height="30" class="lables">
						<asp:Label id="lblPoint17" runat="server">Label</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center" height="30" class="lables">21</TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 316px">
						<asp:Label id="Label32" runat="server" Height="20px">Conduct</asp:Label></TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 15px"><STRONG>:</STRONG></TD>
					<TD align="left" height="30" class="lables">
						<asp:Label id="lblPoint18" runat="server">GOOD</asp:Label></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
