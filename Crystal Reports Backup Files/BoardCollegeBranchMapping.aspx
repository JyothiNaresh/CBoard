<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="BoardCollegeBranchMapping.aspx.vb" Inherits="CollegeBoard.BoardCollegeBranchMapping" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">


<html>
<head>
    <title>BUILDING_PG_DT</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link id="Link1" rel="stylesheet" type="text/css" href="../../../Images/Login/StyleSheet_Report.css">
    <link rel="stylesheet" type="text/css" href="../../../Styles/MultiComboSelect/jquery.multiselect.css">
    <link rel="stylesheet" type="text/css" href="../../../Styles/MultiComboSelect/jquery.multiselect.filter.css">
    <link rel="stylesheet" type="text/css" href="../../../Styles/MultiComboSelect/jquery-ui.css">
    <link rel="stylesheet" type="text/css" href="../../../Styles/MultiComboSelect/prettify.css">
    <%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.js"></script>
		<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1/jquery-ui.min.js"></script>
		<script type="text/javascript" src="http://www.erichynds.com/examples/jquery-ui-multiselect-widget/src/jquery.multiselect.js"></script>
		<script type="text/javascript" src="http://www.erichynds.com/examples/jquery-ui-multiselect-widget/src/jquery.multiselect.filter.js"></script>
		<SCRIPT language="javascript" type="text/javascript" src="../../../Modules/ts_picker.js">
		
		function showFocus()
		 {
			var id = event.srcElement.id
			alert("Pick Date")
		}
		
		</SCRIPT>
		<script language="javascript" type="text/javascript">
		 function checkNum()
			{
				var carCode = event.keyCode;if ((carCode < 48) || (carCode > 57))
			{
				alert('Please enter only numbers.');
				event.cancelBubble = true
				event.returnValue = false;
			}}
		</script>
		<script type="text/javascript">
			$(function(){
				
				$("#lstmCode").multiselect({multiple: true,noneSelectedText: "Select College Code",checkAllText:'Sel.All',uncheckAllText:'Rem.All',selectedList: 3,minWidth:200}).multiselectfilter({filter: function(event, matches){
					if( !matches.length ){ 
						}	}	});									
				});			
		</script>--%>
    <style type="text/css">
        .auto-style2 {
            width: 124px;
            height: 39px;
        }

        .Lables {
        }

        #Table10 {
            height: 27px;
            width: 1505%;
        }

        .auto-style4 {
            width: 108px;
        }

        #Table4 {
            height: 126px;
        }
        .auto-style5 {
            background-color: #B8773D;
            width: 22px;
        }
        .auto-style6 {
            background-color: #E4C7AD;
            height: 4px;
            width: 22px;
        }
        .auto-style7 {
            border: 1px solid #B8773D;
            width: 22px;
        }
        .auto-style8 {
            width: 22px;
        }
        .auto-style9 {
            width: 122px;
        }
        .auto-style10 {
            width: 38px;
        }
    </style>
