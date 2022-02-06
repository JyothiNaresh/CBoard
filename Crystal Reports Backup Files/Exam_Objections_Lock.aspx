<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Exam_Objections_Lock.aspx.vb" Inherits="CollegeBoard.Exam_Objections_Lock" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Exam_Objections_Lock</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK id="Link1" href="../../../Images/Login/StyleSheet_Report.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; POSITION: absolute; TOP: 8px; LEFT: 8px" cellSpacing="1"
				cellPadding="1" width="100%" align="center" border="1">
				<TR>
					<TD align="center">
						<asp:Label id="Label1" runat="server" Width="100%" CssClass="Subheading1" Font-Size="Small">Objectons Entry Lock</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="300" align="center" border="1">
							<TR>
								<TD align="center" width="25%">
									<asp:Label id="Label3" runat="server" Width="100%" CssClass="lables">ExamDate</asp:Label></TD>
								<TD align="center" width="40%">
									<asp:DropDownList id="DrpExamDate" runat="server" Width="100%"></asp:DropDownList></TD>
								<TD align="center" width="15%">
									<asp:ImageButton id="IbntGo" runat="server" ImageUrl="../../../Images/NewImages/go.gif" Height="20px"></asp:ImageButton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<asp:DataGrid id="DgEntryLock" runat="server" CssClass="gridmain" AutoGenerateColumns="False"
							BorderColor="#FF8000">
							<ItemStyle Height="25px"></ItemStyle>
							<HeaderStyle Height="30px" CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="SNO">
									<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
									<ItemTemplate>
										<%#Container.DataSetIndex+1%>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn Visible="False" DataField="OBJTESTSLNO" HeaderText="DEXAMSLNO"></asp:BoundColumn>
								<asp:BoundColumn DataField="EXAMNAME" HeaderText="EXAMNAME"></asp:BoundColumn>
								<asp:BoundColumn DataField="EXAMDATE" HeaderText="EXAMDATE"></asp:BoundColumn>
								<asp:BoundColumn DataField="DESCRIPTION" HeaderText="DESCRIPTION"></asp:BoundColumn>
								<asp:TemplateColumn HeaderText="LOCK">
									<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
									<ItemTemplate>
										<asp:CheckBox id="ChkLock" runat="server"></asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn Visible="False" DataField="OBJLOCKSTATUS" HeaderText="OBJ"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="ISAPP" HeaderText="ISFINAL"></asp:BoundColumn>
							</Columns>
						</asp:DataGrid></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="150" align="center" border="1">
							<TR>
								<TD align="center">
									<asp:ImageButton id="IbtbLock" runat="server" Width="100%" ImageUrl="../../../Images/NewImages/lock.gif"
										Height="20px"></asp:ImageButton></TD>
								<TD align="center">
									<asp:ImageButton id="ImageButton3" runat="server" Width="100%" ImageUrl="../../../Images/NewImages/cancel.gif"
										Height="20px"></asp:ImageButton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<asp:Label id="Label2" runat="server" Width="100%" Height="15px" BackColor="#FFC0C0" ForeColor="Red"
							Font-Bold="True">Note : If You Want to Lock Please Verify that did you recieve All Objections from Branches, B'cause You Dont Have Permission to Unlock</asp:Label></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
