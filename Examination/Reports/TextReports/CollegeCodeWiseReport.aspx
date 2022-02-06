<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CollegeCodeWiseReport.aspx.vb" Inherits="CollegeBoard.CollegeCodeWiseReport" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">

<HTML>
	<HEAD>
		<title>TxtSectionWiseReportNew</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK id="Link1" href="../../../Images/Login/StyleSheet_Report.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" type="text/javascript" src="../../Include/Report.js"></script>
	    <style type="text/css">
            #Table3 {
                width: 257px;
            }
            </style>
	</HEAD>
    <body onscroll="javascript:setcoords()" topMargin="0" onload="javascript:ScrollIt()" MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; POSITION: absolute; TOP: 8px; LEFT: 8px; width: 917px;" cellSpacing="0"
				cellPadding="0" align="center" border="0">
				<TR>
					<TD class="DarkColor" style="HEIGHT: 11px">
						<TABLE id="Table13" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD style="WIDTH: 12px" vAlign="top" width="12"><IMG height="11" src="../../../Images/Login/table-lcorw.gif" width="11"></TD>
								<TD class="SubHeading1" vAlign="middle" align="center">Board Students Information 
									Report</TD>
								<TD vAlign="top" width="11"><IMG height="11" src="../../../Images/Login/table-rcorw.gif" width="11"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
                <TR>
								<TD vAlign="middle" align="center">
									<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="169" border="0">
										<TR>
											<TD nowrap="nowrap"><asp:label id="lblRZ" runat="server" CssClass="Lables" Width="86px">College Code</asp:label></TD>
											<TD nowrap="nowrap">
                                                <asp:TextBox ID="txtCode" runat="server" AutoPostBack="True"></asp:TextBox>
                                            </TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
                <TR>
					<TD vAlign="top" align="right">
                        &nbsp;</TD>
				</TR>
                <tr>
                    <td align="center">
                        <table class="auto-style1">
                            <tr>
                                <td>
									<asp:label id="Label14" runat="server" CssClass="Lables" Width="100px">Format</asp:label></td>
                                <td>
                                    <asp:DropDownList ID="drpFormat" runat="server">
                                        <asp:ListItem Selected="True" Value="1">Admissions</asp:ListItem>
                                        <asp:ListItem Value="2">Reservations</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
									<asp:label id="Label6" runat="server" CssClass="Lables" Width="100px">Format</asp:label></td>
                                <td>
                                    <asp:DropDownList ID="drpCode" runat="server" Enabled="False">
                                        <asp:ListItem Value="2" Selected="True">Code Wise</asp:ListItem>
                                        <asp:ListItem Value="1">Branch Wise</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
									<asp:label id="Label7" runat="server" CssClass="Lables" Width="100px">Order</asp:label></td>
                                <td>
                                    <asp:DropDownList ID="drpOrder" runat="server">
                                        <asp:ListItem Selected="True" Value="1">ADMNO</asp:ListItem>
                                        <asp:ListItem Value="2">NAME</asp:ListItem>
                                        <asp:ListItem Value="3">PRV_HTNO</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <TR>
					<TD vAlign="top" align="right">
                        <br />
                        <asp:imagebutton id="iBtnReport" runat="server" Width="80px" Height="20px" ImageUrl="../../../Images/NewImages/report.gif"></asp:imagebutton></TD>
				</TR>
                </FORM>
	</body>
</html>
