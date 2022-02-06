<%@ Page Language="vb" AutoEventWireup="True" EnableViewState="True" Codebehind="Objection_ObjectionEntry.aspx.vb" Inherits="CollegeBoard.Objection_ObjectionEntry"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Objection_ObjectionEntry</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK id="Link1" href="../../Images/Login/StyleSheet_Report.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="960" align="center" border="1">
				<TR>
					<TD align="center"><asp:label id="Label1" runat="server" CssClass="subheading1" Width="100%" Font-Size="Small">Question Paper Objections Entry</asp:label></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="500" align="center" border="1">
							<TR>
								<TD align="center" width="20%"><asp:label id="Label2" runat="server" CssClass="lables" Width="100%">ExamBranch</asp:label></TD>
								<TD align="center" width="30%"><asp:dropdownlist id="DrpExamBranch" runat="server" Width="100%"></asp:dropdownlist></TD>
								<TD align="center" width="20%"><asp:label id="Label5" runat="server" CssClass="lables" Width="100%">LandLine</asp:label></TD>
								<TD align="center" width="30%"><asp:textbox id="TxtLandLine" runat="server" Width="100%"></asp:textbox></TD>
							</TR>
							<TR>
								<TD align="center"><asp:label id="Label3" runat="server" CssClass="lables" Width="100%">Principal</asp:label></TD>
								<TD align="center"><asp:textbox id="TxtPrince" runat="server" Width="100%"></asp:textbox></TD>
								<TD align="center"><asp:label id="Label6" runat="server" CssClass="Lables" Width="100%">Mobile.No</asp:label></TD>
								<TD align="center"><asp:textbox id="TxtPrinceMob" runat="server" Width="100%"></asp:textbox></TD>
							</TR>
							<TR>
								<TD align="center"><asp:label id="Label4" runat="server" CssClass="Lables" Width="100%">ExamName</asp:label></TD>
								<TD align="center"><asp:dropdownlist id="DrpExamName" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								<TD align="center"><asp:label id="Label7" runat="server" CssClass="lables" Width="100%">ExamDate</asp:label></TD>
								<TD align="center"><asp:dropdownlist id="DrpExamDate" runat="server" Width="100%"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD align="center"><asp:label id="Label8" runat="server" CssClass="Lables" Width="100%">No.Of.Corrections</asp:label></TD>
								<TD align="center"><asp:textbox id="TxtCorrections" runat="server" Width="100%"></asp:textbox></TD>
								<TD align="left" colSpan="2"><asp:imagebutton id="IbtGo" runat="server" Width="45px" ImageUrl="../../Images/NewImages/go.gif"
										Height="20px"></asp:imagebutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="100%" align="center" border="1">
							<TR>
								<TD align="center" width="70%">
									<asp:label id="LblSbjDetail" runat="server" Width="100%" CssClass="lables" Height="18px" BackColor="#FFE0C0"
										ForeColor="Blue" Font-Size="Smaller"></asp:label></TD>
								<TD align="center" width="30%">
									<asp:label id="LblPS" runat="server" Width="100%" CssClass="lables" Height="18px" BackColor="#FFE0C0"
										ForeColor="Red" Font-Bold="True"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center"><asp:datagrid id="DgTrans" runat="server" CssClass="GridMain" Width="750px" AutoGenerateColumns="False">
							<ItemStyle Height="25px"></ItemStyle>
							<HeaderStyle Height="25px" CssClass="GridHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="SNO" HeaderText="SNO">
									<HeaderStyle Wrap="False" HorizontalAlign="Center" Width="15px" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="SUBJECT">
									<HeaderStyle HorizontalAlign="Left" Width="60px" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
									<ItemTemplate>
										<asp:DropDownList id="DrpSbj" runat="server" Width="120px" AutoPostBack="True" OnSelectedIndexChanged="DrpSbj_SelectedIndexChanged"></asp:DropDownList>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="QUESTION">
									<ItemTemplate>
										<asp:DropDownList id="DrpQstn" runat="server" Width="60px"></asp:DropDownList>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn Visible="False" HeaderText="QUESTION">
									<HeaderStyle HorizontalAlign="Left" Width="20px" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
									<ItemTemplate>
										<asp:TextBox id="TxtQno" runat="server" Width="65px" Height="20px"></asp:TextBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="WRONG.KEY">
									<HeaderStyle HorizontalAlign="Left" Width="10px"></HeaderStyle>
									<ItemStyle VerticalAlign="Middle"></ItemStyle>
									<ItemTemplate>
										<asp:TextBox id="TxtWKey" runat="server" Width="75px" Height="20px"></asp:TextBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="CORRECT.KEY">
									<HeaderStyle HorizontalAlign="Left" Width="10px" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
									<ItemTemplate>
										<asp:TextBox id="TxtCKey" runat="server" Width="85px" Height="20px"></asp:TextBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="REMARKS">
									<HeaderStyle HorizontalAlign="Left" Width="80px" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
									<ItemTemplate>
										<asp:TextBox id="TxtRemarks" runat="server" Width="300px" Height="20px" ForeColor="#C04000" TextMode="MultiLine"></asp:TextBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="LECTURER">
									<HeaderStyle HorizontalAlign="Left" Width="80px" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
									<ItemTemplate>
										<asp:TextBox id="TxtLect" runat="server" Width="150px" Height="20px"></asp:TextBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="MOBILE">
									<HeaderStyle HorizontalAlign="Left" Height="20px" Width="20px" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
									<ItemTemplate>
										<asp:TextBox id="TxtLectMob" runat="server" Width="100px" Height="20px"></asp:TextBox>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table3" style="WIDTH: 93px; HEIGHT: 32px" cellSpacing="1" cellPadding="1" width="93"
							align="center" border="1">
							<TR>
								<TD align="center"><asp:imagebutton id="IbtnSave" runat="server" Width="100%" ImageUrl="../../Images/NewImages/save.gif"
										Height="22px"></asp:imagebutton></TD>
								<TD align="center"><asp:imagebutton id="ImageButton2" runat="server" Width="80px" ImageUrl="../../Images/NewImages/cancel.gif"
										Height="22px"></asp:imagebutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
