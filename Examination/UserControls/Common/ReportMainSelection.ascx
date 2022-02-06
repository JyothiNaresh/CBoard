<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ReportMainSelection.ascx.vb" Inherits="CollegeBoard.ReportMainSelection" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<link rel="stylesheet" type="text/css" href="../../../Images/Login/StyleSheet_Report.css">
<table id="table1" border="0" cellSpacing="0" cellPadding="0" width="815" align="left">
	<tbody>
		<tr>
			<td colspan="7" align="center">
				<asp:Label id="LblHeading" CssClass="SubHeading1" Width="100%" runat="server">Main Selection</asp:Label>
			</td>
		</tr>
		<tr>
			<td width="10%"><asp:label id="LblRptType" Width="100%" CssClass="Lables" runat="server">Selection&nbsp;On</asp:label></td>
			<td width="15%"><asp:dropdownlist id="DrpSelection" Width="100%" CssClass="DropDownList" runat="server" AutoPostBack="True"
					Height="40px"></asp:dropdownlist></td>
			<td width="7%"><asp:label style="Z-INDEX: 0" id="Label1" Width="100%" CssClass="Lables" runat="server">Filter&nbsp;On</asp:label></td>
			<td width="15%"><asp:dropdownlist style="Z-INDEX: 0" id="DrpFilter" Width="100%" CssClass="DropDownList" runat="server"
					AutoPostBack="True" Height="40px"></asp:dropdownlist></td>
			<td width="11%"><asp:label id="lblFilter" Width="100%" CssClass="Lables" runat="server" Height="17px"> Filter</asp:label></td>
			<td width="10%"><asp:dropdownlist id="DrpFilterItems" Width="100%" CssClass="DropDownList" runat="server" AutoPostBack="True"
					Height="16px">
					<asp:ListItem Value="1">All</asp:ListItem>
					<asp:ListItem Value="2">Selected Only</asp:ListItem>
				</asp:dropdownlist></td>
			<td width="9%">
				<asp:Button style="Z-INDEX: 0" id="BtnSelection" runat="server" Width="100%" Text="Selection Hide"></asp:Button></td>
		</tr>
		<tr>
			<td colSpan="7">
				<asp:label style="Z-INDEX: 0" id="LblSel" runat="server" CssClass="Lables" Width="100%"></asp:label>
			</td>
		</tr>
		<tr runat="server" id="SelectionRow">
			<td colSpan="7">
				<asp:CheckBoxList style="Z-INDEX: 0" id="ChkLstSel" CssClass="Lables" runat="server" Width="815px"
					RepeatDirection="Vertical" RepeatColumns="4"></asp:CheckBoxList></td>
		</tr>
	</tbody>
</table>
