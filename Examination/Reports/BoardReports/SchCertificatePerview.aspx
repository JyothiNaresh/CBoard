<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SchCertificatePerview.aspx.vb" Inherits="CollegeBoard.SchCertificatePerview" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>SchCertificatePerview</title>
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
							<asp:Label id="Label1" runat="server" CssClass="lables" Width="100%" Height="20">Name of the School</asp:Label></P>
						<P>
							<asp:Label id="Label2" runat="server" CssClass="lables" Width="100%" Height="20px">(Place and Address)</asp:Label></P>
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
						<asp:Label id="Label6" runat="server">Nationality and Religion</asp:Label></TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 15px"><STRONG>:</STRONG></TD>
					<TD align="left" height="30" class="lables">
						<asp:Label id="lblNationality" runat="server">Label</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center" height="30" class="lables">6</TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 316px">
						<P>
							<asp:Label id="Label7" runat="server" Width="100%" Height="20px">Whether the Candidate belongs to S.Cs or STs</asp:Label>
							<asp:Label id="Label8" runat="server" Height="20px">or BC or Vimukthajatis or other socially and </asp:Label>
							<asp:Label id="Label9" runat="server" Height="20px">Educationally backward classes specified in </asp:Label>
							<asp:Label id="Label10" runat="server" Height="20px" Width="328px">A.P.E.S.R.S or he/she a convert from the S.C or </asp:Label>
							<asp:Label id="Label11" runat="server">S.T if so the particulars thereof</asp:Label></P>
					</TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 15px"><STRONG>:</STRONG></TD>
					<TD align="left" height="30" class="lables">
						<asp:Label id="lblCaste" runat="server">Label</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center" height="60" class="lables">7</TD>
					<TD align="center" height="60" class="lables" style="WIDTH: 316px">
						<P>
							<asp:Label id="Label12" runat="server">Date of Birth (in words) as per College Records</asp:Label></P>
						<P align="left">
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
					<TD align="center" height="40" class="lables" style="HEIGHT: 40px">8a</TD>
					<TD align="center" height="40" class="lables" style="WIDTH: 316px; HEIGHT: 40px">Class 
						in which the pupil was reading at the time of leaving (in words)</TD>
					<TD align="center" height="40" style="WIDTH: 15px; HEIGHT: 40px" class="lables"><STRONG>:</STRONG></TD>
					<TD align="left" height="40" style="HEIGHT: 40px" class="lables">
						<asp:Label id="lblPoint8a" runat="server">Label</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center" height="30" class="lables">8b</TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 316px">First Language 
						Under Part I</TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 15px"><STRONG>:</STRONG></TD>
					<TD align="left" height="30" class="lables">
						<asp:Label id="lblPoint8b" runat="server">Label</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center" height="30" class="lables">8c</TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 316px">Second Language 
						Under Part II</TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 15px"><STRONG>:</STRONG></TD>
					<TD align="left" height="30" class="lables">
						<asp:Label id="lblPoint8c" runat="server">Label</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center" height="30" class="lables">8d</TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 316px">Optionals Under 
						Part III</TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 15px"><STRONG>:</STRONG></TD>
					<TD align="left" height="30" class="lables">
						<asp:Label id="lblPoint8d" runat="server">Label</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center" height="30" class="lables">9</TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 316px">Mother Tongue, 
						Medium of Instruction</TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 15px"><STRONG>:</STRONG></TD>
					<TD align="left" height="30" class="lables">
						<asp:Label id="lblMedium" runat="server">Label</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center" height="30" class="lables">10</TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 316px">Date of 
						Admission to 1st/2nd Year Intermediate</TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 15px"><STRONG>:</STRONG></TD>
					<TD align="left" height="30" class="lables">
						<asp:Label id="lblDoa" runat="server">Label</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center" height="60" class="lables" style="HEIGHT: 60px">11</TD>
					<TD align="center" height="60" class="lables" style="WIDTH: 316px; HEIGHT: 60px">
						<P>
							<asp:Label id="Label13" runat="server" Height="20px">Class and years in which the pupil was first </asp:Label>&nbsp;
							<asp:Label id="Label14" runat="server" Height="20px">Admitted into the Intermediate Course </asp:Label>
							<asp:Label id="Label15" runat="server">(1st year or 2nd year)</asp:Label></P>
					</TD>
					<TD align="center" height="60" class="lables" style="WIDTH: 15px; HEIGHT: 60px"><STRONG>:</STRONG></TD>
					<TD align="left" height="60" class="lables" style="HEIGHT: 60px">
						<asp:Label id="lblAdmyear" runat="server">Label</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center" height="30" class="lables">12</TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 316px">
						<asp:Label id="Label16" runat="server" Width="281px" Height="20px">Whether Qualified to study II year Class of </asp:Label>
						<asp:Label id="Label17" runat="server" Width="280px" Height="20px">Intermediate Course? (In case of students</asp:Label>
						<asp:Label id="Label18" runat="server" Width="272px" Height="20px">Leaving after completing 1st year class)</asp:Label></TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 15px"><STRONG>:</STRONG></TD>
					<TD align="left" height="30" class="lables">
						<asp:Label id="lblPoint12" runat="server">Label</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center" height="30" class="lables">13</TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 316px">
						<asp:Label id="Label19" runat="server" Height="20px">Whether the pupil has been declared eligible</asp:Label>
						<asp:Label id="Label20" runat="server" Height="20px">By the Board of Intermediate Education for</asp:Label>
						<asp:Label id="Label21" runat="server" Height="20px">University Course of Study</asp:Label></TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 15px"><STRONG class="lables">:</STRONG></TD>
					<TD align="left" height="30" class="lables">
						<asp:Label id="lblpoint13a" runat="server">Label</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center" height="30" class="lables">14a</TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 316px">
						<asp:Label id="Label24" runat="server" Height="20px">Whether the pupil was in receipt of any</asp:Label>
						<asp:Label id="Label23" runat="server" Height="20px">Scholarship? (Nature of the scholarship to be</asp:Label>
						<asp:Label id="Label22" runat="server" Height="20px">Specified)</asp:Label></TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 15px"><STRONG>:</STRONG></TD>
					<TD align="left" height="30" class="lables">
						<asp:Label id="lblPoint14a" runat="server">NONE</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center" height="30" class="lables">14b</TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 316px">
						<asp:Label id="Label27" runat="server" Height="20px">Whether the pupil was in receipt of any </asp:Label>
						<asp:Label id="Label26" runat="server" Height="20px">Concession (Nature of concession to be specified</asp:Label></TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 15px"><STRONG>:</STRONG></TD>
					<TD align="left" height="30" class="lables">
						<asp:Label id="lblPoint14b" runat="server">NONE</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center" height="60" class="lables">15</TD>
					<TD align="left" height="60" class="lables" style="WIDTH: 316px" vAlign="top">
						<P>
							<asp:Label id="Label25" runat="server" Height="20px">Personal Marks of Identification</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:Label id="Label28" runat="server">I)</asp:Label></P>
						<P>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
							&nbsp;
							<asp:Label id="Label29" runat="server">II)</asp:Label></P>
					</TD>
					<TD align="center" height="60" class="lables" style="WIDTH: 15px"><STRONG>:</STRONG></TD>
					<TD align="left" height="60" class="lables">
						<P class="lables">
							<asp:Label id="lblPoint15a" runat="server">Label</asp:Label></P>
						<P>
							<asp:Label id="lblPoint15b" runat="server">Label</asp:Label></P>
					</TD>
				</TR>
				<TR>
					<TD align="center" height="30" class="lables">16</TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 316px">
						<asp:Label id="Label30" runat="server" Height="20px">Date on which the pupil has actually left the College</asp:Label></TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 15px"><STRONG>:</STRONG></TD>
					<TD align="left" height="30" class="lables">
						<asp:Label id="lblPoint16" runat="server">Label</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center" height="30" class="lables">17</TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 316px">
						<asp:Label id="Label31" runat="server" Height="20px">Date of Transfer Certificate</asp:Label></TD>
					<TD align="center" height="30" class="lables" style="WIDTH: 15px"><STRONG>:</STRONG></TD>
					<TD align="left" height="30" class="lables">
						<asp:Label id="lblPoint17" runat="server">Label</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center" height="30" class="lables">18</TD>
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
