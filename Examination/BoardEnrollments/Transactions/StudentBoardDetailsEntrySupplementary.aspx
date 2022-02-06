<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="StudentBoardDetailsEntrySupplementary.aspx.vb" Inherits="CollegeBoard.StudentBoardDetailsEntrySupplementary" %>


<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>StudentBoardDetailsEntryForSupplementary</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../../Images/Login/StyleSheet.css" type="text/css" rel="stylesheet">
</head>
<body ms_positioning="GridLayout">
    <form id="Form2" method="post" runat="server">
        <table id="Table4" style="z-index: 102; position: absolute; top: 8px; left: 8px" cellspacing="1"
            cellpadding="1" width="100%" border="0">
            <tr>
                <td valign="top" align="center">
                    <table id="Table1" style="width: 795px" cellspacing="0" cellpadding="1" width="795" align="center"
                        border="1">
                        <tr>
                            <td valign="top" nowrap="nowrap" align="left">
                                <table id="Table2" style="width: 788px" height="216" cellspacing="0" cellpadding="0" width="788"
                                    align="center" border="0">
                                    <tr>
                                        <td valign="top" align="center">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td class="TopLine">
                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                            <tr>
                                                                <td class="Heading" style="width: 216px" width="216">
                                                                    <asp:TextBox ID="txtAdmno" runat="server" Width="0px"></asp:TextBox>STUDENT 
																		BOARD DETAILS</td>
                                                                <td align="right" width="25%">
                                                                    <table style="width: 161px; height: 24px" cellspacing="0" cellpadding="0" width="161" border="0">
                                                                        <tr>

                                                                            <td class="FormNoLable" nowrap="nowrap" width="31%"></td>
                                                                            <%--<TD width="17%"><asp:label id="Label30" runat="server" Width="55px" CssClass="Lables">AcdamicYear</asp:label></TD>
																				<TD width="17%"><asp:dropdownlist id="DropdownAcdamic" runat="server" Width="112px" CssClass="textboxASR"></asp:dropdownlist></TD>--%>
                                                                            <%--<td class="HomeText" width="125" height="13">AcdamicYear</td>--%>
                                                                            <td>
                                                                                <asp:Label ID="Label30" runat="server" Width="72px" CssClass="Lables">AcademicYear</asp:Label></td>
                                                                            <td height="13">
                                                                                <asp:DropDownList ID="DropdownAcdamic" runat="server" Width="100px" CssClass="textboxASR" AutoPostBack="True">
                                                                                    <asp:ListItem Selected="True" Value="13">2018-2019</asp:ListItem>
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
                                                                             
                                                                            <td class="FormNoLable" valign="middle" nowrap="nowrap" align="center" width="31%">
                                                                                <asp:Label ID="LblAdmNoSearch" runat="server" Width="72px" CssClass="Lables">Adm&nbsp;No *</asp:Label></td>
                                                                            <td width="132">
                                                                                <asp:TextBox ID="txtAdmNoSearch" runat="server" Width="56px" CssClass="textboxASR" MaxLength="7"></asp:TextBox></td>
                                                                            <td width="17%">
                                                                                <asp:Label ID="lblBranchSearch" runat="server" Width="55px" CssClass="Lables">Exam&nbsp;Branch</asp:Label></td>
                                                                            <td width="17%">
                                                                                <asp:DropDownList ID="drpBranchSearch" runat="server" Width="150px" CssClass="textboxASR"></asp:DropDownList></td>
                                                                            <td width="17%">
                                                                                <asp:ImageButton ID="iBtnSearch" AccessKey="E" runat="server" Width="80px" Height="20px" ImageUrl="../../../Images/NewImages/search.gif"></asp:ImageButton></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td nowrap="nowrap" align="center">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="DarkColor">
                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                            <tr>
                                                                <td valign="top" width="11"></td>
                                                                <td class="SubHeading">Student Information</td>
                                                                <td valign="top" width="11"></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="TableBorder" valign="top">
                                                        <table id="Table3" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                            <tr>
                                                                <td style="width: 78px">
                                                                    <asp:Label ID="Label3" runat="server" Width="85px" CssClass="LABLES">SurName</asp:Label></td>
                                                                <td style="width: 147px">
                                                                    <asp:TextBox ID="txtSurName" runat="server" Width="144px" CssClass="textboxASR" ReadOnly="True"></asp:TextBox></td>
                                                                <td style="width: 53px">
                                                                    <asp:Label ID="Label1" runat="server" Width="50px" CssClass="LABLES">Name</asp:Label></td>
                                                                <td style="width: 184px">
                                                                    <asp:TextBox ID="txtSName" runat="server" Width="184px" CssClass="textboxASR" ReadOnly="True"></asp:TextBox></td>
                                                                <td style="width: 82px">
                                                                    <asp:Label ID="Label2" runat="server" Width="80px" CssClass="LABLES">Father Name</asp:Label></td>
                                                                <td>
                                                                    <asp:TextBox ID="txtFname" runat="server" Width="100%" CssClass="textboxASR" ReadOnly="True"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 78px">
                                                                    <asp:Label ID="Label4" runat="server" Width="85px" CssClass="LABLES">Code</asp:Label></td>
                                                                <td style="width: 147px" colspan="4">
                                                                    <asp:Label ID="LblCode" runat="server" Width="465px" CssClass="LABLES"></asp:Label></td>
                                                                <td></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="SubHeading1" valign="top">Board Information</td>
                                                </tr>
                                                <tr>
                                                    <td class="TableBorder" valign="top">
                                                        <table id="Table5" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                            <tr>
                                                                <td style="height: 6px">
                                                                    <asp:Label ID="Label25" runat="server" Width="100%" CssClass="LABLES" Enabled="False">District</asp:Label></td>
                                                                <td style="width: 127px; height: 6px">
                                                                    <asp:DropDownList ID="DrpDist" runat="server" Width="100%" CssClass="textboxASR" Enabled="False"></asp:DropDownList></td>
                                                                <td style="width: 98px; height: 6px">
                                                                    <asp:Label ID="Label26" runat="server" Width="100%" CssClass="LABLES">Code-College</asp:Label></td>
                                                                <td style="width: 97px; height: 6px" colspan="3">
                                                                    <asp:DropDownList ID="DrpColl" runat="server" Width="530px" CssClass="textboxASR"></asp:DropDownList></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label7" runat="server" Width="100%" CssClass="LABLES" Enabled="False">Board&nbsp;ID</asp:Label></td>
                                                                <td style="width: 127px">
                                                                    <asp:TextBox ID="TxtBid" runat="server" Width="100%" CssClass="textboxASR" MaxLength="5" ReadOnly="True"
                                                                        Enabled="False"></asp:TextBox></td>
                                                                <td style="width: 98px">
                                                                    <asp:Label ID="Label15" runat="server" Width="100%" CssClass="LABLES">Board&nbsp;AdmNo *</asp:Label></td>
                                                                <td style="width: 122px">
                                                                    <asp:TextBox ID="TxtBAdmno" runat="server" Width="100%" CssClass="textboxASR" MaxLength="18"></asp:TextBox></td>
                                                                <td style="width: 98px">
                                                                    <asp:Label ID="Label20" runat="server" Width="100%" CssClass="LABLES">Name *</asp:Label></td>
                                                                <td>
                                                                    <asp:TextBox ID="TxtBName" runat="server" Width="100%" CssClass="textboxASR" MaxLength="100"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label8" runat="server" Width="100%" CssClass="LABLES">Community*</asp:Label></td>
                                                                <td style="width: 127px">
                                                                    <asp:DropDownList ID="DrpComm" runat="server" Width="100%" CssClass="textboxASR"></asp:DropDownList></td>
                                                                <td style="width: 98px">
                                                                    <asp:Label ID="Label16" runat="server" Width="100%" CssClass="LABLES">Caste *</asp:Label></td>
                                                                <td style="width: 122px">
                                                                    <asp:DropDownList ID="DrpCaste" runat="server" Width="100%" CssClass="textboxASR" AutoPostBack="True"></asp:DropDownList></td>
                                                                <td style="width: 98px">
                                                                    <asp:Label ID="Label21" runat="server" Width="100%" CssClass="LABLES">Father&nbsp;Name *</asp:Label></td>
                                                                <td>
                                                                    <asp:TextBox ID="TxtBFname" runat="server" Width="100%" CssClass="textboxASR" MaxLength="60"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 2px">
                                                                    <asp:Label ID="Label28" runat="server" Width="100%" CssClass="LABLES">Sub Caste *</asp:Label></td>
                                                                <td style="width: 127px; height: 2px" colspan="3">
                                                                    <asp:DropDownList ID="DrpSubCaste" runat="server" Width="345px" CssClass="textboxASR"></asp:DropDownList></td>
                                                                <td style="width: 98px; height: 2px">
                                                                    <asp:Label ID="Label14" runat="server" Width="100%" CssClass="LABLES">Mother&nbsp;Name *</asp:Label></td>
                                                                <td style="height: 2px">
                                                                    <asp:TextBox ID="TxtBMname" runat="server" Width="100%" CssClass="textboxASR" MaxLength="60"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 14px">
                                                                    <asp:Label ID="Label9" runat="server" Width="100%" CssClass="LABLES">DateofBirth*</asp:Label></td>
                                                                <td style="width: 127px; height: 14px">
                                                                    <asp:TextBox ID="TxtDob" runat="server" Width="100%" CssClass="textboxASR"></asp:TextBox></td>
                                                                <td style="width: 98px; height: 14px">
                                                                    <asp:Label ID="Label17" runat="server" Width="100%" CssClass="LABLES">Previous&nbsp;Exam</asp:Label></td>
                                                                <td style="width: 122px; height: 14px">
                                                                    <asp:DropDownList ID="DrpPrvExm" runat="server" Width="100%" CssClass="textboxASR"></asp:DropDownList></td>
                                                                <td style="width: 98px; height: 14px">
                                                                    <asp:Label ID="Label22" runat="server" Width="100%" CssClass="LABLES">Previous&nbsp;Htno</asp:Label></td>
                                                                <td style="height: 14px">
                                                                    <asp:TextBox ID="TxtBhtno" runat="server" Width="100%" CssClass="textboxASR" MaxLength="100"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 15px">
                                                                    <asp:Label ID="Label10" runat="server" Width="100%" CssClass="LABLES">YearofPass</asp:Label></td>
                                                                <td style="width: 127px; height: 15px">
                                                                    <asp:DropDownList ID="DrpYOp" runat="server" Width="100%" CssClass="textboxASR"></asp:DropDownList></td>
                                                                <td style="width: 98px; height: 15px">
                                                                    <asp:Label ID="Label18" runat="server" Width="100%" CssClass="LABLES">Category *</asp:Label></td>
                                                                <td style="width: 122px; height: 15px">
                                                                    <asp:DropDownList ID="DrpCateg" runat="server" Width="100%" CssClass="textboxASR"></asp:DropDownList></td>
                                                                <td style="width: 98px; height: 15px">
                                                                    <asp:Label ID="Label23" runat="server" Width="100%" CssClass="LABLES">Blind&nbsp;or&nbsp;PH</asp:Label></td>
                                                                <td style="height: 15px">
                                                                    <asp:DropDownList ID="DrpPh" runat="server" Width="150px" CssClass="textboxASR"></asp:DropDownList><asp:TextBox ID="TxtPhper" runat="server" Width="155px" CssClass="textboxASR" MaxLength="10"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 6px">
                                                                    <asp:Label ID="Label11" runat="server" Width="100%" CssClass="LABLES">First&nbsp;Lang.</asp:Label></td>
                                                                <td style="width: 127px; height: 6px">
                                                                    <asp:DropDownList ID="DrpFlang" runat="server" Width="100%" CssClass="textboxASR"></asp:DropDownList></td>
                                                                <td style="width: 98px; height: 6px">
                                                                    <asp:Label ID="Label19" runat="server" Width="100%" CssClass="LABLES">Second&nbsp;Lang. *</asp:Label></td>
                                                                <td style="width: 122px; height: 6px">
                                                                    <asp:DropDownList ID="DrpSlang" runat="server" Width="100%" CssClass="textboxASR"></asp:DropDownList></td>
                                                                <td style="width: 98px; height: 6px">
                                                                    <asp:Label ID="Label24" runat="server" Width="100%" CssClass="LABLES">MotherTongue *</asp:Label></td>
                                                                <td style="height: 6px">
                                                                    <asp:DropDownList ID="DrpMotherTounge" runat="server" Width="150px" CssClass="textboxASR"></asp:DropDownList></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 78px; height: 3px">
                                                                    <asp:Label ID="Label5" runat="server" Width="100%" CssClass="LABLES">DateofAdmn*</asp:Label></td>
                                                                <td style="width: 127px; height: 3px">
                                                                    <asp:TextBox ID="TxtDtAdm" runat="server" Width="100%" CssClass="textboxASR"></asp:TextBox></td>
                                                                <td style="width: 98px; height: 3px">
                                                                    <asp:Label ID="Label6" runat="server" Width="100%" CssClass="LABLES">Admited&nbsp;Class*</asp:Label></td>
                                                                <td style="width: 122px; height: 3px">
                                                                    <asp:DropDownList ID="DrpCourse" runat="server" Width="100%" CssClass="textboxASR"></asp:DropDownList></td>
                                                                <td style="width: 98px; height: 3px">
                                                                    <asp:Label ID="lblBoardBranch" runat="server" Width="100%" CssClass="Lables">Board&nbsp;Branch *</asp:Label></td>
                                                                <td style="height: 3px">
                                                                    <asp:DropDownList ID="drpAdmBranch" runat="server" Width="305px" CssClass="textboxASR" Height="16px"></asp:DropDownList></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 78px; height: 3px">
                                                                    <asp:Label ID="Label29" runat="server" Width="100%" CssClass="LABLES">Aadhar No *</asp:Label></td>
                                                                <td style="width: 127px; height: 3px">
                                                                    <asp:TextBox ID="txtAadhar" runat="server" Width="175%" CssClass="textboxASR" MaxLength="12"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 6px">
                                                                    <asp:Label ID="Label12" runat="server" Width="100%" CssClass="LABLES">1.&nbsp;A&nbsp;Mole&nbsp;on*</asp:Label></td>
                                                                <td style="width: 98px" colspan="5">
                                                                    <asp:TextBox ID="TxtMole1" runat="server" Width="755px" CssClass="textboxASR" MaxLength="200"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label13" runat="server" Width="100%" CssClass="LABLES">2.&nbsp;A&nbsp;Mole&nbsp;on*</asp:Label></td>
                                                                <td style="width: 98px" colspan="5">
                                                                    <asp:TextBox ID="TxtMole2" runat="server" Width="755px" CssClass="textboxASR" MaxLength="200"></asp:TextBox></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top" nowrap="nowrap" align="left">
                                                        <asp:Label ID="Label27" runat="server" Font-Bold="True" ForeColor="Red">* Fields Mandatory</asp:Label>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td valign="top" nowrap="nowrap" align="right">
                                                        <asp:ImageButton ID="iBtnSave" AccessKey="S" runat="server" Width="80px" Height="20px" ImageUrl="../../../Images/NewImages/save.gif"></asp:ImageButton></td>
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
        </table>
    </form>
</body>
</html>

