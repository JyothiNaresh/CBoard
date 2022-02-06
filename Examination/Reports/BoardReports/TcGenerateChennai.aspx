<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TcGenerateChennai.aspx.vb" Inherits="CollegeBoard.TcGenerateChennai" %>

<!DOCTYPE html>

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
          
            <table style="z-index: 101; left: 8px; width: 750px; position: absolute; top: 8px" border="0"
                cellspacing="0" cellpadding="0" width="659" align="center">
                <tr>

                    <td align="center">

                        <table style="width: 750px" id="Table1" border="0" cellspacing="0" cellpadding="0"
                            align="center">
                            <tr>
                                <td colspan="3">
                                    <table style="width: 871px; height: 125px" id="Table4" border="0" cellspacing="0" cellpadding="0"
                                        width="621" align="center">
                                        <tr>
                                            <td valign="top" rowspan="4" width="12%" align="center">
                                                <asp:Image ID="Image1" runat="server" Height="112px" Width="91px" ImageUrl="~/Images/NewImages/Narayana Logo.jpg.jpg"></asp:Image></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 800px" align="center">
                                                <table id="Table5" border="0" cellspacing="0" cellpadding="0" width="100%" align="center">
                                                    <tr>
                                                        <td style="height: 15px" align="right">
                                                            <asp:Label ID="lblDocumentId" runat="server" Width="160px" Font-Bold="True" Font-Names="Calibri">1</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                                    </tr>
                                                  <%--  <tr>
                                                        <td align="left">
                                                            <asp:Label ID="Label6" runat="server" Height="10px" Width="558px" Font-Names="Calibri"
                                                                CssClass="lables" Font-Size="Large">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NARAYANA EDUCATIONAL TRUST'S</asp:Label></td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td align="left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblTCColName" runat="server" Height="10px" Width="558px" Font-Names="Calibri" Font-Bold="True"
                                                            CssClass="lables" Font-Size="Large"></asp:Label></td>

                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <table align="left">
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblAdress" runat="server" Font-Bold="true" Font-Names="Calibri"
                                                                            CssClass="lables" Font-Size="10px"></asp:Label>
                                                                    </td>
                                                                    
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">

                                                                        <asp:Label ID="lblzip" runat="server" Font-Bold="true" Font-Names="Calibri"
                                                                            CssClass="lables" Font-Size="10px"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>

                                                    </tr>
                                                   
                                                    <tr>
                                                        <td height="16" align="left">

                                                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lable" runat="server" Text="TRANSFER CERTIFICATE" Font-Bold="True" BackColor="Black" ForeColor="White"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        
                                    </table>
                                </td>
                            </tr>
                           




                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%">
                            <tr>
                               
                                <td style="height: 15px;width:10%;align:right">
                                                            <asp:Label ID="Label1" runat="server" Width="70px" Font-Bold="True" Font-Names="Calibri">Book No:</asp:Label></td>
                                <td style="height: 15px" align="left">
                                     <asp:Label ID="lblbookno" runat="server" Width="70px" Font-Bold="True" Font-Names="Calibri"></asp:Label>
                                </td>
                               <td style="height: 15px;width:5%;align:right">
                                                            <asp:Label ID="Label2" runat="server" Width="50px" Font-Bold="True" Font-Names="Calibri">Sl.No:</asp:Label></td>
                                <td style="height: 15px" align="left">
                                      <asp:Label ID="lblsno" runat="server" Width="65px" Font-Bold="True" Font-Names="Calibri"></asp:Label>
                                </td>
                                <td style="height: 15px;width:12%;align:right">
                                                            <asp:Label ID="Label3" runat="server" Width="110px" Font-Bold="True" Font-Names="Calibri" align="right">Admission No:</asp:Label></td>
                                <td style="height: 15px" align="left">
                                      <asp:Label ID="lbladmno" runat="server" Width="120px" Font-Bold="True" Font-Names="Calibri"></asp:Label>
                                </td>
                           
                            </tr>
                            
                        </table>
                        </td>
                    </tr>
            
                <tr>
                    <td style="height: 15px" align="left">
                        <table width="100%" >
                            <tr>
                               
                    <td style="height: 15px" align="left" >
                         <asp:Label ID="Label4" runat="server" Width="120px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small">1.Name of Pupil</asp:Label>
                    </td>
                    <td style="height: 15px" align="left">
                         <asp:Label ID="lblstudentname" runat="server" Width="120px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                    </td>
               
                            </tr>
                            <tr>
                                <td>
                                      <asp:Label ID="Label5" runat="server" Width="120px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small">2. Father’s / Guardian’s Name </asp:Label>
                                </td>
                                <td>
                                      <asp:Label ID="lblfathername" runat="server" Width="120px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                      <asp:Label ID="Label7" runat="server" Width="120px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small">3. Nationality </asp:Label>
                                </td>
                                <td>
                                      <asp:Label ID="lblnationalty" runat="server" Width="120px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                </td>
                            </tr>
                             <tr>
                                <td>
                                      <asp:Label ID="Label8" runat="server" Width="400px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small">4. Whether the candidate belongs to schedule Caste or schedule Tribe </asp:Label>
                                </td>
                                <td>
                                      <asp:Label ID="lblscheduleTribe" runat="server" Width="120px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                </td>
                            </tr>
                             <tr>
                                <td>
                                      <asp:Label ID="Label9" runat="server" Width="300px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small">5. Date of first admission in the school with class </asp:Label>
                                </td>
                                <td>
                                      <asp:Label ID="lblfirstadmission" runat="server" Width="120px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                </td>
                            </tr>
                             <tr>
                                <td>
                                      <asp:Label ID="Label10" runat="server" Width="360px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small">6.Date of Birth (in Christian Era)according to Admission Register </asp:Label>
                                </td>
                                <td>
                                      <asp:Label ID="lable11" runat="server" Width="120px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small">...................</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblfigure" runat="server" Width="120px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small">(inwords)</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblwords" runat="server" Width="120px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small">...................</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label11" runat="server" Width="300px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small">7. Class in which the pupil last studied (in figures)</asp:Label>  <asp:Label ID="lblinfigure" runat="server" Width="120px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small">...................</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label12" runat="server" Width="80px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small">(in words)</asp:Label>  <asp:Label ID="Label13" runat="server" Width="120px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small">...................</asp:Label>
                                </td>
                            </tr>
                             <tr>
                                <td>
                                    <asp:Label ID="Label14" runat="server" Width="330px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small">8. School / Board Annual examination last taken with result </asp:Label> 
                                </td>
                                <td>
                                      <asp:Label ID="lblschoolanualexamination" runat="server" Width="120px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small">...................</asp:Label>
                                </td>
                            </tr>
                             <tr>
                                <td>
                                    <asp:Label ID="Label15" runat="server" Width="300px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small">9. Whether failed, if so once / twice in the same class </asp:Label> 
                                </td>
                                <td>
                                      <asp:Label ID="lblfailed" runat="server" Width="120px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small">...................</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label16" runat="server" Width="120px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small">10. Subject Studied </asp:Label> 
                                </td>
                                <td>

                                    <table>
                                        <tr>
                                            <td >
                                               
                                              <asp:Label ID="Label18" runat="server" Width="5px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small">1.</asp:Label><asp:Label ID="lblsubject1" runat="server" Width="120px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                            </td>
                                             <td style="Font-Bold="false; Font-Names="Calibri; Font-Size="Small">
                                               
                                               <asp:Label ID="Label22" runat="server" Width="5px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small">2.</asp:Label><asp:Label ID="lblsubject2" runat="server" Width="120px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                            </td>
                                            <td style="Font-Bold="false; Font-Names="Calibri; Font-Size="Small">
                                               
                                            <asp:Label ID="Label25" runat="server" Width="5px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small">3.</asp:Label><asp:Label ID="lblsubject3" runat="server" Width="120px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td >
                                               
                                             <asp:Label ID="Label28" runat="server" Width="5px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small">4.</asp:Label><asp:Label ID="lblsubject4" runat="server" Width="120px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                            </td>
                                             <td >
                                               
                                              <asp:Label ID="Label32" runat="server" Width="5px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small">5.</asp:Label><asp:Label ID="lblsubject5" runat="server" Width="120px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                            </td>
                                            <td >
                                               
                                              <asp:Label ID="Label40" runat="server" Width="5px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small">6.</asp:Label><asp:Label ID="lblsubject6" runat="server" Width="120px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                     
                                </td>
                                
                            
                                            
                             </tr>
                             <tr>
                                <td>
                                    <asp:Label ID="Label17" runat="server" Width="340px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small">11. Whether qualified for promotion to the higher class</asp:Label>  <asp:Label ID="lblpromotion" runat="server" Width="120px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small">...................</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label19" runat="server" Width="300px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small">If so, to which class (in figures)</asp:Label>  <asp:Label ID="Label20" runat="server" Width="120px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small">...................</asp:Label> <asp:Label ID="Label21" runat="server" Width="120px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small">(in words)</asp:Label>  <asp:Label ID="lblpromowords" runat="server" Width="120px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small">...................</asp:Label>
                                </td>
                            </tr>
                              <tr>
                                <td>
                                    <asp:Label ID="Label23" runat="server" Width="340px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small">12. Month up to which the (pupil has paid) school dues paid </asp:Label> 
                                </td>
                                <td>
                                      <asp:Label ID="lblschooldues" runat="server" Width="120px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small">...................</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label24" runat="server" Width="400px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small">13. Any fee concession availed of : If so, the nature of such concession</asp:Label> 
                                </td>
                                <td>
                                      <asp:Label ID="lblfeeconcetion" runat="server" Width="120px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small">...................</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label26" runat="server" Width="280px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small">14. Total No. of working days </asp:Label> 
                                </td>
                                <td>
                                      <asp:Label ID="lbltotworkingdays" runat="server" Width="120px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small">...................</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label27" runat="server" Width="280px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small">15. Total No. of working days present </asp:Label> 
                                </td>
                                <td>
                                      <asp:Label ID="lbltotworkingdayspresent" runat="server" Width="120px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small">...................</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label29" runat="server" Width="400px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small">16.	Whether NCC Cadet / Boy Scout / Girl Guide (details may be given)</asp:Label> 
                                </td>
                                <td>
                                      <asp:Label ID="lblncccandiate" runat="server" Width="120px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small">...................</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label30" runat="server" Width="470px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small">17.	Games played or extracurricular activities in which the pupil usually took part</asp:Label> 
                                </td>
                                <td>
                                      <asp:Label ID="Label31" runat="server" Width="320px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small">(Mention achievement level therein)</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblGAMESACTIV" runat="server" Width="320px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small" align="center">...................................................................................................</asp:Label> 
                                </td>
                                <td>
                                      
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label33" runat="server" Width="320px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small">18.General conduct</asp:Label> 
                                </td>
                                <td>
                                      <asp:Label ID="lblgconduct" runat="server" Width="320px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label34" runat="server" Width="320px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small">19. Date of application for certificate</asp:Label> 
                                </td>
                                <td>
                                      <asp:Label ID="lbldateofapplication" runat="server" Width="320px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                </td>
                            </tr>
                           
                             <tr>
                                <td>
                                    <asp:Label ID="Label35" runat="server" Width="320px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small">20. Date of issue of certificate</asp:Label> 
                                </td>
                                <td>
                                      <asp:Label ID="lblissuecertificate" runat="server" Width="320px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                </td>
                            </tr>
                             <tr>
                                <td>
                                    <asp:Label ID="Label36" runat="server" Width="320px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small">21. Reason for leaving the school </asp:Label> 
                                </td>
                                <td>
                                      <asp:Label ID="lblreason" runat="server" Width="320px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                </td>
                            </tr>
                             <tr>
                                <td>
                                    <asp:Label ID="Label37" runat="server" Width="320px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small">22. Any other remarks </asp:Label> 
                                </td>
                                <td>
                                      <asp:Label ID="lblanydesk" runat="server" Width="320px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                </td>
                            </tr>
                        </table>
                       
                </tr>
                <tr>
                    <td>
                        <table width="100%">
                            <tr>
                               <td align="left">
                                   &nbsp&nbsp&nbsp&nbsp <asp:Label ID="Label38" runat="server" Width="320px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small">Prepared by </asp:Label> 
                                </td>
                                <td align="right">
                                      <asp:Label ID="Label39" runat="server" Width="320px" Font-Bold="false" Font-Names="Calibri" Font-Size="Small">Principal (Sign & Seal)</asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                

            </table>
                
             
           
		</form>
      
	</body>
</HTML>
