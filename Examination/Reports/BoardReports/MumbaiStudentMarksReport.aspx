<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MumbaiStudentMarksReport.aspx.vb" Inherits="CollegeBoard.MumbaiStudentMarksReport" %>

<HTML>
	<HEAD>
		<title>ColLoginStatusSummary</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="javascript" type="text/javascript" src="../../Include/Report.js"></script>
		<LINK rel="stylesheet" type="text/css" href="../../../Images/Login/StyleSheet_Report.css">
	</HEAD>
	<body background="../AttndImages/innerpage-bg1.jpg" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="992">
				<TR>
					<TD style="WIDTH: 955px" vAlign="baseline" nowrap="nowrap" align="center">
						<P>
							<TABLE id="tblHide" border="1" cellSpacing="0" cellPadding="0" runat="server" width="992">
								<TR>
									<TD vAlign="middle" nowrap="nowrap" align="center"><asp:label id="Label1" runat="server" ForeColor="White" Width="100%" Font-Bold="True" CssClass="SubHeading1">STATEMENT AVG MARKS </asp:label></TD>
								</TR>
								<TR>
									<TD vAlign="middle" nowrap="nowrap" align="center">
										<TABLE id="Table2" border="0" cellSpacing="0" cellPadding="0" width="228">
											
											
											<TR>
												<TD vAlign="middle" colSpan="4" nowrap="nowrap" align="center">
													<TABLE id="Table11" border="0" cellSpacing="0" cellPadding="0" width="168">
														<TR>
															<TD nowrap="nowrap"><asp:label id="lblRZ" runat="server" Width="65px" CssClass="Lables" Height="19px"> BRANCH:</asp:label></TD>
															<TD nowrap="nowrap"><asp:dropdownlist id="drpExamBranch" runat="server" CssClass=" " Width="100%" AutoPostBack="True"
													></asp:dropdownlist></TD>
														</TR>
                                                        <tr>
                                                            
                                                              <TD nowrap="nowrap"><asp:label id="Label2" runat="server" Width="65px" CssClass="Lables" Height="19px">ADMNO:</asp:label></TD>
                                                          
                                                          
                                                                <TD nowrap="nowrap"><asp:textbox id="txtadmno" runat="server" Width="295px"  CssClass="Textbox" MaxLength="10"></asp:textbox></TD>
                                                          
                                                        </tr>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								
								
								<TR>
									<TD vAlign="middle" nowrap="nowrap" align="CENTER"><asp:imagebutton accessKey="R" id="ibtnReport" runat="server" Width="80px" Height="20px" ImageUrl="../../../Images/NewImages/report.gif"></asp:imagebutton></TD>
								</TR>
							</TABLE>
						</P>
				<TR>
					<TD style="WIDTH: 955px" vAlign="middle" nowrap="nowrap" align="center"><asp:table style="Z-INDEX: 0" id="ReportDataTable" runat="server" Width="4px" BorderColor="Silver"></asp:table></TD>
				</TR>
				</TD></TR></TABLE>
		</form>
	</body>
</HTML>