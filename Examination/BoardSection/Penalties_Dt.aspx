<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Penalties_Dt.aspx.vb" Inherits="CollegeBoard.PENALTIES_DT" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>PENALTIES_DT</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK id="Link1" rel="stylesheet" type="text/css" href="../../Images/Login/StyleSheet_Report.css">
		<LINK rel="stylesheet" type="text/css" href="../../Styles/MultiComboSelect/jquery.multiselect.css">
		<LINK rel="stylesheet" type="text/css" href="../../Styles/MultiComboSelect/jquery.multiselect.filter.css">
		<LINK rel="stylesheet" type="text/css" href="../../Styles/MultiComboSelect/jquery-ui.css">
		<LINK rel="stylesheet" type="text/css" href="../../Styles/MultiComboSelect/prettify.css">
		<%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.js"></script>
		<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1/jquery-ui.min.js"></script>
		<script type="text/javascript" src="http://www.erichynds.com/examples/jquery-ui-multiselect-widget/src/jquery.multiselect.js"></script>
		<script type="text/javascript" src="http://www.erichynds.com/examples/jquery-ui-multiselect-widget/src/jquery.multiselect.filter.js"></script>
		<script type="text/javascript">
			$(function(){
				
				$("#lstmCode").multiselect({multiple: true,noneSelectedText: "Select College Code",checkAllText:'Sel.All',uncheckAllText:'Rem.All',selectedList: 3,minWidth:200}).multiselectfilter({filter: function(event, matches){
					if( !matches.length ){ 
						}	}	});									
				});			
		</script>
		<SCRIPT language="javascript" type="text/javascript" src="../../Modules/ts_picker.js">
		
		function showFocus()
		 {
			var id = event.srcElement.id
			alert("Pick Date")
		}
		
		</SCRIPT>
		<script language="javascript" type="text/javascript">
		 function checkNum()
			{
				var carCode = event.keyCode;if ((carCode < 48) || (carCode > 57))
			{
				alert('Please enter only numbers.');
				event.cancelBubble = true
				event.returnValue = false;
			}}
		</script>
		<script type="text/javascript">
               $(document).ready(function () {
			$("#Txtccode1").autocomplete({
					 source: function (request, response) {
				 $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "Penalties_Dt.aspx/GetData",
                data: "{'ccode':'" + document.getElementById('Txtccode1').value + "'}",
                dataType: "json",
                success: function (data) {
                    response(data.d);
                },
                error: function (result) {
                    alert("Error......");
                }
            });
        }
    });
});
		</script>--%>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" autocomplete="off" runat="server">
			<asp:textbox id="txtlblCode" runat="server" Width="0px" Height="32px">XXXXXX</asp:textbox>
			<TABLE id="Table0" border="0" cellSpacing="1" cellPadding="1" width="100%">
				<TBODY>
					<TR>
						<TD vAlign="top" align="center">
							<TABLE id="Table1" class="Panel" border="0" cellSpacing="0" cellPadding="0">
								<TR>
									<TD align="center">
										<TABLE id="Table2" border="0" cellSpacing="0" cellPadding="0">
											<TR>
												<TD class="DarkColor">
													<TABLE id="Table3" border="0" cellSpacing="0" cellPadding="0" width="100%">
														<TR>
															<TD vAlign="top" width="11"><IMG src="../../Images/Login/table-lcorw.gif" width="11" height="11"></TD>
															<TD class="SubHeading"><asp:label id="lblHeading" runat="server" Width="100%" Font-Bold="True" CssClass="SubHeading1"> List  of College Wise Details  of Penalties </asp:label></TD>
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
													<TABLE id="Table12" border="0" cellSpacing="0" cellPadding="0" width="200">
														<TR>
															<%--<TD width="250"><SELECT style="Z-INDEX: 0; WIDTH: 100px" multiple name="Prdcity" RUNAT="server" id="lstmCode"></SELECT></TD>--%>
                                                             <TD width="250"><asp:TextBox ID="lstmCode" runat="server" Width="152px"></asp:TextBox>
                                                            </TD>
															<TD><asp:imagebutton accessKey="G" style="Z-INDEX: 0" id="imgBtnGoo1" tabIndex="1" runat="server" Width="40px"
																	Height="17px" ImageUrl="../../Images/NewImages/go.gif"></asp:imagebutton></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD class="TableBorder" vAlign="top" align="center"></TD>
											</TR>
											<TR>
												<TD class="TableBorder" vAlign="top" align="center"><asp:datagrid id="dgGridSection" tabIndex="1" runat="server" Width="198px" CssClass="GridMain"
														CellSpacing="2" OnItemCreated="DeleteConformationMessage" BorderStyle="Dotted" CellPadding="0" BorderWidth="0px" AutoGenerateColumns="False"
														AllowPaging="True">
														<SelectedItemStyle Font-Bold="True"></SelectedItemStyle>
														<AlternatingItemStyle CssClass="GridAlternateItem"></AlternatingItemStyle>
														<HeaderStyle Font-Bold="True" CssClass="GridHeader"></HeaderStyle>
														<Columns>
															<asp:TemplateColumn HeaderText="S.No">
																<HeaderStyle HorizontalAlign="Center" Width="10%" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																<ItemTemplate>
																	<asp:Label id=Label5 runat="server" Text='<%# DataBinder.Eval(Container, "DataSetIndex")+1 %>'>
																	</asp:Label>
																</ItemTemplate>
																<FooterStyle Wrap="False"></FooterStyle>
															</asp:TemplateColumn>
															<asp:BoundColumn Visible="False" DataField="PENT_SLNO" HeaderText="SLNO">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="CCODE" HeaderText="College Code">
																<HeaderStyle Wrap="False" HorizontalAlign="Center" Width="10%" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="COLLEGENAME" HeaderText="College Name">
																<HeaderStyle Wrap="False" Width="10%" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle Wrap="False" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:EditCommandColumn ButtonType="PushButton" UpdateText="Update" CancelText="Cancel" EditText="Edit">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:EditCommandColumn>
															<asp:ButtonColumn Text="Delete" ButtonType="PushButton" CommandName="Delete">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:ButtonColumn>
														</Columns>
														<PagerStyle HorizontalAlign="Center" CssClass="GridPager" Mode="NumericPages"></PagerStyle>
													</asp:datagrid></TD>
											</TR>
											<TR>
												<TD class="TableBorder" vAlign="middle" align="right"><asp:imagebutton accessKey="S" id="iBtnAdd" tabIndex="5" runat="server" Width="92px" Height="20px"
														ImageUrl="../../Images/NewImages/add.gif"></asp:imagebutton>&nbsp;&nbsp;&nbsp;
												</TD>
											</TR>
										</TABLE>
										<TABLE id="Table4" border="0" cellSpacing="0" cellPadding="0" width="426" runat="server">
											<TR>
												<TD align="center" style="HEIGHT: 29px">
													<P>&nbsp;</P>
													<P>&nbsp;</P>
												</TD>
											</TR>
											<TR>
												<TD align="center">
													<TABLE id="Table6" class="Panel" border="0" cellSpacing="0" cellPadding="0">
														<TR>
															<TD align="center">
																<TABLE id="Table7" border="0" cellSpacing="0" cellPadding="0">
																	<TR>
																		<TD class="DarkColor">
																			<TABLE id="Table8" border="0" cellSpacing="0" cellPadding="0" width="100%">
																				<TR>
																					<TD vAlign="top" width="11"><IMG src="../../Images/Login/table-lcorw.gif" width="11" height="11"></TD>
																					<TD class="SubHeading"><asp:label id="Label10" runat="server" Width="264px" Height="8px" Font-Bold="True" CssClass="SubHeading1"> Entry  for Penaltie Details </asp:label></TD>
																					<TD vAlign="top" width="11"><IMG src="../../Images/Login/table-rcorw.gif" width="11" height="11"></TD>
																				</TR>
																			</TABLE>
																		</TD>
																	</TR>
																	<TR>
																		<TD class="TdBorder"><IMG src="../../Images/Login/spacer.gif" width="1" height="1"></TD>
																	</TR>
																	<TR>
																		<TD class="TableBorder" vAlign="top" align="left">
																			<TABLE id="Table9" border="0" cellSpacing="0" cellPadding="0">
																			</TABLE>
																			<TABLE id="Table5" border="0" cellSpacing="0" cellPadding="0" width="330">
																				<TR>
																					<TD style="WIDTH: 116px"><asp:label style="Z-INDEX: 0" id="Label2" runat="server" Width="128px" Height="19px" CssClass="Lables">College Code</asp:label></TD>
																					<TD style="WIDTH: 29px"><asp:textbox style="Z-INDEX: 0" id="Txtccode" runat="server" Width="59px" CssClass=" " MaxLength="10"></asp:textbox></TD>
																					<TD align="left"><asp:imagebutton accessKey="G" id="imgBtnGo" tabIndex="1" runat="server" Width="75px" Height="17px"
																							ImageUrl="../../Images/NewImages/search.gif"></asp:imagebutton></TD>
																				</TR>
																				<TR>
																					<TD colSpan="3" align="center"><asp:label style="Z-INDEX: 0" id="LBLCLGNAME" runat="server" Width="100%" Height="19px" CssClass="Lables"
																							BackColor="Info">College Name</asp:label></TD>
																				</TR>
																			</TABLE>
																			<TABLE id="Table10" border="0" cellSpacing="0" cellPadding="0" width="100%">
																				<TR>
																					<TD style="WIDTH: 133px"><asp:label id="Label1" runat="server" Width="100%" Height="14px" CssClass="Lables"> Shifting</asp:label></TD>
																					<TD><asp:dropdownlist id="drpshift" tabIndex="2" runat="server" Width="144px" CssClass=" " AutoPostBack="True">
																							<asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
																							<asp:ListItem Value="1">Yes</asp:ListItem>
																							<asp:ListItem Value="2">No</asp:ListItem>
																						</asp:dropdownlist></TD>
																				</TR>
																				<TR>
																					<TD colSpan="2">
																						<TABLE id="tblsht" border="0" cellSpacing="0" cellPadding="0" width="280" runat="server">
																							<TR>
																								<TD style="WIDTH: 133px; HEIGHT: 19px"><asp:label id="Label3" runat="server" Width="100%" Height="19px" CssClass="Lables"> Change of Year</asp:label></TD>
																								<TD><asp:textbox id="txtshtamt" tabIndex="3" runat="server" Width="144px" CssClass=" " MaxLength="10"></asp:textbox></TD>
																							</TR>
																						</TABLE>
																					</TD>
																				</TR>
																				<TR>
																					<TD style="WIDTH: 133px"><asp:label id="Label12" runat="server" Width="100%" Height="14px" CssClass="Lables"> College Name Chang</asp:label></TD>
																					<TD><asp:dropdownlist id="drpclg" tabIndex="2" runat="server" Width="144px" CssClass=" " AutoPostBack="True">
																							<asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
																							<asp:ListItem Value="1">Yes</asp:ListItem>
																							<asp:ListItem Value="2">No</asp:ListItem>
																						</asp:dropdownlist></TD>
																				</TR>
																				<TR>
																					<TD colSpan="2">
																						<TABLE style="WIDTH: 280px; HEIGHT: 19px" id="Tblclg" border="0" cellSpacing="0" cellPadding="0"
																							width="280" runat="server">
																							<TR>
																								<TD style="WIDTH: 133px; HEIGHT: 19px"><asp:label id="Label13" runat="server" Width="100%" Height="19px" CssClass="Lables"> Change of Year</asp:label></TD>
																								<TD><asp:textbox id="txtclgpenamt" tabIndex="3" runat="server" Width="144px" CssClass=" " MaxLength="10"></asp:textbox></TD>
																							</TR>
																						</TABLE>
																					</TD>
																				</TR>
																				<TR>
																					<TD style="WIDTH: 133px"><asp:label id="Label7" runat="server" Width="100%" Height="14px" CssClass="Lables"> Society Name Change</asp:label></TD>
																					<TD><asp:dropdownlist id="drpsoc" tabIndex="4" runat="server" Width="144px" CssClass=" " AutoPostBack="True">
																							<asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
																							<asp:ListItem Value="1">Yes</asp:ListItem>
																							<asp:ListItem Value="2">No</asp:ListItem>
																						</asp:dropdownlist></TD>
																				</TR>
																				<TR>
																					<TD colSpan="2">
																						<TABLE style="WIDTH: 280px; HEIGHT: 19px" id="Tblsoc" border="0" cellSpacing="0" cellPadding="0"
																							width="280" runat="server">
																							<TR>
																								<TD style="WIDTH: 135px"><asp:label id="Label9" runat="server" Width="100%" Height="19px" CssClass="Lables"> Change of Year</asp:label></TD>
																								<TD><asp:textbox id="txtsocamt" tabIndex="5" runat="server" Width="144px" CssClass=" " MaxLength="10"></asp:textbox></TD>
																							</TR>
																						</TABLE>
																					</TD>
																				</TR>
																				<TR>
																					<TD style="WIDTH: 133px"><asp:label id="Label4" runat="server" Width="100%" Height="14px" CssClass="Lables"> Court Cases</asp:label></TD>
																					<TD><asp:dropdownlist id="drpcourt" tabIndex="6" runat="server" Width="144px" CssClass=" " AutoPostBack="True">
																							<asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
																							<asp:ListItem Value="1">Yes</asp:ListItem>
																							<asp:ListItem Value="2">No</asp:ListItem>
																						</asp:dropdownlist></TD>
																				</TR>
																				<TR>
																					<TD colSpan="2">
																						<TABLE style="WIDTH: 280px; HEIGHT: 19px" id="tblcourt" border="0" cellSpacing="0" cellPadding="0"
																							width="280" runat="server">
																							<TR>
																								<TD style="WIDTH: 135px"><asp:label id="Label6" runat="server" Width="100%" Height="19px" CssClass="Lables"> Change of Year</asp:label></TD>
																								<TD><asp:textbox id="txtcouramt" tabIndex="7" runat="server" Width="144px" CssClass=" " MaxLength="10"></asp:textbox></TD>
																							</TR>
																						</TABLE>
																					</TD>
																				</TR>
																				<TR>
																					<TD style="WIDTH: 133px"><asp:label id="Label8" runat="server" Width="100%" Height="14px" CssClass="Lables"> Restart</asp:label></TD>
																					<TD><asp:dropdownlist id="drprestart" tabIndex="8" runat="server" Width="144px" CssClass=" " AutoPostBack="True">
																							<asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
																							<asp:ListItem Value="1">Yes</asp:ListItem>
																							<asp:ListItem Value="2">No</asp:ListItem>
																						</asp:dropdownlist></TD>
																				</TR>
																				<TR>
																					<TD colSpan="2">
																						<TABLE style="WIDTH: 280px; HEIGHT: 19px" id="tblrest" border="0" cellSpacing="0" cellPadding="0"
																							width="280" runat="server">
																							<TR>
																								<TD style="WIDTH: 135px"><asp:label id="Label11" runat="server" Width="100%" Height="19px" CssClass="Lables"> Change of Year</asp:label></TD>
																								<TD><asp:textbox id="txtrestamt" tabIndex="9" runat="server" Width="144px" CssClass=" " MaxLength="10"></asp:textbox></TD>
																							</TR>
																						</TABLE>
																					</TD>
																				</TR>
																				<TR>
																					<TD><asp:label style="Z-INDEX: 0" id="Label14" runat="server" Width="100%" Height="19px" CssClass="Lables"> Penalty Year</asp:label></TD>
																					<TD><asp:textbox style="Z-INDEX: 0" id="txtpentyear" tabIndex="10" runat="server" Width="144px" CssClass=" "
																							MaxLength="10"></asp:textbox></TD>
																				</TR>
																				<TR>
																					<TD><asp:label style="Z-INDEX: 0" id="Label15" runat="server" Width="100%" Height="19px" CssClass="Lables"> Penaltie Type</asp:label></TD>
																					<TD><asp:dropdownlist style="Z-INDEX: 0" id="drpptype" tabIndex="11" runat="server" Width="144px" CssClass=" ">
																							<asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
																							<asp:ListItem Value="1">Imposed</asp:ListItem>
																							<asp:ListItem Value="2">Disposed</asp:ListItem>
																						</asp:dropdownlist></TD>
																				</TR>
																				<TR>
																					<TD><asp:label style="Z-INDEX: 0" id="Label16" runat="server" Width="100%" Height="19px" CssClass="Lables"> Penalty Paid Amount</asp:label></TD>
																					<TD><asp:textbox style="Z-INDEX: 0" id="txtpenpaidamt" tabIndex="12" runat="server" Width="144px"
																							CssClass=" " MaxLength="10"></asp:textbox></TD>
																				</TR>
																				<TR>
																					<TD><asp:label style="Z-INDEX: 0" id="Label17" runat="server" Width="100%" Height="19px" CssClass="Lables"> Penalty  Due Amount</asp:label></TD>
																					<TD><asp:textbox style="Z-INDEX: 0" id="txtpendueamt" tabIndex="13" runat="server" Width="144px"
																							CssClass=" " MaxLength="10"></asp:textbox></TD>
																				</TR>
																			</TABLE>
																		</TD>
																	</TR>
																	<TR>
																		<TD class="TableBorder" vAlign="middle" align="right"><asp:imagebutton accessKey="S" style="Z-INDEX: 0" id="iBtnSave" tabIndex="14" runat="server" Width="92px"
																				Height="20px" ImageUrl="../../Images/NewImages/save.gif"></asp:imagebutton>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
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
		</form>
		</TD></TR></TBODY></TABLE>
	</body>
</HTML>
