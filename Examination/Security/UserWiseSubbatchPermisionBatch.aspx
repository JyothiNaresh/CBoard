<%@ Page Language="vb" AutoEventWireup="false" Codebehind="UserWiseSubbatchPermisionBatch.aspx.vb" Inherits="CollegeBoard.UserWiseSubbatchPermisionBatch" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>UserWiseSubbatchPermisionBatch</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK id="Link2" href="../../Images/Login/StyleSheet_Report.css" type="text/css" rel="stylesheet">
		<script language="javascript" type="text/javascript" src="../Include/Report.js"></script>
	</HEAD>
	<body onscroll="javascript:setcoords()" topMargin="0" onload="javascript:ScrollIt()" background="../Images/NewImages/innerpage-bg1.jpg"
		MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 102; POSITION: absolute; TOP: 8px; LEFT: 8px" cellSpacing="0"
				cellPadding="1" width="100%" border="0">
				<TR>
					<TD vAlign="top" align="center">
						<TABLE id="Table4" style="WIDTH: 874px; HEIGHT: 331px" cellSpacing="0" cellPadding="1"
							width="874" align="center" border="1">
							<TR>
								<TD vAlign="baseline" nowrap="nowrap" align="center">
									<TABLE id="Table2" style="WIDTH: 881px; HEIGHT: 312px" cellSpacing="0" cellPadding="1"
										width="881" align="center" border="0">
										<TR>
											<TD vAlign="middle" align="center"><asp:label id="lblHeading" runat="server" CssClass="SubHeading1" Width="100%">User Wise Subbatch Permissions(Batch)</asp:label></TD>
										</TR>
										<TR>
											<TD vAlign="middle" align="center">
												<TABLE id="Table3" cellSpacing="0" cellPadding="1" width="300" border="0">
													<TR>
														<TD nowrap="nowrap"><asp:label id="Label5" runat="server" CssClass="Lables" Width="110px">User&nbsp;Types&nbsp;*</asp:label></TD>
														<TD nowrap="nowrap"><asp:dropdownlist id="DrpUserTypes" runat="server" CssClass="DropDownList" Width="153px"></asp:dropdownlist></TD>
														<TD nowrap="nowrap"><asp:label id="Label6" runat="server" CssClass="Lables" Width="120px">Academic Year</asp:label></TD>
														<TD nowrap="nowrap"><asp:dropdownlist id="drpAcaSlno" runat="server" CssClass="DropDownList" Width="153px"></asp:dropdownlist></TD>
														<TD nowrap="nowrap"><asp:imagebutton id="iBtnSearch" accessKey="E" runat="server" Width="80px" Height="20px" ImageUrl="../../Images/NewImages/search.gif"></asp:imagebutton></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD vAlign="middle" align="center">
												<HR width="100%" SIZE="1">
											</TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 24px" vAlign="middle" align="center"><asp:checkbox id="chkCheckUnChk" runat="server" CssClass="Lables" AutoPostBack="True" Text="Check/UnCheck"></asp:checkbox></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 24px" vAlign="middle" align="center"><br>
											</TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 24px" vAlign="middle" align="center"><asp:checkboxlist id="chklUsers" runat="server" CssClass="Lables" Width="542px" RepeatColumns="6"></asp:checkboxlist></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 24px" vAlign="middle" align="center">
												<HR width="100%" SIZE="1">
											</TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 24px" vAlign="middle" align="center">
												<TABLE id="Table5" style="WIDTH: 410px; HEIGHT: 19px" cellSpacing="0" cellPadding="0" width="410"
													border="0">
													<TR>
														<TD style="WIDTH: 64px">
															<asp:label id="lblCourse" runat="server" Width="100%" CssClass="Lables">Course&nbsp;*</asp:label></TD>
														<TD style="WIDTH: 136px">
															<asp:dropdownlist id="drpCourse" runat="server" Width="153px" CssClass="Lables" AutoPostBack="True"></asp:dropdownlist></TD>
														<TD style="WIDTH: 6px">
															<asp:label id="lblGroup" runat="server" Width="24px" CssClass="Lables">Group&nbsp;*</asp:label></TD>
														<TD>
															<asp:dropdownlist id="drpGroup" runat="server" Width="153px" CssClass="Lables" AutoPostBack="True"></asp:dropdownlist></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 24px" vAlign="middle" align="center">
												<TABLE id="TblBatch" style="WIDTH: 544px; HEIGHT: 24px" cellSpacing="0" cellPadding="0"
													width="544" border="0" runat="server">
													<TR>
														<TD align="center"><B>Batch
																<asp:checkbox id="ChkCheckbatch" runat="server" CssClass="Lables" Text="Check/Uncheck" AutoPostBack="True"></asp:checkbox></B></TD>
													</TR>
													<TR>
														<TD align="center"><br>
														</TD>
													</TR>
													<TR>
														<TD vAlign="middle" align="center">
															<asp:checkboxlist id="ChkBatches" runat="server" Width="542px" CssClass="Lables" RepeatColumns="5"></asp:checkboxlist></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 24px" vAlign="middle" align="center">
												<asp:imagebutton id="ibtnSBSearch" accessKey="E" runat="server" Width="80px" ImageUrl="../../Images/NewImages/search.gif"
													Height="20px"></asp:imagebutton></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 24px" vAlign="middle" align="center">
												<TABLE id="TblSubbatch" cellSpacing="0" cellPadding="0" width="300" border="0" runat="server">
													<TR>
														<TD align="center"></TD>
													</TR>
													<TR>
														<TD align="center"><B>SubBatch
																<asp:checkbox id="ChkCheckSubbatch" runat="server" CssClass="Lables" Text="Check/Uncheck" AutoPostBack="True"></asp:checkbox></B></TD>
													</TR>
													<TR>
														<TD align="center"><br>
														</TD>
													</TR>
													<TR>
														<TD>
															<asp:checkboxlist id="ChkSubbatches" runat="server" Width="542px" CssClass="Lables" RepeatColumns="5"></asp:checkboxlist></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 24px" vAlign="middle" align="center"></TD>
										</TR>
										<TR>
											<TD vAlign="middle" align="right">
												<asp:textbox id="PageY" runat="server" Visible="false" Width="0px"></asp:textbox>
												<asp:textbox id="PageX" runat="server" Visible="false" Width="0px"></asp:textbox><asp:imagebutton id="ibtSave" accessKey="S" runat="server" CssClass="button" Width="80px" Height="20px"
													ImageUrl="../../Images/NewImages/save.gif" AlternateText="Save"></asp:imagebutton>&nbsp;&nbsp;
												<asp:imagebutton id="ibtnCancel" accessKey="C" runat="server" CssClass="button" Width="80px" Height="20px"
													ImageUrl="../../Images/NewImages/cancel.gif" AlternateText="Cancel"></asp:imagebutton></TD>
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
