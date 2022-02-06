<%@ Control Language="vb" AutoEventWireup="false" Codebehind="VcDoZoneRegionSelection.ascx.vb" Inherits="CollegeBoard.VcDoZoneRegionSelection" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<LINK href="../../../Images/Login/StyleSheet_Report.css" type="text/css" rel="stylesheet">
<BLOCKQUOTE>
	<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="784" align="center" border="0">
		<TBODY>
			<TR>
				<TD width="10%"><asp:CheckBox ID="Chkcommon" Runat="server" CssClass="Lables" Width="100%" AutoPostBack="True"
						Text="Common"></asp:CheckBox></TD>
				<TD width="10%"><asp:label id="LblRptType" runat="server" CssClass="Lables" Width="100%">ReportType</asp:label></TD>
				<TD width="15%"><asp:dropdownlist id="drpReportType" runat="server" CssClass="DropDownList" Width="100%" Height="40px"
						AutoPostBack="True"></asp:dropdownlist></TD>
				<TD width="10%"><asp:radiobutton id="rdbRegion" runat="server" CssClass="Lables" Width="100%" Height="5px" AutoPostBack="True"
						Text="Region" Checked="True" GroupName="0"></asp:radiobutton></TD>
				<TD width="10%"><asp:radiobutton id="rdbZone" runat="server" CssClass="Lables" Width="100%" Height="5px" AutoPostBack="True"
						Text="Zone" GroupName="0"></asp:radiobutton></TD>
				<TD width="10%"><asp:radiobutton id="rdbDos" runat="server" CssClass="Lables" Width="100%" Height="17px" AutoPostBack="True"
						Text="DO" GroupName="0"></asp:radiobutton></TD>
				<TD width="10%"><asp:radiobutton id="rdbVC" runat="server" CssClass="Lables" Width="100%" Height="17px" AutoPostBack="True"
						Text="VC" GroupName="0"></asp:radiobutton></TD>
				<TD width="10%"><asp:label id="lblRZ" runat="server" CssClass="Lables" Width="100%" Height="17px"> Region</asp:label></TD>
				<TD width="15%"><asp:dropdownlist id="drpRZ" runat="server" CssClass="DropDownList" Width="100%" Height="16px" AutoPostBack="True"></asp:dropdownlist></TD>
			</TR>
		</TBODY>
	</TABLE>
</BLOCKQUOTE></TD></TR></TBODY> <BLOCKQUOTE></BLOCKQUOTE><BLOCKQUOTE></BLOCKQUOTE>
