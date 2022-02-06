<%@ Page CodeBehind="home.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="CollegeBoard.home" %>
<HTML>
	<HEAD>
		<title>NIMS - Narayana Information Management System</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<Link href="images/Login/StyleSheet.css" rel="stylesheet" type="text/css">
			<script id="clientEventHandlersJS" src="Examination/Include/ValidationUserTo.js" type="text/javascript"> </script>
		<!--<script language=jscript src="Examination/Include/windowstatus.js"  ></script>****  --> 
	</HEAD>
	<body onload="javascript:btnGo_onClick()">
		<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
			<tr>
				<td><div align="center">
						<table width="710" height="430" border="0" cellpadding="0" cellspacing="0">
							<tr>
								<td valign="top" background="images/Login/login-bg.jpg"><table width="100%" border="0" cellspacing="0" cellpadding="0">
										<tr>
											<td width="369" height="168">&nbsp;</td>
											<td width="46%" height="168">&nbsp;</td>
										</tr>
										<tr>
											<td width="369">&nbsp;</td>
											<td><form id="Form1" name="Form1" method="post" runat="server">
													<table width="100%" border="0" cellspacing="0" cellpadding="0">
														<TR>
															<TD class="HomeText" width="125"></TD>
															<TD width="61%">
																<asp:Label id="lblMessage" runat="server" Width="156px" ForeColor="DodgerBlue">You Can Login With Examination UserId/Passwod</asp:Label></TD>
														</TR>
														<tr>
															<td width="125" class="HomeText">User Name:</td>
															<td width="61%"><asp:textbox id="txtUserId" runat="server" Width="100px" CssClass="textboxASR" Height="20px"></asp:textbox></td>
														</tr>
														<tr>
															<td class="HomeText" width="125">Password:</td>
															<td><asp:textbox id="txtPwd" runat="server" TextMode="Password" Width="100px" CssClass="textboxASR"
																	Height="20px"></asp:textbox></td>
														</tr>
														<tr>
															<td class="HomeText" width="125" height="13">
																Code:</td>
															<td height="13"><asp:DropDownList id="drpAcyear" runat="server" Width="100px">
                                                                <asp:ListItem Value="16">2021-2022</asp:ListItem>
                                                                <asp:ListItem Value="15" Selected="True">2020-2021</asp:ListItem>
                                                                <asp:ListItem Value="14">2019-2020</asp:ListItem>
                                                                <asp:ListItem Value="13">2018-2019</asp:ListItem>
                                                                <asp:ListItem Value="12">2017-2018</asp:ListItem>
															        <asp:ListItem Value="11">2016-2017</asp:ListItem>
															        <asp:ListItem Value="10">2015-2016</asp:ListItem>
																	<asp:ListItem Value="9">2014-2015</asp:ListItem>
																	<asp:ListItem Value="8">2013-2014</asp:ListItem>
																	<asp:ListItem Value="7">2012-2013</asp:ListItem>
																	<asp:ListItem Value="6">2011-2012</asp:ListItem>
																	<asp:ListItem Value="5">2010-2011</asp:ListItem>
																	<asp:ListItem Value="4">2009-2010</asp:ListItem>
																	<asp:ListItem Value="3">2008-2009</asp:ListItem>
																	<asp:ListItem Value="2">2007-2008</asp:ListItem>
																	<asp:ListItem Value="1">2006-2007</asp:ListItem>
																</asp:DropDownList></td>
														</tr>
														<tr>
															<td width="125">&nbsp;</td>
															<td>&nbsp;</td>
														</tr>
														<tr>
															<td width="125">&nbsp;</td>
															<td><asp:ImageButton id="iBtnSubmit" runat="server" ImageUrl="images/Login/btn-hsubmit.gif" Width="60px"
																	Height="20"></asp:ImageButton></td>
														</tr>
														<tr>
															<td width="125">
															</td>
														</tr>
													</table>
													<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="300" border="0">
														<TBODY>
															<TR>
																<TD><asp:textbox id="Txt1" runat="server" Width="0px" Height="0px"></asp:textbox></TD>
															</TR>
															<TR>
																<TD><asp:textbox id="Txt2" runat="server" Width="0px" Height="0px"></asp:textbox></TD>
															</TR>
															<TR>
																<TD><asp:textbox id="Txt3" runat="server" Width="0px" Height="0px"></asp:textbox></TD>
															</TR>
														</TBODY></TABLE>
												</form>
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</div>
				</td>
			</tr>
		</table>
	</body>
</HTML>
