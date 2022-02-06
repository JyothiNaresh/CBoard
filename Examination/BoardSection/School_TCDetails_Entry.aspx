<%@ Page Language="vb" AutoEventWireup="false" Codebehind="School_TCDetails_Entry.aspx.vb" Inherits="CollegeBoard.School_TCDetails_Entry"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>School_TCDetails_Entry</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK id="Link1" rel="stylesheet" type="text/css" href="../../Images/Login/StyleSheet_Report.css">
		<script type="text/javascript" src="http://highslide.com/highslide/highslide-full.js"></script>
		<LINK rel="stylesheet" type="text/css" href="http://highslide.com/highslide/highslide.css">
		<script type="text/javascript">
			hs.graphicsDir = '../Include/Slide/Graphics/';
			hs.outlineType = 'rounded-white';
			hs.showCredits = false;
			hs.fadeInOut = true;
			hs.headingEval = 'this.a.title';
			hs.wrapperClassName = 'draggable-header';
		</script>
		<LINK rel="stylesheet" type="text/css" href="../../Styles/MultiComboSelect/jquery.multiselect.css">
		<LINK rel="stylesheet" type="text/css" href="../../Styles/MultiComboSelect/jquery.multiselect.filter.css">
		<LINK rel="stylesheet" type="text/css" href="../../Styles/MultiComboSelect/jquery-ui.css">
		<LINK rel="stylesheet" type="text/css" href="../../Styles/MultiComboSelect/prettify.css">
		<link rel="stylesheet" type="text/css" href="http://www.jeasyui.com/easyui/themes/default/easyui.css">
		<link rel="stylesheet" type="text/css" href="http://www.jeasyui.com/easyui/themes/icon.css">
		<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.js"></script>
		<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1/jquery-ui.min.js"></script>
		<script type="text/javascript" src="http://www.erichynds.com/examples/jquery-ui-multiselect-widget/src/jquery.multiselect.js"></script>
		<script type="text/javascript" src="http://www.erichynds.com/examples/jquery-ui-multiselect-widget/src/jquery.multiselect.filter.js"></script>
		<script type="text/javascript" src="http://www.erichynds.com/examples/jquery-ui-multiselect-widget/demos/assets/prettify.js"></script>
		<script type="text/javascript">
			$(function(){
				$("#lstmdEBranch").multiselect({multiple: false,noneSelectedText: "ExamBranch ",checkAllText:'Sel.All',uncheckAllText:'Rem.All',selectedList: 1}).multiselectfilter({width: 125,autoReset:true});
			});			
			function ToggleColumn()
			{
				$(".myColumn").toggle();
			}
		</script>
	</HEAD>
	<body onload="ToggleColumn();" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" autocomplete="off" runat="server">
			<TABLE id="Table0" border="0" cellSpacing="1" cellPadding="1" width="100%">
				<TBODY>
					<TR>
						<TD vAlign="top" align="center">
							<TABLE style="WIDTH: 397px; HEIGHT: 288px" id="Table1" class="Panel" border="0" cellSpacing="0"
								cellPadding="0">
								<TR>
									<TD align="center">
										<TABLE style="WIDTH: 360px; HEIGHT: 248px" id="Table2" border="0" cellSpacing="0" cellPadding="0">
											<TR>
												<TD class="DarkColor">
													<TABLE id="Table3" border="0" cellSpacing="0" cellPadding="0" width="100%">
														<TR>
															<TD vAlign="top" width="11"><IMG src="../../Images/Login/table-lcorw.gif" width="11" height="11"></TD>
															<TD class="SubHeading" align="center"><asp:label id="lblHeading" runat="server" Width="100%" CssClass="SubHeading1" Font-Bold="True">SCHOOOL TRANSFER CERTIFICATE</asp:label></TD>
															<TD vAlign="top" width="11"><IMG src="../../Images/Login/table-rcorw.gif" width="11" height="11"></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD class="TdBorder"><IMG src="../../Images/Login/spacer.gif" width="1" height="1"></TD>
											</TR>
											<TR>
												<TD class="TableBorder" vAlign="top" align="center">
													<TABLE id="Table4" border="0" cellSpacing="0" cellPadding="0" width="240">
														<TR>
															<TD style="HEIGHT: 13px" align="right"><asp:hyperlink style="Z-INDEX: 0" id="HyperLink1" runat="server" Font-Bold="True" ForeColor="Blue"
																	NavigateUrl="http://www.picresize.com" Font-Italic="True" Target="_blank">ToResize Images Goto : http://www.picresize.com</asp:hyperlink></TD>
														</TR>
														<TR>
															<TD align="center">
																<TABLE style="WIDTH: 425px; HEIGHT: 32px" id="Table5" class="tableborder" border="0" cellSpacing="1"
																	cellPadding="1" bgColor="#ffffcc">
																	<TR>
																		<TD bgColor="#ffffcc" vAlign="middle" colSpan="3" align="center">
																			<TABLE style="Z-INDEX: 0" id="Table7" border="0" cellSpacing="1" cellPadding="1" width="100%"
																				bgColor="#ffffcc" align="center">
																				<TR>
																					<TD class="tableborder" align="center"><asp:radiobutton style="Z-INDEX: 0" id="rdbDetailsEntry" runat="server" Width="115px" Font-Bold="True"
																							ForeColor="Green" Height="31px" Text="Details Entry" TextAlign="Left" GroupName="SCH_TC" AutoPostBack="True"></asp:radiobutton></TD>
																					<TD class="tableborder" align="center"><asp:radiobutton style="Z-INDEX: 0" id="rdbRequestEntry" runat="server" Width="115px" Font-Bold="True"
																							ForeColor="Green" Height="31px" Text="Request Entry" TextAlign="Left" GroupName="SCH_TC" AutoPostBack="True"></asp:radiobutton></TD>
																					<TD class="tableborder" align="center"><asp:radiobutton style="Z-INDEX: 0" id="rdbRequetAprvl" runat="server" Width="115px" Font-Bold="True"
																							ForeColor="Green" Text="Request Approval" TextAlign="Left" GroupName="SCH_TC" AutoPostBack="True"></asp:radiobutton></TD>
																				</TR>
																			</TABLE>
																		</TD>
																	</TR>
																	<TR class="tableborder">
																		<TD><asp:label id="Label4" runat="server" Width="100%" Font-Bold="True" ForeColor="Green"> Select Branch</asp:label></TD>
																		<TD><select style="WIDTH: 220px" id="lstmdEBranch" multiple name="Select1" runat="server"></select></TD>
																		<TD align="left"><asp:imagebutton accessKey="G" id="imgBtnGo" tabIndex="2" runat="server" Width="75px" Height="20px"
																				ImageUrl="../../Images/NewImages/search.gif"></asp:imagebutton></TD>
																	</TR>
																	<TR>
																		<TD style="HEIGHT: 20px" colSpan="3" align="center"><A style="Z-INDEX: 0; TEXT-TRANSFORM: capitalize; BACKGROUND-COLOR: thistle; COLOR: slateblue; FONT-WEIGHT: bold"
																				class="lables" href="javascript:ToggleColumn();">[Show/Hide] code</A></TD>
																	</TR>
																</TABLE>
																<TABLE style="WIDTH: 264px; HEIGHT: 112px" id="Table6" border="0" cellSpacing="1" cellPadding="1"
																	width="264">
																	<TR>
																		<TD align="center"><asp:datagrid style="Z-INDEX: 0" id="dgTCDetails" runat="server" Width="900px" CssClass="GridMain"
																				CellSpacing="2" BorderWidth="0px" BorderStyle="None" CellPadding="0" AutoGenerateColumns="False" AllowPaging="True"
																				AllowSorting="True" PageSize="50">
																				<EditItemStyle Wrap="False"></EditItemStyle>
																				<AlternatingItemStyle CssClass="GridAlternateItem"></AlternatingItemStyle>
																				<ItemStyle CssClass="GridItem" BackColor="White"></ItemStyle>
																				<HeaderStyle CssClass="GridHeader"></HeaderStyle>
																				<Columns>
																					<asp:TemplateColumn HeaderText="Sl.No">
																						<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																						<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																						<ItemTemplate>
																							<asp:Label id="Label2" runat="server" Text='<%# DataBinder.Eval(Container, "DataSetIndex") +1 %>'>
																							</asp:Label>
																						</ItemTemplate>
																					</asp:TemplateColumn>
																					<asp:BoundColumn DataField="ADMNO" HeaderText="ADMNO">
																						<HeaderStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></HeaderStyle>
																						<ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																						<FooterStyle Wrap="False"></FooterStyle>
																					</asp:BoundColumn>
																					<asp:BoundColumn DataField="NAME" HeaderText="NAME">
																						<HeaderStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																						<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																						<FooterStyle Wrap="False"></FooterStyle>
																					</asp:BoundColumn>
																					<asp:BoundColumn DataField="CODE" HeaderText="CODE">
																						<HeaderStyle Wrap="False" CssClass="myColumn"></HeaderStyle>
																						<ItemStyle Wrap="False" HorizontalAlign="Left" CssClass="myColumn" VerticalAlign="Middle"></ItemStyle>
																						<FooterStyle Wrap="False"></FooterStyle>
																					</asp:BoundColumn>
																					<asp:BoundColumn DataField="PAIDPER" HeaderText="PAID(%)">
																						<ItemStyle Font-Bold="True" HorizontalAlign="Right" ForeColor="#000099" VerticalAlign="Middle"
																							BackColor="#FFFFCC"></ItemStyle>
																					</asp:BoundColumn>
																					<asp:TemplateColumn HeaderText="TC_BOOKNO">
																						<ItemStyle Wrap="False"></ItemStyle>
																						<ItemTemplate>
																							<asp:TextBox id=txtTCBookNO runat="server" Width="100px" Height="20px" Text='<% #Container.Dataitem("TCBOOKNO")%>'>
																							</asp:TextBox>
																						</ItemTemplate>
																					</asp:TemplateColumn>
																					<asp:TemplateColumn HeaderText="TCNO">
																						<ItemStyle Wrap="False"></ItemStyle>
																						<ItemTemplate>
																							<asp:TextBox style="Z-INDEX: 0" id=txtTCNO runat="server" Width="100px" Height="20px" Text='<% #Container.Dataitem("TCNO")%>'>
																							</asp:TextBox>
																						</ItemTemplate>
																					</asp:TemplateColumn>
																					<asp:TemplateColumn HeaderText="TC_Upload">
																						<ItemStyle Wrap="False"></ItemStyle>
																						<ItemTemplate>
																							<INPUT style="Z-INDEX: 0; WIDTH: 200px; HEIGHT: 20px" id="tcfilepath1" type="file" runat="server">
																						</ItemTemplate>
																					</asp:TemplateColumn>
																					<asp:TemplateColumn HeaderText="View_TC">
																						<ItemStyle Wrap="False" HorizontalAlign="Center" ForeColor="#33CCFF" VerticalAlign="Middle"
																							BackColor="#FFFFCC"></ItemStyle>
																						<ItemTemplate>
																							<asp:HyperLink id=HypNew onclick="return hs.expand(this)" runat="server" Font-Bold="True" ForeColor="DeepSkyBlue" NavigateUrl='<%# Container.Dataitem("TCFILEPATH")%>' Text="ViewTc">ViewTC</asp:HyperLink>
																						</ItemTemplate>
																					</asp:TemplateColumn>
																					<asp:TemplateColumn HeaderText="DESCRIPTION">
																						<ItemTemplate>
																							<asp:TextBox style="Z-INDEX: 0" id=txtTCDESC runat="server" Width="500px" Height="20px" Text='<% #Container.Dataitem("REQENTRY_DESC")%>'>
																							</asp:TextBox>
																						</ItemTemplate>
																					</asp:TemplateColumn>
																					<asp:ButtonColumn Text="Save" ButtonType="PushButton" CommandName="Edit">
																						<HeaderStyle Wrap="False"></HeaderStyle>
																						<ItemStyle Wrap="False"></ItemStyle>
																						<FooterStyle Wrap="False"></FooterStyle>
																					</asp:ButtonColumn>
																					<asp:BoundColumn Visible="False" DataField="TCFLAG"></asp:BoundColumn>
																					<asp:BoundColumn Visible="False" DataField="UNIQUENO" HeaderText="UNIQUENO"></asp:BoundColumn>
																					<asp:BoundColumn Visible="False" DataField="ADMSLNO" HeaderText="ADMSLNO"></asp:BoundColumn>
																					<asp:BoundColumn Visible="False" DataField="EXAMBRANCHSLNO" HeaderText="EXAMBRANCHSLNO"></asp:BoundColumn>
																					<asp:BoundColumn Visible="False" DataField="REQSLNO" HeaderText="REQSLNO"></asp:BoundColumn>
																					<asp:TemplateColumn HeaderText="Verify">
																						<ItemTemplate>
																							<asp:CheckBox style="Z-INDEX: 0" id="chkVerify" runat="server" Font-Bold="True" ForeColor="#0000C0"
																								OnSelectedIndexChanged="chkVerify_SelectedIndexChanged" Text=" " AutoPostBack="True" BackColor="#C0C0FF"></asp:CheckBox>
																						</ItemTemplate>
																					</asp:TemplateColumn>
																				</Columns>
																				<PagerStyle VerticalAlign="Middle" Font-Bold="True" HorizontalAlign="Center" ForeColor="#FFFF80"
																					Position="Top" PageButtonCount="20" CssClass="GridPager" Mode="NumericPages"></PagerStyle>
																			</asp:datagrid></TD>
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
						</TD>
					</TR>
				</TBODY>
			</TABLE>
			<asp:textbox style="Z-INDEX: 101; POSITION: absolute; TOP: 3px; LEFT: 8px" id="txtSetfocus" runat="server"
				Width="0px" Height="32px"></asp:textbox><asp:textbox style="Z-INDEX: 102; POSITION: absolute; TOP: 8px; LEFT: 8px" id="txtMessage" runat="server"
				Width="0px" Height="32px"></asp:textbox><asp:textbox id="txtlblCode" runat="server" Width="0px" Height="32px">XXXXXX</asp:textbox></form>
		</TD></TR></TBODY></TABLE></FORM>
	</body>
</HTML>
