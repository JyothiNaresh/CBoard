<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Exam_Objections_Entry.aspx.vb" Inherits="CollegeBoard.Exam_Objections_Entry"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Exam_Objections_Entry</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK id="Link1" href="../../../Images/Login/StyleSheet_Report.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" borderColor="#ff9966"
				cellSpacing="1" cellPadding="1" width="100%" align="center" border="1">
				<TR>
					<TD align="center"><asp:label id="Label1" runat="server" Font-Size="Small" Width="100%" CssClass="subheading1">Question Paper Objections Entry</asp:label></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table2" borderColor="#996633" cellSpacing="1" cellPadding="1" width="70%" align="center"
							border="1">
							<TR>
								<TD style="HEIGHT: 10px" align="center" width="10%"><asp:label id="Label9" runat="server" Width="100%" CssClass="lables">ExamDate</asp:label></TD>
								<TD style="HEIGHT: 10px" align="center" width="10%"><asp:dropdownlist id="DrpExamDate" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								<TD style="HEIGHT: 10px" align="center" width="8%"><asp:label id="Label10" runat="server" Width="100%" CssClass="Lables">ExamName</asp:label></TD>
								<TD style="HEIGHT: 10px" align="center" width="30%"><asp:dropdownlist id="DrpExamName" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 2px" align="center" width="10%"><asp:label id="Label2" runat="server" Width="100%" CssClass="lables">ExamBranch</asp:label></TD>
								<TD style="HEIGHT: 2px" align="center" width="10%"><asp:dropdownlist id="DrpExamBranch" runat="server" Width="100%"></asp:dropdownlist></TD>
								<TD style="HEIGHT: 2px" align="center" width="8%"><asp:label id="Label5" runat="server" Width="100%" CssClass="lables">LandLine</asp:label></TD>
								<TD style="HEIGHT: 2px" align="center" width="30%"><asp:textbox id="TxtLandLine" runat="server" Width="100%"></asp:textbox></TD>
							</TR>
							<TR>
								<TD align="center"><asp:label id="Label3" runat="server" Width="100%" CssClass="lables">Principal</asp:label></TD>
								<TD align="center"><asp:textbox id="TxtPrince" runat="server" Width="100%"></asp:textbox></TD>
								<TD align="center"><asp:label id="Label6" runat="server" Width="100%" CssClass="Lables">Mobile.No</asp:label></TD>
								<TD align="center"><asp:textbox id="TxtPrinceMob" runat="server" Width="100%"></asp:textbox></TD>
							</TR>
							<TR>
								<TD align="center"></TD>
								<TD align="center"><asp:label id="Label8" runat="server" Width="100%" CssClass="Lables">No.Of.Corrections</asp:label></TD>
								<TD align="left"><asp:textbox id="TxtCorrections" runat="server" Width="100%"></asp:textbox></TD>
								<TD align="left"><asp:imagebutton id="IbtGo" runat="server" Width="45px" Height="20px" ImageUrl="../../../Images/NewImages/go.gif"></asp:imagebutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="100%" align="center" border="1">
							<TR>
								<TD align="center" width="30%"><asp:label id="LblPS" runat="server" Width="100%" CssClass="lables" Height="18px" Font-Bold="True"
										ForeColor="Red" BackColor="#FFE0C0"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center"><asp:datagrid id="DgTrans" runat="server" Width="750px" CssClass="GridMain" AutoGenerateColumns="False">
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
										<asp:DropDownList id="DrpQstn" runat="server" Width="80px"></asp:DropDownList>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn Visible="False" HeaderText="QUESTION">
									<HeaderStyle HorizontalAlign="Left" Width="60px" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
									<ItemTemplate>
										<asp:TextBox id="TxtQno" runat="server" Width="65px" Height="20px"></asp:TextBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="GIVEN.KEY">
									<HeaderStyle HorizontalAlign="Left" Width="10px"></HeaderStyle>
									<ItemStyle VerticalAlign="Middle"></ItemStyle>
									<ItemTemplate>
										<asp:TextBox id="TxtWKey" runat="server" Width="75px" Height="20px"></asp:TextBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="CORRECT.KEY/DELETE">
									<HeaderStyle Wrap="False" HorizontalAlign="Left" Width="10px" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
									<ItemTemplate>
										<asp:TextBox id="TxtCKey" runat="server" Width="150px" Height="20px"></asp:TextBox>
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
								<TD align="center"><asp:imagebutton id="IbtnSave" runat="server" Width="100%" Height="22px" ImageUrl="../../../Images/NewImages/save.gif"></asp:imagebutton></TD>
								<TD align="center"><asp:imagebutton id="ImageButton2" runat="server" Width="80px" Height="22px" ImageUrl="../../../Images/NewImages/cancel.gif"></asp:imagebutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center"><asp:datagrid id="dgUserObj" runat="server" Width="75%" CssClass="gridmain" AutoGenerateColumns="False">
							<ItemStyle Height="23px"></ItemStyle>
							<HeaderStyle Height="25px" CssClass="gridheader"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="SNO">
									<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
									<ItemTemplate>
										<%#CONTAINER.DATASETINDEX+1%>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="NAME" HeaderText="SUBJECT">
									<HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="OBJQUESTIONNO" HeaderText="QNO">
									<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="OBJGIVENKEY" HeaderText="GIVENKEY">
									<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="OBJCORRECTKEY" HeaderText="REF.KEY"></asp:BoundColumn>
								<asp:BoundColumn DataField="OBJREMARKS" HeaderText="REMARKS">
									<HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="OBJLECTURER" HeaderText="LECTURER">
									<HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="OBJLECTMOBILE" HeaderText="MOBILE">
									<HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
