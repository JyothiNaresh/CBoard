<%@ Page Language="vb" AutoEventWireup="True" EnableViewState="True" Codebehind="Objection_ObjectionsEntry.aspx.vb" Inherits="CollegeBoard.Objection_ObjectionsEntry" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Objection_ObjectionsEntry</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK id="Link1" href="../../Images/Login/StyleSheet_Report.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="1"
				cellPadding="1" width="955" align="center" border="1">
				<TR>
					<TD align="center"><asp:label id="Label1" runat="server" CssClass="Subheading1" Width="100%" Font-Size="Small">Question Paper Objections Entry</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">&nbsp;
						<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="600" align="center" border="1">
							<TR>
								<TD align="center" width="15%"><asp:label id="Label2" runat="server" CssClass="lables" Width="100%">ExamBranch</asp:label></TD>
								<TD align="center" width="35%"><asp:dropdownlist id="DrpEB" runat="server" Width="100%"></asp:dropdownlist></TD>
								<TD align="center" width="15%"><asp:label id="Label5" runat="server" CssClass="lables" Width="100%">LandLine</asp:label></TD>
								<TD align="center" width="35%"><asp:textbox id="TextBox1" runat="server" Width="100%"></asp:textbox></TD>
							</TR>
							<TR>
								<TD align="center" width="15%"><asp:label id="Label3" runat="server" CssClass="lables" Width="100%">Principal</asp:label></TD>
								<TD align="center" width="35%"><asp:textbox id="TextBox2" runat="server" Width="100%"></asp:textbox></TD>
								<TD align="center" width="15%"><asp:label id="Label6" runat="server" CssClass="lables" Width="100%">Mobile</asp:label></TD>
								<TD align="center" width="35%"><asp:textbox id="TextBox3" runat="server" Width="100%"></asp:textbox></TD>
							</TR>
							<TR>
								<TD align="center" width="15%"><asp:label id="Label4" runat="server" CssClass="lables" Width="100%">ExamName</asp:label></TD>
								<TD align="center" width="35%"><asp:dropdownlist id="DrpEN" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								<TD align="center" width="15%"><asp:label id="Label7" runat="server" CssClass="lables" Width="100%">ExamDate</asp:label></TD>
								<TD align="center" width="35%"><asp:dropdownlist id="DrpED" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="700" align="center" border="1">
							<TR>
								<TD align="center"><asp:datagrid id="DgObjections" runat="server" CssClass="gridmain" Width="100%" AutoGenerateColumns="False"
										Height="25px" AllowSorting="True">
										<ItemStyle Height="20px"></ItemStyle>
										<HeaderStyle CssClass="GridHeader"></HeaderStyle>
										<Columns>
											<asp:BoundColumn DataField="SNO" HeaderText="SNO">
												<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="SUBJECT">
												<HeaderStyle HorizontalAlign="Left" Width="100%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												<ItemTemplate>
													<asp:DropDownList id="DrpSubject" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="DrpSubject_SelectedIndexChanged"></asp:DropDownList>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="QNO">
												<HeaderStyle HorizontalAlign="Left" Width="100%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												<ItemTemplate>
													<asp:DropDownList id="DrpQuestions" runat="server" Width="100%"></asp:DropDownList>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="CORRECT KEY">
												<HeaderStyle HorizontalAlign="Left" Width="100%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												<ItemTemplate>
													<asp:TextBox id="TxtQFrom" runat="server" Width="100%"></asp:TextBox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="WRONG KEY">
												<HeaderStyle HorizontalAlign="Left" Width="100%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
												<ItemTemplate>
													<asp:TextBox id="TxtQTo" runat="server" Width="100%"></asp:TextBox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="REMARKS">
												<HeaderStyle HorizontalAlign="Left" Width="50px" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												<ItemTemplate>
													<asp:TextBox id="TxtRemarks" runat="server" Width="100%"></asp:TextBox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="LECTURER">
												<HeaderStyle HorizontalAlign="Left" Width="50px" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												<ItemTemplate>
													<asp:TextBox id="TxtLect" runat="server" Width="100%"></asp:TextBox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="MOBILE">
												<HeaderStyle HorizontalAlign="Left" Width="20px" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												<ItemTemplate>
													<asp:TextBox id="TxtLectMobile" runat="server" Width="100%"></asp:TextBox>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
									</asp:datagrid></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table4" height="35" cellSpacing="1" cellPadding="1" width="150" align="center"
							border="1">
							<TR>
								<TD align="center" width="50%"><asp:imagebutton id="ImageButton1" runat="server" Width="100%" ImageUrl="../../Images/NewImages/save.gif"
										Height="20px"></asp:imagebutton></TD>
								<TD align="center" width="50%"><asp:imagebutton id="ImageButton2" runat="server" Width="100%" ImageUrl="../../Images/NewImages/cancel.gif"
										Height="20px"></asp:imagebutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
