<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MastersBatch.aspx.vb" Inherits="CollegeBoard.MastersBatch" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>MastersBatch</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK id="Link1" rel="stylesheet" type="text/css" href="../../../Images/Login/StyleSheet.css">
		<script language="JavaScript" type="text/javascript" src="../../Include/ExamScheduleHome.js"></script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form onkeydown="return pressCancel(cmdCancel);" id="Topics" method="post" runat="server">
			<asp:textbox style="Z-INDEX: 103; POSITION: absolute; TOP: 16px; LEFT: 16px" id="txtSetfocus"
				runat="server" Height="32px" Width="0px"></asp:textbox>
			<TABLE style="Z-INDEX: 105; POSITION: absolute; TOP: 8px; LEFT: 8px" id="Table7" border="0"
				cellSpacing="1" cellPadding="1" width="100%">
				<TR>
					<TD vAlign="top" align="center">
						<TABLE style="WIDTH: 877px; HEIGHT: 331px" id="Table1" border="1" cellSpacing="0" cellPadding="1"
							width="877" align="center">
							<TR>
								<TD vAlign="top" align="center">
									<TABLE style="WIDTH: 906px; HEIGHT: 312px" id="Table2" class="panel" border="0" cellSpacing="0"
										cellPadding="1" align="center">
										<TR>
											<TD style="HEIGHT: 26px" vAlign="top" align="center">
												<TABLE style="HEIGHT: 25px" id="Table3" border="0" cellSpacing="1" cellPadding="1" width="100%">
													<TR>
														<TD>
															<CENTER><asp:label id="lblHeading" runat="server" Width="100%" CssClass="SubHeading1" Font-Bold="True">Board&nbsp;Enrollment&nbsp;Masters&nbsp;Entry&nbsp;(Batch&nbsp; Mode)</asp:label></CENTER>
														</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 26px" vAlign="top" align="center">
												<TABLE style="WIDTH: 253px; HEIGHT: 23px" id="Table6" border="0" cellSpacing="1" cellPadding="1"
													width="253">
													<TR>
														<TD><asp:label id="LblCourse" runat="server" CssClass="Lables">Select</asp:label></TD>
														<TD><asp:dropdownlist id="DrpBoardMaster" runat="server" Width="211px" CssClass=" " AutoPostBack="True">
																<asp:ListItem Value="1" Selected="True">Board Dist</asp:ListItem>
																<asp:ListItem Value="2">Previous Exam</asp:ListItem>
																<asp:ListItem Value="3">Year of Pass</asp:ListItem>
																<asp:ListItem Value="4">Category</asp:ListItem>
																<asp:ListItem Value="5">Medium</asp:ListItem>
																<asp:ListItem Value="6">Religion</asp:ListItem>
																<asp:ListItem Value="7">Caste</asp:ListItem>
																<asp:ListItem Value="8">Physical Status</asp:ListItem>
																<asp:ListItem Value="9">Subject</asp:ListItem>
																<asp:ListItem Value="10">Group</asp:ListItem>
																<asp:ListItem Value="11">Second Language</asp:ListItem>
																<asp:ListItem Value="12">College Type</asp:ListItem>
																<asp:ListItem Value="13">Corporate College</asp:ListItem>
																<asp:ListItem Value="14">Sub Caste</asp:ListItem>
															</asp:dropdownlist></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 18px" colSpan="2" align="center">
												<TABLE style="WIDTH: 234px; HEIGHT: 16px" id="Table4" border="0" cellSpacing="0" cellPadding="0"
													width="234" runat="server">
													<TR>
														<TD style="WIDTH: 73px"><asp:label id="Label1" runat="server" Width="39px" CssClass="Lables">Caste&nbsp;*</asp:label></TD>
														<TD align="center"><asp:dropdownlist id="DrpCaste" runat="server" Height="24px" Width="211px" CssClass=" " AutoPostBack="False"></asp:dropdownlist></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD vAlign="top" align="center" style="HEIGHT: 168px"><asp:datagrid id="dgACT" tabIndex="1" runat="server" Width="100%" CssClass="GridMain" CellPadding="0"
													BorderWidth="0px" AutoGenerateColumns="False" BorderStyle="None" CellSpacing="2">
													<SelectedItemStyle Font-Bold="True"></SelectedItemStyle>
													<AlternatingItemStyle CssClass="GridAlternateItem"></AlternatingItemStyle>
													<ItemStyle CssClass="GridItem"></ItemStyle>
													<HeaderStyle Font-Bold="True" CssClass="GridHeader"></HeaderStyle>
													<FooterStyle BackColor="#D1CBCB"></FooterStyle>
													<Columns>
														<asp:BoundColumn DataField="DGSLNO" HeaderText="Sl. No.">
															<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn HeaderText="Code&amp;nbsp;*">
															<ItemTemplate>
																<asp:TextBox id="TxtCode" runat="server" Width="100px"></asp:TextBox>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Name&amp;nbsp;*">
															<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
															<ItemTemplate>
																<asp:TextBox id="txtName" onkeydown="return txtGridUpDown('Topics','dgACT','txtName');" tabIndex="2"
																	runat="server" Height="24px" Width="275px" CssClass=" " MaxLength="50"></asp:TextBox>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Descriptions">
															<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
															<ItemTemplate>
																<asp:TextBox id="txtDescription" onkeydown="return txtGridUpDown('Topics','dgACT','txtDescription');"
																	tabIndex="2" runat="server" Height="22px" Width="350px" CssClass=" " MaxLength="250"></asp:TextBox>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
													<PagerStyle Visible="False" HorizontalAlign="Center" BackColor="#D1CBCB"></PagerStyle>
												</asp:datagrid></TD>
										</TR>
										<TR>
											<TD vAlign="top" align="center" style="HEIGHT: 17px"><asp:imagebutton id="iBtnSave" accessKey="S" tabIndex="3" runat="server" Width="80px" Height="20px"
													ImageUrl="../../../Images/NewImages/save.gif"></asp:imagebutton><asp:imagebutton id="iBtnCancel" accessKey="C" tabIndex="4" runat="server" Width="80px" Height="20px"
													ImageUrl="../../../Images/NewImages/cancel.gif"></asp:imagebutton></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
