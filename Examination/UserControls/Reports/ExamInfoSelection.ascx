<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls, Version=1.0.2.226, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ExamInfoSelection.ascx.vb" Inherits="CollegeBoard.ExamInfoSelection" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<LINK id="Link1" href="../../../Images/Login/StyleSheet_Report.css" type="text/css" rel="stylesheet">
<table id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
		<td><iewc:tabstrip id="TabStrip1" align="Left" TabSelectedStyle="background-color:#ffffff;color:#000000;"
				TabHoverStyle="background-color:#777777" TabDefaultStyle='background-color:#111111;font-family:verdana;font-weight:bold;font-size:8pt;color:#ffffff;width:79;height:21;text-align:center;background-image:"C:\Documents and Settings\hemanth\Desktop\Geentab.jpg";'
				runat="server" BackColor="White" TargetId="FileterSel">
				<iewc:Tab DefaultImageUrl="../../../Images/NewImages/examinfo.jpg" SelectedImageUrl="../../../Images/NewImages/examinfo-h.jpg"
					HoverImageUrl="../../../Images/NewImages/examinfo-h.jpg"></iewc:Tab>
				<iewc:TabSeparator></iewc:TabSeparator>
				<iewc:Tab DefaultImageUrl="../../../Images/NewImages/student-info.jpg" SelectedImageUrl="../../../Images/NewImages/student-info-h.jpg"
					HoverImageUrl="../../../Images/NewImages/student-info-h.jpg"></iewc:Tab>
				<iewc:TabSeparator></iewc:TabSeparator>
				<iewc:Tab DefaultImageUrl="../../../Images/NewImages/subject-info.jpg" SelectedImageUrl="../../../Images/NewImages/subject-info-h.jpg"
					HoverImageUrl="../../../Images/NewImages/subject-info-h.jpg"></iewc:Tab>
				<iewc:TabSeparator></iewc:TabSeparator>
				<iewc:Tab DefaultImageUrl="../../../Images/NewImages/general-info.jpg" SelectedImageUrl="../../../Images/NewImages/general-info-h.jpg"
					HoverImageUrl="../../../Images/NewImages/general-info-h.jpg"></iewc:Tab>
				<iewc:TabSeparator></iewc:TabSeparator>
				<iewc:Tab DefaultImageUrl="../../../Images/NewImages/report-info.jpg" SelectedImageUrl="../../../Images/NewImages/report-info-h.jpg"
					HoverImageUrl="../../../Images/NewImages/report-info-h.jpg"></iewc:Tab>
			</iewc:tabstrip></td>
	</tr>
	<tr>
		<td><iewc:multipage id="FileterSel" runat="server" BorderWidth="1" BorderStyle="Solid" BorderColor="#844326">
				<iewc:pageView>
					<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="300" border="0">
						<TR>
							<TD>
								<asp:label id="Label21" runat="server" Width="100%" CssClass="Lables">Exam&nbsp;Level</asp:label></TD>
							<TD>
								<asp:dropdownlist id="drpExamBranch" enabled="False" runat="server" Width="155px" CssClass=" "></asp:dropdownlist></TD>
							<TD>
								<asp:label id="Label37" runat="server" Width="104px" CssClass="Lables">Course&nbsp;Exam</asp:label></TD>
							<TD>
								<asp:dropdownlist id="DrpCrExam" runat="server" Width="155px" CssClass=" " AutoPostBack="True"></asp:dropdownlist></TD>
							<TD>
								<asp:label id="Label22" runat="server" Width="100%" CssClass="Lables">Combination&nbsp;Key</asp:label></TD>
							<TD>
								<asp:dropdownlist id="cboCombiantion" runat="server" Width="360px" CssClass=" " AutoPostBack="True"></asp:dropdownlist></TD>
						</TR>
					</TABLE>
					<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="472" border="0">
						<TR>
							<TD>
								<asp:label id="Label24" runat="server" Width="100%" CssClass="Lables">Periodicity</asp:label></TD>
							<TD></TD>
							<TD>
								<asp:label id="Label25" runat="server" Width="100%" CssClass="Lables">Selected</asp:label></TD>
							<TD>
								<asp:label id="Label14" runat="server" Width="100%" CssClass="Lables">Exam</asp:label></TD>
							<TD></TD>
							<TD>
								<asp:label id="Label5" runat="server" Width="100%" CssClass="Lables">Selected</asp:label></TD>
							<TD>
								<asp:label id="Label13" runat="server" Width="100%" CssClass="Lables">Course</asp:label></TD>
							<TD></TD>
							<TD>
								<asp:label id="Label20" runat="server" Width="100%" CssClass="Lables">Selected</asp:label></TD>
						</TR>
						<TR>
							<TD vAlign="top">
								<asp:listbox id="LSTPeriodicity" runat="server" Width="140px" CssClass=" " Height="150px" SelectionMode="Multiple"
									Rows="100"></asp:listbox></TD>
							<TD vAlign="top">
								<TABLE id="Table13" cellSpacing="0" cellPadding="0" width="30" border="0">
									<TR>
										<TD>
											<asp:imagebutton id="BtnPeriodicity" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Select.gif"></asp:imagebutton></TD>
									</TR>
									<TR>
										<TD colSpan="1">
											<asp:imagebutton id="BtnPeriodicityAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/SelectAll.gif"></asp:imagebutton></TD>
									</TR>
									<TR>
										<TD>
											<asp:imagebutton id="BtnRemPeriodicity" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Remove.gif"></asp:imagebutton></TD>
									</TR>
									<TR>
										<TD>
											<asp:imagebutton id="BtnRemPeriodicityAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/RemoveAll.gif"></asp:imagebutton></TD>
									</TR>
								</TABLE>
							</TD>
							<TD vAlign="top">
								<asp:listbox id="LSTSelPeriodicity" runat="server" Width="140px" CssClass=" " Height="150px"
									SelectionMode="Multiple" Rows="100"></asp:listbox></TD>
							<TD vAlign="top">
								<asp:listbox id="lstExam" runat="server" Width="140px" CssClass=" " Height="150px" SelectionMode="Multiple"
									Rows="100"></asp:listbox></TD>
							<TD vAlign="top">
								<TABLE id="Table15" cellSpacing="0" cellPadding="0" width="30" border="0">
									<TR>
										<TD>
											<asp:imagebutton id="BtnExam" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Select.gif"></asp:imagebutton></TD>
									</TR>
									<TR>
										<TD colSpan="1">
											<asp:imagebutton id="BtnExamAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/SelectAll.gif"></asp:imagebutton></TD>
									</TR>
									<TR>
										<TD>
											<asp:imagebutton id="BtnRemExam" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Remove.gif"></asp:imagebutton></TD>
									</TR>
									<TR>
										<TD>
											<asp:imagebutton id="BtnRemAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/RemoveAll.gif"></asp:imagebutton></TD>
									</TR>
								</TABLE>
							</TD>
							<TD vAlign="top">
								<asp:listbox id="lstSelExam" runat="server" Width="140px" CssClass=" " Height="150px" SelectionMode="Multiple"
									Rows="100"></asp:listbox></TD>
							<TD vAlign="top">
								<asp:listbox id="LSTCourse" runat="server" Width="140px" CssClass=" " Height="150px" SelectionMode="Multiple"
									Rows="100"></asp:listbox></TD>
							<TD vAlign="top">
								<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="30" border="0">
									<TR>
										<TD>
											<asp:imagebutton id="BtnSelCourse" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Select.gif"></asp:imagebutton></TD>
									</TR>
									<TR>
										<TD colSpan="1">
											<asp:imagebutton id="BtnSelCourseAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/SelectAll.gif"></asp:imagebutton></TD>
									</TR>
									<TR>
										<TD>
											<asp:imagebutton id="BtnRemCourse" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Remove.gif"></asp:imagebutton></TD>
									</TR>
									<TR>
										<TD>
											<asp:imagebutton id="BtnRemCourseAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/RemoveAll.gif"></asp:imagebutton></TD>
									</TR>
								</TABLE>
							</TD>
							<TD vAlign="top">
								<asp:listbox id="LSTSelCourse" runat="server" Width="140px" CssClass=" " Height="150px" SelectionMode="Multiple"
									Rows="100"></asp:listbox></TD>
						</TR>
					</TABLE>
				</iewc:pageView>
				<iewc:pageView>
					<table>
						<TR>
							<TD>
								<asp:label id="lblERZ" runat="server" Width="100%" CssClass="Lables">Exam Branch</asp:label></TD>
							<TD></TD>
							<TD>
								<asp:label id="Label3" runat="server" Width="100%" CssClass="Lables">Selected</asp:label></TD>
							<TD>
								<asp:label id="Label4" runat="server" Width="100%" CssClass="Lables">Group</asp:label></TD>
							<TD></TD>
							<TD>
								<asp:label id="Label8" runat="server" Width="100%" CssClass="Lables">Selected</asp:label></TD>
							<TD>
								<asp:label id="Label16" runat="server" Width="100%" CssClass="Lables">Batch</asp:label></TD>
							<TD></TD>
							<TD>
								<asp:label id="Label17" runat="server" Width="100%" CssClass="Lables">Selected</asp:label></TD>
						</TR>
						<TR>
							<TD vAlign="top" align="center" colSpan="1" rowSpan="1">
								<asp:listbox id="LSTExamBranch" runat="server" Width="140px" CssClass=" " Height="150px" SelectionMode="Multiple"
									Rows="100"></asp:listbox></TD>
							<TD vAlign="top">
								<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="30" border="0">
									<TR>
										<TD>
											<asp:imagebutton id="BtnSelEB" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Select.gif"></asp:imagebutton></TD>
									</TR>
									<TR>
										<TD colSpan="1">
											<asp:imagebutton id="BtnSelEBAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/SelectAll.gif"></asp:imagebutton></TD>
									</TR>
									<TR>
										<TD>
											<asp:imagebutton id="BtnRemEB" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Remove.gif"></asp:imagebutton></TD>
									</TR>
									<TR>
										<TD>
											<asp:imagebutton id="BtnRemEBAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/RemoveAll.gif"></asp:imagebutton></TD>
									</TR>
								</TABLE>
							</TD>
							<TD vAlign="top">
								<asp:listbox id="lstSelExamBranch" runat="server" Width="140px" CssClass=" " Height="150px" SelectionMode="Multiple"
									Rows="100"></asp:listbox></TD>
							<TD vAlign="top">
								<asp:listbox id="LSTGroup" runat="server" Width="140px" CssClass=" " Height="150px" SelectionMode="Multiple"
									Rows="20"></asp:listbox></TD>
							<TD vAlign="top">
								<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="30" border="0">
									<TR>
										<TD>
											<asp:imagebutton id="BtnSelGroup" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Select.gif"></asp:imagebutton></TD>
									</TR>
									<TR>
										<TD>
											<asp:imagebutton id="BtnSelGroupAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/SelectAll.gif"></asp:imagebutton></TD>
									</TR>
									<TR>
										<TD>
											<asp:imagebutton id="BtnRemGroup" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Remove.gif"></asp:imagebutton></TD>
									</TR>
									<TR>
										<TD>
											<asp:imagebutton id="BtnRemGroupAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/RemoveAll.gif"></asp:imagebutton></TD>
									</TR>
								</TABLE>
							</TD>
							<TD vAlign="top">
								<asp:listbox id="lstSelGroup" runat="server" Width="140px" CssClass=" " Height="150px" SelectionMode="Multiple"
									Rows="20"></asp:listbox></TD>
							<TD vAlign="top">
								<asp:listbox id="LSTBatch" runat="server" Width="140px" CssClass=" " Height="150px" SelectionMode="Multiple"
									Rows="20"></asp:listbox></TD>
							<TD vAlign="top">
								<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="30" border="0">
									<TR>
										<TD>
											<asp:imagebutton id="BtnSelBatch" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Select.gif"></asp:imagebutton></TD>
									</TR>
									<TR>
										<TD>
											<asp:imagebutton id="BtnSelBatchAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/SelectAll.gif"></asp:imagebutton></TD>
									</TR>
									<TR>
										<TD>
											<asp:imagebutton id="BtnRemBatch" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Remove.gif"></asp:imagebutton></TD>
									</TR>
									<TR>
										<TD>
											<asp:imagebutton id="BtnRemBatchAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/RemoveAll.gif"></asp:imagebutton></TD>
									</TR>
								</TABLE>
							</TD>
							<TD vAlign="top">
								<asp:listbox id="LSTSelBatch" runat="server" Width="140px" CssClass=" " Height="150px" SelectionMode="Multiple"
									Rows="20"></asp:listbox></TD>
						</TR>
					</table>
				</iewc:pageView>
				<iewc:pageView>
					<table>
						<TR>
							<TD>
								<asp:label id="Label15" runat="server" Width="100%" CssClass="Lables">Subjects</asp:label></TD>
							<TD></TD>
							<TD>
								<asp:label id="Label18" runat="server" Width="100%" CssClass="Lables">Selected</asp:label></TD>
							<TD>
								<asp:label id="Label26" runat="server" Width="100%" CssClass="Lables">Track</asp:label></TD>
							<TD></TD>
							<TD>
								<asp:label id="Label27" runat="server" Width="100%" CssClass="Lables">Selected</asp:label></TD>
							<TD>
								<asp:label id="Label30" runat="server" Width="100%" CssClass="Lables">Caste</asp:label></TD>
							<TD></TD>
							<TD>
								<asp:label id="Label40" runat="server" Width="100%" CssClass="Lables">Selected</asp:label></TD>
						</TR>
						<TR>
							<TD vAlign="top" colSpan="1" rowSpan="1">
								<asp:listbox id="LSTSubject" runat="server" Width="140px" CssClass=" " Height="150px" SelectionMode="Multiple"
									Rows="20"></asp:listbox></TD>
							<TD vAlign="top">
								<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="30" border="0">
									<TR>
										<TD>
											<asp:imagebutton id="BtnSelsubject" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Select.gif"></asp:imagebutton></TD>
									</TR>
									<TR>
										<TD>
											<asp:imagebutton id="BtnSelsubjectAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/SelectAll.gif"></asp:imagebutton></TD>
									</TR>
									<TR>
										<TD>
											<asp:imagebutton id="BtnRemsubject" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Remove.gif"></asp:imagebutton></TD>
									</TR>
									<TR>
										<TD>
											<asp:imagebutton id="BtnRemsubjectAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/RemoveAll.gif"></asp:imagebutton></TD>
									</TR>
								</TABLE>
							</TD>
							<TD vAlign="top">
								<asp:listbox id="LSTSelSubjects" runat="server" Width="140px" CssClass=" " Height="150px" SelectionMode="Multiple"
									Rows="20"></asp:listbox></TD>
							<TD vAlign="top">
								<asp:listbox id="LstTrack" runat="server" Width="140px" CssClass=" " Height="150px" SelectionMode="Multiple"
									Rows="20"></asp:listbox></TD>
							<TD vAlign="top">
								<TABLE id="Table14" cellSpacing="0" cellPadding="0" width="30" border="0">
									<TR>
										<TD>
											<asp:imagebutton id="BtnSelTrack" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Select.gif"></asp:imagebutton></TD>
									</TR>
									<TR>
										<TD>
											<asp:imagebutton id="BtnSelTrackAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/SelectAll.gif"></asp:imagebutton></TD>
									</TR>
									<TR>
										<TD>
											<asp:imagebutton id="BtnRemTrack" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Remove.gif"></asp:imagebutton></TD>
									</TR>
									<TR>
										<TD>
											<asp:imagebutton id="BtnRemTackAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/RemoveAll.gif"></asp:imagebutton></TD>
									</TR>
								</TABLE>
							</TD>
							<TD vAlign="top">
								<asp:listbox id="LstSelTrack" runat="server" Width="140px" CssClass=" " Height="150px" SelectionMode="Multiple"
									Rows="20"></asp:listbox></TD>
							<TD vAlign="top">
								<asp:listbox id="LSTCaste" runat="server" Width="140px" CssClass="textboxASR" Height="150px"
									SelectionMode="Multiple" Rows="20" DESIGNTIMEDRAGDROP="529"></asp:listbox></TD>
							<TD vAlign="top">
								<TABLE id="Table16" cellSpacing="0" cellPadding="0" width="30" border="0">
									<TR>
										<TD>
											<asp:imagebutton id="BtnSelCaste" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Select.gif"></asp:imagebutton></TD>
									</TR>
									<TR>
										<TD>
											<asp:imagebutton id="BtnSelCasteAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/SelectAll.gif"></asp:imagebutton></TD>
									</TR>
									<TR>
										<TD>
											<asp:imagebutton id="BtnRemCaste" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Remove.gif"></asp:imagebutton></TD>
									</TR>
									<TR>
										<TD>
											<asp:imagebutton id="BtnRemCasteAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/RemoveAll.gif"></asp:imagebutton></TD>
									</TR>
								</TABLE>
							</TD>
							<TD vAlign="top">
								<asp:listbox id="LSTSelCaste" runat="server" Width="140px" CssClass="textboxASR" Height="150px"
									SelectionMode="Multiple" Rows="20"></asp:listbox></TD>
						</TR>
					</table>
				</iewc:pageView>
				<iewc:pageView>
					<TABLE id="Table9" cellSpacing="0" cellPadding="0" width="300" border="1">
						<TR>
							<TD>
								<asp:label id="Label10" runat="server" Width="95px" CssClass="Lables">Student&nbsp;Type</asp:label></TD>
							<TD>
								<asp:dropdownlist id="drpStuType" runat="server" Width="95px" CssClass="textboxASR" Height="20px">
									<asp:ListItem Value="0">ALL</asp:ListItem>
								</asp:dropdownlist></TD>
							<TD>
								<asp:label id="Label7" runat="server" Width="95px" CssClass="Lables">Medium</asp:label></TD>
							<TD>
								<asp:dropdownlist id="drpMedium" runat="server" Width="95px" CssClass="textboxASR" Height="20px"></asp:dropdownlist></TD>
							<TD>
								<asp:label id="Label6" runat="server" Width="95px" CssClass="Lables">Gender</asp:label></TD>
							<TD>
								<asp:dropdownlist id="drpGender" runat="server" Width="95px" CssClass="DropDownList" Height="20px">
									<asp:ListItem Value="A">All</asp:ListItem>
									<asp:ListItem Value="M">Male</asp:ListItem>
									<asp:ListItem Value="F">Female</asp:ListItem>
								</asp:dropdownlist></TD>
						</TR>
						<TR>
							<TD colSpan="2">
								<asp:radiobutton id="RdbFailWithAbs" runat="server" Width="100%" CssClass="Lables" Checked="True"
									GroupName="K1" Text="Fail (%) With Absent"></asp:radiobutton></TD>
							<TD colSpan="2">
								<asp:radiobutton id="RdbFailWithOutAbs" runat="server" Width="100%" CssClass="Lables" GroupName="K1"
									Text="Fail (%) WithOut Absent"></asp:radiobutton></TD>
							<TD>
								<asp:label id="Label23" runat="server" Width="95px" CssClass="Lables">PreCou.Medium</asp:label></TD>
							<TD>
								<asp:dropdownlist id="DrpPreCourseMedium" runat="server" Width="95px" CssClass="textboxASR" Height="20px"></asp:dropdownlist></TD>
						</TR>
					</TABLE>
				</iewc:pageView>
				<iewc:pageView></iewc:pageView>
			</iewc:multipage></td>
	</tr>
	<TR>
		<td align="left"><asp:datagrid id="DataGrid2" runat="server" AutoGenerateColumns="False">
				<Columns>
					<asp:BoundColumn DataField="SNO" HeaderText="Sno"></asp:BoundColumn>
					<asp:BoundColumn DataField="DESCRIPTION" HeaderText="Descripition"></asp:BoundColumn>
					<asp:BoundColumn DataField="SELECTIONINFO" HeaderText="SelectionInfo"></asp:BoundColumn>
				</Columns>
			</asp:datagrid></td>
	</TR>
</table>
<table id="Table14" cellSpacing="0" cellPadding="0" width="300" border="1">
</table>
