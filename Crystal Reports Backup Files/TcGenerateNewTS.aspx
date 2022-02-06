<%@ Page Language="vb" AutoEventWireup="false" Codebehind="TcGenerateNewTS.aspx.vb" Inherits="CollegeBoard.TcGenerateNewTS" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>TcGenerateNew</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body onload="pageset();" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE style="Z-INDEX: 101; POSITION: absolute; WIDTH: 680px; TOP: 8px; LEFT: 8px" border="0"
				cellSpacing="0" cellPadding="0" width="659" align="center">
				<TR>
					<TD align="center">
						<TABLE style="WIDTH: 680px" id="Table1" border="0" cellSpacing="0" cellPadding="0" width="680"
							align="center">
							<tr>
								<td colspan="4">
									<TABLE style="WIDTH: 621px; HEIGHT: 125px" id="Table4" border="0" cellSpacing="0" cellPadding="0"
										width="621" align="center">
										<TR>
											<TD vAlign="top" rowSpan="4" width="15%" align="center"><asp:image id="Image1" runat="server" Height="112px" Width="91px"></asp:image></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 540px" width="540" align="center">
												<TABLE id="Table5" border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
													<TR>
														<TD style="HEIGHT: 15px" colSpan="2" align="right">
															<asp:label id="lblDocumentId" runat="server" Width="160px" Font-Bold="True" Font-Names="Calibri">1</asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
													</TR>
													<TR>
														<TD colSpan="2" align="center"><asp:label id="lblTCColName" runat="server" Height="10px" Width="558px" Font-Names="Calibri"
																CssClass="lables" Font-Size="Large">Name of the College</asp:label></TD>
													</TR>
													<TR>
														<TD style="HEIGHT: 9px" width="70%" colSpan="2" align="center"><asp:label id="Label35" runat="server" Height="10px" Width="100%" Font-Bold="True" Font-Names="Calibri"
																CssClass="lables" Font-Size="Larger">Transfer Certificate</asp:label></TD>
													</TR>
													<TR>
														<TD style="HEIGHT: 17px" align="left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
															&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;<asp:label id="Label36" runat="server" Height="9px" Width="228px" Font-Names="Calibri" CssClass="lables"
																Font-Size="Smaller"> (Recognised by Govt. of Telangana)</asp:label></TD>
													</TR>
													<TR>
														<TD height="16" align="center">
															<asp:label id="lblTCRCNO" runat="server" Height="7px" Width="576px" Font-Names="Calibri" CssClass="lables"
																Font-Size="Smaller">RCNO</asp:label></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</td>
							</tr>
							<TR>
								<TD colSpan="4"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 100%; HEIGHT: 1px" class="lables" vAlign="top" width="29" colSpan="4"
									align="center">
									<TABLE style="WIDTH: 100%; HEIGHT: 23px" id="Table2" border="0" cellSpacing="1" cellPadding="1"
										width="604">
										<TR>
											<TD style="WIDTH: 387px" valign="top">
												<asp:label id="Label33" runat="server" Width="188px" Font-Names="Calibri" Font-Bold="True">Transfer Certificate No. : </asp:label>
												<asp:label id="lblTcno" runat="server" Width="192px" Font-Names="Calibri">lblTcno</asp:label></TD>
											<TD style="WIDTH: 72px" valign="top">
												<asp:label id="Label13" runat="server" Font-Names="Calibri" Font-Bold="True">Adm.No :</asp:label></TD>
											<TD style="HEIGHT: 50px" valign="top">
												<asp:label id="LblAdmno" runat="server" Font-Names="Calibri">Label</asp:label></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px" class="lables" height="10" vAlign="top" width="67" align="center"><FONT size="2" face="Calibri">1</FONT></TD>
								<TD style="WIDTH: 321px" class="lables" height="10" vAlign="top" align="left"><asp:label id="Label2" runat="server" Height="20" Width="100%" Font-Names="Calibri" Font-Size="Smaller">Name of the College</asp:label></TD>
								<TD style="WIDTH: 14px" class="lables" height="10" vAlign="top" align="center"><STRONG>:</STRONG></TD>
								<TD class="lables" height="10" vAlign="top" align="left"><asp:label id="lblClgNameCode" runat="server" Font-Names="Calibri" Font-Size="X-Small">Label</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px" class="lables" height="10" vAlign="top" width="67" align="center"></TD>
								<TD style="WIDTH: 321px" class="lables" height="10" vAlign="top" align="left"><asp:label id="Label3" runat="server" Height="20px" Width="100%" Font-Names="Calibri" Font-Size="Smaller">(Place and District)</asp:label></TD>
								<TD style="WIDTH: 14px" class="lables" height="10" vAlign="top" align="center"></TD>
								<TD class="lables" height="10" vAlign="top" align="left"><asp:label id="lblClgAddress1" runat="server" Font-Names="Calibri" Font-Size="X-Small">Label</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px" class="lables" height="10" vAlign="top" width="67" align="center"></TD>
								<TD style="WIDTH: 321px; HEIGHT: 25px" class="lables" vAlign="top" align="left"></TD>
								<TD style="WIDTH: 14px" class="lables" height="10" vAlign="top" align="center"></TD>
								<TD class="lables" height="10" vAlign="top" align="left"><asp:label id="lblClgAddress2" runat="server" Font-Names="Calibri" Font-Size="X-Small">Label</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 25px" class="lables" height="25" align="center"><asp:label id="Label47" runat="server" Height="20px" Width="100%" Font-Bold="True" Font-Names="Calibri"
										CssClass="lables" Font-Size="Smaller">2</asp:label></TD>
								<TD style="WIDTH: 321px; HEIGHT: 17px" class="lables" height="17" align="left">
									<P><FONT size="2" face="Calibri">Name of the Pupil</FONT></P>
								</TD>
								<TD style="WIDTH: 14px; HEIGHT: 25px" class="lables" height="25" align="center"><STRONG>:</STRONG></TD>
								<TD style="HEIGHT: 17px" class="lables" height="17" align="left"><asp:label id="lblStuName" runat="server" Font-Names="Calibri" Font-Size="X-Small">Label</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 25px" class="lables" height="25" align="center"><asp:label id="Label48" runat="server" Height="20px" Width="100%" Font-Bold="True" Font-Names="Calibri"
										CssClass="lables" Font-Size="Smaller">3</asp:label></TD>
								<TD style="WIDTH: 321px; HEIGHT: 25px" class="lables" height="25" align="left"><FONT size="2" face="Calibri">Name 
										of the Father</FONT></TD>
								<TD style="WIDTH: 14px; HEIGHT: 25px" class="lables" height="25" align="center"><STRONG>:</STRONG></TD>
								<TD style="HEIGHT: 19px" class="lables" height="19" align="left"><asp:label id="lblStuFname" runat="server" Font-Names="Calibri" Font-Size="X-Small">Label</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 7px" class="lables" height="7" align="center"><asp:label id="Label49" runat="server" Height="20px" Width="100%" Font-Bold="True" Font-Names="Calibri"
										CssClass="lables" Font-Size="Smaller">4</asp:label></TD>
								<TD style="WIDTH: 321px; HEIGHT: 7px" class="lables" height="7" align="left"><FONT size="2" face="Calibri">Name 
										of the Mother</FONT></TD>
								<TD style="WIDTH: 14px; HEIGHT: 25px" class="lables" height="25" align="center"><STRONG>:</STRONG></TD>
								<TD style="HEIGHT: 25px" class="lables" height="25" align="left"><asp:label id="lblStuMname" runat="server" Font-Names="Calibri" Font-Size="X-Small">Label</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 7px" class="lables" height="7" align="center"><asp:label id="Label50" runat="server" Height="20px" Width="100%" Font-Bold="True" Font-Names="Calibri"
										CssClass="lables" Font-Size="Smaller">5</asp:label></TD>
								<TD style="WIDTH: 321px; HEIGHT: 7px" class="lables" height="7" align="left"><asp:label id="Label7" runat="server" Font-Names="Calibri" Font-Size="Smaller">Nationality and Religion</asp:label></TD>
								<TD style="WIDTH: 14px; HEIGHT: 7px" class="lables" height="7" align="center"><STRONG>:</STRONG></TD>
								<TD style="HEIGHT: 7px" class="lables" height="7" align="left"><asp:label id="lblNationality" runat="server" Font-Names="Calibri" Font-Size="X-Small">Label</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 25px" class="lables" height="25" align="center">
									<asp:label id="Label51" runat="server" Height="20px" Width="100%" Font-Bold="True" Font-Names="Calibri"
										CssClass="lables" Font-Size="Smaller">6</asp:label></TD>
								<TD style="WIDTH: 321px; HEIGHT: 25px" class="lables" height="25" align="left">
									<asp:label id="Label8" runat="server" Height="20px" Width="100%" Font-Names="Calibri" Font-Size="Smaller">Whether the Candidate belongs to S.Cs or STs</asp:label></TD>
								<TD style="WIDTH: 14px; HEIGHT: 25px" class="lables" height="25" align="center"><STRONG>:</STRONG></TD>
								<TD style="HEIGHT: 7px" class="lables" height="7" align="left">
									<asp:label id="lblCaste" runat="server" Font-Names="Calibri" Font-Size="Smaller">Label</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 25px" class="lables" height="25" align="center"></TD>
								<TD style="WIDTH: 321px; HEIGHT: 25px" class="lables" height="25" align="left">
									<asp:label id="Label9" runat="server" Height="20px" Font-Names="Calibri" Font-Size="Smaller">or BC or Vimukthajatis or other socially and </asp:label></TD>
								<TD style="WIDTH: 14px; HEIGHT: 7px" class="lables" height="7" align="center"></TD>
								<TD style="HEIGHT: 7px" class="lables" height="7" align="left"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 25px" class="lables" height="25" align="center"></TD>
								<TD style="WIDTH: 321px; HEIGHT: 25px" class="lables" height="25" align="left">
									<asp:label id="Label10" runat="server" Height="20px" Font-Names="Calibri" Font-Size="Smaller">Educationally backward classes specified in </asp:label></TD>
								<TD style="WIDTH: 14px; HEIGHT: 7px" class="lables" height="7" align="center"></TD>
								<TD style="HEIGHT: 7px" class="lables" height="7" align="left"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 7px" class="lables" height="7" align="center"></TD>
								<TD style="WIDTH: 321px; HEIGHT: 7px" class="lables" height="7" align="left">
									<asp:label id="Label11" runat="server" Height="20px" Width="328px" Font-Names="Calibri" Font-Size="Smaller">A.P.E.S.R.S or he/she a convert from the S.C or </asp:label></TD>
								<TD style="WIDTH: 14px; HEIGHT: 7px" class="lables" height="7" align="center"></TD>
								<TD style="HEIGHT: 7px" class="lables" height="7" align="left"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 25px" class="lables" height="25" align="center"></TD>
								<TD style="WIDTH: 321px; HEIGHT: 25px" class="lables" height="25" align="left">
									<asp:label id="Label12" runat="server" Font-Names="Calibri" Font-Size="Smaller">S.T if so the particulars thereof</asp:label></TD>
								<TD style="WIDTH: 14px; HEIGHT: 7px" class="lables" height="7" align="center"></TD>
								<TD style="HEIGHT: 7px" class="lables" height="7" align="left"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 15px" class="lables" vAlign="top" align="center">
									<asp:label id="Label52" runat="server" Height="25px" Width="100%" Font-Bold="True" Font-Names="Calibri"
										CssClass="lables" Font-Size="Smaller">7</asp:label></TD>
								<TD style="WIDTH: 321px; HEIGHT: 15px" class="lables" vAlign="top" align="left">
									<asp:label id="Label14" runat="server" Font-Names="Calibri" Font-Size="Smaller">Date of Birth (in words) as per College Records</asp:label></TD>
								<TD style="WIDTH: 14px; HEIGHT: 15px" class="lables" height="15" align="center"><STRONG>:</STRONG></TD>
								<TD style="HEIGHT: 15px" class="lables" height="15" align="left">
									<P>
										<asp:label id="lblDob" runat="server" Font-Names="Calibri" Font-Size="X-Small">Label</asp:label></P>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 25px" class="lables" vAlign="top" align="center"></TD>
								<TD style="WIDTH: 321px; HEIGHT: 25px" class="lables" vAlign="top" align="left"></TD>
								<TD style="WIDTH: 14px; HEIGHT: 25px" class="lables" height="4" vAlign="top" align="center"></TD>
								<TD style="HEIGHT: 25px" class="lables" height="4" align="left">
									<P><asp:label id="lblDobwords" runat="server" Width="100%" Font-Names="Calibri" Font-Size="X-Small">Label</asp:label></P>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 25px" class="lables" height="25" vAlign="top" align="center">
									<asp:label id="Label4" runat="server" Height="20px" Width="100%" Font-Bold="True" Font-Names="Calibri"
										CssClass="lables" Font-Size="Smaller">8</asp:label></TD>
								<TD style="WIDTH: 321px; HEIGHT: 25px" class="lables" height="25" align="left" Valign="top">
									<asp:label id="Label34" runat="server" Width="288px" Font-Names="Calibri" Font-Size="Smaller">a) Class in which the pupil was reading at the time </asp:label></TD>
								<TD style="WIDTH: 14px; HEIGHT: 7px" class="lables" height="7" align="center"><STRONG>:</STRONG></TD>
								<TD style="HEIGHT: 25px" class="lables" height="25" align="left">
									<asp:label id="lblPoint8a" runat="server" Font-Names="Calibri" Font-Size="X-Small">Label</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 25px" class="lables" height="25" vAlign="top" align="center"></TD>
								<TD style="WIDTH: 321px; HEIGHT: 1px" class="lables" height="1" align="left">
									<asp:label id="Label37" runat="server" Font-Names="Calibri" Font-Size="Smaller">of leaving (in words)</asp:label></TD>
								<TD style="WIDTH: 14px; HEIGHT: 25px" class="lables" height="25" align="center"></TD>
								<TD style="HEIGHT: 1px" class="lables" height="1" align="left"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 25px" class="lables" height="25" vAlign="middle" align="center"></TD>
								<TD style="WIDTH: 321px; HEIGHT: 25px" class="lables" height="25" align="left">
									<P><FONT size="2" face="Calibri">b) First Language Under Part I</FONT></P>
								</TD>
								<TD style="WIDTH: 14px; HEIGHT: 25px" class="lables" height="25" align="center"><STRONG>:</STRONG></TD>
								<TD style="HEIGHT: 14px" class="lables" height="14" align="left"><asp:label id="lblPoint8b" runat="server" Font-Names="Calibri" Font-Size="X-Small">Label</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 25px" class="lables" height="25" align="center"></TD>
								<TD style="WIDTH: 321px; HEIGHT: 25px" class="lables" height="25" align="left"><asp:label id="Label39" runat="server" Font-Names="Calibri" Font-Size="Smaller">c) Second Language Under Part II</asp:label></TD>
								<TD style="WIDTH: 14px; HEIGHT: 25px" class="lables" height="25" align="center"><STRONG>:</STRONG></TD>
								<TD style="HEIGHT: 5px" class="lables" height="5" align="left"><asp:label id="lblPoint8c" runat="server" Font-Names="Calibri" Font-Size="X-Small">Label</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 25px" class="lables" height="25" align="center"></TD>
								<TD style="WIDTH: 321px; HEIGHT: 25px" class="lables" height="25" align="left"><asp:label id="Label40" runat="server" Font-Names="Calibri" Font-Size="Smaller">d) Optionals Under Part III</asp:label></TD>
								<TD style="WIDTH: 14px; HEIGHT: 25px" class="lables" height="25" align="center"><STRONG>:</STRONG></TD>
								<TD style="HEIGHT: 3px" class="lables" height="3" align="left"><asp:label id="lblPoint8d" runat="server" Font-Names="Calibri" Font-Size="X-Small">Label</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 25px" class="lables" height="25" align="center" valign="top"><asp:label id="Label57" runat="server" Height="20px" Width="100%" Font-Bold="True" Font-Names="Calibri"
										CssClass="lables" Font-Size="Smaller">9</asp:label></TD>
								<TD style="WIDTH: 321px; HEIGHT: 25px" class="lables" height="25" align="left" valign="top"><asp:label id="Label41" runat="server" Font-Names="Calibri" Font-Size="Smaller">Mother Tongue, Medium of Instruction</asp:label></TD>
								<TD style="WIDTH: 14px; HEIGHT: 25px" class="lables" height="25" align="center"><STRONG>:</STRONG></TD>
								<TD style="HEIGHT: 7px" class="lables" height="25" align="left"><asp:label id="lblMedium" runat="server" Font-Names="Calibri" Font-Size="X-Small">Label</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 25px" class="lables" height="25" align="center">
									<asp:label id="Label1" runat="server" Height="20px" Width="100%" Font-Bold="True" Font-Names="Calibri"
										CssClass="lables" Font-Size="Smaller">10</asp:label></TD>
								<TD style="WIDTH: 321px; HEIGHT: 25px" class="lables" height="25" align="left" valign="top">
									<asp:label id="Label42" runat="server" Font-Names="Calibri" Font-Size="Smaller">Date of Admission to 1st/2nd Year Intermediate</asp:label></TD>
								<TD style="WIDTH: 14px; HEIGHT: 25px" class="lables" height="25" align="center"><STRONG>:</STRONG></TD>
								<TD style="HEIGHT: 1px" class="lables" height="25" align="left">
									<asp:label id="lblDoa" runat="server" Font-Names="Calibri" Font-Size="X-Small">Label</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 25px" class="lables" height="25" vAlign="top" align="center">
									<asp:label id="Label58" runat="server" Height="25px" Width="100%" Font-Bold="True" Font-Names="Calibri"
										CssClass="lables" Font-Size="Smaller">11</asp:label></TD>
								<TD style="WIDTH: 321px; HEIGHT: 25px" class="lables" height="25" align="left" valign="top">
									<asp:label id="Label45" runat="server" Height="20px" Font-Names="Calibri" Font-Size="Smaller">Class and years in which the pupil was first </asp:label></TD>
								<TD style="WIDTH: 14px; HEIGHT: 25px" class="lables" height="25" align="center"></TD>
								<TD style="HEIGHT: 25px" class="lables" height="25" align="left"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px" class="lables" height="25" vAlign="top" align="center"></TD>
								<TD style="WIDTH: 321px" class="lables" height="25" align="left">
									<asp:label id="Label15" runat="server" Height="25px" Font-Names="Calibri" Font-Size="Smaller">Admitted into the Intermediate Course </asp:label></TD>
								<TD style="WIDTH: 14px" class="lables" height="25" align="center"><STRONG>:</STRONG></TD>
								<TD class="lables" height="25" align="left">
									<asp:label id="lblAdmyear" runat="server" Font-Names="Calibri" Font-Size="X-Small">Label</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 25px" class="lables" height="25" vAlign="top" align="center"></TD>
								<TD style="WIDTH: 321px; HEIGHT: 25px" class="lables" height="25" align="left">
									<asp:label id="Label16" runat="server" Font-Names="Calibri" Font-Size="Smaller">(1st year or 2nd year)</asp:label></TD>
								<TD style="WIDTH: 14px; HEIGHT: 25px" class="lables" height="25" align="center"></TD>
								<TD style="HEIGHT: 9px" class="lables" height="9" align="left"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 25px" class="lables" height="25" vAlign="top" align="center">
									<asp:label id="Label5" runat="server" Height="20px" Width="100%" Font-Bold="True" Font-Names="Calibri"
										CssClass="lables" Font-Size="Smaller">12</asp:label></TD>
								<TD style="WIDTH: 321px; HEIGHT: 25px" class="lables" height="25" align="left">
									<asp:label id="Label17" runat="server" Height="20px" Width="281px" Font-Names="Calibri" Font-Size="Smaller">Whether Qualified to study II year Class of </asp:label></TD>
								<TD style="WIDTH: 14px; HEIGHT: 25px" class="lables" height="25" align="center"></TD>
								<TD style="HEIGHT: 15px" class="lables" height="15" align="left"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 25px" class="lables" height="25" vAlign="top" align="center"></TD>
								<TD style="WIDTH: 321px; HEIGHT: 25px" class="lables" height="25" align="left">
									<asp:label id="Label18" runat="server" Height="20px" Width="280px" Font-Names="Calibri" Font-Size="Smaller">Intermediate Course? (In case of students</asp:label></TD>
								<TD style="WIDTH: 14px; HEIGHT: 25px" class="lables" height="25" align="center"><STRONG>:</STRONG></TD>
								<TD style="HEIGHT: 6px" class="lables" height="25" align="left">
									<asp:label id="lblPoint12" runat="server" Font-Names="Calibri" Font-Size="X-Small">Label</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 25px" class="lables" height="25" vAlign="top" align="center"></TD>
								<TD style="WIDTH: 321px; HEIGHT: 22px" class="lables" height="22" align="left">
									<asp:label id="Label19" runat="server" Height="20px" Width="304px" Font-Names="Calibri" Font-Size="Smaller">Leaving after completing 1st year class)</asp:label></TD>
								<TD style="WIDTH: 14px; HEIGHT: 25px" class="lables" height="25" align="center"></TD>
								<TD style="HEIGHT: 22px" class="lables" height="22" align="left"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 25px" class="lables" height="25" vAlign="top" align="center"><asp:label id="Label61" runat="server" Height="20px" Width="100%" Font-Bold="True" Font-Names="Calibri"
										CssClass="lables" Font-Size="Smaller">13</asp:label></TD>
								<TD style="WIDTH: 321px; HEIGHT: 15px" class="lables" height="15" align="left" valign="top"><asp:label id="Label70" runat="server" Height="20px" Width="281px" Font-Names="Calibri" Font-Size="Smaller">Whether the pupil has been declared eligible</asp:label></TD>
								<TD style="WIDTH: 14px; HEIGHT: 25px" class="lables" height="25" align="center"></TD>
								<TD style="HEIGHT: 15px" class="lables" height="15" align="left"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 25px" class="lables" height="25" vAlign="top" align="center"></TD>
								<TD style="WIDTH: 321px; HEIGHT: 25px" class="lables" height="25" align="left"><asp:label id="Label69" runat="server" Height="20px" Width="280px" Font-Names="Calibri" Font-Size="Smaller">By the Board of Intermediate Education for</asp:label></TD>
								<TD style="WIDTH: 14px; HEIGHT: 25px" class="lables" height="25" align="center"><STRONG class="lables">:</STRONG></TD>
								<TD style="HEIGHT: 15px" class="lables" height="25" align="left"><asp:label id="lblpoint13a" runat="server" Font-Names="Calibri" Font-Size="X-Small">Label</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 25px" class="lables" height="25" vAlign="top" align="center"></TD>
								<TD style="WIDTH: 321px; HEIGHT: 25px" class="lables" height="25" align="left"><asp:label id="Label68" runat="server" Height="20px" Width="272px" Font-Names="Calibri" Font-Size="Smaller">University Course of Study</asp:label></TD>
								<TD style="WIDTH: 14px; HEIGHT: 25px" class="lables" height="25" align="center"></TD>
								<TD style="HEIGHT: 25px" class="lables" height="15" align="left"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 25px" class="lables" height="25" vAlign="top" align="center"><asp:label id="Label62" runat="server" Height="20px" Width="100%" Font-Bold="True" Font-Names="Calibri"
										CssClass="lables" Font-Size="Smaller">14</asp:label></TD>
								<TD style="WIDTH: 321px; HEIGHT: 25px" class="lables" height="25" align="left" valign="top"><asp:label id="Label73" runat="server" Height="20px" Width="281px" Font-Names="Calibri" Font-Size="Smaller">a) Whether the pupil was in receipt of any</asp:label></TD>
								<TD style="WIDTH: 14px; HEIGHT: 25px" class="lables" height="25" align="center"></TD>
								<TD style="HEIGHT: 5px" class="lables" height="5" align="left"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 25px" class="lables" height="25" vAlign="top" align="center"></TD>
								<TD style="WIDTH: 321px; HEIGHT: 25px" class="lables" height="25" align="left"><asp:label id="Label72" runat="server" Height="20px" Width="304px" Font-Names="Calibri" Font-Size="Smaller">Scholarship? (Nature of the scholarship to be Specified)</asp:label></TD>
								<TD style="WIDTH: 14px; HEIGHT: 12px" class="lables" height="12" align="center"><STRONG class="lables">:</STRONG></TD>
								<TD style="HEIGHT: 12px" class="lables" height="12" align="left"><asp:label id="lblPoint14a" runat="server" Font-Names="Calibri" Font-Size="X-Small">NONE</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 25px" class="lables" height="25" vAlign="top" align="center"></TD>
								<TD style="WIDTH: 321px; HEIGHT: 25px" class="lables" height="25" align="left"><asp:label id="Label76" runat="server" Height="20px" Width="281px" Font-Names="Calibri" Font-Size="Smaller">b) Whether the pupil was in receipt of any </asp:label></TD>
								<TD style="WIDTH: 14px; HEIGHT: 25px" class="lables" height="25" align="center"></TD>
								<TD style="HEIGHT: 25px" class="lables" height="25" align="left"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 25px" class="lables" height="25" vAlign="top" align="center"></TD>
								<TD style="WIDTH: 321px; HEIGHT: 25px" class="lables" height="25" align="left"><asp:label id="Label75" runat="server" Height="20px" Width="280px" Font-Names="Calibri" Font-Size="Smaller">Concession (Nature of concession to be specified</asp:label></TD>
								<TD style="WIDTH: 14px; HEIGHT: 25px" class="lables" height="25" align="center"><STRONG>:</STRONG></TD>
								<TD style="HEIGHT: 25px" class="lables" height="25" align="left"><asp:label id="lblPoint14b" runat="server" Font-Names="Calibri" Font-Size="Smaller">NONE</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 25px" class="lables" height="25" vAlign="top" align="center">
									<asp:label id="Label22" runat="server" Width="100%" Height="20px" Font-Names="Calibri" Font-Bold="True"
										Font-Size="Smaller" CssClass="lables">15</asp:label>
								</TD>
								<TD style="WIDTH: 321px; HEIGHT: 13px" class="lables" height="13" align="left" vAlign="top">
									<TABLE style="WIDTH: 269px; HEIGHT: 18px" id="Table12" border="0" cellSpacing="0" cellPadding="0"
										width="269">
										<TR>
											<TD style="HEIGHT: 1px">
												<asp:label id="Label24" runat="server" Height="20px" Width="281px" Font-Names="Calibri" Font-Size="Smaller">Personal Marks of Identification</asp:label></TD>
											<TD style="HEIGHT: 1px" vAlign="top"><asp:label id="Label23" runat="server" Font-Size="Smaller">I)</asp:label></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD><asp:label id="Label20" runat="server" Font-Size="Smaller">II)</asp:label></TD>
										</TR>
									</TABLE>
								</TD>
								<TD style="WIDTH: 14px; HEIGHT: 13px" class="lables" height="13" align="center" vAlign="top">
									<TABLE id="Table13" border="0" cellSpacing="0" cellPadding="0" width="10">
										<TR>
											<TD><STRONG>&nbsp;:</STRONG></TD>
										</TR>
										<TR>
											<TD>
												<P><STRONG>&nbsp;:</STRONG></P>
											</TD>
										</TR>
									</TABLE>
								</TD>
								<TD style="HEIGHT: 13px" class="lables" height="13" align="left" vAlign="top">
									<TABLE style="WIDTH: 301px; HEIGHT: 48px" id="Table16" border="0" cellSpacing="0" cellPadding="0"
										width="301">
										<TR>
											<TD><asp:label id="lblPoint15a" runat="server" Font-Names="Calibri" Font-Size="Smaller">Label</asp:label></TD>
										</TR>
										<TR>
											<TD>
												<P><asp:label id="lblPoint15b" runat="server" Font-Names="Calibri" Font-Size="Smaller">Label</asp:label></P>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 9px" class="lables" height="9" vAlign="top" align="center"><asp:label id="Label65" runat="server" Height="20px" Width="100%" Font-Bold="True" Font-Names="Calibri"
										Font-Size="Smaller">16</asp:label></TD>
								<TD style="WIDTH: 321px; HEIGHT: 9px" class="lables" height="9" align="left" vAlign="top"><asp:label id="Label82" runat="server" Height="20px" Width="296px" Font-Names="Calibri" Font-Size="Smaller">Date on which the pupil has actually left the College</asp:label></TD>
								<TD style="WIDTH: 14px; HEIGHT: 9px" class="lables" height="9" align="center"><STRONG>:</STRONG></TD>
								<TD style="HEIGHT: 9px" class="lables" height="9" align="left"><asp:label id="lblPoint16" runat="server" Font-Names="Calibri" Font-Size="Smaller">Label</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 5px" class="lables" height="5" vAlign="top" align="center"><asp:label id="Label66" runat="server" Height="20px" Width="100%" Font-Bold="True" Font-Names="Calibri"
										CssClass="lables" Font-Size="Smaller">17</asp:label></TD>
								<TD style="WIDTH: 321px; HEIGHT: 5px" class="lables" height="5" align="left" vAlign="top"><asp:label id="Label85" runat="server" Height="20px" Width="281px" Font-Names="Calibri" Font-Size="Smaller">Date of Transfer Certificate</asp:label></TD>
								<TD style="WIDTH: 14px; HEIGHT: 5px" class="lables" height="5" align="center"><STRONG>:</STRONG></TD>
								<TD style="HEIGHT: 5px" class="lables" height="5" align="left"><asp:label id="lblPoint17" runat="server" Font-Names="Calibri" Font-Size="Smaller">Label</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 1px" class="lables" height="1" vAlign="top" align="center"><asp:label id="Label67" runat="server" Font-Bold="True" Font-Names="Calibri" CssClass="lables"
										Font-Size="Smaller">18</asp:label></TD>
								<TD style="WIDTH: 321px; HEIGHT: 1px" class="lables" height="1" align="left" vAlign="top"><asp:label id="Label88" runat="server" Width="281px" Font-Names="Calibri" Font-Size="Smaller">Conduct</asp:label></TD>
								<TD style="WIDTH: 14px; HEIGHT: 1px" class="lables" height="1" align="center"><STRONG>:</STRONG></TD>
								<TD style="HEIGHT: 1px" class="lables" height="1" align="left"><asp:label id="lblPoint18" runat="server" Font-Names="Calibri" Font-Size="Smaller">GOOD</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 1px" class="lables" height="1" vAlign="top" align="center"></TD>
								<TD style="WIDTH: 321px; HEIGHT: 1px" class="lables" height="1" align="left"></TD>
								<TD style="WIDTH: 14px; HEIGHT: 1px" class="lables" height="1" align="center"></TD>
								<TD style="HEIGHT: 1px" class="lables" height="1" align="right"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 1px" class="lables" height="1" vAlign="top" align="center"></TD>
								<TD style="WIDTH: 321px; HEIGHT: 1px" class="lables" height="1" align="left"></TD>
								<TD style="WIDTH: 14px; HEIGHT: 1px" class="lables" height="1" align="center"></TD>
								<TD style="HEIGHT: 1px" class="lables" height="1" align="right"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 1px" class="lables" height="1" vAlign="top" align="center"></TD>
								<TD style="WIDTH: 321px; HEIGHT: 1px" class="lables" height="1" align="left"></TD>
								<TD style="WIDTH: 14px; HEIGHT: 1px" class="lables" height="1" align="center"></TD>
								<TD style="HEIGHT: 1px" class="lables" height="1" align="right"><STRONG>Principal</STRONG>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
