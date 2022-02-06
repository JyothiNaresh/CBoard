<%@ Register TagPrefix="uc1" TagName="ExamsStudentInfoSelection" Src="ExamsStudentInfoSelection.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="DropdownCheckList.aspx.vb" Inherits="CollegeBoard.DropdownCheckList" %>
<%@ Register TagPrefix="uc1" TagName="CombinationSelectionInfo" Src="CombinationSelectionInfo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ReportMainSelection" Src="ReportMainSelection.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>DropdownCheckList</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../../Images/Login/StyleSheet_Report.css">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table border="0" cellSpacing="0" cellPadding="0" align="center" width="820">
				<TR>
					<TD>
						<uc1:ExamsStudentInfoSelection id="ExamsStudentInfoSelection1" runat="server"></uc1:ExamsStudentInfoSelection></TD>
				</TR>
			</table>
		</form>
	</body>
</HTML>
