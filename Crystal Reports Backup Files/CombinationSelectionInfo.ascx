<%@ Control Language="vb" AutoEventWireup="false" Codebehind="CombinationSelectionInfo.ascx.vb" Inherits="CollegeBoard.CombinationSelectionInfo" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<LINK rel="stylesheet" type="text/css" href="../../../Images/Login/StyleSheet_Report.css">
<table id="table1" border="0" cellSpacing="0" cellPadding="0" width="815" align="left">
	<tbody>
		<tr>
			<td colspan="7" align="center">
				<asp:Label id="LblHeading" CssClass="SubHeading1" Width="100%" runat="server">Exam Selection</asp:Label>
			</td>
		</tr>
		<tr>
			<td width="120"><asp:label id="LblCourseExam" runat="server" CssClass="Lables" Width="100%">Course Exam</asp:label></td>
			<td width="152"><asp:dropdownlist id="DrpCourseExam" runat="server" CssClass="DropDownList" Width="100%" Height="40px"
					AutoPostBack="true"></asp:dropdownlist></td>
			<td width="122"><asp:label id="LblCombinationkey" runat="server" CssClass="Lables" Width="100%">CombinationKey</asp:label></td>
			<td width="260"><asp:dropdownlist id="DrpCombinationKey" runat="server" CssClass="DropDownList" Width="100%" Height="40px"
					AutoPostBack="true"></asp:dropdownlist></td>
			<td width="25"><asp:label id="LblSelection" runat="server" CssClass="Lables" Width="100%"> Periodicity</asp:label></td>
			<td width="100"><asp:dropdownlist id="DrpSelection" runat="server" CssClass="DropDownList" Width="100%" Height="40px"
					AutoPostBack="true">
					<asp:ListItem Value="0" Selected="True">--Select--</asp:ListItem>
					<asp:ListItem Value="1">All</asp:ListItem>
					<asp:ListItem Value="2">SelectedOnly</asp:ListItem>
				</asp:dropdownlist></td>
		</tr>
		<tr runat="server" id="TrPeriodicity">
			<td colspan="6" width="100%" valign="middle">
				<asp:CheckBoxList id="ChkLstPeriodicity" runat="server" CssClass="Lables" Width="100%" RepeatDirection="Horizontal"
					RepeatColumns="4" AutoPostBack="True"></asp:CheckBoxList>
			</td>
		</tr>
		<tr>
			<td colspan="6">
				<table id="table4" border="0" cellSpacing="0" cellPadding="0" width="690">
					<tr>
						<td><asp:label id="Label24" runat="server" CssClass="Lables" Width="100%">Exams</asp:label></td>
						<td></td>
						<td><asp:label id="Label25" runat="server" CssClass="Lables" Width="100%">Selected</asp:label></td>
						<td><asp:label id="Label14" runat="server" CssClass="Lables" Width="100%">Subjects</asp:label></td>
						<td></td>
						<td><asp:label id="Label5" runat="server" CssClass="Lables" Width="100%">Selected</asp:label></td>
						<td><asp:label id="Label13" runat="server" CssClass="Lables" Width="100%">Tracks</asp:label></td>
						<td></td>
						<td><asp:label id="Label20" runat="server" CssClass="Lables" Width="100%">Selected</asp:label></td>
					</tr>
					<tr>
						<td vAlign="top"><asp:listbox id="LstExams" runat="server" CssClass=" " Width="120px" Height="150px" Rows="100"
								SelectionMode="Multiple"></asp:listbox></td>
						<td vAlign="top">
							<table id="table13" border="0" cellSpacing="0" cellPadding="0" width="30">
								<tr>
									<td><asp:imagebutton id="BtnExam" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Select.gif"></asp:imagebutton></td>
								</tr>
								<tr>
									<td><asp:imagebutton id="BtnExamAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/SelectAll.gif"></asp:imagebutton></td>
								</tr>
								<tr>
									<td><asp:imagebutton id="BtnRemExam" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Remove.gif"></asp:imagebutton></td>
								</tr>
								<tr>
									<td><asp:imagebutton id="BtnRemAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/RemoveAll.gif"></asp:imagebutton></td>
								</tr>
							</table>
						</td>
						<td vAlign="top"><asp:listbox id="LstSelExams" runat="server" CssClass=" " Width="120px" Height="150px" Rows="100"
								SelectionMode="Multiple"></asp:listbox></td>
						<td vAlign="top"><asp:listbox id="LstSubject" runat="server" CssClass=" " Width="120px" Height="150px" Rows="100"
								SelectionMode="Multiple"></asp:listbox></td>
						<td vAlign="top">
							<table id="table15" border="0" cellSpacing="0" cellPadding="0" width="30">
								<tr>
									<td><asp:imagebutton id="BtnSubject" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Select.gif"></asp:imagebutton></td>
								</tr>
								<tr>
									<td><asp:imagebutton id="BtnSubjectAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/SelectAll.gif"></asp:imagebutton></td>
								</tr>
								<tr>
									<td><asp:imagebutton id="BtnRemSubject" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Remove.gif"></asp:imagebutton></td>
								</tr>
								<tr>
									<td><asp:imagebutton id="BtnRemSubjectAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/RemoveAll.gif"></asp:imagebutton></td>
								</tr>
							</table>
						</td>
						<td vAlign="top"><asp:listbox id="LstSelSubject" runat="server" CssClass=" " Width="120px" Height="150px" Rows="100"
								SelectionMode="Multiple"></asp:listbox></td>
						<td vAlign="top"><asp:listbox id="LstTrack" runat="server" CssClass=" " Width="120px" Height="150px" Rows="100"
								SelectionMode="Multiple"></asp:listbox></td>
						<td vAlign="top">
							<table id="table11" border="0" cellSpacing="0" cellPadding="0" width="30">
								<tr>
									<td><asp:imagebutton id="BtnTrack" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Select.gif"></asp:imagebutton></td>
								</tr>
								<tr>
									<td><asp:imagebutton id="BtnTrackAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/SelectAll.gif"></asp:imagebutton></td>
								</tr>
								<tr>
									<td><asp:imagebutton id="BtnRemTrack" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Remove.gif"></asp:imagebutton></td>
								</tr>
								<tr>
									<td><asp:imagebutton id="BtnRemTrackAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/RemoveAll.gif"></asp:imagebutton></td>
								</tr>
							</table>
						</td>
						<td vAlign="top"><asp:listbox id="LstSelTrack" runat="server" CssClass=" " Width="120px" Height="150px" Rows="100"
								SelectionMode="Multiple"></asp:listbox></td>
					</tr>
				</table>
			</td>
		</tr>
		<tr runat="server" id="NewSelection">
		</tr>
		<tr runat="server" id="ListSelection">
		</tr>
		<tr runat="server" id="DisplaySelection">
		</tr>
	</tbody>
</table>
