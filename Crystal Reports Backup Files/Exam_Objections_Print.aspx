<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Exam_Objections_Print.aspx.vb" Inherits="CollegeBoard.Exam_Objections_Print"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Exam_Objections_Print</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK id="Link1" href="../../../Images/Login/StyleSheet_Report.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="1"
				cellPadding="1" width="100%" align="center" border="1">
				<TR>
					<TD align="center"><asp:label id="Label1" runat="server" CssClass="SUBHEADING1" Width="100%" Font-Size="Small">EXAM OBJECTIONS PRINT</asp:label></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="70%" align="center" border="1">
							<TR>
								<TD style="HEIGHT: 14px" align="center" width="7%"><asp:label id="Label2" runat="server" CssClass="Lables" Width="100%">Exam.Date</asp:label></TD>
								<TD style="HEIGHT: 14px" align="center" width="10%"><asp:dropdownlist id="DrpExamDate" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								<TD style="HEIGHT: 14px" align="center" width="7%"><asp:label id="Label4" runat="server" CssClass="Lables" Width="100%">Exam.Name</asp:label></TD>
								<TD style="HEIGHT: 14px" align="center" width="35%"><asp:dropdownlist id="DrpExam" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center"><asp:table id="Tblresult" runat="server"></asp:table></TD>
				</TR>
				<TR>
					<TD align="center"></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
