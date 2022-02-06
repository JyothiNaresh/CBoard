<%@ Control Language="vb" AutoEventWireup="false" Codebehind="AddressInfo.ascx.vb" Inherits="CollegeBoard.AddressInfo" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" debug="True" %>
<link href="../../Images/Login/StyleSheet.css" rel="stylesheet" type="text/css">
<TABLE id="Table1" style="WIDTH: 784px; HEIGHT: 64px" cellSpacing="0" cellPadding="0" width="784"
	border="0">
	<TR>
		<TD nowrap="nowrap" style="HEIGHT: 13px">
			<asp:Label id="lblCountry" runat="server" CssClass="Lables" Width="110px">Country *</asp:Label></TD>
		<TD nowrap="nowrap" style="HEIGHT: 13px">
			<asp:DropDownList id="drpCountry" runat="server" Width="144px" AutoPostBack="True" CssClass="textboxASR"></asp:DropDownList></TD>
		<TD nowrap="nowrap" style="HEIGHT: 13px">
			<asp:Label id="lblState" runat="server" CssClass="Lables" Width="100px">State *</asp:Label></TD>
		<TD nowrap="nowrap" style="HEIGHT: 13px">
			<asp:DropDownList id="drpState" runat="server" Width="144px" AutoPostBack="True" CssClass="textboxASR"></asp:DropDownList></TD>
		<TD nowrap="nowrap" style="HEIGHT: 13px">
			<asp:Label id="lblDistrict" runat="server" CssClass="Lables" Width="130px">District *</asp:Label></TD>
		<TD nowrap="nowrap" style="HEIGHT: 13px">
			<asp:DropDownList id="drpDistrict" runat="server" Width="144px" CssClass="textboxASR" AutoPostBack="True"></asp:DropDownList></TD>
	</TR>
	<TR>
		<TD nowrap="nowrap">
			<asp:Label id="lblMandal" Width="110px" CssClass="Lables" runat="server">Mandal *</asp:Label></TD>
		<TD nowrap="nowrap">
			<asp:DropDownList id="DrpMandal" Width="144px" CssClass="textboxASR" runat="server" AutoPostBack="True"></asp:DropDownList></TD>
		<TD nowrap="nowrap">
			<asp:Label id="Label1" Width="100px" CssClass="Lables" runat="server">H.No</asp:Label></TD>
		<TD nowrap="nowrap">
			<asp:TextBox id="txtHNO" CssClass="textboxASR" runat="server" Width="144px" MaxLength="50"></asp:TextBox></TD>
		<TD nowrap="nowrap">
			<asp:Label id="Label2" Width="130px" CssClass="Lables" runat="server">Street/Vill</asp:Label></TD>
		<TD nowrap="nowrap">
			<asp:TextBox id="txtStreetVill" CssClass="textboxASR" runat="server" Width="144px" MaxLength="50"></asp:TextBox></TD>
	</TR>
	<TR>
		<TD nowrap="nowrap">
			<asp:Label id="Label3" Width="110px" CssClass="Lables" runat="server">Area</asp:Label></TD>
		<TD nowrap="nowrap">
			<asp:TextBox id="txtMandalArea" Width="144px" CssClass="textboxASR" runat="server" MaxLength="50"></asp:TextBox></TD>
		<TD nowrap="nowrap">
			<asp:Label id="Label4" Width="100px" CssClass="Lables" runat="server">Pin</asp:Label></TD>
		<TD nowrap="nowrap">
			<asp:TextBox id="txtPIN" Width="144px" CssClass="textboxASR" runat="server" MaxLength="6"></asp:TextBox></TD>
		<TD nowrap="nowrap">
			<asp:Label id="Label5" Width="130px" CssClass="Lables" runat="server">Phone Res</asp:Label></TD>
		<TD nowrap="nowrap">
			<asp:TextBox id="txtPhoneRes" Width="144px" CssClass="textboxASR" runat="server" MaxLength="12"></asp:TextBox></TD>
	</TR>
	<TR>
		<TD nowrap="nowrap">
			<asp:Label id="Label6" Width="110px" CssClass="Lables" runat="server">Phone Off</asp:Label></TD>
		<TD nowrap="nowrap">
			<asp:TextBox id="txtPhoneOff" Width="144px" CssClass="textboxASR" runat="server" MaxLength="12"></asp:TextBox></TD>
		<TD nowrap="nowrap">
			<asp:Label id="Label7" Width="100px" CssClass="Lables" runat="server">Mobile1</asp:Label></TD>
		<TD nowrap="nowrap">
			<asp:TextBox id="txtMobile1" CssClass="textboxASR" runat="server" Width="144px" MaxLength="10"
				ReadOnly="True"></asp:TextBox></TD>
		<TD nowrap="nowrap">
			<asp:Label id="Label8" Width="130px" CssClass="Lables" runat="server">Mobile2</asp:Label></TD>
		<TD nowrap="nowrap">
			<asp:TextBox id="txtMobile2" Width="144px" CssClass="textboxASR" runat="server" MaxLength="10"
				ReadOnly="True"></asp:TextBox></TD>
	</TR>
	<TR>
		<TD nowrap="nowrap">
			<asp:Label id="Label9" Width="110px" CssClass="Lables" runat="server">Email</asp:Label></TD>
		<TD nowrap="nowrap">
			<asp:TextBox id="txtEmail" Width="144px" CssClass="textboxASR" runat="server" MaxLength="50"></asp:TextBox></TD>
		<TD nowrap="nowrap"></TD>
		<TD nowrap="nowrap"></TD>
		<TD nowrap="nowrap"></TD>
		<TD nowrap="nowrap"></TD>
	</TR>
</TABLE>
