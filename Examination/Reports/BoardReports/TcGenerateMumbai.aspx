<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TcGenerateMumbai.aspx.vb" Inherits="CollegeBoard.TcGenerateMumbai" %>

<!DOCTYPE html>

<HTML>
	<HEAD>
		<title>TcGenerateNew</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
       
	    <style type="text/css">
            .auto-style1 {
                width: 67px;
                height: 25px;
            }
            .auto-style2 {
                width: 321px;
                height: 25px;
            }
            .auto-style3 {
                width: 14px;
                height: 25px;
            }
            .lables {}
        </style>
	</HEAD>
	<body onload="pageset();" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
          
			<TABLE style="Z-INDEX: 101; LEFT: 8px; WIDTH: 680px; POSITION: absolute; TOP: 8px" border="0"
				cellSpacing="0" cellPadding="0" width="659" align="center">
				<TR>
                     
					<TD align="center">
                
						<TABLE style="WIDTH: 680px" id="Table1"  border="0" cellSpacing="0" cellPadding="0" 
							align="center">
							<tr>
								<td colspan="3">
									<TABLE style="WIDTH: 821px; HEIGHT: 125px" id="Table4" border="0" cellSpacing="0" cellPadding="0"
										width="621" align="center">
										<TR>
											<TD vAlign="top" rowSpan="4" width="12%" align="center"><asp:image id="Image1" runat="server" Height="112px" Width="91px" ImageUrl="~/Images/NewImages/Narayana Logo.jpg.jpg"></asp:image></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 800px"  align="center">
												<TABLE id="Table5" border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
													<TR>
														<TD style="HEIGHT: 15px" align="right">
															<asp:label id="lblDocumentId" runat="server" Width="160px" Font-Bold="True" Font-Names="Calibri">1</asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
													</TR>
                                                    <TR>
														<TD align="left"><asp:label id="Label6" runat="server" Height="10px" Width="558px" Font-Names="Calibri"
																CssClass="lables" Font-Size="Large">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NARAYANA EDUCATIONAL TRUST'S</asp:label></TD>
													</TR>
													<TR>
														<TD align="left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:label id="lblTCColName" runat="server" Height="10px" Width="558px" Font-Names="Calibri"  Font-Bold="True" 
																CssClass="lables" Font-Size="Large"></asp:label></TD>
                                                      
													</TR>
													<TR>
                                                        <td align="left" >
                                                            <table align="left" >
                                                                <tr>
                                                                    <TD align="left" ><asp:label id="lblAdress" runat="server"  Font-Bold="true" Font-Names="Calibri"
																CssClass="lables" Font-Size="10px"></asp:label>
                                                                        </TD>
                                                                    <TD align="left" >

                                                            <asp:label id="lblzip" runat="server"  Font-Bold="true" Font-Names="Calibri" align="top"
																CssClass="lables" Font-Size="10px"></asp:label>
														</TD>
                                                                </tr>
                                                            </table>
                                                        </td>
														
													</TR>
                                                    <tr>
                                                       
                                                        <TD style="HEIGHT: 17px"  align="right">
                                                            
                                                        </TD>
                                                    </tr>
													<TR>
														<TD style="HEIGHT: 17px" align="left">

														</TD>
													</TR>
													<TR>
														<TD height="16" align="center">
															

														</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</td>
							</tr>

                           
							<TR>
								<TD colSpan="3">
                                    <table  id="table6" width="80%" align="left">
                                                                <tr>
                                                                       <TD style="HEIGHT: 17px" align="left" width="10px"><asp:label id="Label26" runat="server" Height="9px" Width="128px"  Font-Names="Calibri" CssClass="lables"
																Font-Size="X-Small">Taluka:</asp:label></TD>
                                                                    <TD style="HEIGHT: 17px" align="left"width="15px"><asp:label id="lblthaluka" runat="server" Height="9px"  Font-Names="Calibri" CssClass="lables" Width="158px"
																Font-Size="X-Small"></asp:label></TD>

                                                                    <TD style="HEIGHT: 17px" align="left" width="8px" ><asp:label id="Label21" runat="server" Height="9px" Width="108px"  Font-Names="Calibri" CssClass="lables"
																Font-Size="X-Small">District:</asp:label></TD>
                                                                    <TD style="HEIGHT: 17px" align="left" ><asp:label id="lbldistrict" runat="server" Height="9px"  Font-Names="Calibri" CssClass="lables" Width="108px"
																Font-Size="X-Small"></asp:label></TD>
                                                                </tr>
                                                               <tr>
                                                                    <TD style="HEIGHT: 17px" align="left"><asp:label id="Label27" runat="server" Height="9px" Width="158px"  Font-Names="Calibri" CssClass="lables"
																Font-Size="X-Small">Tel:</asp:label></TD>
                                                                    <TD style="HEIGHT: 17px" align="left"><asp:label id="lbltele" runat="server" Height="9px"  Font-Names="Calibri" CssClass="lables" Width="158px"
																Font-Size="X-Small"></asp:label></TD>
                                                                    <TD style="HEIGHT: 17px" align="left"><asp:label id="Label25" runat="server" Height="9px" Width="108px"  Font-Names="Calibri" CssClass="lables"
																Font-Size="X-Small">E-mail:</asp:label></TD>
                                                                    <TD style="HEIGHT: 17px" align="left"><asp:label id="lblmail" runat="server" Height="9px"  Font-Names="Calibri" CssClass="lables" Width="108px"
																Font-Size="X-Small"></asp:label></TD>
                                                                </tr>
                                        <tr>
                                             <TD style="HEIGHT: 17px" align="left" ><asp:label id="Label28" runat="server" Height="9px" Width="158px"  Font-Names="Calibri" CssClass="lables"
																Font-Size="X-Small">SERIAL NO:</asp:label></TD>
                                                                    <TD style="HEIGHT: 17px" align="left"><asp:label id="lblslno" runat="server" Height="9px"  Font-Names="Calibri" CssClass="lables" Width="158px"
																Font-Size="X-Small">____________</asp:label></TD>
                                                                    <TD style="HEIGHT: 17px" align="left"><asp:label id="Label30" runat="server" Height="9px" Width="108px"  Font-Names="Calibri" CssClass="lables"
																Font-Size="X-Small">G.RNO:</asp:label></TD>
                                                                    <TD style="HEIGHT: 17px" align="left"><asp:label id="lblgrno" runat="server" Height="9px"  Font-Names="Calibri" CssClass="lables" Width="108px"
																Font-Size="X-Small"></asp:label></TD>
                                        </tr>
                                         <tr>
                                             <TD style="HEIGHT: 17px" align="left" ><asp:label id="Label32" runat="server" Height="9px" Width="158px"  Font-Names="Calibri" CssClass="lables"
																Font-Size="X-Small">PERMISSION NO:</asp:label></TD>
                                                                    <TD style="HEIGHT: 17px" align="left"><asp:label id="lblpermssion" runat="server" Height="9px"  Font-Names="Calibri" CssClass="lables" Width="108px"
																Font-Size="X-Small"></asp:label></TD>
                                                                    <TD style="HEIGHT: 17px" align="left"><asp:label id="Label36" runat="server" Height="9px" Width="108px"  Font-Names="Calibri" CssClass="lables"
																Font-Size="X-Small">MEDIUM:</asp:label></TD>
                                                                    <TD style="HEIGHT: 17px" align="left"><asp:label id="lblmed" runat="server" Height="9px"  Font-Names="Calibri" CssClass="lables" Width="108px"
																Font-Size="X-Small"></asp:label></TD>
                                        </tr>
                                       <tr>
                                            <TD style="HEIGHT: 17px" align="left" ><asp:label id="Label35" runat="server" Height="9px" Width="158px"  Font-Names="Calibri" CssClass="lables"
																Font-Size="X-Small">UDISE NUMBER:</asp:label></TD>
                                                                    <TD style="HEIGHT: 17px" align="left"><asp:label id="lbludise" runat="server" Height="9px"  Font-Names="Calibri" CssClass="lables" Width="158px"
																Font-Size="X-Small"></asp:label></TD>
                                                                   
                                                                
                                            <TD style="HEIGHT: 17px" align="left"><asp:label id="Label46" runat="server" Height="9px" Width="80px"  Font-Names="Calibri" CssClass="lables"
																Font-Size="X-Small">COLLEGE INDEX NUMBER:</asp:label></TD>
                                                                    <TD style="HEIGHT: 17px" align="left"><asp:label id="lblcode" runat="server" Height="9px"  Font-Names="Calibri" CssClass="lables" Width="128px"
																Font-Size="X-Small"></asp:label></TD>
                                        </tr>
                                                            </table>
                                   
								</TD>
							</TR>
                            <tr>
                                <td>

                                </td>
                            </tr>
							<TR height="25px">
								<TD style="WIDTH: 100%; HEIGHT: 25px" class="lables" vAlign="top"  colSpan="3"
									align="left" >
								
										&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp<asp:label id="Label33" runat="server" Font-Names="Calibri" Font-Bold="True" Font-Size="Large">COLLEGE LEAVING CERTIFICATE </asp:label>
											
								</TD>
							</TR>
                            <tr>
                                <td></td>
                            </tr>
							<TR  height="25px" >
								<%--<TD style="WIDTH: 10PX" class="lables" height="10" vAlign="top"  align="center"><FONT size="2" face="Calibri"></FONT></TD>--%>
								<TD style="WIDTH: 121px" class="lables" vAlign="top" align="left" height="25px" vAlign="top"><asp:label id="Label2" runat="server" height="20px" Width="100%" Font-Names="Calibri" Font-Size="X-Small">STUDENT ID:</asp:label></TD>
								<%--<TD style="WIDTH: 14px" class="lables" height="10" vAlign="top" align="center"><STRONG></STRONG></TD>--%>
								<TD class="lables"  width="180px" vAlign="top" align="left" height="25px" ><asp:label id="lblClgNameCode" runat="server" height="20px" Font-Names="Calibri" Font-Size="X-Small">Label</asp:label></TD>
							</TR>
							
							
							<TR  height="25px" >
							<%--	<TD style="WIDTH: 10px; HEIGHT: 25px" class="lables" height="25" align="center"</TD>--%>
								<TD style="WIDTH: 321px; HEIGHT: 20px" class="lables" height="20px" align="left" vAlign="top">
									
                                    <asp:label id="Label1" runat="server" Height="20px" Width="100%" Font-Names="Calibri" Font-Size="X-Small">UID (ADHAR CARD NUMBER):</asp:label>
								</TD>
							
								<TD style="HEIGHT: 20px" class="lables" height="20px" align="left" vAlign="top"><asp:label id="lbladhar" runat="server" Height="20px" Font-Names="Calibri" Font-Size="X-Small">Label</asp:label></TD>
							</TR>
							<TR height="25px">

                                
							<%--	<TD class="auto-style1" align="center"></TD>--%>
								<TD  align="left" Height="20px" vAlign="top"><asp:label id="Label3" runat="server" Height="20px"  Font-Names="Calibri" Font-Size="X-Small">STUDENT FULL NAME:</asp:label>&nbsp<asp:label id="lblname" Height="20" runat="server" Font-Names="Calibri" Font-Size="X-Small"></asp:label></TD>
								
								<TD  align="left" Height="20px" vAlign="top"><asp:label id="Label8" runat="server" Height="20px"  Font-Names="Calibri" Font-Size="X-Small">FATHER NAME:</asp:label>&nbsp<asp:label id="lblFNAME" Height="20" runat="server" Font-Names="Calibri" Font-Size="X-Small"></asp:label></TD>
							</TR>
                         
							<TR height="25px">
								<%--<TD style="WIDTH: 10px; HEIGHT: 7px" class="lables" height="7" align="center"></TD>--%>
								<TD style="WIDTH: 321px; HEIGHT: 20px" class="lables" height="7" align="left" vAlign="top"><asp:label id="Label9" runat="server" Height="20px"  Font-Names="Calibri" Font-Size="X-Small">SURNAME:</asp:label>&nbsp<asp:label id="lblsurname"  Height="20px" runat="server" Font-Names="Calibri" Font-Size="X-Small"></asp:label></TD>
								
								<TD style="HEIGHT: 25px" class="lables" height="20px" align="left" vAlign="top"><asp:label id="Label48" runat="server" Height="20px"  Font-Names="Calibri" Font-Size="X-Small">MOTHER NAME:</asp:label>&nbsp<asp:label id="lblStuMname" runat="server" Height="20px" Font-Names="Calibri" Font-Size="X-Small"></asp:label></TD>
							</TR>
							<TR height="25px">
							<%--	<TD style="WIDTH: 10px; HEIGHT: 7px" class="lables" height="7" align="center"></TD>--%>
								<TD style="WIDTH: 321px; HEIGHT: 20px" class="lables" height="7" align="left" vAlign="top"><asp:label id="Label7" runat="server" Font-Names="Calibri" Height="20" Font-Size="X-Small">Nationality:</asp:label>&nbsp&nbsp<asp:label id="lblnationalty" Height="20" runat="server" Font-Names="Calibri" Font-Size="X-Small"></asp:label></TD>
								
								<TD style="HEIGHT: 20px" class="lables" height="20" align="left" vAlign="top"><asp:label id="lblNationality" runat="server" Height="20" Font-Names="Calibri" Font-Size="X-Small">MOTHERTONGUE:</asp:label>&nbsp&nbsp <asp:label id="lblmothertongue" Height="20" runat="server" Font-Names="Calibri" Font-Size="X-Small"></asp:label></TD>
							</TR>
							<TR height="25px">
								<%--<TD style="WIDTH: 10px; HEIGHT: 25px" class="lables" height="25" align="center">
									</TD>--%>
								<TD style="WIDTH: 181px; HEIGHT: 20px" class="lables" height="20" align="left" vAlign="top">
									<asp:label id="Label13" runat="server" Height="20"  Font-Names="Calibri" Font-Size="X-Small">RELIGION:</asp:label>
                                    <asp:label id="lblreligion" runat="server"  Height="20" Font-Names="Calibri" Font-Size="X-Small"></asp:label>
                                    
                                    &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                   
                                    <asp:label id="Label14" runat="server" Height="20"  Font-Names="Calibri" Font-Size="X-Small">CASTE:</asp:label>
                                    <asp:label id="lblCaste" runat="server" Height="20" Font-Names="Calibri" Font-Size="X-Small"></asp:label>
                                   </TD>
							
								<TD style="HEIGHT: 20px" class="lables" height="20" align="left" vAlign="top">
									
                                    <asp:label id="Label15" runat="server" Height="20"  Font-Names="Calibri" Font-Size="X-Small">SUB-CASTE:</asp:label>
                                    <asp:label id="lblsubcaste" runat="server" Height="20" Font-Names="Calibri" Font-Size="Smaller"></asp:label></TD>
							</TR>
							<TR height="25px">
								<%--<TD style="WIDTH: 10px; HEIGHT: 25px" class="lables" height="25" align="center"></TD>--%>
								<TD style="WIDTH: 321px; HEIGHT: 20px" class="lables" height="20px" align="left" vAlign="top">
									
                                    <asp:label id="Label16" runat="server" Height="20"  Font-Names="Calibri" Font-Size="X-Small">PLACE OF BIRTH(CITY/VILLAGE):</asp:label>
                                    <asp:label id="lblplaceofbirth" runat="server"  Height="20" Font-Names="Calibri" Font-Size="X-Small"></asp:label>
                                    &nbsp&nbsp&nbsp                             
                                    
                                     <asp:label id="Label17" runat="server" Height="20"  Font-Names="Calibri" Font-Size="X-Small">DIST:</asp:label>
                                    <asp:label id="lbldist" runat="server"  Height="20" Font-Names="Calibri" Font-Size="X-Small"></asp:label>
                                    
								</TD>
									
								
								<TD style="WIDTH: 321px; HEIGHT: 20px" class="lables" height="20" align="left" vAlign="top">
                                   
                                     <asp:label id="Label18" runat="server" Height="20"  Font-Names="Calibri" Font-Size="X-Small">STATE:</asp:label>
                                    <asp:label id="lblstate" runat="server" Height="20" Font-Names="Calibri" Font-Size="X-Small"></asp:label>
                                    &nbsp
                                  
                                     <asp:label id="Label19" runat="server" Height="20"  Font-Names="Calibri" Font-Size="X-Small">COUNTRY:</asp:label>
                                   
                                    <asp:label id="lblcountry" runat="server" Height="20" Font-Names="Calibri" Font-Size="X-Small"></asp:label>
                                   

								</TD>
							</TR>
							<TR height="25px">
								<%--<TD style="WIDTH: 10px; HEIGHT: 25px" class="lables" height="25" align="center"></TD>--%>
								<TD style="WIDTH: 321px; HEIGHT: 25px" class="lables" height="25" align="left" vAlign="top">
									<asp:label id="Label10" runat="server" Height="20" Font-Names="Calibri" Font-Size="X-Small">DATE OF BIRTH(according to christian era):</asp:label>
                                   
								</TD>
							
								<TD style="HEIGHT: 7px" class="lables" height="7" align="left" vAlign="top"> <asp:label id="lbldobace" runat="server" Height="20px" Font-Names="Calibri" Font-Size="X-Small" ></asp:label></TD>
							</TR>
							<TR height="25px">
								<%--<TD style="WIDTH: 10px; HEIGHT: 7px" class="lables" height="7" align="center"></TD>--%>
								<TD style="WIDTH: 321px; HEIGHT: 25px" class="lables" height="25" align="left" vAlign="top">
									<asp:label id="Label11" runat="server" Height="20" Width="328px" Font-Names="Calibri" Font-Size="X-Small">DATE OF BIRTH(IN WORDS)</asp:label>
                                   
								</TD>
								
								<TD style="HEIGHT: 7px" class="lables" height="7" align="left" vAlign="top">
                                     <asp:label id="lbldobwords" runat="server" Height="20" Width="328px" Font-Names="Calibri" Font-Size="X-Small"></asp:label>
								</TD>
							</TR>
							<TR height="25px">
								<%--<TD style="WIDTH: 10px; HEIGHT: 25px" class="lables" height="25" align="center"></TD>--%>
								<TD style="WIDTH: 321px; HEIGHT: 25px" class="lables" height="25" align="left" vAlign="top">
									<asp:label id="Label12" runat="server" Font-Names="Calibri" height="20" Font-Size="X-Small">PREVIOUS SCHOOL NAME AND CLASS:</asp:label>
                                  
								</TD>
                                <TD style="WIDTH: 321px; HEIGHT: 25px" class="lables" height="25" align="left" vAlign="top">
									<asp:label id="lblpresch" runat="server" Font-Names="Calibri" height="20" Font-Size="X-Small"></asp:label>
								</TD>
								<%--<TD style="WIDTH: 14px; HEIGHT: 7px" class="lables" height="7" align="center"></TD>
								<TD style="HEIGHT: 7px" class="lables" height="7" align="left"><asp:label id="Label8" runat="server" Font-Names="Calibri" Font-Size="Smaller"></asp:label></TD>--%>
							</TR>
							<TR height="25px">
							
								<TD style="WIDTH: 321px; HEIGHT: 15px" class="lables" vAlign="top" align="left" vAlign="top">
									     <asp:label id="Label20" runat="server" Font-Names="Calibri" height="20" Font-Size="X-Small">DATE OF ADMISSION:</asp:label>&nbsp<asp:label id="lbladmission" Height="20" runat="server" Font-Names="Calibri" Font-Size="X-Small"></asp:label></TD>
							
								<TD style="HEIGHT: 15px" class="lables" height="15" align="left" vAlign="top">
									
										<asp:label id="Label22" runat="server" Height="20"  Font-Names="Calibri" Font-Size="X-Small">CLASS:</asp:label> <asp:label id="lblCLASS" Height="20" runat="server" Font-Names="Calibri" Font-Size="X-Small"></asp:label>
								</TD>
							</TR>
                            <TR height="25px">
							<%--	<TD style="WIDTH: 10px; HEIGHT: 15px" class="lables" vAlign="top" align="center">
									</TD>--%>
								<TD style="WIDTH: 321px; HEIGHT: 15px" class="lables" vAlign="top" align="left" vAlign="top">
									<asp:label id="Label23" runat="server" Height="20"  Font-Names="Calibri" Font-Size="X-Small">PROGRESS IN STUDIES:</asp:label>
                                    <asp:label id="lblpis" runat="server" Height="20" Font-Names="Calibri" Font-Size="X-Small"></asp:label></TD>
							
								<TD style="HEIGHT: 15px" class="lables" height="15" align="left" vAlign="top">
									
										<asp:label id="Label24" runat="server" Height="20"  Font-Names="Calibri" Font-Size="X-Small">CONDUCT IN SCHOOL:</asp:label><asp:label id="lblconduct" runat="server" Height="20" Font-Names="Calibri" Font-Size="X-Small"></asp:label>
								</TD>
							</TR>
							
							<TR height="25px">
								<%--<TD style="WIDTH: 10px; HEIGHT: 15px" class="lables" vAlign="top" align="center">
									</TD>--%>
								<TD style="WIDTH: 321px; HEIGHT: 15px" class="lables" vAlign="top" align="left" vAlign="top">
									<asp:label id="Label29" runat="server" Height="20"  Font-Names="Calibri" Font-Size="X-Small">DATE OF LEAVING COLLEGE:</asp:label></TD>
								<TD style="WIDTH: 321px; HEIGHT: 15px" class="lables" vAlign="top" align="left" vAlign="top">
                                    &nbsp<asp:label id="lblDLC" runat="server" Height="20" Font-Names="Calibri" Font-Size="X-Small"></asp:label>
                                    </TD>
							</TR>
							<TR height="25px">
							<%--	<TD style="WIDTH: 10px; HEIGHT: 15px" class="lables" vAlign="top" align="center">
									</TD>--%>
								<TD style="WIDTH: 321px; HEIGHT: 15px" class="lables" vAlign="top" align="left">
									<asp:label id="Label31" runat="server" Height="20px"  Font-Names="Calibri" Font-Size="X-Small">STD.IN WHICH STUDYING AND SINCE WHEN(IN FIGURE AND WORDS):</asp:label></TD>
								
								<TD style="HEIGHT: 25px" class="lables" height="25" align="left" vAlign="top"><asp:label id="lblstdword" runat="server" Height="20" Font-Names="Calibri" Font-Size="X-Small"></asp:label></TD>
							</TR>
							
							<TR runat="server" visible="false" height="25px">
							<%--	<TD style="WIDTH: 67px; HEIGHT: 25px" class="lables" height="25" align="center"></TD>--%>
								<TD style="WIDTH: 321px; HEIGHT: 25px" class="lables" height="25" align="left" vAlign="top"><asp:label id="Label34" runat="server" Height="20"  Font-Names="Calibri" Font-Size="X-Small">(words)</asp:label></TD>
								
								<TD style="HEIGHT: 5px" class="lables" height="5" align="left" vAlign="top"><asp:label id="lblwords" runat="server" Height="20" Font-Names="Calibri" Font-Size="X-Small"></asp:label></TD>
							</TR>
							<TR height="25px">
							<%--	<TD style="WIDTH: 10px; HEIGHT: 25px" class="lables" height="25" align="center"></TD>--%>
								<TD style="WIDTH: 321px; HEIGHT: 25px" class="lables" height="25" align="left" vAlign="top"><asp:label id="Label37" runat="server" Height="20"  Font-Names="Calibri" Font-Size="X-Small">REASON FOR LEAVING COLLEGE</asp:label>&nbsp</TD>
								
								<TD style="HEIGHT: 3px" class="lables" height="3" align="left" vAlign="top"><asp:label id="lblresonlevingcol" Height="20" runat="server" Font-Names="Calibri" Font-Size="X-Small"></asp:label></TD>
							</TR>
							<TR height="25px">
								
								<TD style="WIDTH: 321px; HEIGHT: 25px" class="lables" height="25" align="left" valign="top"><asp:label id="Label41" Height="20" runat="server" Font-Names="Calibri" Font-Size="X-Small">REMARKS:</asp:label></TD>
								
								<TD style="HEIGHT: 7px" class="lables" height="25" align="left" vAlign="top"><asp:label id="lblremarks" Height="20" runat="server" Font-Names="Calibri" Font-Size="X-Small"></asp:label></TD>
							</TR>
							
							
						
						
						</TABLE>
                        <table WIDTH="90%">
                            <TR>
								
								<TD style="font-weight: bold; font-size: xx-large;" align="left">
                                    <FONT size="1" face="Calibri"  >


								 Certified that the above school leaving certificate information mentioned is in accordance with the  school General Register number 1.</FONT>
                                    </TD>
                              
							</TR>

                        </table>
                         <table WIDTH="90%" align="center" >
                            <TR>
							
								<TD style="WIDTH: 321px; HEIGHT: 25px" class="lables" height="25" align="left" valign="top">
									<asp:label id="Label38" runat="server" Height="20"  Font-Names="Calibri" Font-Size="X-Small">DATE:</asp:label><asp:label id="lbldate" Height="20" runat="server" Font-Names="Calibri" Font-Size="X-Small"></asp:label>&nbsp&nbsp&nbsp&nbsp&nbsp
                                    <asp:label id="Label39" runat="server" Height="20"  Font-Names="Calibri" Font-Size="X-Small">MONTH:</asp:label><asp:label id="lblmonth" Height="20" runat="server" Font-Names="Calibri" Font-Size="X-Small"></asp:label>&nbsp&nbsp&nbsp&nbsp&nbsp
                                    <asp:label id="Label42" runat="server" Height="20"  Font-Names="Calibri" Font-Size="X-Small">YEAR:</asp:label><asp:label id="lblyear" Height="20" runat="server" Font-Names="Calibri" Font-Size="X-Small"></asp:label>
								</TD>
								
							</TR>

                        </table>
                        <table  width="90%" align="center">
                            
                            <TR>
								
								<TD style="WIDTH: 321px; HEIGHT: 20px" class="lables"  align="left" valign="top">
									<asp:label id="Label43" runat="server" Height="20"  Font-Names="Calibri" Font-Size="X-Small">CLASS TEACHER:</asp:label><asp:label id="lblclassteacher" runat="server" Height="20" Font-Names="Calibri" Font-Size="X-Small"></asp:label>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                   
                                    <asp:label id="Label44" runat="server" Height="20"  Font-Names="Calibri" Font-Size="X-Small">CLERK:</asp:label>
                                    <asp:label id="lblcleark" runat="server" Height="20" Font-Names="Calibri" Font-Size="X-Small"></asp:label>
                                  
								</TD>
								
								<TD style="HEIGHT: 25px" class="lables"  align="left"><asp:label id="Label45" runat="server" Height="20"  Font-Names="Calibri" Font-Size="X-Small">PRINCIPAL:</asp:label><br>
                                            <asp:label id="Label47" runat="server" Height="20"  Font-Names="Calibri" Font-Size="X-Small">(STAMP/SIGN)</asp:label>
                                        </TD>
							</TR>
                            
                            
                        </table>
                        <table width="80%" align="left" style="height: 36px">
                            <tr>
                                <td>
                                    <asp:label id="Label5" runat="server" Font-Names="Calibri" Font-Size="X-Small">-------------------------------------------------------------------------------------------------------------------------------------------------------------------------</asp:label>
                                </td>
                            </tr>
                           <tr>
                                <td style="font-weight: bold; font-size: xx-large;" align="left" >
                                    <FONT size="1" face="Calibri" >
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp  NOTE:-1) Any illegal correction or change in any entry made in the school leaving certificate, is an offence and strict legal action will be taken</FONT>
                                </td>
                            </tr>
                           
                        </table>
                             
					</TD>
				</TR>
                
			</TABLE>
                
             
           
		</form>
      
	</body>
</HTML>
