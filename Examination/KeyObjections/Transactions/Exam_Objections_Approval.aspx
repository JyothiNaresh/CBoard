<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Exam_Objections_Approval.aspx.vb" Inherits="CollegeBoard.Exam_Objections_Approval"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Exam_Objections_Approval</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK id="Link1" href="../../../Images/Login/StyleSheet_Report.css" type="text/css" rel="stylesheet">
		<script language="javascript" type="text/javascript" src="../../Include/GridScript.js"></script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="1"
				cellPadding="1" width="100%" align="center" border="1">
				<TR>
					<TD align="center"><asp:label id="Label1" runat="server" Font-Size="Small" Width="100%" CssClass="Subheading1">Objections Approval</asp:label></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="70%" align="center" border="1">
							<TR>
								<TD align="center" width="7%" style="HEIGHT: 14px"><asp:label id="Label2" runat="server" Width="100%" CssClass="Lables">Exam.Date</asp:label></TD>
								<TD align="center" width="10%" style="HEIGHT: 14px"><asp:dropdownlist id="DrpExamDate" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								<TD align="center" width="7%" style="HEIGHT: 14px"><asp:label id="Label4" runat="server" Width="100%" CssClass="Lables">Exam.Name</asp:label></TD>
								<TD align="center" width="35%" style="HEIGHT: 14px"><asp:dropdownlist id="DrpExamName" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="4"><asp:label id="LbsPS" runat="server" Width="100%" BackColor="#FFC080" ForeColor="#000099" Font-Bold="True"></asp:label></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="4">
									<asp:label id="Label3" runat="server" Width="100%" Font-Bold="True" ForeColor="#000099" BackColor="#FFC080">Note : Cor.Ans must be Numeric(1 / 12 / 123) For (1 Or 2, 1 and 2) Enter R12 </asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center"><asp:datagrid id="DgSummary" runat="server" CssClass="GRIDMAIN" AutoGenerateColumns="False">
							<ItemStyle Height="23px"></ItemStyle>
							<HeaderStyle Height="25px" CssClass="GRIDHEADER"></HeaderStyle>
							<Columns>
								<asp:HyperLinkColumn Text="+">
									<HeaderStyle Width="3%"></HeaderStyle>
									<ItemStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#B8773D"></ItemStyle>
								</asp:HyperLinkColumn>
								<asp:TemplateColumn HeaderText="SNO">
									<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
									<ItemTemplate>
										<%#Container.DataSetIndex+1 %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="SBJNAME" HeaderText="SUBJECT"></asp:BoundColumn>
								<asp:BoundColumn DataField="QUESTIONNO" HeaderText="QNO">
									<HeaderStyle HorizontalAlign="Center" Width="15px" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="OBJGIVENKEY" HeaderText="GIVEN.KEY">
									<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="OBJCNT" HeaderText="OBJ.CNT">
									<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" ForeColor="#000099" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="STATUS">
									<ItemTemplate>
										<asp:DropDownList id="DrpStatus" runat="server" Width="70px" AutoPostBack="True" OnSelectedIndexChanged="DrpStatus_SelectedIndexChanged">
											<asp:ListItem Value="1">Accept</asp:ListItem>
											<asp:ListItem Value="0" Selected="True">Reject</asp:ListItem>
										</asp:DropDownList>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="ACTION">
									<ItemTemplate>
										<asp:DropDownList id="DrpAction" runat="server" Width="70px" AutoPostBack="True" OnSelectedIndexChanged="DrpAction_SelectedIndexChanged"
											Enabled="False">
											<asp:ListItem Value="0" Selected="True">Deleted</asp:ListItem>
											<asp:ListItem Value="1">ChangeKey</asp:ListItem>
										</asp:DropDownList>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="COR.ANS">
									<ItemTemplate>
										<asp:TextBox id="TxtCorAns" runat="server" Width="50px" Enabled="False"></asp:TextBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="REMARKS">
									<ItemTemplate>
										<asp:TextBox id="TxtGRem" runat="server" Width="300px" ForeColor="#C04000" Height="20px" TextMode="MultiLine"
											Enabled="False"></asp:TextBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="OBJSUBJECTSLNO">
									<HeaderStyle Width="0px"></HeaderStyle>
									<ItemStyle ForeColor="#EBDED6"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="OBJQSTN">
									<HeaderStyle Width="0px"></HeaderStyle>
									<ItemStyle ForeColor="#EBDED6"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table3" height="25" cellSpacing="1" cellPadding="1" width="300" align="center"
							border="1">
							<TR>
								<TD align="center" width="30%">
									<asp:ImageButton id="IbtnSave" runat="server" Width="100%" Height="20px" ImageUrl="../../../Images/NewImages/save.gif"></asp:ImageButton></TD>
								<TD align="center" width="30%">
									<asp:ImageButton id="IbtnCancel" runat="server" Height="20px" ImageUrl="../../../Images/NewImages/cancel.gif"
										Width="100%"></asp:ImageButton></TD>
								<TD align="center" width="40%">
									<asp:ImageButton id="IbtnNilMst" runat="server" Width="100%" Height="20px" ImageUrl="../../../Images/NewImages/nil_mistakes.gif"></asp:ImageButton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center"><asp:textbox id="txtExpandedDivs" runat="server" Width="100%" Visible="False"></asp:textbox></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
