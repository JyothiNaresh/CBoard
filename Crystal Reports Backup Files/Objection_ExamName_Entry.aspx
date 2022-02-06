<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Objection_ExamName_Entry.aspx.vb" Inherits="CollegeBoard.Objection_Exam_Entry"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Objection_Exam_Entry</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK id="Link1" href="../../Images/Login/StyleSheet_Report.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table5" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px" borderColor="#cc6633"
				cellSpacing="1" cellPadding="1" width="992" align="center" border="1">
				<TR>
					<TD align="center">
						<TABLE id="Table6" height="20" cellSpacing="1" cellPadding="1" align="center" border="1">
							<TR>
								<TD align="center"><asp:radiobutton id="RdbExamEntry" runat="server" CssClass="lABLES" Width="100%" Text="Exams Entry"
										GroupName="Objections" AutoPostBack="True"></asp:radiobutton></TD>
								<TD align="center"><asp:radiobutton id="RdbExams" runat="server" CssClass="lABLES" Width="100%" Text="Exams View" GroupName="Objections"
										AutoPostBack="True"></asp:radiobutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center"><asp:panel id="PnlEntry" runat="server" Visible="False">
							<TABLE id="Table2" style="HEIGHT: 152px" cellSpacing="1" cellPadding="1" width="493" align="center"
								border="1">
								<TBODY>
									<TR>
										<TD style="HEIGHT: 23px" align="center"><asp:label id="Label1" runat="server" Font-Size="X-Small" CssClass="SubHeading1" Width="100%"
												Height="23px">OBJECTION EXAMNAME ENTRY</asp:label></TD>
									</TR>
									<TR>
										<TD align="center">
											<TABLE id="Table3" style="WIDTH: 359px; HEIGHT: 72px" cellSpacing="1" cellPadding="1" width="359"
												align="center" border="1">
												<TR>
													<TD style="WIDTH: 91px" align="center" width="91"><asp:label id="Label2" runat="server" CssClass="SubHeading1" Width="100%">Exam.Name</asp:label></TD>
													<TD align="center" width="75%"><asp:textbox id="TxtExamName" runat="server" Width="100%"></asp:textbox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 91px" align="center"><asp:label id="Label3" runat="server" CssClass="SubHeading1" Width="100%">Description</asp:label></TD>
													<TD align="center"><asp:textbox id="TxtDesc" runat="server" Width="100%"></asp:textbox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 91px; HEIGHT: 15px" align="center"><asp:label id="Label4" runat="server" CssClass="SubHeading1" Width="100%">Status</asp:label></TD>
													<TD style="HEIGHT: 15px" align="center">
														<asp:DropDownList id="DrpActive" runat="server" Width="100%">
															<asp:ListItem Value="ACTIVE" Selected="True">---ACTIVE---</asp:ListItem>
															<asp:ListItem Value="INACTIVE">---INACTIVE---</asp:ListItem>
														</asp:DropDownList></TD>
												</TR>
											</TABLE>
											<TABLE id="Table4" cellSpacing="1" cellPadding="1" align="center" border="1">
												<TR>
													<TD align="center"><asp:imagebutton id="IBtnSave" runat="server" Width="75px" Height="22px" ImageUrl="../../Images/NewImages/save.gif"></asp:imagebutton></TD>
													<TD align="center"><asp:imagebutton id="IbtnCancel" runat="server" Width="75px" Height="22px" ImageUrl="../../Images/NewImages/cancel.gif"></asp:imagebutton></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
								</TBODY>
							</TABLE></TD>
				</TR>
				</asp:panel>
				<TR>
					<TD align="center"><asp:panel id="PnlView" runat="server" Visible="False">
							<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="611" align="center" border="1">
								<TR>
									<TD align="center">
										<asp:label id="Label5" runat="server" Width="100%" CssClass="SubHeading1" Font-Size="X-Small">OBJECTION EXAMNAMES VIEW</asp:label></TD>
								</TR>
								<TR>
									<TD align="center" width="100%" height="25">
										<asp:DataGrid id="DgExamView" runat="server" Width="500px" CssClass="gridmain" Visible="False"
											AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True">
											<ItemStyle HorizontalAlign="Center" Height="20px"></ItemStyle>
											<HeaderStyle Height="25px" CssClass="GridHeader"></HeaderStyle>
											<Columns>
												<asp:TemplateColumn HeaderText="SNO">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
													<ItemTemplate>
														<%#Container.DataSetIndex+1 %>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn Visible="False" DataField="OBJEXAMSLNO" HeaderText="EXAMSLNO">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="OBJEXAMNAME" HeaderText="EXAMNAME">
													<HeaderStyle HorizontalAlign="Left" Width="50px" VerticalAlign="Middle"></HeaderStyle>
													<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="OBJDESCRIPTION" HeaderText="DESCRIPTION">
													<HeaderStyle HorizontalAlign="Left" Width="50px" VerticalAlign="Middle"></HeaderStyle>
													<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="OBJEXAMSTATUS" HeaderText="STATUS">
													<HeaderStyle HorizontalAlign="Left" Width="10px" VerticalAlign="Middle"></HeaderStyle>
													<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												</asp:BoundColumn>
											</Columns>
											<PagerStyle VerticalAlign="Middle" Font-Bold="True" HorizontalAlign="Center" ForeColor="#0000C0"
												Mode="NumericPages"></PagerStyle>
										</asp:DataGrid></TD>
								</TR>
							</TABLE>
						</asp:panel>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
