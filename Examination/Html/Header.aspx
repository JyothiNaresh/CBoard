<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Header.aspx.vb" Inherits="CollegeBoard.Header" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Header</title>
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="VisualStudio.HTML" name="ProgId">
		<meta content="Microsoft Visual Studio .NET 7.1" name="Originator">
		<LINK href="../../Images/Login/StyleSheet_Report.css" type="text/css" rel="stylesheet">
		<script language="javascript" type="text/javascript">
		
		function fnHideShow(){
			if(spnHideShow.innerText=='' || spnHideShow.innerText=='Show'){
				parent.inner.cols='215,*';
				spnHideShow.innerText='Hide';
				
				
			}
			else if(spnHideShow.innerText=='Hide'){	
				parent.inner.cols='0,*';
				spnHideShow.innerText='Show';
			}
		}
		
		function GetCocPage() 
		{
		parent.frames['right'].location='../Central Office Communication/Reports/CocDetailsReport.aspx';
		}
		
		</script>
	</HEAD>
	<body class="DarkColor" bgColor="#003399" onload="fnHideShow()" MS_POSITIONING="GridLayout">
		<table id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
			<tr>
				<td>
					<table id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
						<tr>
							<td height="50"><IMG height="50" src="../../Images/Login/logo.jpg" width="163"></td>
							<td width="372"><asp:label id="Label1" Font-Bold="True" ForeColor="White" Height="20px" Font-Size="Medium"
									Width="538px" runat="server"></asp:label></td>
							<td style="WIDTH: 150px"><A id="A4" href="javascript:GetCocPage();"><FONT face="verdana" color="blue" size="1"><b><span id="Span2">Central 
												Office Helpline</span></b></FONT></A></td>
							<TD style="WIDTH: 59px" width="59"></TD>
							<TD style="WIDTH: 59px" width="59"><A id="A3" href="../Html/Content.aspx" target="_parent"><FONT face="verdana" color="white" size="2"><b><span id="Span1">Home</span></b></FONT></A></TD>
							<TD style="WIDTH: 59px" width="59"></TD>
							<td style="WIDTH: 59px" width="59"><A id="A1" href="javascript:fnHideShow();"><FONT face="verdana" color="white" size="2"><b><span id="spnHideShow"></span></b></FONT></A></td>
							<td align="right"><A id="A2" href="../../Home.aspx" target="_parent"><FONT face="verdana" color="white" size="2"><b><span id="spnLogout">Signout</span></b></FONT></A></td>
						</tr>
					</table>
				</td>
			</tr>
			<tr>
				<td width="100%" bgColor="#ffffff">
					<table id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
						<tr>
							<td vAlign="top" width="10"><IMG height="8" src="../images/Login/ltop-corw.gif" width="10"></td>
							<td width="100%"><IMG height="1" src="../images/Login/spacer.gif" width="1"></td>
							<td vAlign="top" width="10"><IMG height="8" src="../images/Login/rtop-corw.gif" width="10"></td>
						</tr>
					</table>
				</td>
			</tr>
		</table>
	</body>
</HTML>