</head>
<body ms_positioning="GridLayout">
    <form id="Form1" method="post" autocomplete="off" runat="server">
        <asp:TextBox ID="txtlblCode" runat="server" Width="0px" Height="32px">XXXXXX</asp:TextBox>
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
                                                            <img src="../../../Images/Login/table-lcorw.gif" width="11" height="11"></td>
                                                        <td class="SubHeading">
                                                            <asp:Label ID="lblHeading" runat="server" Width="100%" Font-Bold="True" CssClass="SubHeading1"> List  of College Wise Details  of Board College Branch Mapping </asp:Label></td>
                                                        <td valign="top" width="11">
                                                            <img src="../../../Images/Login/table-rcorw.gif" width="11" height="11"></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TdBorder">
                                                <img src="../../../Images/Login/spacer.gif" width="1" height="1"></td>
                                        </tr>
                                        <tr>
                                            <td class="TableBorder" valign="top" align="center">
                                                <table id="Table12" border="0" cellspacing="0" cellpadding="0" width="200">
                                                    <tr>
                                                        <%--<TD width="250"><SELECT style="Z-INDEX: 0; WIDTH: 100px" multiple name="Prdcity" RUNAT="server" id="lstmCode"></SELECT></TD>--%>
                                                        <td width="250">
                                                            <asp:TextBox ID="lstmCode" runat="server" Width="152px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton AccessKey="G" Style="z-index: 0" ID="imgBtnGoo1" TabIndex="1" runat="server" Width="40px"
                                                                Height="17px" ImageUrl="../../../Images/NewImages/go.gif"></asp:ImageButton></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TableBorder" valign="top" align="center"></td>
                                        </tr>
                                        <tr>
                                            <td class="TableBorder" valign="top" align="center">
                                                <asp:DataGrid ID="dgGridSection" TabIndex="1" runat="server" Width="198px" CssClass="GridMain"
                                                    CellSpacing="2" OnItemCreated="DeleteConformationMessage" BorderStyle="Dotted" CellPadding="0" BorderWidth="0px" AutoGenerateColumns="False"
                                                    AllowPaging="True" PageSize="50">
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
                                                        <asp:BoundColumn Visible="False" DataField="BRANCHSLNO" HeaderText="SLNO">
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
                                                        <asp:BoundColumn DataField="BRANCHNAME" HeaderText="Branch Name">
                                                            <HeaderStyle Wrap="False" Width="10%" VerticalAlign="Middle"></HeaderStyle>
                                                            <ItemStyle Wrap="False" VerticalAlign="Middle"></ItemStyle>
                                                        </asp:BoundColumn>
                                                        <asp:EditCommandColumn ButtonType="PushButton" UpdateText="Update" CancelText="Cancel" EditText="Edit">
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                                        </asp:EditCommandColumn>
                                                        <asp:ButtonColumn Text="Delete" ButtonType="PushButton" CommandName="Delete" Visible="False">
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                                        </asp:ButtonColumn>
                                                    </Columns>
                                                    <PagerStyle HorizontalAlign="Center" CssClass="GridPager" Mode="NumericPages"></PagerStyle>
                                                </asp:DataGrid></td>
                                        </tr>
                                        <tr>
                                            <td class="TableBorder" valign="middle" align="right">
                                                <asp:ImageButton AccessKey="S" ID="iBtnAdd" TabIndex="5" runat="server" Width="92px" Height="20px"
                                                    ImageUrl="../../../Images/NewImages/add.gif" Visible="False"></asp:ImageButton>&nbsp;&nbsp;&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                    <table id="Table4" border="0" cellspacing="0" cellpadding="0" width="426" runat="server">
                                        <tr>
                                            <td align="center"></td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <table id="Table6" class="Panel" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td align="center">
                                                            <table id="Table7" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td class="auto-style5">
                                                                        <table id="Table8" border="0" cellspacing="0" cellpadding="0" width="100%">
                                                                            <tr>
                                                                                <td valign="top" width="11">
                                                                                    <img src="../../../Images/Login/table-lcorw.gif" width="11" height="11"></td>
                                                                                <td class="SubHeading">
                                                                                    <asp:Label ID="Label10" runat="server" Width="320px" Height="8px" Font-Bold="True" CssClass="SubHeading1"> Branch Mapping </asp:Label></td>
                                                                               <%-- <td valign="top" width="11">--%>
                                                                                    <%--<img src="../../../Images/Login/table-rcorw.gif" width="11" height="11"></td>--%>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="auto-style6">
                                                                        <img src="../../../Images/Login/spacer.gif" width="1" height="1"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="auto-style7" valign="top" align="left">
                                                                        <table id="Table9" border="0" cellspacing="0" cellpadding="0">
                                                                        </table>
                                                                        <table id="Table5" border="0" cellspacing="0" cellpadding="0" width="330">
                                                                            <tr>
                                                                                <td style="width: 116px">
                                                                                    <asp:Label Style="z-index: 0" ID="Label2" runat="server" Width="128px" Height="19px" CssClass="Lables">College Code</asp:Label></td>
                                                                                <td class="auto-style10">
                                                                                    <asp:TextBox Style="z-index: 0" ID="Txtccode" runat="server" Width="115px" CssClass=" " MaxLength="10"></asp:TextBox></td>
                                                                                <td align="left" class="auto-style9">
                                                                                    <asp:ImageButton AccessKey="G" ID="imgBtnGo" TabIndex="1" runat="server" Width="78px" Height="17px"
                                                                                        ImageUrl="../../../Images/NewImages/search.gif"></asp:ImageButton></td>
                                                                            </tr>
                                                                               <TR>
																					<TD colSpan="3" align="center"><asp:label style="Z-INDEX: 0" id="LBLCLGNAME" runat="server" Width="100%" Height="19px" CssClass="Lables"
																							BackColor="Info">College Name</asp:label></TD>
																				</TR>

                                                                        </table>
                                                                      
                                                                        <table id="Table10" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td class="auto-style8">
                                                                                    <asp:Label ID="Label1" runat="server" Width="273%" Height="14px" CssClass="Lables"> Branch</asp:Label></td>
                                                                                <td>
                                                                                   <TD><asp:dropdownlist id="drpBranch" runat="server" CssClass="textboxASR" Width="200px"></asp:dropdownlist></TD>
                                                                            </tr>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                        </td>

                                                    </tr>
                                                <td class="auto-style8">

                                           <%-- <td class="auto-style4">--%>
                                        </tr>
                                    <%--<td class="auto-style2">--%>
                            </tr>
                    </td>
                </tr>
        </table>
        </td>
                                        </tr>
                                      
                                    </table>
                                </td>
                            </tr>
        <TR>
															<TD class="TableBorder" vAlign="middle" align="right"><asp:imagebutton accessKey="S" style="Z-INDEX: 0" id="iBtnSave" tabIndex="13" runat="server" Width="92px"
																	Height="20px" ImageUrl="../../../Images/NewImages/save.gif"></asp:imagebutton>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
														</TR>

                        </table>
                    </td>
                </tr>
        </table>
        </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </tbody>
        </table>
    </form>
    </TD></TR></TBODY></TABLE>
</body>
</html>


