<%@ Register TagPrefix="uc1" TagName="CombinationSelectionInfo" Src="CombinationSelectionInfo.ascx" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ExamsStudentInfoSelection.ascx.vb" Inherits="CollegeBoard.ExamsStudentInfoSelection" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="uc1" TagName="ReportMainSelection" Src="ReportMainSelection.ascx" %>
<LINK rel="stylesheet" type="text/css" href="../../../Images/Login/StyleSheet_Report.css">
<table id="table1" border="0" cellSpacing="0" cellPadding="0" width="815" align="left">
	<tbody>
		<tr>
			<td>
				<uc1:ReportMainSelection id="UcMainSelection" runat="server"></uc1:ReportMainSelection>
			</td>
		</tr>
		<tr>
			<td>
				<uc1:CombinationSelectionInfo id="UcCombSelection" runat="server"></uc1:CombinationSelectionInfo>
			</td>
		</tr>
		<tr>
			<td colspan="7" align="center">
				<asp:Label id="LblHeading" CssClass="SubHeading1" Width="100%" runat="server">Students Selection</asp:Label>
			</td>
		</tr>
		<tr>
			<td colspan="6">
				<table id="table4" border="0" cellSpacing="0" cellPadding="0" width="100%">
					<tr>
						<td Width="120"><asp:label id="LblExb" runat="server" CssClass="Lables" Width="100%"></asp:label></td>
						<td Width="10"></td>
						<td Width="120"><asp:label id="Label25" runat="server" CssClass="Lables" Width="100%">Selected</asp:label></td>
						<td Width="110"><asp:label id="Label14" runat="server" CssClass="Lables" Width="100%">Course</asp:label></td>
						<td Width="110"><asp:label id="Label5" runat="server" CssClass="Lables" Width="100%">Group</asp:label></td>
						<td Width="110"><asp:label id="Label13" runat="server" CssClass="Lables" Width="100%">Batch</asp:label></td>
						<td Width="110"><asp:label id="Label20" runat="server" CssClass="Lables" Width="100%">SubBatch</asp:label></td>
						<td Width="120">
							<asp:label id="PrvCourse" runat="server" Width="100%" CssClass="Lables">Prv.Course</asp:label></td>
					</tr>
					<tr>
						<td vAlign="top"><asp:listbox id="LstExb" runat="server" CssClass=" " Width="120px" Height="150px" Rows="100"
								SelectionMode="Multiple"></asp:listbox></td>
						<td vAlign="top">
							<table id="table13" border="0" cellSpacing="0" cellPadding="0" width="30">
								<tr>
									<td><asp:imagebutton id="BtnExb" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Select.gif"></asp:imagebutton></td>
								</tr>
								<tr>
									<td><asp:imagebutton id="BtnExbAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/SelectAll.gif"></asp:imagebutton></td>
								</tr>
								<tr>
									<td><asp:imagebutton id="BtnRemExb" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Remove.gif"></asp:imagebutton></td>
								</tr>
								<tr>
									<td><asp:imagebutton id="BtnRemAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/RemoveAll.gif"></asp:imagebutton></td>
								</tr>
							</table>
						</td>
						<td vAlign="top"><asp:listbox id="LstSelExb" runat="server" CssClass=" " Width="120px" Height="150px" Rows="100"
								SelectionMode="Multiple"></asp:listbox></td>
						<td vAlign="top" height="150px">
							<asp:CheckBoxList style="Z-INDEX: 0" id="ChkLstCourse" runat="server" CssClass="lables" Height="100%"
								AutoPostBack="True"></asp:CheckBoxList></td>
						<td vAlign="top">
							<asp:CheckBoxList style="Z-INDEX: 0" id="ChkLstGroup" runat="server" CssClass="lables"></asp:CheckBoxList></td>
						<td vAlign="top" height="150px">
							<asp:CheckBoxList style="Z-INDEX: 0" id="ChkLstBatch" runat="server" CssClass="lables"></asp:CheckBoxList></td>
						<td vAlign="top" height="150px">
							<asp:CheckBoxList style="Z-INDEX: 0" id="ChkLstSubBatch" runat="server" CssClass="lables"></asp:CheckBoxList></td>
						<td vAlign="top" height="150px">
							<asp:DropDownList style="Z-INDEX: 0" id="DrpPrvCourse" runat="server"></asp:DropDownList>
							<asp:CheckBoxList style="Z-INDEX: 0" id="ChkLstPrvCourse" runat="server" CssClass="lables" Width="100%"></asp:CheckBoxList></td>
					</tr>
				</table>
			</td>
		</tr>
	</tbody>
</table>
