<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Objection_ExamDate_Creation.aspx.vb" Inherits="CollegeBoard.Objection_ExamEntry"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Objection_ExamEntry</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK id="Link1" href="../../Images/Login/StyleSheet_Report.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table8" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px" borderColor="#cc6633"
				cellSpacing="1" cellPadding="1" width="940" align="center" border="1">
				<TR>
					<TD align="center">
						<TABLE id="Table6" height="20" cellSpacing="1" cellPadding="1" align="center" border="1">
							<TR>
								<TD align="center"><asp:radiobutton id="RdbTestEntry" runat="server" CssClass="lABLES" Width="100%" Text="Test Entry"
										GroupName="Objections" AutoPostBack="True"></asp:radiobutton></TD>
								<TD align="center"><asp:radiobutton id="RdbTest" runat="server" CssClass="lABLES" Width="100%" Text="Tests View" GroupName="Objections"
										AutoPostBack="True"></asp:radiobutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center"><asp:panel id="PnlEntry" runat="server" Height="168px" Visible="False">
							<TABLE id="Table9" style="HEIGHT: 152px" cellSpacing="1" cellPadding="1" width="493" align="center"
								border="1">
								<TR>
									<TD style="HEIGHT: 23px" align="center"><asp:label id="Label11" runat="server" CssClass="SubHeading1" Width="100%" Height="23px" Font-Size="X-Small">OBJECTION TEST CREATION</asp:label></TD>
								</TR>
								<TR>
									<TD align="center">
										<TABLE id="Table10" style="WIDTH: 359px; HEIGHT: 72px" cellSpacing="1" cellPadding="1"
											width="359" align="center" border="1">
											<TR>
												<TD style="WIDTH: 91px; HEIGHT: 6px" align="center" width="91"><asp:label id="Label10" runat="server" CssClass="Lables" Width="100%">Exam.Name</asp:label></TD>
												<TD style="HEIGHT: 6px" align="center" width="75%"><asp:dropdownlist id="DrpExamName" runat="server" Width="100%"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 91px" align="center" width="91">
													<asp:label id="Label2" runat="server" Width="100%" CssClass="Lables">Paper.Setter</asp:label></TD>
												<TD align="left" width="75%">
													<asp:dropdownlist id="DrpPaperSetter" runat="server" Width="100%"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 91px" align="center" width="91"><asp:label id="Label9" runat="server" CssClass="Lables" Width="100%">Test.Date</asp:label></TD>
												<TD align="left" width="75%"><asp:textbox id="TxtTestDate" runat="server" Width="104px"></asp:textbox><asp:label id="LblHelp" runat="server" Width="136px" Font-Bold="True" ForeColor="Red"> Ex:{"DD/MM/YYYY"}</asp:label></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 91px" align="center"><asp:label id="Label7" runat="server" CssClass="Lables" Width="100%">Description</asp:label></TD>
												<TD align="center"><asp:textbox id="TxtDesc" runat="server" Width="100%"></asp:textbox></TD>
											</TR>
											<TR>
												<TD align="center" colSpan="2" vAlign="bottom">
													<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="60%" align="center" border="1">
														<TR>
															<TD align="center" height="100%" width="70%">
																<asp:label id="LblNSub" runat="server" CssClass="Lables" Width="100%">No.of.Subjects</asp:label></TD>
															<TD align="center" width="15%">
																<asp:textbox id="TxtNsub" runat="server" Height="15px"></asp:textbox></TD>
															<TD align="left" width="15%" height="100%">
																<asp:imagebutton id="IbtnGo" runat="server" Width="40px" Height="16px" ImageUrl="../../Images/NewImages/go.gif"></asp:imagebutton></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD vAlign="middle" align="center" colSpan="2">
													<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="340" align="center" border="1">
														<TR>
															<TD align="center"><asp:datagrid id="DgSubjects" runat="server" CssClass="Gridmain" Width="100%" Visible="False"
																	AutoGenerateColumns="False">
																	<ItemStyle Height="17px"></ItemStyle>
																	<HeaderStyle Height="20px" CssClass="GridHeader"></HeaderStyle>
																	<Columns>
																		<asp:BoundColumn DataField="SNO" HeaderText="SNO">
																			<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																			<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:TemplateColumn HeaderText="SUBJECT">
																			<HeaderStyle HorizontalAlign="Left" Width="100%" VerticalAlign="Middle"></HeaderStyle>
																			<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																			<ItemTemplate>
																				<asp:DropDownList id="DrpSbj" runat="server" Width="100%"></asp:DropDownList>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn HeaderText="QNO.FROM">
																			<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																			<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																			<ItemTemplate>
																				<asp:TextBox id="TextBox1" runat="server"></asp:TextBox>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn HeaderText="QNO.TO">
																			<HeaderStyle HorizontalAlign="Center" Width="100%" VerticalAlign="Middle"></HeaderStyle>
																			<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																			<ItemTemplate>
																				<asp:TextBox id="TextBox2" runat="server"></asp:TextBox>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																	</Columns>
																</asp:datagrid></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
										<TABLE id="Table11" cellSpacing="1" cellPadding="1" align="center" border="1">
											<TR>
												<TD align="center"><asp:imagebutton id="IBtnSave" runat="server" Width="75px" Height="22px" ImageUrl="../../Images/NewImages/save.gif"></asp:imagebutton></TD>
												<TD align="center"><asp:imagebutton id="IbtnCancel" runat="server" Width="75px" Height="22px" ImageUrl="../../Images/NewImages/cancel.gif"></asp:imagebutton></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE></TD>
				</TR>
				</asp:panel></TD></TR>
				<TR>
					<TD align="center"><asp:panel id="PnlView" runat="server" Visible="False">
							<TABLE id="Table12" style="WIDTH: 469px" cellSpacing="1" cellPadding="1" width="469" align="center"
								border="1">
								<TR>
									<TD align="center">
										<asp:label id="Label13" runat="server" Width="100%" CssClass="SubHeading1" Font-Size="X-Small">OBJECTION TESTS VIEW</asp:label></TD>
								</TR>
								<TR>
									<TD align="center" width="100%" height="25">
										<TABLE id="Table13" cellSpacing="1" cellPadding="1" width="300" align="center" border="1">
											<TR>
												<TD align="center" width="25%">
													<asp:Label id="Label12" runat="server" Width="100%" CssClass="Subheading1">Exam.Name</asp:Label></TD>
												<TD align="center" width="75%">
													<asp:DropDownList id="DrpExamName1" runat="server" AutoPostBack="True" Width="100%"></asp:DropDownList></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD align="center" width="100%" height="25">
										<asp:DataGrid id="DgTestView" runat="server" Width="400px" CssClass="gridmain" Visible="False"
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
												<asp:BoundColumn DataField="OBJEXAMNAME" HeaderText="EXAMNAME">
													<HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle"></HeaderStyle>
													<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="OBJTESTSLNO" HeaderText="TESTSLNO">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="OBJTESTDATE" HeaderText="TESTDATE">
													<HeaderStyle HorizontalAlign="Left" Width="50px" VerticalAlign="Middle"></HeaderStyle>
													<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="OBJTESTDESC" HeaderText="DESCRIPTION">
													<HeaderStyle HorizontalAlign="Center" Width="50px" VerticalAlign="Middle"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="EBNAME" HeaderText="PAPER SETTER"></asp:BoundColumn>
											</Columns>
											<PagerStyle VerticalAlign="Middle" Font-Bold="True" HorizontalAlign="Center" ForeColor="#0000C0"
												Mode="NumericPages"></PagerStyle>
										</asp:DataGrid></TD>
								</TR>
							</TABLE>
						</asp:panel></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
