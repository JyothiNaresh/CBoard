<%@ Page Language="vb" AutoEventWireup="false" Codebehind="BoardDetailsEntry.aspx.vb" Inherits="CollegeBoard.BoardDetailsEntry" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Board Details Entry</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="JavaScript" type="text/javascript" src="../Include/CTExam.js"></script>
		<LINK id="Link1" href="../../Images/Login/StyleSheet.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" type="text/javascript" src="../Include/ExamScheduleHome.js"></script>
		<script language="javascript" type="text/javascript">
			
		function PressCancel(btn) {
		
		var iKeyCode = 0;
		
		
		if (window.event) 
			iKeyCode = window.event.keyCode;
		
		 if (iKeyCode==27){
				
				event.returnValue=false;
				event.cancel = true;
			
				btn.click();
				
				}
		} 
	
		</script>
	</HEAD>
	<BODY MS_POSITIONING="GridLayout">
		<form id="frmStuBoard" method="post" runat="server">
			<TABLE id="Table9" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD vAlign="top" align="center">
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" border="1">
							<TR>
								<TD vAlign="top" align="center">
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" border="0">
										<TR>
											<TD vAlign="top" align="center">
												<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" border="0">
													<TR>
														<TD vAlign="top" align="center">
															<asp:label id="LblHeading" runat="server" CssClass="SubHeading1" Width="100%"> Student Wise Board Details Mapping</asp:label></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD vAlign="top" align="center">
												<TABLE id="Table4" style="WIDTH: 226px; HEIGHT: 22px" cellSpacing="0" cellPadding="0" width="226"
													border="0">
													<TR>
														<TD>
															<asp:label id="Label2" runat="server" CssClass="Lables" Width="100%">AdmNo</asp:label></TD>
														<TD>
															<asp:TextBox id="txtAdmNo" runat="server" Width="100px" MaxLength="8"></asp:TextBox></TD>
														<TD>
															<asp:imagebutton id="iBtnGo" accessKey="G" runat="server" Width="80px" Height="20px" ImageUrl="../../Images/NewImages/search.gif"></asp:imagebutton></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 21px">
												<HR style="WIDTH: 526px" SIZE="1">
											</TD>
										</TR>
										<TR>
											<TD vAlign="top" align="center">
												<TABLE id="Table7" style="WIDTH: 533px; HEIGHT: 48px" cellSpacing="0" cellPadding="0" width="533"
													border="0">
													<TR>
														<TD vAlign="top" align="center">
															<asp:label id="Label7" runat="server" CssClass="Lables" Width="100%">Exam&nbsp;Branch</asp:label></TD>
														<TD vAlign="top" align="left">
															<asp:dropdownlist id="drpExamBranch" runat="server" CssClass=" " Width="200px" AutoPostBack="True"></asp:dropdownlist></TD>
														<TD vAlign="top" align="center">
															<asp:label id="lblCourse" runat="server" CssClass="Lables" Width="100%">Course</asp:label></TD>
														<TD vAlign="top" align="left">
															<asp:dropdownlist id="drpCourse" runat="server" CssClass=" " Width="200px" AutoPostBack="True"></asp:dropdownlist></TD>
														<TD vAlign="top" align="left"></TD>
													</TR>
													<TR>
														<TD vAlign="top" align="center">
															<asp:label id="lblGroup" runat="server" CssClass="Lables" Width="100%">Group</asp:label></TD>
														<TD vAlign="top" align="left">
															<asp:dropdownlist id="drpGroup" runat="server" CssClass=" " Width="200px" AutoPostBack="True"></asp:dropdownlist></TD>
														<TD vAlign="top" align="center">
															<asp:label id="lblBatch" runat="server" CssClass="Lables" Width="100%">Batch</asp:label></TD>
														<TD vAlign="top" align="left">
															<asp:dropdownlist id="drpBatch" runat="server" CssClass=" " Width="200px" AutoPostBack="True"></asp:dropdownlist></TD>
														<TD vAlign="top" align="left"></TD>
													</TR>
													<TR>
														<TD vAlign="top" align="center">
															<asp:label id="Label9" runat="server" CssClass="Lables" Width="100%">Section</asp:label></TD>
														<TD vAlign="top" align="left">
															<asp:dropdownlist id="drpSection" runat="server" CssClass=" " Width="200px" AutoPostBack="True"></asp:dropdownlist></TD>
														<TD></TD>
														<TD vAlign="top" align="right" colSpan="2"></TD>
														<TD vAlign="top" align="right"></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD vAlign="top" align="center">
												<TABLE id="Table5" cellSpacing="1" cellPadding="1" border="0">
													<TR>
														<TD vAlign="top" align="center">
															<asp:datagrid id="DGStuBoardMap" runat="server" CssClass="GridMain" Width="100%" CellSpacing="2"
																BorderWidth="0px" BorderStyle="None" CellPadding="0" AutoGenerateColumns="False">
																<AlternatingItemStyle CssClass="GridAlternateItem"></AlternatingItemStyle>
																<ItemStyle CssClass="GridItem"></ItemStyle>
																<HeaderStyle CssClass="GridHeader"></HeaderStyle>
																<Columns>
																	<asp:TemplateColumn HeaderText="Sl.No">
																		<HeaderStyle HorizontalAlign="Center" Width="15px" VerticalAlign="Middle"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Center"></ItemStyle>
																		<ItemTemplate>
																			<asp:Label id=Label1 runat="server" Text='<%# DataBinder.Eval(Container, "DataSetIndex") +1 %>'>
																			</asp:Label>
																		</ItemTemplate>
																	</asp:TemplateColumn>
																	<asp:BoundColumn Visible="False" DataField="ADMSLNO" HeaderText="ADM SLNO">
																		<HeaderStyle HorizontalAlign="Center" Width="1px" VerticalAlign="Middle"></HeaderStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="ADMNO" HeaderText="Adm.No">
																		<HeaderStyle Wrap="False" HorizontalAlign="Center" Width="100px" VerticalAlign="Middle"></HeaderStyle>
																		<ItemStyle Wrap="False"></ItemStyle>
																		<FooterStyle Wrap="False"></FooterStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="STUNAME" HeaderText="Name">
																		<HeaderStyle Wrap="False" HorizontalAlign="Center" Width="100px" VerticalAlign="Middle"></HeaderStyle>
																		<ItemStyle Wrap="False"></ItemStyle>
																		<FooterStyle Wrap="False"></FooterStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn Visible="False" DataField="FATHERNAME" HeaderText="Father&amp;nbsp;Name">
																		<HeaderStyle Wrap="False" Width="200px"></HeaderStyle>
																		<ItemStyle Wrap="False"></ItemStyle>
																		<FooterStyle Wrap="False"></FooterStyle>
																	</asp:BoundColumn>
																	<asp:TemplateColumn HeaderText="Board&amp;nbsp;Id">
																		<HeaderStyle HorizontalAlign="Center" Width="50px" VerticalAlign="Middle"></HeaderStyle>
																		<ItemTemplate>
																			<asp:TextBox id=txtBoardId onkeydown="return txtGridUpDown('frmStuBoard','DGStuBoardMap','txtBoardId');" runat="server" Width="90px" CssClass=" " Text='<% #Container.Dataitem("BOARDIDNO")%>' MaxLength="5">
																			</asp:TextBox>
																		</ItemTemplate>
																	</asp:TemplateColumn>
																	<asp:TemplateColumn HeaderText="Board&amp;nbsp;College&amp;nbsp;Code">
																		<HeaderStyle HorizontalAlign="Center" Width="50px" VerticalAlign="Middle"></HeaderStyle>
																		<ItemTemplate>
																			<asp:TextBox id="txtBoardCollCode" onkeydown="return txtGridUpDown('frmStuBoard','DGStuBoardMap','txtBoardCollCode');" runat="server" Width="90px" CssClass=" " Text='<% #Container.Dataitem("BOARDCOLLCODE")%>' MaxLength="10">
																			</asp:TextBox>
																		</ItemTemplate>
																	</asp:TemplateColumn>
																	<asp:TemplateColumn HeaderText="Caste">
																		<ItemTemplate>
																			<asp:DropDownList ID="DrpCaste" TabIndex="15" Width="100" Runat="server" DataTextField="CASTENAME" DataValueField="CASTESLNO" DataSource="<%# FileCasteDataset() %>" SelectedIndex='<%# CasteGetGridCombIndex(DataBinder.Eval(Container.DataItem,"CASTESLNO").tostring())%>'>
																			</asp:DropDownList>
																		</ItemTemplate>
																	</asp:TemplateColumn>
																	<asp:TemplateColumn HeaderText="Date&amp;nbsp;Of&amp;nbsp;Birth">
																		<HeaderStyle HorizontalAlign="Center" Width="50px" VerticalAlign="Middle"></HeaderStyle>
																		<ItemTemplate>
																			<asp:TextBox id="txtDOB" onkeydown="return txtGridUpDown('frmStuBoard','DGStuBoardMap','txtDOB');" runat="server" Width="90px" CssClass=" " Text='<% #Container.Dataitem("DOB")%>' MaxLength="10">
																			</asp:TextBox>
																		</ItemTemplate>
																	</asp:TemplateColumn>
																	<asp:TemplateColumn HeaderText="Sex">
																		<ItemTemplate>
																			<asp:DropDownList id=DrpGender tabIndex=15 Width="100" Runat="server" SelectedIndex='<%# GenderGetGridCombIndex(DataBinder.Eval(Container.DataItem,"SEX").tostring())%>' DataSource="<%# FileGenderDataset() %>" DataTextField="GENDER" DataValueField="SEX">
																			</asp:DropDownList>
																		</ItemTemplate>
																	</asp:TemplateColumn>
																</Columns>
															</asp:datagrid></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD vAlign="top" align="center"></TD>
										</TR>
										<TR>
											<TD vAlign="top" align="center">
												<TABLE id="Table6" style="WIDTH: 697px" cellSpacing="1" cellPadding="1" width="697" border="0">
													<TR>
														<TD vAlign="top" align="center">
															<asp:imagebutton id="iBtnSave" accessKey="S" tabIndex="3" runat="server" Width="80px" Height="20px"
																ImageUrl="../../Images/NewImages/save.gif"></asp:imagebutton>&nbsp;
															<asp:imagebutton id="iBtnCancle" accessKey="C" tabIndex="3" runat="server" Width="80px" Visible="False"
																Height="20px" ImageUrl="../../Images/NewImages/cancel.gif"></asp:imagebutton>
															<asp:DropDownList id="DrpDummayStatus" runat="server" Width="0px"></asp:DropDownList>
															<asp:DropDownList id="DrpDummyGender" runat="server" Width="0px"></asp:DropDownList></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<BR>
		<BR>
		</FROM>
	</BODY>
</HTML>
