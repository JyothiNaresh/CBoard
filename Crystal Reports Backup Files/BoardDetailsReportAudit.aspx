<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="BoardDetailsReportAudit.aspx.vb" Inherits="CollegeBoard.BoardDetailsReportAudit" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>BoardDetailsReport</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link id="Link1" href="../../../Images/Login/StyleSheet_Report.css" type="text/css" rel="stylesheet">
    <script language="JavaScript" type="text/javascript" src="../../Include/Report.js"></script>
    <style type="text/css">
        .auto-style1 {
            width: 81px;
        }

        #Table3 {
            width: 257px;
        }

        #Table11 {
            height: 120px;
            width: 30px;
        }
    </style>
</head>


<body onscroll="javascript:setcoords()" topmargin="0" onload="javascript:ScrollIt()" ms_positioning="GridLayout">

    <form id="Form1" method="post" runat="server">

						<TABLE id="Table1" style="WIDTH: 1024px" cellSpacing="0" cellPadding="1" width="1024" align="center" border="1">
							<TR>
								<TD vAlign="top" align="center">


        <table id="Table17" style="z-index: 105; top: 8px" cellspacing="0" cellpadding="1" width="100%" border="0">
            <tr>
                <td class="DarkColor" style="height: 11px">

                    <table id="Table13" cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td style="width: 12px" valign="top" width="12">
                                <img height="11" src="../../../Images/Login/table-lcorw.gif" width="11">
                            </td>
                            <td class="SubHeading1" valign="middle" align="center">Board Details Report</td>
                            <td valign="top" width="11">
                                <img height="11" src="../../../Images/Login/table-rcorw.gif" width="11">
                            </td>
                        </tr>
                    </table>

                </td>
            </tr>
            <tr>
                <td style="height: 202px" valign="top" align="center" colspan="4">
                    <table id="Table12" cellspacing="0" cellpadding="0" border="1">

                        <tr>
                            <td>
                                <asp:Label ID="Label15" runat="server" CssClass="Lables" Width="100%">Team Lead</asp:Label>
                            </td>
                            <td></td>
                            <td>
                                <asp:Label ID="Label16" runat="server" CssClass="Lables" Width="100%">Selected</asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="Drpstate" runat="server" AutoPostBack="True" CssClass="DropDownList" Height="20px" Width="244px">
                                </asp:DropDownList>
                            </td>
                            <td></td>
                            <td>
                                <asp:Label ID="Label5" runat="server" CssClass="Lables" Width="100%">Selected</asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:ListBox ID="lstAllAudit" runat="server" CssClass=" " Width="250px" Height="150px" Rows="100"
                                    SelectionMode="Multiple"></asp:ListBox>
                            </td>
                            <td valign="top">
                                <table id="Table8" cellspacing="0" cellpadding="0" width="30" border="0">
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="BtnSelAudit" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Select.gif"></asp:ImageButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="BtnSelAuditAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/SelectAll.gif"></asp:ImageButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="BtnRemAudit" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Remove.gif"></asp:ImageButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="BtnRemAuditAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/RemoveAll.gif"></asp:ImageButton>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td valign="top">
                                <asp:ListBox ID="lstSelAudit" runat="server" CssClass=" " Width="250px" Height="150px" Rows="100"
                                    SelectionMode="Multiple"></asp:ListBox>
                            </td>
                            <td valign="top">
                                <asp:ListBox ID="lstAllDistrict" runat="server" CssClass=" " Width="250px" Height="150px" Rows="100"
                                    SelectionMode="Multiple"></asp:ListBox>
                            </td>
                            <td valign="top">
                                <table id="Table14" cellspacing="0" cellpadding="0" width="30" border="0">
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="BtnSelDistrict" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Select.gif"></asp:ImageButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="BtnSelDistrictAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/SelectAll.gif"></asp:ImageButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="BtnRemDistrict" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Remove.gif"></asp:ImageButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="BtnRemDistrictAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/RemoveAll.gif"></asp:ImageButton>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td valign="top">
                                <asp:ListBox ID="lstSelDistrict" runat="server" CssClass=" " Width="250px" Height="150px" Rows="100"
                                    SelectionMode="Multiple"></asp:ListBox>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Label ID="Label10" runat="server" CssClass="Lables" Width="100%">Exam Branch</asp:Label>
                            </td>
                            <td valign="top">&nbsp;</td>
                            <td valign="top">
                                <asp:Label ID="Label3" runat="server" CssClass="Lables" Width="100%">Selected</asp:Label>
                            </td>
                            <td valign="top">
                                <asp:Label ID="Label1" runat="server" CssClass="Lables" Width="100%">Course</asp:Label>
                            </td>
                            <td valign="top">&nbsp;</td>
                            <td valign="top">&nbsp;</td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:ListBox ID="LSTExamBranch" runat="server" CssClass=" " Width="250px" Height="150px" Rows="100"
                                    SelectionMode="Multiple"></asp:ListBox>
                            </td>
                            <td valign="top">
                                <table id="Table7" cellspacing="0" cellpadding="0" width="30" border="0">
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="BtnSelEB" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Select.gif"></asp:ImageButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="BtnSelEBAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/SelectAll.gif"></asp:ImageButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="BtnRemEB" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Remove.gif"></asp:ImageButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="BtnRemEBAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/RemoveAll.gif"></asp:ImageButton>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td valign="top">
                                <asp:ListBox ID="LSTSelEBranch" runat="server" CssClass=" " Width="250px" Height="150px" Rows="100"
                                    SelectionMode="Multiple"></asp:ListBox>
                            </td>
                            <td valign="top">
                                <asp:ListBox ID="LstCourse" runat="server" CssClass=" " Width="250px" SelectionMode="Multiple"
                                    Rows="100" Height="150px"></asp:ListBox>
                            </td>
                            <td valign="top">
                                <table id="Table2" cellspacing="0" cellpadding="0" width="30" border="0">
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="BtnSelCourse" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Select.gif"></asp:ImageButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="BtnSelCourseAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/SelectAll.gif"></asp:ImageButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="BtnRemCourse" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Remove.gif"></asp:ImageButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="BtnRemCourseAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/RemoveAll.gif"></asp:ImageButton>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td valign="top">
                                <asp:ListBox ID="LstSelCourse" runat="server" CssClass=" " Width="250px" SelectionMode="Multiple"
                                    Rows="100" Height="150px"></asp:ListBox>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Label ID="Label13" runat="server" CssClass="Lables" Width="100%">Board Code</asp:Label>
                            </td>
                            <td valign="top">&nbsp;</td>
                            <td valign="top">
                                <asp:Label ID="Label2" runat="server" CssClass="Lables" Width="100%">Selected</asp:Label>
                            </td>
                            <td valign="top">
                                <asp:Label ID="Label4" runat="server" CssClass="Lables" Width="100%">Board District</asp:Label>
                            </td>
                            <td valign="top">&nbsp;</td>
                            <td valign="top">
                                <asp:Label ID="Label8" runat="server" CssClass="Lables" Width="100%">Selected</asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:ListBox ID="LSTBoardCode" runat="server" CssClass=" " Width="250px" SelectionMode="Multiple"
                                    Rows="100" Height="150px"></asp:ListBox>
                            </td>
                            <td valign="top">
                                <table id="Table11" cellspacing="0" cellpadding="0" width="30" border="0">
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="BtnSelBoardCode" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Select.gif"></asp:ImageButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="BtnSelBoardCodeAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/SelectAll.gif"></asp:ImageButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="BtnRemBoardCode" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Remove.gif"></asp:ImageButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="BtnRemBoardCodeAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/RemoveAll.gif"></asp:ImageButton>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td valign="top">
                                <asp:ListBox ID="LSTSelBoardCode" runat="server" CssClass=" " Width="250px" SelectionMode="Multiple"
                                    Rows="100" Height="150px"></asp:ListBox>
                            </td>
                            <td valign="top">
                                <asp:ListBox ID="LSTBoardDist" runat="server" CssClass=" " Width="250px" SelectionMode="Multiple"
                                    Rows="20" Height="150px"></asp:ListBox>
                            </td>
                            <td valign="top">
                                <table id="Table15" cellspacing="0" cellpadding="0" width="30" border="0">
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="BtnSelBoardDist" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Select.gif"></asp:ImageButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="BtnSelBoardDistAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/SelectAll.gif"></asp:ImageButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="BtnRemBoardDist" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Remove.gif"></asp:ImageButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="BtnRemBoardDistAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/RemoveAll.gif"></asp:ImageButton>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td valign="top">
                                <asp:ListBox ID="LSTSelBoardDist" runat="server" CssClass=" " Width="250px" SelectionMode="Multiple"
                                    Rows="20" Height="150px"></asp:ListBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>

            <tr>
                <td align="center">
                    <table class="auto-style1">
                        <tr>
                            <td>
                                <asp:Label ID="Label14" runat="server" CssClass="Lables" Width="100px">Format</asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="drpFormat" runat="server">
                                    <asp:ListItem Value="0" Selected="True">ALL</asp:ListItem>
                                    <asp:ListItem Value="1">ALLAdmissions</asp:ListItem>
                                    <asp:ListItem Value="2">Reservations</asp:ListItem>
                                    <asp:ListItem Value="3">Supplementary</asp:ListItem>
                                    <asp:ListItem Value="4">Non-Admitted</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="Label6" runat="server" CssClass="Lables" Width="100px">Format</asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="drpCode" runat="server">
                                    <asp:ListItem Selected="True" Value="1">Branch Wise</asp:ListItem>
                                    <asp:ListItem Value="2">Code Wise</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="Label7" runat="server" CssClass="Lables" Width="100px">Order</asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="drpOrder" runat="server">
                                    <asp:ListItem Selected="True" Value="1">ADMNO</asp:ListItem>
                                    <asp:ListItem Value="2">NAME</asp:ListItem>
                                    <asp:ListItem Value="3">PRV_HTNO</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td valign="top" align="right" colspan="4">
                    <asp:ImageButton ID="ibtnExcel" runat="server" Height="20px" ImageUrl="~/Images/NewImages/download.gif" Width="80px" />
                    <asp:TextBox ID="PageY" runat="server" Visible="false" Width="0px"></asp:TextBox><asp:TextBox ID="PageX" runat="server" Visible="false" Width="0px"></asp:TextBox><asp:ImageButton ID="iBtnReport" runat="server" Width="80px" Height="20px" ImageUrl="../../../Images/NewImages/report.gif"></asp:ImageButton>
                </td>
            </tr>
        </table>


                                    </TD>
                                </TR>
                            </TABLE>
    </form>


</body>
</html>
