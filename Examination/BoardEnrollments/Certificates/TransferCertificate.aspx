<%@ Page Language="vb" AutoEventWireup="false" Codebehind="TransferCertificate.aspx.vb" Inherits="CollegeBoard.TransferCertificate"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>TransferCertificate</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK id="Link1" href="../../../Images/Login/StyleSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table7" style="Z-INDEX: 105; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="0"
				cellPadding="1" width="100%" border="0">
				<TR>
					<TD align="center">
						<TABLE id="Table4" style="WIDTH: 735px; HEIGHT: 120px" cellSpacing="0" cellPadding="0"
							width="735" border="1">
							<TR>
								<TD style="HEIGHT: 7px" width="10%">
									<asp:label id="Label3" runat="server" Width="100%" CssClass="Lables">ExamBranch</asp:label></TD>
								<TD style="HEIGHT: 7px" width="15%">
									<asp:dropdownlist id="DrpExamBranch" runat="server" Width="200px" CssClass=" " AutoPostBack="True"></asp:dropdownlist></TD>
								<TD style="HEIGHT: 7px" width="15%">
									<asp:label id="lblCourse" runat="server" Width="100%" CssClass="Lables">Board&nbsp;College</asp:label></TD>
								<TD style="HEIGHT: 7px" width="50%">
									<asp:dropdownlist id="DrpBoardCollege" runat="server" Width="100%" CssClass=" " AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD vAlign="middle" align="right" colSpan="5">
									<asp:imagebutton id="iBtnGo" accessKey="G" runat="server" Width="80px" Height="20px" ImageUrl="../../../Images/NewImages/search.gif"
										Visible="False"></asp:imagebutton></TD>
							</TR>
							<TR>
								<TD vAlign="middle" align="center" colSpan="5">
									<TABLE id="Table6" style="WIDTH: 545px; HEIGHT: 30px" cellSpacing="1" cellPadding="1" width="545"
										border="1">
										<TR>
											<TD>
												<asp:radiobutton id="Rbtntc" runat="server" Width="280px" CssClass="Lables" AutoPostBack="True" Height="1px"
													TextAlign="Left" GroupName="Opt" Text="TRANSFER CERTIFICATE"></asp:radiobutton></TD>
											<TD>
												<asp:radiobutton id="Rbtncc" runat="server" Width="272px" CssClass="lables" AutoPostBack="True" Height="15px"
													TextAlign="Left" GroupName="Opt" Text="CONDUCT CERTIFICATE"></asp:radiobutton></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD vAlign="top" align="center" colSpan="5">
									<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD align="center" width="10%">
												<asp:label id="Label1" runat="server" Width="100%" CssClass="Lables">Select</asp:label></TD>
											<TD align="center" width="15%">
												<asp:dropdownlist id="drpSelect" runat="server" Width="100%" CssClass=" ">
													<asp:ListItem Value="1">ADMNO</asp:ListItem>
													<asp:ListItem Value="2">Name</asp:ListItem>
												</asp:dropdownlist></TD>
											<TD align="center" width="65%">
												<asp:textbox id="TxtSelect" runat="server" Width="100%"></asp:textbox></TD>
											<TD vAlign="middle" align="left" width="50%">
												<asp:imagebutton id="IbtnSearch" accessKey="G" runat="server" Width="80px" Height="20px" ImageUrl="../../../Images/NewImages/search.gif"></asp:imagebutton></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD vAlign="top" align="center" colSpan="5"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
