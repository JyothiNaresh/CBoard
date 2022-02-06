<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TcGenerateCBSE.aspx.vb" Inherits="CollegeBoard.TcGenerateCBSE" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">

<HTML>
	<HEAD>
		<title>TcGenerateNew</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	    <style type="text/css">
            .auto-style1 {
                height: 29px;
            }
            .auto-style2 {
                width: 106px;
            }
        </style>
	</HEAD>
	<body onload="pageset();" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE style="Z-INDEX: 101; LEFT: 8px; WIDTH: 680px; POSITION: absolute; TOP: 8px" border="0"
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
														<TD colSpan="2" align="center" class="auto-style1"><asp:label id="lblTCColName" runat="server" Height="10px" Width="558px" Font-Names="Calibri"
																CssClass="lables" Font-Size="Large">Name of the College</asp:label></TD>
													</TR>
													
													<TR>
														<TD style="HEIGHT: 17px" align="left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:label id="Label36" runat="server" Height="9px" Width="280px" Font-Names="Calibri" CssClass="lables"
																Font-Size="Smaller">(AFFILIATED TO CBSE, GOVT. OF INDIA, NEW DELHI) </asp:label></TD>
													</TR>
                                                    <tr>
                                                        <td height="16" align="center">
                                                            <asp:Label id="Label25" runat="server" Width="100%" Font-Size="Smaller" Font-Names="Calibri"
														CssClass="lables">NO. 10+2 CBSE/ AFF./ 3630202, School No. : 57718</asp:Label>
                                                        </td>
                                                    </tr>
													<TR>
														<TD height="16" align="center">
															<asp:Label id="LblColAddr" runat="server" Width="100%" Font-Size="9pt" Font-Names="Calibri"
														CssClass="lables"></asp:Label></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</td>
							</tr>
							<TR>
								<TD colSpan="4">==============================================================================</TD>
                                
							</TR>
                            <TR>
														<TD style="WIDTH: 800px" valign="top" align="center" colSpan="4"><asp:label id="Label35" runat="server" Height="10px" Width="100%" Font-Bold="True" Font-Names="Calibri"
																CssClass="lables" Font-Size="Larger">Transfer Certificate</asp:label></TD>
													</TR>
                            
							<TR>
								<TD style="WIDTH: 100%; HEIGHT: 1px" class="lables" vAlign="top" width="29" colSpan="4"
									align="center">
									<TABLE style="WIDTH: 100%; HEIGHT: 23px" id="Table2" border="0" cellSpacing="1" cellPadding="1"
										width="604">
                                        
										<TR>
                                            <TD style="WIDTH: 72px" valign="top">
												<asp:label id="Label6" runat="server" Width="188px" Font-Names="Calibri" Font-Bold="True">Book No:</asp:label>
												</TD>
                                            <TD style="HEIGHT: 50px" valign="top">
												<asp:label id="Label21" runat="server" Width="102px" Font-Names="Calibri"></asp:label></TD>
											<TD style="WIDTH: 50px" valign="top" >
												<asp:label id="Label33" runat="server" Width="60px" Font-Names="Calibri" Font-Bold="True">TC No. : </asp:label>
												</TD>
                                            <TD style="HEIGHT: 50px" valign="top">
												<asp:label id="lblTcno" runat="server" Width="70px" Font-Names="Calibri">lblTcno</asp:label></TD>
											<TD style="WIDTH: 50px" valign="top">
												<asp:label id="Label13" runat="server" Font-Names="Calibri" Font-Bold="True">Adm.No:</asp:label></TD>
											<TD style="HEIGHT: 50px" valign="top">
												<asp:label id="LblAdmno" runat="server" Font-Names="Calibri" align="left">Label</asp:label></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<%--<TR>
								<TD style="WIDTH: 67px" class="lables" height="10" vAlign="top" width="67" align="center"><FONT size="2" face="Calibri">1</FONT></TD>
								<TD style="WIDTH: 321px" class="lables" height="10" vAlign="top" align="left"><asp:label id="Label2" runat="server" Height="20" Width="100%" Font-Names="Calibri" Font-Size="Smaller">Name of the College</asp:label></TD>
								<TD style="WIDTH: 14px" class="lables" height="10" vAlign="top" align="center"><STRONG>:</STRONG></TD>
								<TD class="lables" height="10" vAlign="top" align="left"><asp:label id="lblClgNameCode" runat="server" Font-Names="Calibri" Font-Size="Smaller">Label</asp:label></TD>
							</TR>--%>
							<%--<TR>
								<TD style="WIDTH: 67px" class="lables" height="10" vAlign="top" width="67" align="center"></TD>
								<TD style="WIDTH: 321px" class="lables" height="10" vAlign="top" align="left"><asp:label id="Label3" runat="server" Height="20px" Width="100%" Font-Names="Calibri" Font-Size="Smaller">(Place and District)</asp:label></TD>
								<TD style="WIDTH: 14px" class="lables" height="10" vAlign="top" align="center"></TD>
								<TD class="lables" height="10" vAlign="top" align="left"><asp:label id="lblClgAddress1" runat="server" Font-Names="Calibri" Font-Size="Smaller">Label</asp:label></TD>
							</TR>--%>
							<%--<TR>
								<TD style="WIDTH: 67px" class="lables" height="10" vAlign="top" width="67" align="center"></TD>
								<TD style="WIDTH: 321px; HEIGHT: 25px" class="lables" vAlign="top" align="left"></TD>
								<TD style="WIDTH: 14px" class="lables" height="10" vAlign="top" align="center"></TD>
								<TD class="lables" height="10" vAlign="top" align="left"><asp:label id="lblClgAddress2" runat="server" Font-Names="Calibri" Font-Size="Smaller">Label</asp:label></TD>
							</TR>--%>
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 25px" class="lables" height="25" align="center"><asp:label id="Label47" runat="server" Height="20px" Width="100%" Font-Bold="True" Font-Names="Calibri"
										CssClass="lables" Font-Size="Smaller">1</asp:label></TD>
								<TD style="WIDTH: 321px; HEIGHT: 17px" class="lables" height="17" align="left" >
									
                                     <asp:label id="Label68" runat="server" Font-Names="Calibri" Font-Size="Smaller">Name of the Pupil</asp:label>

								</TD>
								<TD style="WIDTH: 14px; HEIGHT: 25px" class="lables" height="25" align="center"><STRONG>:</STRONG></TD>
								<TD style="HEIGHT: 17px" class="lables" height="17" align="left"><asp:label id="lblStuName" runat="server" Font-Names="Calibri" Font-Size="Smaller">Label</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 25px" class="lables" height="25" align="center"><asp:label id="Label48" runat="server" Height="20px" Width="100%" Font-Bold="True" Font-Names="Calibri"
										CssClass="lables" Font-Size="Smaller">2</asp:label></TD>
								<TD style="WIDTH: 321px; HEIGHT: 25px" class="lables" height="25" align="left">
                                     <asp:label id="Label64" runat="server" Font-Names="Calibri" Font-Size="Smaller">Name 
										of the Father</asp:label>

								</TD>
								<TD style="WIDTH: 14px; HEIGHT: 25px" class="lables" height="25" align="center"><STRONG>:</STRONG></TD>
								<TD style="HEIGHT: 19px" class="lables" height="19" align="left"><asp:label id="lblStuFname" runat="server" Font-Names="Calibri" Font-Size="Smaller">Label</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 7px" class="lables" height="7" align="center"><asp:label id="Label49" runat="server" Height="20px" Width="100%" Font-Bold="True" Font-Names="Calibri"
										CssClass="lables" Font-Size="Smaller">3</asp:label></TD>
								<TD style="WIDTH: 321px; HEIGHT: 7px" class="lables" height="7" align="left">

                                    <asp:label id="Label63" runat="server" Font-Names="Calibri" Font-Size="Smaller">Name 
										of the Mother</asp:label>
								</TD>
								<TD style="WIDTH: 14px; HEIGHT: 25px" class="lables" height="25" align="center"><STRONG>:</STRONG></TD>
								<TD style="HEIGHT: 25px" class="lables" height="25" align="left"><asp:label id="lblStuMname" runat="server" Font-Names="Calibri" Font-Size="Smaller">Label</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 7px" class="lables" height="7" align="center"><asp:label id="Label50" runat="server" Height="20px" Width="100%" Font-Bold="True" Font-Names="Calibri"
										CssClass="lables" Font-Size="Smaller">4</asp:label></TD>
								<TD style="WIDTH: 321px; HEIGHT: 7px" class="lables" height="7" align="left"><asp:label id="Label7" runat="server" Font-Names="Calibri" Font-Size="Smaller">Nationality, Religion & Mother Tongue</asp:label></TD>
								<TD style="WIDTH: 14px; HEIGHT: 7px" class="lables" height="7" align="center"><STRONG>:</STRONG></TD>
								<TD style="HEIGHT: 7px" class="lables" height="7" align="left"><asp:label id="lblNationality" runat="server" Font-Names="Calibri" Font-Size="Smaller">Label</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 25px" class="lables" height="25" align="center">
									<asp:label id="Label51" runat="server" Height="20px" Width="100%" Font-Bold="True" Font-Names="Calibri"
										CssClass="lables" Font-Size="Smaller">5</asp:label></TD>
								<TD style="WIDTH: 321px; HEIGHT: 25px" class="lables" height="25" align="left">
									<asp:label id="Label8" runat="server" Height="20px" Width="100%" Font-Names="Calibri" Font-Size="Smaller">Wheather Candidate belongs to</asp:label></TD>
								<TD style="WIDTH: 14px; HEIGHT: 25px" class="lables" height="25" align="center"><STRONG>:</STRONG></TD>
								<TD style="HEIGHT: 7px" class="lables" height="7" align="left">
									<asp:label id="lblCaste" runat="server" Font-Names="Calibri" Font-Size="Smaller">Label</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 25px" class="lables" height="25" align="center"></TD>
								<TD style="WIDTH: 321px; HEIGHT: 25px" class="lables" height="25" align="left">
									<asp:label id="Label9" runat="server" Height="20px" Font-Names="Calibri" Font-Size="Smaller">OC, BC, SC & ST</asp:label></TD>
								<TD style="WIDTH: 14px; HEIGHT: 7px" class="lables" height="7" align="center"></TD>
								<TD style="HEIGHT: 7px" class="lables" height="7" align="left"></TD>
							</TR>
							
							
							
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 15px" class="lables" vAlign="top" align="center">
									<asp:label id="Label52" runat="server" Height="25px" Width="100%" Font-Bold="True" Font-Names="Calibri"
										CssClass="lables" Font-Size="Smaller">6</asp:label></TD>
								<TD style="WIDTH: 321px; HEIGHT: 15px" class="lables" vAlign="top" align="left">
									<asp:label id="Label14" runat="server" Font-Names="Calibri" Font-Size="Smaller">Date of Birth (In words) as entered in the</asp:label></TD>
								<TD style="WIDTH: 14px; HEIGHT: 15px" class="lables" height="15" align="center"><STRONG>:</STRONG></TD>
								<TD style="HEIGHT: 15px" class="lables" height="15" align="left">
									<P>
										<asp:label id="lblDob" runat="server" Font-Names="Calibri" Font-Size="Smaller">Label</asp:label></P>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 25px" class="lables" vAlign="top" align="center"></TD>
								<TD style="WIDTH: 321px; HEIGHT: 25px" class="lables" vAlign="top" align="left" > <asp:label id="Label1" runat="server" Font-Names="Calibri" Font-Size="Smaller">Admission Register </asp:label></P></TD>
								<TD style="WIDTH: 14px; HEIGHT: 25px" class="lables" height="4" vAlign="top" align="center"></TD>
								<TD style="HEIGHT: 25px" class="lables" height="4" align="left">
									<P><asp:label id="lblDobwords" runat="server" Width="100%" Font-Names="Calibri" Font-Size="Smaller">Label</asp:label></P>
								</TD>
							</TR>
							
							
							
							
							
							
							
							
							
							
							
							
							
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 25px" class="lables" height="25" vAlign="top" align="center"><asp:label id="Label61" runat="server" Height="20px" Width="100%" Font-Bold="True" Font-Names="Calibri"
										CssClass="lables" Font-Size="Smaller">7</asp:label></TD>
								<TD style="WIDTH: 321px; HEIGHT: 15px" class="lables" height="15" align="left" valign="top"><asp:label id="Label70" runat="server" Height="20px" Width="281px" Font-Names="Calibri" Font-Size="Smaller">Date of admission and class to</asp:label></TD>
								<TD style="WIDTH: 14px; HEIGHT: 25px" class="lables" height="25" align="center"></TD>
								<TD style="HEIGHT: 15px" class="lables" height="15" align="left"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 25px" class="lables" height="25" vAlign="top" align="center"></TD>
								<TD style="WIDTH: 321px; HEIGHT: 25px" class="lables" height="25" align="left"><asp:label id="Label69" runat="server" Height="20px" Width="280px" Font-Names="Calibri" Font-Size="Smaller">which Admitted</asp:label></TD>
								<TD style="WIDTH: 14px; HEIGHT: 25px" class="lables" height="25" align="center"><STRONG class="lables">:</STRONG></TD>
								<TD style="HEIGHT: 15px" class="lables" height="25" align="left"><asp:label id="lblpoint13a" runat="server" Font-Names="Calibri" Font-Size="Smaller">Label</asp:label></TD>
							</TR>
							
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 25px" class="lables" height="25" vAlign="top" align="center"><asp:label id="Label62" runat="server" Height="20px" Width="100%" Font-Bold="True" Font-Names="Calibri"
										CssClass="lables" Font-Size="Smaller">8</asp:label></TD>
								<TD style="WIDTH: 321px; HEIGHT: 25px" class="lables" height="25" align="left" valign="top"><asp:label id="Label73" runat="server" Height="20px" Width="281px" Font-Names="Calibri" Font-Size="Smaller">Class in which the pupil last studied</asp:label></TD>
								<TD style="WIDTH: 14px; HEIGHT: 25px" class="lables" height="25" align="center"><STRONG class="lables">:</STRONG></TD>
								<TD style="HEIGHT: 5px" class="lables" height="5" align="left"><asp:label id="Label5" runat="server" Font-Names="Calibri" Font-Size="Smaller">12th Class (10+2 Class)</asp:label></TD>
							</TR>
							
							
							
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 25px" class="lables" height="25" vAlign="top" align="center">
									<asp:label id="Label22" runat="server" Width="100%" Height="20px" Font-Names="Calibri" Font-Bold="True"
										Font-Size="Smaller" CssClass="lables">9</asp:label>
								</TD>
								<TD style="WIDTH: 321px; HEIGHT: 13px" class="lables" height="13" align="left" vAlign="top">
									<TABLE style="WIDTH: 269px; HEIGHT: 18px" id="Table12" border="0" cellSpacing="0" cellPadding="0"
										width="269">
										<TR>
											<TD style="HEIGHT: 1px">
												<asp:label id="Label24" runat="server" Height="20px" Width="281px" Font-Names="Calibri" Font-Size="Smaller">Subjects Studied</asp:label></TD>
											<TD style="HEIGHT: 1px" vAlign="top"></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD></TD>
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
												<P><STRONG></STRONG></P>
											</TD>
										</TR>
									</TABLE>
								</TD>
								<TD style="HEIGHT: 13px" class="lables" height="13" align="left" vAlign="top">
									<TABLE style="WIDTH: 301px; HEIGHT: 48px" id="Table16" border="0" cellSpacing="0" cellPadding="0"
										width="301">
										<TR>
											<TD><asp:label id="lblsubjectstudied" runat="server" Font-Names="Calibri" Font-Size="Smaller">Label</asp:label></TD>
										</TR>
										<TR>
											<TD>
												
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 9px" class="lables" height="9" vAlign="top" align="center"><asp:label id="Label65" runat="server" Height="20px" Width="100%" Font-Bold="True" Font-Names="Calibri"
										Font-Size="Smaller">10</asp:label></TD>
								<TD style="WIDTH: 321px; HEIGHT: 9px" class="lables" height="9" align="left" vAlign="top"><asp:label id="Label82" runat="server" Height="20px" Width="296px" Font-Names="Calibri" Font-Size="Smaller">Date on which the pupil has actually left the College</asp:label></TD>
								<TD style="WIDTH: 14px; HEIGHT: 9px" class="lables" height="9" align="center"><STRONG>:</STRONG></TD>
								<TD style="HEIGHT: 9px" class="lables" height="9" align="left"><asp:label id="lblPoint16" runat="server" Font-Names="Calibri" Font-Size="Smaller">Label</asp:label></TD>
							</TR>
                            <TR>
								<TD style="WIDTH: 67px; HEIGHT: 9px" class="lables" height="9" vAlign="top" align="center"><asp:label id="Label56" runat="server" Height="20px" Width="100%" Font-Bold="True" Font-Names="Calibri"
										Font-Size="Smaller">11</asp:label></TD>
								<TD style="WIDTH: 321px; HEIGHT: 9px" class="lables" height="9" align="left" vAlign="top"><asp:label id="Label59" runat="server" Height="20px" Width="296px" Font-Names="Calibri" Font-Size="Smaller">Promotions to Higher Classses</asp:label></TD>
								<TD style="WIDTH: 14px; HEIGHT: 9px" class="lables" height="9" align="center"><STRONG>:</STRONG></TD>
								<TD style="HEIGHT: 9px" class="lables" height="9" align="left"><asp:label id="Label60" runat="server" Font-Names="Calibri" Font-Size="Smaller">YES</asp:label></TD>
							</TR>

                            <TR>
								<TD style="WIDTH: 67px; HEIGHT: 9px" class="lables" height="9" vAlign="top" align="center"><asp:label id="Label53" runat="server" Height="20px" Width="100%" Font-Bold="True" Font-Names="Calibri"
										Font-Size="Smaller">12</asp:label></TD>
								<TD style="WIDTH: 321px; HEIGHT: 9px" class="lables" height="9" align="left" vAlign="top"><asp:label id="Label54" runat="server" Height="20px" Width="296px" Font-Names="Calibri" Font-Size="Smaller">Date of Application for the T.C.</asp:label></TD>
								<TD style="WIDTH: 14px; HEIGHT: 9px" class="lables" height="9" align="center"><STRONG>:</STRONG></TD>
								<TD style="HEIGHT: 9px" class="lables" height="9" align="left"><asp:label id="Label55" runat="server" Font-Names="Calibri" Font-Size="Smaller">Label</asp:label></TD>
							</TR>

                             <TR>
								<TD style="WIDTH: 67px; HEIGHT: 9px" class="lables" height="9" vAlign="top" align="center"><asp:label id="Label2" runat="server" Height="20px" Width="100%" Font-Bold="True" Font-Names="Calibri"
										Font-Size="Smaller">13</asp:label></TD>
								<TD style="WIDTH: 321px; HEIGHT: 9px" class="lables" height="9" align="left" vAlign="top"><asp:label id="Label3" runat="server" Height="20px" Width="296px" Font-Names="Calibri" Font-Size="Smaller">Reason for leaving</asp:label></TD>
								<TD style="WIDTH: 14px; HEIGHT: 9px" class="lables" height="9" align="center"><STRONG>:</STRONG></TD>
								<TD style="HEIGHT: 9px" class="lables" height="9" align="left"><asp:label id="Label4" runat="server" Font-Names="Calibri" Font-Size="Smaller">PROMOTED</asp:label></TD>
							</TR>
                            <TR>
								<TD style="WIDTH: 67px; HEIGHT: 9px" class="lables" height="9" vAlign="top" align="center"><asp:label id="Label43" runat="server" Height="20px" Width="100%" Font-Bold="True" Font-Names="Calibri"
										Font-Size="Smaller">14</asp:label></TD>
								<TD style="WIDTH: 321px; HEIGHT: 9px" class="lables" height="9" align="left" vAlign="top"><asp:label id="Label44" runat="server" Height="20px" Width="296px" Font-Names="Calibri" Font-Size="Smaller">Attendance of the pupil</asp:label></TD>
								<TD style="WIDTH: 14px; HEIGHT: 9px" class="lables" height="9" align="center"><STRONG>:</STRONG></TD>
								<TD style="HEIGHT: 9px" class="lables" height="9" align="left"><asp:label id="Label46" runat="server" Font-Names="Calibri" Font-Size="Smaller">Label</asp:label></TD>
							</TR>
                            <TR>
								<TD style="WIDTH: 67px; HEIGHT: 9px" class="lables" height="9" vAlign="top" align="center"><asp:label id="Label30" runat="server" Height="20px" Width="100%" Font-Bold="True" Font-Names="Calibri"
										Font-Size="Smaller">15</asp:label></TD>
								<TD style="WIDTH: 321px; HEIGHT: 9px" class="lables" height="9" align="left" vAlign="top"><asp:label id="Label38" runat="server" Height="20px" Width="296px" Font-Names="Calibri" Font-Size="Smaller">Total No. of Working days</asp:label></TD>
								<TD style="WIDTH: 14px; HEIGHT: 9px" class="lables" height="9" align="center"><STRONG>:</STRONG></TD>
								<TD style="HEIGHT: 9px" class="lables" height="9" align="left"><asp:label id="lbltotworkingdays" runat="server" Font-Names="Calibri" Font-Size="Smaller">Label</asp:label></TD>
							</TR>
                            <TR>
								<TD style="WIDTH: 67px; HEIGHT: 9px" class="lables" height="9" vAlign="top" align="center"><asp:label id="Label31" runat="server" Height="20px" Width="100%" Font-Bold="True" Font-Names="Calibri"
										Font-Size="Smaller">16</asp:label></TD>
								<TD style="WIDTH: 321px; HEIGHT: 9px" class="lables" height="9" align="left" vAlign="top"><asp:label id="Label32" runat="server" Height="20px" Width="296px" Font-Names="Calibri" Font-Size="Smaller">Wheather the people has paid all the dues to the school</asp:label></TD>
								<TD style="WIDTH: 14px; HEIGHT: 9px" class="lables" height="9" align="center"><STRONG>:</STRONG></TD>
								<TD style="HEIGHT: 9px" class="lables" height="9" align="left"><asp:label id="lbldues" runat="server" Font-Names="Calibri" Font-Size="Smaller">YES</asp:label></TD>
							</TR>
                            <TR>
								<TD style="WIDTH: 67px; HEIGHT: 5px" class="lables" height="5" vAlign="top" align="center"><asp:label id="Label28" runat="server" Height="20px" Width="100%" Font-Bold="True" Font-Names="Calibri"
										CssClass="lables" Font-Size="Smaller">17</asp:label></TD>
								<TD style="WIDTH: 321px; HEIGHT: 5px" class="lables" height="5" align="left" vAlign="top"><asp:label id="Label29" runat="server" Height="20px" Width="281px" Font-Names="Calibri" Font-Size="Smaller">Whether NCC Candidate</asp:label></TD>
								<TD style="WIDTH: 14px; HEIGHT: 5px" class="lables" height="5" align="center"><STRONG>:</STRONG></TD>
								<TD style="HEIGHT: 5px" class="lables" height="5" align="left"><asp:label id="lblncc" runat="server" Font-Names="Calibri" Font-Size="Smaller">Label</asp:label></TD>
							</TR>
                            <TR>
								<TD style="WIDTH: 67px; HEIGHT: 5px" class="lables" height="5" vAlign="top" align="center"><asp:label id="Label26" runat="server" Height="20px" Width="100%" Font-Bold="True" Font-Names="Calibri"
										CssClass="lables" Font-Size="Smaller">18</asp:label></TD>
								<TD style="WIDTH: 321px; HEIGHT: 5px" class="lables" height="5" align="left" vAlign="top"><asp:label id="Label27" runat="server" Height="20px" Width="281px" Font-Names="Calibri" Font-Size="Smaller">Games Played</asp:label></TD>
								<TD style="WIDTH: 14px; HEIGHT: 5px" class="lables" height="5" align="center"><STRONG>:</STRONG></TD>
								<TD style="HEIGHT: 5px" class="lables" height="5" align="left"><asp:label id="lblgameplayed" runat="server" Font-Names="Calibri" Font-Size="Smaller">Label</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 5px" class="lables" height="5" vAlign="top" align="center"><asp:label id="Label66" runat="server" Height="20px" Width="100%" Font-Bold="True" Font-Names="Calibri"
										CssClass="lables" Font-Size="Smaller">19</asp:label></TD>
								<TD style="WIDTH: 321px; HEIGHT: 5px" class="lables" height="5" align="left" vAlign="top"><asp:label id="Label85" runat="server" Height="20px" Width="281px" Font-Names="Calibri" Font-Size="Smaller">Date of Transfer Certificate</asp:label></TD>
								<TD style="WIDTH: 14px; HEIGHT: 5px" class="lables" height="5" align="center"><STRONG>:</STRONG></TD>
								<TD style="HEIGHT: 5px" class="lables" height="5" align="left"><asp:label id="lblPoint17" runat="server" Font-Names="Calibri" Font-Size="Smaller">Label</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 1px" class="lables" height="1" vAlign="top" align="center"><asp:label id="Label67" runat="server" Font-Bold="True" Font-Names="Calibri" CssClass="lables"
										Font-Size="Smaller">20</asp:label></TD>
								<TD style="WIDTH: 321px; HEIGHT: 1px" class="lables" height="1" align="left" vAlign="top"><asp:label id="Label88" runat="server" Width="281px" Font-Names="Calibri" Font-Size="Smaller">General Conduct</asp:label></TD>
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
								<TD style="HEIGHT: 1px" class="lables" height="1" align="right"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 67px; HEIGHT: 1px" class="lables" height="1" vAlign="top" align="center"><STRONG>STAMP</STRONG></TD>
								<TD style="WIDTH: 321px; HEIGHT: 1px" class="lables" height="1" align="left"></TD>
								<TD style="WIDTH: 14px; HEIGHT: 1px" class="lables" height="1" align="center"></TD>
								<TD style="HEIGHT: 1px" class="lables" height="1" align="right"><STRONG>PRINCIPAL</STRONG>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
