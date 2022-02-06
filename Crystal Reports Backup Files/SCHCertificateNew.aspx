<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SCHCertificateNew.aspx.vb" Inherits="CollegeBoard.SCHCertificateNew" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>Cetificates_Dtnew</TITLE>
		<LINK id="Link1" rel="stylesheet" type="text/css" href="../../Images/Login/StyleSheet_Report.css">
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../Styles/MultiComboSelect/jquery.multiselect.css">
		<LINK rel="stylesheet" type="text/css" href="../../Styles/MultiComboSelect/jquery.multiselect.filter.css">
		<LINK rel="stylesheet" type="text/css" href="../../Styles/MultiComboSelect/jquery-ui.css">
		<LINK rel="stylesheet" type="text/css" href="../../Styles/MultiComboSelect/prettify.css">
		
	</HEAD>
<body ms_positioning="GridLayout">
    <form id="Form1" method="post" runat="server" autocomplete="off">
        <asp:TextBox ID="txtlblCode" runat="server" Height="32px" Width="0px">XXXXXX</asp:TextBox>
        <table id="Table0" border="0" cellspacing="1" cellpadding="1" width="100%">
            <tbody>
                <tr>
                    <td valign="top" align="center">
                        <table id="Table1" class="Panel" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td align="center">
                                    <table id="Table2" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td class="DarkColor">
                                                <table id="Table3" border="0" cellspacing="0" cellpadding="0" width="100%">
                                                    <tr>
                                                        <td valign="top" width="11">
                                                            <img src="../../Images/Login/table-lcorw.gif" width="11" height="11"></td>
                                                        <td class="SubHeading">
                                                            <asp:Label ID="lblHeading" runat="server" Width="100%" CssClass="SubHeading1" Font-Bold="True"> List  of College Wise Details  of Certificates </asp:Label></td>
                                                        <td valign="top" width="11">
                                                            <img src="../../Images/Login/table-rcorw.gif" width="11" height="11"></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TdBorder">
                                                <img src="../../Images/Login/spacer.gif" width="1" height="1"></td>
                                        </tr>
                                        <tr>
                                            <td class="TableBorder" valign="top" align="center">
                                                <table id="Table13" border="0" cellspacing="0" cellpadding="0" width="200">
                                                    <tr>
                                                        <%--<TD width="250"><SELECT style="Z-INDEX: 0; WIDTH: 100px" multiple name="Prdcity" RUNAT="server" id="lstmCode"></SELECT></TD>--%>
                                                        <td width="250">
                                                            <asp:TextBox ID="lstmCode" runat="server" Width="152px"></asp:TextBox></td>
                                                        <td>
                                                            <asp:ImageButton AccessKey="G" Style="z-index: 0" ID="imgBtnGoo1" TabIndex="1" runat="server" Width="40px"
                                                                Height="17px" ImageUrl="../../Images/NewImages/go.gif"></asp:ImageButton></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TableBorder" valign="top" align="center"></td>
                                        </tr>
                                        <tr>
                                            <td class="TableBorder" valign="top" align="center">
                                                <asp:DataGrid Style="z-index: 0" ID="dgGridSection" TabIndex="1" runat="server" Width="198px"
                                                    CssClass="GridMain" AllowPaging="True" AutoGenerateColumns="False" BorderWidth="0px" CellPadding="0" BorderStyle="Dotted" OnItemCreated="DeleteConformationMessage"
                                                    CellSpacing="2">
                                                    <SelectedItemStyle Font-Bold="True"></SelectedItemStyle>
                                                    <AlternatingItemStyle CssClass="GridAlternateItem"></AlternatingItemStyle>
                                                    <HeaderStyle Font-Bold="True" CssClass="GridHeader"></HeaderStyle>
                                                    <Columns>
                                                        <asp:TemplateColumn HeaderText="S.No">
                                                            <HeaderStyle HorizontalAlign="Center" Width="10%" VerticalAlign="Middle"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label5" runat="server" Text='<%# DataBinder.Eval(Container, "DataSetIndex")+1 %>'>
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                            <FooterStyle Wrap="False"></FooterStyle>
                                                        </asp:TemplateColumn>
                                                        <asp:BoundColumn Visible="False" DataField="CERTFSLNO" HeaderText="SLNO">
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
                                                </asp:DataGrid></td>
                                        </tr>
                                        <tr>
                                            <td class="TableBorder" valign="middle" align="right">
                                                <asp:ImageButton AccessKey="S" ID="iBtnAdd" TabIndex="5" runat="server" Height="20px" Width="92px"
                                                    ImageUrl="../../Images/NewImages/add.gif"></asp:ImageButton>&nbsp;&nbsp;&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                    <p></p>
                                </td>
                            </tr>
                        </table>
                        <table style="z-index: 0" id="Table4" border="1" cellspacing="0" cellpadding="0" width="80%"
                            runat="server">
                            <tr>
                                <td align="center">
                                    <table id="Table6" class="Panel" border="1" cellspacing="0" cellpadding="0" width="100%">
                                        <tr>
                                            <td align="center">
                                                <table id="Table7" border="1" cellspacing="0" cellpadding="0" width="100%">
                                                    <tr>
                                                        <td class="DarkColor">
                                                            <table id="Table8" border="0" cellspacing="0" cellpadding="0" width="100%">
                                                                <tr>
                                                                    <td valign="top" width="11">
                                                                        <img src="../../Images/Login/table-lcorw.gif" width="11" height="11"></td>
                                                                    <td class="SubHeading">
                                                                        <asp:Label Style="z-index: 0" ID="Label10" runat="server" Height="8px" Width="264px" CssClass="SubHeading1"
                                                                            Font-Bold="True"> Certificates Entry Details </asp:Label></td>
                                                                    <td valign="top" width="11">
                                                                        <img src="../../Images/Login/table-rcorw.gif" width="11" height="11"></td>
                                                                </tr>
                                                            </table>
                                                            <tr>
                                                                <td style="height: 13px" align="right">
                                                                    <asp:HyperLink Style="z-index: 0" ID="Hyperlink4" runat="server" Font-Bold="True" Target="_blank"
                                                                        Font-Italic="True" NavigateUrl="http://www.picresize.com" ForeColor="Blue">ToResize Images Goto : http://www.picresize.com</asp:HyperLink></td>
                                                            </tr>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TdBorder">
                                                            <img src="../../Images/Login/spacer.gif" width="1" height="1">
                                                           
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TableBorder" valign="top" align="center">
                                                            <table id="Table9" border="0" cellspacing="0" cellpadding="0">
                                                            </table>
                                                            <table id="Table5" border="0" cellspacing="0" cellpadding="0" width="330">
                                                                <tr>
                                                                    <td style="width: 193px">
                                                                        <asp:Label Style="z-index: 0" ID="Label2" runat="server" Height="19px" Width="100%" CssClass="Lables">College Code</asp:Label></td>
                                                                    <td style="width: 29px">
                                                                        <asp:TextBox ID="Txtccode" runat="server" Width="73px"></asp:TextBox></td>
                                                                    <td align="left">
                                                                        <asp:ImageButton AccessKey="G" ID="imgBtnGo" TabIndex="1" runat="server" Height="17px" Width="75px"
                                                                            ImageUrl="../../Images/NewImages/search.gif"></asp:ImageButton></td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="3" align="center">
                                                                        <asp:Label Style="z-index: 0" ID="LBLCLGNAME" runat="server" Height="19px" Width="344px" CssClass="Lables"
                                                                            BackColor="Info">College Name</asp:Label></td>
                                                                </tr>
                                                            </table>
                                                           
                                                            <table style="height: 56px" id="Table20" border="1" cellspacing="0" cellpadding="0" width="100%">
                                                                <tbody>
                                                                    
                                                                    <tr>
                                                                        <td style="width: 105px; height: 23px"></td>
                                                                        <td style="width: 63px; height: 23px"></td>
                                                                        <td style="height: 23px"></td>
                                                                        <td style="height: 23px">
                                                                            <table id="Table11" border="1" cellspacing="0" cellpadding="0" width="100%">
                                                                                <tr>
                                                                                    <td style="width: 86px">
                                                                                        <asp:Label Style="z-index: 0" ID="Label4" runat="server" Width="100%" Height="14px" CssClass="Lables">From Date</asp:Label></td>
                                                                                    <td style="width: 85px">
                                                                                        <asp:Label Style="z-index: 0" ID="Label6" runat="server" Width="100%" Height="14px" CssClass="Lables">To Date</asp:Label></td>
                                                                                    <td style="width: 195px">
                                                                                        <asp:Label Style="z-index: 0" ID="Label8" runat="server" Width="100%" Height="14px" CssClass="Lables">Image Browse</asp:Label></td>
                                                                                    <td>
                                                                                        <asp:Label Style="z-index: 0" ID="Label9" runat="server" Width="100%" Height="14px" CssClass="Lables">View</asp:Label></td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 105px; height: 8px">
                                                                            <asp:Label ID="Label1" runat="server" Height="14px" Width="100%" CssClass="Lables"> Fire Safety</asp:Label></td>
                                                                        <td style="width: 63px; height: 8px">
                                                                            <asp:DropDownList Style="z-index: 0" ID="Drpfire1" TabIndex="3" runat="server" Width="91px" CssClass=" "
                                                                                AutoPostBack="True">
                                                                                <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                                                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                                                                <asp:ListItem Value="2">No</asp:ListItem>
                                                                            </asp:DropDownList></td>
                                                                        <td style="width: 92px; height: 8px">
                                                                            <asp:DropDownList Style="z-index: 0" ID="Drpfire2" TabIndex="4" runat="server" Width="100%" CssClass=" " Height="16px">
                                                                                <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                                                                <asp:ListItem Value="1">Submitted</asp:ListItem>
                                                                                <asp:ListItem Value="2">Not Submitted</asp:ListItem>
                                                                            </asp:DropDownList></td>
                                                                        <td style="width: 36px; height: 8px">
                                                                            <table id="Table12" border="0" cellspacing="1" cellpadding="0" width="100%" runat="server">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:TextBox Style="z-index: 0" ID="txtfirfmdate" TabIndex="5" runat="server" Width="85px" CssClass=" "
                                                                                            MaxLength="16" ToolTip="DD/MM/YYYY"></asp:TextBox></td>
                                                                                    <td>
                                                                                        <asp:TextBox Style="z-index: 0" ID="txtfirtodate" TabIndex="6" runat="server" Width="85px" CssClass=" "
                                                                                            MaxLength="16" ToolTip="DD/MM/YYYY"></asp:TextBox></td>
                                                                                    <td>
                                                                                        <input style="z-index: 0; width: 200px; height: 20px" id="cerfirepath1" tabindex="7" type="file"
                                                                                            name="cerfirepath1" runat="server"></td>
                                                                                    <td>
                                                                                        <asp:HyperLink Style="z-index: 0" ID="HypNew" onclick="return hs.expand(this)" runat="server" Font-Bold="True"
                                                                                            ForeColor="DeepSkyBlue" Text="ViewImg" Visible="false">View</asp:HyperLink>
                                                                               
                                                                                    </td>
                                                                                    <td>
                                                                                          <asp:Button ID="but1" runat="server" Text="View" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <%-- <td style="width: 86px">
                                                                                    <asp:Image ID="img1" runat="server" height="80px" Width="80px" Visible="false"/>
                                                                                    </td>
                                                                        --%>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 105px; height: 21px">
                                                                            <asp:Label ID="Label7" runat="server" Height="14px" Width="100%" CssClass="Lables"> Sanitory</asp:Label></td>
                                                                        <td style="width: 63px; height: 21px">
                                                                            <asp:DropDownList Style="z-index: 0" ID="drpsant1" TabIndex="8" runat="server" Width="91px" CssClass=" "
                                                                                AutoPostBack="True">
                                                                                <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                                                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                                                                <asp:ListItem Value="2">No</asp:ListItem>
                                                                            </asp:DropDownList></td>
                                                                        <td style="width: 92px; height: 8px">
                                                                            <asp:DropDownList Style="z-index: 0" ID="drpsant2" TabIndex="9" runat="server" Width="100%" CssClass=" ">
                                                                                <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                                                                <asp:ListItem Value="1">Submitted</asp:ListItem>
                                                                                <asp:ListItem Value="2">Not Submitted</asp:ListItem>
                                                                            </asp:DropDownList></td>
                                                                        <td style="width: 36px; height: 21px">
                                                                            <table id="Table13" border="0" cellspacing="1" cellpadding="0" width="100%" runat="server">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:TextBox Style="z-index: 0" ID="txtstfmdate" TabIndex="10" runat="server" Width="85px" CssClass=" "
                                                                                            MaxLength="16" ToolTip="DD/MM/YYYY"></asp:TextBox></td>
                                                                                    <td>
                                                                                        <asp:TextBox Style="z-index: 0" ID="txtsttodate" TabIndex="11" runat="server" Width="85px" CssClass=" "
                                                                                            MaxLength="16" ToolTip="DD/MM/YYYY"></asp:TextBox></td>
                                                                                    <td>
                                                                                        <input style="z-index: 0; width: 200px; height: 20px" id="cersanpath1" tabindex="12" type="file"
                                                                                            name="cersanpath1" runat="server"></td>
                                                                                    <td>
                                                                                        <asp:HyperLink Style="z-index: 0" ID="HypNew2" onclick="return hs.expand(this)" runat="server"
                                                                                            Font-Bold="True" ForeColor="DeepSkyBlue" Text="ViewImg" Visible="false">View</asp:HyperLink></td>
                                                                                    <td>
                                                                                          <asp:Button ID="Button2" runat="server" Text="View" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 105px">
                                                                                <asp:Label ID="Label11" runat="server" Height="14px" Width="100%" CssClass="Lables"> Traffic</asp:Label></td>
                                                                            <td style="width: 63px">
                                                                                <asp:DropDownList Style="z-index: 0" ID="drptraffic1" TabIndex="13" runat="server" Width="91px" CssClass=" "
                                                                                    AutoPostBack="True">
                                                                                    <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                                                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                                                                    <asp:ListItem Value="2">No </asp:ListItem>
                                                                                </asp:DropDownList></td>
                                                                            <td style="width: 92px; height: 8px">
                                                                                <asp:DropDownList Style="z-index: 0" ID="drptraffic2" TabIndex="14" runat="server" Width="100%" CssClass=" ">
                                                                                    <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                                                                    <asp:ListItem Value="1">Submitted</asp:ListItem>
                                                                                    <asp:ListItem Value="2">Not Submitted</asp:ListItem>
                                                                                </asp:DropDownList></td>
                                                                            <td style="width: 48px">
                                                                                <table style="z-index: 0" id="Table14" border="0" cellspacing="1" cellpadding="0" width="100%"
                                                                                    runat="server">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:TextBox Style="z-index: 0" ID="txtstrafromdate" TabIndex="15" runat="server" Width="85px" CssClass=" "
                                                                                                MaxLength="16" ToolTip="DD/MM/YYYY"></asp:TextBox></td>
                                                                                        <td>
                                                                                            <asp:TextBox Style="z-index: 0" ID="txtstratodate" TabIndex="16" runat="server" Width="85px" CssClass=" "
                                                                                                MaxLength="16" ToolTip="DD/MM/YYYY"></asp:TextBox></td>
                                                                                        <td>
                                                                                            <input style="z-index: 0; width: 200px; height: 20px" id="cerstrpath1" tabindex="17" type="file"
                                                                                                name="cerstrpath1" runat="server"></td>
                                                                                        <td>
                                                                                            <asp:HyperLink Style="z-index: 0" ID="HypNew3" onclick="return hs.expand(this)" runat="server"
                                                                                                Font-Bold="True" ForeColor="DeepSkyBlue" Text="ViewImg" Visible="false">View</asp:HyperLink></td>
                                                                                         <td>
                                                                                          <asp:Button ID="Button3" runat="server" Text="View" />
                                                                                    </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    <tr>
                                                                        <td style="width: 105px">
                                                                            <asp:Label ID="Label3" runat="server" Height="14px" Width="104px" CssClass="Lables"> Mun. N O C</asp:Label></td>
                                                                        <td style="width: 63px">
                                                                            <asp:DropDownList Style="z-index: 0" ID="drpnoc1" TabIndex="18" runat="server" Width="91px" CssClass=" "
                                                                                AutoPostBack="True">
                                                                                <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                                                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                                                                <asp:ListItem Value="2">No </asp:ListItem>
                                                                            </asp:DropDownList></td>
                                                                        <td style="width: 92px; height: 8px">
                                                                            <asp:DropDownList Style="z-index: 0" ID="drpnoc2" TabIndex="19" runat="server" Width="100%" CssClass=" ">
                                                                                <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                                                                <asp:ListItem Value="1">Submitted</asp:ListItem>
                                                                                <asp:ListItem Value="2">Not Submitted</asp:ListItem>
                                                                            </asp:DropDownList></td>
                                                                        <td style="width: 48px">
                                                                            <table style="z-index: 0" id="Table15" border="0" cellspacing="1" cellpadding="0" width="100%"
                                                                                runat="server">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:TextBox Style="z-index: 0" ID="txtmunfmdate" TabIndex="20" runat="server" Width="85px" CssClass=" "
                                                                                            MaxLength="16" ToolTip="DD/MM/YYYY"></asp:TextBox></td>
                                                                                    <td>
                                                                                        <asp:TextBox Style="z-index: 0" ID="txtmuntodate" TabIndex="21" runat="server" Width="85px" CssClass=" "
                                                                                            MaxLength="16" ToolTip="DD/MM/YYYY"></asp:TextBox></td>
                                                                                    <td>
                                                                                        <input style="z-index: 0; width: 200px; height: 20px" id="cermunpath1" tabindex="22" type="file"
                                                                                            name="cermunpath1" runat="server"></td>
                                                                                    <td>
                                                                                        <asp:HyperLink Style="z-index: 0" ID="HypNew4" onclick="return hs.expand(this)" runat="server"
                                                                                            Font-Bold="True" ForeColor="DeepSkyBlue" Text="ViewImg" Visible="false">View</asp:HyperLink></td>
                                                                                     <td>
                                                                                          <asp:Button ID="Button4" runat="server" Text="View" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>

                                                                    <tr>
                                                                        <td style="width: 105px">
                                                                            <asp:Label ID="Label12" runat="server" Height="14px" Width="200px" CssClass="Lables">Play  Ground</asp:Label></td>
                                                                        <td style="width: 63px">
                                                                            <asp:DropDownList Style="z-index: 0" ID="drpplyground1" TabIndex="18" runat="server" Width="91px" CssClass=" "
                                                                                AutoPostBack="True">
                                                                                <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                                                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                                                                <asp:ListItem Value="2">No </asp:ListItem>
                                                                            </asp:DropDownList></td>
                                                                        <td style="width: 92px; height: 8px">
                                                                            <asp:DropDownList Style="z-index: 0" ID="drpplyground2" TabIndex="19" runat="server" Width="100%" CssClass=" ">
                                                                                <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                                                                <asp:ListItem Value="1">Submitted</asp:ListItem>
                                                                                <asp:ListItem Value="2">Not Submitted</asp:ListItem>
                                                                            </asp:DropDownList></td>
                                                                        <td style="width: 48px">
                                                                            <table style="z-index: 0" id="Table10" border="0" cellspacing="1" cellpadding="0" width="100%"
                                                                                runat="server">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:TextBox Style="z-index: 0" ID="txtplaygroundfrom" TabIndex="20" runat="server" Width="85px" CssClass=" "
                                                                                            MaxLength="16" ToolTip="DD/MM/YYYY"></asp:TextBox></td>
                                                                                    <td>
                                                                                        <asp:TextBox Style="z-index: 0" ID="txtplaygroundto" TabIndex="21" runat="server" Width="85px" CssClass=" "
                                                                                            MaxLength="16" ToolTip="DD/MM/YYYY"></asp:TextBox></td>
                                                                                    <td>
                                                                                        <input style="z-index: 0; width: 200px; height: 20px" id="cerplaygroundpath1" tabindex="22" type="file"
                                                                                            name="cermunpath1" runat="server"></td>
                                                                                    <td>
                                                                                        <asp:HyperLink Style="z-index: 0" ID="HyperLink1" onclick="return hs.expand(this)" runat="server"
                                                                                            Font-Bold="True" ForeColor="DeepSkyBlue" Text="ViewImg" Visible="false">View</asp:HyperLink></td>
                                                                                     <td>
                                                                                          <asp:Button ID="ButAff" runat="server" Text="View" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>



                                                                    <tr>
                                                                        <td style="width: 105px">
                                                                            <asp:Label ID="Label13" runat="server" Height="14px" Width="200px" CssClass="Lables">Additional Sections</asp:Label></td>
                                                                        <td style="width: 63px">
                                                                            <asp:DropDownList Style="z-index: 0" ID="drpaddsec1" TabIndex="18" runat="server" Width="91px" CssClass=" "
                                                                                AutoPostBack="True">
                                                                                <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                                                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                                                                <asp:ListItem Value="2">No </asp:ListItem>
                                                                            </asp:DropDownList></td>
                                                                        <td style="width: 92px; height: 8px">
                                                                            <asp:DropDownList Style="z-index: 0" ID="drpaddsec2" TabIndex="19" runat="server" Width="100%" CssClass=" ">
                                                                                <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                                                                <asp:ListItem Value="1">Submitted</asp:ListItem>
                                                                                <asp:ListItem Value="2">Not Submitted</asp:ListItem>
                                                                            </asp:DropDownList></td>
                                                                        <td style="width: 48px">
                                                                            <table style="z-index: 0" id="Table16" border="0" cellspacing="1" cellpadding="0" width="100%"
                                                                                runat="server">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:TextBox Style="z-index: 0" ID="txtsecfrom" TabIndex="20" runat="server" Width="85px" CssClass=" "
                                                                                            MaxLength="16" ToolTip="DD/MM/YYYY"></asp:TextBox></td>
                                                                                    <td>
                                                                                        <asp:TextBox Style="z-index: 0" ID="txtsecto" TabIndex="21" runat="server" Width="85px" CssClass=" "
                                                                                            MaxLength="16" ToolTip="DD/MM/YYYY"></asp:TextBox></td>
                                                                                    <td>
                                                                                        <input style="z-index: 0; width: 200px; height: 20px" id="cersecpath1" tabindex="22" type="file"
                                                                                            name="cermunpath1" runat="server"></td>
                                                                                    <td>
                                                                                        <asp:HyperLink Style="z-index: 0" ID="HyperLink2" onclick="return hs.expand(this)" runat="server"
                                                                                            Font-Bold="True" ForeColor="DeepSkyBlue" Text="ViewImg" Visible="false">View</asp:HyperLink></td>
                                                                                     <td>
                                                                                          <asp:Button ID="butsec" runat="server" Text="View" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>


                                                                    <tr>
                                                                        <td style="width: 105px">
                                                                            <asp:Label ID="Label14" runat="server" Height="14px" Width="200px" CssClass="Lables">Registered Lease Deed</asp:Label></td>
                                                                        <td style="width: 63px">
                                                                            <asp:DropDownList Style="z-index: 0" ID="drplease1" TabIndex="18" runat="server" Width="91px" CssClass=" "
                                                                                AutoPostBack="True">
                                                                                <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                                                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                                                                <asp:ListItem Value="2">No </asp:ListItem>
                                                                            </asp:DropDownList></td>
                                                                        <td style="width: 92px; height: 8px">
                                                                            <asp:DropDownList Style="z-index: 0" ID="drplease2" TabIndex="19" runat="server" Width="100%" CssClass=" ">
                                                                                <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                                                                <asp:ListItem Value="1">Submitted</asp:ListItem>
                                                                                <asp:ListItem Value="2">Not Submitted</asp:ListItem>
                                                                            </asp:DropDownList></td>
                                                                        <td style="width: 48px">
                                                                            <table style="z-index: 0" id="Table17" border="0" cellspacing="1" cellpadding="0" width="100%"
                                                                                runat="server">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:TextBox Style="z-index: 0" ID="txtleasefrom" TabIndex="20" runat="server" Width="85px" CssClass=" "
                                                                                            MaxLength="16" ToolTip="DD/MM/YYYY"></asp:TextBox></td>
                                                                                    <td>
                                                                                        <asp:TextBox Style="z-index: 0" ID="txtleaseto" TabIndex="21" runat="server" Width="85px" CssClass=" "
                                                                                            MaxLength="16" ToolTip="DD/MM/YYYY"></asp:TextBox></td>
                                                                                    <td>
                                                                                        <input style="z-index: 0; width: 200px; height: 20px" id="cerleasepath1" tabindex="22" type="file"
                                                                                            name="cermunpath1" runat="server"></td>
                                                                                    <td>
                                                                                        <asp:HyperLink Style="z-index: 0" ID="HyperLink3" onclick="return hs.expand(this)" runat="server"
                                                                                            Font-Bold="True" ForeColor="DeepSkyBlue" Text="ViewImg" Visible="false">View</asp:HyperLink></td>
                                                                                     <td>
                                                                                          <asp:Button ID="butlease" runat="server" Text="View" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>

                                                                    <tr>
                                                                        <td style="width: 105px">
                                                                            <asp:Label ID="Label15" runat="server" Height="14px" Width="200px" CssClass="Lables"> Building Permission </asp:Label></td>
                                                                        <td style="width: 63px">
                                                                            <asp:DropDownList Style="z-index: 0" ID="drpbuilding1" TabIndex="18" runat="server" Width="91px" CssClass=" "
                                                                                AutoPostBack="True">
                                                                                <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                                                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                                                                <asp:ListItem Value="2">No </asp:ListItem>
                                                                            </asp:DropDownList></td>
                                                                        <td style="width: 92px; height: 8px">
                                                                            <asp:DropDownList Style="z-index: 0" ID="drpbuilding2" TabIndex="19" runat="server" Width="100%" CssClass=" ">
                                                                                <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                                                                <asp:ListItem Value="1">Submitted</asp:ListItem>
                                                                                <asp:ListItem Value="2">Not Submitted</asp:ListItem>
                                                                            </asp:DropDownList></td>
                                                                        <td style="width: 48px">
                                                                            <table style="z-index: 0" id="Table18" border="0" cellspacing="1" cellpadding="0" width="100%"
                                                                                runat="server">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:TextBox Style="z-index: 0" ID="txtbuildingfrom" TabIndex="20" runat="server" Width="85px" CssClass=" "
                                                                                            MaxLength="16" ToolTip="DD/MM/YYYY"></asp:TextBox></td>
                                                                                    <td>
                                                                                        <asp:TextBox Style="z-index: 0" ID="txtbuildingto" TabIndex="21" runat="server" Width="85px" CssClass=" "
                                                                                            MaxLength="16" ToolTip="DD/MM/YYYY"></asp:TextBox></td>
                                                                                    <td>
                                                                                        <input style="z-index: 0; width: 200px; height: 20px" id="cerbuildingpath1" tabindex="22" type="file"
                                                                                            name="cermunpath1" runat="server"></td>
                                                                                    <td>
                                                                                        <asp:HyperLink Style="z-index: 0" ID="HyperLink5" onclick="return hs.expand(this)" runat="server"
                                                                                            Font-Bold="True" ForeColor="DeepSkyBlue" Text="ViewImg" Visible="false">View</asp:HyperLink></td>
                                                                                     <td>
                                                                                          <asp:Button ID="Butfdr" runat="server" Text="View" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>

                                                                    <tr>
                                                                        <td style="width: 105px">
                                                                            <asp:Label ID="Label16" runat="server" Height="14px" Width="200px" CssClass="Lables"> Sketch Plan </asp:Label></td>
                                                                        <td style="width: 63px">
                                                                            <asp:DropDownList Style="z-index: 0" ID="drpsketch1" TabIndex="18" runat="server" Width="91px" CssClass=" "
                                                                                AutoPostBack="True">
                                                                                <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                                                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                                                                <asp:ListItem Value="2">No </asp:ListItem>
                                                                            </asp:DropDownList></td>
                                                                        <td style="width: 92px; height: 8px">
                                                                            <asp:DropDownList Style="z-index: 0" ID="drpsketch2" TabIndex="19" runat="server" Width="100%" CssClass=" ">
                                                                                <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                                                                <asp:ListItem Value="1">Submitted</asp:ListItem>
                                                                                <asp:ListItem Value="2">Not Submitted</asp:ListItem>
                                                                            </asp:DropDownList></td>
                                                                        <td style="width: 48px">
                                                                            <table style="z-index: 0" id="Table19" border="0" cellspacing="1" cellpadding="0" width="100%"
                                                                                runat="server">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:TextBox Style="z-index: 0" ID="txtsketchfrom" TabIndex="20" runat="server" Width="85px" CssClass=" "
                                                                                            MaxLength="16" ToolTip="DD/MM/YYYY"></asp:TextBox></td>
                                                                                    <td>
                                                                                        <asp:TextBox Style="z-index: 0" ID="txtsketchto" TabIndex="21" runat="server" Width="85px" CssClass=" "
                                                                                            MaxLength="16" ToolTip="DD/MM/YYYY"></asp:TextBox></td>
                                                                                    <td>
                                                                                        <input style="z-index: 0; width: 200px; height: 20px" id="cerskecthpath1" tabindex="22" type="file"
                                                                                            name="cermunpath1" runat="server"></td>
                                                                                    <td>
                                                                                        <asp:HyperLink Style="z-index: 0" ID="HyperLink6" onclick="return hs.expand(this)" runat="server"
                                                                                            Font-Bold="True" ForeColor="DeepSkyBlue" Text="ViewImg" Visible="false">View</asp:HyperLink></td>
                                                                                     <td>
                                                                                          <asp:Button ID="Button1" runat="server" Text="View" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>

                                                                    <tr>
                                                                        <td>
                                                                            <table>
                                                                                <tr>
                                                                                  
                                                                                    <td style="width: 115px">
                                                                                           <asp:Label ID="Label17" runat="server" Height="14px" Width="212px" CssClass="Lables">Recognition Status/State or CBSE: </asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>

                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 105px">
                                                                            <asp:Label ID="Label18" runat="server" Height="14px" Width="200px" CssClass="Lables"> PP </asp:Label></td>
                                                                        <td style="width: 63px">
                                                                            <asp:DropDownList Style="z-index: 0" ID="drppp1" TabIndex="18" runat="server" Width="91px" CssClass=" "
                                                                                AutoPostBack="True">
                                                                                <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                                                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                                                                <asp:ListItem Value="2">No </asp:ListItem>
                                                                            </asp:DropDownList></td>
                                                                        <td style="width: 92px; height: 8px">
                                                                            <asp:DropDownList Style="z-index: 0" ID="drppp2" TabIndex="19" runat="server" Width="100%" CssClass=" ">
                                                                                <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                                                                <asp:ListItem Value="1">Submitted</asp:ListItem>
                                                                                <asp:ListItem Value="2">Not Submitted</asp:ListItem>
                                                                            </asp:DropDownList></td>
                                                                        <td style="width: 48px">
                                                                            <table style="z-index: 0" id="Table21" border="0" cellspacing="1" cellpadding="0" width="100%"
                                                                                runat="server">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:TextBox Style="z-index: 0" ID="txtppfrom" TabIndex="20" runat="server" Width="85px" CssClass=" "
                                                                                            MaxLength="16" ToolTip="DD/MM/YYYY"></asp:TextBox></td>
                                                                                    <td>
                                                                                        <asp:TextBox Style="z-index: 0" ID="txtppto" TabIndex="21" runat="server" Width="85px" CssClass=" "
                                                                                            MaxLength="16" ToolTip="DD/MM/YYYY"></asp:TextBox></td>
                                                                                    <td>
                                                                                        <input style="z-index: 0; width: 200px; height: 20px" id="cerspppath1" tabindex="22" type="file"
                                                                                            name="cermunpath1" runat="server"></td>
                                                                                    <td>
                                                                                        <asp:HyperLink Style="z-index: 0" ID="HyperLink7" onclick="return hs.expand(this)" runat="server"
                                                                                            Font-Bold="True" ForeColor="DeepSkyBlue" Text="ViewImg" Visible="false">View</asp:HyperLink></td>
                                                                                     <td>
                                                                                          <asp:Button ID="Button5" runat="server" Text="View" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 105px">
                                                                            <asp:Label ID="Label19" runat="server" Height="14px" Width="200px" CssClass="Lables">  I-V  </asp:Label></td>
                                                                        <td style="width: 63px">
                                                                            <asp:DropDownList Style="z-index: 0" ID="drpOF1" TabIndex="18" runat="server" Width="91px" CssClass=" "
                                                                                AutoPostBack="True">
                                                                                <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                                                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                                                                <asp:ListItem Value="2">No </asp:ListItem>
                                                                            </asp:DropDownList></td>
                                                                        <td style="width: 92px; height: 8px">
                                                                            <asp:DropDownList Style="z-index: 0" ID="drpOF2" TabIndex="19" runat="server" Width="100%" CssClass=" ">
                                                                                <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                                                                <asp:ListItem Value="1">Submitted</asp:ListItem>
                                                                                <asp:ListItem Value="2">Not Submitted</asp:ListItem>
                                                                            </asp:DropDownList></td>
                                                                        <td style="width: 48px">
                                                                            <table style="z-index: 0" id="Table22" border="0" cellspacing="1" cellpadding="0" width="100%"
                                                                                runat="server">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:TextBox Style="z-index: 0" ID="txtOFfrom" TabIndex="20" runat="server" Width="85px" CssClass=" "
                                                                                            MaxLength="16" ToolTip="DD/MM/YYYY"></asp:TextBox></td>
                                                                                    <td>
                                                                                        <asp:TextBox Style="z-index: 0" ID="txtOFto" TabIndex="21" runat="server" Width="85px" CssClass=" "
                                                                                            MaxLength="16" ToolTip="DD/MM/YYYY"></asp:TextBox></td>
                                                                                    <td>
                                                                                        <input style="z-index: 0; width: 200px; height: 20px" id="cersonefourpath1" tabindex="22" type="file"
                                                                                            name="cermunpath1" runat="server"></td>
                                                                                    <td>
                                                                                        <asp:HyperLink Style="z-index: 0" ID="HyperLink8" onclick="return hs.expand(this)" runat="server"
                                                                                            Font-Bold="True" ForeColor="DeepSkyBlue" Text="ViewImg" Visible="false">View</asp:HyperLink></td>
                                                                                     <td>
                                                                                          <asp:Button ID="Button6" runat="server" Text="View" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 105px">
                                                                            <asp:Label ID="Label20" runat="server" Height="14px" Width="200px" CssClass="Lables"> VI-X</asp:Label></td>
                                                                        <td style="width: 63px">
                                                                            <asp:DropDownList Style="z-index: 0" ID="drpST1" TabIndex="18" runat="server" Width="91px" CssClass=" "
                                                                                AutoPostBack="True">
                                                                                <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                                                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                                                                <asp:ListItem Value="2">No </asp:ListItem>
                                                                            </asp:DropDownList></td>
                                                                        <td style="width: 92px; height: 8px">
                                                                            <asp:DropDownList Style="z-index: 0" ID="drpST2" TabIndex="19" runat="server" Width="100%" CssClass=" ">
                                                                                <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                                                                <asp:ListItem Value="1">Submitted</asp:ListItem>
                                                                                <asp:ListItem Value="2">Not Submitted</asp:ListItem>
                                                                            </asp:DropDownList></td>
                                                                        <td style="width: 48px">
                                                                            <table style="z-index: 0" id="Table23" border="0" cellspacing="1" cellpadding="0" width="100%"
                                                                                runat="server">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:TextBox Style="z-index: 0" ID="txtSTfrom" TabIndex="20" runat="server" Width="85px" CssClass=" "
                                                                                            MaxLength="16" ToolTip="DD/MM/YYYY"></asp:TextBox></td>
                                                                                    <td>
                                                                                        <asp:TextBox Style="z-index: 0" ID="txtSTTo" TabIndex="21" runat="server" Width="85px" CssClass=" "
                                                                                            MaxLength="16" ToolTip="DD/MM/YYYY"></asp:TextBox></td>
                                                                                    <td>
                                                                                        <input style="z-index: 0; width: 200px; height: 20px" id="cersSTpath1" tabindex="22" type="file"
                                                                                            name="cermunpath1" runat="server"></td>
                                                                                    <td>
                                                                                        <asp:HyperLink Style="z-index: 0" ID="HyperLink9" onclick="return hs.expand(this)" runat="server"
                                                                                            Font-Bold="True" ForeColor="DeepSkyBlue" Text="ViewImg" Visible="false">View</asp:HyperLink></td>
                                                                                     <td>
                                                                                          <asp:Button ID="Button7" runat="server" Text="View" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <table>
                                                                                <tr>
                                                                                  
                                                                                    <td style="width: 115px">
                                                                                           <asp:Label ID="Label21" runat="server" Height="14px" Width="200px" CssClass="Lables">National Savings Certificates: </asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>

                                                                        
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 105px">
                                                                            <asp:Label ID="Label22" runat="server" Height="14px" Width="200px" CssClass="Lables">  Amount  </asp:Label></td>
                                                                        <td style="width: 63px">
                                                                            <asp:DropDownList Style="z-index: 0" ID="drpAmount1" TabIndex="18" runat="server" Width="91px" CssClass=" "
                                                                                AutoPostBack="True">
                                                                                <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                                                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                                                                <asp:ListItem Value="2">No </asp:ListItem>
                                                                            </asp:DropDownList></td>
                                                                        <td style="width: 92px; height: 8px">
                                                                            <asp:DropDownList Style="z-index: 0" ID="drpAmount2" TabIndex="19" runat="server" Width="100%" CssClass=" ">
                                                                                <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                                                                <asp:ListItem Value="1">Submitted</asp:ListItem>
                                                                                <asp:ListItem Value="2">Not Submitted</asp:ListItem>
                                                                            </asp:DropDownList></td>
                                                                        <td style="width: 48px">
                                                                            <table style="z-index: 0" id="Table24" border="0" cellspacing="1" cellpadding="0" width="100%"
                                                                                runat="server">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:TextBox Style="z-index: 0" ID="txtAmountfrom" TabIndex="20" runat="server" Width="85px" CssClass=" "
                                                                                            MaxLength="16" ToolTip="DD/MM/YYYY"></asp:TextBox></td>
                                                                                    <td>
                                                                                        <asp:TextBox Style="z-index: 0" ID="txtAmountto" TabIndex="21" runat="server" Width="85px" CssClass=" "
                                                                                            MaxLength="16" ToolTip="DD/MM/YYYY"></asp:TextBox></td>
                                                                                    <td>
                                                                                        <input style="z-index: 0; width: 200px; height: 20px" id="cersAmountpath1" tabindex="22" type="file"
                                                                                            name="cermunpath1" runat="server"></td>
                                                                                    <td>
                                                                                        <asp:HyperLink Style="z-index: 0" ID="HyperLink10" onclick="return hs.expand(this)" runat="server"
                                                                                            Font-Bold="True" ForeColor="DeepSkyBlue" Text="ViewImg" Visible="false">View</asp:HyperLink></td>
                                                                                     <td>
                                                                                          <asp:Button ID="Button8" runat="server" Text="View" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    </tbody>
                                                                </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TableBorder" valign="middle" align="right">
                                                <asp:ImageButton AccessKey="S" ID="iBtnSave" TabIndex="23" runat="server" Width="92px" Height="20px"
                                                    ImageUrl="../../Images/NewImages/save.gif"></asp:ImageButton></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center"></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </tbody>
        </table>
        </TD></TR></TBODY></TABLE>
    </form>
    </TD></TR></TBODY></TABLE>
</body>
</HTML>

