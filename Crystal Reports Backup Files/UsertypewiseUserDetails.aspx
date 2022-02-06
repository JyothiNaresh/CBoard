<%@ Page Language="vb" AutoEventWireup="false" Codebehind="UsertypewiseUserDetails.aspx.vb" Inherits="CollegeBoard.UsertypewiseUserDetails" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
		<title>UsertypewiseUserDetails</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" type="text/javascript" src="../../Includes/Common/CommanFunctions.js"></script>
		<script language="javascript" type="text/javascript" src="../../Includes/Common/jsDateValidation.js"></script>
		<script language="javascript" type="text/javascript" src="../../Includes/Transactions/jsReservation.js"></script>
		<LINK href="../../Styles/StyleSheet_ASR.css" type="text/css" rel="stylesheet">
		<style type="text/css">BODY { SCROLLBAR-FACE-COLOR: #ebded6; SCROLLBAR-ARROW-COLOR: black }
	</style>
		<script language="javascript" type="text/javascript">
		
		function disDetails(no)
	{
	
	var msg;
	var qs;
	var url;
	var temp;
	qs='?uno='
	msg=qs+no
			
	temp='UserDetailsPopUp.aspx'
	url=temp+msg
	
	window.open(url,'mine','menubar=no,toolbar=no,scrollbars=yes,height=300,width=650')
	}
	
		</script>
</HEAD>
	<body background="../../Images/NewImages/innerpage-bg1.jpg" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 432px"
				cellSpacing="0" cellPadding="5" width="90%" align="center" border="0">
				<TBODY>
					<TR>
						<TD style="HEIGHT: 16px" vAlign="baseline" nowrap="nowrap" align="center">
							<asp:label id="lblHeading" runat="server" CssClass="SubHeading1" Width="100%">User&nbsp;Type&nbsp;Wise&nbsp;Users&nbsp;List</asp:label></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 13px" vAlign="baseline" nowrap="nowrap" align="center">&nbsp;</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 30px" vAlign="baseline" nowrap="nowrap" align="center">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="300" border="1">
								<TR>
									<TD style="WIDTH: 63px">
										<asp:label id="Label1" runat="server" CssClass="Lables" Width="100%">D.O.:</asp:label></TD>
									<TD>
										<asp:dropdownlist id="DrpDo" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD vAlign="baseline" nowrap="nowrap" align="center"><asp:table id="tabMain" runat="server" CellSpacing="0" CellPadding="4" GridLines="Both"></asp:table><asp:label id="lblnote" runat="server" Visible="False" Width="443px" CssClass="Lables"></asp:label></TD>
					</TR>
				</TBODY>
			</TABLE>
			&nbsp;</form>
	</body>
</HTML>
